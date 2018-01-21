using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using eSchool.MyPrints;
using custom_alert_notifications;
using eSchool.MyPrints2;
using System.IO;

namespace eSchool
{
    public partial class FeesStructure : UserControl
    {
        private static FeesStructure _instance;

        public static FeesStructure Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeesStructure();
                }
                return _instance;
            }
        }
        public FeesStructure()
        {
            InitializeComponent();
        }

        int GYear = Properties.Settings.Default.CurrentYear;
        int GTerm = Properties.Settings.Default.CurrentTerm;
        private void TabSwitcher(Control UIinstance)
        {
            if (!FeesStructure.Instance.container.Controls.Contains(UIinstance))
            {
                FeesStructure.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        private async Task<bool> AnyCurrentFeeStruct(int cYear)
        {
            bool available = false;
            var queryAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.GroupedFeeStructures.Select(c => new
                    {
                        c.selYear
                    }).ToList();
                }
            });

            foreach (var cur in queryAsync)
            {
                if (cYear == cur.selYear)
                {
                    available = true;
                    return available;
                }
            }
            return available;
        }

        private async void FeesStructure_Load(object sender, EventArgs e)
        {
            //UI code
            this.lblYFeeStructure.Text = $"{GYear.ToString()} Fees Structures"; //2017 Fees Structures

            //TODO 1 Check if there already existing fee structure for that 
            //year and decide which UI to load
            //create an option to create feeStructure in the dropdown option
            bool ch = await AnyCurrentFeeStruct(GYear);
            if (ch)
            {
                //show FeeUI_List
                TabSwitcher(FeeUI_List.Instance);
            }
            else
            {
                TabSwitcher(FeeUI_Default.Instance);
            }

            //loading comboBox
            CheckAnnualPrintAvail(GYear);
            //print avail if all 3 terms avail
        }

        public List<AnnualFeeStructure> SelectedOverHeads(List<OverHeadCategoryPerYear> ovfeestructureListAsync, int selYear, int selform, int selTerm)
        {
            List<AnnualFeeStructure> feestructureList = new List<AnnualFeeStructure>();

            foreach (var ov in ovfeestructureListAsync)
            {
                AnnualFeeStructure afs = new AnnualFeeStructure();
                afs.overHeadName = ov.Category;
                afs.costCurrent = ov.Amount;

                afs.costTerm1 = 0;
                afs.costTerm2 = 0;
                afs.costTerm3 = 0;

                feestructureList.Add(afs);
            }
            return feestructureList;
        }
        private List<AnnualFeeStructure> SelectedOverHeads(List<OverHeadCategoryPerYear> ovfeestructureListAsync, int selYear, int selform)
        {
            //img

            PrintsLogo printsLogo = new PrintsLogo();
            printsLogo.ImgPath = "";
            string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
            string myf = tt + ".\\Output.jpg";
            if ((File.Exists(myf)))
            {
                //path
                printsLogo.ImgPath = myf;
            }

            List<AnnualFeeStructure> feestructureList = new List<AnnualFeeStructure>();
            var ovfees = ovfeestructureListAsync.OrderBy(a => a.Category).Select(a => a.Category);
            var ovfeescat = ovfees.Distinct();
            foreach (var ov in ovfeescat)
            {
                AnnualFeeStructure afs = new AnnualFeeStructure();
                afs.overHeadName = ov;
                foreach (var item in ovfeestructureListAsync)
                {
                    if (item.Category.Equals(ov))
                    {
                        if (item.Term == 1)
                        {
                            afs.costTerm1 = item.Amount;
                        }
                        if (item.Term == 2)
                        {
                            afs.costTerm2 = item.Amount;
                        }
                        if (item.Term == 3)
                        {
                            afs.costTerm3 = item.Amount;
                        }
                    }
                }
                feestructureList.Add(afs);
            }
            return feestructureList;
        }
        private async void bMenu_onItemSelected_1(object sender, EventArgs e)
        {
            // use this externally to print item
            // complex print func comes here
            if (bMenu.selectedValue.Equals("Print"))
            {
                //alert.Show("Generating Document !", alert.AlertType.success);
                // open up a dialogue print fee
                FrmPrompt fp = new FrmPrompt();
                if (fp.ShowDialog() == DialogResult.OK)
                {
                    var feestructureListAsync = await Task.Factory.StartNew(() =>
                    {
                        using (var context = new EschoolEntities())
                        {
                            return context.OverHeadCategoryPerYears
                                               .OrderBy(c => c.Id)
                                               .Where(c => c.Year == fp.selFilYear & c.Form == fp.selFilForm)
                                               .ToList();
                        }
                    });

                    List<AnnualFeeStructure> feestructureList = SelectedOverHeads(feestructureListAsync, fp.selFilYear, fp.selFilForm);
                    string lbl = $"{fp.selFilYear} Form {fp.frmlbl} Fees Structure"; //2017 Form Four Fees Structure



                    alert l = new alert("Please wait...\n Generating Document !", alert.AlertType.success);
                    l.Show();
                    await Task.Delay(2000);
                    l.Close();
                    FrmAnnualFsReport frm = new FrmAnnualFsReport(lbl, feestructureList);
                    frm.ShowDialog();
                }
                return;
            }


            if (bMenu.selectedValue.Equals("New Fee Structure"))
            {
                CreateFeeStructClick();
                return;
            }

            if (bMenu.selectedValue.Equals("Do Print"))
            {
                FeeUI_Show fus = FeeUI_Show.Instance;
                fus.RpInit();

                alert l = new alert("Please wait...\n Generating Document !", alert.AlertType.success);
                l.Show();
                await Task.Delay(2000);
                l.Close();
                DoPrint(fus.rpYear, fus.rpTerm, fus.rpForms[0], fus.rpTitle);
                return;
            }
        }

        private async void DoPrint(int year, int term, int form, string title)
        {
            int fm = FeesUI.autoFilterListOfForms[0];
            var feestructureListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategoryPerYears
                                       .OrderBy(c => c.Id)
                                       .Where(c => c.Year == FeesUI.autoSelYear & c.Form == fm
                                        & c.Term == FeesUI.autoSelTerm)
                                       .ToList();
                }
            });


            List<AnnualFeeStructure> feestructureList = SelectedOverHeads(feestructureListAsync, FeesUI.autoSelYear, fm, FeesUI.autoSelTerm);

            string lbl = $"{title} Term {FeesUI.autoSelTerm} Fees Structure"; //2017 Form Four Fees Structure

            FrmTermFsReport frm = new FrmTermFsReport(lbl, feestructureList);

            frm.ShowDialog();
        }

        //loading comboBox
        public void CheckAnnualPrintAvail(int cYear)
        {
            //loading comboBox
            bMenu.Clear();
            bMenu.AddItem("New Fee Structure");

            bool bool1 = false;
            bool bool2 = false;
            bool bool3 = false;
            using (var context = new EschoolEntities())
            {
                var grpFsListAsync = context.GroupedFeeStructures
                    .OrderBy(c => c.Id)
                    .Where(c => c.selYear == cYear)
                    .ToList();

                foreach (var item in grpFsListAsync)
                {
                    if (item.selTerm == 1)
                    {
                        bool1 = true;
                    }
                    if (item.selTerm == 2)
                    {
                        bool2 = true;
                    }
                    if (item.selTerm == 3)
                    {
                        bool3 = true;
                    }
                }

                //loading comboBox
                if ((bool1 ? 1 : 0) + (bool2 ? 1 : 0) + (bool3 ? 1 : 0) == 3)
                {
                    bMenu.AddItem("Print");
                }
            }
        }
        private void CreateFeeStructClick()
        {
            int term = Properties.Settings.Default.CurrentTerm;
            int year = Properties.Settings.Default.CurrentYear;

            FrmCreateFStruct frm = new FrmCreateFStruct(term, year);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //need to send FeeUI_Show to front
                //at exit save of FrmCreateFStruct

            }
        }

        private void bTBtnChangeYear_Click(object sender, EventArgs e)
        {
            //check if the fee structure is saved and autosave :)
            FeeUI_Show fuui = FeeUI_Show.Instance;
            if (fuui.btnSaveStructure.Visible)
            {
                //Custom notification
                //MetroMessageBox.Show(this, "Your Fee Structure was Auto Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                alert.Show("Your Fee Structure was Auto Saved !", alert.AlertType.success);
                // Autosave 
                fuui.btnSaveStructure_Click(sender, e);
            }

            FrmChangeYear frm = new FrmChangeYear();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FeeUI_List ful = FeeUI_List.Instance;
                //show FeeUI_List
                TabSwitcher(FeeUI_List.Instance);
                //updates the list with current year fee structures
                ful.LoadListAsync(FrmChangeYear.selChangeYear);
            }
        }

        public void SwitchTabExt()
        {
            //show FeeUI_List
            TabSwitcher(FeeUI_List.Instance);
        }
        public void SwitchTabExt2()
        {
            //show FeeUI_List
            TabSwitcher(FeeUI_Show.Instance);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
