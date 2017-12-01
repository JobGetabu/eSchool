using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.MyPrints
{
    public partial class FrmAnnualFsReport : Form
    {
        AnnualFeeStructure FeeStruc;
        List<AnnualFeeStructure> lFeeStruc;
        public FrmAnnualFsReport(AnnualFeeStructure FeeStruc, List<AnnualFeeStructure> listFeeStruc)
        {
            InitializeComponent();
            this.FeeStruc = FeeStruc;
            lFeeStruc = new List<AnnualFeeStructure>();
            this.lFeeStruc = listFeeStruc;
        }

        private void FrmAnnualFsReport_Load(object sender, EventArgs e)
        {
            AnnualFeeStructureBindingSource.DataSource = lFeeStruc;
     
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("schoolName","Test Secondary School"),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolAddress","P.O BOX 1234-234 NYERI"),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolCellNo","CELL NO: +1212121211"),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolMotto","Born to serve"),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolEmail","Test@eschoolKe.com"),
                new Microsoft.Reporting.WinForms.ReportParameter("formfeeslbl","Test Form Four Fees Structure"),
                 new Microsoft.Reporting.WinForms.ReportParameter("schoolLogo","//image url")
                //table data from list
            };

            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
            
        }
    }
}
