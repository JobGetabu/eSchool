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



        private async void FeeUI_List_Load(object sender, EventArgs e)
        {
            //load up the grid
            GridInitilizer();

            //load up the list control

            try
            {
                bool ch= await ListControlInitAsync();
            }
            catch(NullReferenceException exp)
            {
                MessageBox.Show(exp.Message,"Nulllllllll");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                //throw;
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

        private void gridCategory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.gridCategory.Rows[e.RowIndex].Cells[0].Value = GridIcon.AChecked64px;
        }

        private void bThinBtnViewAll_Click(object sender, EventArgs e)
        {
            //TODO 1 display page on all categories
        }

        List<FeeStructure> structureList;
       private async Task<List<FeeStructure>> StructureListAsync()
        {
            var structureListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.FeeStructures.OrderBy(c => c.Id).ToList();
                }
            });
             
            return structureListAsync;
        }
        private async Task<bool> ListControlInitAsync()
        {
            structureList=await StructureListAsync();
            foreach (var fs in structureList)
            {
                if (fs.Year == Properties.Settings.Default.CurrentYear)
                {
                    int count = 0;
                    if (fs.Term == Properties.Settings.Default.CurrentTerm)
                    {
                        count++;
                    }
                    if (count > 0)
                    {
                        string title, session, total;
                        //TODO get the total
                        //check created fee structures
                        FeesUI feeUi = FeesUI.Instance;
                        PassDataEventArgs psd ;
                        
                        //comes alive once a fs is created
                        if (FeesUI.filterListOfForms.Count > 0)
                        {
                            string fms = "";
                            foreach (var item in FeesUI.filterListOfForms)
                            {
                                fms += $" {FeesUI.filterListOfForms}";
                            }
                            title = $"{FeesUI.selYear} Form{fms}";
                        }
                        else
                        {
                            title = $"{FeesUI.selYear} Form{FeesUI.filterListOfForms}";
                        }
                        session = $"Term {FeesUI.selTerm}";
                        total = "KES 20,000";

                        this.listControl1.Add(title, session, total);
                    }
                }
            }
            return true;
        }
    }
}
