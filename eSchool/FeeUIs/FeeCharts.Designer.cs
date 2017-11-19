namespace eSchool.FeeUIs
{
    partial class FeeCharts
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
            this.paneTop = new System.Windows.Forms.Panel();
            this.lblYear = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTerm = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.paneTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneTop
            // 
            this.paneTop.Controls.Add(this.lblYear);
            this.paneTop.Controls.Add(this.lblTerm);
            this.paneTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneTop.Location = new System.Drawing.Point(0, 0);
            this.paneTop.Name = "paneTop";
            this.paneTop.Size = new System.Drawing.Size(798, 44);
            this.paneTop.TabIndex = 0;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblYear.Location = new System.Drawing.Point(736, 13);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(40, 17);
            this.lblYear.TabIndex = 59;
            this.lblYear.Text = "2020";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblTerm.Location = new System.Drawing.Point(37, 13);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(151, 17);
            this.lblTerm.TabIndex = 12;
            this.lblTerm.Text = "Fee Payment Analytics";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cartesianChart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 363);
            this.panel1.TabIndex = 1;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(0, 0);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(798, 363);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // FeeCharts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paneTop);
            this.Name = "FeeCharts";
            this.Size = new System.Drawing.Size(798, 407);
            this.Load += new System.EventHandler(this.FeeCharts_Load);
            this.paneTop.ResumeLayout(false);
            this.paneTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneTop;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTerm;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblYear;
    }
}
