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

namespace eSchool.IncomeUIs
{
    public partial class FrmAddIncome : Form
    {
        public FrmAddIncome()
        {
            InitializeComponent();
        }

        private int close;

        private int selYear;
        private int selTerm;
        private decimal amount;
        private string incomeCategory;
        private string selAccount;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
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

                cbTerm.Items.Add(1);
                cbTerm.Items.Add(2);
                cbTerm.Items.Add(3);

                var listCatogory = Task.Factory.StartNew(() =>
                {
                    return context.Categories.Where(x => x.Type.Equals("Income")).Select(c => c.CategoryName).ToList();
                });

                foreach (var c in await listCatogory)
                {
                    cbCategory.Items.Add(c);
                }

                var accListAsync = Task.Factory.StartNew(() =>
                {
                    return context.Accounts.ToList();
                });

                foreach (var c in await accListAsync)
                {
                    cbAccount.Items.Add($"{c.AccName}({c.AccNo})");
                }
            }
        }

        private Account FindSelAccount(String account)
        {
            // account = Equity(075465156)
            using (var context = new EschoolEntities())
            {
                var accListAsync =  context.Accounts.ToList();
              
                foreach (var c in accListAsync)
                {
                    string f= ($"{c.AccName}({c.AccNo})");
                    if (account.Equals(f))
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        private void FrmAddIncome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (string.IsNullOrEmpty(selAccount))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select an Account !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (selYear == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select a year !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (selTerm == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select a term !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbDetails.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Give some details on income !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(incomeCategory))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Give some details on income !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbAmount.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Enter amount !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            decimal test1;
            if (!decimal.TryParse(tbAmount.Text, out test1))
            {
                MetroMessageBox.Show(this, "Only numeric values  allowed on amount input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
            amount = test1;


            using (var context =new EschoolEntities())
            {
                Account me = FindSelAccount(selAccount);
                if (me != null)
                {
                    Income income = new Income()
                    {
                        Details = tbDetails.Text,
                        Amount = amount,
                        Date = DateTime.Now,
                        Term = selTerm,
                        Year = selYear,
                        Category = incomeCategory,
                        Acc_Fk = me.Id
                    };


                    me.Amount += amount;

                    context.Entry<Account>(me).State = EntityState.Modified;
                    context.Incomes.Add(income);
                }
                try
                {
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                //TODO custom notification
                MetroMessageBox.Show(this, "Income Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region RegisterTransation

                //Register this Transaction

                Transation trans = new Transation()
                {
                    Type = "Income",
                    Details = tbDetails.Text + "\n" + $"({incomeCategory})",
                    Amount = amount,
                    Date = DateTime.Now,
                    Term = selTerm,
                    Year = selYear,
                };

                context.Transations.Add(trans);
                try
                {
                    trans.TransactionNo = "300" + trans.Id;
                    context.SaveChanges();
                    trans.TransactionNo = "300" + +trans.Id;
                    context.Entry<Transation>(trans).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                TransationsUI traUI = TransationsUI.Instance;
                traUI.Global_TransationsUI_Load();
                #endregion


                e.Cancel = false;              
            }
        }


        private void FrmAddIncome_Load(object sender, EventArgs e)
        {
            PreparingComboBoxesAsync();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selYear = int.Parse(cbYear.SelectedItem.ToString());
        }

        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            selTerm = int.Parse(cbTerm.SelectedItem.ToString());
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            incomeCategory = cbCategory.SelectedItem.ToString();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            selAccount = cbAccount.SelectedItem.ToString();
        }
    }
}
