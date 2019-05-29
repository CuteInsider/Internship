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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkMenu = new System.Windows.Forms.LinkLabel();
            this.linkIngredients = new System.Windows.Forms.LinkLabel();
            this.linkChildren = new System.Windows.Forms.LinkLabel();
            this.btnSetup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtDish = new System.Windows.Forms.DataGridView();
            this.DishID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDinnerType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DataView = new System.Windows.Forms.ListBox();
            this.dtMenu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishMenu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbChildrenControl = new System.Windows.Forms.CheckBox();
            this.txtAllChildren = new System.Windows.Forms.TextBox();
            this.btnMakeMenu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDish)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtMenu)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(984, 75);
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
            this.linkIngredients.Location = new System.Drawing.Point(339, 26);
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
            this.linkChildren.Location = new System.Drawing.Point(672, 26);
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
            this.btnSetup.Location = new System.Drawing.Point(838, 20);
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
            this.panel2.Size = new System.Drawing.Size(984, 3);
            this.panel2.TabIndex = 1;
            // 
            // dtDish
            // 
            this.dtDish.AllowDrop = true;
            this.dtDish.AllowUserToAddRows = false;
            this.dtDish.AllowUserToDeleteRows = false;
            this.dtDish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtDish.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dtDish.BackgroundColor = System.Drawing.Color.White;
            this.dtDish.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dtDish.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDish.ColumnHeadersVisible = false;
            this.dtDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DishID,
            this.DishName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtDish.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtDish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDish.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtDish.GridColor = System.Drawing.Color.DarkGray;
            this.dtDish.Location = new System.Drawing.Point(200, 39);
            this.dtDish.Margin = new System.Windows.Forms.Padding(0);
            this.dtDish.MultiSelect = false;
            this.dtDish.Name = "dtDish";
            this.dtDish.ReadOnly = true;
            this.dtDish.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtDish.RowHeadersVisible = false;
            this.dtDish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDish.Size = new System.Drawing.Size(265, 345);
            this.dtDish.TabIndex = 2;
            this.dtDish.DragDrop += new System.Windows.Forms.DragEventHandler(this.dtDish_DragDrop);
            this.dtDish.DragEnter += new System.Windows.Forms.DragEventHandler(this.dtDish_DragEnter);
            this.dtDish.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtDish_MouseDown);
            this.dtDish.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtDish_MouseMove);
            // 
            // DishID
            // 
            this.DishID.DataPropertyName = "ID";
            this.DishID.HeaderText = "ID";
            this.DishID.Name = "DishID";
            this.DishID.ReadOnly = true;
            this.DishID.Visible = false;
            // 
            // DishName
            // 
            this.DishName.DataPropertyName = "DishName";
            this.DishName.HeaderText = "Назавнеие блюда";
            this.DishName.Name = "DishName";
            this.DishName.ReadOnly = true;
            // 
            // cmbDinnerType
            // 
            this.cmbDinnerType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbDinnerType.FormattingEnabled = true;
            this.cmbDinnerType.Location = new System.Drawing.Point(719, 0);
            this.cmbDinnerType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbDinnerType.Name = "cmbDinnerType";
            this.cmbDinnerType.Size = new System.Drawing.Size(265, 31);
            this.cmbDinnerType.TabIndex = 3;
            this.cmbDinnerType.SelectedIndexChanged += new System.EventHandler(this.cmbDinnerType_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel1.Controls.Add(this.dtDish, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DataView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtMenu, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbDinnerType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.15625F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.84375F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 384);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // DataView
            // 
            this.DataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView.FormatString = "D";
            this.DataView.FormattingEnabled = true;
            this.DataView.ItemHeight = 23;
            this.DataView.Location = new System.Drawing.Point(0, 0);
            this.DataView.Margin = new System.Windows.Forms.Padding(0);
            this.DataView.Name = "DataView";
            this.tableLayoutPanel1.SetRowSpan(this.DataView, 2);
            this.DataView.Size = new System.Drawing.Size(200, 384);
            this.DataView.TabIndex = 4;
            this.DataView.SelectedIndexChanged += new System.EventHandler(this.DataView_SelectedIndexChanged);
            // 
            // dtMenu
            // 
            this.dtMenu.AllowDrop = true;
            this.dtMenu.AllowUserToAddRows = false;
            this.dtMenu.AllowUserToDeleteRows = false;
            this.dtMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtMenu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtMenu.BackgroundColor = System.Drawing.Color.White;
            this.dtMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DishMenu});
            this.dtMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtMenu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtMenu.Location = new System.Drawing.Point(719, 39);
            this.dtMenu.Margin = new System.Windows.Forms.Padding(0);
            this.dtMenu.Name = "dtMenu";
            this.dtMenu.ReadOnly = true;
            this.dtMenu.RowHeadersVisible = false;
            this.dtMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtMenu.Size = new System.Drawing.Size(265, 345);
            this.dtMenu.TabIndex = 5;
            this.dtMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.dtMenu_DragDrop);
            this.dtMenu.DragEnter += new System.Windows.Forms.DragEventHandler(this.dtMenu_DragEnter);
            this.dtMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtMenu_MouseDown);
            this.dtMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtMenu_MouseMove);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ИД";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // DishMenu
            // 
            this.DishMenu.DataPropertyName = "DishName";
            this.DishMenu.HeaderText = "Блюдо";
            this.DishMenu.Name = "DishMenu";
            this.DishMenu.ReadOnly = true;
            // 
            // label1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(203, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Меню на";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.cbChildrenControl, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtAllChildren, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnMakeMenu, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(468, 42);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(248, 339);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // cbChildrenControl
            // 
            this.cbChildrenControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbChildrenControl.Checked = true;
            this.cbChildrenControl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChildrenControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbChildrenControl.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cbChildrenControl.FlatAppearance.BorderSize = 5;
            this.cbChildrenControl.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.cbChildrenControl.Location = new System.Drawing.Point(0, 0);
            this.cbChildrenControl.Margin = new System.Windows.Forms.Padding(0);
            this.cbChildrenControl.Name = "cbChildrenControl";
            this.cbChildrenControl.Size = new System.Drawing.Size(248, 50);
            this.cbChildrenControl.TabIndex = 0;
            this.cbChildrenControl.Text = "Учитывать посещаймость";
            this.cbChildrenControl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbChildrenControl.UseVisualStyleBackColor = true;
            this.cbChildrenControl.CheckedChanged += new System.EventHandler(this.cbChildrenControl_CheckedChanged);
            // 
            // txtAllChildren
            // 
            this.txtAllChildren.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAllChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAllChildren.Location = new System.Drawing.Point(0, 50);
            this.txtAllChildren.Margin = new System.Windows.Forms.Padding(0);
            this.txtAllChildren.Name = "txtAllChildren";
            this.txtAllChildren.ReadOnly = true;
            this.txtAllChildren.Size = new System.Drawing.Size(248, 31);
            this.txtAllChildren.TabIndex = 2;
            this.txtAllChildren.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMakeMenu
            // 
            this.btnMakeMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMakeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMakeMenu.Location = new System.Drawing.Point(0, 299);
            this.btnMakeMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMakeMenu.Name = "btnMakeMenu";
            this.btnMakeMenu.Size = new System.Drawing.Size(248, 40);
            this.btnMakeMenu.TabIndex = 1;
            this.btnMakeMenu.Text = "Сформировать меню";
            this.btnMakeMenu.UseVisualStyleBackColor = true;
            this.btnMakeMenu.Click += new System.EventHandler(this.btnMakeMenu_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 500);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDish)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtMenu)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.LinkLabel linkMenu;
        private System.Windows.Forms.LinkLabel linkIngredients;
        private System.Windows.Forms.LinkLabel linkChildren;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtDish;
        private System.Windows.Forms.ComboBox cmbDinnerType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox DataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishName;
        private System.Windows.Forms.DataGridView dtMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox cbChildrenControl;
        private System.Windows.Forms.Button btnMakeMenu;
        private System.Windows.Forms.TextBox txtAllChildren;
    }
}

