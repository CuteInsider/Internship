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
        public Dish(Point Location, object Role)
        {
            InitializeComponent();
            this.Location = Location;
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
        }

        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Menu MForm = new Menu(Location, Role);
            MForm.Show();
        }

        private void linkChildren_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Children CForm = new Children(Location, Role);
            CForm.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Close();
            Application.OpenForms[0].Show();
        }
    }
}
