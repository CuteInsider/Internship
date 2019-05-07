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
            DataView.DataSource = date.newTable("SELECT date FROM attendance GROUP BY date");
            DataView.ValueMember = "date";
            cmbDinnerType.DataSource = dinnerType.newTable("SELECT * FROM dinnertype");
            cmbDinnerType.ValueMember = "ID";
            cmbDinnerType.DisplayMember = "Type";
            InvokeDinnerType(cmbDinnerType.SelectedValue);
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
                "SELECT ID, DishName FROM dishs WHERE DinnerType = " + Value + "");
        }

        private void cmbDinnerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (open)
            {
                InvokeDinnerType(cmbDinnerType.SelectedValue);
                dtMenu.DataSource = menu.newTable("SELECT dishs.DishName FROM dishs " +
                    "INNER JOIN dinnertype ON dishs.DinnerType = dinnertype.ID " +
                    "INNER JOIN menu menu.DishId = dishs.ID " +
                    "WHERE menu.date= '" + DataView.SelectedValue + "' " +
                    "AND DinnerType.ID = " + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "'");
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
            }
        }


        //====== РАБОТА С МЕНЮ =======
        private void dtDish_MouseDown(object sender, MouseEventArgs e)
        {
            if (dtDish.CurrentRow.Index != -1 && dtDish.CurrentRow.Index != -1)
            {
                DataRow dataRow = dish.DBTable.Rows[dtDish.CurrentRow.Index];
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
            DataRow dropped = (DataRow)e.Data.GetData(typeof(DataRow));
            dtMenu.Rows.Add(dropped["ID"].ToString(), dropped["DishName"].ToString());
            if (DataBase.Connect())
            {
                menu.Query("INSERT INTO menu (date, DishID) VALUES ('" + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "', " + dropped["ID"].ToString() + ")");
                DataBase.Close();
            }
            else
                MessageBox.Show(
                    "Проверте подключение к базе данных",
                    "Ошибка Подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
