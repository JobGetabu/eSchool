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
    public partial class FrmCreateFStruct : Form
    {
        private int cTerm;
        private int feeYear;
        private int selectedYear;
        private int selectedTerm;

        public FrmCreateFStruct(int term, int year)
        {
            InitializeComponent();

            cTerm = term;
            feeYear = year;
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

        private void bCbox1_OnChange(object sender, EventArgs e)
        {

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

                context.FeeStructures.Add(fstruct);
                try
                {
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
            if (bCbox1.Checked)
            {
                SaveFeeStructure(bCbox1);
            }

            if (bCbox2.Checked)
            {
                SaveFeeStructure(bCbox2);
            }

            if (bCbox3.Checked)
            {
                SaveFeeStructure(bCbox3);
            }

            if (bCbox4.Checked)
            {
                SaveFeeStructure(bCbox4);
            }

            //TODO custom notification
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
