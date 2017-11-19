namespace eSchool.Dash
{
    partial class MoneyOverview
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
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelExpense = new System.Windows.Forms.Panel();
            this.panelIncome = new System.Windows.Forms.Panel();
            this.panelBal = new System.Windows.Forms.Panel();
            this.ovalPictureBox1 = new eSchool.OvalPictureBox();
            this.bunifuCards1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelBal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 7;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCards1.Controls.Add(this.tableLayoutPanel1);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(418, 180);
            this.bunifuCards1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelStatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelExpense, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelIncome, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelBal, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 180);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelStatus
            // 
            this.panelStatus.Location = new System.Drawing.Point(212, 93);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(200, 78);
            this.panelStatus.TabIndex = 3;
            // 
            // panelExpense
            // 
            this.panelExpense.Location = new System.Drawing.Point(4, 93);
            this.panelExpense.Name = "panelExpense";
            this.panelExpense.Size = new System.Drawing.Size(200, 78);
            this.panelExpense.TabIndex = 2;
            // 
            // panelIncome
            // 
            this.panelIncome.Location = new System.Drawing.Point(212, 4);
            this.panelIncome.Name = "panelIncome";
            this.panelIncome.Size = new System.Drawing.Size(200, 78);
            this.panelIncome.TabIndex = 1;
            // 
            // panelBal
            // 
            this.panelBal.Controls.Add(this.ovalPictureBox1);
            this.panelBal.Location = new System.Drawing.Point(4, 4);
            this.panelBal.Name = "panelBal";
            this.panelBal.Size = new System.Drawing.Size(200, 82);
            this.panelBal.TabIndex = 0;
            // 
            // ovalPictureBox1
            // 
            this.ovalPictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.ovalPictureBox1.Location = new System.Drawing.Point(15, 13);
            this.ovalPictureBox1.Name = "ovalPictureBox1";
            this.ovalPictureBox1.Size = new System.Drawing.Size(80, 40);
            this.ovalPictureBox1.TabIndex = 0;
            this.ovalPictureBox1.TabStop = false;
            // 
            // MoneyOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.bunifuCards1);
            this.Name = "MoneyOverview";
            this.Size = new System.Drawing.Size(418, 180);
            this.bunifuCards1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelBal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Panel panelExpense;
        private System.Windows.Forms.Panel panelIncome;
        private System.Windows.Forms.Panel panelBal;
        private OvalPictureBox ovalPictureBox1;
    }
}
