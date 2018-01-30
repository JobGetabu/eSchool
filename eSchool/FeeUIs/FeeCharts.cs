using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;

namespace eSchool.FeeUIs
{
    public partial class FeeCharts : UserControl
    {

        private static FeeCharts _instance;
        public static FeeCharts Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeeCharts();
                }
                return _instance;
            }
        }

        int GTerm = Properties.Settings.Default.CurrentTerm;
        int GYear = Properties.Settings.Default.CurrentYear;

        private ChartValues<decimal> cIncome;
        private ChartValues<decimal> cExpenses;
        private ChartValues<decimal> cFeePaid;

        public FeeCharts()
        {
            InitializeComponent();

            SetUpChart(GYear);
        }

        public void Global_FeeCharts_Load()
        {
            SetUpChart(GYear);
            cartesianChart1.Update();
        }
        private void FeeCharts_Load(object sender, EventArgs e)
        {
            lblYear.Text = GYear.ToString();
            // SetUpChart(GYear);
        }
        private  void SetUpChart(int year)
        {
            //diffrent values for each month
            //term 1 = jan feb march
            //term 2= may june july
            //term 3=sep oct nov
            decimal janFee = 0; decimal febFee = 0; decimal marFee = 0; decimal aprilFee = 0;
            decimal mayFee = 0; decimal juneFee = 0; decimal julyFee = 0;decimal augFee = 0;
            decimal sepFee = 0; decimal octFee = 0; decimal novFee = 0;decimal decFee = 0;

            decimal incJan = 0; decimal incFeb = 0; decimal incMar = 0;decimal incApril = 0;
            decimal incMay = 0; decimal incJune = 0; decimal incJuly = 0;decimal incAug = 0;
            decimal incSep = 0; decimal incOct = 0; decimal incNov = 0;decimal incDec = 0;

            decimal expJan = 0; decimal expFeb = 0; decimal expMar = 0;decimal expApril = 0;
            decimal expMay = 0; decimal expJune = 0; decimal expJuly = 0;decimal expAug = 0;
            decimal expSep = 0; decimal expOct = 0; decimal expNov = 0;decimal expDec = 0;

            using (var context = new EschoolEntities())
            {
                //var feeListAsyncs = await Task.Factory.StartNew(() =>
                //{
                //    return context.Fees.Where(x => x.Year == year)
                //    .ToList();
                //});
                //var incListAsyncs = await Task.Factory.StartNew(() =>
                //{
                //    return context.Incomes.Where(x => x.Year == year)
                //    .ToList();
                //});
                //var expListAsyncs = await Task.Factory.StartNew(() =>
                //{
                //    return context.Expenses.Where(x => x.Year == year)
                //    .ToList();
                //});
                var feeListAsync =

                     context.Fees.Where(x => x.Year == year)
                    .ToList();

                var incListAsync =
                     context.Incomes.Where(x => x.Year == year)
                    .ToList();

                var expListAsync =
                     context.Expenses.Where(x => x.Year == year)
                    .ToList();


                #region init vars

                janFee = feeListAsync.Where(x => x.Term == 1 & x.Date.Month == 1).Sum(a => a.Amount_Paid);
                febFee = feeListAsync.Where(x => x.Term == 1 & x.Date.Month == 2).Sum(a => a.Amount_Paid);
                marFee = feeListAsync.Where(x => x.Term == 1 & x.Date.Month == 3).Sum(a => a.Amount_Paid);
                aprilFee = feeListAsync.Where(x => x.Term == 1 & x.Date.Month == 4).Sum(a => a.Amount_Paid);

                mayFee = feeListAsync.Where(x => x.Term == 2 & x.Date.Month == 5).Sum(a => a.Amount_Paid);
                juneFee = feeListAsync.Where(x => x.Term == 2 & x.Date.Month == 6).Sum(a => a.Amount_Paid);
                julyFee = feeListAsync.Where(x => x.Term == 2 & x.Date.Month == 7).Sum(a => a.Amount_Paid);
                augFee = feeListAsync.Where(x => x.Term == 2 & x.Date.Month == 8).Sum(a => a.Amount_Paid);

                sepFee = feeListAsync.Where(x => x.Term == 3 & x.Date.Month == 9).Sum(a => a.Amount_Paid);
                octFee = feeListAsync.Where(x => x.Term == 3 & x.Date.Month == 10).Sum(a => a.Amount_Paid);
                novFee = feeListAsync.Where(x => x.Term == 3 & x.Date.Month == 11).Sum(a => a.Amount_Paid);
                decFee = feeListAsync.Where(x => x.Term == 3 & x.Date.Month == 12).Sum(a => a.Amount_Paid);

                incJan = incListAsync.Where(x => x.Term == 1 & x.Date.Month == 1).Sum(a => a.Amount);
                incFeb = incListAsync.Where(x => x.Term == 1 & x.Date.Month == 2).Sum(a => a.Amount);
                incMar = incListAsync.Where(x => x.Term == 1 & x.Date.Month == 3).Sum(a => a.Amount);
                incApril = incListAsync.Where(x => x.Term == 1 & x.Date.Month == 4).Sum(a => a.Amount);

                incMay = incListAsync.Where(x => x.Term == 2 & x.Date.Month == 5).Sum(a => a.Amount);
                incJune = incListAsync.Where(x => x.Term == 2 & x.Date.Month == 6).Sum(a => a.Amount);
                incJuly = incListAsync.Where(x => x.Term == 2 & x.Date.Month == 7).Sum(a => a.Amount);
                incAug = incListAsync.Where(x => x.Term == 2 & x.Date.Month == 8).Sum(a => a.Amount);

                incSep = incListAsync.Where(x => x.Term == 3 & x.Date.Month == 9).Sum(a => a.Amount);
                incOct = incListAsync.Where(x => x.Term == 3 & x.Date.Month == 10).Sum(a => a.Amount);
                incNov = incListAsync.Where(x => x.Term == 3 & x.Date.Month == 11).Sum(a => a.Amount);
                incDec = incListAsync.Where(x => x.Term == 3 & x.Date.Month == 12).Sum(a => a.Amount);

                expJan = expListAsync.Where(x => x.Term == 1 & x.Date.Month == 1).Sum(a => a.Amount);
                expFeb = expListAsync.Where(x => x.Term == 1 & x.Date.Month == 2).Sum(a => a.Amount);
                expMar = expListAsync.Where(x => x.Term == 1 & x.Date.Month == 3).Sum(a => a.Amount);
                expApril = expListAsync.Where(x => x.Term == 1 & x.Date.Month == 4).Sum(a => a.Amount);

                expMay = expListAsync.Where(x => x.Term == 2 & x.Date.Month == 5).Sum(a => a.Amount);
                expJune = expListAsync.Where(x => x.Term == 2 & x.Date.Month == 6).Sum(a => a.Amount);
                expJuly = expListAsync.Where(x => x.Term == 2 & x.Date.Month == 7).Sum(a => a.Amount);
                expAug = expListAsync.Where(x => x.Term == 2 & x.Date.Month == 8).Sum(a => a.Amount);

                expSep = expListAsync.Where(x => x.Term == 3 & x.Date.Month == 9).Sum(a => a.Amount);
                expOct = expListAsync.Where(x => x.Term == 3 & x.Date.Month == 10).Sum(a => a.Amount);
                expNov = expListAsync.Where(x => x.Term == 3 & x.Date.Month == 11).Sum(a => a.Amount);
                expDec = expListAsync.Where(x => x.Term == 3 & x.Date.Month == 12).Sum(a => a.Amount);

                #endregion
            }

            cIncome = new ChartValues<decimal> { incJan, incFeb, incMar, incApril, incMay, incJune, incJuly, incAug, incSep, incOct, incNov, incDec };

            cExpenses = new ChartValues<decimal> { expJan, expFeb, expMar, expApril, expMay, expJune, expJuly, expAug, expSep, expOct, expNov, expDec };

            cFeePaid = new ChartValues<decimal> { janFee, febFee, marFee, aprilFee, mayFee, juneFee, julyFee, augFee, sepFee, octFee, novFee, decFee };


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
                    },

                    new LineSeries
                    {
                        Title = "Fee Paid",
                        Values = cFeePaid,
                        PointGeometry = DefaultGeometries.Square,
                        PointGeometrySize = 15
                    }
                };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar","April" ,"May", "June", "July", "Sep", "Oct", "Nov","Dec" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Amount",
                LabelFormatter = value => $"KES {String.Format("{0:0,0}", value)}"
                //value.ToString("C3", CultureInfo.CreateSpecificCulture("sw-KE"))
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart
            //cartesianChart1.Series.Add(new LineSeries
            //{
            //    Title = "Expenses",
            //    Values = new ChartValues<decimal> { expJan, expFeb, expMar, expMay, expJune, expJuly, expSep, expOct, expNov },
            //    LineSmoothness = 0, //straight lines, 1 really smooth lines
            //    PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            //    PointGeometrySize = 50,
            //    PointForeground = System.Windows.Media.Brushes.Gray
            //});

            
            //cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }

        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {

            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

    }
}
