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

namespace eSchool.Invoices
{
    public partial class FrmCreateInvoice : Form
    {
        public FrmCreateInvoice()
        {
            InitializeComponent();
        }

        List<Student_Basic> studentList = null;
        private int close;
        private int GTerm;
        private int GYear;
        private string client;
        private decimal amount;
        private decimal balance;
        private void FrmCreateInvoice_Load(object sender, EventArgs e)
        {
            GYear = Properties.Settings.Default.CurrentYear;
            GTerm = Properties.Settings.Default.CurrentTerm;

            tbCat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbCat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            col.Add("Fees");
            tbCat.AutoCompleteCustomSource = col;
        }

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
            if (studentList == null)
            {
                studentList = await StudListAsync();
            }

            foreach (var stud in studentList.Where(a => a.Admin_No == admin))
            {
                if (admin == stud.Admin_No)
                {
                    return stud;
                }
            }
            return null;
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
                        tbSDetails.Text = $" {stud.First_Name} {stud.Last_Name}";
                        tbCat.Text = "Fees";
                        tbCat.Focus();

                        client = tbSDetails.Text;
                        amount = await AmountPaid(stud);
                        balance = await Balance(stud);
        
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }
        private void FrmCreateInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }
            if (string.IsNullOrEmpty(tbAdminNo.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Enter Administration Number !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbSDetails.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Enter Some Student Details  !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            Invoice invoice = new Invoice()
            {
                Category = tbCat.Text,
                Client = client,
                Amount = amount,
                Balance = balance,
                Date = DateTime.Now,
                Term = GTerm,
                Year = GYear
            };

            using (var context = new EschoolEntities())
            {
                context.Invoices.Add(invoice);
                try
                {
                    invoice.InvoiceNo = "100" + invoice.Id;
                    context.SaveChanges();
                    invoice.InvoiceNo = "100" + invoice.Id;
                    context.Entry<Invoice>(invoice).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            //TODO custom notification
            MetroMessageBox.Show(this, "Invoice Saved !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            e.Cancel = false;
        }

        private async Task<Decimal> AmountPaid(Student_Basic stud)
        {
            List<Fee> feeListAsync= new List<Fee>();
            using (var context = new EschoolEntities())
            {
                feeListAsync = await Task.Factory.StartNew(() =>
                {
                    return context.Fees
                    .ToList();

                });
            }

            var result = from item in feeListAsync
                         orderby item.Admin_No
                         group feeListAsync by item.Admin_No into grp
                         let sum = feeListAsync.Where(x => x.Admin_No == grp.Key & x.Term == GTerm & x.Year == GYear).Sum(x => x.Amount_Paid)
                         let sform = feeListAsync.Where(x => x.Admin_No == grp.Key & x.Term == GTerm & x.Year == GYear).Select(x => x.Form).First()
                         select new
                         {
                             StudAdmin = grp.Key,
                             Sum = sum,
                             sForm = sform,
                         };
            foreach (var student in result)
            {
                if (stud.Admin_No == student.StudAdmin)
                {
                    return student.Sum;
                }
            }
            return 0;
        }

        private async Task<Decimal> Balance(Student_Basic stud)
        {
            decimal frThisTerm = FeeRequired(GTerm, GYear, stud.Form);

            decimal fpThisTerm =await AmountPaid(stud);

            return Decimal.Subtract(frThisTerm , fpThisTerm);           
        }

        List<FeesRequiredPerTerm> fRPTerms;
        private void fRPTermsList()
        {
            using (var context = new EschoolEntities())
            {
                fRPTerms = context.FeesRequiredPerTerms.ToList();
            }
        }
        private decimal FeeRequired(int term, int year, int form)
        {
            if (fRPTerms == null)
            {
                fRPTermsList();
            }
            foreach (var fr in fRPTerms)
            {
                return fRPTerms
                     .Where(f => f.Term == term & f.Year == year & f.Form == form)
                    .ToList()
                    .First().FeeRequired;
            }
            return 0;
        }

      
    }
}
