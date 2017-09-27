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
    public partial class InvoicesReceipt : UserControl
    {
        //Singleton pattern ***best practices***
        private static InvoicesReceipt _instance;
        public static InvoicesReceipt Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InvoicesReceipt();
                }
                return _instance;
            }
        }
        public InvoicesReceipt()
        {
            InitializeComponent();
        }
    }
}
