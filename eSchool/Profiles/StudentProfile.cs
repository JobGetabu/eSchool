using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using eSchool.Importss;
using System.IO;
using MetroFramework;
using custom_alert_notifications;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using LiveCharts.Defaults;
using eSchool.ReceiptPrints;

namespace eSchool.Profiles
{
    public partial class StudentProfile : UserControl
    {
        static Student_Basic student = new Student_Basic();
        private static StudentProfile _instance;
        public static StudentProfile Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentProfile(student);
                }
                return _instance;
            }
            set
            {
                _instance = new StudentProfile(student);
            }
        }

        int GYear = Properties.Settings.Default.CurrentYear;
        int GTerm = Properties.Settings.Default.CurrentTerm;

        private ChartValues<decimal> MyValues;
        //private ObservableValue MyValue2;
        //private ObservableValue MyValue3;

        #region chartprops
        //set up graph properties 
        public decimal Term1Fee { get; set; }
        public decimal Term2Fee { get; set; }
        public decimal Term3Fee { get; set; }

        private decimal term1Paid = 0;
        private decimal term2Paid = 0;
        private decimal term3Paid = 0;
        public decimal Term1Paid
        {
            get { return term1Paid; }

            set
            {
                term1Paid = value;
                OnPropertyChanged("Term1Paid");
            }
        }
        public decimal Term2Paid
        {
            get { return term2Paid; }
            set
            {
                term2Paid = value;
                OnPropertyChanged("Term2Paid");
            }
        }
        public decimal Term3Paid
        {
            get { return term3Paid; }
            set
            {
                term3Paid = value;
                OnPropertyChanged("Term3Paid");
            }
        }


        #endregion

        private string name;   //Ben Carson New
        private string school; //EschoolKe Secondary - 20154245   
        private string reg;    //Reg NO - 17052  
        private string mol;    //Mode of Learning - Bording
        private string date;   //Admitted - 12/05/2013
        string path = "";


        private void SetUpChart()
        {
            int count = 0;
            using (var context = new EschoolEntities())
            {

                ChartValues<decimal> editVarPaid = new ChartValues<decimal>();
                ChartValues<decimal> editVarRqd = new ChartValues<decimal>();
                List<string> chartLbls = new List<string>();

                for (int i = student.RegYear.Value; i <= GYear; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (count == 0)
                        {
                            j = student.RegTerm.Value;
                        }
                        if (GYear == i & GTerm == j)
                        {
                            //last bit

                            //set up fee info
                            decimal editfrpt = context.FeesRequiredPerTerms
                               .Where(x => x.Year == i & x.Term == j & x.Form == student.Form)
                               .Select(x => x.FeeRequired)
                               .FirstOrDefault();

                            decimal editTerm1Paid1 = context.Fees
                              .Where(x => x.Admin_No == student.Admin_No & x.Year == i & x.Term == j)
                              .Select(x => x.Amount_Paid)
                              .ToList()
                              .Sum();

                            editVarPaid.Add(editTerm1Paid1);
                            editVarRqd.Add(editfrpt);
                            chartLbls.Add($"{i}\nTerm {j}");

                            Console.WriteLine($"=>Period{count} Year {i} Term {j}");
                            break;

                        }
                        //set up fee info
                        decimal editfrpt1 = context.FeesRequiredPerTerms
                           .Where(x => x.Year == i & x.Term == j & x.Form == student.Form)
                           .Select(x => x.FeeRequired)
                           .FirstOrDefault();

                        decimal editTerm1Paid = context.Fees
                          .Where(x => x.Admin_No == student.Admin_No & x.Year == i & x.Term == j)
                          .Select(x => x.Amount_Paid)
                          .ToList()
                          .Sum();

                        editVarPaid.Add(editTerm1Paid);
                        editVarRqd.Add(editfrpt1);
                        chartLbls.Add($"{i}\nTerm {j}");

                        Console.WriteLine($"Period{count} Year {i} Term {j}");
                        count += 1;
                    }
                }

                MyValues = editVarPaid;
                cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Fee Required",
                    Values = editVarRqd
                }
            };

                //adding series will update and animate the chart automatically
                cartesianChart1.Series.Add(new ColumnSeries
                {
                    Title = "Paid",
                    Values = MyValues
                });

                //also adding values updates and animates the chart automatically
                //cartesianChart1.Series[1].Values.Add(48d);

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Periods",
                    Labels = chartLbls
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Amount",
                    LabelFormatter = value => $"KES {String.Format("{0:0,0}", value)}"

                });
            }
        }
        public StudentProfile(Student_Basic stud)
        {
            InitializeComponent();
            student = stud;

            name = $"{stud.First_Name} {stud.Middle_Name} {stud.Last_Name}";
            school = $"{Properties.Settings.Default.schoolName} - {Properties.Settings.Default.schoolreg}";
            reg = $"Reg NO - {stud.Admin_No}";
            mol = $"Mode of Learning - {stud.ModeOfLearning}";

            date = $"Admitted - Term {stud.RegTerm} {stud.RegYear}";



            using (var context = new EschoolEntities())
            {
                decimal frpt1 = context.FeesRequiredPerTerms
                            .Where(x => x.Year == GYear & x.Term == 1 & x.Form == stud.Form)
                            .Select(x => x.FeeRequired)
                            .FirstOrDefault();
                decimal frpt2 = context.FeesRequiredPerTerms
                            .Where(x => x.Year == GYear & x.Term == 2 & x.Form == stud.Form)
                            .Select(x => x.FeeRequired)
                            .FirstOrDefault();
                decimal frpt3 = context.FeesRequiredPerTerms
                            .Where(x => x.Year == GYear & x.Term == 3 & x.Form == stud.Form)
                            .Select(x => x.FeeRequired)
                            .FirstOrDefault();





                Term1Paid = context.Fees
                           .Where(x => x.Admin_No == stud.Admin_No & x.Year == GYear & x.Term == 1)
                           .Select(x => x.Amount_Paid)
                           .ToList()
                           .Sum();

                Term2Paid = context.Fees
                           .Where(x => x.Admin_No == stud.Admin_No & x.Year == GYear & x.Term == 2)
                           .Select(x => x.Amount_Paid)
                           .ToList()
                           .Sum();
                Term3Paid = context.Fees
                           .Where(x => x.Admin_No == stud.Admin_No & x.Year == GYear & x.Term == 3)
                           .Select(x => x.Amount_Paid)
                           .ToList()
                           .Sum();

                #region chart
                /*
                cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Fee Required",
                    Values = new ChartValues<decimal> { frpt1, frpt2, frpt3 }
                }
            };

                //adding series will update and animate the chart automatically
                cartesianChart1.Series.Add(new ColumnSeries
                {
                    Title = "Paid",
                    Values = MyValues
                });

                //also adding values updates and animates the chart automatically
                //cartesianChart1.Series[1].Values.Add(48d);

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Periods",
                    Labels = new[] { "Term 1", "Term 2", "Term 3" }
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Amount",
                    LabelFormatter = value => $"KES {String.Format("{0:0,0}", value)}"

                });
                */
                #endregion

                SetUpChart();
            }
        }

        private void ChartUpdate(EschoolEntities context, Student_Basic stud)
        {
            int count = 0;
            using (var contexts = new EschoolEntities())
            {

                ChartValues<decimal> editVarPaid = new ChartValues<decimal>();

                for (int i = student.RegYear.Value; i <= GYear; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (count == 0)
                        {
                            j = student.RegTerm.Value;
                        }
                        if (GYear == i & GTerm == j)
                        {
                            //last bit

                            decimal editTerm1Paid1 = context.Fees
                              .Where(x => x.Admin_No == student.Admin_No & x.Year == i & x.Term == j)
                              .Select(x => x.Amount_Paid)
                              .ToList()
                              .Sum();

                            editVarPaid.Add(editTerm1Paid1);

                            break;

                        }


                        decimal editTerm1Paid = context.Fees
                          .Where(x => x.Admin_No == student.Admin_No & x.Year == i & x.Term == j)
                          .Select(x => x.Amount_Paid)
                          .ToList()
                          .Sum();

                        editVarPaid.Add(editTerm1Paid);
                        count += 1;
                    }
                }

                MyValues.Clear();
                MyValues.AddRange(editVarPaid);
            }
        }

        public void Global_StudentProfile_Load()
        {

        }
        private void StudentProfile_Load(object sender, EventArgs e)
        {
            //change color of INX to green
            gData.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            gData.Columns[5].DefaultCellStyle.ForeColor = Color.Blue;

            lblName.Text = name;
            lblSchoolAndNo.Text = school;
            lblRegno.Text = reg;
            lblMOL.Text = mol;
            lblRegDate.Text = date;

            //set up picture
            if (String.IsNullOrEmpty(student.PictureLocation))
            {
                path = "";
                ovalPictureBox1.Image = GridIcon.student;
            }
            else
            {
                if (File.Exists(student.PictureLocation))
                {
                    path = student.PictureLocation;
                    try
                    {

                        var y = Image.FromFile(student.PictureLocation);
                        this.ovalPictureBox1.Image = y;
                        this.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
                else
                {
                    ovalPictureBox1.Image = GridIcon.student;
                }
            }

            GridInitilizer();

            OverallPayments();
        }

        //nav
        private void TabSwitcher(Control UIinstance)
        {
            if (!NewImportsUI.Instance.container.Controls.Contains(UIinstance))
            {
                NewImportsUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        EschoolEntities db = new EschoolEntities();


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            //under auto modification 
            student.PictureLocation = path;
            db.Entry<Student_Basic>(student).State = EntityState.Modified;

            //back to import UI
            //show students data UI
            TabSwitcher(StudentsData.Instance);

            try
            {
                //save edited student
                db.SaveChanges();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            db.Dispose();
        }


        private void btnChangePic_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog opf = new OpenFileDialog()
                { Filter = "Picture|*.jpg|*.JPEG|*.png", ValidateNames = true, Multiselect = false })
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        this.ovalPictureBox1.Image = Image.FromFile(opf.FileName);
                        this.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        path = opf.FileName;
                    }

                    // short Custom Notification
                    alert.Show("Updated", alert.AlertType.success);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MetroMessageBox.Show(this, $"Are You Sure You Want To Delete This Student Record !", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                try
                {
                    db.Entry<Student_Basic>(student).State = EntityState.Deleted;
                    //save edited student
                    db.SaveChanges();

                    // short Custom Notification
                    alert.Show("Deleted", alert.AlertType.warnig);

                    //refresh grids
                    StudentsData d = StudentsData.Instance;
                    d.GridInitilizer();

                    //back to import UI
                    //show students data UI
                    TabSwitcher(StudentsData.Instance);
                    db.Dispose();
                }
                catch (DbUpdateException)
                {
                    MetroMessageBox.Show(this, "Can not delete this student \n There are related fee payment records", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Something went wrong \n" + exp.Message, "Unsuccessful");
                    throw;
                }
            }
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            FrmEditStudent fes = new FrmEditStudent(student);
            fes.ShowDialog();


        }

        private string AccType(List<Account> accs, int accId)
        {
            String m = "";
            Account d = accs.Where(x => x.Id == accId).FirstOrDefault();
            if (d != null)
            {
                m = $"{d.AccName} \n ({d.AccNo})";
            }
            return m;
        }
        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.gData.Rows[e.RowIndex].Cells[6].Value = GridIcon.Trash_Can_50px;
        }

        public async void GridInitilizer()
        {
            this.gData.Rows.Clear();

            List<Fee> fees = await Task.Factory.StartNew(() =>
             {
                 using (var context = new EschoolEntities())
                 {
                     return context.Fees.OrderBy(c => c.FeesId)
                     .Where(x => x.Admin_No == student.Admin_No)
                     .ToList();
                 }
             });

            List<Account> accs = await Task.Factory.StartNew(() =>
             {
                 using (var context = new EschoolEntities())
                 {
                     return context.Accounts
                     .ToList();
                 }
             });

            this.gData.Rows.Clear();
            foreach (var f in fees)
            {
                gData.Rows.Add(new string[]
                {
                        f.Date.ToString("dd MMM yyy"),
                        $"Payment for {f.Year} Form {f.Form} Term {f.Term} fees",
                        $"KES {String.Format("{0:0,0}", f.Amount_Paid)}",
                        AccType(accs,f.Acc_Fk.Value),
                        $"FPY0{f.FeesId}",
                        "View Receipt",
                        null
                });
            }
        }

        private async Task<Fee> GridDelImageAsync(int rowIndex)
        {
            List<Fee> fees = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees
                    .Where(x => x.Admin_No == student.Admin_No)
                    .ToList();
                }
            });

            string details;
            details = (string)this.gData.Rows[rowIndex].Cells[4].Value;
            string test = details;
            string t1 = test.Remove(0, 4);
            t1.TrimEnd();

            foreach (var fi in fees)
            {
                if (fi.FeesId == int.Parse(t1))
                {
                    return fi;
                }
            }
            return null;
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

 
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                if ((MetroMessageBox.Show(this, $"Are You Sure You Want To Delete This Fee Payment Record ! \nThis action is irreversible", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes))
                                {
                                    //Deduct amount in the account
                                    string acs = this.gData.Rows[e.RowIndex].Cells[3].Value.ToString();
                                    Account accAssociated = FindSelAccount(acs);
                                    if (accAssociated != null)
                                    {
                                        accAssociated.Amount -= (await GridDelImageAsync(e.RowIndex)).Amount_Paid;

                                        context.Entry<Account>(accAssociated).State = EntityState.Modified;
                                    }

                                    context.Entry<Fee>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;

                                    context.SaveChanges();

                                    // Custom Notification
                                    alert.Show("Deleted", alert.AlertType.warnig);
                                    gData.Rows[e.RowIndex].Visible = false;
                                    //Load the grid again
                                    GridInitilizer();
                                    //Trying to update chart
                                    ChartUpdate(context, student);
                                    //update balances
                                    OverallPayments();
                                }

                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");
                            }
                        }
                    }
                }
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewLinkCell && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    PrintService(e.RowIndex);
                }
            }
        }


        //local but global
        private decimal psBalance =0;
        private decimal psCredit = 0;
        private async void PrintService(int rowIndex)
        {
            List<Fee> fees = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees
                    .Where(x => x.Admin_No == student.Admin_No)
                    .ToList();
                }
            });

            string details;
            details = (string)this.gData.Rows[rowIndex].Cells[4].Value;
            string test = details;
            string t1 = test.Remove(0, 4);
            t1.TrimEnd();

            Fee cFee = null;
            foreach (var fi in fees)
            {
                if (fi.FeesId == int.Parse(t1))
                {
                    cFee= fi;
                }
            }

            if (cFee != null)
            {
                //look for the fee structure associated
                GroupedFeeStructure grpFs = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.GroupedFeeStructures
                        .Where(x => x.selTerm == cFee.Term & x.selYear == cFee.Year)
                        .FirstOrDefault(x => x.selFm1 == cFee.Form | x.selFm2 == cFee.Form | x.selFm3 == cFee.Form | x.selFm4 == cFee.Form);
                    }
                });
                //look for associted required fee that term
                FeesRequiredPerTerm frpt = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.FeesRequiredPerTerms
                        .Where(x => x.Term == cFee.Term & x.Year == cFee.Year & x.Form == cFee.Form)
                        .FirstOrDefault( );
                    }
                });

                //look for list of overheadcatperyear associated
                List<OverHeadCategoryPerYear> ovCpyear = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.OverHeadCategoryPerYears
                        .Where(x => x.Term == cFee.Term & x.Year == cFee.Year & x.Form == cFee.Form)
                        .ToList();
                    }
                });

                //var listOverheads = ovCpyear.Select(x => x.Category).Distinct();
                List<PaymentOverheads> listPayOv = new List<PaymentOverheads>();
                foreach (var item in ovCpyear)
                {
                    PaymentOverheads p = new PaymentOverheads();
                    p.Overhead = item.Category;
                    decimal t = Decimal.Divide(item.Amount, frpt.FeeRequired) * cFee.Amount_Paid;
                    p.Amount = t;

                    listPayOv.Add(p);
                }

                //student details
                StudentDetails sdd = new StudentDetails(student);

                //payment details
                PaymentDetails payee = new PaymentDetails();
                payee.FeeId = details;
                if (psBalance > 0)
                {
                    payee.Status = "Uncleared";
                }
                payee.Balance= $"Balance: KES {String.Format("{0:0,0}", psBalance)}";
                payee.Credit = $"Credit: KES {String.Format("{0:0,0}", psCredit)}";

                FrmPaymentReceipt fpr = new FrmPaymentReceipt(listPayOv, payee, sdd);
                fpr.ShowDialog();
            }
        }

        //public event Action PointChanged;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var eventToRaise = PropertyChanged;
            if (eventToRaise != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Account FindSelAccount(String account)
        {
            // account = Equity(075465156)
            using (var context = new EschoolEntities())
            {
                var accListAsync = context.Accounts.ToList();

                foreach (var c in accListAsync)
                {
                    string f = ($"{c.AccName} \n ({c.AccNo})");
                    if (account.Equals(f))
                    {
                        return c;
                    }
                }
            }
            return null;
        }


        //calculation of overall payment
        private async void OverallPayments()
        {
            decimal amountsRqd = await AmountRequiredToBePaid();
            decimal amountsPaid = await AmountPaidToNow();

            decimal ggg = Decimal.Subtract(amountsRqd, amountsPaid);

            if (ggg < 0)
            {
                //Credit: KES 0
                lblCredit.Text = $"Credit: KES {String.Format("{0:0,0}", Decimal.Negate(ggg))}";
                psCredit = Decimal.Negate(ggg);
            }
            else
            {
                //Balances: KES 0
                lblBalance.Text = $"Balances: KES {String.Format("{0:0,0}", ggg)}";
                psBalance = ggg;
            }

        }

        private async Task<decimal> AmountPaidToNow()
        {
            int count = 0;
            decimal runningAmount = 0;
            using (var context = new EschoolEntities())
            {
                for (int i = student.RegYear.Value; i <= GYear; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (count == 0)
                        {
                            j = student.RegTerm.Value;
                        }
                        if (GYear == i & GTerm == j)
                        {
                            //set up fee info
                            decimal editPaid = await Task.Factory.StartNew(() =>
                            {
                                return
                               context.Fees
                                  .Where(x => x.Admin_No == student.Admin_No & x.Year == i & x.Term == j)
                                  .Select(x => x.Amount_Paid)
                                  .ToList()
                                  .Sum();
                            });

                            runningAmount += editPaid;

                            //Console.WriteLine($"=>Period{count} Year {i} Term {j}");
                            break;
                        }

                        //set up fee info
                        decimal editPaid1 = await Task.Factory.StartNew(() =>
                        {
                            return
                           context.Fees
                              .Where(x => x.Admin_No == student.Admin_No & x.Year == i & x.Term == j)
                              .Select(x => x.Amount_Paid)
                              .ToList()
                              .Sum();
                        });

                        runningAmount += editPaid1;
                        count += 1;
                    }
                }
            }

            return runningAmount;
        }

        private async Task<decimal> AmountRequiredToBePaid()
        {
            int count = 0;
            decimal runningAmount = 0;
            using (var context = new EschoolEntities())
            {
                for (int i = student.RegYear.Value; i <= GYear; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (count == 0)
                        {
                            j = student.RegTerm.Value;
                        }
                        if (GYear == i & GTerm == j)
                        {
                            //set up fee info
                            decimal editfrpt = await Task.Factory.StartNew(() =>
                            {
                                return context.FeesRequiredPerTerms
                                .Where(x => x.Year == i & x.Term == j & x.Form == student.Form)
                                .Select(x => x.FeeRequired)
                                .FirstOrDefault();
                            });

                            runningAmount += editfrpt;

                            //Console.WriteLine($"=>Period{count} Year {i} Term {j}");
                            break;
                        }

                        //set up fee info
                        decimal editfrpt1 = await Task.Factory.StartNew(() =>
                        {
                            return context.FeesRequiredPerTerms
                            .Where(x => x.Year == i & x.Term == j & x.Form == student.Form)
                            .Select(x => x.FeeRequired)
                            .FirstOrDefault();
                        });

                        runningAmount += editfrpt1;
                        count += 1;
                    }
                }
            }

            return runningAmount;
        }
    }
}
