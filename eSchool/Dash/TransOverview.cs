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

    public partial class TransOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static TransOverview _instance;
        public static TransOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransOverview();
                }
                return _instance;
            }
        }
        public TransOverview()
        {
            InitializeComponent();
        }
    }
}
