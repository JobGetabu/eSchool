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

namespace eSchool.MyPrints
{
    public partial class FrmAnnualFsReport : Form
    {
        private String lblFeeStruc;
        List<AnnualFeeStructure> lFeeStruc;

        public FrmAnnualFsReport(string lblFeeStruc, List<AnnualFeeStructure> listFeeStruc)
        {
            InitializeComponent();
            this.lblFeeStruc =lblFeeStruc;
            lFeeStruc = new List<AnnualFeeStructure>();
            this.lFeeStruc = listFeeStruc;
        }
        string schoolName = Properties.Settings.Default.schoolName;
        string schoolMotto = Properties.Settings.Default.schoolMotto;
        string schoolAddress = Properties.Settings.Default.schoolAddress;
        string schoolEmail = Properties.Settings.Default.schoolEmail;
        string schoolCell = Properties.Settings.Default.schoolCell;
        private void FrmAnnualFsReport_Load(object sender, EventArgs e)
        {
            AnnualFeeStructureBindingSource.DataSource = lFeeStruc;
           

            ReportParameter[] p = new ReportParameter[7];
            p[0] = new ReportParameter("schoolName", schoolName);
            p[1] = new ReportParameter("schoolAddress", schoolAddress);
            p[2] = new ReportParameter("schoolCellNo", schoolCell);
            p[3] = new ReportParameter("schoolMotto", schoolMotto);
            p[4] = new ReportParameter("schoolEmail", schoolEmail);
            p[5] = new ReportParameter("formfeeslbl", lblFeeStruc);


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


            p[6] = new ReportParameter("ImagePath", ff);

            this.reportViewer.LocalReport.EnableExternalImages = true;
            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
            
            
        }

        private void FrmAnnualFsReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.reportViewer.RefreshReport();
            this.reportViewer = null;
        }
    }
}
