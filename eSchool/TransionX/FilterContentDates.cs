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
    public partial class FilterContentDates : UserControl
    {

        //Singleton pattern ***best practices***
        private static FilterContentDates _instance;
        public static FilterContentDates Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FilterContentDates();
                }
                return _instance;
            }
            set
            {
                value = _instance;
            }
        }
        public FilterContentDates()
        {
            InitializeComponent();          
        }

        public DateTime selDate;

        private void Nullify()
        {
            selDate = DateTime.Now;

        }
        private void FilterContentDates_Load(object sender, EventArgs e)
        {
            Nullify();
        }

        private void DatepickerStart_onValueChanged(object sender, EventArgs e)
        {
            selDate = DatepickerStart.Value;
        }
    }
}
