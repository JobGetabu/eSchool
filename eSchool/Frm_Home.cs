﻿using Bunifu.Framework.UI;
using custom_alert_notifications;
using eSchool.Dash;
using eSchool.Importss;
using eSchool.Profiles;
using eSchool.SearchCriteria;
using eSchool.TheLogins;
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
        eUser currentUser = null;

        //Singleton pattern ***best practices***
        private static Frm_Home _instance;
        public static Frm_Home Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Frm_Home(_instance.currentUser);
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
        public Frm_Home(eUser currentUser)
        {
            InitializeComponent();

            this.currentUser = currentUser;
            alert.Show($"Welcome back {currentUser.username}", alert.AlertType.success);
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
                    using (BunifuAnimatorNS.BunifuTransition ss = new BunifuAnimatorNS.BunifuTransition())
                    {
                        ss.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndHorizSlide;
                        //this.bunifuTransitionUIs
                        ss.ShowSync(UIinstance);
                    }
                }
                catch (InvalidOperationException)
                {

                    //this exception occurs when the transition is not complete ;(
                }
                catch (System.Reflection.TargetInvocationException exp)
                {
                    MessageBox.Show(exp.Message + " \n" + exp.InnerException.Message);
                }
                catch (Exception exx)
                {
                    MessageBox.Show(exx.Message, "Try again");
                }
            }
            else
            {
                UIinstance.BringToFront();
                //only occurs once
                //this.bunifuTransitionUIs.ShowSync(UIinstance);
            }

            containerUIs.Refresh();
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


        //Global vars
        private string selSearch;
        private void Frm_Home_Load(object sender, EventArgs e)
        {
            SetToolTip(btnLogout, "Logout");
            SetToolTip(btnAbout, "About");

            //sidebar autoscroll
            sidebar.AutoScroll = true;
            sidebar.VerticalScroll.Enabled = true;

            btn_dashboard.selected = true;
            btn_dashboard.Textcolor = _white;
            DashboardUI.collapse += CollapseNavBar;

            this.cbSearch.SelectedIndex = 0;
            selSearch = cbSearch.SelectedItem.ToString();

            //set images
            PrepareFolder();
            DisplayProf();

            //set up auto complete for search 
            AutoComplete(tbSearch);

            //see which tab is to be done
            if (IsEschoolKe(currentUser))
            {
                ColorSelection();
                UserProfile.Instance = new UserProfile(currentUser);
                TabSwitcher(UserProfile.Instance);
            }
            else
            {
               TabSwitcher(DashboardUI.Instance);
            }

        }

        /// <summary>
        /// prepare folder save images
        /// </summary>
        private void PrepareFolder()
        {
            //create a directory at My Documents
            //save a default logo image
            try
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "eSchool"));

                string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
                string myf = tt + ".\\school2.jpg";
                if (File.Exists(myf))
                {

                }
                else
                {
                    using (Bitmap bmp = new Bitmap(MyLogo.school2))
                    {
                        //write image                     
                        bmp.Save(myf, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                string fff = tt + ".\\eschool.png";
                if (File.Exists(fff))
                {

                }
                else
                {
                    using (Bitmap bmp = new Bitmap(MyLogo.profile1))
                    {
                        //write image                     
                        bmp.Save(fff, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                string eee = tt + ".\\eschool.png";
                if (File.Exists(eee))
                {

                }
                else
                {
                    using (Bitmap bmp = new Bitmap(MyLogo.eschool))
                    {
                        //write image                     
                        bmp.Save(eee, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Start App as Administrator");
            }
            catch (Exception)
            {

            }
        }

        private void DisplayProf()
        {
            //set up picture
            if (String.IsNullOrEmpty(currentUser.ProfImage))
            {
                string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
                string fff = tt + ".\\eschool.png";
                if (File.Exists(fff))
                {
                    try
                    {
                        Image img;
                        using (var bmpTemp = new Bitmap(fff))
                        {
                            img = new Bitmap(bmpTemp);
                        }
                        this.ovalPictureBox1.Image = img;
                        this.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                if (File.Exists(currentUser.ProfImage))
                {
                    try
                    {
                        Image img;
                        using (var bmpTemp = new Bitmap(currentUser.ProfImage))
                        {
                            img = new Bitmap(bmpTemp);
                        }
                        this.ovalPictureBox1.Image = img;
                        this.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception) { }
                }
                else
                {
                    string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
                    string fff = tt + ".\\eschool.png";
                    if (File.Exists(fff))
                    {
                        Image img;
                        using (var bmpTemp = new Bitmap(fff))
                        {
                            img = new Bitmap(bmpTemp);
                        }
                        ovalPictureBox1.Image = img;
                    }
                }
            }
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

            // btn_settings.selected = true;

            TabSwitcher(NewSettings.Instance);

            //refresh the settings code pretty sensitive
            NewSettings sss = NewSettings.Instance;
            sss.Global_NewSettings_Load();


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

            //referesh the progress bars
            FeePayment fp = FeePayment.Instance;
            fp.Copy_FeePayment_Load();
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
                if (sidebar.VerticalScroll.Visible)
                {
                    //increase the width a bit
                    sidebar.Width = 67;
                    sidebar.SetAutoScrollMargin(0, 0);
                }

            }
            else
            {
                //EXPAND
                //1.exand the sidebar
                //2.show the logo
                sidebar.Width = 240;
                logoAnim.ShowSync(pictureBox1);
            }

            //trying to hide scroll
            //sidebar autoscroll
            sidebar.AutoScroll = true;
            sidebar.VerticalScroll.Visible = false;
            sidebar.SetAutoScrollMargin(0, 0);
            sidebar.HorizontalScroll.Visible = false;
            sidebar.VerticalScroll.Enabled = true;
        }

        private void ColorSelection()
        {
            btn_dashboard.selected = false;
            btn_expenses.selected = false;
            btn_fees.selected = false;
            btn_imports.selected = false;
            btn_income.selected = false;
            btn_invoices.selected = false;
            btn_transations.selected = false;
            btn_Accounts.selected = false;
            btn_settings.selected = false;
        }
        private void bDropdownDashMenu_onItemSelected(object sender, EventArgs e)
        {
            //Profile
            //Settings
            //Log out
            if (bDropdownDashMenu.selectedValue.Equals("Settings"))
            {
                ColorSelection();
                btn_settings.selected = true;
                btn_settings.Focus();
                btn_settings_Click(sender, e);
            }
            if (bDropdownDashMenu.selectedValue.Equals("Profile"))
            {
                ColorSelection();
                UserProfile.Instance = new UserProfile(currentUser);
                TabSwitcher(UserProfile.Instance);
            }
            if (bDropdownDashMenu.selectedValue.Equals("Log out"))
            {
                ColorSelection();
                this.Close();

            }
        }

        private void SetToolTip(Control ctl, string message)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            //toolTip1.IsBalloon = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(ctl, message);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // About page
            FrmAbout ab = new FrmAbout();
            ab.Show();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            selSearch = cbSearch.SelectedItem.ToString();
        }

        private async void AutoComplete(MetroFramework.Controls.MetroTextBox tb)
        {
            tbSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            //auto complete for student names in search

            List<string> studName = new List<string>();

            var studList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Student_Basic
                    .OrderBy(x => x.Admin_No)
                    .ToList();
                }
            });

            var names = studList.Select(x => new
            {
                Names = $"{x.First_Name} {x.Middle_Name} {x.Last_Name}"
            });



            if (tb == tbSearch)
            {
                col.Clear();
                foreach (var item in names)
                {
                    col.Add(item.Names);
                }
                tb.AutoCompleteCustomSource = col;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Do search
            //Pop up
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                NewImportsUI ssim = NewImportsUI.Instance;
                //do tabswitch
                TabSwitcher(ssim);

                ssim.Global_tab2_Click(true);
                StudentsData sdata = StudentsData.Instance;

                sdata.IsSearchInit = true;
                sdata.searchText = tbSearch.Text;
                sdata.Global_Search(tbSearch.Text, false);
                if (cbSearch.SelectedIndex == 1)
                {
                    //searching for a form
                    //var showing only form
                    sdata.IsForm = true;
                    tbSearch.Text.Trim();
                    sdata.Global_Search(tbSearch.Text, true);

                    return;
                }
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //Do search
                //Pop up
                if (!string.IsNullOrEmpty(tbSearch.Text))
                {
                    NewImportsUI ssim = NewImportsUI.Instance;
                    //do tabswitch
                    TabSwitcher(ssim);

                    ssim.Global_tab2_Click();
                    StudentsData sdata = StudentsData.Instance;

                    sdata.IsSearchInit = true;
                    sdata.searchText = tbSearch.Text;
                    sdata.Global_Search(tbSearch.Text, false);
                    if (cbSearch.SelectedIndex == 1)
                    {
                        //searching for a form
                        //var showing only form
                        sdata.IsForm = true;
                        tbSearch.Text.Trim();
                        sdata.Global_Search(tbSearch.Text, true);

                        return;
                    }
                }
            }
        }

        ///see if eschoolke is user
        private bool IsEschoolKe(eUser cUser)
        {
            if (cUser.username.Equals("eschoolke".ToUpper()))
            {
                return true;
            }
            return false;
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
