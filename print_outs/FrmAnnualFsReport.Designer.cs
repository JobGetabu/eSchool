namespace print_outs
{
    partial class FrmAnnualFsReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panelRpt = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AnnualFeeStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelRpt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualFeeStructureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRpt
            // 
            this.panelRpt.Controls.Add(this.reportViewer);
            this.panelRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRpt.Location = new System.Drawing.Point(0, 0);
            this.panelRpt.Name = "panelRpt";
            this.panelRpt.Size = new System.Drawing.Size(813, 527);
            this.panelRpt.TabIndex = 0;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "FeeStructureDataSet";
            reportDataSource1.Value = this.AnnualFeeStructureBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "print_outs.MyFeeStructure.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(813, 527);
            this.reportViewer.TabIndex = 1;
            // 
            // AnnualFeeStructureBindingSource
            // 
            this.AnnualFeeStructureBindingSource.DataSource = typeof(eSchool.MyPrints.AnnualFeeStructure);
            // 
            // FrmAnnualFsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 527);
            this.Controls.Add(this.panelRpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAnnualFsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fees Structure";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAnnualFsReport_Load);
            this.panelRpt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnnualFeeStructureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRpt;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource AnnualFeeStructureBindingSource;
    }
}