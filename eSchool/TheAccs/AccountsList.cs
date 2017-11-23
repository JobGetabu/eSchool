using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TheAccs
{
    public partial class AccountsList : UserControl
    {
        private static AccountsList _instance;
        public static AccountsList Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountsList();
                }
                return _instance;
            }
        }
        public AccountsList()
        {
            InitializeComponent();
        }

        private void AccountsList_Load(object sender, EventArgs e)
        {

        }
    }
}
