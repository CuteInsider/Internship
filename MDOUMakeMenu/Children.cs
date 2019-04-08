using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDOUMakeMenu
{
    public partial class Children : Form
    {
        Table attendance = new Table();
        object Role;
        public Children(Point Location, FormWindowState state, object Role)
        {
            InitializeComponent();
            Table date = new Table();
            this.Location = Location;
            this.WindowState = state;
            this.Role = Role;
            switch (Role)
            {
                case "A":
                    linkMenu.Enabled = true;
                    linkIngredients.Enabled = true;
                    linkChildren.Enabled = false;
                    break;

                case "T":
                    linkMenu.Enabled = false;
                    linkIngredients.Enabled = false;
                    linkChildren.Enabled = false;
                    break;

                case "M":
                    linkMenu.Enabled = true;
                    linkIngredients.Enabled = true;
                    linkChildren.Enabled = false;
                    break;
            }
            if (DataBase.Connect())
            {
                object result = date.Query("SELECT date FROM date ORDER BY date DESC");
                DateTime LastDate = Convert.ToDateTime(result);
                DateTime NowDate = DateTime.Now.Date;
                if (NowDate > LastDate)
                {
                    date.Query("INSERT INTO date (Date) VALUES ('" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "')");
                    int dateId = Convert.ToInt32(date.Query("SELECT ID FROM date ORDER BY date DESC"));
                    int colRows = Convert.ToInt32(date.Query("SELECT count(*) FROM groups"));
                    for (int i = 1; i <= colRows; i++)
                        date.Query("INSERT INTO attendance (DateID, GroupID, ActuallyChildrenAmount) VALUES (" + dateId + ", " + i + ", " + 0 + ")");
                }
                dateView.DataSource = date.newTable("SELECT * FROM date ORDER BY ID");
                DataBase.Close();
                dateView.ValueMember = "ID";
                dateView.DisplayMember = "Date";
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            splitContainer2.Panel2Collapsed = true;
            splitContainer3.Panel1Collapsed = true;
            splitContainer3.Panel1.Hide();
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
        }

        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Menu MForm = new Menu(Location, this.WindowState, Role);
            MForm.Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Dish DForm = new Dish(Location, this.WindowState, Role);
            DForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms[0].Show();
        }

        private void dateView_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtAttendance.DataSource = attendance.newTable("SELECT attendance.Id, groups.ID, groups.GroupName, totalchildren.TotalChildren, attendance.ActuallyChildrenAmount " +
                "FROM attendance " +
                "INNER JOIN totalchildren ON attendance.GroupId = totalchildren.GroupID " +
                "INNER JOIN groups ON totalchildren.GroupID = groups.ID " +
                "WHERE DateID = '" + dateView.SelectedValue + "'");
        }

        private void dtAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Table children = new Table();
            dtChildren.DataSource = children.newTable("SELECT agegroup.AgeGroup, childrens.SecondName, childrens.FistName, childrens.FatherName " +
                "FROM childrens " +
                "INNER JOIN agegroup ON childrens.IDAgeGroup = agegroup.ID " +
                "WHERE childrens.IDGroup = '" + dtAttendance.CurrentRow.Cells[1].Value + "'");
        }

        private void dtAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DataBase.Connect())
            {
                switch (e.ColumnIndex)
                {
                    case 3:
                        EndEditAllAmount();
                        break;

                    case 4:
                        EndEditCurrentAmount();
                        break;
                }
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EndEditAllAmount()
        {
            if (!String.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[3].Value.ToString()))
            {
                if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) >= Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value))
                    attendance.Query("UPDATE totalchildren SET TotalChildren = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) + " WHERE GroupID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[1].Value) + "");
                else
                {
                    dtAttendance.CurrentRow.Cells[3].Value = dtAttendance.CurrentRow.Cells[4].Value;
                    attendance.Query("UPDATE totalchildren SET TotalChildren = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) + " WHERE GroupID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[1].Value) + "");
                }
            }
            else
                dtAttendance.CancelEdit();
            //attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = NULL WHERE ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value));
        }

        private void EndEditCurrentAmount()
        {
            if (!String.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[4].Value.ToString()))
            {
                if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) >= Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) && Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) > 0)
                    attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) + " WHERE attendance.ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value) + "");
                else
                {
                    dtAttendance.CurrentRow.Cells[4].Value = 0;
                    MessageBox.Show("Введеное число превышает колтчество детей в группе", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = 0 WHERE attendance.ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value));
        }

        private void btnComposition_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
                if (splitContainer3.Panel1Collapsed == true)
                {
                    splitContainer3.Panel1Collapsed = false;
                    splitContainer3.Panel1.Show();
                    splitContainer3.Panel2Collapsed = true;
                    splitContainer3.Panel2.Hide();
                }
            }
            else if (splitContainer3.Panel2Collapsed == false)
            {
                if (splitContainer3.Panel1Collapsed == false)
                {
                    splitContainer3.Panel1Collapsed = true;
                    splitContainer3.Panel1.Hide();
                }
                else
                {
                    splitContainer3.Panel1Collapsed = false;
                    splitContainer3.Panel1.Show();
                }
            }
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void btnNone2_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
                if (splitContainer3.Panel2Collapsed == true)
                {
                    splitContainer3.Panel2Collapsed = false;
                    splitContainer3.Panel2.Show();
                    splitContainer3.Panel1Collapsed = true;
                    splitContainer3.Panel1.Hide();
                }
            }
            else if (splitContainer3.Panel1Collapsed == false)
            {
                if (splitContainer3.Panel2Collapsed == false)
                {
                    splitContainer3.Panel2Collapsed = true;
                    splitContainer3.Panel2.Hide();
                }
                else
                {
                    splitContainer3.Panel2Collapsed = false;
                    splitContainer3.Panel2.Show();
                }
            }
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void dtAttendance_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Ошибка ввода информации " + anError.Context.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
            }
            anError.ThrowException = false;

        }
    }
}
