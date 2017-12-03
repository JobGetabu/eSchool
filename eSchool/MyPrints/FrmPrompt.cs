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

namespace eSchool.MyPrints
{
    public partial class FrmPrompt : Form
    {
        public FrmPrompt()
        {
            InitializeComponent();
            Nullify();
        }

        private int close;
        public  int selFilYear;
        public  int selFilForm;
        public string frmlbl;
        private void Nullify()
        {
            selFilForm = 0;
            selFilYear = 0;
            
        }
        private void FrmPrompt_Load(object sender, EventArgs e)
        {
            PreparingComboBoxesAsync();
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

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilYear = int.Parse(cbYear.SelectedItem.ToString());
        }

        private void cbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilForm = int.Parse(cbForm.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (selFilYear == 0)
            {
                alert.Show("Required info \n Select a year !", alert.AlertType.error);
                e.Cancel = true;
                return;
            }
            if (selFilForm == 0)
            {
                alert.Show("Required info \n Select a form !", alert.AlertType.error);
                e.Cancel = true;
                return;
            }

            switch (selFilForm)
            {
                case 1:
                    frmlbl = "One";
                    break;
                case 2:
                    frmlbl = "Two";
                    break;
                case 3:
                    frmlbl = "Three";
                    break;
                case 4:
                    frmlbl = "Four";
                    break;
                default:
                    break;
            }

            e.Cancel = false;
        }
    }
}
