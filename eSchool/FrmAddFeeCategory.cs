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
    public partial class FrmAddFeeCategory : Form
    {
        public FrmAddFeeCategory()
        {
            InitializeComponent();
        }

        private void bFlatBtnSave_Click(object sender, EventArgs e)
        {

            //TODO 1 Autocomplete features here

            using (var context = new EschoolEntities())
            {
                try
                {
                    if (mTBoxFeeItem.Text == string.Empty)
                    {
                        return;
                    }
                    OverHeadCategory cat = new OverHeadCategory();
                    cat.OverHead = mTBoxFeeItem.Text;

                    context.OverHeadCategories.Add(cat);
                    context.SaveChanges();

                    //TODO 2 custom notification
                    MetroMessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    //throw;
                }
            }
        }

        private void bFlatButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
