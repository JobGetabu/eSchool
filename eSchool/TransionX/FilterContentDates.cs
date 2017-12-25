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
        public FilterContentDates()
        {
            InitializeComponent();          
        }

        public DateTime selDate;

        private void Nullify()
        {
            selDate = DateTime.Now;
            this.DatepickerStart.Value = DateTime.Now;
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
