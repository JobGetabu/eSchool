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

            //this.moneyOverview1 = new eSchool.Dash.MoneyOverview();
            //this.receiptOverview1 = new eSchool.Dash.ReceiptOverview();
            //this.transOverview1 = new eSchool.Dash.TransOverview();
            //this.monthlyOverview1 = new eSchool.Dash.MonthlyOverview();
            //this.termlyOverview1 = new eSchool.Dash.TermlyOverview();

            this.moneyOverview1 = eSchool.Dash.MoneyOverview.Instance;
            this.receiptOverview1 =  eSchool.Dash.ReceiptOverview.Instance; ;
            this.transOverview1 =  eSchool.Dash.TransOverview.Instance; ;
            this.monthlyOverview1 = eSchool.Dash.MonthlyOverview.Instance; ;
            this.termlyOverview1 = eSchool.Dash.TermlyOverview.Instance; ;

            this.panelHCD.SuspendLayout();
            this.panelWColpseBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageBtnColapse)).BeginInit();
            this.panelWithDashDate.SuspendLayout();
            this.panelHCDCard.SuspendLayout();
            this.flowPanelBody.SuspendLayout();
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
            this.panelHCD.Size = new System.Drawing.Size(798, 93);
            this.panelHCD.TabIndex = 5;
            // 
            // panelWColpseBtn
            // 
            this.panelWColpseBtn.Controls.Add(this.bunifuImageBtnColapse);
            this.panelWColpseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelWColpseBtn.Location = new System.Drawing.Point(702, 0);
            this.panelWColpseBtn.Name = "panelWColpseBtn";
            this.panelWColpseBtn.Size = new System.Drawing.Size(96, 93);
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
            this.panelWithDashDate.Size = new System.Drawing.Size(376, 93);
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
            this.panelHCDCard.Size = new System.Drawing.Size(798, 93);
            this.panelHCDCard.TabIndex = 6;
            // 
            // flowPanelBody
            // 
            this.flowPanelBody.AutoScroll = true;
            this.flowPanelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.flowPanelBody.Controls.Add(this.moneyOverview1);
            this.flowPanelBody.Controls.Add(this.receiptOverview1);
            this.flowPanelBody.Controls.Add(this.transOverview1);
            this.flowPanelBody.Controls.Add(this.monthlyOverview1);
            this.flowPanelBody.Controls.Add(this.termlyOverview1);
            this.flowPanelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelBody.Location = new System.Drawing.Point(0, 93);
            this.flowPanelBody.Name = "flowPanelBody";
            this.flowPanelBody.Padding = new System.Windows.Forms.Padding(5);
            this.flowPanelBody.Size = new System.Drawing.Size(798, 450);
            this.flowPanelBody.TabIndex = 7;
            // 
            // moneyOverview1
            // 
            this.moneyOverview1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.moneyOverview1.Location = new System.Drawing.Point(8, 8);
            this.moneyOverview1.Name = "moneyOverview1";
            this.moneyOverview1.Size = new System.Drawing.Size(356, 144);
            this.moneyOverview1.TabIndex = 0;
            // 
            // receiptOverview1
            // 
            this.receiptOverview1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.receiptOverview1.Location = new System.Drawing.Point(370, 8);
            this.receiptOverview1.Name = "receiptOverview1";
            this.receiptOverview1.Size = new System.Drawing.Size(209, 144);
            this.receiptOverview1.TabIndex = 1;
            // 
            // transOverview1
            // 
            this.transOverview1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.transOverview1.Location = new System.Drawing.Point(585, 8);
            this.transOverview1.Name = "transOverview1";
            this.transOverview1.Size = new System.Drawing.Size(203, 144);
            this.transOverview1.TabIndex = 2;
            // 
            // monthlyOverview1
            // 
            this.monthlyOverview1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.monthlyOverview1.Location = new System.Drawing.Point(8, 158);
            this.monthlyOverview1.Name = "monthlyOverview1";
            this.monthlyOverview1.Size = new System.Drawing.Size(356, 289);
            this.monthlyOverview1.TabIndex = 3;
            // 
            // termlyOverview1
            // 
            this.termlyOverview1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.termlyOverview1.Location = new System.Drawing.Point(370, 158);
            this.termlyOverview1.Name = "termlyOverview1";
            this.termlyOverview1.Size = new System.Drawing.Size(418, 289);
            this.termlyOverview1.TabIndex = 4;
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
            this.flowPanelBody.ResumeLayout(false);
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
        public Dash.MoneyOverview moneyOverview1;
        public Dash.ReceiptOverview receiptOverview1;
        public Dash.TransOverview transOverview1;
        public Dash.MonthlyOverview monthlyOverview1;
        public Dash.TermlyOverview termlyOverview1;
    }
}
