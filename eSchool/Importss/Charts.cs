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
    public partial class Charts : UserControl
    {

        private static Charts _instance;
        public static Charts Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Charts();
                }
                return _instance;
            }
        }
        public Charts()
        {
            InitializeComponent();
        }
    }
}
