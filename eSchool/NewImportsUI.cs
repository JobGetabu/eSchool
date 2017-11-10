using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.Importss;

namespace eSchool
{
    public partial class NewImportsUI : UserControl
    {

        private static NewImportsUI _instance;
        public static NewImportsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NewImportsUI();
                }
                return _instance;
            }
        }
        public NewImportsUI()
        {
            InitializeComponent();
        }

        private void TabSwitcher(Control UIinstance)
        {
            if (!NewImportsUI.Instance.container.Controls.Contains(UIinstance))
            {
                NewImportsUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab1.Width;
            bunifuSeparator1.Left = tab1.Left;

            //show imports UI with custom list
            TabSwitcher(ImportsData.Instance);
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab2.Width;
            bunifuSeparator1.Left = tab2.Left;

            //show students data UI
            TabSwitcher(StudentsData.Instance);
        }

        private void tab3_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab3.Width;
            bunifuSeparator1.Left = tab3.Left;

            //TODO charts baby
            TabSwitcher(Charts.Instance);
        }

        private void NewImportsUI_Load(object sender, EventArgs e)
        {
            //UI code
            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();

            //explicit tab1 click at load
            tab1_Click(sender, e);
        }
    }
}
