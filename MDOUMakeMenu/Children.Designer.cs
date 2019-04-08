namespace MDOUMakeMenu
{
    partial class Children
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Children));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkMenu = new System.Windows.Forms.LinkLabel();
            this.linkIngredients = new System.Windows.Forms.LinkLabel();
            this.linkChildren = new System.Windows.Forms.LinkLabel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtAttendance = new System.Windows.Forms.DataGridView();
            this.dtChildren = new System.Windows.Forms.DataGridView();
            this.AgeGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateView = new System.Windows.Forms.ListBox();
            this.btnNone = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNone2 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalChildren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActuallyChildren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.linkMenu);
            this.panel1.Controls.Add(this.linkIngredients);
            this.panel1.Controls.Add(this.linkChildren);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 75);
            this.panel1.TabIndex = 0;
            // 
            // linkMenu
            // 
            this.linkMenu.ActiveLinkColor = System.Drawing.Color.White;
            this.linkMenu.AutoSize = true;
            this.linkMenu.DisabledLinkColor = System.Drawing.Color.Gray;
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
            this.linkIngredients.ForeColor = System.Drawing.Color.White;
            this.linkIngredients.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkIngredients.LinkColor = System.Drawing.Color.White;
            this.linkIngredients.Location = new System.Drawing.Point(389, 26);
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
            this.linkChildren.Location = new System.Drawing.Point(772, 26);
            this.linkChildren.Name = "linkChildren";
            this.linkChildren.Size = new System.Drawing.Size(56, 23);
            this.linkChildren.TabIndex = 1;
            this.linkChildren.TabStop = true;
            this.linkChildren.Text = "Дети";
            this.linkChildren.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnter.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEnter.Location = new System.Drawing.Point(937, 20);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(135, 35);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "Настройки";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 3);
            this.panel2.TabIndex = 1;
            // 
            // dtAttendance
            // 
            this.dtAttendance.AllowUserToAddRows = false;
            this.dtAttendance.AllowUserToDeleteRows = false;
            this.dtAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtAttendance.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ID_,
            this.GroupName,
            this.TotalChildren,
            this.ActuallyChildren});
            this.dtAttendance.Location = new System.Drawing.Point(133, 0);
            this.dtAttendance.Margin = new System.Windows.Forms.Padding(0);
            this.dtAttendance.MultiSelect = false;
            this.dtAttendance.Name = "dtAttendance";
            this.dtAttendance.RowHeadersWidth = 25;
            this.dtAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtAttendance.Size = new System.Drawing.Size(462, 289);
            this.dtAttendance.TabIndex = 2;
            this.dtAttendance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAttendance_CellClick);
            this.dtAttendance.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAttendance_CellEndEdit);
            this.dtAttendance.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtAttendance_DataError);
            // 
            // dtChildren
            // 
            this.dtChildren.AllowUserToAddRows = false;
            this.dtChildren.AllowUserToDeleteRows = false;
            this.dtChildren.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtChildren.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtChildren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtChildren.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AgeGroup,
            this.SecondName,
            this.FistName,
            this.FatherName});
            this.dtChildren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtChildren.Location = new System.Drawing.Point(0, 0);
            this.dtChildren.Margin = new System.Windows.Forms.Padding(0);
            this.dtChildren.MultiSelect = false;
            this.dtChildren.Name = "dtChildren";
            this.dtChildren.ReadOnly = true;
            this.dtChildren.RowHeadersWidth = 5;
            this.dtChildren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtChildren.Size = new System.Drawing.Size(488, 271);
            this.dtChildren.TabIndex = 3;
            // 
            // AgeGroup
            // 
            this.AgeGroup.DataPropertyName = "AgeGroup";
            this.AgeGroup.HeaderText = "Воз. Группа";
            this.AgeGroup.Name = "AgeGroup";
            this.AgeGroup.ReadOnly = true;
            // 
            // SecondName
            // 
            this.SecondName.DataPropertyName = "SecondName";
            this.SecondName.HeaderText = "Фамилия";
            this.SecondName.Name = "SecondName";
            this.SecondName.ReadOnly = true;
            // 
            // FistName
            // 
            this.FistName.DataPropertyName = "FistName";
            this.FistName.HeaderText = "Имя";
            this.FistName.Name = "FistName";
            this.FistName.ReadOnly = true;
            // 
            // FatherName
            // 
            this.FatherName.DataPropertyName = "FatherName";
            this.FatherName.HeaderText = "Отчество";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dateView);
            this.splitContainer1.Panel1.Controls.Add(this.dtAttendance);
            this.splitContainer1.Panel1MinSize = 550;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtChildren);
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(1084, 271);
            this.splitContainer1.SplitterDistance = 595;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // dateView
            // 
            this.dateView.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateView.FormattingEnabled = true;
            this.dateView.ItemHeight = 23;
            this.dateView.Location = new System.Drawing.Point(0, 0);
            this.dateView.Margin = new System.Windows.Forms.Padding(0);
            this.dateView.Name = "dateView";
            this.dateView.Size = new System.Drawing.Size(133, 271);
            this.dateView.TabIndex = 3;
            this.dateView.SelectedIndexChanged += new System.EventHandler(this.dateView_SelectedIndexChanged);
            // 
            // btnNone
            // 
            this.btnNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNone.Location = new System.Drawing.Point(0, 485);
            this.btnNone.Margin = new System.Windows.Forms.Padding(0);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(542, 30);
            this.btnNone.TabIndex = 5;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnComposition_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(540, 204);
            this.dataGridView1.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // splitContainer2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer2, 2);
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1084, 485);
            this.splitContainer2.SplitterDistance = 271;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer3.Size = new System.Drawing.Size(1084, 204);
            this.splitContainer3.SplitterDistance = 540;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(540, 204);
            this.dataGridView2.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNone, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNone2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 515);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnNone2
            // 
            this.btnNone2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNone2.Location = new System.Drawing.Point(542, 485);
            this.btnNone2.Margin = new System.Windows.Forms.Padding(0);
            this.btnNone2.Name = "btnNone2";
            this.btnNone2.Size = new System.Drawing.Size(542, 30);
            this.btnNone2.TabIndex = 6;
            this.btnNone2.Text = "None2";
            this.btnNone2.UseVisualStyleBackColor = true;
            this.btnNone2.Click += new System.EventHandler(this.btnNone2_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // ID_
            // 
            this.ID_.DataPropertyName = "ID1";
            this.ID_.HeaderText = "ID";
            this.ID_.Name = "ID_";
            this.ID_.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Группа";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // TotalChildren
            // 
            this.TotalChildren.DataPropertyName = "TotalChildren";
            this.TotalChildren.HeaderText = "Детей в группе";
            this.TotalChildren.Name = "TotalChildren";
            // 
            // ActuallyChildren
            // 
            this.ActuallyChildren.DataPropertyName = "ActuallyChildrenAmount";
            this.ActuallyChildren.HeaderText = "Детей сегодня";
            this.ActuallyChildren.Name = "ActuallyChildren";
            // 
            // Children
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 593);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 250);
            this.Name = "Children";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Меню";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChildren)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.LinkLabel linkMenu;
        private System.Windows.Forms.LinkLabel linkIngredients;
        private System.Windows.Forms.LinkLabel linkChildren;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtAttendance;
        private System.Windows.Forms.DataGridView dtChildren;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox dateView;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNone2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalChildren;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActuallyChildren;
    }
}

