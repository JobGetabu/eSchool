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
    public partial class StudentsData : UserControl
    {

        private static StudentsData _instance;
        public static StudentsData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentsData();
                }
                return _instance;
            }
        }
        public StudentsData()
        {
            InitializeComponent();
        }
    }
}
