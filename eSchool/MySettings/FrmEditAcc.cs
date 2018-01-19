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
    public partial class FrmEditAcc : Form
    {

        private int close = 0;
        private Account account;
        private string selAcctype;
        public FrmEditAcc(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void FrmEditAcc_Load(object sender, EventArgs e)
        {
            //UI Code
            SetToolTip(tbAccNo, tbAccNo.WaterMark);
            SetToolTip(tbBankBranch, tbBankBranch.WaterMark);
            SetToolTip(tbBankName, tbBankName.WaterMark);
            SetToolTip(tbAmount, $"{tbAmount.WaterMark} : {account.Amount}");

            switch (account.Type)
            {
                case "Cash":
                    cbSelAccType.SelectedIndex = 0;
                    selAcctype = "Cash";
                    break;
                case "Bank":
                    cbSelAccType.SelectedIndex = 1;
                    selAcctype = "Bank";
                    break;
                case "M-Pesa":
                    cbSelAccType.SelectedIndex = 2;
                    selAcctype = "M-Pesa";
                    break;
                case "Mobile Money":
                    cbSelAccType.SelectedIndex = 3;
                    selAcctype = "Mobile Money";
                    break;
                default:
                    break;
            }

            tbAccNo.Text = account.AccNo;
            tbBankBranch.Text = account.AccName;
            tbBankName.Text = account.Bank;
            tbAmount.Text = $"{String.Format("{0:0,0}", account.Amount)}";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.close = 1;
            this.Close();
        }

        private void btnEditMoney_Click(object sender, EventArgs e)
        {
            this.tbAmount.Enabled = true;
            this.tbAmount.Text = "";
            this.tbAmount.Focus();

        }

        private void FrmEditAcc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (string.IsNullOrEmpty(selAcctype))
            {
                alert.Show("Required info \n Select the Account Type !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbAccNo.Text))
            {
                alert.Show("Required info \n Give some details on Account No !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(tbBankBranch.Text))
            {
                alert.Show("Required info \n Give some details on Account Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(tbBankName.Text))
            {
                alert.Show("Required info \n Give some details on Bank Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            decimal amm;

            if (!decimal.TryParse(tbAmount.Text, out amm))
            {
                alert.Show("Required info \n Only numerical amount !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            using (var context = new EschoolEntities())
            {
                account.Type = selAcctype;
                account.AccName = tbBankBranch.Text;
                account.AccNo = tbAccNo.Text;
                account.Amount = decimal.Parse(tbAmount.Text);
                account.Bank = tbBankName.Text;

                try
                {
                    context.Entry<Account>(account).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                alert.Show("Account Updated !", alert.AlertType.success);
            }
        }

        private void cbSelAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selAcctype = cbSelAccType.SelectedItem.ToString();
        }


        private void SetToolTip(Control ctl, string message)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            //toolTip1.IsBalloon = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(ctl, message);
        }
    }
}
