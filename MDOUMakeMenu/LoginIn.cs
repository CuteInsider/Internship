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
    public partial class LoginIn : Form
    {

        public LoginIn(Point location)
        {
            InitializeComponent();
            this.Location = location;
        }

        private void LoginIn_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void LoginIn_Activated(object sender, EventArgs e)
        {
           //Location = 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                button1.Text = ">Настройки>";
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                button1.Text = "<Настройки<";
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Menu MForm = new Menu(Location);
            MForm.Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Dish CForm = new Dish(Location);
            CForm.Show();
        }

        private void linkChildren_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Children CForm = new Children(Location);
            CForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoginIn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtLogin.Text) && !String.IsNullOrWhiteSpace(txtPassword.Text))
            {

            }
        }
    }
}
