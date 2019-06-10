using OfficeOpenXml;
using OfficeOpenXml.Style;
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

        bool close = true;

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
                    if (!(attendanceLastDate.DayOfWeek == DayOfWeek.Saturday) || !(attendanceLastDate.DayOfWeek == DayOfWeek.Sunday))
                    {
                        for (int i = 1; i <= colRows; i++)
                        {
                            date.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + attendanceLastDate.Date.ToString("yyyy-MM-dd") + "', " + i + ", " + 0 + ")");
                        }
                    }
                }
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
            close = false;
            Close();
            Application.OpenForms[0].WindowState = this.WindowState;
            Application.OpenForms[0].Location = this.Location;
            Application.OpenForms[0].Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            close = false;
            Close();
            Dish DForm = new Dish(Location, this.WindowState, Role);
            DForm.Show();
        }

        private void linkChildren_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            close = false;
            Close();
            Children CForm = new Children(Location, this.WindowState, Role);
            CForm.Show();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
                Application.Exit();
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
                    InvokeDtMenu(DataView.SelectedValue, cmbDinnerType.SelectedValue);
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
                InvokeDtMenu(DataView.SelectedValue, cmbDinnerType.SelectedValue);
            }
        }


        //====== РАБОТА С МЕНЮ =======
        //Drag n Drop Из Списка болюд в меню
        DataRow dataRow;
        int rowIndex;

        private void InvokeDtMenu(object SelectedDate, object SelectedDT)
        {
            dtMenu.DataSource = menu.newTable("SELECT Dishs.ID, Dishs.DishName FROM Dishs " +
                "INNER JOIN menu ON Dishs.ID = menu.DishId " +
                "WHERE date = '" + Convert.ToDateTime(SelectedDate).ToString("yyyy-MM-dd") + "' " +
                "AND SelectedDiinerType = " + SelectedDT + "");
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
                    object result = dish.Query("SELECT ID " +
                        "FROM Menu " +
                        "WHERE Date = " + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + " " +
                        "AND SelectedDiinerType = " + cmbDinnerType.SelectedValue + " " +
                        "AND DishId = " + row["ID"].ToString() + "");
                    if (result == null)
                    {
                        menu.DBTable.Rows.Add(row["ID"].ToString(), row["DishName"].ToString());
                        menu.Query(
                            "INSERT INTO menu (date, SelectedDiinerType, DishID) " +
                            "VALUES ('" + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "', " + cmbDinnerType.SelectedValue + "," + row["ID"].ToString() + ")");
                    }
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
                    menu.Query("DELETE FROM menu " +
                        "WHERE Date = '" + Convert.ToDateTime(DataView.SelectedValue).ToString("yyyy-MM-dd") + "' " +
                        "AND SelectedDiinerType = " + cmbDinnerType.SelectedValue + " " +
                        "AND dishID = " + row["ID"].ToString());
                    menu.DBTable.Rows.Remove(row);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString(), "Ошибка");
                }
                DataBase.Close();
            }
        }

        //====== РАБОТА С НОРМАМИ ПИТАНИЯ ======
        private void btnMakeMenu_Click(object sender, EventArgs e)
        {
            //Создание файла
            using (ExcelPackage Excel = new ExcelPackage())
            {
                //Создание листа
                ExcelWorksheet workSheet = Excel.Workbook.Worksheets.Add("Отчет");

                DataTable DTcmb = cmbDinnerType.DataSource as DataTable;
                workSheet.Cells[1, 1, 2, 1].Merge = true;
                workSheet.Cells[1, 1].Value = "Прием пищи";
                workSheet.Cells[1, 2, 2, 2].Merge = true;
                workSheet.Cells[1, 2].Value = "Наименование блюда";
                workSheet.Cells[1, 2].Style.WrapText = true;
                workSheet.Cells[1, 3, 1, 5].Merge = true;
                workSheet.Cells[1, 3].Value = "Пищевая ценность (г)";
                workSheet.Cells[2, 3].Value = "Б";
                workSheet.Cells[2, 4].Value = "Ж";
                workSheet.Cells[2, 5].Value = "У";
                workSheet.Cells[1, 6, 2, 6].Merge = true;
                workSheet.Cells[1, 6].Value = "Энергетическая ценность (г)";
                workSheet.Cells[1, 6].Style.WrapText = true;
                using (var entireSheetRange = workSheet.Cells[1, 1, 2, 6])
                {
                    entireSheetRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    entireSheetRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                int[] Adreses = new int[10];
                int i = 0;
                int selectedIndex = DataView.SelectedIndex;
                for (int d = DataView.SelectedIndex; d < selectedIndex + 10; d++)
                {
                    if ((selectedIndex + 10) > DataView.Items.Count)
                    {
                        MessageBox.Show("Меню должно быть создано не менее чем на 10 дней",
                            "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    cmbDinnerType.SelectedIndex = 0;
                    DataRowView dateString = (DataRowView)DataView.Items[d];
                    int startAdress = 1;
                    int endAdress = 1;
                    workSheet.Cells[workSheet.Dimension.End.Row + (d != 0 ? 2 : 1), 1].Value = Convert.ToDateTime(dateString["date"]).ToString("D");
                    startAdress = workSheet.Dimension.End.Row + 1;
                    for (int dinnerType = 0; dinnerType < cmbDinnerType.Items.Count; dinnerType++)
                    {
                        workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = DTcmb.Rows[dinnerType][1].ToString();
                        for (int row = 0; row < dtMenu.Rows.Count; row++)
                        {
                            workSheet.Cells[workSheet.Dimension.End.Row + (row != 0 ? 1 : 0), 2].Value = dtMenu.Rows[row].Cells[1].Value;
                            if (DataBase.Connect())
                            {
                                workSheet.Cells[workSheet.Dimension.End.Row/* + (row != 0 ? 1 : 0)*/, 3].Value = dish.Query("SELECT SUM(`Protein,g`) FROM ingredients_composition " +
                                                                                                                        "INNER JOIN ingredients ON ingredients_composition.ingredientID = ingredients.ID " +
                                                                                                                        "INNER JOIN composition ON ingredients.ID = composition.IngredientID " +
                                                                                                                        "WHERE composition.DishID = " + dtMenu.Rows[row].Cells[0].Value + "");
                                workSheet.Cells[workSheet.Dimension.End.Row/* + (row != 0 ? 1 : 0)*/, 4].Value = dish.Query("SELECT SUM(`Fat,g`) FROM ingredients_composition " +
                                                                                                                        "INNER JOIN ingredients ON ingredients_composition.ingredientID = ingredients.ID " +
                                                                                                                        "INNER JOIN composition ON ingredients.ID = composition.IngredientID " +
                                                                                                                        "WHERE composition.DishID = " + dtMenu.Rows[row].Cells[0].Value + "");

                                workSheet.Cells[workSheet.Dimension.End.Row/* + (row != 0 ? 1 : 0)*/, 5].Value = dish.Query("SELECT SUM(`Carbohydrates, g`) FROM ingredients_composition " +
                                                                                                                        "INNER JOIN ingredients ON ingredients_composition.ingredientID = ingredients.ID " +
                                                                                                                        "INNER JOIN composition ON ingredients.ID = composition.IngredientID " +
                                                                                                                        "WHERE composition.DishID = " + dtMenu.Rows[row].Cells[0].Value + "");

                                workSheet.Cells[workSheet.Dimension.End.Row/* + (row != 0 ? 1 : 0)*/, 6].Value = dish.Query("SELECT SUM(`Energy(kkal)`) FROM ingredients_composition " +
                                                                                                                        "INNER JOIN ingredients ON ingredients_composition.ingredientID = ingredients.ID " +
                                                                                                                        "INNER JOIN composition ON ingredients.ID = composition.IngredientID " +
                                                                                                                        "WHERE composition.DishID = " + dtMenu.Rows[row].Cells[0].Value + "");
                                DataBase.Close();
                            }
                            else
                            {
                                MessageBox.Show(
                                        "Проверте подключение к базе данных",
                                        "Ошибка Подключения",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                return;
                            }
                        }
                        endAdress = workSheet.Dimension.End.Row;
                        if (cmbDinnerType.SelectedIndex != cmbDinnerType.Items.Count - 1)
                            cmbDinnerType.SelectedIndex++;
                    }
                    workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = "Итого за день";
                    workSheet.Cells[workSheet.Dimension.End.Row, 3].Formula = "SUM(C" + startAdress + ":C" + endAdress + ")";
                    workSheet.Cells[workSheet.Dimension.End.Row, 4].Formula = "SUM(D" + startAdress + ":D" + endAdress + ")";
                    workSheet.Cells[workSheet.Dimension.End.Row, 5].Formula = "SUM(E" + startAdress + ":E" + endAdress + ")";
                    workSheet.Cells[workSheet.Dimension.End.Row, 6].Formula = "SUM(F" + startAdress + ":F" + endAdress + ")";
                    Adreses[i] = workSheet.Dimension.End.Row;
                    i++;
                    startAdress = 1;
                    if (DataView.SelectedIndex != DataView.Items.Count - 1)
                        DataView.SelectedIndex++;
                }
                workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = "Итог за весь день";
                workSheet.Cells[workSheet.Dimension.End.Row, 3].Formula = "SUM(C" + Adreses[0] + ",C" + Adreses[1] + ",C" + Adreses[2] + ",C" + Adreses[3] + ",C" + Adreses[4] + ",C" + Adreses[5] + ",C" + Adreses[6] + ",C" + Adreses[7] + ",C" + Adreses[8] + ",C" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 4].Formula = "SUM(D" + Adreses[0] + ",D" + Adreses[1] + ",D" + Adreses[2] + ",D" + Adreses[3] + ",D" + Adreses[4] + ",D" + Adreses[5] + ",D" + Adreses[6] + ",D" + Adreses[7] + ",D" + Adreses[8] + ",D" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 5].Formula = "SUM(E" + Adreses[0] + ",E" + Adreses[1] + ",E" + Adreses[2] + ",E" + Adreses[3] + ",E" + Adreses[4] + ",E" + Adreses[5] + ",E" + Adreses[6] + ",E" + Adreses[7] + ",E" + Adreses[8] + ",E" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 6].Formula = "SUM(F" + Adreses[0] + ",F" + Adreses[1] + ",F" + Adreses[2] + ",F" + Adreses[3] + ",F" + Adreses[4] + ",F" + Adreses[5] + ",F" + Adreses[6] + ",F" + Adreses[7] + ",F" + Adreses[8] + ",F" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = "Среднее значение за день";
                workSheet.Cells[workSheet.Dimension.End.Row, 1].Style.WrapText = true;
                workSheet.Cells[workSheet.Dimension.End.Row, 3].Formula = "AVERAGE(C" + Adreses[0] + ",C" + Adreses[1] + ",C" + Adreses[2] + ",C" + Adreses[3] + ",C" + Adreses[4] + ",C" + Adreses[5] + ",C" + Adreses[6] + ",C" + Adreses[7] + ",C" + Adreses[8] + ",C" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 4].Formula = "AVERAGE(D" + Adreses[0] + ",D" + Adreses[1] + ",D" + Adreses[2] + ",D" + Adreses[3] + ",D" + Adreses[4] + ",D" + Adreses[5] + ",D" + Adreses[6] + ",D" + Adreses[7] + ",D" + Adreses[8] + ",D" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 5].Formula = "AVERAGE(E" + Adreses[0] + ",E" + Adreses[1] + ",E" + Adreses[2] + ",E" + Adreses[3] + ",E" + Adreses[4] + ",E" + Adreses[5] + ",E" + Adreses[6] + ",E" + Adreses[7] + ",E" + Adreses[8] + ",E" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 6].Formula = "AVERAGE(F" + Adreses[0] + ",F" + Adreses[1] + ",F" + Adreses[2] + ",F" + Adreses[3] + ",F" + Adreses[4] + ",F" + Adreses[5] + ",F" + Adreses[6] + ",F" + Adreses[7] + ",F" + Adreses[8] + ",F" + Adreses[9] + ")";
                workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = "Содержание белков, жиров, углеводов в % от калорийности";
                workSheet.Cells[workSheet.Dimension.End.Row, 2].Style.Numberformat.Format = "#%";
                workSheet.Cells[workSheet.Dimension.End.Row, 2].Formula = "=((C" + (workSheet.Dimension.End.Row - 2) + "+D" + (workSheet.Dimension.End.Row - 2) + "+E" + (workSheet.Dimension.End.Row - 2) + ")/F" + (workSheet.Dimension.End.Row - 2) + ")";
                workSheet.Cells[workSheet.Dimension.End.Row, 1].Style.WrapText = true;
                //Форматирование Файла
                workSheet.Workbook.CalcMode = ExcelCalcMode.Automatic;
                workSheet.Cells.AutoFitColumns();
                workSheet.Cells.Style.Font.Name = "Times New Roman";
                workSheet.Cells.Style.Font.Size = 12;
                using (var entireSheetRange = workSheet.Cells[1, 1, workSheet.Dimension.End.Row, 6])
                {
                    entireSheetRange.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    entireSheetRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    entireSheetRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    entireSheetRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    entireSheetRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                //Сохранение Excel
                System.IO.FileInfo fi = new System.IO.FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Меню.xlsx");
                Excel.SaveAs(fi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataBase.Connect())
            {
                DateTime LastDate = Convert.ToDateTime(dish.Query("SELECT date FROM attendance GROUP BY date ORDER BY date DESC"));
                DateTime result = Convert.ToDateTime(dish.Query("SELECT date FROM attendance GROUP BY date"));
                for (; result < LastDate;)
                {
                    if (result.DayOfWeek == DayOfWeek.Saturday || result.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dish.Query("DELETE FROM attendance WHERE date = '" + result.ToString("yyyy-MM-dd") + "'");
                    }
                    result = result.AddDays(1);
                }
                DataBase.Close();
            }
        }
    }
}
