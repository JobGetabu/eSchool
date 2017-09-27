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
    public partial class TransationsUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static TransationsUI _instance;
        public static TransationsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransationsUI();
                }
                return _instance;
            }
        }
        public TransationsUI()
        {
            InitializeComponent();
        }
    }
}
