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
    public partial class ReceiptOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static ReceiptOverview _instance;
        public static ReceiptOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReceiptOverview();
                }
                return _instance;
            }
        }
        public ReceiptOverview()
        {
            InitializeComponent();
        }

        private void ReceiptOverview_Load(object sender, EventArgs e)
        {
            //TODO get number of printed receipts here and pending
        }
    }
}
