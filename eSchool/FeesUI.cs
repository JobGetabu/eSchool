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
    public partial class FeesUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static FeesUI _instance;
        public static FeesUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeesUI();
                }
                return _instance;
            }
        }
        public FeesUI()
        {
            InitializeComponent();
        }
    }
}
