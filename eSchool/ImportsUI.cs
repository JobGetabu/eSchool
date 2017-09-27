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
    public partial class ImportsUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static ImportsUI _instance;
        public static ImportsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportsUI();
                }
                return _instance;
            }
        }
        public ImportsUI()
        {
            InitializeComponent();
        }
    }
}
