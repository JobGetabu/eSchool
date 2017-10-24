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


        private void bThinBtnViewAll_Click(object sender, EventArgs e)
        {
            //TODO 1 display page on all categories
        }

        private void FeeUI_Default_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                GridInitilizer();
            }
        }

        //More efficient grid initilizer
        private async void GridInitilizer()
        {
            this.gridCategory.Rows.Clear();

            var categoryListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                }
            });

            foreach (var cat in categoryListAsync)
            {
                gridCategory.Rows.Add(new string[]
                {
                        null,
                        cat.OverHead
                });
            }
        }
        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
            FrmAddFeeCategory frm = new FrmAddFeeCategory();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
            //Referesh the grid
            GridInitilizer();
        }

        private void CreateFeeStructClick()
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
        private void metroTileCreateFeeStruct_Click_1(object sender, EventArgs e)
        {
            CreateFeeStructClick();
        }

        private void gridCategory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.gridCategory.Rows[e.RowIndex].Cells[0].Value = GridIcon.AChecked64px;
        }

        //TODO
        //View all page for  managing categories...
    }
}
