namespace eSchool.TrialBal
{
    partial class FrmTrialBalance
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrialBalance));
            this.panelRpt = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.IncomeDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExpenseDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelRpt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IncomeDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRpt
            // 
            this.panelRpt.Controls.Add(this.reportViewer);
            this.panelRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRpt.Location = new System.Drawing.Point(0, 0);
            this.panelRpt.Name = "panelRpt";
            this.panelRpt.Size = new System.Drawing.Size(812, 542);
            this.panelRpt.TabIndex = 2;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.IncomeDetailsBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.ExpenseDetailsBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "eSchool.TrialBal.TrialBalance.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Padding = new System.Windows.Forms.Padding(10);
            this.reportViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer.ShowBackButton = false;
            this.reportViewer.ShowContextMenu = false;
            this.reportViewer.ShowCredentialPrompts = false;
            this.reportViewer.ShowDocumentMapButton = false;
            this.reportViewer.ShowFindControls = false;
            this.reportViewer.Size = new System.Drawing.Size(812, 542);
            this.reportViewer.TabIndex = 0;
            // 
            // IncomeDetailsBindingSource
            // 
            this.IncomeDetailsBindingSource.DataSource = typeof(eSchool.TrialBal.IncomeDetails);
            // 
            // ExpenseDetailsBindingSource
            // 
            this.ExpenseDetailsBindingSource.DataSource = typeof(eSchool.TrialBal.ExpenseDetails);
            // 
            // FrmTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 542);
            this.Controls.Add(this.panelRpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTrialBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trial Balance";
            this.Load += new System.EventHandler(this.FrmTrialBalance_Load);
            this.panelRpt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IncomeDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRpt;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource IncomeDetailsBindingSource;
        private System.Windows.Forms.BindingSource ExpenseDetailsBindingSource;
    }
}