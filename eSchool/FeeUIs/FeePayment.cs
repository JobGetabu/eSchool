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
        private decimal frpt;
        private int GTerm;
        private int GYear;

        private void lblSet()
        {
            GYear = Properties.Settings.Default.CurrentYear;
            GTerm = Properties.Settings.Default.CurrentTerm;
            lblYear.Text = $"Year: {GYear}";//Year: 2017
            lblTerm.Text = ""; //Term II
            switch (GTerm)
            {
                case 1:
                    lblTerm.Text = "Term I";
                    break;
                case 2:
                    lblTerm.Text = "Term II";
                    break;
                case 3:
                    lblTerm.Text = "Term III";
                    break;
                default:
                    break;
            }
        }
        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.lblRowCount.Text = gData.Rows.Count.ToString();
            //insert images smartly      
            GridIconPicker(gData.Rows[e.RowIndex].Cells[0], gData.Rows[e.RowIndex].Cells["Amount"], gData.Rows[e.RowIndex].Cells["Form"]);
        }

        private void FeePayment_Load(object sender, EventArgs e)
        {
            //Ui code
            FeeUISet();
            this.lblRowCount.Text = gData.Rows.Count.ToString();
            lblSet();
            //populate the grid
            GridInitilizer();

        }

        private void GridIconPicker(DataGridViewCell rPic, DataGridViewCell amountpaid, DataGridViewCell frm)
        {
            string test = (string)amountpaid.Value;
            string t1 = test.Remove(0, 4);
            string t2 = t1.Replace(",", "");
            int cAmount;
            int.TryParse(t2, out cAmount);
            decimal pct = 0;
            int f = int.Parse((string)frm.Value);
            frpt = FeeRequiredAsync(GTerm, GYear, f);
            if (frpt != 0)
            {
                pct = cAmount / frpt * 100;
            }
            if (pct == 100)
            {
                rPic.Value = GridIcon.Happy100;
            }
            else if (pct > 80)
            {
                rPic.Value = GridIcon.ok80;
            }
            else if (pct > 60)
            {
                rPic.Value = GridIcon.ok60;
            }
            else if (pct > 50)
            {
                rPic.Value = GridIcon.Ok50px;
            }
            else if (pct > 20)
            {
                rPic.Value = GridIcon.ok20;
            }
            else
            {
                rPic.Value = GridIcon.sad0;
            }
        }
        List<Fee> myFee;
        public async void GridInitilizer()
        {
            gData.Rows.Clear();

            var feeListAsync = await Task.Factory.StartNew(() =>
            {
                int ct = Properties.Settings.Default.CurrentTerm;
                int cy = Properties.Settings.Default.CurrentYear;
                using (var context = new EschoolEntities())
                {
                    return context.Fees
                    .Where(t => t.Term == ct && t.Year == cy)
                    .OrderBy(t => t.Date)
                    .ToList();
                }
            });
            //runs first
            fRPTermsList();

            // string totalCash = $"KES {String.Format("{0:0,0}", updateTotal)}";
            myFee = new List<Fee>();
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
                        $"KES {String.Format("{0:0,0}", fee.Amount_Paid)}",
                        fee.Date.ToString("dd MMM yyy"),
                        fee.ModeOfPayment
                });
            }
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
                return fRPTerms
                     .Where(f => f.Term == term & f.Year == year & f.Form == form)
                    .ToList()
                    .First().FeeRequired;
            }
            return 0;
        }
        private decimal FeeRequiredAsync(int term, int year)
        {
            if (fRPTerms == null)
            {
                fRPTermsList();
            }
            //decimal runningTotal=0;
            foreach (var fr in fRPTerms)
            {
                return fRPTerms
                     .Where(f => f.Term == term & f.Year == year)
                    .ToList()
                    .Sum(x=>x.FeeRequired);
            }
            return 0;
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
                     Regex.IsMatch(s.Form.ToString(), tbSearch.Text, RegexOptions.IgnoreCase))
                     .OrderBy(t => t.Date)
                     .ToList();
                foreach (var fee in filList)
                {
                    gData.Rows.Add(new string[]
                    {
                        null,
                        fee.Admin_No.ToString(),
                        fee.Name,
                        fee.Form.ToString(),
                        fee.Class,
                        $"KES {String.Format("{0:0,0}", fee.Amount_Paid)}",
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
                 Regex.IsMatch(s.Form.ToString(), tbSearch.Text, RegexOptions.IgnoreCase))
                 .OrderBy(t => t.Date)
                 .ToList();
            foreach (var fee in filList)
            {
                gData.Rows.Add(new string[]
                {
                        null,
                        fee.Admin_No.ToString(),
                        fee.Name,
                        fee.Form.ToString(),
                        fee.Class,
                        $"KES {String.Format("{0:0,0}", fee.Amount_Paid)}",
                        fee.Date.ToString("dd MMM yyy"),
                        fee.ModeOfPayment
                });
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            FrmFeePayment frm = new FrmFeePayment();
            frm.ShowDialog();

            //update ui
            FeeUISet();
        }

        List<int> selForms;
        int filTerm;
        int filYear;
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            FrmFilter frm = new FrmFilter();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                selForms = new List<int>();
                selForms = FrmFilter.selFilForms;
                filTerm = FrmFilter.selFilTerm;
                filYear = FrmFilter.selFilYear;

                //refresh grid with filters
                GridInitilizer(selForms);
                lblSet(filTerm, filYear);
            }
        }

        public async void GridInitilizer(List<int> selForms)
        {
            gData.Rows.Clear();
            selForms = this.selForms;

            var feeListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees
                    .Where(t => t.Term == filTerm & t.Year == filYear)
                    .ToList();
                }
            });

            myFee = new List<Fee>();
            myFee = feeListAsync;
            foreach (int fitem in selForms)
            {
                foreach (var fee in feeListAsync.Where(f => f.Form == fitem))
                {
                    gData.Rows.Add(new string[]
                    {
                        null,
                        fee.Admin_No.ToString(),
                        fee.Name,
                        fee.Form.ToString(),
                        fee.Class,
                        $"KES {String.Format("{0:0,0}", fee.Amount_Paid)}",
                        fee.Date.ToString("dd MMM yyy"),
                        fee.ModeOfPayment
                    });
                }
            }
        }
        private void lblSet(int filTerm, int filYear)
        {
            lblYear.Text = $"Year: {filYear}";//Year: 2017
            lblTerm.Text = ""; //Term II
            switch (filTerm)
            {
                case 1:
                    lblTerm.Text = "Term I";
                    break;
                case 2:
                    lblTerm.Text = "Term II";
                    break;
                case 3:
                    lblTerm.Text = "Term III";
                    break;
                default:
                    break;
            }
        }

        public async void FeeUISet()
        {
            FeesUI feeui = FeesUI.Instance;

            using (var context = new EschoolEntities())
            {
                var feeListAsync = await Task.Factory.StartNew(() =>
                    {
                        return context.Fees
                        .ToList();

                    });
                var studentList = await Task.Factory.StartNew(() =>
                {
                    return context.Student_Basic.ToList();
                });

                int studentsCount = studentList.Count;
                var fees = feeListAsync.Select(a => a.Admin_No);

                var studentFees = studentList.SelectMany(
                                    (stud) =>
                                    feeListAsync.Where(a => a.Admin_No == stud.Admin_No)
                                                .Select(a => new { FoundAdminNo = a.Admin_No }));


                int registeredStudents = fees.Distinct().Count();

                decimal pcg = decimal.Divide(registeredStudents, studentsCount) * 100;
                

                decimal pcgRegistered = decimal.Round(pcg);
                feeui.bunifuCircleProgressbarRegistered.Value = int.Parse(pcgRegistered.ToString());


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
                decimal feeForTermTotal= FeeRequiredAsync(GTerm,GYear);

                feeui.lblRequred.Text = $"{String.Format("{0:0,0}", feeForTermTotal)}";
                decimal paidTotal = 0;
                int countCleared = 0;
                foreach (var item in result)
                {
                    var i = item.Sum;
                    if (i >= FeeRequiredAsync(GTerm, GYear,item.sForm))
                    {
                        countCleared += 1;
                    }
                    paidTotal += i;
                }

                decimal pcgClr = decimal.Divide(countCleared, registeredStudents) * 100;
                decimal pcgCleared = decimal.Round(pcgClr);


                feeui.bunifuCircleProgressbarCleared.Value = int.Parse(pcgCleared.ToString());

                feeui.lblPaid.Text = $"{String.Format("{0:0,0}", paidTotal)}";

                decimal pcgPerf = decimal.Divide(paidTotal, feeForTermTotal) * 100;
                decimal pcgpcgPerf = decimal.Round(pcgPerf);
                feeui.perfPercentage.Text = $"{pcgpcgPerf.ToString()}%";// i.e 93%


                //var Fees = feeListAsync.SelectMany(
                //                    (fee) =>
                //                    studentList.Where(a => a.Admin_No == fee.Admin_No)
                //                                .Select(a => new { FoundAdminNo = a.Admin_No }));

                //var joined2 = from s in studentList
                //              join f in feeListAsync
                //              on s.Admin_No equals f.Admin_No

                //              select new { FoundAdminNo = s.Admin_No, FeeID = f.FeesId };

                //registered 
            }
        }
    }
}
