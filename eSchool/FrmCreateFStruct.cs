using MetroFramework;
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
    public delegate void PassStoredDataDelegate(List<int> fmStore, int tmStore, int yrStore);
    public delegate void PassMoreDelegate(List<int> fmStore, int tmStore, int yrStore);
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
        public FrmCreateFStruct(int term, int year)
        {
            InitializeComponent();

            cTerm = term;
            feeYear = year;
            fmStore = new List<int>();
        }
        public FrmCreateFStruct()
        {
            InitializeComponent();
            fmStore = new List<int>();

        }

        /// <summary>
        /// Save data here in FeeStructure store
        /// and also 
        /// </summary>

        private void FrmCreateFStruct_Load(object sender, EventArgs e)
        {
            PreparingComboBoxes();
            bCLabelStructureYear.Text = feeYear.ToString();
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
                    int x = ++feeYear;
                    mCBoxYear.Items.Add(x);
                }

            }
        }

        private void mCBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mCBoxYear.SelectedItem != null)
            {
                selectedYear = int.Parse(mCBoxYear.SelectedItem.ToString());
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
                FeeStructure fstruct = new FeeStructure()
                {
                    Details = $"FORM {ck.Tag} {selectedYear} FEES STRUCTURE",
                    Term = selectedTerm,
                    Year = selectedYear,
                    Form = int.Parse(ck.Tag.ToString())
                };

                FrmCreateFStruct.fmStore.Add(int.Parse(ck.Tag.ToString()));
                FrmCreateFStruct.tmStore = selectedTerm;
                FrmCreateFStruct.yrStore = selectedYear;
                try
                {
                    context.FeeStructures.Add(fstruct);
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    //TODO Logging errors
                    MessageBox.Show(exp.Message);
                    throw;
                }
            }
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


            string frmslbl = "For Form ";

            if (bCbox1.Checked)
            {
                SaveFeeStructure(bCbox1);
                frmslbl += "1";
            }

            if (bCbox2.Checked)
            {
                SaveFeeStructure(bCbox2);
                frmslbl += " 2";
            }

            if (bCbox3.Checked)
            {
                SaveFeeStructure(bCbox3);
                frmslbl += " 3";
            }

            if (bCbox4.Checked)
            {
                SaveFeeStructure(bCbox4);
                frmslbl += " 4";
            }

            //subscribe a method to our delegate
            FeeUI_Show ins = FeeUI_Show.Instance;
            PassStoredDataDelegate psd = new PassStoredDataDelegate((ins.delPassData));
            psd(fmStore, tmStore, yrStore);

            //subscribe a method to our delegate
            PassMoreDelegate psf = new PassMoreDelegate(ins.GridDataFilter);
            psf(fmStore, tmStore, yrStore);

            //raise our event
            List<int> data = fmStore;
            int tmData = tmStore;
            int yrData = yrStore;
            PassDataEventArgs args = new PassDataEventArgs(data, tmData, yrData);
            //give it updated args
            ListUpdated(this, args);

            //change label
            FeesUI feeIns = FeesUI.Instance;
           // feeIns.lblCFeeStructure.Text = selectedYear + " Fee Structure " + frmslbl;

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
            if (!FeesUI.Instance.container.Controls.Contains(UIinstance))
            {
                FeesUI.Instance.container.Controls.Add(UIinstance);
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
