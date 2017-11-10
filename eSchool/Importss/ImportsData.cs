using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Importss
{
    public partial class ImportsData : UserControl
    {

        private static ImportsData _instance;
        public static ImportsData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportsData();
                }
                return _instance;
            }
        }
        public ImportsData()
        {
            InitializeComponent();
        }

        private void ImportsData_Load(object sender, EventArgs e)
        {
            listControl1.Clear();
            //title //session //but total
            listControl1.Add("1stimport",true);
            listControl1.Add("1stimport", true);
            listControl1.Add("1stimport", true);
        }
    }
}
