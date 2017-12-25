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
    public partial class FrmTermlyTB : Form
    {
        private List<int> selFilTerms;
        private int selYear = 0;
        public FrmTermlyTB()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTermlyTB_Load(object sender, EventArgs e)
        {
            PreparingComboBoxesAsync();
            ListInit();
        }

        private void ListInit()
        {
            selFilTerms = new List<int>();
            selFilTerms.Add(1); selFilTerms.Add(2); selFilTerms.Add(3);
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
                    cbYear.Items.Add(y);
                }
            }
        }

        private void Switch_OnValueChange(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuiOSSwitch sw = sender as Bunifu.Framework.UI.BunifuiOSSwitch;
            if (sw.Value)
            {
                selFilTerms.Add(int.Parse(sw.Tag.ToString()));
            }
            else
            {
                selFilTerms.Remove(int.Parse(sw.Tag.ToString()));
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selYear = int.Parse(cbYear.SelectedItem.ToString());
        }

        private void FrmTermlyTB_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (selYear == 0)
            {
                alert.Show("Required info \n Select a year !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (switch1.Value & switch2.Value & switch3.Value)
            {
                ListInit();
            }

            if (selFilTerms.Count == -1)
            {
                alert.Show("Required info \n Select at least a term !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            //load the print


            e.Cancel = false;
        }
    }
}
