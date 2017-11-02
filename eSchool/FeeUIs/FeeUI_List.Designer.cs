namespace eSchool
{
    partial class FeeUI_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeUI_List));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bThinBtnViewAll = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bThinBtnAddFeeItem = new Bunifu.Framework.UI.BunifuThinButton2();
            this.gridCategory = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelListCtl = new System.Windows.Forms.Panel();
            this.listControl1 = new eSchool.ListControl();
            this.panelCreateFeeS = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bunifuCardsHeader = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelGrid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).BeginInit();
            this.panelListCtl.SuspendLayout();
            this.panelCreateFeeS.SuspendLayout();
            this.bunifuCardsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGrid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelGrid.Controls.Add(this.panel1);
            this.panelGrid.Controls.Add(this.gridCategory);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelGrid.Location = new System.Drawing.Point(544, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(254, 336);
            this.panelGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.panel1.Controls.Add(this.bThinBtnViewAll);
            this.panel1.Controls.Add(this.bThinBtnAddFeeItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 48);
            this.panel1.TabIndex = 1;
            // 
            // bThinBtnViewAll
            // 
            this.bThinBtnViewAll.ActiveBorderThickness = 1;
            this.bThinBtnViewAll.ActiveCornerRadius = 20;
            this.bThinBtnViewAll.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.bThinBtnViewAll.ActiveForecolor = System.Drawing.Color.DimGray;
            this.bThinBtnViewAll.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.bThinBtnViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bThinBtnViewAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bThinBtnViewAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bThinBtnViewAll.BackgroundImage")));
            this.bThinBtnViewAll.ButtonText = "View All";
            this.bThinBtnViewAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bThinBtnViewAll.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bThinBtnViewAll.ForeColor = System.Drawing.Color.Gray;
            this.bThinBtnViewAll.IdleBorderThickness = 1;
            this.bThinBtnViewAll.IdleCornerRadius = 20;
            this.bThinBtnViewAll.IdleFillColor = System.Drawing.Color.White;
            this.bThinBtnViewAll.IdleForecolor = System.Drawing.Color.Gray;
            this.bThinBtnViewAll.IdleLineColor = System.Drawing.Color.Gray;
            this.bThinBtnViewAll.Location = new System.Drawing.Point(0, 6);
            this.bThinBtnViewAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bThinBtnViewAll.Name = "bThinBtnViewAll";
            this.bThinBtnViewAll.Size = new System.Drawing.Size(106, 37);
            this.bThinBtnViewAll.TabIndex = 5;
            this.bThinBtnViewAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bThinBtnViewAll.Click += new System.EventHandler(this.bThinBtnViewAll_Click);
            // 
            // bThinBtnAddFeeItem
            // 
            this.bThinBtnAddFeeItem.ActiveBorderThickness = 1;
            this.bThinBtnAddFeeItem.ActiveCornerRadius = 20;
            this.bThinBtnAddFeeItem.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.bThinBtnAddFeeItem.ActiveForecolor = System.Drawing.Color.DimGray;
            this.bThinBtnAddFeeItem.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.bThinBtnAddFeeItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bThinBtnAddFeeItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bThinBtnAddFeeItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bThinBtnAddFeeItem.BackgroundImage")));
            this.bThinBtnAddFeeItem.ButtonText = "Add Fee Item";
            this.bThinBtnAddFeeItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bThinBtnAddFeeItem.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bThinBtnAddFeeItem.ForeColor = System.Drawing.Color.Gray;
            this.bThinBtnAddFeeItem.IdleBorderThickness = 1;
            this.bThinBtnAddFeeItem.IdleCornerRadius = 20;
            this.bThinBtnAddFeeItem.IdleFillColor = System.Drawing.Color.White;
            this.bThinBtnAddFeeItem.IdleForecolor = System.Drawing.Color.Gray;
            this.bThinBtnAddFeeItem.IdleLineColor = System.Drawing.Color.Gray;
            this.bThinBtnAddFeeItem.Location = new System.Drawing.Point(112, 6);
            this.bThinBtnAddFeeItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bThinBtnAddFeeItem.Name = "bThinBtnAddFeeItem";
            this.bThinBtnAddFeeItem.Size = new System.Drawing.Size(117, 37);
            this.bThinBtnAddFeeItem.TabIndex = 4;
            this.bThinBtnAddFeeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bThinBtnAddFeeItem.Click += new System.EventHandler(this.bThinBtnAddFeeItem_Click);
            // 
            // gridCategory
            // 
            this.gridCategory.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCategory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gridCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridCategory.ColumnHeadersHeight = 30;
            this.gridCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPic,
            this.ColumnName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCategory.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCategory.DoubleBuffered = true;
            this.gridCategory.EnableHeadersVisualStyles = false;
            this.gridCategory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gridCategory.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gridCategory.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.gridCategory.Location = new System.Drawing.Point(0, 0);
            this.gridCategory.Name = "gridCategory";
            this.gridCategory.ReadOnly = true;
            this.gridCategory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCategory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridCategory.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCategory.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridCategory.RowTemplate.Height = 40;
            this.gridCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategory.Size = new System.Drawing.Size(254, 336);
            this.gridCategory.TabIndex = 0;
            this.gridCategory.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridCategory_RowsAdded);
            // 
            // ColumnPic
            // 
            this.ColumnPic.FillWeight = 50.76142F;
            this.ColumnPic.HeaderText = "";
            this.ColumnPic.Name = "ColumnPic";
            this.ColumnPic.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.FillWeight = 149.2386F;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // panelListCtl
            // 
            this.panelListCtl.Controls.Add(this.listControl1);
            this.panelListCtl.Controls.Add(this.panelCreateFeeS);
            this.panelListCtl.Controls.Add(this.bunifuCardsHeader);
            this.panelListCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListCtl.Location = new System.Drawing.Point(0, 0);
            this.panelListCtl.Name = "panelListCtl";
            this.panelListCtl.Size = new System.Drawing.Size(544, 336);
            this.panelListCtl.TabIndex = 2;
            // 
            // listControl1
            // 
            this.listControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listControl1.Location = new System.Drawing.Point(0, 39);
            this.listControl1.Name = "listControl1";
            this.listControl1.Size = new System.Drawing.Size(544, 262);
            this.listControl1.TabIndex = 2;
            // 
            // panelCreateFeeS
            // 
            this.panelCreateFeeS.Controls.Add(this.button1);
            this.panelCreateFeeS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCreateFeeS.Location = new System.Drawing.Point(0, 301);
            this.panelCreateFeeS.Name = "panelCreateFeeS";
            this.panelCreateFeeS.Size = new System.Drawing.Size(544, 35);
            this.panelCreateFeeS.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Image = global::eSchool.GridIcon.Plus_Matpx;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(25, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "     Create Fee Structure";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bunifuCardsHeader
            // 
            this.bunifuCardsHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bunifuCardsHeader.BorderRadius = 5;
            this.bunifuCardsHeader.BottomSahddow = true;
            this.bunifuCardsHeader.color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(98)))), ((int)(((byte)(115)))));
            this.bunifuCardsHeader.Controls.Add(this.bunifuCustomLabel3);
            this.bunifuCardsHeader.Controls.Add(this.bunifuCustomLabel2);
            this.bunifuCardsHeader.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuCardsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCardsHeader.LeftSahddow = false;
            this.bunifuCardsHeader.Location = new System.Drawing.Point(0, 0);
            this.bunifuCardsHeader.Name = "bunifuCardsHeader";
            this.bunifuCardsHeader.RightSahddow = true;
            this.bunifuCardsHeader.ShadowDepth = 20;
            this.bunifuCardsHeader.Size = new System.Drawing.Size(544, 39);
            this.bunifuCardsHeader.TabIndex = 0;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(387, 14);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(34, 15);
            this.bunifuCustomLabel3.TabIndex = 3;
            this.bunifuCustomLabel3.Text = "Total";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(187, 14);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(48, 15);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "Session";
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(60, 14);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(32, 15);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Title";
            // 
            // FeeUI_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panelListCtl);
            this.Controls.Add(this.panelGrid);
            this.Name = "FeeUI_List";
            this.Size = new System.Drawing.Size(798, 336);
            this.Load += new System.EventHandler(this.FeeUI_List_Load);
            this.panelGrid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategory)).EndInit();
            this.panelListCtl.ResumeLayout(false);
            this.panelCreateFeeS.ResumeLayout(false);
            this.bunifuCardsHeader.ResumeLayout(false);
            this.bunifuCardsHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 bThinBtnViewAll;
        private Bunifu.Framework.UI.BunifuThinButton2 bThinBtnAddFeeItem;
        private Bunifu.Framework.UI.BunifuCustomDataGrid gridCategory;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.Panel panelListCtl;
        private System.Windows.Forms.Panel panelCreateFeeS;
        private System.Windows.Forms.Button button1;
        private Bunifu.Framework.UI.BunifuCards bunifuCardsHeader;
        private ListControl listControl1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}
