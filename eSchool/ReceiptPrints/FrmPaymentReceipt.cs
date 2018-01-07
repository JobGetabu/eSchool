using eSchool.MyPrints;
using Microsoft.Reporting.WinForms;
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
        Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[12];

            p[0] = new ReportParameter("schoolName", schoolName);
            p[1] = new ReportParameter("schoolAddress", schoolAddress);
            p[2] = new ReportParameter("schoolCellNo", schoolCell);

            p[3] = new ReportParameter("schoolEmail", schoolEmail);
            p[4] = new ReportParameter("studentName", $"{sDetails.StudentName}");
            p[5] = new ReportParameter("studentReg", $"{sDetails.StudentAdminNo}");
            p[6] = new ReportParameter("feeId", $"{pDetails.FeeId}");
            p[7] = new ReportParameter("status", $"{pDetails.Status}");
            p[8] = new ReportParameter("credit", $"{pDetails.Credit}");
            p[9] = new ReportParameter("balance", $"{pDetails.Balance}");
            p[10] = new ReportParameter("date", $"{dd}");


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
               
            }
            string ff = new Uri(myf).AbsoluteUri;

            p[11] = new ReportParameter("ImagePath", ff);


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
