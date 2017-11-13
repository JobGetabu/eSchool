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
            //TODO find a cancelled state
                        
        }
        private void InvoicesReceipt_Load(object sender, EventArgs e)
        {
            GYear = Properties.Settings.Default.CurrentYear;
            GTerm = Properties.Settings.Default.CurrentTerm;

            //load the grid
            GridInitializer();

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
            }
        }
    }
}
