namespace eSchool.ReceiptPrints
{
    partial class FrmPaymentReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPaymentReceipt));
            this.PaymentOverheadsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelRpt = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentOverheadsBindingSource)).BeginInit();
            this.panelRpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // PaymentOverheadsBindingSource
            // 
            this.PaymentOverheadsBindingSource.DataSource = typeof(eSchool.ReceiptPrints.PaymentOverheads);
            // 
            // panelRpt
            // 
            this.panelRpt.Controls.Add(this.reportViewer);
            this.panelRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRpt.Location = new System.Drawing.Point(0, 0);
            this.panelRpt.Name = "panelRpt";
            this.panelRpt.Size = new System.Drawing.Size(744, 581);
            this.panelRpt.TabIndex = 1;
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.PaymentOverheadsBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "eSchool.ReceiptPrints.PaymentReceipt.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Padding = new System.Windows.Forms.Padding(10);
            this.reportViewer.PageCountMode = Microsoft.Reporting.WinForms.PageCountMode.Actual;
            this.reportViewer.ShowBackButton = false;
            this.reportViewer.ShowContextMenu = false;
            this.reportViewer.ShowCredentialPrompts = false;
            this.reportViewer.ShowDocumentMapButton = false;
            this.reportViewer.ShowFindControls = false;
            this.reportViewer.Size = new System.Drawing.Size(744, 581);
            this.reportViewer.TabIndex = 0;
            // 
            // FrmPaymentReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 581);
            this.Controls.Add(this.panelRpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPaymentReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Receipt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPaymentReceipt_FormClosing);
            this.Load += new System.EventHandler(this.FrmPaymentReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentOverheadsBindingSource)).EndInit();
            this.panelRpt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRpt;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource PaymentOverheadsBindingSource;
    }
}