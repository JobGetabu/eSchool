namespace eSchool
{
    partial class FeeUI_Show
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeUI_Show));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bThinBtnViewAll = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bThinBtnAddFeeItem = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bCDataGridCategory = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.DelImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DelBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overHeadCategoryPerYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.overHeadCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.overHeadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelGrid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bCDataGridCategory)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryPerYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelGrid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelGrid.Controls.Add(this.panel1);
            this.panelGrid.Controls.Add(this.bCDataGridCategory);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelGrid.Location = new System.Drawing.Point(544, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(254, 477);
            this.panelGrid.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bThinBtnViewAll);
            this.panel1.Controls.Add(this.bThinBtnAddFeeItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 429);
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
            this.bThinBtnViewAll.BackColor = System.Drawing.SystemColors.ButtonHighlight;
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
            this.bThinBtnViewAll.Size = new System.Drawing.Size(100, 37);
            this.bThinBtnViewAll.TabIndex = 5;
            this.bThinBtnViewAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bThinBtnAddFeeItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
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
            this.bThinBtnAddFeeItem.Size = new System.Drawing.Size(115, 37);
            this.bThinBtnAddFeeItem.TabIndex = 4;
            this.bThinBtnAddFeeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bThinBtnAddFeeItem.Click += new System.EventHandler(this.bThinBtnAddFeeItem_Click);
            // 
            // bCDataGridCategory
            // 
            this.bCDataGridCategory.AllowUserToAddRows = false;
            this.bCDataGridCategory.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bCDataGridCategory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bCDataGridCategory.AutoGenerateColumns = false;
            this.bCDataGridCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.bCDataGridCategory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.bCDataGridCategory.BackgroundColor = System.Drawing.Color.White;
            this.bCDataGridCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bCDataGridCategory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bCDataGridCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bCDataGridCategory.ColumnHeadersHeight = 30;
            this.bCDataGridCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.overHeadDataGridViewTextBoxColumn,
            this.AssBtn});
            this.bCDataGridCategory.DataSource = this.overHeadCategoryBindingSource;
            this.bCDataGridCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCDataGridCategory.DoubleBuffered = true;
            this.bCDataGridCategory.EnableHeadersVisualStyles = false;
            this.bCDataGridCategory.GridColor = System.Drawing.Color.DimGray;
            this.bCDataGridCategory.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.bCDataGridCategory.HeaderForeColor = System.Drawing.Color.White;
            this.bCDataGridCategory.Location = new System.Drawing.Point(0, 0);
            this.bCDataGridCategory.Name = "bCDataGridCategory";
            this.bCDataGridCategory.ReadOnly = true;
            this.bCDataGridCategory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bCDataGridCategory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bCDataGridCategory.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bCDataGridCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bCDataGridCategory.Size = new System.Drawing.Size(254, 477);
            this.bCDataGridCategory.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuCustomDataGrid1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 477);
            this.panel2.TabIndex = 2;
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.bunifuCustomDataGrid1.AutoGenerateColumns = false;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.OldLace;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.bunifuCustomDataGrid1.ColumnHeadersHeight = 35;
            this.bunifuCustomDataGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.DelImage,
            this.DelBtn});
            this.bunifuCustomDataGrid1.DataSource = this.overHeadCategoryPerYearBindingSource;
            this.bunifuCustomDataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.GridColor = System.Drawing.Color.DimGray;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.ReadOnly = true;
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.bunifuCustomDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(544, 477);
            this.bunifuCustomDataGrid1.TabIndex = 0;
            // 
            // DelImage
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle7.NullValue")));
            this.DelImage.DefaultCellStyle = dataGridViewCellStyle7;
            this.DelImage.HeaderText = "";
            this.DelImage.Image = ((System.Drawing.Image)(resources.GetObject("DelImage.Image")));
            this.DelImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DelImage.Name = "DelImage";
            this.DelImage.ReadOnly = true;
            // 
            // DelBtn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DelBtn.DefaultCellStyle = dataGridViewCellStyle8;
            this.DelBtn.HeaderText = "";
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.ReadOnly = true;
            this.DelBtn.Text = "Delete";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Width = 200;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // overHeadCategoryPerYearBindingSource
            // 
            this.overHeadCategoryPerYearBindingSource.DataSource = typeof(eSchool.OverHeadCategoryPerYear);
            // 
            // overHeadCategoryBindingSource
            // 
            this.overHeadCategoryBindingSource.DataSource = typeof(eSchool.OverHeadCategory);
            // 
            // overHeadDataGridViewTextBoxColumn
            // 
            this.overHeadDataGridViewTextBoxColumn.DataPropertyName = "OverHead";
            this.overHeadDataGridViewTextBoxColumn.HeaderText = "Name";
            this.overHeadDataGridViewTextBoxColumn.Name = "overHeadDataGridViewTextBoxColumn";
            this.overHeadDataGridViewTextBoxColumn.ReadOnly = true;
            this.overHeadDataGridViewTextBoxColumn.Width = 76;
            // 
            // AssBtn
            // 
            this.AssBtn.HeaderText = "";
            this.AssBtn.Name = "AssBtn";
            this.AssBtn.ReadOnly = true;
            this.AssBtn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AssBtn.Text = "Assign Item";
            this.AssBtn.UseColumnTextForButtonValue = true;
            this.AssBtn.Width = 5;
            // 
            // FeeUI_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelGrid);
            this.Name = "FeeUI_Show";
            this.Size = new System.Drawing.Size(798, 477);
            this.Load += new System.EventHandler(this.FeeUI_Show_Load);
            this.panelGrid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bCDataGridCategory)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryPerYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 bThinBtnViewAll;
        private Bunifu.Framework.UI.BunifuThinButton2 bThinBtnAddFeeItem;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bCDataGridCategory;
        private System.Windows.Forms.BindingSource overHeadCategoryBindingSource;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private System.Windows.Forms.BindingSource overHeadCategoryPerYearBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn DelImage;
        private System.Windows.Forms.DataGridViewButtonColumn DelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overHeadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn AssBtn;
    }
}
