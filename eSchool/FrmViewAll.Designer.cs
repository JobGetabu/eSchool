namespace eSchool
{
    partial class FrmViewAll
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewAll));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panelBtm = new System.Windows.Forms.Panel();
            this.bThinBtnAddFeeItem = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panelgrid = new System.Windows.Forms.Panel();
            this.bGrid = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.overhead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelBtm.SuspendLayout();
            this.bunifuCards1.SuspendLayout();
            this.panelgrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bGrid)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panelBtm
            // 
            this.panelBtm.AutoSize = true;
            this.panelBtm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelBtm.Controls.Add(this.bThinBtnAddFeeItem);
            this.panelBtm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBtm.Location = new System.Drawing.Point(0, 298);
            this.panelBtm.Name = "panelBtm";
            this.panelBtm.Size = new System.Drawing.Size(798, 38);
            this.panelBtm.TabIndex = 1;
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
            this.bThinBtnAddFeeItem.Location = new System.Drawing.Point(12, 0);
            this.bThinBtnAddFeeItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bThinBtnAddFeeItem.Name = "bThinBtnAddFeeItem";
            this.bThinBtnAddFeeItem.Size = new System.Drawing.Size(117, 37);
            this.bThinBtnAddFeeItem.TabIndex = 5;
            this.bThinBtnAddFeeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bThinBtnAddFeeItem.Click += new System.EventHandler(this.bThinBtnAddFeeItem_Click);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(98)))), ((int)(((byte)(115)))));
            this.bunifuCards1.Controls.Add(this.bunifuGradientPanel1);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(798, 57);
            this.bunifuCards1.TabIndex = 3;
            // 
            // panelgrid
            // 
            this.panelgrid.Controls.Add(this.bGrid);
            this.panelgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelgrid.Location = new System.Drawing.Point(0, 57);
            this.panelgrid.Name = "panelgrid";
            this.panelgrid.Size = new System.Drawing.Size(798, 241);
            this.panelgrid.TabIndex = 4;
            // 
            // bGrid
            // 
            this.bGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.bGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.bGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPic,
            this.overhead,
            this.Del});
            this.bGrid.DoubleBuffered = true;
            this.bGrid.EnableHeadersVisualStyles = false;
            this.bGrid.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bGrid.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.bGrid.Location = new System.Drawing.Point(12, 6);
            this.bGrid.Name = "bGrid";
            this.bGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bGrid.RowHeadersVisible = false;
            this.bGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bGrid.Size = new System.Drawing.Size(783, 229);
            this.bGrid.TabIndex = 1;
            this.bGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bGrid_CellContentClick);
            this.bGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.bGrid_RowsAdded);
            // 
            // ColumnPic
            // 
            this.ColumnPic.HeaderText = "";
            this.ColumnPic.Name = "ColumnPic";
            this.ColumnPic.ReadOnly = true;
            // 
            // overhead
            // 
            this.overhead.HeaderText = "Name";
            this.overhead.Name = "overhead";
            this.overhead.ReadOnly = true;
            // 
            // Del
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle6.NullValue")));
            this.Del.DefaultCellStyle = dataGridViewCellStyle6;
            this.Del.HeaderText = "";
            this.Del.Name = "Del";
            this.Del.ToolTipText = "Delete Record";
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuImageButton1);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox2);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 5);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(798, 49);
            this.bunifuGradientPanel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(68, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(97, 12);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(192, 25);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "OverHead Fee Items";
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(758, 10);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(28, 28);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 5;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // FrmViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(798, 336);
            this.Controls.Add(this.panelgrid);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.panelBtm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmViewAll";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View All";
            this.Load += new System.EventHandler(this.FrmViewAll_Load);
            this.panelBtm.ResumeLayout(false);
            this.bunifuCards1.ResumeLayout(false);
            this.panelgrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bGrid)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelBtm;
        private Bunifu.Framework.UI.BunifuThinButton2 bThinBtnAddFeeItem;
        private System.Windows.Forms.Panel panelgrid;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        public Bunifu.Framework.UI.BunifuCustomDataGrid bGrid;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn overhead;
        private System.Windows.Forms.DataGridViewImageColumn Del;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
    }
}