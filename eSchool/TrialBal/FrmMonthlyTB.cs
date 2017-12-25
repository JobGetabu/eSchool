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
        string periodType; //either Month or Year
        private int selMonth =0;
        private int selYear=0;
        private int close = 0;

        //report vars
        string totalIncome, totalExpense, openingBal, closingBal;
        List<ExpenseDetails> expenseDetails = new List<ExpenseDetails>();
        List<IncomeDetails> incomeDetails = new List<IncomeDetails>();

        public FrmMonthlyTB(string periodType)
        {
            InitializeComponent();
            this.periodType = periodType;

        }

        private void FrmMonthlyTB_Load(object sender, EventArgs e)
        {
            if (periodType.Equals("Month"))
            {
                lblFrm.Text = "Select Month";
                cbItem.PromptText = "Select Month";
                //process monthly data
                String[] monthList = new string[]
                {
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                };
                cbItem.Items.Clear();
                cbItem.Items.AddRange(monthList);
            }
            else
            {
                lblFrm.Text = "Select Year";
                cbItem.PromptText = "Select Year";
                PreparingComboBoxesAsync();
                //process yearly data
            }
        }

        private async void PreparingComboBoxesAsync()
        {
            cbItem.Items.Clear();
            using (var context = new EschoolEntities())
            {
                var listYear = Task.Factory.StartNew(() =>
                {
                    return context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                });

                foreach (var y in await listYear)
                {
                    cbItem.Items.Add(y);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            selMonth = 1 + (cbItem.SelectedIndex);
            if (periodType.Equals("Year"))
            {
                selYear = int.Parse(cbItem.SelectedItem.ToString());
            }
        }

        private async void FrmMonthlyTB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
            }
            if (periodType.Equals("Month"))
            {
                if (selMonth ==0)
                {
                    alert.Show("Required info \n Select month !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                //pass monthly data

                e.Cancel = false;
            }
            else
            {
                if (selYear == 0)
                {
                    alert.Show("Required info \n Select year !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                //pass yearly data

                TrialDetails tdd = new TrialDetails()
                {
                    PeriodText = "Month",
                    PeriodValue = cbItem.SelectedItem.ToString(),
                    TotalIncome = totalIncome,
                    TotalExpense = totalExpense,
                    OpeningBal = openingBal,
                    ClosingBal = closingBal
                };

                //notification
                alert.Show("Please wait...\n Generating Document !", alert.AlertType.success);
                await Task.Delay(5000);

                FrmTrialBalance frmT = new FrmTrialBalance(tdd, incomeDetails, expenseDetails);
                frmT.ShowDialog();

                e.Cancel = false;
            }

        }


        #region Complexies

        private async void TransCashlbl(int datePicked, int year, bool filtered)
        {

            #region lbl_income&lbl_expense
            var myIncomes = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Incomes
                    .Where(t => (t.Date.Month == datePicked))
                    .ToList();
                }
            });
            decimal totalIncome1 = myIncomes.Where(t => (t.Date.Month == datePicked)).Sum(x => x.Amount);

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
                           .Where(t => (t.Date.Month == datePicked))
                           .ToList();
                }
            });
            decimal totalFee = myFees.Where(t => (t.Date.Month == datePicked)).Sum(x => x.Amount_Paid);
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
                    .Where(t => (t.Date.Month == datePicked))
                    .ToList();
                }
            });
            decimal totalExpenses1 = myExpenses.Where(t => (t.Date.Month == datePicked)).Sum(x => x.Amount);

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


            ClosingBalance prevClosingBalance = await checkPeriodClosingBal(datePicked, year, filtered);
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


             openingBal = $"KES {String.Format("{0:0,0}", openingBal1)}";

            decimal closingBal1 = openingBal1 + ((totalIncome1 + totalFee) - totalExpenses1);

            closingBal = $"KES {String.Format("{0:0,0}", closingBal1)}";

            ClosingBalance curClosingBalance = await ThisPeriodClosingBal(datePicked, year, filtered);
            using (var context = new EschoolEntities())
            {

                if (curClosingBalance != null)
                {
                    curClosingBalance.Amount = closingBal1;
                    curClosingBalance.Term = 0;
                    curClosingBalance.Year = year;
                    curClosingBalance.Month = datePicked;

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
                        Month = datePicked
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
