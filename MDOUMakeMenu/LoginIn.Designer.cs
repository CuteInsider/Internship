namespace MDOUMakeMenu
{
    partial class LoginIn
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginIn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkMenu = new System.Windows.Forms.LinkLabel();
            this.linkIngredients = new System.Windows.Forms.LinkLabel();
            this.linkChildren = new System.Windows.Forms.LinkLabel();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblErr = new System.Windows.Forms.Label();
            this.lblHello = new System.Windows.Forms.Label();
            this.btnSetup = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnLoginIn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.linkMenu);
            this.panel1.Controls.Add(this.linkIngredients);
            this.panel1.Controls.Add(this.linkChildren);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 75);
            this.panel1.TabIndex = 0;
            // 
            // linkMenu
            // 
            this.linkMenu.ActiveLinkColor = System.Drawing.Color.White;
            this.linkMenu.AutoSize = true;
            this.linkMenu.DisabledLinkColor = System.Drawing.Color.Gray;
            this.linkMenu.Enabled = false;
            this.linkMenu.ForeColor = System.Drawing.Color.White;
            this.linkMenu.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkMenu.LinkColor = System.Drawing.Color.White;
            this.linkMenu.Location = new System.Drawing.Point(12, 26);
            this.linkMenu.Name = "linkMenu";
            this.linkMenu.Size = new System.Drawing.Size(65, 23);
            this.linkMenu.TabIndex = 1;
            this.linkMenu.TabStop = true;
            this.linkMenu.Text = "Меню";
            this.linkMenu.VisitedLinkColor = System.Drawing.Color.White;
            this.linkMenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMenu_LinkClicked);
            // 
            // linkIngredients
            // 
            this.linkIngredients.ActiveLinkColor = System.Drawing.Color.White;
            this.linkIngredients.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkIngredients.AutoSize = true;
            this.linkIngredients.DisabledLinkColor = System.Drawing.Color.Gray;
            this.linkIngredients.Enabled = false;
            this.linkIngredients.ForeColor = System.Drawing.Color.White;
            this.linkIngredients.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkIngredients.LinkColor = System.Drawing.Color.White;
            this.linkIngredients.Location = new System.Drawing.Point(264, 26);
            this.linkIngredients.Name = "linkIngredients";
            this.linkIngredients.Size = new System.Drawing.Size(74, 23);
            this.linkIngredients.TabIndex = 1;
            this.linkIngredients.TabStop = true;
            this.linkIngredients.Text = "Блюда";
            this.linkIngredients.VisitedLinkColor = System.Drawing.Color.White;
            this.linkIngredients.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIngredients_LinkClicked);
            // 
            // linkChildren
            // 
            this.linkChildren.ActiveLinkColor = System.Drawing.Color.White;
            this.linkChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkChildren.AutoSize = true;
            this.linkChildren.DisabledLinkColor = System.Drawing.Color.Gray;
            this.linkChildren.Enabled = false;
            this.linkChildren.ForeColor = System.Drawing.Color.White;
            this.linkChildren.LinkColor = System.Drawing.Color.White;
            this.linkChildren.Location = new System.Drawing.Point(522, 26);
            this.linkChildren.Name = "linkChildren";
            this.linkChildren.Size = new System.Drawing.Size(56, 23);
            this.linkChildren.TabIndex = 1;
            this.linkChildren.TabStop = true;
            this.linkChildren.Text = "Дети";
            this.linkChildren.VisitedLinkColor = System.Drawing.Color.White;
            this.linkChildren.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChildren_LinkClicked);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(722, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Выход";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 3);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 78);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblErr);
            this.splitContainer1.Panel1.Controls.Add(this.lblHello);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetup);
            this.splitContainer1.Panel1.Controls.Add(this.txtPassword);
            this.splitContainer1.Panel1.Controls.Add(this.lblPassword);
            this.splitContainer1.Panel1.Controls.Add(this.txtLogin);
            this.splitContainer1.Panel1.Controls.Add(this.lblLogin);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoginIn);
            this.splitContainer1.Size = new System.Drawing.Size(834, 384);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblErr
            // 
            this.lblErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblErr.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErr.Location = new System.Drawing.Point(0, 351);
            this.lblErr.Margin = new System.Windows.Forms.Padding(0);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(391, 33);
            this.lblErr.TabIndex = 5;
            this.lblErr.Text = "-";
            this.lblErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblErr.Visible = false;
            // 
            // lblHello
            // 
            this.lblHello.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHello.Location = new System.Drawing.Point(0, 0);
            this.lblHello.Margin = new System.Windows.Forms.Padding(0);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(391, 23);
            this.lblHello.TabIndex = 4;
            this.lblHello.Text = "-";
            this.lblHello.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHello.Visible = false;
            // 
            // btnSetup
            // 
            this.btnSetup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSetup.Enabled = false;
            this.btnSetup.FlatAppearance.BorderSize = 0;
            this.btnSetup.Location = new System.Drawing.Point(391, 0);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(20, 384);
            this.btnSetup.TabIndex = 3;
            this.btnSetup.Text = "<Настройки<";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(117, 196);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(159, 31);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(118, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(166, 23);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Введите пароль";
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogin.Location = new System.Drawing.Point(117, 92);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(159, 31);
            this.txtLogin.TabIndex = 2;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(118, 66);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(153, 23);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Введите логин";
            // 
            // btnLoginIn
            // 
            this.btnLoginIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoginIn.Location = new System.Drawing.Point(142, 291);
            this.btnLoginIn.Name = "btnLoginIn";
            this.btnLoginIn.Size = new System.Drawing.Size(100, 35);
            this.btnLoginIn.TabIndex = 0;
            this.btnLoginIn.Text = "Войти";
            this.btnLoginIn.UseVisualStyleBackColor = true;
            this.btnLoginIn.Click += new System.EventHandler(this.btnLoginIn_Click);
            // 
            // LoginIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 500);
            this.Name = "LoginIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Меню";
            this.Activated += new System.EventHandler(this.LoginIn_Activated);
            this.Load += new System.EventHandler(this.LoginIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.LinkLabel linkMenu;
        private System.Windows.Forms.LinkLabel linkIngredients;
        private System.Windows.Forms.LinkLabel linkChildren;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnLoginIn;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Label lblErr;
    }
}

