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
    public partial class MonthlyOverview : UserControl, INotifyPropertyChanged
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

        private ChartValues<decimal> cIncome;
        private ChartValues<decimal> cExpenses;

        #region var declaration
        decimal incDay0 = 0; decimal incDay5 = 0; decimal incDay10 = 0;
        decimal incDay15 = 0; decimal incDay20 = 0; decimal incDay25 = 0;
        decimal incDayLast = 0;

        decimal expDay0 = 0; decimal expDay5 = 5; decimal expDay10 = 10;
        decimal expDay15 = 15; decimal expDay20 = 20; decimal expDay25 = 25;
        decimal expDayLast = 0;
        #endregion


        //set up property value for chart
        #region Properties
        private decimal IncDay0
        {
            get { return incDay0; }
            set
            {
                incDay0 = value;
                OnPropertyChanged("IncDay0");
            }
        }
        private decimal IncDay5
        {
            get { return incDay5; }
            set
            {
                incDay5 = value;
                OnPropertyChanged("IncDay5");
            }
        }
        private decimal IncDay10
        {
            get { return incDay10; }
            set
            {
                incDay10 = value;
                OnPropertyChanged("IncDay10");
            }
        }
        public decimal IncDay15
        {
            get { return incDay15; }
            set
            {
                incDay15 = value;
                OnPropertyChanged("IncDay15");
            }
        }
        public decimal IncDay20
        {
            get { return incDay20; }
            set
            {
                incDay20 = value;
                OnPropertyChanged("IncDay20");
            }
        }
        public decimal IncDay25
        {
            get { return incDay25; }
            set
            {
                incDay25 = value;
                OnPropertyChanged("IncDay25");
            }
        }
        public decimal IncDayLast
        {
            get { return incDayLast; }
            set
            {
                incDayLast = value;
                OnPropertyChanged("IncDayLast");
            }
        }

        public decimal ExpDay0
        {
            get { return expDay0; }
            set
            {
                expDay0 = value;
                OnPropertyChanged("ExpDay0");
            }
        }
        public decimal ExpDay5
        {
            get { return expDay5; }
            set
            {
                expDay5 = value;
                OnPropertyChanged("ExpDay5");
            }
        }
        public decimal ExpDay10
        {
            get { return expDay0; }
            set
            {
                expDay10 = value;
                OnPropertyChanged("ExpDay10");
            }
        }

        public decimal ExpDay15
        {
            get { return expDay15; }
            set
            {
                expDay15 = value;
                OnPropertyChanged("ExpDay15");
            }
        }

        public decimal ExpDay20
        {
            get { return expDay20; }
            set
            {
                expDay20 = value;
                OnPropertyChanged("ExpDay20");
            }
        }

        public decimal ExpDay25
        {
            get { return expDay25; }
            set
            {
                expDay25 = value;
                OnPropertyChanged("ExpDay25");
            }
        }

        public decimal ExpDayLast
        {
            get { return expDayLast; }
            set
            {
                expDayLast = value;
                OnPropertyChanged("ExpDayLast");
            }
        }
        #endregion

        public void Global_MonthlyOverview()
        {
            UpdateMyChart();
        }
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




                #region var init



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
                IncDay0 = incomeListAsync.Where(x => x.Date == firstDayOfMonth).Sum(a => a.Amount);
                IncDay5 = incomeListAsync.Where(x => x.Date.Day > 1 & x.Date.Day < 6).ToList().Sum(a => a.Amount);
                IncDay10 = incomeListAsync.Where(x => x.Date.Day > 5 & x.Date.Day < 11).ToList().Sum(a => a.Amount);
                IncDay15 = incomeListAsync.Where(x => x.Date.Day > 10 & x.Date.Day < 16).ToList().Sum(a => a.Amount);
                IncDay20 = incomeListAsync.Where(x => x.Date.Day > 15 & x.Date.Day < 26).ToList().Sum(a => a.Amount);
                IncDay25 = incomeListAsync.Where(x => x.Date.Day > 25 & x.Date.Day < 31).ToList().Sum(a => a.Amount);
                IncDayLast = incomeListAsync.Where(x => x.Date.Day == lastDayOfMonth.Day).ToList().Sum(a => a.Amount);

                //Days for expense
                ExpDay0 = expListAsync.Where(x => x.Date == firstDayOfMonth).Sum(a => a.Amount);
                ExpDay5 = expListAsync.Where(x => x.Date.Day > 1 & x.Date.Day < 6).ToList().Sum(a => a.Amount);
                ExpDay10 = expListAsync.Where(x => x.Date.Day > 5 & x.Date.Day < 11).ToList().Sum(a => a.Amount);
                ExpDay15 = expListAsync.Where(x => x.Date.Day > 10 & x.Date.Day < 16).ToList().Sum(a => a.Amount);
                ExpDay20 = expListAsync.Where(x => x.Date.Day > 15 & x.Date.Day < 26).ToList().Sum(a => a.Amount);
                ExpDay25 = expListAsync.Where(x => x.Date.Day > 25 & x.Date.Day < 31).ToList().Sum(a => a.Amount);
                ExpDayLast = expListAsync.Where(x => x.Date.Day == lastDayOfMonth.Day).ToList().Sum(a => a.Amount);

                #endregion

                cIncome = new ChartValues<decimal> { incDay0, incDay5, incDay10, incDay15, incDay20, incDay25, incDayLast };
                cExpenses = new ChartValues<decimal> { expDay0, expDay5, expDay10, expDay15, expDay20, expDay25, expDayLast };
                cartesianChart1.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Incomes",
                        Values = cIncome
            },
                     new LineSeries
                     {
                         Title = "Expenses",
                         Values = cExpenses,
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
                    LabelFormatter = value => $"KES {String.Format("{0:0,0}", value)}"
                    //value.ToString("C3", CultureInfo.CreateSpecificCulture("sw-KE"))
                });

                cartesianChart1.LegendLocation = LegendLocation.Right;
            }
        }

        private async void UpdateMyChart()
        {
            using (var context = new EschoolEntities())
            {
                var studentList = await Task.Factory.StartNew(() =>
                {
                    return context.Student_Basic.ToList();
                });

                int studentsCount = studentList.Count;

                lblStudents.Text = (studentsCount).ToString();

                //TODO find the no of users in the system 
                var usersList = await Task.Factory.StartNew(() =>
                {
                    return context.Login_Users.ToList();
                });

                int usersCount = usersList.Count;

                lblUsers.Text = (usersCount).ToString();

                //chart area below
                //set of monthly variables days = 30 or 31 || 28 interval = 5

                var GMonth = DateTime.Now.Month;

                var firstDayOfMonth = new DateTime(GYear, GMonth, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var incomeListAsync = await Task.Factory.StartNew(() =>
                {
                    return context.Incomes.Where(x => x.Year == GYear & x.Term == GTerm & x.Date.Month == GMonth)
                   .ToList();
                });

                var expListAsync = await Task.Factory.StartNew(() =>
                {
                    return context.Expenses.Where(x => x.Year == GYear & x.Term == GTerm & x.Date.Month == GMonth)
                    .ToList();
                });


                //Days for income
                IncDay0 = incomeListAsync.Where(x => x.Date == firstDayOfMonth).Sum(a => a.Amount);
                IncDay5 = incomeListAsync.Where(x => x.Date.Day > 1 & x.Date.Day < 6).ToList().Sum(a => a.Amount);
                IncDay10 = incomeListAsync.Where(x => x.Date.Day > 5 & x.Date.Day < 11).ToList().Sum(a => a.Amount);
                IncDay15 = incomeListAsync.Where(x => x.Date.Day > 10 & x.Date.Day < 16).ToList().Sum(a => a.Amount);
                IncDay20 = incomeListAsync.Where(x => x.Date.Day > 15 & x.Date.Day < 26).ToList().Sum(a => a.Amount);
                IncDay25 = incomeListAsync.Where(x => x.Date.Day > 25 & x.Date.Day < 31).ToList().Sum(a => a.Amount);
                IncDayLast = incomeListAsync.Where(x => x.Date.Day == lastDayOfMonth.Day).ToList().Sum(a => a.Amount);

                //Days for expense
                ExpDay0 = expListAsync.Where(x => x.Date == firstDayOfMonth).Sum(a => a.Amount);
                ExpDay5 = expListAsync.Where(x => x.Date.Day > 1 & x.Date.Day < 6).ToList().Sum(a => a.Amount);
                ExpDay10 = expListAsync.Where(x => x.Date.Day > 5 & x.Date.Day < 11).ToList().Sum(a => a.Amount);
                ExpDay15 = expListAsync.Where(x => x.Date.Day > 10 & x.Date.Day < 16).ToList().Sum(a => a.Amount);
                ExpDay20 = expListAsync.Where(x => x.Date.Day > 15 & x.Date.Day < 26).ToList().Sum(a => a.Amount);
                ExpDay25 = expListAsync.Where(x => x.Date.Day > 25 & x.Date.Day < 31).ToList().Sum(a => a.Amount);
                ExpDayLast = expListAsync.Where(x => x.Date.Day == lastDayOfMonth.Day).ToList().Sum(a => a.Amount);


                var cin = new ChartValues<decimal> { incDay0, incDay5, incDay10, incDay15, incDay20, incDay25, incDayLast };
                var exp = new ChartValues<decimal> { expDay0, expDay5, expDay10, expDay15, expDay20, expDay25, expDayLast };

                cIncome.Clear();
                cExpenses.Clear();
                cExpenses.AddRange(exp);
                cIncome.AddRange(cin);
            }
        }

        //public event Action PointChanged;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //DashboardUI das = DashboardUI.Instance;
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
