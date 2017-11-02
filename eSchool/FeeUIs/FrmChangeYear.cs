using MetroFramework;
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
    public partial class FrmChangeYear : Form
    {
        public static int selChangeYear;
        private int close;
        public FrmChangeYear()
        {
            InitializeComponent();
        }

        private void FrmChangeYear_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                var listYear = context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                foreach (var y in listYear)
                {
                    cBYear.Items.Add(y);
                }
            }
            //int count = (Properties.Settings.Default.CurrentYear);
            //cBYear.Items.Add(Properties.Settings.Default.CurrentYear + 1);
            //cBYear.Items.Add(Properties.Settings.Default.CurrentYear);
            ////go down 5 yrs from current and up one
            //for (int i = 0; i < 5; i++)
            //{
            //    cBYear.Items.Add(count -= 1);
            //}
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void cBYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selChangeYear = (int)this.cBYear.SelectedItem;
        }

        private void FrmChangeYear_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }
            if (selChangeYear == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select a year", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            else
            {
                //label change
                FeesStructure feeIns = FeesStructure.Instance;
                feeIns.lblYFeeStructure.Text = $"{selChangeYear} Fees Structures";//2017 Fees Structures
                feeIns.lblFFeeStructure.Text = "";
                feeIns.lblTFeeStructure.Text = "";
                feeIns.lblTotalFeeStructure.Text = "";
                e.Cancel = false;
            }
        }
    }
}
