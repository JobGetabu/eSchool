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

namespace productActivation
{
    public partial class FrmActivate : Form
    {

        private int close = 0;
        private string _Pass;
       // public bool inTrialMode;


        public FrmActivate(string BaseString,
            string Password, int DaysToEnd, int Runed, string info)
        {
            InitializeComponent();

            tbCompId.Text = BaseString;
            _Pass = Password;

            //lblDays.Text = DaysToEnd.ToString() + " Day(s)";
            //lblTimes.Text = Runed.ToString() + " Time(s)";
            //lblText.Text = info;

            if (DaysToEnd <= 0 || Runed <= 0)
            {
                // trial is finished
                btnCancel.Enabled = false;
            }

            sebPassword.Select();
        }

        private void FrmActivate_Load(object sender, EventArgs e)
        {

        }

        private void FrmActivate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            //check for true key

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.close = 1;
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (_Pass == sebPassword.Text)
            {
                //the software has been purchesed
                alert.Show("Product fully Activated !", alert.AlertType.success);
                this.DialogResult = DialogResult.OK;
                //set the texts in about to activated on dialog result OK

            }
            else
            {
                alert.Show("Product key Incorrect \n Contact Administrator !", alert.AlertType.error);
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.close = 1;
        }
    }
}
