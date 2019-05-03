namespace MDOUMakeMenu
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkMenu = new System.Windows.Forms.LinkLabel();
            this.linkIngredients = new System.Windows.Forms.LinkLabel();
            this.linkChildren = new System.Windows.Forms.LinkLabel();
            this.btnSetup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtMenu = new System.Windows.Forms.DataGridView();
            this.dtDish = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDish)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.linkMenu);
            this.panel1.Controls.Add(this.linkIngredients);
            this.panel1.Controls.Add(this.linkChildren);
            this.panel1.Controls.Add(this.btnSetup);
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
            // 
            // linkIngredients
            // 
            this.linkIngredients.ActiveLinkColor = System.Drawing.Color.White;
            this.linkIngredients.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkIngredients.AutoSize = true;
            this.linkIngredients.DisabledLinkColor = System.Drawing.Color.Gray;
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
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetup.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetup.Location = new System.Drawing.Point(688, 20);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(135, 35);
            this.btnSetup.TabIndex = 0;
            this.btnSetup.Text = "Настройки";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnEnter_Click);
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
            // dtMenu
            // 
            this.dtMenu.AllowUserToAddRows = false;
            this.dtMenu.AllowUserToDeleteRows = false;
            this.dtMenu.BackgroundColor = System.Drawing.Color.White;
            this.dtMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtMenu, 3);
            this.dtMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtMenu.Location = new System.Drawing.Point(156, 0);
            this.dtMenu.Margin = new System.Windows.Forms.Padding(0);
            this.dtMenu.Name = "dtMenu";
            this.dtMenu.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dtMenu, 5);
            this.dtMenu.Size = new System.Drawing.Size(274, 384);
            this.dtMenu.TabIndex = 1;
            // 
            // dtDish
            // 
            this.dtDish.AllowUserToAddRows = false;
            this.dtDish.AllowUserToDeleteRows = false;
            this.dtDish.BackgroundColor = System.Drawing.Color.White;
            this.dtDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dtDish, 4);
            this.dtDish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDish.Location = new System.Drawing.Point(517, 0);
            this.dtDish.Margin = new System.Windows.Forms.Padding(0);
            this.dtDish.Name = "dtDish";
            this.dtDish.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dtDish, 5);
            this.dtDish.Size = new System.Drawing.Size(317, 384);
            this.dtDish.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.417768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.417768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.08275F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.47021F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.47021F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.47021F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.417768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.417768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.417768F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.417768F));
            this.tableLayoutPanel1.Controls.Add(this.dtDish, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtMenu, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.87578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.87578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.87578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.40994F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.96273F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 384);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 500);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Меню";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDish)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.LinkLabel linkMenu;
        private System.Windows.Forms.LinkLabel linkIngredients;
        private System.Windows.Forms.LinkLabel linkChildren;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dtDish;
    }
}

