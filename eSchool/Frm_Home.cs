using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
   
    public partial class Frm_Home : Form
    {
        
        public Frm_Home()
        {
            InitializeComponent();
        }

        Color _normal = Color.FromArgb(126, 135, 169);
        Color _white = Color.White;
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _white;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(DashboardUI.Instance);
        }

        //TabSwitcher switches the tabs gracefully
        private void TabSwitcher(Control UIinstance)
        {
            if (!this.containerUIs.Controls.Contains(UIinstance))
            {
                this.containerUIs.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                this.bunifuTransitionUIs.ShowSync(UIinstance);
                UIinstance.BringToFront();
            }
            else
            {
                this.bunifuTransitionUIs.ShowSync(UIinstance);
                UIinstance.BringToFront();
            }
        }

        private void btn_invoices_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _white;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(InvoicesReceipt.Instance);
        }

        private void btn_income_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _white;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(IncomeUI.Instance);
        }

        private void btn_expenses_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _white;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;

            //End UI Design code
        }

        private void Frm_Home_Load(object sender, EventArgs e)
        {
            btn_dashboard.selected = true;
            DashboardUI.collapse += CollapseNavBar;
            TabSwitcher(DashboardUI.Instance);

            this.metroComboBoxSearch.SelectedIndex = 0;
        }
        private void btn_settings_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _white;

            //End UI Design code

            btn_settings.selected = true;

            TabSwitcher(SettingsUI.Instance);
        }

        private void btn_imports_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _white;
            btn_settings.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(ImportsUI.Instance);
        }
    

        private void btn_transations_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _white;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(TransationsUI.Instance);
        }

        private void btn_fees_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _white;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(FeesUI.Instance);

        }

        public void pictureBxMenuHome_Click(object sender, EventArgs e)
        {
            CollapseNavBar();                  
        }
        
        
        public  void CollapseNavBar()
        {
            if (sidebar.Width == 240)
            {
                sidebar.Width = 62;
            }
            else
            {
                sidebar.Width = 240;
            }
        }
    }
}
