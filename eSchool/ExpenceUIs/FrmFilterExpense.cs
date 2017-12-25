using custom_alert_notifications;
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

namespace eSchool.ExpenceUIs
{
    public partial class FrmFilterExpense : Form
    {
        public FrmFilterExpense()
        {
            InitializeComponent();
            Nullify();
        }

        private int close;
        public static int selFilYear;
        public static List<int> selFilTerms;
        public static string trmslbl;
        private void Nullify()
        {
            trmslbl = "";
            selFilYear = 0;
            selFilTerms = new List<int>();
        }

        private void ListInit()
        {
            selFilTerms.Clear();
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

        private void lblSetter(string tag, bool value)
        {
            if (value)
            {
                if (trmslbl.Contains(tag))
                {
                    trmslbl.Replace(tag, "");
                }
            }
            else
            {
                if (!trmslbl.Contains(tag))
                {
                    trmslbl.Replace(tag, "");
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

        private void FrmFilterExpense_Load(object sender, EventArgs e)
        {
            PreparingComboBoxesAsync();
            ListInit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilYear = int.Parse(cbYear.SelectedItem.ToString());
        }

        private void FrmFilterExpense_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (selFilYear == 0)
            {
                //MetroMessageBox.Show(this, "Select a year !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alert.Show("Required info \n Select a year !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (switch1.Value & switch2.Value & switch3.Value)
            {
                ListInit();
            }

            if (selFilTerms.Count == 0)
            {
                // custom notification
                //MetroMessageBox.Show(this, "Select at least a form !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                alert.Show("Required info \n Select at least a term !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            //change term labels
            ExpenseUI inui = ExpenseUI.Instance;
            inui.lblT1.Text = "";
            inui.lblT2.Text = "";
            inui.lblT3.Text = "";
            e.Cancel = false;
        }
    }
}
