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

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.gData.Rows[e.RowIndex].Cells[6].Value = StatusGrid._1unpaid;
        }

        private void InvoicesReceipt_Load(object sender, EventArgs e)
        {
            //gData.Rows.Add(new string[]
            //    {
            //           "101",
            //           "Fees",
            //           "Job Getabu",
            //           "KES 15,000",
            //           "KES 00",
            //           "14 Jan 2017",
            //           null
            //    });
          
        }

        //takes a student. Gets all the data on fees he/she has paid.
        //Propagates the amount paid and fee balance if any.
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCreateInvoice_Click_1(object sender, EventArgs e)
        {
            FrmCreateInvoice frm = new FrmCreateInvoice();
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
