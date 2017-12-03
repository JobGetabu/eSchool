﻿using System;
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
     
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("schoolName",schoolName),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolAddress",schoolAddress),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolCellNo",schoolCell),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolMotto",schoolMotto),
                new Microsoft.Reporting.WinForms.ReportParameter("schoolEmail",schoolEmail),
                new Microsoft.Reporting.WinForms.ReportParameter("formfeeslbl",lblFeeStruc),
                 new Microsoft.Reporting.WinForms.ReportParameter("schoolLogo","school2")
                //table data from list
            };

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