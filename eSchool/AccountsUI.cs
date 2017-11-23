using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.TheAccs;

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

        private void TabSwitcher(Control UIinstance)
        {
            if (!AccountsUI.Instance.container.Controls.Contains(UIinstance))
            {
                AccountsUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }
        private void AccountsUI_Load(object sender, EventArgs e)
        {

        }

        private void tab1_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab1.Width;
            bunifuSeparator1.Left = tab1.Left;

            //show Accs list UI with custom list
            TabSwitcher(AccountsList.Instance);
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab2.Width;
            bunifuSeparator1.Left = tab2.Left;

            //show acc charts data UI
            TabSwitcher(AccountsChart.Instance);
        }
    }
}
