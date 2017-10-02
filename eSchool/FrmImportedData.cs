using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class FrmImportedData : Form
    {
        DataTable tbl;
        DataSet tblSet;
        public FrmImportedData(DataTable tbl, DataSet tblSet)
        {
            InitializeComponent();
            this.tbl = tbl;
            this.tblSet = tblSet;
        }

        private void metroCBSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bCGridImportData.DataSource =tblSet.Tables[metroCBSheets.SelectedIndex];
        }

        private void FrmImportedData_Load(object sender, EventArgs e)
        {
            foreach (DataTable tbl in tblSet.Tables)
            {
                metroCBSheets.Items.Add(tbl.TableName);
            }

            this.bCGridImportData.DataSource = tbl;
        }

        private void bFClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
