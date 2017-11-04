using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.IncomeUIs;

namespace eSchool
{
    public partial class IncomeUI : UserControl
    {

        //Singleton pattern ***best practices***
        private static IncomeUI _instance;

        public static IncomeUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncomeUI();
                }
                return _instance;
            }
        }

        private List<Income> myIncomes;
        private static int GTerm;
        private static int GYear;
        public IncomeUI()
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

        private async void IncomeTotalAsync(int term,int year)
        {
            myIncomes = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Incomes
                    .Where(t => t.Term == ct && t.Year == cy)
                    .ToList();
                }
            });
            decimal total = myIncomes.Where(x => x.Term == term & x.Year == year).Sum(x => x.Amount);
            this.lblPaid.Text=   $"KES {String.Format("{0:0,0}",total)}";
        }
        private void IncomeUI_Load(object sender, EventArgs e)
        {
            //UI code
            TermImageSet();

            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();
            //Load the grid
            GridInitilizer();
            IncomeTotalAsync(GTerm,GYear);
        }

        private async void IncomeListAsync()
        {
            myIncomes = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Incomes
                    .Where(t => t.Term == ct && t.Year == cy)
                    .ToList();
                }
            });
        }
        public async void GridInitilizer()
        {
            gData.Rows.Clear();

            var incomeListAsync = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Incomes
                    .Where(t => t.Term == ct && t.Year == cy)
                    .OrderBy(t => t.Date)
                    .ToList();
                }
            });
            //runs first
            //fRPTermsList();

            // string totalCash = $"KES {String.Format("{0:0,0}", updateTotal)}";
            myIncomes = new List<Income>();
            myIncomes = incomeListAsync;
            foreach (var inc in incomeListAsync)
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
                                context.Entry<Income>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();

                                //TODO short Custom Notification
                                gData.Rows[e.RowIndex].Visible = false;
                                //Load the grid again
                                GridInitilizer();
                                IncomeTotalAsync(GTerm, GYear);
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

        private async Task<Income> GridDelImageAsync(int rowIndex)
        {
            List<Income> incomeList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Incomes.ToList();
                }
            });

            string details;
            details = (string)this.gData.Rows[rowIndex].Cells[1].Value;

            foreach (var fi in incomeList)
            {
                if (fi.Details.Equals(details))
                {
                    return fi;
                }
            }
            return null;
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            FrmAddIncome frm = new FrmAddIncome();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //refresh grid & total
                GridInitilizer();
                IncomeTotalAsync(GTerm, GYear);
                TermImageSet();
            }
        }

        List<int> selTerms;
        int filYear;
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            FrmFilterIncome filInc = new FrmFilterIncome();
            if (filInc.ShowDialog() == DialogResult.OK)
            {
                selTerms = FrmFilterIncome.selFilTerms;
                filYear = FrmFilterIncome.selFilYear;

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

        private async void GridInitilizer(int year,List<int> terms)
        {
            gData.Rows.Clear();

            var incomeListAsync = await Task.Factory.StartNew(() =>
            {

                using (var context = new EschoolEntities())
                {
                    return context.Incomes
                    .Where(t =>  t.Year == year)
                    .OrderBy(t => t.Date)
                    .ToList();
                }
            });

            List<Income> maList = new List<Income>();
            decimal totalRunning=0;
            foreach (var tm in terms)
            {
                maList.AddRange(incomeListAsync.Where(x => x.Term == tm).ToList());
                if (maList!=null)
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
