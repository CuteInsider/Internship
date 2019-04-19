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
        bool newRowIC = false;

        Table dish = new Table();
        Table composition = new Table();
        Table ingredients = new Table();
        Table CompositionIngredients = new Table();

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

        //====== НАВИГАЦИЯ ======
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

        //====== РАБОТА С БОЮДАМИ ======

        private void dtDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                dtIngredient.DataSource = composition.newTable("SELECT composition.ID, ingredients.Ingredient FROM composition " +
                    "INNER JOIN ingredients ON ingredients.Id = composition.IngredientID " +
                    "WHERE DishID = " + dtDish.CurrentRow.Cells[0].Value);
                newRowD = false;
            }
            else
                newRowD = true;
        }

        private void dtDish_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtDish_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DataBase.Connect())
            {
                if (newRowD == true && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()))
                {
                    return;
                }
                if (!string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()))
                    if (newRowD == true)
                        dish.Query("INSERT INTO dishs (DinnerType, DishName) VALUES ('" + dataView.SelectedValue + "', '" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "')");
                    else
                        dish.Query("UPDATE dishs SET DishName = '" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "' WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                else
                    dish.Query("DELETE FROM dishs WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    ((DataGridView)sender).DataSource = dish.newTable("SELECT dishs.ID, dishs.DishName " +
                        "FROM dishs " +
                        "WHERE DinnerType = '" + dataView.SelectedValue + "'");
                }));
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //====== РАБОТА С ИНГРИДИЕНТАМИ ======

        private void dtIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowI = false;
                btnComposition.Enabled = true;
                if (splitContainer2.Panel2Collapsed == false)
                    dtIngredientsComposition.DataSource = ingredients.newTable("SELECT * FROM ingredients_composition WHERE ingredientID = " + dtIngredient.CurrentRow.Cells[0].Value);
            }
            else
            {
                newRowI = true;
                btnComposition.Enabled = false;
            }
        }

        private void dtIngredient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtIngredient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowD == true && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()))
            {
                return;
            }
            Table DishIngredients = new Table();
            if (DataBase.Connect())
            {
                if (!String.IsNullOrEmpty(dtIngredient.CurrentRow.Cells[1].Value.ToString()))
                {
                    if (newRowI == true)
                    {
                        DishIngredients.Query("INSERT INTO ingredients (Ingredient) VALUES ('" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "')");
                        object DishId = DishIngredients.Query("SELECT ID FROM ingredients ORDER BY ID DESC");
                        composition.Query("INSERT INTO composition (DishID, IngredientID) VALUES (" + dtDish.CurrentRow.Cells[0].Value + "," + DishId + ")");
                    }
                    else
                        DishIngredients.Query("UPDATE ingredients SET Ingredient = '" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "' WHERE ID = " + dtIngredient.CurrentRow.Cells[0].Value);
                }
                else
                    DishIngredients.Query("DELETE FROM ingredients WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    dtIngredient.DataSource = composition.newTable("SELECT composition.ID, ingredients.Ingredient FROM composition " +
                    "INNER JOIN ingredients ON ingredients.Id = composition.IngredientID " +
                    "WHERE DishID = " + dtDish.CurrentRow.Cells[0].Value);
                }));
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //====== РАБОТА С СОСТАВОМ ИНГРИДИЕНТОВ ======

        private void btnComposition_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
            }
            else
            {
                splitContainer2.Panel2Collapsed = true;
            }
        }


        private void dtIngredientsComposition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowIC = false;
            }
            else
                newRowIC = true;
        }

        private void dtIngredientsComposition_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtIngredientsComposition_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowD == true && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
            {
                return;
            }
            if (DataBase.Connect())
            {
                if (!String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                {
                    if (newRowIC == true)
                        CompositionIngredients.Query("INSERT INTO ingredients_composition (ingredientID, `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "`) VALUES (" + dtIngredient.CurrentRow.Cells[0].Value + ", " + ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + ");");
                    else
                        CompositionIngredients.Query("UPDATE ingredients_composition SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = " + ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + " WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                else if (((DataGridView)sender).CurrentRow.Cells[2].Value == null && ((DataGridView)sender).CurrentRow.Cells[3].Value == null &&
                    ((DataGridView)sender).CurrentRow.Cells[4].Value == null && ((DataGridView)sender).CurrentRow.Cells[5].Value == null &&
                    ((DataGridView)sender).CurrentRow.Cells[6].Value == null && ((DataGridView)sender).CurrentRow.Cells[7].Value == null)
                    CompositionIngredients.Query("DELETE FROM ingredients_composition WHERE ID = " + dtIngredient.CurrentRow.Cells[0].Value);
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    dtIngredient.DataSource = composition.newTable("SELECT composition.ID, ingredients.Ingredient FROM composition " +
                    "INNER JOIN ingredients ON ingredients.Id = composition.IngredientID " +
                    "WHERE DishID = " + dtDish.CurrentRow.Cells[0].Value);
                }));
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
