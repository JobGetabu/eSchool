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

        private async void bGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    using (var context = new EschoolEntities())
                    {
                        for (int i = 0; i < FeesUI.filterListOfForms.Count; i++)
                        {
                            if (GridDelImageAsync(e.RowIndex) != null)
                            {
                                context.Entry<OverHeadCategoryPerYear>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();                               
                            }
                        }
                            //ToDo custom notification 
                            bGrid.Rows[e.RowIndex].Visible = false;
                            //call the GridInit to update
                            OverHeadListItem d = new OverHeadListItem();
                            d.GridData(FeesUI.filterListOfForms, FeesUI.selTerm, FeesUI.selYear);
                    }
                }
            }
        }

        private async Task<OverHeadCategoryPerYear> GridDelImageAsync(int rowIndex)
        {
            //call the GridDataPass to update list
            OverHeadListItem c = new OverHeadListItem();
           var overHeadPYList=await c.GridDataPass(FeesUI.filterListOfForms, FeesUI.selTerm, FeesUI.selYear);

            string name;
            name = (string)this.bGrid.Rows[rowIndex].Cells[1].Value;
            if (overHeadPYList != null)
            {
                foreach (var fi in overHeadPYList)
                {
                    if (fi.Category.Equals(name))
                    {
                        return fi;
                    }
                }
            }
            return null;
        }
        
    }
}
