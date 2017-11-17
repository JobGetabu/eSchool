namespace eSchool.Importss
{
    partial class Charts
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.solidGaugeGender = new LiveCharts.WinForms.SolidGauge();
            this.panelchart = new System.Windows.Forms.Panel();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panelt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelchart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelt
            // 
            this.panelt.Controls.Add(this.lblStudents);
            this.panelt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelt.Location = new System.Drawing.Point(0, 0);
            this.panelt.Name = "panelt";
            this.panelt.Size = new System.Drawing.Size(798, 37);
            this.panelt.TabIndex = 0;
            // 
            // lblStudents
            // 
            this.lblStudents.AutoSize = true;
            this.lblStudents.BackColor = System.Drawing.Color.Transparent;
            this.lblStudents.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.lblStudents.Location = new System.Drawing.Point(35, 10);
            this.lblStudents.Name = "lblStudents";
            this.lblStudents.Size = new System.Drawing.Size(146, 19);
            this.lblStudents.TabIndex = 59;
            this.lblStudents.Text = "Students Analytics";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(584, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 370);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.solidGaugeGender);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 370);
            this.panel3.TabIndex = 65;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.bunifuCustomLabel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(214, 19);
            this.panel4.TabIndex = 66;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(120, 3);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(84, 16);
            this.bunifuCustomLabel1.TabIndex = 65;
            this.bunifuCustomLabel1.Text = "Gender M-F";
            // 
            // solidGaugeGender
            // 
            this.solidGaugeGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solidGaugeGender.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solidGaugeGender.Location = new System.Drawing.Point(0, 0);
            this.solidGaugeGender.Name = "solidGaugeGender";
            this.solidGaugeGender.Size = new System.Drawing.Size(214, 370);
            this.solidGaugeGender.TabIndex = 65;
            this.solidGaugeGender.Text = "solidGauge10";
            // 
            // panelchart
            // 
            this.panelchart.Controls.Add(this.pieChart1);
            this.panelchart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelchart.Location = new System.Drawing.Point(0, 37);
            this.panelchart.Name = "panelchart";
            this.panelchart.Size = new System.Drawing.Size(584, 370);
            this.panelchart.TabIndex = 3;
            // 
            // pieChart1
            // 
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart1.Location = new System.Drawing.Point(0, 0);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(584, 370);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Text = "pieChart1";
            // 
            // Charts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panelchart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelt);
            this.Name = "Charts";
            this.Size = new System.Drawing.Size(798, 407);
            this.Load += new System.EventHandler(this.Charts_Load);
            this.panelt.ResumeLayout(false);
            this.panelt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelchart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelt;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel lblStudents;
        private System.Windows.Forms.Panel panelchart;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Panel panel3;
        private LiveCharts.WinForms.SolidGauge solidGaugeGender;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
    }
}
