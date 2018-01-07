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
    public partial class ReceiptOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static ReceiptOverview _instance;
        public static ReceiptOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiptOverview();
                }
                return _instance;
            }
        }
        public ReceiptOverview()
        {
            InitializeComponent();
        }

        int GTerm = Properties.Settings.Default.CurrentTerm;
        int GYear = Properties.Settings.Default.CurrentYear;
        public void Global_ReceiptOverview_Load()
        {
            //TODO get number of printed receipts here and pending
        }
        private void ReceiptOverview_Load(object sender, EventArgs e)
        {
            //TODO get number of printed receipts here and pending
            Figures();
        }

        private async void Figures()
        {
            using (var context = new EschoolEntities())
            {
                var feeListAsync = await Task.Factory.StartNew(() =>
                {
                    return context.Fees
                    .Where(s => s.Term == GTerm & s.Year == GYear)
                    .ToList();

                });


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

                var fees = feeListAsync.Select(a => a.Admin_No);

                int registeredStudents = fees.Distinct().Count();

                this.lblReceipted.Text = countCleared.ToString();
                this.lblPending.Text = $"{(registeredStudents - countCleared).ToString()}";
            }
        }

        private decimal FeeRequiredAsync(int term, int year, int form)
        {
            using (var context = new EschoolEntities())
            {
                var  fRPTerms =  context.FeesRequiredPerTerms.ToList();

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
        }
    }
}
