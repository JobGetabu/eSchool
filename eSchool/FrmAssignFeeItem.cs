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
    public partial class FrmAssignFeeItem : Form
    {
        private string categoryOverhead;
        private List<int> fmStore;
        private int tmStore;
        private int yrStore;
        public FrmAssignFeeItem(String category,List<int> fmStore,int tmStore,int yrStore)
        {
            InitializeComponent();

            this.categoryOverhead = category;
            this.tmStore = tmStore;
            this.fmStore = fmStore;
            this.yrStore = yrStore;
        }

        private void bFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAssignFeeItem_Load(object sender, EventArgs e)
        {
            this.bCLabelOverHeadCategory.Text = categoryOverhead;
            mTBoxCost.Focus();
        }
        private void bFlatBtnSave_Click(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {

                if (string.IsNullOrEmpty(this.mTBoxCost.Text))
                {
                    MetroMessageBox.Show(this, "Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mTBoxCost.Focus();
                    return;
                }

                decimal amount;
                if (!decimal.TryParse(mTBoxCost.Text, out amount))
                {
                    MetroMessageBox.Show(this, "Only numbers allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mTBoxCost.Focus();
                    return;
                }

                //Possible disposal of objects i'll do a check later
                foreach (var fmFee in fmStore)
                {
                    OverHeadCategoryPerYear catPy = new OverHeadCategoryPerYear();

                    catPy.Amount = amount;
                    catPy.Category = this.categoryOverhead;
                    catPy.Form = fmFee;
                    catPy.Term = tmStore;
                    catPy.Year = yrStore;

                    try
                    {
                        context.OverHeadCategoryPerYears.Add(catPy);
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                        throw;
                    }
                }

                //TODO custom notification
                MetroMessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                //remove category from visible list 
            }
        }
    }
}
