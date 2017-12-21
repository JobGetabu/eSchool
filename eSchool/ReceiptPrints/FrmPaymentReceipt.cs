using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.ReceiptPrints
{
    public partial class FrmPaymentReceipt : Form
    {
        List<PaymentOverheads> listPayOv = new List<PaymentOverheads>();
        PaymentDetails pDetails;
        StudentDetails sDetails;

        public FrmPaymentReceipt(List<PaymentOverheads> listPayOv, PaymentDetails pDetails, StudentDetails sDetails)
        {
            InitializeComponent();
            this.listPayOv = listPayOv;
            this.pDetails = pDetails;
            this.sDetails = sDetails;
        }

        string schoolName = Properties.Settings.Default.schoolName;
        string schoolAddress = Properties.Settings.Default.schoolAddress;
        string schoolEmail = Properties.Settings.Default.schoolEmail;
        string schoolCell = Properties.Settings.Default.schoolCell;

        private void FrmPaymentReceipt_Load(object sender, EventArgs e)
        {
            PaymentOverheadsBindingSource.DataSource = listPayOv;
            string dd = DateTime.Now.ToShortDateString();
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
           {
                new Microsoft.Reporting.WinForms.ReportParameter("schoolName",schoolName),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolAddress",schoolAddress),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolCellNo",schoolCell),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolEmail",schoolEmail),
                 new Microsoft.Reporting.WinForms.ReportParameter("schoolLogo","school2"),
                  new Microsoft.Reporting.WinForms.ReportParameter("studentName",$"{sDetails.StudentName}"),
                   new Microsoft.Reporting.WinForms.ReportParameter("studentReg",$"{sDetails.StudentAdminNo}"),

                    new Microsoft.Reporting.WinForms.ReportParameter("feeId",$"{pDetails.FeeId}"),
                     new Microsoft.Reporting.WinForms.ReportParameter("status",$"{pDetails.Status}"),
                      new Microsoft.Reporting.WinForms.ReportParameter("credit",$"{pDetails.Credit}"),
                       new Microsoft.Reporting.WinForms.ReportParameter("balance",$"{pDetails.Balance}"),
                       new Microsoft.Reporting.WinForms.ReportParameter("date",$"{dd}")
           };

            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
        }

        private void FrmPaymentReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.reportViewer.RefreshReport();
            this.reportViewer = null;
        }
    }
}
