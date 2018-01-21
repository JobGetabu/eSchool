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

namespace eSchool.TrialBal
{
    public partial class FrmMonthlyTB : Form
    {
        private int selMonth = 0;
        private int selYear = 0;
        private DateTime datePicked;
        private int close = 0;

        //report vars
        string totalIncome, totalExpense, openingBal, closingBal;
        List<ExpenseDetails> expenseDetails = new List<ExpenseDetails>();
        List<IncomeDetails> incomeDetails = new List<IncomeDetails>();
        FrmTrialBalance frmT;

        public FrmMonthlyTB()
        {
            InitializeComponent();

        }

        private void FrmMonthlyTB_Load(object sender, EventArgs e)
        {
            selMonth = DateTime.Now.Month;
            selYear = DateTime.Now.Year;
            datePicked = DateTime.Now;
            DatepickerStart.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMonthlyTB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
            }
           
            //pass yearly data


            e.Cancel = false;


        }

        public async void LauchPrint(IWin32Window t)
        {
            //notification
            alert l = new alert("Please wait...\n Generating Document !", alert.AlertType.success);
            l.Show();
            await Task.Delay(2000);
            l.Close();
            frmT.ShowDialog(t);
        }


        private void DatepickerStart_onValueChanged(object sender, EventArgs e)
        {
            selMonth = DatepickerStart.Value.Month;
            selYear = DatepickerStart.Value.Year;
            datePicked = DatepickerStart.Value;
        }

        private async void btnPrint_Click_1(object sender, EventArgs e)
        {
             await TransCashlbl(datePicked, selYear, true);
            

            TrialDetails tdd = new TrialDetails()
            {
                PeriodText = "Month",
                PeriodValue = $"{selYear} "+datePicked.ToString("MMMM"),
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                OpeningBal = openingBal,
                ClosingBal = closingBal
            };

            frmT = new FrmTrialBalance(tdd, incomeDetails, expenseDetails);
        }

        #region Complexies

        private async Task TransCashlbl(DateTime datePicked, int year, bool filtered)
        {
            int ttt = datePicked.Month;
            #region lbl_income&lbl_expense
            var myIncomes = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Incomes
                    .Where(t => (t.Date.Month == ttt))
                    .ToList();
                }
            });
            decimal totalIncome1 = myIncomes.Where(t => (t.Date.Month == ttt)).Sum(x => x.Amount);

            foreach (var item in myIncomes)
            {
                IncomeDetails inc = new IncomeDetails()
                {
                    IncomeName = item.Category,
                    Amount = item.Amount
                };

                incomeDetails.Add(inc);
            }

            var myFees = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees
                           .Where(t => (t.Date.Month == ttt))
                           .ToList();
                }
            });
            decimal totalFee = myFees
                .Where(t => (t.Date.Month == ttt))
                .Sum(x => x.Amount_Paid);
            IncomeDetails inc1 = new IncomeDetails()
            {
                IncomeName = "Fees",
                Amount = totalFee
            };
            incomeDetails.Add(inc1);

            totalIncome = $"KES {String.Format("{0:0,0}", totalIncome1 + totalFee)}";

            var myExpenses = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Expenses
                    .Where(t => (t.Date.Month == ttt))
                    .ToList();
                }
            });
            decimal totalExpenses1 = myExpenses
                .Where(t => (t.Date.Month == ttt))
                .Sum(x => x.Amount);

            foreach (var item in myExpenses)
            {
                ExpenseDetails exp = new ExpenseDetails()
                {
                    ExpenseName = item.Category,
                    Amount = item.Amount
                };

                expenseDetails.Add(exp);
            }

            totalExpense = $"KES {String.Format("{0:0,0}", totalExpenses1)}";
            #endregion

            #region lbl_opening&lbl_closing_Balance


            ClosingBalance prevClosingBalance = await checkPeriodClosingBal(datePicked.Month, year, filtered);
            decimal openingBal1 = 0;
            if (prevClosingBalance != null)
            {
                openingBal1 = prevClosingBalance.Amount;
            }
            else
            {
                if (Properties.Settings.Default.FirstInstallUse)
                {
                    //Brings mathematical errors
                    //openingBal1 = Properties.Settings.Default.OpeningBalance;
                    //this condition code is not to run again
                    Properties.Settings.Default.FirstInstallUse = false;
                    Properties.Settings.Default.Save();
                }
            }


            openingBal = $"KES {String.Format("{0:0,0}", openingBal1)}";

            decimal closingBal1 = openingBal1 + ((totalIncome1 + totalFee) - totalExpenses1);

            closingBal = $"KES {String.Format("{0:0,0}", closingBal1)}";

            ClosingBalance curClosingBalance = await ThisPeriodClosingBal(datePicked.Month, year, filtered);
            using (var context = new EschoolEntities())
            {

                if (curClosingBalance != null)
                {
                    curClosingBalance.Amount = closingBal1;
                    curClosingBalance.Term = 0;
                    curClosingBalance.Year = year;
                    curClosingBalance.Month = datePicked.Month;

                    context.Entry<ClosingBalance>(curClosingBalance).State = EntityState.Modified;
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "ClosingBalance error");
                    }
                }
                else
                {
                    ClosingBalance newCloseBal = new ClosingBalance()
                    {
                        Amount = closingBal1,
                        Term = 0,
                        Year = year,
                        Month = datePicked.Month
                    };
                    context.ClosingBalances.Add(newCloseBal);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "ClosingBalance error");
                    }
                }
            }
            #endregion
        }


        private async Task<ClosingBalance> ThisPeriodClosingBal(int month, int year, bool fil)
        {
            var myCloseBalListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.ClosingBalances
                    .ToList();
                }
            });

            if (myCloseBalListAsync != null)
            {
                foreach (var item in myCloseBalListAsync.Where(x => x.Month == month & x.Year == year))
                {
                    return item;
                }
            }

            return null;
        }
        private async Task<ClosingBalance> checkPeriodClosingBal(int month, int year, bool fil)
        {
            var myCloseBalListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.ClosingBalances
                    .ToList();
                }
            });

            int checkMonth, checkYear;

            if (month == 1)
            {
                checkYear = year - 1;
                checkMonth = 12;
            }
            else
            {
                checkYear = year;
                checkMonth = month - 1;
            }

            if (myCloseBalListAsync != null)
            {
                var l = myCloseBalListAsync.OrderBy(t => t.Month).Where(t => t.Month == checkMonth & t.Year == checkYear).ToList();
                return l.FirstOrDefault();
            }
            return null;
        }
        #endregion

    }
}
