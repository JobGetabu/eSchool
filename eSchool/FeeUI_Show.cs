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

        #region Interform passed variables
        //passed variables
        private List<int> fmstore;
        private int tmStore;
        private int yrStore;
        public void delPassData(List<int> pfmStore, int ptmStore, int pyrStore)
        {
            FeeUI_Show._instance.fmstore = pfmStore;
            FeeUI_Show._instance.yrStore = pyrStore;
            FeeUI_Show._instance.tmStore = ptmStore;
        }

        #endregion
        private void FeeUI_Show_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                overHeadCategoryBindingSource.DataSource = context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
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

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bCDataGridCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here

                //Open assignfee UI dialogue 
                if (overHeadCategoryBindingSource.Current == null)
                {
                    return;
                }
                OverHeadCategory cat = overHeadCategoryBindingSource.Current as OverHeadCategory;
                FrmAssignFeeItem frm = new FrmAssignFeeItem(cat.OverHead.ToString(),fmstore,tmStore,yrStore);
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    //logic
                    overHeadCategoryBindingSource.RemoveCurrent();        
                }
                using (var context = new EschoolEntities())
                {
                    overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
                }
            }
        }
    }
}
