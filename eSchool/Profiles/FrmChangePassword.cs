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

namespace eSchool.Profiles
{
    public partial class FrmChangePassword : Form
    {
        eUser cUser;
        int close = 0;
        public FrmChangePassword(eUser cUser)
        {
            InitializeComponent();

            this.cUser = cUser;
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }


            string tt = Encode(tbCPassword.Text);
            if (!cUser.Password.Equals(tt))
            {
                alert.Show("Error \n Wrong Password !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbNPassword.Text))
            {
                alert.Show("Required info \n Enter password !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            string ff = Encode(tbNPassword.Text);
            cUser.Password = ff;

            using (var context = new EschoolEntities())
            {
                context.Entry<eUser>(cUser).State = EntityState.Modified;
                try
                {
                    //save edited student
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }

            // short Custom Notification
            alert.Show("Updated", alert.AlertType.success);
            e.Cancel = false;
        }

        private string Encode(String password)
        {
            string encode = "";
            int num = 7;

            for (int i = 0; i < password.Length; i++)
            {
                encode += (char)(password[i] + num);
            }

            return encode;
        }

        private string Decode(string encryptedPass)
        {
            string decode = "";
            int num = 7;

            for (int i = 0; i < encryptedPass.Length; i++)
            {
                decode += (char)(encryptedPass[i] - num);
            }

            return decode;
        }
    }
}
