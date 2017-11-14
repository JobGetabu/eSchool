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

namespace eSchool.ExpenceUIs
{
    public partial class FrmAddExpence : Form
    {
        public FrmAddExpence()
        {
            InitializeComponent();
        }

        private int close;

        private int selYear;
        private int selTerm;
        private decimal amount;
        public string expenseCategory;

        private void FrmAddExpence_Load(object sender, EventArgs e)
        {
            PreparingComboBoxesAsync();
        }
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
                    return context.Categories.Where(x => x.Type.Equals("Expense")).Select(c => c.CategoryName).ToList();
                });

                foreach (var c in await listCatogory)
                {
                    cbCategory.Items.Add(c);
                }
            }
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
            expenseCategory = cbCategory.SelectedItem.ToString();
        }

        private void FrmAddExpence_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
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
                MetroMessageBox.Show(this, "Give some details on expense !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(expenseCategory))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Give some details on expense !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            using (var context = new EschoolEntities())
            {
                Expense expense = new Expense()
                {
                    Details = tbDetails.Text,
                    Amount = amount,
                    Date = DateTime.Now,
                    Term = selTerm,
                    Year = selYear,
                    Category = expenseCategory
                };

                context.Expenses.Add(expense);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }

                //TODO custom notification
                MetroMessageBox.Show(this, "Expense Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #region RegisterTransation

                //Register this Transaction

                Transation trans = new Transation()
                {
                    Type = "Expense",
                    Details = tbDetails.Text + "\n" + $"({expenseCategory})",
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
    }
}
