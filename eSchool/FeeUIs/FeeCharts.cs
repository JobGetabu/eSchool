using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public FeeCharts()
        {
            InitializeComponent();
        }
    }
}
