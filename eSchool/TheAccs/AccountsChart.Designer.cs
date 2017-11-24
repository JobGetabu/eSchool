namespace eSchool.TheAccs
{
    partial class AccountsChart
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
            this.panelt = new System.Windows.Forms.Panel();
            this.lblStudents = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panelt.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelt
            // 
            this.panelt.Controls.Add(this.lblStudents);
            this.panelt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelt.Location = new System.Drawing.Point(0, 0);
            this.panelt.Name = "panelt";
            this.panelt.Size = new System.Drawing.Size(798, 37);
            this.panelt.TabIndex = 1;
            // 
            // lblStudents
            // 
            this.lblStudents.AutoSize = true;
            this.lblStudents.BackColor = System.Drawing.Color.Transparent;
            this.lblStudents.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblStudents.Location = new System.Drawing.Point(35, 10);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(155, 19);
            this.lblStudents.TabIndex = 59;
            this.lblStudents.Text = "Accounts Analytics";
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(0, 37);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(798, 370);
            this.pieChart1.TabIndex = 2;
            this.pieChart1.Text = "pieChart1";
            // 
            // AccountsChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.panelt);
            this.Name = "AccountsChart";
            this.Size = new System.Drawing.Size(798, 407);
            this.Load += new System.EventHandler(this.AccountsChart_Load);
            this.panelt.ResumeLayout(false);
            this.panelt.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelt;
        private Bunifu.Framework.UI.BunifuCustomLabel lblStudents;
        private LiveCharts.WinForms.PieChart pieChart1;
    }
}
