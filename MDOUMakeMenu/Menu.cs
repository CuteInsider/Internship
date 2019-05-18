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
    public partial class Menu : Form
    {
        object Role;
        bool open = false;

        Table date = new Table();
        Table dinnerType = new Table();
        Table dish = new Table();
        Table menu = new Table();

        public Menu(Point Location, FormWindowState state, object Role)
        {
            InitializeComponent();
            this.Location = Location;
            this.WindowState = state;
            this.Role = Role;
            switch (Role)
            {
                case "A":
                    linkMenu.Enabled = false;
                    linkIngredients.Enabled = true;
                    linkChildren.Enabled = true;
                    break;

                case "T":
                    linkMenu.Enabled = false;
                    linkIngredients.Enabled = false;
                    linkChildren.Enabled = true;
                    break;

                case "M":
                    linkMenu.Enabled = false;
                    linkIngredients.Enabled = true;
                    linkChildren.Enabled = false;
                    break;
            }
            if (DataBase.Connect())
            {
                DateTime menuLastDate = Convert.ToDateTime(date.Query("SELECT Date FROM menu GROUP BY Date ORDER BY Date DESC"));
                DateTime attendanceLastDate = Convert.ToDateTime(date.Query("SELECT DISTINCT date FROM attendance ORDER BY date DESC"));
                DateTime NowDate = DateTime.Now.Date;
                while (attendanceLastDate.Date < NowDate.Date)
                {
                    int colRows = 0;
                    if (colRows == 0)
                        colRows = Convert.ToInt32(date.Query("SELECT count(*) FROM groups"));
                    attendanceLastDate = attendanceLastDate.AddDays(1);
                    for (int i = 1; i <= colRows; i++)
                    {
                        date.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + attendanceLastDate.Date.ToString("yyyy-MM-dd") + "', " + i + ", " + 0 + ")");
                    }
                }
                //while (menuLastDate.Date < attendanceLastDate.Date)
                //{
                //    menuLastDate = menuLastDate.AddDays(1);
                //    menu.Query("INSERT INTO Menu (Date) VALUES('" + menuLastDate.Date.ToString("yyyy-MM-dd") + "')");
                //}
                DataBase.Close();
            }
            else
                MessageBox.Show(
                    "Проверте подключение к базе данных",
                    "Ошибка Подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            DataView.ValueMember = "date";
            DataView.DataSource = date.newTable("SELECT date FROM attendance GROUP BY date");

            cmbDinnerType.ValueMember = "ID";
            cmbDinnerType.DisplayMember = "Type";
            cmbDinnerType.DataSource = dinnerType.newTable("SELECT * FROM dinnertype");

            InvokeDate(DataView.SelectedItem);
            InvokeDinnerType(cmbDinnerType.SelectedValue);
            InvokeDtMenu(DataView.SelectedValue, cmbDinnerType.SelectedValue);
            open = true;
        }

        //====== НАВИГАЦИЯ ======
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms[0].Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Dish DForm = new Dish(Location, this.WindowState, Role);
            DForm.Show();
        }

        private void linkChildren_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Children CForm = new Children(Location, this.WindowState, Role);
            CForm.Show();
        }


        //====== РАБОТА С ТИПАМИ ПИТАНИЯ ======
        private void InvokeDinnerType(object Value)
        {
            dtDish.DataSource = dish.newTable(
                "SELECT dishs.ID, dishs.DishName " +
                "FROM dishs " +
                "INNER JOIN dishs_for_dinnertype ON dishs.ID = dishs_for_dinnertype.DishID " +
                "WHERE DinnerTypeID = " + Value + "");
        }

        private void cmbDinnerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (open)
            {
                InvokeDinnerType(cmbDinnerType.SelectedValue);
                try
                {
                    dtMenu.DataSource = menu.newTable("SELECT dishs.ID, dishs.DishName " +
                        "FROM dishs " +
                        "INNER JOIN menu ON dishs.ID = menu.DishID " +
                        "INNER JOIN dishs_for_dinnertype ON dishs.ID = dishs_for_dinnertype.DishID " +
                        "WHERE dishs_for_dinnertype.DinnerTypeID = " + cmbDinnerType.SelectedValue + " " +
                        "AND menu.Date = '" + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "'");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString(), "Ошибка");
                }
            }
        }


        //====== РАБОТА ДАТАМИ ======
        private void InvokeDate(object Value)
        {
            DataRowView dateString = (DataRowView)Value;
            DateTime date = DateTime.Parse(dateString["date"].ToString());
            label1.Text = "Меню на " + date.ToString("D");
        }

        private void DataView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (open)
            {
                InvokeDate(DataView.SelectedItem);
                InvokeDtMenu(DataView.SelectedItem, cmbDinnerType.SelectedValue);
            }
        }


        //====== РАБОТА С МЕНЮ =======
        //Drag n Drop Из Списка болюд в меню
        DataRow dataRow;
        int rowIndex;

        private void InvokeDtMenu(object SelectedDate, object SelectedDT)
        {
            dtMenu.DataSource = menu.newTable("SELECT dishs.ID, dishs.DishName FROM dishs " +
            "INNER JOIN dishs_for_dinnertype ON dishs.ID = dishs_for_dinnertype.DishID " +
            "INNER JOIN dinnerType ON dishs_for_dinnertype.DinnerTypeID = dinnerType.ID " +
            "INNER JOIN menu ON menu.DishId = dishs.ID " +
            "WHERE menu.date= '" + Convert.ToDateTime(SelectedDate).ToString("yyyy-MM-dd") + "' " +
            "AND DinnerType.ID = " + SelectedDT + "");
        }

        private void dtDish_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndex = dtDish.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex != -1)
            {
                dataRow = dish.DBTable.Rows[dtDish.CurrentRow.Index];
            }
        }

        private void dtDish_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (rowIndex != -1)
                    dtDish.DoDragDrop(dataRow, DragDropEffects.Copy);
            }
        }

        private void dtMenu_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
                e.Effect = DragDropEffects.Copy;
        }

        private void dtMenu_DragDrop(object sender, DragEventArgs e)
        {
            DataTable dropped = dtMenu.DataSource as DataTable;
            DataRow row = dropped.NewRow();
            row = (DataRow)e.Data.GetData(typeof(DataRow));
            if (DataBase.Connect())
            {
                try
                {
                    menu.DBTable.Rows.Add(row["ID"].ToString(), row["DishName"].ToString());
                    menu.Query(
                        "INSERT INTO menu (date, DishID) " +
                        "VALUES ('" + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "', " + row["ID"].ToString() + ")");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString(), "Ошибка");
                }
                DataBase.Close();
            }
            else
                MessageBox.Show(
                    "Проверте подключение к базе данных",
                    "Ошибка Подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        //Drag n Drop Из меню 
        private void dtMenu_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndex = dtMenu.HitTest(e.X, e.Y).RowIndex;
            if (rowIndex != -1)
            {
                dataRow = menu.DBTable.Rows[dtMenu.CurrentRow.Index];
            }
        }

        private void dtMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (rowIndex != -1)
                    dtMenu.DoDragDrop(dataRow, DragDropEffects.Move);
            }
        }

        private void dtDish_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
                e.Effect = DragDropEffects.Move;
        }

        private void dtDish_DragDrop(object sender, DragEventArgs e)
        {
            if (DataBase.Connect())
            {
                DataRow row = (DataRow)e.Data.GetData(typeof(DataRow));
                try
                {
                    menu.Query(
                    "DELETE FROM menu " +
                    "WHERE date= '" + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "' " +
                    "AND DishID = " + row["ID"].ToString() + "");
                    menu.DBTable.Rows.Remove(row);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString(), "Ошибка");
                }
                DataBase.Close();
            }
        }
    }
}
