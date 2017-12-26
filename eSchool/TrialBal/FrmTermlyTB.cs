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
    public partial class FrmTermlyTB : Form
    {
        private List<int> selFilTerms = new List<int>();
        private int selYear = 0;
        private int close = 0;
        private int GYear = Properties.Settings.Default.CurrentYear;
        private int GTerm = Properties.Settings.Default.CurrentTerm;

        //report vars
        string totalIncome, totalExpense, openingBal, closingBal;
        List<ExpenseDetails> expenseDetails = new List<ExpenseDetails>();
        List<IncomeDetails> incomeDetails = new List<IncomeDetails>();
        FrmTrialBalance frmT;

        public FrmTermlyTB()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmTermlyTB_Load(object sender, EventArgs e)
        {
            PreparingComboBoxesAsync();
            ListInit();
        }

        private void ListInit()
        {
            selFilTerms.Clear();
            selFilTerms.Add(1); selFilTerms.Add(2); selFilTerms.Add(3);
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
            }
        }

        private void Switch_OnValueChange(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuiOSSwitch sw = sender as Bunifu.Framework.UI.BunifuiOSSwitch;
            if (sw.Value)
            {
                selFilTerms.Add(int.Parse(sw.Tag.ToString()));
            }
            else
            {
                selFilTerms.Remove(int.Parse(sw.Tag.ToString()));
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selYear = int.Parse(cbYear.SelectedItem.ToString());
        }

        private void FrmTermlyTB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close==1)
            {
                e.Cancel = false;
                return;
            }

            if (selYear == 0)
            {
                alert.Show("Required info \n Select a year !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            if (switch1.Value & switch2.Value & switch3.Value)
            {
                ListInit();
            }

            if (selFilTerms.Count == 0)
            {
                alert.Show("Required info \n Select at least a term !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            //load the print


            e.Cancel = false;
        }

        public async void LauchPrint(IWin32Window t)
        {
            //notification
            alert.Show("Please wait...\n Generating Document !", alert.AlertType.success);
            await Task.Delay(5000);

            frmT.ShowDialog(t);
        }
        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (selFilTerms.Count != 0)
            {
                if (selYear != 0)
                {
                   // await Task.Run(() => TransCashlbl(selFilTerms, selYear, true)) ;
                   await TransCashlbl(selFilTerms, selYear, true);

                    TrialDetails tdd = new TrialDetails()
                    {
                        PeriodText = "Year",
                        PeriodValue = selYear.ToString(),
                        TotalIncome = totalIncome,
                        TotalExpense = totalExpense,
                        OpeningBal = openingBal,
                        ClosingBal = closingBal
                    };

                    frmT = new FrmTrialBalance(tdd, incomeDetails, expenseDetails);
                } 
            }
        }

        #region Complexities

        private async Task TransCashlbl(List<int> selTerms, int year, bool filtered)
        {
            decimal runningTotalIncome = 0;
            decimal runningTotalFees = 0;
            decimal runningTotalExpenses = 0;
            decimal runningOpeningBal = 0;
            decimal runningClosingBal = 0;

            foreach (var term in selTerms)
            {
                #region lbl_income&lbl_expense
                var myIncomes = await Task.Factory.StartNew(() =>
                {
                    int ct = term;
                    int cy = year;
                    using (var context = new EschoolEntities())
                    {
                        return context.Incomes
                        .Where(t => t.Term == ct && t.Year == cy)
                        .ToList();
                    }
                });
                decimal totalIncome1 = myIncomes.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);

                foreach (var item in myIncomes)
                {
                    IncomeDetails inc = new IncomeDetails()
                    {
                        IncomeName = item.Category + $" (T{term})",
                        Amount = item.Amount
                    };

                    incomeDetails.Add(inc);
                }

                runningTotalIncome += totalIncome1;

                var myFees = await Task.Factory.StartNew(() =>
                {
                    int ct = term;
                    int cy = year;
                    using (var context = new EschoolEntities())
                    {
                        return context.Fees
                               .Where(t => t.Term == ct && t.Year == cy)
                               .ToList();
                    }
                });
                decimal totalFee = myFees.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount_Paid);

                IncomeDetails inc1 = new IncomeDetails()
                {
                    IncomeName = "Fees" + $" (T{term})",
                    Amount = totalFee
                };
                incomeDetails.Add(inc1);

                runningTotalFees += totalFee;

                totalIncome = $"KES {String.Format("{0:0,0}", runningTotalIncome + runningTotalFees)}";

                var myExpenses = await Task.Factory.StartNew(() =>
                {
                    int ct = term;
                    int cy = year;
                    using (var context = new EschoolEntities())
                    {
                        return context.Expenses
                        .Where(t => t.Term == ct && t.Year == cy)
                        .ToList();
                    }
                });
                decimal totalExpenses1 = myExpenses.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);

                foreach (var item in myExpenses)
                {
                    ExpenseDetails exp = new ExpenseDetails()
                    {
                        ExpenseName = item.Category + $" (T{term})",
                        Amount = item.Amount
                    };

                    expenseDetails.Add(exp);
                }

                runningTotalExpenses += totalExpenses1;

                totalExpense = $"KES {String.Format("{0:0,0}", runningTotalExpenses)}";
                #endregion

                #region lbl_opening&lbl_closing_Balance
                int checkTerm, checkYear;

                if (term == 1)
                {
                    checkYear = year - 1;
                    checkTerm = 3;
                }
                else
                {
                    checkYear = year;
                    checkTerm = term - 1;
                }
                ClosingBalance prevClosingBalance = await PrevPeriodClosingBal(checkTerm, checkYear);
                decimal openingBal1 = 0;
                if (prevClosingBalance != null)
                {
                    openingBal1 = prevClosingBalance.Amount;
                }
                else
                {
                    if (Properties.Settings.Default.FirstInstallUse)
                    {
                        openingBal1 = Properties.Settings.Default.OpeningBalance;
                        //this condition code is not to run again
                        Properties.Settings.Default.FirstInstallUse = false;
                        Properties.Settings.Default.Save();
                    }
                }

                runningOpeningBal += openingBal1;
                openingBal = $"KES {String.Format("{0:0,0}", runningOpeningBal)}";

                decimal closingBal1 = openingBal1 + ((totalIncome1 + totalFee) - totalExpenses1);

                runningClosingBal += closingBal1;
                closingBal = $"KES {String.Format("{0:0,0}", runningClosingBal)}";

                ClosingBalance curClosingBalance = await PrevPeriodClosingBal(GTerm, GYear);
                using (var context = new EschoolEntities())
                {

                    if (curClosingBalance != null)
                    {
                        curClosingBalance.Amount = closingBal1;
                        curClosingBalance.Term = GTerm;
                        curClosingBalance.Year = GYear;
                        curClosingBalance.Month = null;


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
                            Term = GTerm,
                            Year = GYear,
                            Month = null
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
        }


        private async Task<ClosingBalance> PrevPeriodClosingBal(int term, int year)
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
                foreach (var item in myCloseBalListAsync.Where(x => x.Term == term & x.Year == year))
                {
                    return item;
                }
            }

            return null;
        }
        #endregion
    }
}
