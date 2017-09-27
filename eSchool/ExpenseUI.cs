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
    public partial class ExpenseUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static ExpenseUI _instance;
        public static ExpenseUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpenseUI();
                }
                return _instance;
            }
        }
        public ExpenseUI()
        {
            InitializeComponent();
        }
    }
}
