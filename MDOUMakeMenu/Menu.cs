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
                    for (int i = 1; i <= colRows; i++)
                    {
                        date.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + attendanceLastDate.Date.ToString("yyyy-MM-dd") + "', " + i + ", " + 0 + ")");
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
                InvokeDtMenu(DataView.SelectedItem, cmbDinnerType.SelectedValue);
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
                        "AND dishID = "+ row["ID"].ToString());
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
        private void cbChildrenControl_CheckedChanged(object sender, EventArgs e)
        {

        }

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
                workSheet.Cells[1, 3, 1, 5].Merge = true;
                workSheet.Cells[1, 3].Value = "Пищевая ценность (г)";
                workSheet.Cells[2, 3].Value = "Б";
                workSheet.Cells[2, 4].Value = "Ж";
                workSheet.Cells[2, 5].Value = "У";
                workSheet.Cells[1, 6, 2, 6].Merge = true;
                workSheet.Cells[1, 6].Value = "Энергетическая ценность (г)";
                using (var entireSheetRange = workSheet.Cells[1, 1, 2, 6])
                {
                    entireSheetRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    entireSheetRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                for (int d = DataView.SelectedIndex; d < 10; d++)
                {
                    cmbDinnerType.SelectedIndex = 0;
                    DataRowView dateString = (DataRowView)DataView.Items[d];
                    workSheet.Cells[workSheet.Dimension.End.Row + (d != 0 ? 2 : 1), 1].Value = Convert.ToDateTime(dateString["date"]).ToString("D");
                    for (int dinnerType = 0; dinnerType < cmbDinnerType.Items.Count; dinnerType++)
                    {
                        workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = DTcmb.Rows[dinnerType][1].ToString();
                        for (int row = 0; row < dtMenu.Rows.Count; row++)
                        {
                            workSheet.Cells[workSheet.Dimension.End.Row + (row != 0 ? 1 : 0), 2].Value = dtMenu.Rows[row].Cells[1].Value;
                        }
                        if (cmbDinnerType.SelectedIndex != cmbDinnerType.Items.Count - 1)
                            cmbDinnerType.SelectedIndex++;
                    }
                    workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].Value = "Итого за день";
                }
                //Форматирование Файла
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
    }
}
