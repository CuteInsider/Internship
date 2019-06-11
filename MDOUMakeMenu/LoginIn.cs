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
        object Role = null;
        Table login = new Table();
        public LoginIn(Point location, FormWindowState State)
        {
            InitializeComponent();
            this.Location = location;
            this.WindowState = State;
            splitContainer1.Panel2Collapsed = true;
            if (DataBase.Connect())
            {
                object result = login.Query("SELECT Role FROM users WHERE state = 'YES'");
                DataBase.Close();
                if (result != null)
                {
                    Role = result.ToString();
                    switch (Role)
                    {
                        case "A":
                            linkMenu.Enabled = true;
                            linkIngredients.Enabled = true;
                            linkChildren.Enabled = true;
                            btnSetup.Visible = true;
                            lblHello.Text = "Добро пожаловать Администратор";
                            break;

                        case "T":
                            linkMenu.Enabled = false;
                            linkIngredients.Enabled = false;
                            linkChildren.Enabled = true;
                            btnSetup.Visible = false;
                            lblHello.Text = "Добро пожаловать Воспитатель";
                            break;

                        case "M":
                            linkMenu.Enabled = true;
                            linkIngredients.Enabled = true;
                            linkChildren.Enabled = false;
                            btnSetup.Visible = false;
                            lblHello.Text = "Добро пожаловать Медсестра";
                            break;
                    }
                    lblLogin.Enabled = false;
                    lblPassword.Enabled = false;
                    txtLogin.Text = String.Empty;
                    txtLogin.Enabled = false;
                    txtPassword.Text = String.Empty;
                    txtPassword.Enabled = false;
                    lblHello.Visible = true;
                    btnLoginIn.Text = "Выйти";
                }
            }
        }

        // ====== НАВИГАЦИЯ ======
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Menu MForm = new Menu(Location, this.WindowState, Role);
            MForm.Show();
        }

        private void linkIngredients_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Dish CForm = new Dish(Location, this.WindowState, Role);
            CForm.Show();
        }

        private void linkChildren_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Children CForm = new Children(Location, this.WindowState, Role);
            CForm.Show();
        }


        //====== НАСТРОЙКИ ======
        private void btnSetup_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel2Collapsed == true)
            {
                btnSetup.Text = ">Настройки>";
                splitContainer1.Panel2Collapsed = false;
            }
            else
            {
                btnSetup.Text = "<Настройки<";
                splitContainer1.Panel2Collapsed = true;
            }
        }

        private void btnLoginIn_Click(object sender, EventArgs e)
        {
            if (DataBase.Connect())
            {
                if (btnLoginIn.Text == "Войти")
                {
                    if (!String.IsNullOrWhiteSpace(txtLogin.Text) && !String.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        Role = login.Query("SELECT role FROM users WHERE Login = '" + txtLogin.Text + "' AND Password = '" + txtPassword.Text + "'");
                        login.Query("UPDATE users SET state = 'YES' WHERE Login = '" + txtLogin.Text + "'");
                        switch (Role)
                        {
                            case "A":
                                linkMenu.Enabled = true;
                                linkIngredients.Enabled = true;
                                linkChildren.Enabled = true;
                                btnSetup.Visible = true;
                                lblHello.Text = "Добро пожаловать Администратор";
                                break;

                            case "T":
                                linkMenu.Enabled = false;
                                linkIngredients.Enabled = false;
                                linkChildren.Enabled = true;
                                btnSetup.Visible = false;
                                lblHello.Text = "Добро пожаловать Воспитатель";
                                break;

                            case "M":
                                linkMenu.Enabled = true;
                                linkIngredients.Enabled = true;
                                linkChildren.Enabled = false;
                                btnSetup.Visible = false;
                                lblHello.Text = "Добро пожаловать Человек-меню";
                                break;

                            default:
                                linkMenu.Enabled = false;
                                linkIngredients.Enabled = false;
                                linkChildren.Enabled = false;
                                lblHello.Visible = false;
                                btnSetup.Visible = false;
                                lblErr.Text = "Неверный логин или пароль";
                                lblErr.Visible = true;
                                DataBase.Close();
                                return;
                        }
                        lblLogin.Enabled = false;
                        lblPassword.Enabled = false;
                        txtLogin.Text = String.Empty;
                        txtLogin.Enabled = false;
                        txtPassword.Text = String.Empty;
                        txtPassword.Enabled = false;
                        lblHello.Visible = true;
                        btnLoginIn.Text = "Выйти";
                    }
                }
                else
                {
                    login.Query("UPDATE users SET state = 'NO' WHERE Login = '" + txtLogin.Text + "'");
                    linkMenu.Enabled = false;
                    linkIngredients.Enabled = false;
                    linkChildren.Enabled = false;
                    lblHello.Visible = false;

                    lblLogin.Enabled = true;
                    lblPassword.Enabled = true;
                    txtLogin.Enabled = true;
                    txtPassword.Enabled = true;
                    btnLoginIn.Text = "Войти";
                }
                DataBase.Close();
            }
            else
            {
                lblErr.Text = "Проверте поодключение к базе данных";
                lblErr.Visible = true;
            }
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.Filter = "Structured Query Language(*.sql)|*.sql";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (DataBase.Connect())
                    {
                        if (DataBase.BackUp(saveFileDialog.FileName))
                        {
                            MessageBox.Show(
                                "Экспорт завершен",
                                "Операция",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        DataBase.Close();
                    }
                }
            }
        }

        //====== ВХОД ======
        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Structured Query Language(*.sql)|*.sql";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (DataBase.Connect())
                    {
                        if (DataBase.Restore(openFileDialog.FileName))
                        {
                            MessageBox.Show(
                                "Импорт завершен",
                                "Операция",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        DataBase.Close();
                    }
                }
            }
        }
    }
}
