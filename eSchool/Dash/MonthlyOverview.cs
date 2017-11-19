using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
    }
}
