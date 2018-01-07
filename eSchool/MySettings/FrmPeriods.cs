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

namespace eSchool.MySettings
{
    public partial class FrmPeriods : Form
    {
        public FrmPeriods()
        {
            InitializeComponent();
        }

        private int close;
        private int selTerm = 0;
        private void FrmPeriods_Load(object sender, EventArgs e)
        {

        }

        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            selTerm = int.Parse(cbTerm.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmPeriods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (selTerm == 0)
            {
                alert.Show("Required info \n Select Term !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            int test1;
            if (!int.TryParse(tbYear.Text, out test1))
            {
                alert.Show("Only numeric values \n allowed on year input !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (test1 < 1979)
            {
                alert.Show("Invalid year input !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.CurrentTerm = selTerm;
            Properties.Settings.Default.CurrentYear = test1;
            Properties.Settings.Default.Save();

            alert.Show("Updated !", alert.AlertType.success);
            alert.Show("Updated\nRestart to effect changes !", alert.AlertType.success);
            e.Cancel = false;
        }
    }
}
