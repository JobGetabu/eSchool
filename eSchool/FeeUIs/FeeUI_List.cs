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
    public partial class FeeUI_List : UserControl
    {
        private static FeeUI_List _instance;
        public static FeeUI_List Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeeUI_List();
                }
                return _instance;
            }
        }
        public FeeUI_List()
        {
            InitializeComponent();
        }

        private void FeeUI_List_Load(object sender, EventArgs e)
        {
           //load up the grid
            GridInitilizer();

            //load up the list control
            LoadListAsync(Properties.Settings.Default.CurrentYear);
        }

        //More efficient grid initilizer
        public async void GridInitilizer()
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

        //loading comboBox
        /*public async void CheckAnnualPrintAvail(int cYear)
        {
            //loading comboBox
            FeesStructure fs = FeesStructure.Instance;
            string[] n = { };
            fs.bMenu.Items = n;
            fs.bMenu.AddItem("New Fee Structure");


            bool bool1 = false;
            bool bool2 = false;
            bool bool3 = false;

            var grpFsListAsync = await Task.Factory.StartNew(() =>
        {
            using (var context = new EschoolEntities())
            {
                return context.GroupedFeeStructures
                    .OrderBy(c => c.Id)
                    .Where(c => c.selYear == cYear)
                    .ToList();
            }
        });

            foreach (var item in grpFsListAsync)
            {
                if (item.selTerm ==1)
                {
                    bool1 = true;
                }
                if (item.selTerm == 2)
                {
                    bool2 = true;
                }
                if (item.selTerm == 3)
                {
                    bool3 = true;
                }
            }

            if ((bool1 ? 1 : 0) + (bool2 ? 1 : 0) + (bool3 ? 1 : 0) == 3)
            {
                fs.bMenu.AddItem("Print");
            }
           
        } */
        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
            FrmAddFeeCategory frm = new FrmAddFeeCategory();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
            //Referesh the grid
            GridInitilizer();
        }

        private void gridCategory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.gridCategory.Rows[e.RowIndex].Cells[0].Value = GridIcon.AChecked64px;
        }

        private void bThinBtnViewAll_Click(object sender, EventArgs e)
        {
            FrmViewAll fva = new FrmViewAll();
            fva.ShowDialog();
        }

        public async void LoadListAsync(int year)
        {
            var structureListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.GroupedFeeStructures.OrderBy(c => c.Id)
                    .Where(c => c.selYear == year)
                    .ToList();
                }
            });

            listControl1.Clear();
            foreach (var fs in structureListAsync)
            {
                //title //session //but total
                listControl1.Add(fs.YearTitle, fs.TermTitle, fs.TotalTitle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateFeeStructClick();
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
    }
}
