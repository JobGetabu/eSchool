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
    public partial class FeeUI_Default : UserControl
    {

        private static FeeUI_Default _instance;
        public static FeeUI_Default Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeeUI_Default();
                }
                return _instance;
            }
        }
        public FeeUI_Default()
        {
            InitializeComponent();
        }

        private void metroTileCreateFeeStruct_Click(object sender, EventArgs e)
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

        private void bThinBtnViewAll_Click(object sender, EventArgs e)
        {
            //TODO 1 display page on all categories
        }

        private void FeeUI_Default_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                this.overHeadCategoryBindingSource.DataSource = context.OverHeadCategories.OrderBy(c => c.Id).ToList();
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
