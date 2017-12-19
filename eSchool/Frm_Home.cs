using Bunifu.Framework.UI;
using eSchool.Dash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{

    public partial class Frm_Home : Form
    {

        //Singleton pattern ***best practices***
        private static Frm_Home _instance;
        public static Frm_Home Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Frm_Home();
                }
                return _instance;
            }
        }


        //Deployment code
        // static string path = Path.GetFullPath(Environment.CurrentDirectory);
        public static string databaseFile = "eschool.sdf";


        /// <summary>
        /// TODO 1 Check for null settings to handle all NullException gracefully
        /// </summary>
        public Frm_Home()
        {
            InitializeComponent();
        }

        Color _normal = Color.FromArgb(126, 135, 169);
        Color _white = Color.White;


        DashboardUI das = DashboardUI.Instance;

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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(DashboardUI.Instance);
            das.Global_DashboardUI_Load();
        }


        //TabSwitcher switches the tabs gracefully
        private void TabSwitcher(Control UIinstance)
        {
            if (!this.containerUIs.Controls.Contains(UIinstance))
            {
                this.containerUIs.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.Visible = false;
                UIinstance.BringToFront();

                try
                {
                    this.bunifuTransitionUIs.ShowSync(UIinstance);
                }
                catch (InvalidOperationException)
                {

                    //this exception occurs when the transition is not complete ;(
                }
                catch (System.Reflection.TargetInvocationException exp)
                {
                    MessageBox.Show(exp.Message + " \n" + exp.InnerException.Message);
                }
            }
            else
            {
                UIinstance.BringToFront();
                //only occurs once
                //this.bunifuTransitionUIs.ShowSync(UIinstance);
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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(InvoicesReceipt.Instance);
            InvoicesReceipt inv = InvoicesReceipt.Instance;
            inv.Global_InvoicesReceipt_Load();
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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(IncomeUI.Instance);

            IncomeUI inc = IncomeUI.Instance;
            inc.Global_IncomeUI_Load();
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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(ExpenseUI.Instance);

            ExpenseUI exp = ExpenseUI.Instance;
            exp.Global_ExpenseUI_Load();
        }

        private void Frm_Home_Load(object sender, EventArgs e)
        {
            btn_dashboard.selected = true;
            btn_dashboard.Textcolor = _white;
            DashboardUI.collapse += CollapseNavBar;
            FrmAddCategories.reLoadSettings += btn_settings_Click;
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
            btn_Accounts.Textcolor = _normal;

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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            // TabSwitcher(ImportsUI.Instance);
            TabSwitcher(NewImportsUI.Instance);
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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(TransationsUI.Instance);

            //refresh the transaction code pretty sensitive
            TransationsUI tIns = TransationsUI.Instance;
            tIns.Global_TransationsUI_Load();
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
            btn_Accounts.Textcolor = _normal;

            //End UI Design code

            TabSwitcher(FeesUI.Instance);
        }

        private void btn_Accounts_Click(object sender, EventArgs e)
        {
            //UI design Code
            btn_dashboard.Textcolor = _normal;
            btn_invoices.Textcolor = _normal;
            btn_income.Textcolor = _normal;
            btn_expenses.Textcolor = _normal;
            btn_fees.Textcolor = _normal;
            btn_transations.Textcolor = _normal;
            btn_imports.Textcolor = _normal;
            btn_settings.Textcolor = _normal;
            btn_Accounts.Textcolor = _white;

            //End UI Design code

            TabSwitcher(AccountsUI.Instance);
            AccountsUI a = AccountsUI.Instance;
            a.Global_AccountsUI_Load(sender, e);
        }

        public void pictureBxMenuHome_Click(object sender, EventArgs e)
        {
            CollapseNavBar();
        }
        public void CollapseNavBar()
        {
            if (sidebar.Width == 240)
            {
                //MINIMIZE
                //1.HideLogo
                //2.slide sidebar
                logoAnim.Hide(pictureBox1);

                sidebar.Width = 62;

            }
            else
            {
                //EXPAND
                //1.exand the sidebar
                //2.show the logo
                sidebar.Width = 240;
                logoAnim.ShowSync(pictureBox1);
            }
        }


    }

    //TODO InvalidOperationException
    //Use lock objects when accessing same resources in the program to prevent this random crashes

    //TODO Incase of code regeneration in EschoolContextModel
    //public override int SaveChanges()
    //{
    //    FeesRequiredPerTerms
    //        .Local
    //        .Where(r => r.GroupedFeeStructure == null)
    //        .ToList()
    //        .ForEach(r => FeesRequiredPerTerms.Remove(r));

    //    return base.SaveChanges();
    //}
}
