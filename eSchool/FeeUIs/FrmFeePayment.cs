﻿using custom_alert_notifications;
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

namespace eSchool
{
    public partial class FrmFeePayment : Form
    {
        public FrmFeePayment()
        {
            InitializeComponent();
        }

        private void bunifuFlatCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string selAccount;

        private async void PreparingComboBoxesAsync()
        {
            using (var context = new EschoolEntities())
            {
                var accListAsync = Task.Factory.StartNew(() =>
                {
                    return context.Accounts.ToList();
                });

                foreach (var c in await accListAsync)
                {
                    cbAccount.Items.Add($"{c.Bank}({c.AccNo})");
                }
            }
        }

        private Account FindSelAccount(String account)
        {
            // account = Equity(075465156)
            using (var context = new EschoolEntities())
            {
                var accListAsync = context.Accounts.ToList();

                foreach (var c in accListAsync)
                {
                    string f = ($"{c.Bank}({c.AccNo})");
                    if (account.Equals(f))
                    {
                        return c;
                    }
                }
            }
            return null;
        }
        private void FrmFeePayment_Load(object sender, EventArgs e)
        {
            //UI code
            tbAmount.DisplayIcon = true;
            AutoComplete(tbMOP);
            AutoComplete(tbTerm);
            AutoComplete(tbYear);
            tbAdminNo.Focus();

            PreparingComboBoxesAsync();
        }

        //check if its working
        private void AutoComplete(MetroFramework.Controls.MetroTextBox tb)
        {
            tbForm.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbForm.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            if (tb == tbMOP)
            {
                col.Clear();
                col.Add("Mpesa"); col.Add("Cash"); col.Add("Bank Slip");
                tb.AutoCompleteCustomSource = col;
            }
            else if (tb == tbTerm)
            {
                col.Clear();
                col.Add("1"); col.Add("2"); col.Add("3");
                tb.AutoCompleteCustomSource = col;
            }
            else if (tb == tbTerm)
            {
                col.Clear();
                int y = Properties.Settings.Default.CurrentYear;
                col.Add(1 + y.ToString()); col.Add(y.ToString()); col.Add((y - 1).ToString());
                tb.AutoCompleteCustomSource = col;
            }
        }

       // List<Student_Basic> studentList = null;
        private async Task<List<Student_Basic>> StudListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Student_Basic.ToList();
                }
            });
        }
        private async Task<Student_Basic> StudFoundAsync(int admin)
        {
            var studentList = await StudListAsync();

            foreach (var stud in studentList.Where(a => a.Admin_No == admin))
            {
                if (admin == stud.Admin_No)
                {
                    return stud;
                }
            }
            return null;
        }
        private async Task<SchoolPeriodYear> YearFoundAsync(int year)
        {
            List<SchoolPeriodYear> yearsList = await Task.Factory.StartNew(() =>
             {
                 using (var context = new EschoolEntities())
                 {
                     return context.SchoolPeriodYears.ToList();
                 }
             });

            foreach (var yr in yearsList)
            {
                if (year == yr.Year)
                {
                    return yr;
                }
            }
            return null;
        }

        private async Task<FeesRequiredPerTerm> FeeStructureFoundAsync(int form, int term, int year)
        {
            List<FeesRequiredPerTerm> structList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.FeesRequiredPerTerms.Where(f => f.Form == form & f.Term == term).ToList();
                }
            });

            foreach (var fs in structList)
            {
                if (year == fs.Year)
                {
                    return fs;
                }
            }
            return null;
        }
        private void AmountKeyPressFocusChange(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbTxncode.Focus();
            }
        }
        private void tbTxncode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbMOP.Focus();
            }
        }
        private void MOPKeyPressFocusChange(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cbAccount.Focus();

            }
        }
        private void TermKeyPressFocusChange(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                tbYear.Focus();
            }
        }
        private void YearKeyPressFocusChange(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                bunifuFlatBtnSave.Focus();
            }
        }
        private async void tbAdminNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAdminNo.DisplayIcon = false;
            if (e.KeyChar == (char)13)
            {
                int adminNo = 0;
                if (int.TryParse(this.tbAdminNo.Text, out adminNo))
                {
                    Student_Basic stud = null;
                    stud = await StudFoundAsync(adminNo);
                    if (stud != null)
                    {
                        lblFLName.Text = $"- {stud.First_Name} {stud.Last_Name}";
                        //set up auto complete
                        tbFName.Text = stud.First_Name;
                        tbSName.Text = stud.Middle_Name;
                        tbLName.Text = stud.Last_Name;
                        tbForm.Text = stud.Form.ToString();
                        if (stud.Gender.Equals("M"))
                        {
                            tbGender.Text = "Male";
                        }
                        else
                        {
                            tbGender.Text = "Female";
                        }
                        tbClass.Text = stud.Class;
                        tbTerm.Text = Properties.Settings.Default.CurrentTerm.ToString();
                        tbYear.Text = Properties.Settings.Default.CurrentYear.ToString();
                        tbMOP.Text = "Bank Slip";
                        tbAmount.Focus();
                    }
                    else
                    {
                        if (MetroMessageBox.Show(this, $"No student with the admission number {adminNo} found \n Would you like to save him or her into the database ?", "Search Again", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            FrmAddStudent frm = new FrmAddStudent(stud);
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    tbAdminNo.Icon = GridIcon.Not_Applicable_50px;
                    tbAdminNo.DisplayIcon = true;
                }
            }
        }

        private void SavePayment()
        {
            int adminNo = int.Parse(tbAdminNo.Text);
            int term = int.Parse(tbTerm.Text);
            int form = int.Parse(tbForm.Text);
            int year = int.Parse(tbYear.Text);

            decimal amount = decimal.Parse(tbAmount.Text);
            using (var context = new EschoolEntities())
            {
                Account me = FindSelAccount(selAccount);
                if (me != null)
                {
                    Fee myFee = new Fee
                    {
                        Name = $"{tbFName.Text} {tbSName.Text}",
                        Admin_No = adminNo,
                        Form = form,
                        Class = $"{tbClass.Text}",
                        Date = DateTime.Now,
                        Term = term,
                        Year = year,
                        ModeOfPayment = $"{tbMOP.Text}",
                        Amount_Paid = amount,
                        TransactionCode = $"{tbTxncode.Text}",
                        Acc_Fk = me.Id
                    };


                    me.Amount += amount;

                    context.Entry<Account>(me).State = EntityState.Modified;
                    context.Fees.Add(myFee);

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }

                    #region RegisterTransation

                    //Register this Transaction

                    Transation trans = new Transation()
                    {
                        Type = "Payment",
                        Details = $"Order #200{myFee.FeesId}" + "\n" + $"(Client {tbFName.Text} {tbSName.Text})",
                        Amount = amount,
                        Date = DateTime.Now,
                        Term = term,
                        Year = year,
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
                }
                TransationsUI traUI = TransationsUI.Instance;
                traUI.Global_TransationsUI_Load();
                #endregion

            }
        }
        private async void bunifuFlatBtnSave_Click(object sender, EventArgs e)
        {
            // validate int in tb Term and Year and amount
            // validate existence of a fee structure of the term and year

            if (string.IsNullOrEmpty(tbAmount.Text) | string.IsNullOrEmpty(tbTerm.Text) | string.IsNullOrEmpty(tbYear.Text))
            {
                alert.Show("Required info \n Please fill all required fields !", alert.AlertType.warnig);
                return;
            }

            if (string.IsNullOrEmpty(selAccount))
            {
                alert.Show("Required info \n Select an Account !", alert.AlertType.warnig);
                return;
            }

            decimal test1;
            if (!decimal.TryParse(tbAmount.Text, out test1))
            {
                //MetroMessageBox.Show(this, "Only numeric values  allowed on amount input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert.Show("Only numeric values \n allowed on amount input !", alert.AlertType.error);
                return;
            }
            if (string.IsNullOrEmpty(tbTxncode.Text))
            {
                alert.Show("Required info \n Enter Transaction Code !", alert.AlertType.warnig);
                return;
            }

            if (await IsTxncodeUsed(tbTxncode.Text))
            {
                alert.Show("Duplicate Transaction Code !", alert.AlertType.warnig);
                return;
            }

            int test;
            if (!int.TryParse(tbYear.Text, out test))
            {
                //MetroMessageBox.Show(this, "Only numeric values  allowed on year input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert.Show("Only numeric values  \n  allowed on year input !", alert.AlertType.error);
                return;
            }
            int test2;
            if (!int.TryParse(tbTerm.Text, out test2))
            {
                //MetroMessageBox.Show(this, "Only numeric values  allowed on term input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert.Show("Only numeric values  \n  allowed on term input !", alert.AlertType.error);
                return;
            }
            if (int.Parse(tbTerm.Text) != 1 & int.Parse(tbTerm.Text) != 2 & int.Parse(tbTerm.Text) != 3)
            {
                //MetroMessageBox.Show(this, "Only term 1, 2 or 3 exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                alert.Show("Only term 1, 2 or 3 exist !", alert.AlertType.error);
                return;
            }

            if ((await YearFoundAsync((int.Parse(tbYear.Text)))) == null)
            {
                if (MetroMessageBox.Show(this, $"The year {tbYear.Text} is not registered as a financial year. \n Do you wish to add it as a Financial year", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using (var context = new EschoolEntities())
                    {
                        SchoolPeriodYear spy = new SchoolPeriodYear()
                        {
                            Year = int.Parse(tbYear.Text)
                        };
                        context.SchoolPeriodYears.Add(spy);
                        context.SaveChanges();
                    }
                }
                return;
            }
            var x = await FeeStructureFoundAsync(int.Parse(tbForm.Text), int.Parse(tbTerm.Text), int.Parse(tbYear.Text));
            if (x == null)
            {
                if (MetroMessageBox.Show(this, $"Form {tbForm.Text} Term {tbTerm.Text} {tbYear.Text} lacks a Fees Structure \n Would you wish to make one, before you continue processing the Fee Payment ?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.Close();
                    FeesUI fui = FeesUI.Instance;
                    fui.tab2_Click(sender, e);
                }
                return;
            }

            SavePayment();

            // custom notification
            //MetroMessageBox.Show(this, "Payment Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            alert.Show("Payment Added !", alert.AlertType.success);

            //refresh the fee list grid
            FeePayment fp = FeePayment.Instance;
            fp.GridInitilizer();
            this.Close();
        }

        private async Task<bool> IsTxncodeUsed(string txnCode)
        {
            var feeList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees.ToList();
                }
            });

            foreach (var f in feeList)
            {
                if (f.TransactionCode.Equals(txnCode))
                {
                    return true;
                }
            }
            return false;
        }

        private void FrmFeePayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            //refresh the fee list grid
            FeePayment fp = FeePayment.Instance;
            fp.GridInitilizer();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            selAccount = cbAccount.SelectedItem.ToString();
        }

        

        //ToDo pass some info over to invoices and receipts to enable easier
        //printing of receipts after fee payment.
    }
}

