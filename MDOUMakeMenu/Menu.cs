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
        }

    }
}
