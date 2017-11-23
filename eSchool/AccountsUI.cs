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
    public partial class AccountsUI : UserControl
    {
        private static AccountsUI _instance;
        public static AccountsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountsUI();
                }
                return _instance;
            }
        }
        public AccountsUI()
        {
            InitializeComponent();
        }

        private void AccountsUI_Load(object sender, EventArgs e)
        {

        }
    }
}
