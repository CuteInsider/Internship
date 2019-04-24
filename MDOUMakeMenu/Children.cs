using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MDOUMakeMenu
{
    public partial class Children : Form
    {
        Table attendance = new Table();
        Table children = new Table();

        object Role;
        bool newRowC = false;
        bool newRowG = false;

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

                for (; LastDate.Day < NowDate.Day;)
                {
                    int colRows = 0;
                    if (colRows == 0)
                        colRows = Convert.ToInt32(date.Query("SELECT count(*) FROM groups"));

                    LastDate = LastDate.AddDays(1);
                    date.Query("INSERT INTO date (Date) VALUES ('" + LastDate.ToString("yyyy-MM-dd") + "')");
                    int dateId = Convert.ToInt32(date.Query("SELECT ID FROM date ORDER BY date DESC"));
                    for (int i = 1; i <= colRows; i++)
                        date.Query("INSERT INTO attendance (DateID, GroupID, ActuallyChildrenAmount) VALUES (" + dateId + ", " + i + ", " + 0 + ")");
                }
                dataView.DataSource = date.newTable("SELECT * FROM date ORDER BY ID");
                DataBase.Close();
                dataView.ValueMember = "ID";
                dataView.DisplayMember = "Date";
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            splitContainer2.Panel2Collapsed = true;
            splitContainer3.Panel1Collapsed = true;
            splitContainer3.Panel1.Hide();
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
        }

        private void dateView_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtAttendance.DataSource = attendance.newTable("SELECT attendance.Id, groups.ID, groups.GroupName, totalchildren.TotalChildren, attendance.ActuallyChildrenAmount " +
                "FROM attendance " +
                "INNER JOIN totalchildren ON attendance.GroupId = totalchildren.GroupID " +
                "INNER JOIN groups ON totalchildren.GroupID = groups.ID " +
                "WHERE DateID = '" + dataView.SelectedValue + "'");
        }

        //====== РАБОТА С ПОСЕЩАЙМОСТТЬЮ ======
        private void dtAttendance_DoubleClick(object sender, EventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).CurrentRow.IsNewRow == false)
            {
                dtChildren.AllowUserToAddRows = true;
                AgeGroup.DataSource = children.newTable("SELECT * FROM agegroup");
                AgeGroup.ValueMember = "ID";
                AgeGroup.DisplayMember = "agegroup";

                dtChildren.DataSource = children.newTable("SELECT childrens.ID, childrens.IDAgeGroup, childrens.SecondName, childrens.FistName, childrens.FatherName " +
                    "FROM childrens " +
                    "WHERE childrens.IDGroup = '" + dtAttendance.CurrentRow.Cells[1].Value + "'");

                newRowG = false;
            }
            else
                newRowG = true;
        }

        private void dtAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DataBase.Connect())
            {
                switch (e.ColumnIndex)
                {
                    case 2:
                        EndEditGroupName();
                        break;

                    case 3:
                        EndEditAllAmount();
                        break;

                    case 4:
                        EndEditCurrentAmount();
                        break;
                }
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    ((DataGridView)sender).DataSource = attendance.newTable("SELECT attendance.Id, groups.ID, groups.GroupName, totalchildren.TotalChildren, attendance.ActuallyChildrenAmount " +
                        "FROM attendance " +
                        "INNER JOIN totalchildren ON attendance.GroupId = totalchildren.GroupID " +
                        "INNER JOIN groups ON totalchildren.GroupID = groups.ID " +
                        "WHERE DateID = '" + dataView.SelectedValue + "'");
                }));
                DataBase.Close();
            }
            else
                MessageBox.Show(
                    "Проверте подключение к базе данных",
                    "Ошибка Подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void EndEditGroupName()
        {
            if (!string.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[2].Value.ToString()))
            {
                if (newRowG == true)
                {
                    attendance.Query("INSERT INTO groups VALUES('" + dtAttendance.CurrentRow.Cells[2].Value + "')");
                    int lastGroup = Convert.ToUInt16(attendance.Query("SELECT GroupID FROM totalchildren ORDER BY GroupID DESC"));
                    attendance.Query("INSERT INTO totalchildren VALUES('" + lastGroup + 1 + "')");
                }
                else
                {
                    attendance.Query("UPDATE groups SET GroupName = '" + dtAttendance.CurrentRow.Cells[2].Value + "' WHERE ID = " + dtAttendance.CurrentRow.Cells[1].Value + "");
                }
            }
            else
            {
                DialogResult = MessageBox.Show(
                    "Внимание",
                    "Вы действительно хотете удалить запсиь, удаление записи приведт к удалению всех данных связанных с ней",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                    attendance.Query("DELETE FROM group WHERE ID = " + dtAttendance.CurrentRow.Cells[2].Value + "");
            }
        }

        private void EndEditAllAmount()
        {
            if (newRowG == true)
            {
                return;
            }
            if (!String.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[3].Value.ToString()))
            {
                if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) >= Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value))
                {
                    int colRows = Convert.ToInt32(attendance.Query("SELECT count(*) " +
                        "FROM childrens WHERE IDGroup = " + dtAttendance.CurrentRow.Cells[0].Value + ""));
                    if (colRows > Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value))
                    {
                        dtAttendance.CancelEdit();
                        MessageBox.Show(
                            "Количество детей в группе блольше чем максимальное число",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    dtAttendance.CurrentRow.Cells[3].Value = dtAttendance.CurrentRow.Cells[4].Value;
                }
                attendance.Query("UPDATE totalchildren SET TotalChildren = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) +
                " WHERE GroupID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[1].Value) + "");

            }
            else
                dtAttendance.CancelEdit();
            //attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = NULL WHERE ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value));
        }

        private void EndEditCurrentAmount()
        {
            if (newRowG == true)
            {
                return;
            }
            if (!String.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[4].Value.ToString()))
            {
                if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) >= Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) && Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) >= 0)
                    attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) + " WHERE attendance.ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value) + "");
                else
                {
                    dtAttendance.CurrentRow.Cells[4].Value = 0;
                    MessageBox.Show(
                        "Введеное число превышает колтчество детей в группе",
                        "Ошибка Подключения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
                attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = 0 WHERE attendance.ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value));
        }

        //====== РАБОТА С ДЕТЬМИ ======
        private void dtChildren_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowC = false;
            }
            else
            {
                newRowC = true;
            }
        }

        private void dtChildren_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtChildren_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowC == true && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
            {
                return;
            }
            if (DataBase.Connect())
            {
                if (newRowC == true)
                {
                    int colRows = Convert.ToInt32(children.Query("SELECT count(*) FROM childrens WHERE IDGroup = " + dtAttendance.CurrentRow.Cells[1].Value + ""));
                    if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) > colRows)
                    {
                        children.Query("INSERT INTO childrens (IDGroup,`" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "`) " +
                            "VALUES (" + dtAttendance.CurrentRow.Cells[1].Value + ", '" + ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + "');");
                    }
                    else
                    {
                        ((DataGridView)sender).Rows.RemoveAt(e.RowIndex);
                        MessageBox.Show(
                            "Превышено максимальное число детей в группе",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (!String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                {
                    children.Query("UPDATE childrens SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = '" +
                        ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + "' WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                else
                {
                    children.Query("UPDATE childrens SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = NULL WHERE ID = " +
                        ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                if (String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[2].Value.ToString()) &&
                String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[3].Value.ToString()) &&
                String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[4].Value.ToString()) && newRowC == false)
                {
                    children.Query("DELETE FROM childrens WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    ((DataGridView)sender).DataSource = children.newTable(
                        "SELECT childrens.ID, childrens.IDAgeGroup, childrens.SecondName, childrens.FistName, childrens.FatherName " +
                        "FROM childrens " +
                        "WHERE childrens.IDGroup = '" + dtAttendance.CurrentRow.Cells[1].Value + "'");
                }));
                DataBase.Close();
            }
            else
                MessageBox.Show(
                    "Проверте подключение к базе данных",
                    "Ошибка Подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        //======РАБОТА С ОТЧЕТОМ======
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (cbStartDate.Checked == true)
            {
                int index = dataView.FindString(dtpStartDate.Value.ToShortDateString());
                if (index != -1)
                    dataView.SelectedIndex = index;
                else
                {
                    MessageBox.Show(
                        "Такой даты не сущевствует в списке",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
                dataView.SelectedIndex = 1;
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;

            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            int allRows = 1;
            cbStartDate.Enabled = false;
            cbEndDate.Enabled = false;
            for (int d = dataView.SelectedIndex; d <= dataView.Items.Count - 1; d++)
            {
                if (dataView.SelectedIndex != dataView.Items.Count - 1)
                    dataView.SelectedIndex++;
                DataRowView dateString = (DataRowView)dataView.Items[d];
                DateTime curDate = DateTime.Parse(dateString["Date"].ToString());
                workSheet.Cells[allRows, 1] = curDate.Date;
                for (int i = 1; i < dtAttendance.RowCount; i++)
                {
                    dtAttendance.Rows[i].Selected = true;
                    for (int j = 1; j < dtAttendance.ColumnCount - 1; j++)
                    {
                        workSheet.Cells[allRows + i, j] = dtAttendance.Rows[i].Cells[j + 1].Value;
                       //TODO: Сделать дизайн для отчета
                    }
                }
                allRows = allRows + dtAttendance.RowCount;
                if (cbEndDate.Checked == true)
                {
                    DateTime lastDate = dtpEndDate.Value.Date;
                    if (lastDate >= curDate)
                        break;
                }
                allRows = allRows + 1;
            }
            cbStartDate.Enabled = true;
            cbEndDate.Enabled = true;
            workSheet.Cells.EntireRow.AutoFit();
            excelApp.Visible = true;
        }

        private void cbStartDate_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Enabled == false)
                dtpStartDate.Enabled = true;
            else
                dtpStartDate.Enabled = false;
        }

        private void cbEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.Enabled == false)
                dtpEndDate.Enabled = true;
            else
                dtpEndDate.Enabled = false;
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
    }
}
