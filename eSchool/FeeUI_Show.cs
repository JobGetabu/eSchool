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
        List<int> filterList;
        private int selTerm;
        private int selYear;
        public FeeUI_Show()
        {
            InitializeComponent();
        }



        #region Interform passed variables

        /// <summary>
        /// passed variables
        /// from PassStoredDataDelegate
        /// </summary>
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

                //Load the data in the UI
            }

        }

        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
           
        }

        void AddFeeItemClick(object sender, EventArgs e)
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

        /// <summary>
        /// This method is called each time a fee structure is created 
        /// The grid reflects what is happening in the background when fee items are being 
        /// populated to the fee structure.
        /// </summary>
        /// <param name="fmstore"></param>
        /// <param name="tmData"></param>
        /// <param name="yrData"></param>
        //public void GridDataFilter(List<int> fmstore, int tmData, int yrData)
        //{
        //    if (fmstore != null)
        //    {
        //        using (var context = new EschoolEntities())
        //        {
        //            if (fmstore.Count > 1)
        //            {
        //                int r = int.Parse(fmstore[0].ToString());

        //                this.overHeadCategoryPerYearBindingSource.DataSource =
        //                     context.OverHeadCategoryPerYears.OrderBy(c => c.Id)
        //                                                     .Where(c => c.Form == r && c.Term == tmData && c.Year == yrData)
        //                                                     .ToList();
        //            }
        //            else
        //            {
        //                this.overHeadCategoryPerYearBindingSource.DataSource =
        //                     context.OverHeadCategoryPerYears.OrderBy(c => c.Id)
        //                                                     .Where(c => c.Term == tmData && c.Year == yrData)
        //                                                     .ToList();
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// This method is called each time a fee structure is created returning a list of school forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void GridDataList(object sender, PassDataEventArgs e)
        //{
        //    filterList = e.pfmStore;
        //    selTerm = e.ptmStore;
        //    selYear = e.pyrStore;
        //}

        //    void gridCellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        e.RowIndex >= 0)
        //    {
        //        //TODO - Button Clicked - Execute Code Here

        //        //Open assignfee UI dialogue 
        //        if (overHeadCategoryBindingSource.Current == null)
        //        {
        //            return;
        //        }
        //        OverHeadCategory cat = overHeadCategoryBindingSource.Current as OverHeadCategory;
        //        FrmAssignFeeItem frm = new FrmAssignFeeItem(cat.OverHead.ToString(), fmstore, tmStore, yrStore);
        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            //logic

        //        }

        //        //refresh the data grid
        //        #region GridData
        //        ///this is data loaded at save with new fee structure
        //        // overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
        //        //alternative
        //        // initialize the data by subscribing our method
        //        FrmCreateFStruct.ListUpdated += new FrmCreateFStruct.PassMoreDataDelegate(GridDataList);
        //        //filter the data
        //        GridDataFilter(filterList, selTerm, selYear);
        //        #endregion
        //    }
       
    }
}
