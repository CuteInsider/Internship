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
    public partial class Children : Form
    {
        object Role;
        public Children(Point Location, object Role)
        {
            InitializeComponent();
            Table attendance = new Table();
            this.Location = Location;
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

            dtAttendance.DataSource = attendance.newTable("SELECT groups.ID, attendance.Date, groups.GroupName, totalchildren.TotalChildren, attendance.ActuallyChildrenAmount " +
                "FROM attendance " +
                "INNER JOIN totalchildren ON attendance.GroupId = totalchildren.GroupID " +
                "INNER JOIN groups ON totalchildren.GroupID = groups.ID");
        }
        private void dtAttendance_Click(object sender, EventArgs e)
        {
            dtChildren.DataSource = selectChildren(dtAttendance.CurrentRow.Cells[0].Value.ToString());
        }
        private object selectChildren(string group)
        {
            Table children = new Table();
            return children.newTable("SELECT agegroup.AgeGroup, childrens.SecondName, childrens.FistName, childrens.FatherName " +
                "FROM childrens " +
                "INNER JOIN agegroup ON childrens.IDAgeGroup = agegroup.ID " +
                "WHERE childrens.IDGroup = '" + group + "'");
        }

        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Menu MForm = new Menu(Location, Role);
            MForm.Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Dish DForm = new Dish(Location, Role);
            DForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms[0].Show();
        }
    }
}
