﻿using System;
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

        #region chartprops
        //set up graph properties 
        public decimal Term1Fee { get; set; }
        public decimal Term2Fee { get; set; }
        public decimal Term3Fee { get; set; }

        public decimal Term1Paid
        {
            get{ return Term1Paid;   }
            set
            {
                Term1Paid = value;
                OnPropertyChanged("Term1Paid");
            }
        }
        public decimal Term2Paid
        {
            get { return Term2Paid; }
            set
            {
                Term2Paid = value;
                OnPropertyChanged("Term2Paid");
            }
        }
        public decimal Term3Paid
        {
            get { return Term3Paid; }
            set
            {
                Term3Paid = value;
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
                    Values = new ChartValues<decimal> { Term1Paid, Term2Paid, Term3Paid }
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
                #endregion 
            }
        }

        private void ChartUpdate(EschoolEntities context, Student_Basic stud)
        {

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

            List<Fee> fees= await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Fees.OrderBy(c => c.FeesId)
                    .Where(x=>x.Admin_No==student.Admin_No)
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
                                    context.Entry<Fee>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                    context.SaveChanges();

                                    // Custom Notification
                                    alert.Show("Deleted", alert.AlertType.warnig);
                                    gData.Rows[e.RowIndex].Visible = false;
                                    //Load the grid again
                                    GridInitilizer();
                                    //Trying to update chart
                                    ChartUpdate(context, student);
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

    }
}
