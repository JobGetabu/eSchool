using custom_alert_notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Profiles
{
    public partial class FrmEditUserN : Form
    {
        eUser cUser;
        public string userN;
        public FrmEditUserN(eUser cUser)
        {
            InitializeComponent();

            this.cUser = cUser;
        }

        private void FrmEditUserN_Load(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var tt = textInfo.ToTitleCase(cUser.username);
            tbFullName.Text = tt;
        }

        private void FrmEditUserN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFullName.Text))
            {
                alert.Show("Required info \n Enter Username !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            userN = tbFullName.Text;
        }
    }
}
