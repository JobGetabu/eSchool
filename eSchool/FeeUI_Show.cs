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
            OlistControlInitAsync();
        }

        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
            FrmAddFeeCategory frm = new FrmAddFeeCategory();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                //logic
            }
            //refresh listcontrol
            OlistControlInitAsync();
        }

        private async void OlistControlInitAsync()
        {
            var overHeadListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                }
            });

            listControl1.Clear();
            foreach (var ol in overHeadListAsync)
            {
                listControl1.Add(ol.OverHead);
            }
        }

        private void bGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.bGrid.Rows[e.RowIndex].Cells[0].Value = GridIcon.Grid_View_50px;
            this.bGrid.Rows[e.RowIndex].Cells[3].Value = GridIcon.Trash_Can_50px;
        }

        private void btnSaveStructure_Click(object sender, EventArgs e)
        {
            //this point to old data thats not updated by delete click
            MessageBox.Show($"Total fee per term {OverHeadListItem.selTerm} in the year {OverHeadListItem.selYear} is KES{OverHeadListItem.totalCashPas} for form {OverHeadListItem.filterListOfForms.ToString()}");
        }

        private void bGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    using (var context = new EschoolEntities())
                    {
                        if (GridDelImage(e.RowIndex) != null)
                        {
                            context.Entry<OverHeadCategoryPerYear>(GridDelImage(e.RowIndex)).State = EntityState.Deleted;
                            context.SaveChanges();
                            //ToDo custom notification 
                            bGrid.Rows[e.RowIndex].Visible = false;
                            //call the GridInit to update
                            OverHeadListItem c = new OverHeadListItem();
                            c.GridData(FeesUI.filterListOfForms, FeesUI.selTerm, FeesUI.selYear);
                        }
                    }
                }
            }
        }

        private OverHeadCategoryPerYear GridDelImage(int rowIndex)
        {
            string name; 
            name = (string)this.bGrid.Rows[rowIndex].Cells[1].Value;
            if (OverHeadListItem.overHeadPYList != null)
            {
                foreach (var fi in OverHeadListItem.overHeadPYList)
                {
                    if (fi.Category.Equals(name))
                    {
                        return fi;
                    }
                }
            }
            return null;
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
