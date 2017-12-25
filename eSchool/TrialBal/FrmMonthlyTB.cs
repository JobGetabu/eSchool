using custom_alert_notifications;
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
        string periodType; //either Month or Year
        private string selMonth;
        private int selYear=0;

        public FrmMonthlyTB(string periodType)
        {
            InitializeComponent();
            this.periodType = periodType;

        }

        private void FrmMonthlyTB_Load(object sender, EventArgs e)
        {
            if (periodType.Equals("Month"))
            {
                lblFrm.Text = "Select Month";
                cbItem.PromptText = "Select Month";
                //process monthly data
                String[] monthList = new string[]
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
                cbItem.Items.Clear();
                cbItem.Items.AddRange(monthList);
            }
            else
            {
                lblFrm.Text = "Select Year";
                cbItem.PromptText = "Select Year";
                PreparingComboBoxesAsync();
                //process yearly data
            }
        }

        private async void PreparingComboBoxesAsync()
        {
            cbItem.Items.Clear();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            selMonth = cbItem.SelectedItem.ToString();
            if (periodType.Equals("Year"))
            {
                selYear = int.Parse(cbItem.SelectedItem.ToString());
            }
        }

        private void FrmMonthlyTB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (periodType.Equals("Month"))
            {
                if (String.IsNullOrEmpty(selMonth))
                {
                    alert.Show("Required info \n Select month !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                //pass monthly data

                e.Cancel = false;
            }
            else
            {
                if (selYear == 0)
                {
                    alert.Show("Required info \n Select year !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                //pass yearly data
                e.Cancel = false;
            }

        }
    }
}
