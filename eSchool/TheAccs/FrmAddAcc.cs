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

namespace eSchool.TheAccs
{
    public partial class FrmAddAcc : Form
    {
        public FrmAddAcc()
        {
            InitializeComponent();
        }

        private int close;
        private string selAcctype;
        private string bankName;
        private string acName;
        private string acNo;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmAddAcc_Load(object sender, EventArgs e)
        {

        }

        private void FrmAddAcc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (string.IsNullOrEmpty(selAcctype))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select the Account Type !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbAccNo.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Give some details on Account No !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(tbBankBranch.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Give some details on Account Name !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(tbBankName.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Give some details on Bank Name !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            using (var context = new EschoolEntities())
            {
                Account ac = new Account()
                {
                    Type = selAcctype,
                    AccName = tbBankBranch.Text,
                    AccNo = tbAccNo.Text,
                    Amount = 0,
                    Bank = tbBankName.Text
                };

                context.Accounts.Add(ac);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                //TODO custom notification
                MetroMessageBox.Show(this, "Account Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbSelAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selAcctype = cbSelAccType.SelectedItem.ToString();
        }
    }
}
