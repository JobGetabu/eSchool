using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.TransionX;

namespace eSchool
{
    public partial class TransationsUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static TransationsUI _instance;
        public static TransationsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransationsUI();
                }
                return _instance;
            }
        }
        public TransationsUI()
        {
            InitializeComponent();
        }

        private int GTerm;
        private int GYear;

        private void TermImageSet()
        {
            GYear = Properties.Settings.Default.CurrentYear;
            GTerm = Properties.Settings.Default.CurrentTerm;
            this.lblYear.Text = $"Year: {GYear.ToString()}";//Year: 2017

            if (Properties.Settings.Default.CurrentTerm == 1)
            {
                //this.pBoxLogoTerm.Image = Incomelogo.income_term1;
                lblT1.Text = "1";
                lblT2.Text = "";
                lblT3.Text = "";
            }
            if (Properties.Settings.Default.CurrentTerm == 2)
            {
                //this.pBoxLogoTerm.Image = Incomelogo.income_term2;
                lblT2.Text = "2";
                lblT1.Text = "";
                lblT3.Text = "";
            }
            if (Properties.Settings.Default.CurrentTerm == 3)
            {
                //this.pBoxLogoTerm.Image = Incomelogo.income_term3;
                lblT3.Text = "3";
                lblT1.Text = "";
                lblT2.Text = "";
            }
        }

        public void Global_TransationsUI_Load()
        {
            //UI code
            TermImageSet();
            //change color of TXN to green
            gData.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;

            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();

            //Load the grid
            GridInitializer();

            //lbls
            TransCashlbl(GTerm, GYear);
        }

        private void TransationsUI_Load(object sender, EventArgs e)
        {
            //UI code
            TermImageSet();
            //change color of TXN to green
            gData.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;

            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();

            //Load the grid
            GridInitializer();

            //lbls
            TransCashlbl(GTerm, GYear);
        }

        private async void GridInitializer()
        {
            var transListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Transations
                    .Where(t => t.Term == GTerm & t.Year == GYear)
                    .ToList();
                }
            });

            gData.Rows.Clear();
            foreach (var item in transListAsync)
            {
                gData.Rows.Add(new string[]
                    {
                           item.TransactionNo,
                           item.Type,
                           item.Details,
                           $"KES {String.Format("{0:0,0}", item.Amount)}",
                           item.Date.ToString("dd MMM yyy")
                    });
            }
        }

        List<int> selTerms;
        int filYear;
        DateTime startDate;
        DateTime endDate;
        private void btnFilter_Click(object sender, EventArgs e)
        {
            FrmFilterTransaction frm = FrmFilterTransaction.Instance;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //logic
                if (frm.IsTerms)
                {
                    //term was selected
                    selTerms = frm.selFilTerms;
                    filYear = frm.selFilYear;
                    lblDates.Visible = false;

                    lblTermSet(selTerms);
                    this.lblYear.Text = $"Year: {filYear.ToString()}";//Year: 2017

                    //overloaded
                    TransCashlbl(selTerms, filYear, true);
                    GridInitializer(selTerms, filYear);
                }
                else
                {
                    //dates was selected
                    startDate = frm.startDate;
                    endDate = frm.endDate;

                    lblDates.Visible = true;
                    lblDates.Text = $"{startDate.ToString("dd MMM yyy")} to {endDate.ToString("dd MMM yyy")}";

                    //change label
                    lblTermSet(selTerms);
                    this.lblYear.Text = $"Year: {filYear.ToString()}";//Year: 2017
                    lblT1.Text = ""; lblT2.Text = ""; lblT3.Text = "";

                    //TODO overloaded
                }
            }

        }

        private void lblTermSet(List<int> terms)
        {
            lblT1.Text = ""; lblT2.Text = ""; lblT3.Text = "";
            foreach (var tm in terms)
            {
                if (tm == 1)
                {
                    lblT1.Text = "1";

                }
                if (tm == 2)
                {
                    lblT2.Text = "2";

                }
                if (tm == 3)
                {
                    lblT3.Text = "3";
                }
            }
        }

        private void btnTrialBal_Click(object sender, EventArgs e)
        {

        }

        private async void TransCashlbl(int term, int year)
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
            decimal totalIncome = myIncomes.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);


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

            this.lblncomes.Text = $"KES {String.Format("{0:0,0}", totalIncome + totalFee)}";

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
            decimal totalExpenses = myExpenses.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);

            this.lblExpense.Text = $"KES {String.Format("{0:0,0}", totalExpenses)}";
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
            decimal openingBal = 0;
            if (prevClosingBalance != null)
            {
                openingBal = prevClosingBalance.Amount;
            }
            else
            {
                if (Properties.Settings.Default.FirstInstallUse)
                {
                    openingBal = Properties.Settings.Default.OpeningBalance;
                    //this condition code is not to run again
                    Properties.Settings.Default.FirstInstallUse = false;
                    Properties.Settings.Default.Save();
                }
            }


            this.lblOpening.Text = $"KES {String.Format("{0:0,0}", openingBal)}";

            decimal closingBal = openingBal + ((totalIncome + totalFee) - totalExpenses);

            this.lblClosing.Text = $"KES {String.Format("{0:0,0}", closingBal)}";

            ClosingBalance curClosingBalance = await PrevPeriodClosingBal(GTerm, GYear);
            using (var context = new EschoolEntities())
            {

                if (curClosingBalance != null)
                {
                    curClosingBalance.Amount = closingBal;
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
                        Amount = closingBal,
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

        private async Task<decimal> CheckPrevClosingBal(List<GroupedFeeStructure> gpFsList, int term, int year)
        {
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

            decimal lclosingBalance = 0;
            decimal lopeningBalance = 0;
            decimal ltotalIncome = 0;
            decimal ltotalFees = 0;
            decimal ltotalExpense = 0;

            GroupedFeeStructure gpFs = null;

            var filList1 = gpFsList.Where(x => x.selYear == checkYear | x.selYear < checkYear).ToList();
            if (filList1 != null)
            {
                var filList2 = filList1.Where(x => x.selTerm == checkTerm | x.selTerm < checkTerm).ToList();

                foreach (var fd in filList2)
                {
                    gpFs = fd;
                }
            }
            if (gpFs != null)
            {

                using (var context = new EschoolEntities())
                {
                    //TODO instead of settings check do a db check
                    if (Properties.Settings.Default.FirstInstallUse)
                    {
                        lopeningBalance = Properties.Settings.Default.OpeningBalance;
                        //this condition code is not to run again
                        Properties.Settings.Default.FirstInstallUse = false;
                    }
                    else
                    {
                        //TODO find lopeningBalance
                    }


                    var myIncomes = await Task.Factory.StartNew(() =>
                    {
                        int ct = checkTerm;
                        int cy = checkYear;
                        return context.Incomes
                                .Where(t => t.Term == ct & t.Year == cy)
                                .ToList();
                    });
                    decimal totalIncome = myIncomes.Where(x => x.Term == checkTerm & x.Year == checkYear).Sum(x => x.Amount);
                    ltotalIncome = totalIncome;

                    var myFees = await Task.Factory.StartNew(() =>
                    {
                        int ct = checkTerm;
                        int cy = checkYear;
                        return context.Fees
                        .Where(t => t.Term == ct & t.Year == cy)
                        .ToList();
                    });
                    decimal totalFee = myFees.Where(x => x.Term == checkTerm & x.Year == checkYear).Sum(x => x.Amount_Paid);
                    ltotalFees = totalFee;

                    var myExpenses = await Task.Factory.StartNew(() =>
                    {
                        int ct = checkTerm;
                        int cy = checkYear;

                        return context.Expenses
                                .Where(t => t.Term == ct & t.Year == cy)
                                .ToList();

                    });
                    decimal totalExpenses = myExpenses.Where(x => x.Term == checkTerm & x.Year == checkYear).Sum(x => x.Amount);
                    ltotalExpense = totalExpenses;
                }
            }

            lclosingBalance = lopeningBalance + ((ltotalIncome + ltotalFees) - ltotalExpense);
            return lclosingBalance;
        }

        private async Task<List<GroupedFeeStructure>> GrpFeeStruct()
        {

            var myGrpFeeListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.GroupedFeeStructures
                    .ToList();
                }

            });

            return myGrpFeeListAsync;
        }

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //change color of expense to red
            if ((string)this.gData.Rows[e.RowIndex].Cells[1].Value == "Expense")
            {
                this.gData.Rows[e.RowIndex].Cells[1].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                this.gData.Rows[e.RowIndex].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                this.gData.Rows[e.RowIndex].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
                this.gData.Rows[e.RowIndex].Cells[4].Style = new DataGridViewCellStyle { ForeColor = Color.Red };
            }
            //Color.FromArgb(31, 214, 233);
            this.lblRowCount.Text = gData.Rows.Count.ToString();
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

        private async void TransCashlbl(List<int> selTerms, int year, bool filtered)
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
                decimal totalIncome = myIncomes.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);

                runningTotalIncome += totalIncome;

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

                runningTotalFees += totalFee;

                this.lblncomes.Text = $"KES {String.Format("{0:0,0}", runningTotalIncome + runningTotalFees)}";

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
                decimal totalExpenses = myExpenses.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);

                runningTotalExpenses += totalExpenses;

                this.lblExpense.Text = $"KES {String.Format("{0:0,0}", runningTotalExpenses)}";
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
                decimal openingBal = 0;
                if (prevClosingBalance != null)
                {
                    openingBal = prevClosingBalance.Amount;
                }
                else
                {
                    if (Properties.Settings.Default.FirstInstallUse)
                    {
                        openingBal = Properties.Settings.Default.OpeningBalance;
                        //this condition code is not to run again
                        Properties.Settings.Default.FirstInstallUse = false;
                        Properties.Settings.Default.Save();
                    }
                }

                runningOpeningBal += openingBal;
                this.lblOpening.Text = $"KES {String.Format("{0:0,0}", runningOpeningBal)}";

                decimal closingBal = openingBal + ((totalIncome + totalFee) - totalExpenses);

                runningClosingBal += closingBal;
                this.lblClosing.Text = $"KES {String.Format("{0:0,0}", runningClosingBal)}";

                ClosingBalance curClosingBalance = await PrevPeriodClosingBal(GTerm, GYear);
                using (var context = new EschoolEntities())
                {

                    if (curClosingBalance != null)
                    {
                        curClosingBalance.Amount = closingBal;
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
                            Amount = closingBal,
                            Term = GTerm,
                            Year = GYear,
                            Month=null
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

        private async void GridInitializer(List<int> selTerms, int year)
        {

            var transListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Transations
                    .Where(t => t.Year == year)
                    .ToList();
                }
            });

            gData.Rows.Clear();
            foreach (var tm in selTerms)
            {
                foreach (var item in transListAsync.Where(x => x.Term == tm))
                {
                    gData.Rows.Add(new string[]
                        {
                           item.TransactionNo,
                           item.Type,
                           item.Details,
                           $"KES {String.Format("{0:0,0}", item.Amount)}",
                           item.Date.ToString("dd MMM yyy")
                        });
                }
            }
        }


        private async void TransCashlbl(DateTime datePicked,int year, bool filtered)
        {

                #region lbl_income&lbl_expense
                var myIncomes = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.Incomes
                        .Where(t => (t.Date.Month == datePicked.Month) & (t.Date == datePicked | t.Date < datePicked))
                        .ToList();
                    }
                });
                decimal totalIncome = myIncomes.Where(t => (t.Date.Month == datePicked.Month) & (t.Date == datePicked | t.Date < datePicked)).Sum(x => x.Amount);

                var myFees = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.Fees
                               .Where(t => (t.Date.Month == datePicked.Month) & (t.Date == datePicked | t.Date < datePicked))
                               .ToList();
                    }
                });
                decimal totalFee = myFees.Where(t => (t.Date.Month == datePicked.Month) & (t.Date == datePicked | t.Date < datePicked)).Sum(x => x.Amount_Paid);

            this.lblncomes.Text = $"KES {String.Format("{0:0,0}", totalIncome + totalFee)}";

            var myExpenses = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.Expenses
                        .Where(t => (t.Date.Month == datePicked.Month) & (t.Date == datePicked | t.Date < datePicked))
                        .ToList();
                    }
                });
                decimal totalExpenses = myExpenses.Where(t => (t.Date.Month == datePicked.Month) & (t.Date == datePicked | t.Date < datePicked)).Sum(x => x.Amount);

            this.lblExpense.Text = $"KES {String.Format("{0:0,0}", totalExpenses)}";
            #endregion

            #region lbl_opening&lbl_closing_Balance


            ClosingBalance prevClosingBalance = await PrevPeriodClosingBal(datePicked.Month, year,filtered);
                decimal openingBal = 0;
                if (prevClosingBalance != null)
                {
                    openingBal = prevClosingBalance.Amount;
                }
                else
                {
                    if (Properties.Settings.Default.FirstInstallUse)
                    {
                        openingBal = Properties.Settings.Default.OpeningBalance;
                        //this condition code is not to run again
                        Properties.Settings.Default.FirstInstallUse = false;
                        Properties.Settings.Default.Save();
                    }
                }


                this.lblOpening.Text = $"KES {String.Format("{0:0,0}", openingBal)}";

                decimal closingBal = openingBal + ((totalIncome + totalFee) - totalExpenses);

                this.lblClosing.Text = $"KES {String.Format("{0:0,0}", closingBal)}";

                ClosingBalance curClosingBalance = await checkPeriodClosingBal(datePicked.Month, year);
                using (var context = new EschoolEntities())
                {

                    if (curClosingBalance != null)
                    {
                        curClosingBalance.Amount = closingBal;
                        curClosingBalance.Term = 0;
                        curClosingBalance.Year = 0;
                        curClosingBalance.Month = DateTime.Now.Month;

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
                            Amount = closingBal,
                            Term = GTerm,
                            Year = GYear,
                            Month = DateTime.Now.Month
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


        private async Task<ClosingBalance> PrevPeriodClosingBal(int month, int year,bool fil)
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
        private async Task<ClosingBalance> checkPeriodClosingBal(int month,int year)
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
                checkMonth = month-1;
            }

            if (myCloseBalListAsync != null)
            {
                var l = myCloseBalListAsync.OrderBy(t => t.Month).Where(t => t.Month == checkMonth  & t.Year == checkYear).ToList();
                return l.First();
            }
            return null;
        }
    }
}
