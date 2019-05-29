namespace MDOUMakeMenu
{
    partial class Dish
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dish));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkMenu = new System.Windows.Forms.LinkLabel();
            this.linkIngredients = new System.Windows.Forms.LinkLabel();
            this.linkChildren = new System.Windows.Forms.LinkLabel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtDish = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtIngredient = new System.Windows.Forms.DataGridView();
            this.ID_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtDinnerType = new System.Windows.Forms.DataGridView();
            this.DTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDinnerType = new System.Windows.Forms.Button();
            this.dtIngredientsComposition = new System.Windows.Forms.DataGridView();
            this.IID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Energy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalProtein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carbohydrates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnComposition = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIngredient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDinnerType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIngredientsComposition)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 75);
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
            this.linkIngredients.Enabled = false;
            this.linkIngredients.ForeColor = System.Drawing.Color.White;
            this.linkIngredients.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkIngredients.LinkColor = System.Drawing.Color.White;
            this.linkIngredients.Location = new System.Drawing.Point(364, 26);
            this.linkIngredients.Name = "linkIngredients";
            this.linkIngredients.Size = new System.Drawing.Size(74, 23);
            this.linkIngredients.TabIndex = 1;
            this.linkIngredients.TabStop = true;
            this.linkIngredients.Text = "Блюда";
            this.linkIngredients.VisitedLinkColor = System.Drawing.Color.White;
            // 
            // linkChildren
            // 
            this.linkChildren.ActiveLinkColor = System.Drawing.Color.White;
            this.linkChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkChildren.AutoSize = true;
            this.linkChildren.DisabledLinkColor = System.Drawing.Color.Gray;
            this.linkChildren.ForeColor = System.Drawing.Color.White;
            this.linkChildren.LinkColor = System.Drawing.Color.White;
            this.linkChildren.Location = new System.Drawing.Point(722, 26);
            this.linkChildren.Name = "linkChildren";
            this.linkChildren.Size = new System.Drawing.Size(56, 23);
            this.linkChildren.TabIndex = 1;
            this.linkChildren.TabStop = true;
            this.linkChildren.Text = "Дети";
            this.linkChildren.VisitedLinkColor = System.Drawing.Color.White;
            this.linkChildren.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkChildren_LinkClicked);
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnter.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEnter.Location = new System.Drawing.Point(887, 20);
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
            this.panel2.Size = new System.Drawing.Size(1034, 3);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(200, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtDish);
            this.splitContainer1.Panel1MinSize = 55;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtIngredient);
            this.splitContainer1.Panel2MinSize = 55;
            this.tableLayoutPanel2.SetRowSpan(this.splitContainer1, 2);
            this.splitContainer1.Size = new System.Drawing.Size(834, 239);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // dtDish
            // 
            this.dtDish.AllowUserToAddRows = false;
            this.dtDish.AllowUserToDeleteRows = false;
            this.dtDish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtDish.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtDish.BackgroundColor = System.Drawing.Color.White;
            this.dtDish.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtDish.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DishName});
            this.dtDish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDish.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtDish.Enabled = false;
            this.dtDish.EnableHeadersVisualStyles = false;
            this.dtDish.GridColor = System.Drawing.Color.Silver;
            this.dtDish.Location = new System.Drawing.Point(0, 0);
            this.dtDish.Margin = new System.Windows.Forms.Padding(0);
            this.dtDish.MultiSelect = false;
            this.dtDish.Name = "dtDish";
            this.dtDish.RowHeadersVisible = false;
            this.dtDish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDish.Size = new System.Drawing.Size(834, 83);
            this.dtDish.TabIndex = 0;
            this.dtDish.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDish_CellClick);
            this.dtDish.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDish_CellDoubleClick);
            this.dtDish.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDish_CellEndEdit);
            this.dtDish.RowContextMenuStripNeeded += new System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventHandler(this.dtDish_RowContextMenuStripNeeded);
            this.dtDish.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtDish_MouseDown);
            this.dtDish.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtDish_MouseMove);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // DishName
            // 
            this.DishName.DataPropertyName = "DishName";
            this.DishName.HeaderText = "Название блюда";
            this.DishName.Name = "DishName";
            // 
            // dtIngredient
            // 
            this.dtIngredient.AllowUserToAddRows = false;
            this.dtIngredient.AllowUserToDeleteRows = false;
            this.dtIngredient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtIngredient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtIngredient.BackgroundColor = System.Drawing.Color.White;
            this.dtIngredient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtIngredient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtIngredient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtIngredient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_,
            this.IName});
            this.dtIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtIngredient.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtIngredient.Enabled = false;
            this.dtIngredient.EnableHeadersVisualStyles = false;
            this.dtIngredient.GridColor = System.Drawing.Color.DarkGray;
            this.dtIngredient.Location = new System.Drawing.Point(0, 0);
            this.dtIngredient.Margin = new System.Windows.Forms.Padding(0);
            this.dtIngredient.MultiSelect = false;
            this.dtIngredient.Name = "dtIngredient";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtIngredient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtIngredient.RowHeadersVisible = false;
            this.dtIngredient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtIngredient.Size = new System.Drawing.Size(834, 154);
            this.dtIngredient.TabIndex = 0;
            this.dtIngredient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredient_CellClick);
            this.dtIngredient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredient_CellDoubleClick);
            this.dtIngredient.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredient_CellEndEdit);
            // 
            // ID_
            // 
            this.ID_.DataPropertyName = "Id";
            this.ID_.HeaderText = "ID";
            this.ID_.Name = "ID_";
            this.ID_.Visible = false;
            // 
            // IName
            // 
            this.IName.DataPropertyName = "Ingredient";
            this.IName.HeaderText = "Название ингредиента";
            this.IName.Name = "IName";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtIngredientsComposition);
            this.tableLayoutPanel1.SetRowSpan(this.splitContainer2, 2);
            this.splitContainer2.Size = new System.Drawing.Size(1034, 454);
            this.splitContainer2.SplitterDistance = 239;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dtDinnerType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDinnerType, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1034, 239);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // dtDinnerType
            // 
            this.dtDinnerType.AllowDrop = true;
            this.dtDinnerType.AllowUserToAddRows = false;
            this.dtDinnerType.AllowUserToDeleteRows = false;
            this.dtDinnerType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtDinnerType.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtDinnerType.BackgroundColor = System.Drawing.Color.White;
            this.dtDinnerType.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtDinnerType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtDinnerType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDinnerType.ColumnHeadersVisible = false;
            this.dtDinnerType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DTID,
            this.Type});
            this.dtDinnerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDinnerType.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtDinnerType.Location = new System.Drawing.Point(0, 0);
            this.dtDinnerType.Margin = new System.Windows.Forms.Padding(0);
            this.dtDinnerType.MultiSelect = false;
            this.dtDinnerType.Name = "dtDinnerType";
            this.dtDinnerType.ReadOnly = true;
            this.dtDinnerType.RowHeadersVisible = false;
            this.dtDinnerType.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dtDinnerType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDinnerType.Size = new System.Drawing.Size(200, 209);
            this.dtDinnerType.TabIndex = 0;
            this.dtDinnerType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDinnerType_CellClick);
            this.dtDinnerType.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDinnerType_CellDoubleClick);
            this.dtDinnerType.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDinnerType_CellEndEdit);
            this.dtDinnerType.DragDrop += new System.Windows.Forms.DragEventHandler(this.dtDinnerType_DragDrop);
            this.dtDinnerType.DragEnter += new System.Windows.Forms.DragEventHandler(this.dtDinnerType_DragEnter);
            // 
            // DTID
            // 
            this.DTID.DataPropertyName = "ID";
            this.DTID.HeaderText = "DinnerTypeID";
            this.DTID.Name = "DTID";
            this.DTID.ReadOnly = true;
            this.DTID.Visible = false;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Тип питания";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // btnDinnerType
            // 
            this.btnDinnerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDinnerType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDinnerType.Location = new System.Drawing.Point(0, 209);
            this.btnDinnerType.Margin = new System.Windows.Forms.Padding(0);
            this.btnDinnerType.Name = "btnDinnerType";
            this.btnDinnerType.Size = new System.Drawing.Size(200, 30);
            this.btnDinnerType.TabIndex = 3;
            this.btnDinnerType.Text = "Добавить";
            this.btnDinnerType.UseVisualStyleBackColor = true;
            this.btnDinnerType.Click += new System.EventHandler(this.btnDinnerType_Click);
            // 
            // dtIngredientsComposition
            // 
            this.dtIngredientsComposition.AllowUserToDeleteRows = false;
            this.dtIngredientsComposition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtIngredientsComposition.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtIngredientsComposition.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtIngredientsComposition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtIngredientsComposition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtIngredientsComposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtIngredientsComposition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IID,
            this.Energy,
            this.Protein,
            this.animalProtein,
            this.BodyMass,
            this.Fat,
            this.Carbohydrates});
            this.dtIngredientsComposition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtIngredientsComposition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtIngredientsComposition.EnableHeadersVisualStyles = false;
            this.dtIngredientsComposition.Location = new System.Drawing.Point(0, 0);
            this.dtIngredientsComposition.Margin = new System.Windows.Forms.Padding(0);
            this.dtIngredientsComposition.Name = "dtIngredientsComposition";
            this.dtIngredientsComposition.RowHeadersVisible = false;
            this.dtIngredientsComposition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtIngredientsComposition.Size = new System.Drawing.Size(1034, 205);
            this.dtIngredientsComposition.TabIndex = 0;
            this.dtIngredientsComposition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredientsComposition_CellClick);
            this.dtIngredientsComposition.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredientsComposition_CellDoubleClick);
            this.dtIngredientsComposition.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredientsComposition_CellEndEdit);
            // 
            // IID
            // 
            this.IID.DataPropertyName = "ingredientID";
            this.IID.HeaderText = "Ingredient ID";
            this.IID.Name = "IID";
            this.IID.Visible = false;
            // 
            // Energy
            // 
            this.Energy.DataPropertyName = "Energy(kkal)";
            this.Energy.HeaderText = "Энергия(ккал.)";
            this.Energy.Name = "Energy";
            // 
            // Protein
            // 
            this.Protein.DataPropertyName = "Protein,g";
            this.Protein.HeaderText = "Белок, г";
            this.Protein.Name = "Protein";
            // 
            // animalProtein
            // 
            this.animalProtein.DataPropertyName = "animalProtein(%)";
            this.animalProtein.HeaderText = "Животный Белок в % от обычного";
            this.animalProtein.Name = "animalProtein";
            // 
            // BodyMass
            // 
            this.BodyMass.DataPropertyName = "g/kg_BodyMass";
            this.BodyMass.HeaderText = "Г/Кг массы тела";
            this.BodyMass.Name = "BodyMass";
            // 
            // Fat
            // 
            this.Fat.DataPropertyName = "Fat,g";
            this.Fat.HeaderText = "Жир, г";
            this.Fat.Name = "Fat";
            // 
            // Carbohydrates
            // 
            this.Carbohydrates.DataPropertyName = "Carbohydrates, g";
            this.Carbohydrates.HeaderText = "Углеводы, г";
            this.Carbohydrates.Name = "Carbohydrates";
            // 
            // btnComposition
            // 
            this.btnComposition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnComposition.Enabled = false;
            this.btnComposition.Location = new System.Drawing.Point(0, 454);
            this.btnComposition.Margin = new System.Windows.Forms.Padding(0);
            this.btnComposition.Name = "btnComposition";
            this.btnComposition.Size = new System.Drawing.Size(1034, 30);
            this.btnComposition.TabIndex = 4;
            this.btnComposition.Text = "Состав ингридиентов";
            this.btnComposition.UseVisualStyleBackColor = true;
            this.btnComposition.Click += new System.EventHandler(this.btnComposition_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnComposition, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1034, 484);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.ToolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(341, 76);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(340, 22);
            this.ToolStripMenuItem.Text = "Добавить блюдо в...";
            this.ToolStripMenuItem.MouseHover += new System.EventHandler(this.ToolStripMenuItem_MouseHover);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(337, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(340, 22);
            this.toolStripMenuItem1.Text = "Удалить блюдо из этого  времени приема пищи";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(340, 22);
            this.ToolStripMenuItem2.Text = "Удалить блюдо навсегда";
            this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // Dish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 500);
            this.Name = "Dish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Блюда";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dish_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIngredient)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDinnerType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtIngredientsComposition)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.LinkLabel linkMenu;
        private System.Windows.Forms.LinkLabel linkIngredients;
        private System.Windows.Forms.LinkLabel linkChildren;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtDish;
        private System.Windows.Forms.DataGridView dtIngredient;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dtIngredientsComposition;
        private System.Windows.Forms.Button btnComposition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnDinnerType;
        private System.Windows.Forms.DataGridView dtDinnerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Energy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalProtein;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyMass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carbohydrates;
    }
}

