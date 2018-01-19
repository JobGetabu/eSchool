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


namespace eSchool.TrialBal
{
    public partial class FrmTrialBalance : Form
    {

        TrialDetails trialDetails;
        List<IncomeDetails> incomeDetails;
        List<ExpenseDetails> expenseDetails;
        public FrmTrialBalance()
        {
            InitializeComponent();
        }
        public FrmTrialBalance(TrialDetails trialDetails, List<IncomeDetails> incomeDetails, List<ExpenseDetails> expenseDetails)
        {
            InitializeComponent();

            this.trialDetails = trialDetails;
            this.incomeDetails = incomeDetails;
            this.expenseDetails = expenseDetails;
        }

        string schoolName = Properties.Settings.Default.schoolName;
        string schoolAddress = Properties.Settings.Default.schoolAddress;
        string schoolEmail = Properties.Settings.Default.schoolEmail;
        string schoolCell = Properties.Settings.Default.schoolCell;

        private void FrmTrialBalance_Load(object sender, EventArgs e)
        {
            this.ExpenseDetailsBindingSource.DataSource = expenseDetails;
            this.IncomeDetailsBindingSource.DataSource = incomeDetails;

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[11];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("schoolName", schoolName);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("schoolAddress", schoolAddress);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("schoolCellNo", schoolCell);
            p[3] = new Microsoft.Reporting.WinForms.ReportParameter("schoolEmail", schoolEmail);
            p[4] = new Microsoft.Reporting.WinForms.ReportParameter("periodText", $"{trialDetails.PeriodText}");
            p[5] = new Microsoft.Reporting.WinForms.ReportParameter("periodValue", $"{trialDetails.PeriodValue}");

            p[6] = new Microsoft.Reporting.WinForms.ReportParameter("openingBal", $"{trialDetails.OpeningBal}");
            p[7] = new Microsoft.Reporting.WinForms.ReportParameter("closingBal", $"{trialDetails.ClosingBal}");
            p[8] = new Microsoft.Reporting.WinForms.ReportParameter("totalIncome", $"{trialDetails.TotalIncome}");
            p[9] = new Microsoft.Reporting.WinForms.ReportParameter("totalExpense", $"{trialDetails.TotalExpense}");


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


            p[10] = new Microsoft.Reporting.WinForms.ReportParameter("ImagePath", ff);

            this.reportViewer.LocalReport.EnableExternalImages = true;
            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
        }
    }
}