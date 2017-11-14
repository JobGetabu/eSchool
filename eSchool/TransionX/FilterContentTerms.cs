using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TransionX
{
    public partial class FilterContentTerms : UserControl
    {
        //Singleton pattern ***best practices***
        private static FilterContentTerms _instance;
        public static FilterContentTerms Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FilterContentTerms();
                }
                return _instance;
            }
        }
        public FilterContentTerms()
        {
            InitializeComponent();
        }

        private void FilterContentTerms_Load(object sender, EventArgs e)
        {

        }
    }
}
