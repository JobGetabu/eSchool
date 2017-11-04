namespace eSchool
{
    partial class ExpenseUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ColumnDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.Form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAdminNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.gData = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTopRght = new System.Windows.Forms.Panel();
            this.lblYear = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblRowCount = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnFilter = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddExpense = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lblPaid = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTerm = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblT2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblT1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblDateDay = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblT3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelTopLeft = new System.Windows.Forms.Panel();
            this.lblDateNow = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pBoxLogoTerm = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gData)).BeginInit();
            this.panelTopRght.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTopLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogoTerm)).BeginInit();
            this.panelTop.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColumnDel
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle8.NullValue")));
            this.ColumnDel.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnDel.HeaderText = "";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.ReadOnly = true;
            this.ColumnDel.ToolTipText = "Delete Record";
            // 
            // Form
            // 
            this.Form.HeaderText = "Amount";
            this.Form.Name = "Form";
            this.Form.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Details";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnAdminNo
            // 
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ColumnAdminNo.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnAdminNo.HeaderText = "Category";
            this.ColumnAdminNo.Name = "ColumnAdminNo";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gData);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 100);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.panelGrid.Size = new System.Drawing.Size(798, 443);
            this.panelGrid.TabIndex = 4;
            // 
            // gData
            // 
            this.gData.AllowUserToAddRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAdminNo,
            this.ColumnName,
            this.Form,
            this.Class,
            this.ColumnDel});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gData.DefaultCellStyle = dataGridViewCellStyle13;
            this.gData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gData.DoubleBuffered = true;
            this.gData.EnableHeadersVisualStyles = false;
            this.gData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gData.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gData.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.gData.Location = new System.Drawing.Point(20, 10);
            this.gData.MultiSelect = false;
            this.gData.Name = "gData";
            this.gData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gData.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gData.RowHeadersVisible = false;
            this.gData.RowHeadersWidth = 42;
            this.gData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gData.RowTemplate.Height = 40;
            this.gData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gData.Size = new System.Drawing.Size(768, 423);
            this.gData.TabIndex = 1;
            this.gData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gData_CellContentClick);
            this.gData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gData_RowsAdded);
            // 
            // Class
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Class.DefaultCellStyle = dataGridViewCellStyle12;
            this.Class.HeaderText = "Date";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            // 
            // panelTopRght
            // 
            this.panelTopRght.Controls.Add(this.lblYear);
            this.panelTopRght.Controls.Add(this.lblRowCount);
            this.panelTopRght.Controls.Add(this.btnFilter);
            this.panelTopRght.Controls.Add(this.pictureBox1);
            this.panelTopRght.Controls.Add(this.btnAddExpense);
            this.panelTopRght.Controls.Add(this.lblPaid);
            this.panelTopRght.Controls.Add(this.bunifuCustomLabel1);
            this.panelTopRght.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTopRght.Location = new System.Drawing.Point(332, 0);
            this.panelTopRght.Name = "panelTopRght";
            this.panelTopRght.Size = new System.Drawing.Size(466, 100);
            this.panelTopRght.TabIndex = 0;
            // 
            // lblYear
            // 
            this.lblYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.lblYear.ForeColor = System.Drawing.Color.White;
            this.lblYear.Location = new System.Drawing.Point(160, 71);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(72, 17);
            this.lblYear.TabIndex = 79;
            this.lblYear.Text = "Year: 2017";
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.ForeColor = System.Drawing.Color.White;
            this.lblRowCount.Location = new System.Drawing.Point(405, 70);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(16, 18);
            this.lblRowCount.TabIndex = 15;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFilter
            // 
            this.btnFilter.ActiveBorderThickness = 1;
            this.btnFilter.ActiveCornerRadius = 40;
            this.btnFilter.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.btnFilter.ActiveForecolor = System.Drawing.Color.White;
            this.btnFilter.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.btnFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter.BackgroundImage")));
            this.btnFilter.ButtonText = "Filter";
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnFilter.IdleBorderThickness = 1;
            this.btnFilter.IdleCornerRadius = 30;
            this.btnFilter.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(94)))), ((int)(((byte)(135)))));
            this.btnFilter.IdleForecolor = System.Drawing.Color.SeaShell;
            this.btnFilter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.btnFilter.Location = new System.Drawing.Point(256, 27);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(173, 38);
            this.btnFilter.TabIndex = 78;
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(379, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.ActiveBorderThickness = 1;
            this.btnAddExpense.ActiveCornerRadius = 40;
            this.btnAddExpense.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.btnAddExpense.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddExpense.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.btnAddExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.btnAddExpense.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddExpense.BackgroundImage")));
            this.btnAddExpense.ButtonText = "Add Expense";
            this.btnAddExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddExpense.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExpense.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddExpense.IdleBorderThickness = 1;
            this.btnAddExpense.IdleCornerRadius = 30;
            this.btnAddExpense.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(109)))), ((int)(((byte)(99)))));
            this.btnAddExpense.IdleForecolor = System.Drawing.Color.SeaShell;
            this.btnAddExpense.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.btnAddExpense.Location = new System.Drawing.Point(39, 27);
            this.btnAddExpense.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(200, 38);
            this.btnAddExpense.TabIndex = 77;
            this.btnAddExpense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // lblPaid
            // 
            this.lblPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaid.AutoSize = true;
            this.lblPaid.Font = new System.Drawing.Font("Century Gothic", 9.5F);
            this.lblPaid.ForeColor = System.Drawing.Color.White;
            this.lblPaid.Location = new System.Drawing.Point(63, 73);
            this.lblPaid.Name = "lblPaid";
            this.lblPaid.Size = new System.Drawing.Size(47, 17);
            this.lblPaid.TabIndex = 76;
            this.lblPaid.Text = "KES 00";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(16, 74);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(44, 16);
            this.bunifuCustomLabel1.TabIndex = 58;
            this.bunifuCustomLabel1.Text = "Totals :";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblTerm.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblTerm.Location = new System.Drawing.Point(205, 24);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(42, 17);
            this.lblTerm.TabIndex = 56;
            this.lblTerm.Text = "Term: ";
            // 
            // lblT2
            // 
            this.lblT2.AutoSize = true;
            this.lblT2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblT2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblT2.Location = new System.Drawing.Point(253, 24);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(15, 17);
            this.lblT2.TabIndex = 60;
            this.lblT2.Text = "2";
            // 
            // lblT1
            // 
            this.lblT1.AutoSize = true;
            this.lblT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblT1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblT1.Location = new System.Drawing.Point(242, 24);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(15, 17);
            this.lblT1.TabIndex = 59;
            this.lblT1.Text = "1";
            // 
            // lblDateDay
            // 
            this.lblDateDay.AutoSize = true;
            this.lblDateDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblDateDay.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblDateDay.Location = new System.Drawing.Point(205, 49);
            this.lblDateDay.Name = "lblDateDay";
            this.lblDateDay.Size = new System.Drawing.Size(55, 17);
            this.lblDateDay.TabIndex = 58;
            this.lblDateDay.Text = "Tuesday";
            // 
            // lblT3
            // 
            this.lblT3.AutoSize = true;
            this.lblT3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblT3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblT3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblT3.Location = new System.Drawing.Point(263, 24);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(15, 17);
            this.lblT3.TabIndex = 61;
            this.lblT3.Text = "3";
            // 
            // panelTopLeft
            // 
            this.panelTopLeft.AutoSize = true;
            this.panelTopLeft.Controls.Add(this.lblT3);
            this.panelTopLeft.Controls.Add(this.lblT2);
            this.panelTopLeft.Controls.Add(this.lblT1);
            this.panelTopLeft.Controls.Add(this.lblDateDay);
            this.panelTopLeft.Controls.Add(this.lblDateNow);
            this.panelTopLeft.Controls.Add(this.lblTerm);
            this.panelTopLeft.Controls.Add(this.pBoxLogoTerm);
            this.panelTopLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.panelTopLeft.Name = "panelTopLeft";
            this.panelTopLeft.Size = new System.Drawing.Size(297, 100);
            this.panelTopLeft.TabIndex = 55;
            // 
            // lblDateNow
            // 
            this.lblDateNow.AutoSize = true;
            this.lblDateNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblDateNow.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.lblDateNow.Location = new System.Drawing.Point(204, 74);
            this.lblDateNow.Name = "lblDateNow";
            this.lblDateNow.Size = new System.Drawing.Size(90, 16);
            this.lblDateNow.TabIndex = 57;
            this.lblDateNow.Text = "6 October 2017";
            // 
            // pBoxLogoTerm
            // 
            this.pBoxLogoTerm.Image = ((System.Drawing.Image)(resources.GetObject("pBoxLogoTerm.Image")));
            this.pBoxLogoTerm.Location = new System.Drawing.Point(20, 12);
            this.pBoxLogoTerm.Name = "pBoxLogoTerm";
            this.pBoxLogoTerm.Size = new System.Drawing.Size(165, 77);
            this.pBoxLogoTerm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxLogoTerm.TabIndex = 55;
            this.pBoxLogoTerm.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopLeft);
            this.panelTop.Controls.Add(this.panelTopRght);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(798, 100);
            this.panelTop.TabIndex = 1;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.bunifuCards1.Controls.Add(this.panelTop);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(798, 100);
            this.bunifuCards1.TabIndex = 3;
            // 
            // ExpenseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.bunifuCards1);
            this.Name = "ExpenseUI";
            this.Size = new System.Drawing.Size(798, 543);
            this.Load += new System.EventHandler(this.ExpenseUI_Load);
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gData)).EndInit();
            this.panelTopRght.ResumeLayout(false);
            this.panelTopRght.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTopLeft.ResumeLayout(false);
            this.panelTopLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogoTerm)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn ColumnDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdminNo;
        private System.Windows.Forms.Panel panelGrid;
        private Bunifu.Framework.UI.BunifuCustomDataGrid gData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.Panel panelTopRght;
        public Bunifu.Framework.UI.BunifuCustomLabel lblYear;
        private Bunifu.Framework.UI.BunifuCustomLabel lblRowCount;
        private Bunifu.Framework.UI.BunifuThinButton2 btnFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddExpense;
        public Bunifu.Framework.UI.BunifuCustomLabel lblPaid;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTerm;
        private System.Windows.Forms.PictureBox pBoxLogoTerm;
        public Bunifu.Framework.UI.BunifuCustomLabel lblT2;
        public Bunifu.Framework.UI.BunifuCustomLabel lblT1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDateDay;
        public Bunifu.Framework.UI.BunifuCustomLabel lblT3;
        private System.Windows.Forms.Panel panelTopLeft;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDateNow;
        private System.Windows.Forms.Panel panelTop;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
    }
}
