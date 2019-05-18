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

        bool newRowDT = false;
        bool newRowD = false;
        bool newRowI = false;
        bool newRowIC = false;

        bool open = false;

        Table dish = new Table();
        Table composition = new Table();
        Table ingredients = new Table();
        Table CompositionIngredients = new Table();
        Table dinnerType = new Table();

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
                InvokeDtDinnerType();
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            splitContainer2.Panel2Collapsed = true;
            open = true;
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


        //====== РАБОТА С ТИПАМИ ПРИЕМА ПИЩИ ======
        private void InvokeDtDinnerType()
        {
            dtDinnerType.DataSource = dinnerType.newTable("SELECT * FROM dinnertype");
        }

        private void btnDinnerType_Click(object sender, EventArgs e)
        {
            if (!dtDinnerType.AllowUserToAddRows)
            {
                dtDinnerType.AllowUserToAddRows = true;
                dtDinnerType.ReadOnly = false;
                btnDinnerType.Text = "Отмена";
                dtDinnerType.Rows[dtDinnerType.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;
            }
            else
            {
                dtDinnerType.AllowUserToAddRows = false;
                dtDinnerType.ReadOnly = true;
                btnDinnerType.Text = "Добавить";
            }
        }

        private void dtDinnerType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (open == true)
            {
                if (!((DataGridView)sender).CurrentRow.IsNewRow)
                {
                    newRowDT = false;
                    InvokeDtDish(dtDinnerType.CurrentRow.Cells[0].Value);
                    dtDish.AllowUserToAddRows = true;
                    dtDish.Enabled = true;
                }
                else
                {
                    newRowDT = true;
                }
            }
        }

        private void dtDinnerType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtDinnerType_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowD == true && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()))
                return;
            if (DataBase.Connect())
            {
                if (!String.IsNullOrEmpty(dtDinnerType.CurrentRow.Cells[1].Value.ToString()))
                {
                    if (newRowDT == true)
                        dinnerType.Query("INSERT INTO dinnertype (Type) VALUES ('" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "')");
                    else
                        dinnerType.Query("UPDATE dinnertype SET Type = '" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "' WHERE ID = " + dtIngredient.CurrentRow.Cells[0].Value);
                }
                else
                    dinnerType.Query("DELETE FROM dinnertype WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    InvokeDtDinnerType();
                    dtDinnerType.Rows[rowIndex].Selected = true;
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


        //====== РАБОТА С БЛЮДАМИ ======
        private void InvokeDtDish(object Value)
        {
            if (dtDinnerType.Rows.Count > 0)
            {
                dtDish.DataSource = dish.newTable(
                        "SELECT dishs.ID, dishs.DishName " +
                        "FROM dishs " +
                        "INNER JOIN dishs_for_dinnertype ON dishs.ID = dishs_for_dinnertype.DishID " +
                        "WHERE dishs_for_dinnertype.DinnerTypeID = '" + Value + "'");
            }
        }

        private void dtDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowD = false;
                InvokeDtIngredient(dtDish.CurrentRow.Cells[0].Value);
                dtIngredient.AllowUserToAddRows = true;
                dtIngredient.Enabled = true;
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
                    {
                        dish.Query("INSERT INTO dishs (DishName) VALUES ('" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "')");
                        object addedDish = dish.Query("SELECT Id FROM dishs ORDER BY id DESC");
                        dish.Query("INSERT INTO dishs_for_dinnertype (DishID, DinnerTypeID) VALUES (" + addedDish + ", " + dtDinnerType.CurrentRow.Cells[0].Value + ")");
                    }
                    else
                        dish.Query("UPDATE dishs SET DishName = '" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "' WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                else
                    dish.Query("DELETE FROM dishs WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    InvokeDtDish(dtDinnerType.CurrentRow.Cells[0].Value);
                    dtDish.Rows[rowIndex].Selected = true;
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


        //====== РАБОТА С ИНГРИДИЕНТАМИ ======
        private void InvokeDtIngredient(object Value)
        {
            if (dtDish.Rows.Count != 0)
            {
                dtIngredient.DataSource = composition.newTable("SELECT composition.ID, ingredients.Ingredient FROM composition " +
                "INNER JOIN ingredients ON ingredients.Id = composition.IngredientID " +
                "WHERE DishID = " + Value);
            }
        }

        private void dtIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowI = false;
                btnComposition.Enabled = true;
                if (splitContainer2.Panel2Collapsed == false)
                    InvoketDtIngredientsComposition(dtIngredient.CurrentRow.Cells[0].Value);
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
                return;
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
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    InvokeDtIngredient(dtDish.CurrentRow.Cells[0].Value);
                    dtIngredient.Rows[rowIndex].Selected = true;
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


        //====== РАБОТА С СОСТАВОМ ИНГРИДИЕНТОВ ======
        private void InvoketDtIngredientsComposition(object IngredientID)
        {
            dtIngredientsComposition.DataSource = ingredients.newTable(
                "SELECT * FROM ingredients_composition WHERE ingredientID = " + IngredientID);
            if (dtIngredientsComposition.Rows.Count >= 1)
                dtIngredientsComposition.AllowUserToAddRows = false;
            else
                dtIngredientsComposition.AllowUserToAddRows = true;
        }

        private void btnComposition_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
                if (dtIngredient.CurrentRow.Selected == true)
                {
                    InvoketDtIngredientsComposition(dtIngredient.CurrentRow.Cells[0].Value);
                }
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
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowIC = false;
            }
            else
                newRowIC = true;

            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtIngredientsComposition_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowIC == true && String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                return;
            if (DataBase.Connect())
            {
                if (newRowIC == true)
                    CompositionIngredients.Query("INSERT INTO ingredients_composition (ingredientID, `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "`) VALUES (" +
                        dtIngredient.CurrentRow.Cells[0].Value + ", " + ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + ");");
                else if (!String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                {
                    CompositionIngredients.Query("UPDATE ingredients_composition SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = '" +
                        ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + "' WHERE ingredientID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                else
                {
                    CompositionIngredients.Query("UPDATE ingredients_composition SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = NULL WHERE ingredientID = " +
                        ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                if (String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()) && String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[2].Value.ToString()) &&
                    String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[3].Value.ToString()) && String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[4].Value.ToString()) &&
                    String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[5].Value.ToString()) && String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[6].Value.ToString()) && newRowIC == false)
                    CompositionIngredients.Query("DELETE FROM ingredients_composition WHERE ingredientID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    dtIngredientsComposition.DataSource =
                    ingredients.newTable("SELECT * FROM ingredients_composition WHERE ingredientID = "
                    + dtIngredient.CurrentRow.Cells[0].Value);
                    dtIngredientsComposition.Rows[rowIndex].Selected = true;
                }));
                DataBase.Close();
            }
            else
                MessageBox.Show("Проверте подключение к базе данных", "Ошибка Подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        int data;
        DataGridView.HitTestInfo hit;
        private void dtDish_MouseDown(object sender, MouseEventArgs e)
        {
            hit = dtDish.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell && dtDinnerType.DataSource != null
                && hit.RowIndex != dtDish.NewRowIndex)
            {
                data = Convert.ToInt16(dish.DBTable.Rows[hit.RowIndex][0]);
            }
        }

        private void dtDish_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                dtDish.DoDragDrop(data, DragDropEffects.Copy);
            }
        }

        private void dtDinnerType_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(int)))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dtDinnerType_DragDrop(object sender, DragEventArgs e)
        {
            if (DataBase.Connect())
            {
                Point clientPoint = dtDinnerType.PointToClient(new Point(e.X, e.Y));
                DataGridView.HitTestInfo hit = dtDinnerType.HitTest(clientPoint.X, clientPoint.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    object result = dish.Query(
                        "SELECT ID " +
                        "FROM dishs_for_dinnertype " +
                        "WHERE DishID = '" + (int)e.Data.GetData(typeof(int)) + "' " +
                        "AND DinnerTypeID = '" + hit.RowIndex + "'");
                    if (result == null)
                        dish.Query(
                            "INSERT INTO dishs_for_dinnertype (DishID, DinnerTypeID) " +
                            "VALUES (" + (int)e.Data.GetData(typeof(int)) + ", " + hit.RowIndex + ")");
                }
                DataBase.Close();
            }
        }


        //====== КОНТЕКСТНОЕ МЕНЮ ======
        private void dtDish_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            if (DataBase.Connect())
            {
                if (e.RowIndex != -1)
                {
                    int result = Convert.ToInt32(dish.Query("SELECT Count(ID) FROM dishs_for_dinnertype WHERE dishID = " + dtDish.CurrentRow.Cells[0].Value));
                    if (result == 1)
                    {
                        ToolStripMenuItem.Visible = true;
                        toolStripMenuItem1.Visible = false;
                    }
                    else
                    {
                        toolStripMenuItem1.Visible = true;
                        if (result == dtDinnerType.Rows.Count)
                            ToolStripMenuItem.Visible = false;
                        else
                            ToolStripMenuItem.Visible = true;
                    }
                    contextMenuStrip1.Show(Cursor.Position);
                }
                DataBase.Close();
            }
        }

        private void ToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndexChanged -= toolStripComboBox1_SelectedIndexChanged;
            toolStripComboBox1.ComboBox.BindingContext = BindingContext;
            toolStripComboBox1.ComboBox.ValueMember = "ID";
            toolStripComboBox1.ComboBox.DisplayMember = "Type";
            toolStripComboBox1.ComboBox.DataSource = dish.newTable(
                "SELECT dinnerType.ID, dinnerType.Type " +
                "FROM dinnerType " +
                "INNER JOIN dishs_for_dinnertype ON DinnerType.ID = dishs_for_dinnertype.DinnerTypeID " +
                "WHERE dinnerType.ID != " + dtDinnerType.CurrentRow.Cells[0].Value + " " +
                "GROUP BY dinnerType.ID");
            toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DataBase.Connect())
            {
                dish.Query(
                    "DELETE FROM dishs_for_dinnertype " +
                    "WHERE DishID = " + dtDish.CurrentRow.Cells[0].Value +
                    " AND DinnerTypeID = " + dtDinnerType.CurrentRow.Cells[0].Value);
                DataBase.Close();
            }
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (DataBase.Connect())
            {
                dish.Query("DELETE FROM dishs WHERE ID = " + dtDish.CurrentRow.Cells[0].Value);
                DataBase.Close();
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataBase.Connect())
            {
                object result = dish.Query(
                    "SELECT ID " +
                    "FROM dishs_for_dinnertype " +
                    "WHERE DinnerTypeID = " + toolStripComboBox1.ComboBox.SelectedValue + " " +
                    "AND DishID = " + dtDish.CurrentRow.Cells[0].Value);
                if (result == null)
                {
                    dish.Query(
                        "INSERT INTO dishs_for_dinnertype (DishID, DinnerTypeID) " +
                        "VALUES (" + dtDish.CurrentRow.Cells[0].Value + ", " + toolStripComboBox1.ComboBox.SelectedValue + ")");
                }
                DataBase.Close();
            }
            toolStripComboBox1.SelectedIndexChanged -= toolStripComboBox1_SelectedIndexChanged;
            contextMenuStrip1.Close();
        }
    }
}
