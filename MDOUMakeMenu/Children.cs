using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace MDOUMakeMenu
{
    public partial class Children : Form
    {
        Table tAttendance = new Table();
        Table tChildren = new Table();
        Table tAgeGroup = new Table();

        object Role;
        bool newRowC = false;
        bool newRowG = false;
        bool newRowAG = false;

        bool open = false;
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
                object result = date.Query("SELECT DISTINCT date FROM attendance ORDER BY date DESC");
                DateTime LastDate = Convert.ToDateTime(result);
                DateTime NowDate = DateTime.Now.Date;

                while (LastDate.Date < NowDate.Date)
                {
                    int colRows = 0;
                    if (colRows == 0)
                        colRows = Convert.ToInt32(date.Query("SELECT count(*) FROM groups"));
                    LastDate = LastDate.AddDays(1);
                    for (int i = 1; i <= colRows; i++)
                        date.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + LastDate.Date.ToString("yyyy-MM-dd") + "', " + i + ", " + 0 + ")");
                }
                dataView.DataSource = date.newTable("SELECT date FROM attendance GROUP BY Date");
                dataView.ValueMember = "date";
                dataView.DisplayMember = "Date";
                DataBase.Close();
            }
            else
                MessageBox.Show(
                    "Проверте подключение к базе данных",
                    "Ошибка Подключения",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            splitContainer2.Panel2Collapsed = true;
            splitContainer3.Panel1Collapsed = true;
            splitContainer3.Panel1.Hide();
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
            open = true;
        }


        //====== НАВИГАЦИЯ ======
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
        

        //====== РАБОТА СО СПИСКОМ ДАТ ======
        private void dateView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (open == true)
            {
                InvokeDtAttendance(dataView.SelectedValue);
            }
        }

        private void InvokeDtAttendance(object Value)
        {
            DateTime date = (DateTime)Value;
            dtAttendance.DataSource = tAttendance.newTable(
                "SELECT attendance.Id, groups.ID, groups.GroupName, totalchildren.TotalChildren, attendance.ActuallyChildrenAmount " +
                "FROM attendance " +
                "INNER JOIN totalchildren ON attendance.GroupId = totalchildren.GroupID " +
                "INNER JOIN groups ON totalchildren.GroupID = groups.ID " +
                "WHERE Date = '" + date.ToString("yyyy-MM-dd") + "'");
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
                cmbAgeGroup.DataSource = tChildren.newTable("SELECT * FROM agegroup");
                cmbAgeGroup.ValueMember = "ID";
                cmbAgeGroup.DisplayMember = "agegroup";

                dtChildren.DataSource = tChildren.newTable(
                    "SELECT childrens.ID, childrens.IDAgeGroup, childrens.SecondName, childrens.FistName, childrens.FatherName " +
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
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    InvokeDtAttendance(dataView.SelectedValue);
                    dtAttendance.Rows[rowIndex].Selected = true;
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
            if (newRowG && string.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[2].Value.ToString()))
                return;
            if (!string.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[2].Value.ToString()))
            {
                if (newRowG == true)
                {
                    tAttendance.Query("INSERT INTO groups (GroupName) VALUES('" + dtAttendance.CurrentRow.Cells[2].Value + "')");
                    int lastGroup = Convert.ToUInt16(tAttendance.Query("SELECT ID FROM groups ORDER BY ID DESC"));
                    tAttendance.Query("INSERT INTO totalchildren (GroupID, TotalChildren) VALUES(" + lastGroup + ", 0)");

                    DialogResult = MessageBox.Show(
                        "Добавить группу ко всем датам",
                        "Сообщение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk);

                    DateTime NowDate = (DateTime)dataView.SelectedValue;
                    object result = tAttendance.Query("SELECT DISTINCT date FROM attendance ORDER BY date ASC");
                    DateTime FirstDate = Convert.ToDateTime(result);

                    if (DialogResult == DialogResult.Yes)
                    {
                        while (FirstDate.Date <= NowDate.Date)
                        {
                            tAttendance.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + FirstDate.Date.ToString("yyyy-MM-dd") + "', '" + lastGroup + "', " + 0 + ")");
                            FirstDate = FirstDate.AddDays(1);
                        }
                    }
                    else
                        tAttendance.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + NowDate.Date.ToString("yyyy-MM-dd") + "', '" + lastGroup + "', " + 0 + ")");
                }
                else
                    tAttendance.Query("UPDATE groups SET GroupName = '" + dtAttendance.CurrentRow.Cells[2].Value + "' WHERE ID = " + dtAttendance.CurrentRow.Cells[1].Value + "");
            }
            else
            {
                DialogResult = MessageBox.Show(
                    "Вы действительно хотете удалить запсиь, удаление записи приведет к удалению всех данных связанных с ней",
                    "Внимание",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                    tAttendance.Query("DELETE FROM groups WHERE ID = " + dtAttendance.CurrentRow.Cells[1].Value + "");
            }
        }

        private void EndEditAllAmount()
        {
            if (newRowG == true)
                return;
            if (!String.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[3].Value.ToString()))
            {
                if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) >= Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value))
                {
                    int colRows = Convert.ToInt32(tAttendance.Query("SELECT count(*) " +
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
                tAttendance.Query("UPDATE totalchildren SET TotalChildren = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) +
                " WHERE GroupID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[1].Value) + "");

            }
            else
                dtAttendance.CancelEdit();
            //attendance.Query("UPDATE attendance SET ActuallyChildrenAmount = NULL WHERE ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value));
        }

        private void EndEditCurrentAmount()
        {
            if (newRowG == true)
                return;
            if (!String.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[4].Value.ToString()))
            {
                if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) >= Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) && Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) >= 0)
                    tAttendance.Query("UPDATE attendance SET ActuallyChildrenAmount = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[4].Value) + " WHERE attendance.ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value) + "");
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
                tAttendance.Query("UPDATE attendance SET ActuallyChildrenAmount = 0 WHERE attendance.ID = " + Convert.ToInt32(dtAttendance.CurrentRow.Cells[0].Value));
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
            if (newRowC && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                return;
            if (DataBase.Connect())
            {
                if (newRowC == true)
                {
                    int colRows = Convert.ToInt32(tChildren.Query("SELECT count(*) FROM childrens WHERE IDGroup = " + dtAttendance.CurrentRow.Cells[1].Value + ""));
                    if (Convert.ToInt32(dtAttendance.CurrentRow.Cells[3].Value) > colRows)
                    {
                        tChildren.Query("INSERT INTO childrens (IDGroup,`" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "`) " +
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
                    tChildren.Query("UPDATE childrens SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = '" +
                        ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + "' WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                else
                {
                    tChildren.Query("UPDATE childrens SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = NULL WHERE ID = " +
                        ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                if (String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[2].Value.ToString()) &&
                String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[3].Value.ToString()) &&
                String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[4].Value.ToString()) && newRowC == false)
                {
                    tChildren.Query("DELETE FROM childrens WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                }
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    ((DataGridView)sender).DataSource = tChildren.newTable(
                        "SELECT childrens.ID, childrens.IDAgeGroup, childrens.SecondName, childrens.FistName, childrens.FatherName " +
                        "FROM childrens " +
                        "WHERE childrens.IDGroup = '" + dtAttendance.CurrentRow.Cells[1].Value + "'");
                    ((DataGridView)sender).Rows[rowIndex].Selected = true;
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


        //====== РАБОТА С ВОЗРАСТНЫМИ ГРУППАМИ ======
        private void btnAgeGroup_Click(object sender, EventArgs e)
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
                    dtAgeGroup.DataSource = tAgeGroup.newTable("SELECT * FROM AgeGroup");
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
                    dtAgeGroup.DataSource = tAgeGroup.newTable("SELECT * FROM AgeGroup");
                }
            }
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void dtAgeGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
        }

        private void dtAgeGroup_Click(object sender, EventArgs e)
        {
            if (((DataGridView)sender).CurrentRow.IsNewRow)
                newRowAG = true;
            else
                newRowAG = false;
        }

        private void dtAgeGroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DataBase.Connect())
            {
                if (newRowAG && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()))
                    return;
                if (!string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value.ToString()))
                    if (newRowAG == true)
                        tAgeGroup.Query("INSERT INTO AgeGroup (AgeGroup) VALUES ('" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "')");
                    else
                        tAgeGroup.Query("UPDATE AgeGroup SET AgeGroup = '" + ((DataGridView)sender).CurrentRow.Cells[1].Value + "' WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                else
                    tAgeGroup.Query("DELETE FROM AgeGroup WHERE ID = " + ((DataGridView)sender).CurrentRow.Cells[0].Value);
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    ((DataGridView)sender).DataSource = tAgeGroup.newTable("SELECT * FROM AgeGroup");
                    dtAgeGroup.Rows[rowIndex].Selected = true;
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


        //====== РАБОТА С ОТЧЕТОМ ======
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            string rangeDate;
            if (dtpStartDate.Checked == true)
            {
                int index = dataView.FindString(dtpStartDate.Value.ToShortDateString());
                if (index != -1)
                {
                    dataView.SelectedIndex = index;
                    rangeDate = " от " + dtpStartDate.Value.ToShortDateString();
                }
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
            {
                dataView.SelectedIndex = 0;
                DataRowView dateString = (DataRowView)dataView.SelectedItem;
                DateTime shortDate = DateTime.Parse(dateString["Date"].ToString());
                rangeDate = " от " + shortDate.ToShortDateString();
            }
            panel1.Enabled = false;
            dataView.Enabled = false;
            splitContainer2.Enabled = false;
            btnReport.Enabled = false;
            btnAgeGroup.Enabled = false;
            btnCreateReport.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;

            //Создание файла
            using (ExcelPackage Excel = new ExcelPackage())
            {
                //Создание листа
                ExcelWorksheet workSheet = Excel.Workbook.Worksheets.Add("Отчет");

                int allRows = 1;
                for (int d = dataView.SelectedIndex; d <= dataView.Items.Count - 1; d++)
                {
                    DataRowView dateString = (DataRowView)dataView.Items[d];
                    DateTime curDate = DateTime.Parse(dateString["Date"].ToString());

                    //Шапка
                    workSheet.Cells[allRows, 1].Value = curDate.ToShortDateString();
                    workSheet.Cells[allRows, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    workSheet.Cells[allRows + 1, 1].Value = "Название группы";
                    workSheet.Cells[allRows + 1, 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    workSheet.Cells[allRows + 1, 2].Value = "Детей всего";
                    workSheet.Cells[allRows + 1, 2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    workSheet.Cells[allRows + 1, 3].Value = "Детей было";
                    workSheet.Cells[allRows + 1, 3].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    allRows++;

                    for (int i = 1; i < dtAttendance.RowCount - 1; i++)
                    {
                        for (int j = 2; j <= dtAttendance.ColumnCount - 1; j++)
                        {
                            workSheet.Cells[allRows + i, j - 1].Value = dtAttendance.Rows[i - 1].Cells[j].Value;
                            workSheet.Cells[allRows + i, j - 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        }
                    }
                    if (dtpEndDate.Checked == true)
                    {
                        DateTime lastDate = dtpEndDate.Value.Date;
                        if (lastDate == curDate)
                        {
                            rangeDate = rangeDate + " до " + lastDate.ToShortDateString();
                            break;
                        }
                    }
                    allRows = allRows + dtAttendance.RowCount + 1;
                    if (dataView.SelectedIndex != dataView.Items.Count - 1)
                        dataView.SelectedIndex++;
                }

                //Форматирование Файла
                workSheet.Cells.AutoFitColumns();
                workSheet.Cells.Style.Font.Name = "Times New Roman";
                workSheet.Cells.Style.Font.Size = 12;

                //Сохранение Excel
                System.IO.FileInfo fi = new System.IO.FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Отчет о посещаймости" + rangeDate + ".xlsx");
                Excel.SaveAs(fi);
            }
            panel1.Enabled = true;
            dataView.Enabled = true;
            splitContainer2.Enabled = true;
            btnReport.Enabled = true;
            btnAgeGroup.Enabled = true;
            btnCreateReport.Enabled = true;
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
        }

        private void btnReport_Click(object sender, EventArgs e)
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
    }
}
