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
    public partial class FrmAddSchool : Form
    {
        private int close = 0;
        private string mofL = "";
        public FrmAddSchool()
        {
            InitializeComponent();
        }

        private void FrmAddSchool_Load(object sender, EventArgs e)
        {
            tbAddress.Text = Properties.Settings.Default.schoolAddress;
            tbCell.Text = Properties.Settings.Default.schoolCell;
            tbEmail.Text = Properties.Settings.Default.schoolEmail;
            tbMotto.Text = Properties.Settings.Default.schoolMotto;
            tbName.Text = Properties.Settings.Default.schoolName;
            tbSchoolCode.Text = Properties.Settings.Default.schoolreg;

            MofLearn();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void Verifying(FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSchoolCode.Text))
            {
                alert.Show("Required info \n Input School Code !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                alert.Show("Required info \n Input School Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbMotto.Text))
            {
                alert.Show("Required info \n Input School Motto !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                alert.Show("Required info \n Input School Email !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbCell.Text))
            {
                alert.Show("Required info \n Input School Cell !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                alert.Show("Required info \n Input School Address !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(mofL))
            {
                alert.Show("Required info \n Select Mode of Learning!", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
        }
        private void FrmAddSchool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            Verifying(e);

            Properties.Settings.Default.schoolAddress = tbAddress.Text;
            Properties.Settings.Default.schoolCell = tbCell.Text;
            Properties.Settings.Default.schoolEmail = tbEmail.Text;
            Properties.Settings.Default.schoolMotto = tbMotto.Text;
            Properties.Settings.Default.schoolName = tbName.Text;
            Properties.Settings.Default.schoolreg = tbSchoolCode.Text;
            Properties.Settings.Default.schoolType = mofL;

            Properties.Settings.Default.Save();


            alert.Show("Updated !", alert.AlertType.success);
            e.Cancel = false;
        }

        private void cbMofLearn_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             *Boarding School
              Day School
              Day - Bording School 
             */
            mofL = cbMofLearn.SelectedItem.ToString();
        }

        private void MofLearn()
        {
            if (Properties.Settings.Default.schoolType.Equals("Boarding School"))
            {
                cbMofLearn.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.schoolType.Equals("Day School"))
            {
                cbMofLearn.SelectedIndex = 1;
            }
            if (Properties.Settings.Default.schoolType.Equals("Day - Bording School"))
            {
                cbMofLearn.SelectedIndex = 2;
            }
        }
    }
}
