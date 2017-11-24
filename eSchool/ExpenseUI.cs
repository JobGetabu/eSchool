using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.ExpenceUIs;

namespace eSchool
{
    public partial class ExpenseUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static ExpenseUI _instance;

        private List<Expense> myExpenses;
        private static int GTerm;
        private static int GYear;
        public static ExpenseUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpenseUI();
                }
                return _instance;
            }
        }

        public ExpenseUI()
        {
            InitializeComponent();
        }

        private void TermImageSet()
        {
            GYear = Properties.Settings.Default.CurrentYear;
            GTerm = Properties.Settings.Default.CurrentTerm;
            this.lblYear.Text = $"Year: {GYear.ToString()}";//Year: 2017

            if (Properties.Settings.Default.CurrentTerm == 1)
            {
                //this.pBoxLogoTerm.Image = ExpenceLogo.expense_term1;
                lblT1.Text = "1";
                lblT2.Text = "";
                lblT3.Text = "";
            }
            if (Properties.Settings.Default.CurrentTerm == 2)
            {
               // this.pBoxLogoTerm.Image = ExpenceLogo.expense_term2;
                lblT2.Text = "2";
                lblT1.Text = "";
                lblT3.Text = "";
            }
            if (Properties.Settings.Default.CurrentTerm == 3)
            {
                //this.pBoxLogoTerm.Image = ExpenceLogo.expense_term3;
                lblT3.Text = "3";
                lblT1.Text = "";
                lblT2.Text = "";
            }
        }

        private async void ExpenseTotalAsync(int term, int year)
        {
            myExpenses = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Expenses
                    .Where(t => t.Term == ct && t.Year == cy)
                    .ToList();
                }
            });
            decimal total = myExpenses.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);
            this.lblPaid.Text = $"KES {String.Format("{0:0,0}", total)}";
        }

        public void Global_ExpenseUI_Load()
        {
            //UI code
            TermImageSet();

            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();
            //Load the grid
            GridInitilizer();
            ExpenseTotalAsync(GTerm, GYear);
        }
        private void ExpenseUI_Load(object sender, EventArgs e)
        {
            //UI code
            TermImageSet();

            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();
            //Load the grid
            GridInitilizer();
            ExpenseTotalAsync(GTerm, GYear);
        }

        private async void ExpenseListAsync()
        {
            myExpenses = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Expenses
                    .Where(t => t.Term == ct && t.Year == cy)
                    .ToList();
                }
            });
        }
        public async void GridInitilizer()
        {
            gData.Rows.Clear();

            var expenseListAsync = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Expenses
                    .Where(t => t.Term == ct && t.Year == cy)
                    .OrderBy(t => t.Date)
                    .ToList();
                }
            });
            //runs first
            //fRPTermsList();

            // string totalCash = $"KES {String.Format("{0:0,0}", updateTotal)}";
            myExpenses = new List<Expense>();
            myExpenses = expenseListAsync;
            foreach (var inc in expenseListAsync)
            {
                gData.Rows.Add(new string[]
                {
                       inc.Category,
                       inc.Details,
                       $"KES {String.Format("{0:0,0}", inc.Amount)}",
                       inc.Date.ToString("dd MMM yyy")
                });
            }
        }

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.lblRowCount.Text = gData.Rows.Count.ToString();
            this.gData.Rows[e.RowIndex].Cells[4].Value = GridIcon.Trash_Can_50px;
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                context.Entry<Expense>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();

                                //TODO short Custom Notification
                                gData.Rows[e.RowIndex].Visible = false;
                                //Load the grid again
                                GridInitilizer();
                                ExpenseTotalAsync(GTerm, GYear);
                                TermImageSet();
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");
                            }
                        }
                    }
                }
            }
        }

        private async Task<Expense> GridDelImageAsync(int rowIndex)
        {
            List<Expense> expenseList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Expenses.ToList();
                }
            });

            string details;
            details = (string)this.gData.Rows[rowIndex].Cells[1].Value;

            foreach (var fi in expenseList)
            {
                if (fi.Details.Equals(details))
                {
                    return fi;
                }
            }
            return null;
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            FrmAddExpence frm = new FrmAddExpence();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //refresh grid & total
                GridInitilizer();
                ExpenseTotalAsync(GTerm, GYear);
                TermImageSet();
            }
        }

        List<int> selTerms;
        int filYear;

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FrmFilterExpense filInc = new FrmFilterExpense();
            if (filInc.ShowDialog() == DialogResult.OK)
            {
                selTerms = FrmFilterExpense.selFilTerms;
                filYear = FrmFilterExpense.selFilYear;

                lblRowCount.Text = "0";
                //reload list
                GridInitilizer(filYear, selTerms);

                //change label
                lblTermSet(selTerms);
                this.lblYear.Text = $"Year: {filYear.ToString()}";//Year: 2017
            }
        }

        private void lblTermSet(List<int> terms)
        {
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

        private async void GridInitilizer(int year, List<int> terms)
        {
            gData.Rows.Clear();

            var expensesListAsync = await Task.Factory.StartNew(() =>
            {

                using (var context = new EschoolEntities())
                {
                    return context.Expenses
                    .Where(t => t.Year == year)
                    .OrderBy(t => t.Date)
                    .ToList();
                }
            });

            List<Expense> maList = new List<Expense>();
            decimal totalRunning = 0;
            foreach (var tm in terms)
            {
                maList.AddRange(expensesListAsync.Where(x => x.Term == tm).ToList());
                if (maList != null)
                {
                    totalRunning += maList.Where(x => x.Term == tm & x.Year == year).Sum(x => x.Amount);
                }
            }
            foreach (var inc in maList)
            {
                gData.Rows.Add(new string[]
                {
                       inc.Category,
                       inc.Details,
                       $"KES {String.Format("{0:0,0}", inc.Amount)}",
                       inc.Date.ToString("dd MMM yyy")
                });
            }
            this.lblPaid.Text = $"KES {String.Format("{0:0,0}", totalRunning)}";
        }
    }
}
