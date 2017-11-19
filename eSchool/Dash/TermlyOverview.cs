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
    public partial class TermlyOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static TermlyOverview _instance;
        public static TermlyOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TermlyOverview();
                }
                return _instance;
            }
        }
        public TermlyOverview()
        {
            InitializeComponent();
        }
    }
}
