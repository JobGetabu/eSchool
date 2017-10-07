using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class FeeUI_Show : UserControl
    {
        //Singleton pattern ***best practices***
        private static FeeUI_Show _instance;
        public static FeeUI_Show Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeeUI_Show();
                }
                return _instance;
            }
        }
        public FeeUI_Show()
        {
            InitializeComponent();
        }

        private void FeeUI_Show_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                overHeadCategoryBindingSource.DataSource = context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
            }
            {

            }
        }

        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
            FrmAddFeeCategory frm = new FrmAddFeeCategory();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
            using (var context = new EschoolEntities())
            {
                this.overHeadCategoryBindingSource.DataSource = context.OverHeadCategories.OrderBy(c => c.Id).ToList();
            }
        }
    }
}
