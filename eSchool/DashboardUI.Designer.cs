namespace eSchool
{
    partial class DashboardUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardUI));
            this.panelHCD = new System.Windows.Forms.Panel();
            this.panelWColpseBtn = new System.Windows.Forms.Panel();
            this.bunifuImageBtnColapse = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelWithDashDate = new System.Windows.Forms.Panel();
            this.bunifuCustomLabelDashboadTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.home_ui_label = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelHCDCard = new Bunifu.Framework.UI.BunifuCards();
            this.flowPanelBody = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHCD.SuspendLayout();
            this.panelWColpseBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageBtnColapse)).BeginInit();
            this.panelWithDashDate.SuspendLayout();
            this.panelHCDCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHCD
            // 
            this.panelHCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelHCD.Controls.Add(this.panelWColpseBtn);
            this.panelHCD.Controls.Add(this.panelWithDashDate);
            this.panelHCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHCD.Location = new System.Drawing.Point(0, 0);
            this.panelHCD.Name = "panelHCD";
            this.panelHCD.Size = new System.Drawing.Size(798, 96);
            this.panelHCD.TabIndex = 5;
            // 
            // panelWColpseBtn
            // 
            this.panelWColpseBtn.Controls.Add(this.bunifuImageBtnColapse);
            this.panelWColpseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelWColpseBtn.Location = new System.Drawing.Point(702, 0);
            this.panelWColpseBtn.Name = "panelWColpseBtn";
            this.panelWColpseBtn.Size = new System.Drawing.Size(96, 96);
            this.panelWColpseBtn.TabIndex = 1;
            // 
            // bunifuImageBtnColapse
            // 
            this.bunifuImageBtnColapse.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageBtnColapse.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageBtnColapse.Image")));
            this.bunifuImageBtnColapse.ImageActive = null;
            this.bunifuImageBtnColapse.Location = new System.Drawing.Point(30, 31);
            this.bunifuImageBtnColapse.Name = "bunifuImageBtnColapse";
            this.bunifuImageBtnColapse.Size = new System.Drawing.Size(35, 35);
            this.bunifuImageBtnColapse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageBtnColapse.TabIndex = 0;
            this.bunifuImageBtnColapse.TabStop = false;
            this.bunifuImageBtnColapse.Zoom = 10;
            this.bunifuImageBtnColapse.Click += new System.EventHandler(this.bunifuImageBtnColapse_Click_1);
            // 
            // panelWithDashDate
            // 
            this.panelWithDashDate.Controls.Add(this.bunifuCustomLabelDashboadTime);
            this.panelWithDashDate.Controls.Add(this.home_ui_label);
            this.panelWithDashDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelWithDashDate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panelWithDashDate.Location = new System.Drawing.Point(0, 0);
            this.panelWithDashDate.Name = "panelWithDashDate";
            this.panelWithDashDate.Size = new System.Drawing.Size(376, 96);
            this.panelWithDashDate.TabIndex = 0;
            // 
            // bunifuCustomLabelDashboadTime
            // 
            this.bunifuCustomLabelDashboadTime.AutoSize = true;
            this.bunifuCustomLabelDashboadTime.Font = new System.Drawing.Font("Microsoft NeoGothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(5)), true);
            this.bunifuCustomLabelDashboadTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(54)))));
            this.bunifuCustomLabelDashboadTime.Location = new System.Drawing.Point(28, 57);
            this.bunifuCustomLabelDashboadTime.Name = "bunifuCustomLabelDashboadTime";
            this.bunifuCustomLabelDashboadTime.Size = new System.Drawing.Size(93, 19);
            this.bunifuCustomLabelDashboadTime.TabIndex = 1;
            this.bunifuCustomLabelDashboadTime.Text = "October 2017";
            this.bunifuCustomLabelDashboadTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // home_ui_label
            // 
            this.home_ui_label.AutoSize = true;
            this.home_ui_label.Font = new System.Drawing.Font("Microsoft NeoGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(5)), true);
            this.home_ui_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(53)))), ((int)(((byte)(54)))));
            this.home_ui_label.Location = new System.Drawing.Point(26, 16);
            this.home_ui_label.Name = "home_ui_label";
            this.home_ui_label.Size = new System.Drawing.Size(131, 32);
            this.home_ui_label.TabIndex = 0;
            this.home_ui_label.Text = "Dashboard";
            this.home_ui_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHCDCard
            // 
            this.panelHCDCard.BackColor = System.Drawing.Color.Transparent;
            this.panelHCDCard.BorderRadius = 5;
            this.panelHCDCard.BottomSahddow = true;
            this.panelHCDCard.color = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.panelHCDCard.Controls.Add(this.panelHCD);
            this.panelHCDCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHCDCard.LeftSahddow = false;
            this.panelHCDCard.Location = new System.Drawing.Point(0, 0);
            this.panelHCDCard.Name = "panelHCDCard";
            this.panelHCDCard.RightSahddow = false;
            this.panelHCDCard.ShadowDepth = 20;
            this.panelHCDCard.Size = new System.Drawing.Size(798, 96);
            this.panelHCDCard.TabIndex = 6;
            // 
            // flowPanelBody
            // 
            this.flowPanelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.flowPanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelBody.Location = new System.Drawing.Point(0, 96);
            this.flowPanelBody.Name = "flowPanelBody";
            this.flowPanelBody.Size = new System.Drawing.Size(798, 447);
            this.flowPanelBody.TabIndex = 7;
            // 
            // DashboardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPanelBody);
            this.Controls.Add(this.panelHCDCard);
            this.Name = "DashboardUI";
            this.Size = new System.Drawing.Size(798, 543);
            this.Load += new System.EventHandler(this.DashboardUI_Load);
            this.panelHCD.ResumeLayout(false);
            this.panelWColpseBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageBtnColapse)).EndInit();
            this.panelWithDashDate.ResumeLayout(false);
            this.panelWithDashDate.PerformLayout();
            this.panelHCDCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHCD;
        private System.Windows.Forms.Panel panelWColpseBtn;
        private System.Windows.Forms.Panel panelWithDashDate;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabelDashboadTime;
        private Bunifu.Framework.UI.BunifuCustomLabel home_ui_label;
        public Bunifu.Framework.UI.BunifuImageButton bunifuImageBtnColapse;
        private Bunifu.Framework.UI.BunifuCards panelHCDCard;
        private System.Windows.Forms.FlowLayoutPanel flowPanelBody;
    }
}
