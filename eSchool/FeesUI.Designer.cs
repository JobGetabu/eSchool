namespace eSchool
{
    partial class FeesUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeesUI));
            this.panelHCD = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bMenu = new Bunifu.Framework.UI.BunifuDropdown();
            this.bTBtnChangeYear = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panelWithDashDate = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCFeeStructure = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.overHeadCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.container = new System.Windows.Forms.Panel();
            this.panelHCD.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelWithDashDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHCD
            // 
            this.panelHCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelHCD.Controls.Add(this.panel2);
            this.panelHCD.Controls.Add(this.panelWithDashDate);
            this.panelHCD.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHCD.Location = new System.Drawing.Point(0, 0);
            this.panelHCD.Name = "panelHCD";
            this.panelHCD.Size = new System.Drawing.Size(798, 66);
            this.panelHCD.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bMenu);
            this.panel2.Controls.Add(this.bTBtnChangeYear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(466, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 66);
            this.panel2.TabIndex = 1;
            // 
            // bMenu
            // 
            this.bMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bMenu.BackColor = System.Drawing.Color.Transparent;
            this.bMenu.BorderRadius = 7;
            this.bMenu.DisabledColor = System.Drawing.Color.Gray;
            this.bMenu.ForeColor = System.Drawing.Color.White;
            this.bMenu.Items = new string[0];
            this.bMenu.Location = new System.Drawing.Point(161, 16);
            this.bMenu.Name = "bMenu";
            this.bMenu.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bMenu.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bMenu.selectedIndex = -1;
            this.bMenu.Size = new System.Drawing.Size(165, 35);
            this.bMenu.TabIndex = 4;
            this.bMenu.onItemSelected += new System.EventHandler(this.bMenu_onItemSelected);
            // 
            // bTBtnChangeYear
            // 
            this.bTBtnChangeYear.ActiveBorderThickness = 1;
            this.bTBtnChangeYear.ActiveCornerRadius = 20;
            this.bTBtnChangeYear.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bTBtnChangeYear.ActiveForecolor = System.Drawing.Color.White;
            this.bTBtnChangeYear.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bTBtnChangeYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bTBtnChangeYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.bTBtnChangeYear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bTBtnChangeYear.BackgroundImage")));
            this.bTBtnChangeYear.ButtonText = "Change Year";
            this.bTBtnChangeYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTBtnChangeYear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTBtnChangeYear.ForeColor = System.Drawing.Color.SeaGreen;
            this.bTBtnChangeYear.IdleBorderThickness = 1;
            this.bTBtnChangeYear.IdleCornerRadius = 20;
            this.bTBtnChangeYear.IdleFillColor = System.Drawing.Color.White;
            this.bTBtnChangeYear.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bTBtnChangeYear.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bTBtnChangeYear.Location = new System.Drawing.Point(7, 10);
            this.bTBtnChangeYear.Margin = new System.Windows.Forms.Padding(5);
            this.bTBtnChangeYear.Name = "bTBtnChangeYear";
            this.bTBtnChangeYear.Size = new System.Drawing.Size(146, 46);
            this.bTBtnChangeYear.TabIndex = 3;
            this.bTBtnChangeYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelWithDashDate
            // 
            this.panelWithDashDate.AutoSize = true;
            this.panelWithDashDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelWithDashDate.Controls.Add(this.pictureBox1);
            this.panelWithDashDate.Controls.Add(this.lblCFeeStructure);
            this.panelWithDashDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelWithDashDate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panelWithDashDate.Location = new System.Drawing.Point(0, 0);
            this.panelWithDashDate.Name = "panelWithDashDate";
            this.panelWithDashDate.Size = new System.Drawing.Size(248, 66);
            this.panelWithDashDate.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblCFeeStructure
            // 
            this.lblCFeeStructure.AutoSize = true;
            this.lblCFeeStructure.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblCFeeStructure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(54)))));
            this.lblCFeeStructure.Location = new System.Drawing.Point(69, 23);
            this.lblCFeeStructure.Name = "lblCFeeStructure";
            this.lblCFeeStructure.Size = new System.Drawing.Size(176, 25);
            this.lblCFeeStructure.TabIndex = 0;
            this.lblCFeeStructure.Text = "2017 Fees Structures";
            this.lblCFeeStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // overHeadCategoryBindingSource
            // 
            this.overHeadCategoryBindingSource.DataSource = typeof(eSchool.OverHeadCategory);
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 66);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(798, 477);
            this.container.TabIndex = 7;
            // 
            // FeesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.container);
            this.Controls.Add(this.panelHCD);
            this.Name = "FeesUI";
            this.Size = new System.Drawing.Size(798, 543);
            this.Load += new System.EventHandler(this.FeesUI_Load);
            this.panelHCD.ResumeLayout(false);
            this.panelHCD.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelWithDashDate.ResumeLayout(false);
            this.panelWithDashDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overHeadCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHCD;
        private System.Windows.Forms.Panel panelWithDashDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource overHeadCategoryBindingSource;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuDropdown bMenu;
        private Bunifu.Framework.UI.BunifuThinButton2 bTBtnChangeYear;
        public System.Windows.Forms.Panel container;
        public Bunifu.Framework.UI.BunifuCustomLabel lblCFeeStructure;
    }
}
