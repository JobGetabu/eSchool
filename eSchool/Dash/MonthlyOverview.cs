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
using System.Globalization;

namespace eSchool.Dash
{
    public partial class MonthlyOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static MonthlyOverview _instance;
        public static MonthlyOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MonthlyOverview();
                }
                return _instance;
            }
        }
        public MonthlyOverview()
        {
            InitializeComponent();

            MonthlyUISet();
        }

        int GTerm = Properties.Settings.Default.CurrentTerm;
        int GYear = Properties.Settings.Default.CurrentYear;

        private void MonthlyOverview_Load(object sender, EventArgs e)
        {
            lblMonth.Text = $"{DateTime.Now.ToString("MMMM")} Transaction"; ;//Nov Transaction
        }

        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))   // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(year, month, day)) // Map each day to a date
                             .ToList(); // Load dates into a list
        }

        
        public void MonthlyUISet()
        {
            using (var context = new EschoolEntities())
            {
                var studentList =
                     context.Student_Basic.ToList();


                int studentsCount = studentList.Count;

                lblStudents.Text = (studentsCount).ToString();

                //TODO find the no of users in the system 
                var usersList =
                     context.Login_Users.ToList();


                int usersCount = usersList.Count;

                lblUsers.Text = (usersCount).ToString();

                //chart area below
                //set of monthly variables days = 30 or 31 || 28 interval = 5

                var GMonth = DateTime.Now.Month;


                var firstDayOfMonth = new DateTime(GYear, GMonth, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

              


                #region var declarations
                decimal incDay0 = 0; decimal incDay5 = 0; decimal incDay10 = 0;
                decimal incDay15 = 0; decimal incDay20 = 0; decimal incDay25 = 0;
                decimal incDayLast = 0;

                decimal expDay0 = 0; decimal expDay5 = 5; decimal expDay10 = 10;
                decimal expDay15 = 15; decimal expDay20 = 20; decimal expDay25 = 25;
                decimal expDayLast = 0;


                var incomeListAsync =
                    context.Incomes.Where(x => x.Year == GYear & x.Term == GTerm & x.Date.Month == GMonth)
                   .ToList();

                var incomeListAsync2 =
                   context.Incomes
                  .ToList();

                var expListAsync =
                    context.Expenses.Where(x => x.Year == GYear & x.Term == GTerm & x.Date.Month == GMonth)
                    .ToList();

                //Days for income
                incDay0 = incomeListAsync.Where(x => x.Date == firstDayOfMonth).Sum(a => a.Amount);
                incDay5 = incomeListAsync.Where(x => x.Date.Day > 1 & x.Date.Day < 6).ToList().Sum(a => a.Amount);
                incDay10 = incomeListAsync.Where(x => x.Date.Day > 5 & x.Date.Day < 11).ToList().Sum(a => a.Amount);
                incDay15 = incomeListAsync.Where(x => x.Date.Day > 10 & x.Date.Day < 16).ToList().Sum(a => a.Amount);
                incDay20 = incomeListAsync.Where(x => x.Date.Day > 15 & x.Date.Day < 26).ToList().Sum(a => a.Amount);
                incDay25 = incomeListAsync.Where(x => x.Date.Day > 25 & x.Date.Day < 31).ToList().Sum(a => a.Amount);
                incDayLast = incomeListAsync.Where(x =>x.Date.Day == lastDayOfMonth.Day).ToList().Sum(a => a.Amount);

                //Days for expense
                expDay0 = expListAsync.Where(x => x.Date == firstDayOfMonth).Sum(a => a.Amount);
                expDay5 = expListAsync.Where(x => x.Date.Day > 1 & x.Date.Day < 6).ToList().Sum(a => a.Amount);
                expDay10 = expListAsync.Where(x => x.Date.Day > 5 & x.Date.Day < 11).ToList().Sum(a => a.Amount);
                expDay15 = expListAsync.Where(x => x.Date.Day > 10 & x.Date.Day < 16).ToList().Sum(a => a.Amount);
                expDay20 = expListAsync.Where(x => x.Date.Day > 15 & x.Date.Day < 26).ToList().Sum(a => a.Amount);
                expDay25 = expListAsync.Where(x => x.Date.Day > 25 & x.Date.Day < 31).ToList().Sum(a => a.Amount);
                expDayLast = expListAsync.Where(x => x.Date.Day == lastDayOfMonth.Day).ToList().Sum(a => a.Amount);

                #endregion

                cartesianChart1.Series = new SeriesCollection
             {
                    new LineSeries
                    {
                        Title = "Incomes",
                        Values = new ChartValues<decimal> { incDay0,incDay5,incDay10,incDay15,incDay20,incDay25,incDayLast}
                    },
                     new LineSeries
                    {
                        Title = "Expenses",
                        Values = new ChartValues<decimal> { expDay0,expDay5,expDay10,expDay15,expDay20,expDay25,expDayLast },
                        PointGeometry = null
                    }
                };

                cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Days",
                    Labels = new[] { "0", "5", "10", "15", "20", "25", "30" }
                });

                cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Amount",
                    LabelFormatter = value => value.ToString("C3", CultureInfo.CreateSpecificCulture("sw-KE"))
                });

                cartesianChart1.LegendLocation = LegendLocation.Right;
            }
        }
    }
}
