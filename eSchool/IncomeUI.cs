using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class IncomeUI : UserControl
    {

        //Singleton pattern ***best practices***
        private static IncomeUI _instance;
        public static IncomeUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IncomeUI();
                }
                return _instance;
            }
        }
        public IncomeUI()
        {
            InitializeComponent();
        }
    }
}
