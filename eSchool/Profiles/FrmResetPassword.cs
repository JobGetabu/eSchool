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
    public partial class FrmResetPassword : Form
    {
        int close = 0;

        public FrmResetPassword()
        {
            InitializeComponent();
        }

        private void FrmResetPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                alert.Show("Required info \n Enter Username !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(tbNPassword.Text))
            {
                alert.Show("Required info \n Enter password !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (!tbNPassword.Text.Equals(tbCnPassword.Text))
            {
                alert.Show("Passwords Don't Match !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            //look for the user
            eUser xx = UserFoundAsync(tbUserName.Text);
            if (xx==null)
            {
                alert.Show("No user found \n Try again !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            //reset password
            string pss = Encode(tbNPassword.Text);
            using (var context = new EschoolEntities())
            {
                //under auto modification 
                xx.Password = pss;
                context.Entry<eUser>(xx).State = EntityState.Modified;
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
        }

        private eUser UserFoundAsync(string username)
        {
            using (var context = new EschoolEntities())
            {
                var userList = context.eUsers.ToList();

                foreach (var ss in userList.Where(a => a.username.Equals(username.ToUpper())))
                {
                    if (username.ToUpper().Equals(ss.username))
                    {
                        return ss;
                    }
                }
                return null;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
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
    }
}
