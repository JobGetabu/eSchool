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

namespace eSchool.TransionX
{
    public partial class FrmFilterTransaction : Form
    {
        public FrmFilterTransaction()
        {
            InitializeComponent();
        }
        private void TabSwitcher(Control UIinstance)
        {
            UIinstance.Visible = false;
            if (!this.container.Controls.Contains(UIinstance))
            {
                UIinstance.Visible = false;
                this.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();

                try
                {
                    this.bunifuTransition1.ShowSync(UIinstance);
                }
                catch (InvalidOperationException)
                {
                    //this exception occurs when the transition is not complete ;(
                }
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.Visible = false;
                try
                {
                    this.bunifuTransition1.ShowSync(UIinstance);
                }
                catch (InvalidOperationException)
                {
                    //this exception occurs when the transition is not complete ;(
                }
                UIinstance.BringToFront();
            }
        }

        private int close;
        public  int selFilYear;
        public  List<int> selFilTerms;
        public  DateTime selDate;
        public  string trmslbl;
        public  bool IsTerms;

        FilterContentDates fcd = new FilterContentDates();
        FilterContentTerms fct = new FilterContentTerms();
        private void Nullify()
        {
            trmslbl = "";
            selFilYear = 0;
            selFilTerms = new List<int>();

            selDate = DateTime.Now;
            IsTerms = false;
        }
        private void FrmFilterTransaction_Load(object sender, EventArgs e)
        {
            Nullify();
            PreparingComboBoxesAsync();
            TabSwitcher(fct);
            IsTerms = true;
        }

        private async void PreparingComboBoxesAsync()
        {
            using (var context = new EschoolEntities())
            {
                var listYear = Task.Factory.StartNew(() =>
                {
                    return context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                });

                cbYear.Items.Clear();
                foreach (var y in await listYear)
                {
                    cbYear.Items.Add(y);
                }
            }
        }


        private void FrmFilterTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            
            selDate = fcd.selDate;
            if (!IsTerms)
            {
                selFilYear = selDate.Year; 
            }

            if (selFilYear == 0)
            {
                //MetroMessageBox.Show(this, "Select a year !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alert.Show("Required info \n Select a year !", alert.AlertType.error);
                e.Cancel = true;
                return;
            }

            
            selFilTerms = fct.selFilTerms;

            if (IsTerms)
            {
                if (selFilTerms.Count == 0)
                {
                    // custom notification
                    //MetroMessageBox.Show(this, "Select at least a form !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    alert.Show("Required info \n Select at least a form !", alert.AlertType.error);
                    e.Cancel = true;
                    return;
                }
            }
        }

        bool _isIt;
        private void btnSwap_Click(object sender, EventArgs e)
        {
            _isIt = !_isIt;

            if (_isIt)
            {
                fcd = new FilterContentDates();
                TabSwitcher(fcd);
                IsTerms = false;           
            }
            else
            {
                fct = new FilterContentTerms();
                TabSwitcher(fct);
                IsTerms = true;
            }
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
    }
}
