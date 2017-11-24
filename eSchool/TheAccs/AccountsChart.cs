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

namespace eSchool.TheAccs
{
    public partial class AccountsChart : UserControl
    {

        private static AccountsChart _instance;
        public static AccountsChart Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountsChart();
                }
                return _instance;
            }
        }
        public AccountsChart()
        {
            InitializeComponent();
        }

        public void Global_AccountsChart_Load()
        {
            SetUpPieChart();
        }
        private void AccountsChart_Load(object sender, EventArgs e)
        {
            SetUpPieChart();
        }
        private async void SetUpPieChart()
        {
            using (var context = new EschoolEntities())
            {
                var accountList = await Task.Factory.StartNew(() =>
                {
                    return context.Accounts.ToList();
                });

                Func<ChartPoint, string> labelPoint = chartPoint =>
                   string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

                SeriesCollection xs = new SeriesCollection();
                foreach (var acc in accountList)
                {
                    PieSeries x = new PieSeries()
                    {
                        Title = $"{acc.AccName}",
                        Values = new ChartValues<decimal> { acc.Amount },
                        PushOut = 15,
                        DataLabels = true,
                        LabelPoint = labelPoint
                    };
                    xs.Add(x);
                }

                pieChart1.Series = xs;
                pieChart1.LegendLocation = LegendLocation.Right;
            }
        }
    }
}
