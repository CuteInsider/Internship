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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dish));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkMenu = new System.Windows.Forms.LinkLabel();
            this.linkIngredients = new System.Windows.Forms.LinkLabel();
            this.linkChildren = new System.Windows.Forms.LinkLabel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataView = new System.Windows.Forms.ListBox();
            this.dtDish = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtIngredient = new System.Windows.Forms.DataGridView();
            this.ID_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dtIngredientsComposition = new System.Windows.Forms.DataGridView();
            this.IDic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Energy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalProtein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carbohydrates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnComposition = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtIngredientsComposition)).BeginInit();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataView);
            this.splitContainer1.Panel1.Controls.Add(this.dtDish);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtIngredient);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1034, 235);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataView
            // 
            this.dataView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataView.FormattingEnabled = true;
            this.dataView.ItemHeight = 23;
            this.dataView.Location = new System.Drawing.Point(0, 0);
            this.dataView.Margin = new System.Windows.Forms.Padding(0);
            this.dataView.Name = "dataView";
            this.dataView.Size = new System.Drawing.Size(125, 235);
            this.dataView.TabIndex = 1;
            this.dataView.SelectedIndexChanged += new System.EventHandler(this.dataView_SelectedIndexChanged);
            // 
            // dtDish
            // 
            this.dtDish.AllowUserToDeleteRows = false;
            this.dtDish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDish.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtDish.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtDish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DishName});
            this.dtDish.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtDish.Location = new System.Drawing.Point(125, 0);
            this.dtDish.Margin = new System.Windows.Forms.Padding(0);
            this.dtDish.MultiSelect = false;
            this.dtDish.Name = "dtDish";
            this.dtDish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDish.Size = new System.Drawing.Size(367, 235);
            this.dtDish.TabIndex = 0;
            this.dtDish.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDish_CellClick);
            this.dtDish.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDish_CellDoubleClick);
            this.dtDish.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDish_CellEndEdit);
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
            this.DishName.HeaderText = "Название";
            this.DishName.Name = "DishName";
            // 
            // dtIngredient
            // 
            this.dtIngredient.AllowUserToDeleteRows = false;
            this.dtIngredient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtIngredient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtIngredient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtIngredient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_,
            this.IName});
            this.dtIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtIngredient.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtIngredient.Location = new System.Drawing.Point(0, 0);
            this.dtIngredient.MultiSelect = false;
            this.dtIngredient.Name = "dtIngredient";
            this.dtIngredient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtIngredient.Size = new System.Drawing.Size(538, 235);
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
            this.ID_.Width = 58;
            // 
            // IName
            // 
            this.IName.DataPropertyName = "Ingredient";
            this.IName.HeaderText = "Название";
            this.IName.Name = "IName";
            this.IName.Width = 127;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 78);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dtIngredientsComposition);
            this.splitContainer2.Size = new System.Drawing.Size(1034, 484);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.SplitterWidth = 10;
            this.splitContainer2.TabIndex = 3;
            // 
            // dtIngredientsComposition
            // 
            this.dtIngredientsComposition.AllowUserToDeleteRows = false;
            this.dtIngredientsComposition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtIngredientsComposition.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtIngredientsComposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtIngredientsComposition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDic,
            this.IID,
            this.Energy,
            this.Protein,
            this.animalProtein,
            this.BodyMass,
            this.Fat,
            this.Carbohydrates});
            this.dtIngredientsComposition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtIngredientsComposition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtIngredientsComposition.Location = new System.Drawing.Point(0, 0);
            this.dtIngredientsComposition.Margin = new System.Windows.Forms.Padding(0);
            this.dtIngredientsComposition.Name = "dtIngredientsComposition";
            this.dtIngredientsComposition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtIngredientsComposition.Size = new System.Drawing.Size(1034, 239);
            this.dtIngredientsComposition.TabIndex = 0;
            this.dtIngredientsComposition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredientsComposition_CellClick);
            this.dtIngredientsComposition.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredientsComposition_CellDoubleClick);
            this.dtIngredientsComposition.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtIngredientsComposition_CellEndEdit);
            // 
            // IDic
            // 
            this.IDic.DataPropertyName = "ID";
            this.IDic.HeaderText = "ID";
            this.IDic.Name = "IDic";
            this.IDic.Visible = false;
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
            this.btnComposition.Location = new System.Drawing.Point(0, 532);
            this.btnComposition.Margin = new System.Windows.Forms.Padding(0);
            this.btnComposition.Name = "btnComposition";
            this.btnComposition.Size = new System.Drawing.Size(1034, 30);
            this.btnComposition.TabIndex = 4;
            this.btnComposition.Text = "Состав ингридиентов";
            this.btnComposition.UseVisualStyleBackColor = true;
            this.btnComposition.Click += new System.EventHandler(this.btnComposition_Click);
            // 
            // Dish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 562);
            this.Controls.Add(this.btnComposition);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(475, 500);
            this.Name = "Dish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Меню";
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
            ((System.ComponentModel.ISupportInitialize)(this.dtIngredientsComposition)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishName;
        private System.Windows.Forms.ListBox dataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dtIngredientsComposition;
        private System.Windows.Forms.Button btnComposition;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDic;
        private System.Windows.Forms.DataGridViewTextBoxColumn IID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Energy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalProtein;
        private System.Windows.Forms.DataGridViewTextBoxColumn BodyMass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carbohydrates;
    }
}

