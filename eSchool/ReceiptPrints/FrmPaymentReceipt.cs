using eSchool.MyPrints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string dd = "Receipt Date: " + DateTime.Now.ToShortDateString();
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[13];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("schoolName", schoolName);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("schoolAddress", schoolAddress);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("schoolCellNo", schoolCell);

            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("schoolEmail", schoolEmail);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("studentName", $"{sDetails.StudentName}");
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("studentReg", $"{sDetails.StudentAdminNo}");
            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("feeId", $"{pDetails.FeeId}");
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("status", $"{pDetails.Status}");
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("credit", $"{pDetails.Credit}");
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("balance", $"{pDetails.Balance}");
            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("date", $"{dd}");


            PrintsLogo printsLogo = new PrintsLogo();
            printsLogo.ImgPath = "";
            string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
            string myf = tt + ".\\Output.jpg";
            if ((File.Exists(myf)))
            {
                //path
                printsLogo.ImgPath = myf;
            }
            else
            {
                //TODO else default image
                myf = tt + ".\\school2.jpg";
                printsLogo.ImgPath = myf;
            }
            string ff = new Uri(myf).AbsoluteUri;

            try
            {
                p[11] = new Microsoft.Reporting.WinForms.ReportParameter("ImagePath", ff);
            }
            catch (Exception) { }
            p[12] = new Microsoft.Reporting.WinForms.ReportParameter("payDetails", $"{pDetails.PayDetails}");

            this.reportViewer.LocalReport.EnableExternalImages = true;
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
