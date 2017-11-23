using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void AccountsChart_Load(object sender, EventArgs e)
        {

        }
    }
}
