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
using System.Windows;
using System.Windows.Media;

namespace eSchool.Importss
{
    public partial class Charts : UserControl
    {

        private static Charts _instance;
        public static Charts Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Charts();
                }
                return _instance;
            }
        }
        public Charts()
        {
            InitializeComponent();


        }

        public void Global_Charts_Load()
        {
            SetUpPieChart();
            SetUpGaugeGender();
        }
        private void Charts_Load(object sender, EventArgs e)
        {
            SetUpPieChart();
            SetUpGaugeGender();
        }

        private async void SetUpPieChart()
        {
            using (var context = new EschoolEntities())
            {
                var studentList = await Task.Factory.StartNew(() =>
                   {
                       return context.Student_Basic.ToList();
                   });

                int studentsCount = studentList.Count;

                var fm1Count = studentList.Count(x => x.Form == 1);
                var fm2Count = studentList.Count(x => x.Form == 2);
                var fm3Count = studentList.Count(x => x.Form == 3);
                var fm4Count = studentList.Count(x => x.Form == 4);

                Func<ChartPoint, string> labelPoint = chartPoint =>
                   string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Form 1",
                    Values = new ChartValues<int> {fm1Count},
                    PushOut = 15,
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Form 2",
                    Values = new ChartValues<int> {fm2Count},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Form 3",
                    Values = new ChartValues<int> {fm3Count},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Form 4",
                    Values = new ChartValues<double> {fm4Count},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

                pieChart1.LegendLocation = LegendLocation.Bottom;



                //Fee registration chart
                var feeListAsync = await Task.Factory.StartNew(() =>
                {
                    return context.Fees
                            .ToList();

                });

                var fees = feeListAsync.Select(a => a.Admin_No);

                int registeredStudents = fees.Distinct().Count();

                decimal psg = 0;
                if (studentsCount != 0)
                {
                    psg = decimal.Divide(registeredStudents, studentsCount) * 100;
                }
                int rCount = (int)decimal.Round(psg);

                ////fee fill
                //solidGaugeFee.From = 0;
                //solidGaugeFee.To = 100;
                //solidGaugeFee.Value = rCount;
                //solidGaugeFee.Base.LabelsVisibility = Visibility.Hidden;
                //solidGaugeFee.Base.GaugeActiveFill = new LinearGradientBrush
                //{
                //    GradientStops = new GradientStopCollection
                //      {
                //        new GradientStop(Colors.Yellow, 0),
                //        new GradientStop(Colors.Orange, .5),
                //        new GradientStop(Colors.Red, 1)
                //    }
                //};
            }
        }

        private async void SetUpGaugeGender()
        {
            //Gender chart 
            List<Student_Basic> studentList = new List<Student_Basic>();
            using (var context = new EschoolEntities())
            {
                studentList = await Task.Factory.StartNew(() =>
               {
                   return context.Student_Basic.ToList();
               });
            }

            var mCount = studentList.Count(x => x.Gender.Equals("M"));
            int studentsCount = studentList.Count;
            decimal pcg = 0;
            if (studentsCount != 0)
            {
                pcg = decimal.Divide(mCount, studentsCount) * 100;
            }
            int maleCount = (int)decimal.Round(pcg);


            //custom fill
            solidGaugeGender.From = 0;
            solidGaugeGender.To = 100;
            solidGaugeGender.Value = maleCount;
            solidGaugeGender.Base.LabelsVisibility = Visibility.Hidden;

        }
    }
}
