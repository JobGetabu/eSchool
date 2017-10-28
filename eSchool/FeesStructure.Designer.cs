namespace eSchool
{
    partial class FeesStructure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeesStructure));
            this.panelHCD = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bTBtnChangeYear = new Bunifu.Framework.UI.BunifuThinButton2();
            this.bMenu = new Bunifu.Framework.UI.BunifuDropdown();
            this.panelWithDashDate = new System.Windows.Forms.Panel();
            this.lblTFeeStructure = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblFFeeStructure = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblYFeeStructure = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.container = new System.Windows.Forms.Panel();
            this.panelHCD.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelWithDashDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHCD
            // 
            this.panelHCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.panelHCD.Controls.Add(this.panel2);
            this.panelHCD.Controls.Add(this.panelWithDashDate);
            this.panelHCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHCD.Location = new System.Drawing.Point(0, 0);
            this.panelHCD.Name = "panelHCD";
            this.panelHCD.Size = new System.Drawing.Size(798, 71);
            this.panelHCD.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bTBtnChangeYear);
            this.panel2.Controls.Add(this.bMenu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(437, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 71);
            this.panel2.TabIndex = 1;
            // 
            // bTBtnChangeYear
            // 
            this.bTBtnChangeYear.ActiveBorderThickness = 1;
            this.bTBtnChangeYear.ActiveCornerRadius = 40;
            this.bTBtnChangeYear.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.bTBtnChangeYear.ActiveForecolor = System.Drawing.Color.White;
            this.bTBtnChangeYear.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.bTBtnChangeYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bTBtnChangeYear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bTBtnChangeYear.BackgroundImage")));
            this.bTBtnChangeYear.ButtonText = "Change Year";
            this.bTBtnChangeYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bTBtnChangeYear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTBtnChangeYear.ForeColor = System.Drawing.Color.SeaGreen;
            this.bTBtnChangeYear.IdleBorderThickness = 1;
            this.bTBtnChangeYear.IdleCornerRadius = 30;
            this.bTBtnChangeYear.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(94)))), ((int)(((byte)(135)))));
            this.bTBtnChangeYear.IdleForecolor = System.Drawing.Color.SeaShell;
            this.bTBtnChangeYear.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.bTBtnChangeYear.Location = new System.Drawing.Point(7, 17);
            this.bTBtnChangeYear.Margin = new System.Windows.Forms.Padding(5);
            this.bTBtnChangeYear.Name = "bTBtnChangeYear";
            this.bTBtnChangeYear.Size = new System.Drawing.Size(164, 39);
            this.bTBtnChangeYear.TabIndex = 10;
            this.bTBtnChangeYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bTBtnChangeYear.Click += new System.EventHandler(this.bTBtnChangeYear_Click);
            // 
            // bMenu
            // 
            this.bMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bMenu.BackColor = System.Drawing.Color.Transparent;
            this.bMenu.BorderRadius = 40;
            this.bMenu.DisabledColor = System.Drawing.Color.Gray;
            this.bMenu.ForeColor = System.Drawing.Color.White;
            this.bMenu.Items = new string[0];
            this.bMenu.Location = new System.Drawing.Point(179, 17);
            this.bMenu.Name = "bMenu";
            this.bMenu.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(109)))), ((int)(((byte)(99)))));
            this.bMenu.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.bMenu.selectedIndex = -1;
            this.bMenu.Size = new System.Drawing.Size(179, 33);
            this.bMenu.TabIndex = 4;
            this.bMenu.onItemSelected += new System.EventHandler(this.bMenu_onItemSelected_1);
            // 
            // panelWithDashDate
            // 
            this.panelWithDashDate.AutoSize = true;
            this.panelWithDashDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelWithDashDate.Controls.Add(this.lblTFeeStructure);
            this.panelWithDashDate.Controls.Add(this.lblFFeeStructure);
            this.panelWithDashDate.Controls.Add(this.pictureBox1);
            this.panelWithDashDate.Controls.Add(this.lblYFeeStructure);
            this.panelWithDashDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelWithDashDate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panelWithDashDate.Location = new System.Drawing.Point(0, 0);
            this.panelWithDashDate.Name = "panelWithDashDate";
            this.panelWithDashDate.Size = new System.Drawing.Size(248, 71);
            this.panelWithDashDate.TabIndex = 0;
            // 
            // lblTFeeStructure
            // 
            this.lblTFeeStructure.AutoSize = true;
            this.lblTFeeStructure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFeeStructure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(54)))));
            this.lblTFeeStructure.Location = new System.Drawing.Point(144, 53);
            this.lblTFeeStructure.Name = "lblTFeeStructure";
            this.lblTFeeStructure.Size = new System.Drawing.Size(0, 13);
            this.lblTFeeStructure.TabIndex = 3;
            this.lblTFeeStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFFeeStructure
            // 
            this.lblFFeeStructure.AutoSize = true;
            this.lblFFeeStructure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFFeeStructure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(54)))));
            this.lblFFeeStructure.Location = new System.Drawing.Point(69, 53);
            this.lblFFeeStructure.Name = "lblFFeeStructure";
            this.lblFFeeStructure.Size = new System.Drawing.Size(0, 13);
            this.lblFFeeStructure.TabIndex = 2;
            this.lblFFeeStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblYFeeStructure
            // 
            this.lblYFeeStructure.AutoSize = true;
            this.lblYFeeStructure.Font = new System.Drawing.Font("Segoe UI Semilight", 14F);
            this.lblYFeeStructure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(54)))));
            this.lblYFeeStructure.Location = new System.Drawing.Point(69, 23);
            this.lblYFeeStructure.Name = "lblYFeeStructure";
            this.lblYFeeStructure.Size = new System.Drawing.Size(176, 25);
            this.lblYFeeStructure.TabIndex = 0;
            this.lblYFeeStructure.Text = "2017 Fees Structures";
            this.lblYFeeStructure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(98)))), ((int)(((byte)(115)))));
            this.bunifuCards1.Controls.Add(this.panelHCD);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(798, 71);
            this.bunifuCards1.TabIndex = 9;
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 71);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(798, 336);
            this.container.TabIndex = 10;
            // 
            // FeesStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.container);
            this.Controls.Add(this.bunifuCards1);
            this.Name = "FeesStructure";
            this.Size = new System.Drawing.Size(798, 407);
            this.Load += new System.EventHandler(this.FeesStructure_Load);
            this.panelHCD.ResumeLayout(false);
            this.panelHCD.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelWithDashDate.ResumeLayout(false);
            this.panelWithDashDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHCD;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelWithDashDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Bunifu.Framework.UI.BunifuCustomLabel lblYFeeStructure;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private Bunifu.Framework.UI.BunifuThinButton2 bTBtnChangeYear;
        public System.Windows.Forms.Panel container;
        public Bunifu.Framework.UI.BunifuCustomLabel lblFFeeStructure;
        public Bunifu.Framework.UI.BunifuCustomLabel lblTFeeStructure;
        public Bunifu.Framework.UI.BunifuDropdown bMenu;
    }
}
