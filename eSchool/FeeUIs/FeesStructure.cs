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
            //TODO print avail if all 3 terms avail
        }

        private List<AnnualFeeStructure> SelectedOverHeads(List<OverHeadCategoryPerYear> ovfeestructureListAsync, int selYear, int selform)
        {
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
            //ToDo use this externally to print item
            //ToDo complex print func comes here
            if (bMenu.selectedValue.Equals("Print"))
            {

                var feestructureListAsync = await Task.Factory.StartNew(() =>
                {
                    using (var context = new EschoolEntities())
                    {
                        return context.OverHeadCategoryPerYears
                                           .OrderBy(c => c.Id)
                                           .Where(c => c.Year == 2017 & c.Form == 4)
                                           .ToList();
                    }
                });

                //TODO open up a dialogue print fee

                List<AnnualFeeStructure> feestructureList = SelectedOverHeads(feestructureListAsync, GYear,4);
                FrmAnnualFsReport frm = new FrmAnnualFsReport(null, feestructureList);
                frm.ShowDialog();

                if (bMenu.selectedValue.Equals("New Fee Structure"))
                {
                    CreateFeeStructClick();
                }
            }
        }

        //loading comboBox
        public async void CheckAnnualPrintAvail(int cYear)
        {
            //loading comboBox
            string[] n = { };
            bMenu.Items = n;
            bMenu.AddItem("New Fee Structure");


            bool bool1 = false;
            bool bool2 = false;
            bool bool3 = false;

            var grpFsListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.GroupedFeeStructures
                        .OrderBy(c => c.Id)
                        .Where(c => c.selYear == cYear)
                        .ToList();
                }
            });

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

            if ((bool1 ? 1 : 0) + (bool2 ? 1 : 0) + (bool3 ? 1 : 0) == 3)
            {
                bMenu.AddItem("Print");
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
                MetroMessageBox.Show(this, "Your Fee Structure was Auto Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
