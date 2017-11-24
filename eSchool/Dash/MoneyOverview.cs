using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Dash
{
    public partial class MoneyOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static MoneyOverview _instance;
        public static MoneyOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MoneyOverview();
                }
                return _instance;
            }
        }
        public MoneyOverview()
        {
            InitializeComponent();
        }

        int GTerm = Properties.Settings.Default.CurrentTerm;
        int GYear = Properties.Settings.Default.CurrentYear;

        public void Global_MoneyOverview_Load()
        {
            DashUISet();
        }
        private void MoneyOverview_Load(object sender, EventArgs e)
        {
            DashUISet();
        }

        List<FeesRequiredPerTerm> fRPTerms;
        private void fRPTermsList()
        {
            using (var context = new EschoolEntities())
            {
                fRPTerms = context.FeesRequiredPerTerms.ToList();
            }
        }

        private decimal FeeRequiredAsync(int term, int year, int form)
        {
            if (fRPTerms == null)
            {
                fRPTermsList();
            }
            foreach (var fr in fRPTerms)
            {
                try
                {

                    decimal z = fRPTerms
                        .ToList()
                        .FirstOrDefault(f => f.Term == term & f.Year == year & f.Form == form).FeeRequired;
                    if (z != 0)
                    {
                        return z;
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(exp.Message);
                }
            }
            return 0;
        }

        private decimal FeeRequiredAsync(int term, int year, int fm1, int fm2, int fm3, int fm4)
        {
            if (fRPTerms == null)
            {
                fRPTermsList();
            }
            decimal fm1Total = 0;
            decimal fm2Total = 0;
            decimal fm3Total = 0;
            decimal fm4Total = 0;

            foreach (var fr in fRPTerms)
            {
                fm1Total = fRPTerms
                     .Where(f => f.Term == term & f.Year == year & f.Form == 1)
                    .ToList()
                    .Sum(x => x.FeeRequired);
            }

            fm1Total = fm1Total * fm1;

            foreach (var fr in fRPTerms)
            {
                fm2Total = fRPTerms
                     .Where(f => f.Term == term & f.Year == year & f.Form == 2)
                    .ToList()
                    .Sum(x => x.FeeRequired);
            }

            fm2Total = fm2Total * fm2;

            foreach (var fr in fRPTerms)
            {
                fm3Total = fRPTerms
                     .Where(f => f.Term == term & f.Year == year & f.Form == 3)
                    .ToList()
                    .Sum(x => x.FeeRequired);
            }

            fm3Total = fm3Total * fm3;

            foreach (var fr in fRPTerms)
            {
                fm4Total = fRPTerms
                     .Where(f => f.Term == term & f.Year == year & f.Form == 4)
                    .ToList()
                    .Sum(x => x.FeeRequired);
            }

            fm4Total = fm4Total * fm4;

            decimal grandTotal = fm1Total + fm2Total + fm3Total + fm4Total;

            return grandTotal;
        }
        public async void DashUISet()
        {
            using (var context = new EschoolEntities())
            {
                var feeListAsync = await Task.Factory.StartNew(() =>
                {
                    return context.Fees
                    .Where(s => s.Term == GTerm & s.Year == GYear)
                    .ToList();

                });
                var studentList = await Task.Factory.StartNew(() =>
                {
                    return context.Student_Basic.ToList();
                });

                int studentsCount = studentList.Count;

                int fm1Count = studentList.Count(x => x.Form == 1);
                int fm2Count = studentList.Count(x => x.Form == 2);
                int fm3Count = studentList.Count(x => x.Form == 3);
                int fm4Count = studentList.Count(x => x.Form == 4);

                var fees = feeListAsync.Select(a => a.Admin_No);

                var studentFees = studentList.SelectMany(
                                    (stud) =>
                                    feeListAsync.Where(a => a.Admin_No == stud.Admin_No)
                                                .Select(a => new { FoundAdminNo = a.Admin_No }));


                var result = from item in feeListAsync
                             orderby item.Admin_No
                             group feeListAsync by item.Admin_No into grp
                             let sum = feeListAsync.Where(x => x.Admin_No == grp.Key & x.Term == GTerm & x.Year == GYear).Sum(x => x.Amount_Paid)
                             let sform = feeListAsync.Where(x => x.Admin_No == grp.Key & x.Term == GTerm & x.Year == GYear).Select(x => x.Form).FirstOrDefault()
                             select new
                             {
                                 StudAdmin = grp.Key,
                                 Sum = sum,
                                 sForm = sform,
                             };
                //decimal feeForTermTotal = FeeRequiredAsync(GTerm, GYear);
                decimal grandTotalFee = FeeRequiredAsync(GTerm, GYear, fm1Count, fm2Count, fm3Count, fm4Count);                

                decimal paidTotal = 0;
                int countCleared = 0;
                foreach (var item in result)
                {
                    var i = item.Sum;
                    if (i >= FeeRequiredAsync(GTerm, GYear, item.sForm))
                    {
                        countCleared += 1;
                    }
                    paidTotal += i;
                }

                //lblBalance
                decimal balance = grandTotalFee - paidTotal;
                lblBalance.Text = $"{String.Format("{0:0,0}", balance)}";

                var myIncomes = await Task.Factory.StartNew(() =>
                {
                        return context.Incomes
                        .Where(t => t.Term == GTerm && t.Year == GYear)
                        .ToList();                    
                });
                decimal totalIncome = myIncomes.Where(x => x.Term == GTerm & x.Year == GYear).Sum(x => x.Amount);


                var myFees = await Task.Factory.StartNew(() =>
                {
                        return context.Fees
                                .Where(t => t.Term == GTerm && t.Year == GYear)
                               .ToList();                   
                });
                decimal totalFee = myFees.Where(x => x.Term == GTerm & x.Year == GYear).Sum(x => x.Amount_Paid);

                //lblIncome
                this.lblIncome.Text = $"{String.Format("{0:0,0}", totalIncome + totalFee)}";

                var myExpenses = await Task.Factory.StartNew(() =>
                {
                        return context.Expenses
                        .Where(t => t.Term == GTerm && t.Year == GYear)
                        .ToList();
                    
                });
                decimal totalExpenses = myExpenses.Where(x => x.Term == GTerm & x.Year == GYear).Sum(x => x.Amount);

                //lblExpenses
                this.lblExpense.Text = $"{String.Format("{0:0,0}", totalExpenses)}";

                //lblIncome
                this.lblstatus.Text = $"{String.Format("{0:0,0}", (totalIncome + totalFee) -totalExpenses)}";

            }
        }
    }
}
