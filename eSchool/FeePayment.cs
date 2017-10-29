using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace eSchool
{
    public partial class FeePayment : UserControl
    {

        private static FeePayment _instance;
        public static FeePayment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeePayment();
                }
                return _instance;
            }
        }
        public FeePayment()
        {
            InitializeComponent();
        }

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.lblRowCount.Text = gData.Rows.Count.ToString();
            //insert images smartly
            //TODO 1 check percentage from fee required per term to determine image
            gData.Rows[e.RowIndex].Cells[0].Value = GridIcon.ok80;
        }

        private void FeePayment_Load(object sender, EventArgs e)
        {
            //Ui code
            this.lblRowCount.Text = gData.Rows.Count.ToString();
            //populate the grid
            GridInitilizer();
        }

        List<Fee> myFee;
        public async void GridInitilizer()
        {
            gData.Rows.Clear();

            var feeListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees.ToList();
                }
            });

            myFee = feeListAsync;
            foreach (var fee in feeListAsync)
            {
                gData.Rows.Add(new string[]
                {
                        null,
                        fee.Admin_No.ToString(),
                        fee.Name,
                        fee.Form.ToString(),
                        fee.Class,
                        fee.Amount_Paid.ToString(),
                        fee.Date.ToString("dd MMM yyy"),
                        fee.ModeOfPayment
                });
            }
        }


        ///Search Perfecto
        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                gData.Rows.Clear();

                var filList = myFee.Where(s =>
                     Regex.IsMatch(s.Admin_No.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.Class.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.ModeOfPayment.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                     Regex.IsMatch(s.Form.ToString(), tbSearch.Text, RegexOptions.IgnoreCase)).ToList();
                foreach (var fee in filList)
                {
                    gData.Rows.Add(new string[]
                    {
                        null,
                        fee.Admin_No.ToString(),
                        fee.Name,
                        fee.Form.ToString(),
                        fee.Class,
                        fee.Amount_Paid.ToString(),
                        fee.Date.ToString("dd MMM yyy"),
                        fee.ModeOfPayment
                    });
                }
            }
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            gData.Rows.Clear();

            var filList = myFee.Where(s =>
                 Regex.IsMatch(s.Admin_No.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Class.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.ModeOfPayment.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                 Regex.IsMatch(s.Form.ToString(), tbSearch.Text, RegexOptions.IgnoreCase)).ToList();
            foreach (var fee in filList)
            {
                gData.Rows.Add(new string[]
                {
                        null,
                        fee.Admin_No.ToString(),
                        fee.Name,
                        fee.Form.ToString(),
                        fee.Class,
                        fee.Amount_Paid.ToString(),
                        fee.Date.ToString("dd MMM yyy"),
                        fee.ModeOfPayment
                });
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            FrmFeePayment frm = new FrmFeePayment();
            frm.ShowDialog();
        }

        //TODO 1 List
        //term & year label
        //the two buttons click events
    }
}
