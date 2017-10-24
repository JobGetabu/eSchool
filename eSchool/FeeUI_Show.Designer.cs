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
            this.panelListControl1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelListControl2 = new System.Windows.Forms.Panel();
            this.bThinBtnAddFeeItem = new Bunifu.Framework.UI.BunifuThinButton2();
            this.overHeadCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.overHeadCategoryPerYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listControl1 = new eSchool.ListControl();
            this.panelListControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryPerYearBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelListControl1
            // 
            this.panelListControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelListControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelListControl1.Controls.Add(this.listControl1);
            this.panelListControl1.Controls.Add(this.panel1);
            this.panelListControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelListControl1.Location = new System.Drawing.Point(490, 0);
            this.panelListControl1.Name = "panelListControl1";
            this.panelListControl1.Size = new System.Drawing.Size(308, 336);
            this.panelListControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.panel1.Controls.Add(this.bThinBtnAddFeeItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 48);
            this.panel1.TabIndex = 1;
            // 
            // panelListControl2
            // 
            this.panelListControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListControl2.Location = new System.Drawing.Point(0, 0);
            this.panelListControl2.Name = "panelListControl2";
            this.panelListControl2.Size = new System.Drawing.Size(490, 336);
            this.panelListControl2.TabIndex = 2;
            // 
            // bThinBtnAddFeeItem
            // 
            this.bThinBtnAddFeeItem.ActiveBorderThickness = 1;
            this.bThinBtnAddFeeItem.ActiveCornerRadius = 20;
            this.bThinBtnAddFeeItem.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.bThinBtnAddFeeItem.ActiveForecolor = System.Drawing.Color.DimGray;
            this.bThinBtnAddFeeItem.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
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
            this.bThinBtnAddFeeItem.Location = new System.Drawing.Point(49, 6);
            this.bThinBtnAddFeeItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bThinBtnAddFeeItem.Name = "bThinBtnAddFeeItem";
            this.bThinBtnAddFeeItem.Size = new System.Drawing.Size(119, 37);
            this.bThinBtnAddFeeItem.TabIndex = 4;
            this.bThinBtnAddFeeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bThinBtnAddFeeItem.Click += new System.EventHandler(this.bThinBtnAddFeeItem_Click);
            // 
            // overHeadCategoryBindingSource
            // 
            this.overHeadCategoryBindingSource.DataSource = typeof(eSchool.OverHeadCategory);
            // 
            // overHeadCategoryPerYearBindingSource
            // 
            this.overHeadCategoryPerYearBindingSource.DataSource = typeof(eSchool.OverHeadCategoryPerYear);
            // 
            // listControl1
            // 
            this.listControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listControl1.Location = new System.Drawing.Point(0, 0);
            this.listControl1.Name = "listControl1";
            this.listControl1.Size = new System.Drawing.Size(308, 288);
            this.listControl1.TabIndex = 2;
            // 
            // FeeUI_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panelListControl2);
            this.Controls.Add(this.panelListControl1);
            this.Name = "FeeUI_Show";
            this.Size = new System.Drawing.Size(798, 336);
            this.Load += new System.EventHandler(this.FeeUI_Show_Load);
            this.panelListControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryPerYearBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelListControl1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 bThinBtnAddFeeItem;
        private System.Windows.Forms.Panel panelListControl2;
        public System.Windows.Forms.BindingSource overHeadCategoryBindingSource;
        public System.Windows.Forms.BindingSource overHeadCategoryPerYearBindingSource;
        private ListControl listControl1;
    }
}
