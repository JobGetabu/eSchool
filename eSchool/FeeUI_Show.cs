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
        //public List<int> cfrmstore { get; set; }
        //public FeeUI_Show(List<int> pcfrmstore)
        //{
        //    cfrmstore = pcfrmstore;
        //}

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
        List<int> filterList = null;
        public FeeUI_Show()
        {
            InitializeComponent();
            filterList = new List<int>();
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


                #region GridData
                ///this is data loaded at save with new fee structure
                // overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
                //alternative

                //show persisted data of open fee structure

                #endregion
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

        /// <summary>
        /// This method is called each time a fee structure is created 
        /// </summary>
        /// <param name="fmstore"></param>
        public void GridDataFilter(List<int> fmstore)
        {
            if (fmstore != null)
            {

                if (fmstore.Count > 1)
                {
                    int r = int.Parse(fmstore[0].ToString());
                    using (var context = new EschoolEntities())
                    {
                        this.overHeadCategoryPerYearBindingSource.DataSource =
                             context.OverHeadCategoryPerYears.OrderBy(c => c.Id)
                                                             .Where(c => c.Form == r)
                                                             .ToList();
                    }

                }
                else
                {
                    using (var context = new EschoolEntities())
                    {
                        this.overHeadCategoryPerYearBindingSource.DataSource =
                             context.OverHeadCategoryPerYears.OrderBy(c => c.Id)
                                                             .ToList();
                    }
                }
            }
        }

        /// <summary>
        /// This method is called each time a fee structure is created returning a list of school forms
        /// </summary>
        /// <param name="pfmstore"></param>
        public void GridDataList(object sender, PassDataEventArgs e)
        {
            filterList = e.pfmStore;
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
                FrmAssignFeeItem frm = new FrmAssignFeeItem(cat.OverHead.ToString(), fmstore, tmStore, yrStore);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //logic

                }
               //refresh the data grid

                using (var context = new EschoolEntities())
                {
                    overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
                }
            }
        }
    }
}
