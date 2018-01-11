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
    public partial class FrmEditUser : Form
    {
        eUser cUser;
        string type;
        int close = 0;
        public FrmEditUser(eUser cUser)
        {
            InitializeComponent();
            this.cUser = cUser;
        }

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            tbUserName.Text = cUser.username;
            tbOccupation.Text = cUser.Occupation;
            tbFullName.Text = cUser.FullName;
            tbEmail.Text = cUser.Email;
            tbCell.Text = cUser.Phone;
            CheckType(cUser.Type);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = cbType.SelectedItem.ToString();
        }

        private void CheckType(string type)
        {
            foreach (var item in cbType.Items)
            {
                if (type.Equals(item))
                {
                    cbType.SelectedItem = item;
                    type = item.ToString();
                }
            }
        }

        private void FrmEditUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close==1)
            {
                e.Cancel = false;
                return;
            }
            if (string.IsNullOrEmpty(tbFullName.Text))
            {
                alert.Show("Required info \n Enter Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                alert.Show("Required info \n Enter Username !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                alert.Show("Required info \n Enter Email !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(type))
            {
                alert.Show("Required info \n Select UserType !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }


            //save changes
            cUser.FullName = tbFullName.Text;
            cUser.Email = tbEmail.Text;
            cUser.Occupation = tbOccupation.Text;
            cUser.Phone = tbCell.Text;
            cUser.username = tbUserName.Text;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }
    }
}
