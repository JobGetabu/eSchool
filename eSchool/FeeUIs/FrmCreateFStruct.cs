using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class FrmCreateFStruct : Form
    {
        public delegate void PassMoreDataDelegate(object sender, PassDataEventArgs e);

        // add an event of the delegate type
        public static event PassMoreDataDelegate ListUpdated;
        private int cTerm;
        private int feeYear;
        private int selectedYear;
        private int selectedTerm;

        //provides references to the created forms
        public static List<int> fmStore { get; set; }
        public static int tmStore { get; set; }
        public static int yrStore { get; set; }

        public static string frmslbl = "Form ";
        public FrmCreateFStruct(int term, int year)
        {
            InitializeComponent();
            frmslbl = "Form ";
            cTerm = term;
            feeYear = year;
            fmStore = new List<int>();

            bCLabelStructureYear.Text = feeYear.ToString();

            NullifyAutos();

        }
        public FrmCreateFStruct()
        {
            InitializeComponent();
            frmslbl = "Form ";
            fmStore = new List<int>();
            bCLabelStructureYear.Text = Properties.Settings.Default.CurrentYear.ToString();

            NullifyAutos();
        }

        void NullifyAutos()
        {
            FeesUI.autoGen = false;
            FeesUI.autoFilterListOfForms = null;
            FeesUI.autoSelTerm = 0;
            FeesUI.autoSelYear = 0;
            FeesUI.autoTotalFee = 0;
        }
        /// <summary>
        /// Save data here in FeeStructure store
        /// and also 
        /// </summary>
        private void FrmCreateFStruct_Load(object sender, EventArgs e)
        {
            PreparingComboBoxes();
            
        }

        private void PreparingComboBoxes()
        {
            using (var context = new EschoolEntities())
            {
                var listYear = context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                foreach (var y in listYear)
                {
                    mCBoxYear.Items.Add(y);
                }
                //check term 3 set next year available
                if (cTerm == 3)
                {
                    int x = Properties.Settings.Default.CurrentYear +1;
                    //Add the year in the SchoolPeriodYears
                    SchoolPeriodYear spy = new SchoolPeriodYear();
                    spy.Year = x;

                    try
                    {
                        context.SchoolPeriodYears.Add(spy);
                        context.SaveChanges();
                        mCBoxYear.Items.Add(x);
                    }
                    catch (DbUpdateException)
                    {
                        //possibilities of addind same year each time at load
                        //nice exception
                        //MessageBox.Show("Unsuccessful " + exp.Message, "Error occured");
                    }
                    catch (Exception exp)
                    {
                        //fatal must close program //must be logged
                        MessageBox.Show("Unsuccessful " + exp.Message, "Error occured");
                        throw;
                    }
                   
                }

            }
        }

        private void mCBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mCBoxYear.SelectedItem != null)
            {
                selectedYear = int.Parse(mCBoxYear.SelectedItem.ToString());
                bCLabelStructureYear.Text= mCBoxYear.SelectedItem.ToString();
            }
        }

        private void mCBoxTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mCBoxTerm.SelectedItem != null)
            {
                selectedTerm = mCBoxTerm.SelectedIndex + 1;
            }
        }

        private void SaveFeeStructure(Bunifu.Framework.UI.BunifuCheckbox ck)
        {
            using (var context = new EschoolEntities())
            {
                FrmCreateFStruct.fmStore.Add(int.Parse(ck.Tag.ToString()));
                FrmCreateFStruct.tmStore = selectedTerm;
                FrmCreateFStruct.yrStore = selectedYear;       
            }

            //TODO check existence of a similer fees structure and warn 
        }
        private void bFlatBtnSave_Click(object sender, EventArgs e)
        {
            if (selectedTerm == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select the term", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (selectedYear == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select the year", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }   

            if (bCbox1.Checked)
            {
                SaveFeeStructure(bCbox1);
                if (!frmslbl.Contains("1"))
                {
                frmslbl += "1";
                }
            }

            if (bCbox2.Checked)
            {
                SaveFeeStructure(bCbox2);
                if (!frmslbl.Contains("2"))
                {
                    frmslbl += " 2";
                }
            }

            if (bCbox3.Checked)
            {
                SaveFeeStructure(bCbox3);
                if (!frmslbl.Contains("3"))
                {
                    frmslbl += " 3";
                }
            }

            if (bCbox4.Checked)
            {
                SaveFeeStructure(bCbox4);
                if (!frmslbl.Contains("4"))
                {
                    frmslbl += " 4";
                }
            }

            //raise our event
            List<int> data = fmStore;
            int tmData = tmStore;
            int yrData = yrStore;
            PassDataEventArgs args = new PassDataEventArgs(data, tmData, yrData);
            //give it updated args
            ListUpdated(this, args);

            //change label
            FeesStructure feeIns = FeesStructure.Instance;
            feeIns.lblYFeeStructure.Text = selectedYear + " Fee Structure " ;
            feeIns.lblFFeeStructure.Text = frmslbl;
            feeIns.lblTFeeStructure.Text = "Term "+ tmStore.ToString();
            feeIns.lblTotalFeeStructure.Text = "Total KES 0";//Total KES 30,000

            //Make Save btn visible if invisible
            FeeUI_Show fui = FeeUI_Show.Instance; 
            fui.btnSaveStructure.Visible = true;
            //refresh the list of fee items
            fui.OlistControlInitAsync();
            //TODO 1 custom notification
            MetroMessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TabSwitcher(FeeUI_Show.Instance);
            this.Close();

        }

        private void bFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
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
    }
}
