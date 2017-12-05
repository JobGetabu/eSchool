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

namespace eSchool.Profiles
{
    public partial class StudentProfile : UserControl
    {

        private static StudentProfile _instance;
        public static StudentProfile Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentProfile();
                }
                return _instance;
            }
        }
        public StudentProfile()
        {
            InitializeComponent();


            #region chart

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            cartesianChart1.Series[1].Values.Add(48d);

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
            #endregion
        }

        private void StudentProfile_Load(object sender, EventArgs e)
        {
            //this.AutoScrollPosition = new Point()
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

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            //back to import UI
            //show students data UI
            TabSwitcher(StudentsData.Instance);
        }
    }
}
