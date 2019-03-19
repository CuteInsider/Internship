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
        private void LoginIn_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        public LoginIn(Point location)
        {
            InitializeComponent();
            this.Location = location;
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
    }
}
