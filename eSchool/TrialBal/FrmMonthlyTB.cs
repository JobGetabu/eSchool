using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TrialBal
{
    public partial class FrmMonthlyTB : Form
    {
        private string frmLbl;    //Select Month
        private string promptCb;  //Select Month
        string periodType; //either Month or Year
        public FrmMonthlyTB(string periodType, bool IsMonthly)
        {
            InitializeComponent();
            this.periodType = periodType;

        }

        private void FrmMonthlyTB_Load(object sender, EventArgs e)
        {
            if (periodType.Equals("Month"))
            {
                lblFrm.Text = "Select Month";
                //process monthly data
                List<string> monthList = new List<string>()
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
            }
            else
            {
                //process yearly data
                PreparingComboBoxesAsync();
            }
        }

        private async void PreparingComboBoxesAsync()
        {
            using (var context = new EschoolEntities())
            {
                var listYear = Task.Factory.StartNew(() =>
                {
                    return context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                });

                foreach (var y in await listYear)
                {
                    cbItem.Items.Add(y);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (periodType.Equals("Month"))
            {
                //pass monthly data

            }
            else
            {
                //pass yearly data
               
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
