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

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[12];

            p[0] = new ReportParameter("schoolName", schoolName);
            p[1] = new ReportParameter("schoolAddress", schoolAddress);
            p[2] = new ReportParameter("schoolCellNo", schoolCell);
            p[3] = new ReportParameter("schoolEmail", schoolEmail);
            p[4] = new ReportParameter("periodText", $"{trialDetails.PeriodText}");
            p[6] = new ReportParameter("periodValue", $"{trialDetails.PeriodValue}");

            p[7] = new ReportParameter("openingBal", $"{trialDetails.OpeningBal}");
            p[8] = new ReportParameter("closingBal", $"{trialDetails.ClosingBal}");
            p[9] = new ReportParameter("totalIncome", $"{trialDetails.TotalIncome}");
            p[10] = new ReportParameter("totalExpense", $"{trialDetails.TotalExpense}");


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


            p[11] = new ReportParameter("ImagePath", ff);

            reportViewer.LocalReport.EnableExternalImages = true;
            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
        }
    }
}