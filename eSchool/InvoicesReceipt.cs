using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.Invoices;
using eSchool.IncomeUIs;

namespace eSchool
{
    public partial class InvoicesReceipt : UserControl
    {
        //Singleton pattern ***best practices***
        private static InvoicesReceipt _instance;
        public static InvoicesReceipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InvoicesReceipt();
                }
                return _instance;
            }
        }
        public InvoicesReceipt()
        {
            InitializeComponent();
        }

        private int GTerm;
        private int GYear;
        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GridIconPicker(gData.Rows[e.RowIndex].Cells[6], gData.Rows[e.RowIndex].Cells[3], gData.Rows[e.RowIndex].Cells[4]);
            lblRowCount.Text = gData.Rows.Count.ToString();
        }

        private void GridIconPicker(DataGridViewCell rPic, DataGridViewCell amountpaid, DataGridViewCell balance)
        {
            string test = (string)amountpaid.Value;
            string t1 = test.Remove(0, 4);
            string t2 = t1.Replace(",", "");
            int cAmount;
            int.TryParse(t2, out cAmount);

            string test1 = (string)balance.Value;
            string t11 = test1.Remove(0, 4);
            string t21 = t11.Replace(",", "");
            int cBalance;
            int.TryParse(t21, out cBalance);


            if (cAmount == 0 & cBalance > 0)
            {
                rPic.Value = StatusGrid._1unpaid;
            }
            else if (cAmount > 0 & cBalance > 0)
            {
                rPic.Value = StatusGrid._1incomplete;
            }
            else if (cAmount > 0 & (cBalance == 0 | cBalance < 0))
            {
                rPic.Value = StatusGrid._1paid;
            }
            else if (cAmount == 0 & (cBalance == 0 | cBalance < 0))
            {
                rPic.Value = StatusGrid._1paid;
            }
            //TODO find a cancelled state

        }
        private void InvoicesReceipt_Load(object sender, EventArgs e)
        {
            //UI code
            TermImageSet();

            //load the grid
            GridInitializer();
            //lbls
            InvoiceCashlbl(GTerm, GYear);
        }

        private async void GridInitializer()
        {
            var invoiceListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Invoices
                    .Where(t => t.Term == GTerm & t.Year == GYear)
                    .ToList();
                }
            });

            gData.Rows.Clear();
            foreach (var item in invoiceListAsync)
            {
                gData.Rows.Add(new string[]
                    {
                           item.InvoiceNo,
                           item.Category,
                           item.Client,
                           $"KES {String.Format("{0:0,0}", item.Amount)}",
                           $"KES {String.Format("{0:0,0}", item.Balance)}",
                           item.Date.ToString("dd MMM yyy"),
                           null
                    });
            }
        }
        //takes a student. Gets all the data on fees he/she has paid.
        //Propagates the amount paid and fee balance if any.
        private void btnCreateInvoice_Click_1(object sender, EventArgs e)
        {
            FrmCreateInvoice frm = new FrmCreateInvoice();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //load the grid
                GridInitializer();

                //lbls
                InvoiceCashlbl(GTerm, GYear);
            }
        }

        private async void InvoiceCashlbl(int term, int year)
        {
            var invoiceList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Invoices.ToList();
                }
            });

            var myList = invoiceList.Where(x =>x.Term ==term & x.Year == year).ToList();
            if (myList != null)
            {

                decimal totals = myList.Sum(x => x.Amount);
                decimal bal = myList.Sum(x => x.Balance);

                this.lblPaid.Text = $"KES {String.Format("{0:0,0}", totals)}";
                this.lblBalance.Text = $"KES {String.Format("{0:0,0}", bal)}";
                this.lblYear.Text = $"Year: {year}"; //Year: 2017 
            }
            else
            {
                decimal totals = 0;
                decimal bal = 0;

                this.lblPaid.Text = $"KES {String.Format("{0:0,0}", totals)}";
                this.lblBalance.Text = $"KES {String.Format("{0:0,0}", bal)}";
                this.lblYear.Text = $"Year: {year}"; //Year: 2017 
            }
        }

        List<int> selTerms;
        int filYear;
        private void btnFilter_Click(object sender, EventArgs e)
        {
            FrmFilterIncome filInc = new FrmFilterIncome();
            if (filInc.ShowDialog() == DialogResult.OK)
            {
                selTerms = FrmFilterIncome.selFilTerms;
                filYear = FrmFilterIncome.selFilYear;

                lblRowCount.Text = "0";

                //refresh grid with filters
                GridInitilizer(selTerms, filYear);

                //lbls
                InvoiceCashlbl(selTerms, filYear);

                //change label
                lblTermSet(selTerms);
            }
        }

        public async void GridInitilizer(List<int> selTerms, int filYear)
        {
            var invoiceListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Invoices
                    .Where(t => t.Year == filYear)
                    .ToList();
                }
            });

            gData.Rows.Clear();

            foreach (var tm in selTerms)
            {
                foreach (var item in invoiceListAsync.Where(t => t.Term == tm))
                {
                    gData.Rows.Add(new string[]
                        {
                           item.InvoiceNo,
                           item.Category,
                           item.Client,
                           $"KES {String.Format("{0:0,0}", item.Amount)}",
                           $"KES {String.Format("{0:0,0}", item.Balance)}",
                           item.Date.ToString("dd MMM yyy"),
                           null
                        });
                } 
            }
            
        }

        private async void InvoiceCashlbl(List<int> selTerms, int filYear)
        {
            var invoiceList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Invoices.ToList();
                }
            });

            List<Invoice> myList = new List<Invoice>();
                //invoiceList.Where(x => x.Year == filYear).ToList();
            decimal totalRunning = 0;
            decimal totalBal = 0;
            foreach (var tm in selTerms)
            {
                myList.AddRange(invoiceList.Where(x => x.Term == tm).ToList());

                if (myList != null)
                {
                    totalRunning += myList.Where(x => x.Term == tm & x.Year == filYear).Sum(x => x.Amount);
                    totalBal += myList.Where(x => x.Term == tm & x.Year == filYear).Sum(x => x.Balance);
                } 
            }
            this.lblPaid.Text = $"KES {String.Format("{0:0,0}", totalRunning)}";
            this.lblBalance.Text = $"KES {String.Format("{0:0,0}", totalBal)}";
            this.lblYear.Text = $"Year: {filYear}"; //Year: 2017 
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
    }
}
