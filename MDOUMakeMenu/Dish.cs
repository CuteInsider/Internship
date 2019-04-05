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
    public partial class Dish : Form
    {
        object Role;
        bool newRowD = false;
        bool newRowI = false;
        Table dish = new Table();
        Table composition = new Table();
        Table ingredients = new Table();

        public Dish(Point Location, FormWindowState state, object Role)
        {
            InitializeComponent();
            this.Location = Location;
            this.WindowState = state;
            this.Role = Role;
            switch (Role)
            {
                case "A":
                    linkMenu.Enabled = true;
                    linkIngredients.Enabled = false;
                    linkChildren.Enabled = true;
                    break;

                case "T":
                    linkMenu.Enabled = false;
                    linkIngredients.Enabled = false;
                    linkChildren.Enabled = true;
                    break;

                case "M":
                    linkMenu.Enabled = true;
                    linkIngredients.Enabled = false;
                    linkChildren.Enabled = false;
                    break;
            }
            if (DataBase.Connect())
            {
                Table dinnerType = new Table();
                dataView.DataSource = dinnerType.newTable("SELECT * FROM dinnertype ORDER BY ID");
                DataBase.Close();
                dataView.ValueMember = "ID";
                dataView.DisplayMember = "Type";
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            splitContainer2.Panel2Collapsed = true;
        }


        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Menu MForm = new Menu(Location, this.WindowState, Role);
            MForm.Show();
        }

        private void linkChildren_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Children CForm = new Children(Location, this.WindowState, Role);
            CForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms[0].Show();
        }

        private void dataView_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtDish.DataSource = dish.newTable("SELECT dishs.ID, dishs.DishName " +
                "FROM dishs " +
                "WHERE DinnerType = '" + dataView.SelectedValue + "'");
        }

        private void dtDish_Click(object sender, EventArgs e)
        {
            if (!dtDish.CurrentRow.IsNewRow)
            {
                dtIngredient.DataSource = composition.newTable("SELECT composition.ID, ingredients.Ingredient FROM composition " +
                    "INNER JOIN ingredients ON ingredients.Id = composition.IngredientID " +
                    "WHERE DishID = " + dtDish.CurrentRow.Cells[0].Value);
                newRowD = false;
            }
            else
                newRowD = true;
        }

        private void dtDish_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DataBase.Connect())
            {
                if (dtDish.CurrentCell.IsInEditMode)
                {
                    if (!String.IsNullOrEmpty(dtDish.CurrentRow.Cells[1].Value.ToString()))
                        if (newRowD == true)
                            dish.Query("INSERT INTO dishs (DinnerType, DishName) VALUES ('" + dataView.SelectedValue + "', '" + dtDish.CurrentRow.Cells[1].Value + "')");
                        else
                            dish.Query("UPDATE dishs SET DishName = '" + dtDish.CurrentRow.Cells[1].Value + "' WHERE ID = " + dtDish.CurrentRow.Cells[0].Value);
                    else
                        dish.Query("DELETE FROM dishs WHERE ID = " + dtDish.CurrentRow.Cells[0].Value);
                    dtDish.DataSource = dish.newTable("SELECT dishs.ID, dishs.DishName " +
                        "FROM dishs " +
                        "WHERE DinnerType = '" + dataView.SelectedValue + "'");
                    DataBase.Close();
                }
                else

            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dtIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dtIngredient.CurrentRow.IsNewRow)
            {
                newRowI = false;
                if (splitContainer2.Panel2Collapsed == false)
                    dataGridView1.DataSource = ingredients.newTable("SELECT * FROM ingredients_composition WHERE ingredientID = "+dtIngredient.CurrentRow.Cells[0].Value);
            }
            else
                newRowI = true;
        }

        private void dtIngredient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Table DishIngredients = new Table();
            if (DataBase.Connect())
            {
                if (!String.IsNullOrEmpty(dtIngredient.CurrentRow.Cells[1].Value.ToString()))
                {
                    if (newRowI == true)
                    {
                        DishIngredients.Query("INSERT INTO ingredients (Ingredient) VALUES ('" + dtIngredient.CurrentRow.Cells[1].Value + "')");
                        object DishId = DishIngredients.Query("SELECT ID FROM ingredients ORDER BY ID DESC");
                        composition.Query("INSERT INTO composition (DishID, IngredientID) VALUES (" + dtDish.CurrentRow.Cells[0].Value + "," + DishId + ")");
                    }
                    else
                        DishIngredients.Query("UPDATE ingredients SET Ingredient = '" + dtIngredient.CurrentRow.Cells[1].Value + "' WHERE ID = " + dtIngredient.CurrentRow.Cells[0].Value);
                }
                else
                    DishIngredients.Query("DELETE FROM ingredients WHERE ID = " + dtIngredient.CurrentRow.Cells[0].Value);
                dtIngredient.DataSource = composition.newTable("SELECT composition.ID, ingredients.Ingredient FROM composition " +
                    "INNER JOIN ingredients ON ingredients.Id = composition.IngredientID " +
                    "WHERE DishID = " + dtDish.CurrentRow.Cells[0].Value);
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnComposition_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
                splitContainer2.Panel2Collapsed = false;
            else
                splitContainer2.Panel2Collapsed = true;
        }
    }
}
