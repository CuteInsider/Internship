﻿using System;
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
        Table tNforAG = new Table();

        object Role;
        bool newRowC = false;
        bool newRowG = false;
        bool newRowAG = false;
        bool newRowNforAG = false;

        bool closing = true;

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
                    if (!(LastDate.DayOfWeek == DayOfWeek.Saturday) || !(LastDate.DayOfWeek == DayOfWeek.Sunday))
                    {
                        for (int i = 1; i <= colRows; i++)
                            date.Query("INSERT INTO attendance (Date, GroupID, ActuallyChildrenAmount) VALUES ('" + LastDate.Date.ToString("yyyy-MM-dd") + "', " + i + ", " + 0 + ")");
                    }
                }
                dataView.DataSource = date.newTable("SELECT date FROM attendance GROUP BY Date");
                dataView.ValueMember = "date";
                //dataView.DisplayMember = "date";
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
            InvokeDtAttendance(dataView.SelectedValue);
            splitContainer4.Panel2Collapsed = true;
            open = true;
        }


        //====== НАВИГАЦИЯ ======
        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            closing = false;
            Close();
            Menu MForm = new Menu(Location, this.WindowState, Role);
            MForm.Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            closing = false;
            Close();
            Dish DForm = new Dish(Location, this.WindowState, Role);
            DForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            closing = false;
            Close();
            Application.OpenForms[0].WindowState = this.WindowState;
            Application.OpenForms[0].Location = this.Location;
            Application.OpenForms[0].Show();
        }

        private void Children_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closing)
                Application.Exit();
        }

        //====== РАБОТА СО СПИСКОМ ДАТ ======
        private void dateView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (open == true)
            {
                InvokeDtAttendance(dataView.SelectedValue);

            }
        }


        //====== РАБОТА С ПОСЕЩАЙМОСТТЬЮ ======
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

        private void dtAttendance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowG = false;
            }
            else
            {
                newRowG = true;
            }
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
            if (newRowG && string.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[2].Value?.ToString()))
                return;
            if (!string.IsNullOrEmpty(dtAttendance.CurrentRow.Cells[2].Value?.ToString()))
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
            if (dtAttendance.CurrentRow.Cells[anError.ColumnIndex].OwningColumn.Name == "GroupName")
                dtAttendance.CurrentRow.Cells[anError.ColumnIndex].Value = string.Empty;
            else
                dtAttendance.CancelEdit();
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
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowC = false;
            }
            else
            {
                newRowC = true;
            }
        }

        private void dtChildren_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowC && ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value == null)
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
        private void InvokeDtAgeGroup()
        {
            dtAgeGroup.DataSource = tAgeGroup.newTable("SELECT * FROM AgeGroup");
        }

        private void btnAgeGroup_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
                VerticalOrientation();
                if (splitContainer3.Panel2Collapsed == true)
                {
                    splitContainer3.Panel2Collapsed = false;
                    splitContainer3.Panel2.Show();
                    splitContainer3.Panel1Collapsed = true;
                    splitContainer3.Panel1.Hide();
                    InvokeDtAgeGroup();
                    VerticalOrientation();
                }
            }
            else if (splitContainer3.Panel1Collapsed == false)
            {
                HorizontalOrientation();
                if (splitContainer3.Panel2Collapsed == false)
                {
                    splitContainer3.Panel2Collapsed = true;
                    splitContainer3.Panel2.Hide();
                }
                else
                {
                    splitContainer3.Panel2Collapsed = false;
                    splitContainer3.Panel2.Show();
                    InvokeDtAgeGroup();
                }
            }
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void dtAgeGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridView)sender).BeginEdit(false);
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowAG = false;
            }
            else
            {
                newRowAG = true;
            }
            ((DataGridView)sender).AllowUserToAddRows = false;
        }

        private void dtAgeGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowAG = false;
            }
            else
            {
                newRowAG = true;
            }
            ((DataGridView)sender).AllowUserToAddRows = false;
            if (dtAgeGroup.CurrentRow.Index < dtNFAG.Rows.Count)
            {
                dtNFAG.Rows[dtAgeGroup.CurrentRow.Index].Selected = true;
                dtNFAG.CurrentCell = dtNFAG[1, dtAgeGroup.CurrentRow.Index];
            }
        }

        private void dtAgeGroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowC && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value?.ToString()))
                return;
            if (DataBase.Connect())
            {
                if (newRowAG && string.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[1].Value?.ToString()))
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
                    if (dtAgeGroup.Rows.Count - 1 <= dtNFAG.Rows.Count - (dtNFAG.AllowUserToAddRows ? 1 : 0))
                    {
                        dtNFAG.AllowUserToAddRows = false;
                        dtNFAG.Rows.RemoveAt(dtNFAG.CurrentRow.Index);
                    }
                    else
                        dtNFAG.AllowUserToAddRows = true;
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

        private void HorizontalOrientation()
        {
            splitContainer4.Orientation = Orientation.Horizontal;

            tableLayoutPanel2.SetRowSpan(splitContainer4, 1);
            tableLayoutPanel2.SetRowSpan(btnNFAG, 1);

            tableLayoutPanel2.SetColumn(btnNFAG, 0);
            tableLayoutPanel2.SetRow(btnNFAG, 1);

            tableLayoutPanel2.SetColumnSpan(btnNFAG, 2);
            tableLayoutPanel2.SetColumnSpan(splitContainer4, 2);

            splitContainer4.SplitterDistance = splitContainer4.Width / 2;
        }

        private void VerticalOrientation()
        {
            splitContainer4.Orientation = Orientation.Vertical;

            tableLayoutPanel2.SetColumnSpan(btnNFAG, 1);
            tableLayoutPanel2.SetColumnSpan(splitContainer4, 1);

            tableLayoutPanel2.SetColumn(btnNFAG, 1);
            tableLayoutPanel2.SetRow(btnNFAG, 0);

            tableLayoutPanel2.SetRowSpan(btnNFAG, 2);
            tableLayoutPanel2.SetRowSpan(splitContainer4, 2);

            splitContainer4.SplitterDistance = splitContainer4.Width / 2;
        }


        //====== РАБОТА С НОРМАМИ ДЛЯ ВГ ======
        private void InvokeDtNforAG(int selectedRow)
        {
            dtNFAG.DataSource = tNforAG.newTable("SELECT * FROM normsforag");
            if (selectedRow < dtNFAG.RowCount)
                dtNFAG.Rows[selectedRow].Selected = true;
        }

        private void btnNFAG_Click(object sender, EventArgs e)
        {
            if (splitContainer4.Panel2Collapsed)
            {
                splitContainer4.Panel2Collapsed = false;
                InvokeDtNforAG(dtAgeGroup.CurrentRow.Index);
                if (dtAgeGroup.Rows.Count - 1 <= dtNFAG.Rows.Count)
                    dtNFAG.AllowUserToAddRows = false;
                else
                    dtNFAG.AllowUserToAddRows = true;
            }
            else
            {
                splitContainer4.Panel2Collapsed = true;
            }
        }

        private void dtNFAG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowNforAG = false;
            }
            else
            {
                newRowNforAG = true;
            }
            if (dtNFAG.CurrentRow.Index < dtAgeGroup.Rows.Count)
            {
                dtAgeGroup.Rows[dtNFAG.CurrentRow.Index].Selected = true;
                dtAgeGroup.CurrentCell = dtAgeGroup[1, dtNFAG.CurrentRow.Index];
            }
        }

        private void dtNFAG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dtNFAG.BeginEdit(false);
            if (!((DataGridView)sender).CurrentRow.IsNewRow)
            {
                newRowNforAG = false;
            }
            else
            {
                newRowNforAG = true;
            }
        }

        private void dtNFAG_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (newRowNforAG == true && String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value?.ToString()))
                return;
            if (DataBase.Connect())
            {
                if (newRowNforAG == true)
                    tNforAG.Query("INSERT INTO normsforag (IDAgeGroup, `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "`) VALUES (" +
                        dtAgeGroup.CurrentRow.Cells[0].Value + ", " + ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + ");");
                else if (!String.IsNullOrEmpty(((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value.ToString()))
                {
                    tNforAG.Query("UPDATE normsforag SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = '" +
                        ((DataGridView)sender).CurrentRow.Cells[e.ColumnIndex].Value + "' WHERE IDAgeGroup = " + dtAgeGroup.CurrentRow.Cells[0].Value);
                }
                else
                {
                    tNforAG.Query("UPDATE normsforag SET `" + ((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName + "` = NULL WHERE IDAgeGroup = " +
                        dtAgeGroup.CurrentRow.Cells[0].Value);
                }
                int rowIndex = e.RowIndex;
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    InvokeDtNforAG(dtAgeGroup.CurrentRow.Index);
                    dtNFAG.Rows[rowIndex].Selected = true;
                    if (dtAgeGroup.Rows.Count - 1 <= dtNFAG.Rows.Count - (dtNFAG.AllowUserToAddRows ? 1 : 0))
                    {
                        dtNFAG.AllowUserToAddRows = false;
                    }
                    else
                        dtNFAG.AllowUserToAddRows = true;
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

        private void dtNFAG_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dtNFAG.CancelEdit();
            e.ThrowException = false;
            e.Cancel = true;
        }

        //====== РАБОТА С ОТЧЕТОМ ======
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
                HorizontalOrientation();
                if (splitContainer3.Panel1Collapsed == true)
                {
                    splitContainer3.Panel1Collapsed = false;
                    splitContainer3.Panel1.Show();
                    splitContainer3.Panel2Collapsed = true;
                    splitContainer3.Panel2.Hide();
                    HorizontalOrientation();
                }
            }
            else if (splitContainer3.Panel2Collapsed == false)
            {
                if (splitContainer3.Panel1Collapsed == false)
                {
                    splitContainer3.Panel1Collapsed = true;
                    splitContainer3.Panel1.Hide();
                    VerticalOrientation();
                }
                else
                {
                    splitContainer3.Panel1Collapsed = false;
                    splitContainer3.Panel1.Show();
                    HorizontalOrientation();
                }
            }
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show(
                "Начальная дата не может быть больше конечной",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            string rangeDate;
            if (dtpStartDate.Checked == true)
            {
                int index = dataView.FindString(dtpStartDate.Value.Date.ToString("D"));
                if (index != -1)
                {
                    dataView.SelectedIndex = index;
                    rangeDate = " от " + dtpStartDate.Value.ToString("D");
                }
                else
                {
                    MessageBox.Show(
                        "Такой начальной даты не сущевствует в списке",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                dataView.SelectedIndex = 0;
                DateTime shortDate = dtpStartDate.Value.Date;
                rangeDate = " от " + shortDate.ToString("D");
            }
            DateTime lastDate;
            if (dtpEndDate.Checked == true)
            {
                int index = dataView.FindString(dtpEndDate.Value.Date.ToString("D"));
                if (index != -1)
                {
                    lastDate = dtpEndDate.Value.Date;
                }
                else
                {
                    MessageBox.Show(
                        "Такой конечной даты не сущевствует в списке",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
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
                        workSheet.Cells[allRows, 1].Value = curDate.ToString("D");
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
                        if (lastDate == curDate)
                        {
                            rangeDate = rangeDate + " по " + lastDate.ToString("D");
                            break;
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
        }
    }
}
