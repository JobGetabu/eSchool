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

            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
          {
                new Microsoft.Reporting.WinForms.ReportParameter("schoolName",schoolName),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolAddress",schoolAddress),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolCellNo",schoolCell),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolEmail",schoolEmail),
                  new Microsoft.Reporting.WinForms.ReportParameter("periodText",$"{trialDetails.PeriodText}"),
                   new Microsoft.Reporting.WinForms.ReportParameter("periodValue",$"{trialDetails.PeriodValue}"),

                    new Microsoft.Reporting.WinForms.ReportParameter("openingBal",$"{trialDetails.OpeningBal}"),
                     new Microsoft.Reporting.WinForms.ReportParameter("closingBal",$"{trialDetails.ClosingBal}"),
                      new Microsoft.Reporting.WinForms.ReportParameter("totalIncome",$"{trialDetails.TotalIncome}"),
                       new Microsoft.Reporting.WinForms.ReportParameter("totalExpense",$"{trialDetails.TotalExpense}")
          };

            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
        }

        private void SetImage(Microsoft.Reporting.WinForms.ReportParameter[] p,int index)
        {
            reportViewer.LocalReport.EnableExternalImages = true;

            string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
            string myf = tt + ".\\Output.jpg";
            if ((File.Exists(myf)))
            {
                p[index] = new Microsoft.Reporting.WinForms.ReportParameter("ImagePath", myf);
            }
            if ((File.Exists(".\\school2.jpg")))
            {
                p[index] = new Microsoft.Reporting.WinForms.ReportParameter("ImagePath", ".\\school2.jpg");
            }
        }
    }
}