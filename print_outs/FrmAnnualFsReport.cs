using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace print_outs
{
    public partial class FrmAnnualFsReport : Form
    {
        public FrmAnnualFsReport()
        {
            InitializeComponent();
        }

        private void FrmAnnualFsReport_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
    }
}
