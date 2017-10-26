using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

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
            int count = 1;
            listControl1.Clear();
            foreach (var ol in overHeadListAsync)
            {
                
                listControl1.Add(ol.OverHead,count+=1);
            }
        }

        private void bGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.bGrid.Rows[e.RowIndex].Cells[0].Value = GridIcon.Grid_View_50px;
            this.bGrid.Rows[e.RowIndex].Cells[3].Value = GridIcon.Trash_Can_50px;
        }

        private void btnSaveStructure_Click(object sender, EventArgs e)
        {
            //TODO 2 prompt to print fee structure
            //ToDO delete privious same fee rpt & gpFs 

            ///Delete preexisting data of the same kind we are saving
            foreach (var fm in OverHeadListItem.filterListOfForms)
            {
                DeleteExistFrptsAndGfs(OverHeadListItem.selTerm, OverHeadListItem.selYear, fm);
            }


            string title = $"{OverHeadListItem.selYear} {FrmCreateFStruct.frmslbl}";
            string tmTitle = $"Term {OverHeadListItem.selTerm}";
            string totalCash = $"KES {String.Format("{0:0,0}", OverHeadListItem.totalCashPas)}";

            using (var context = new EschoolEntities())
            {
                GroupedFeeStructure gp = new GroupedFeeStructure()
                {
                    YearTitle = title,
                    TermTitle = tmTitle,
                    TotalTitle = totalCash,
                    TotalFee = OverHeadListItem.totalCashPas,
                    selTerm = OverHeadListItem.selTerm,
                    selYear = OverHeadListItem.selYear
                };
                foreach (var fm in FeesUI.filterListOfForms)
                {
                    if (fm == 1)
                    {
                        gp.selFm1 = 1; //true
                    }
                    if (fm == 2)
                    {
                        gp.selFm2 = 2; //true
                    }
                    if (fm == 3)
                    {
                        gp.selFm3 = 3; //true
                    }
                    if (fm == 4)
                    {
                        gp.selFm4 = 4; //true
                    }
                }

                context.GroupedFeeStructures.Add(gp);
                context.SaveChanges();
              

                foreach (var fm in FeesUI.filterListOfForms)
                {
                    FeesRequiredPerTerm frpt = new FeesRequiredPerTerm()
                    {
                        Form = fm,
                        Term = OverHeadListItem.selTerm,
                        FeeRequired = OverHeadListItem.totalCashPas,
                        Year = OverHeadListItem.selYear
                    };
                    context.FeesRequiredPerTerms.Add(frpt);
                }
                context.SaveChanges();
            }
          

            //ToDo custom notification
            if ((MetroMessageBox.Show(this, $"{title} has been saved for {tmTitle} /n Total fee for {tmTitle} is {totalCash} /n Do you wish to print the Fee Structure ?", "Print Fee Structure", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {
                //TODO print fee structure
                //this point to old data thats not updated by delete click
                MessageBox.Show($"Printing info /n Total fee per term {OverHeadListItem.selTerm} in the year {OverHeadListItem.selYear} is KES {OverHeadListItem.totalCashPas} for {FrmCreateFStruct.frmslbl}");
            }
            this.btnSaveStructure.Visible = false;
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
            var overHeadPYList = await c.GridDataPass(FeesUI.filterListOfForms, FeesUI.selTerm, FeesUI.selYear);

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

        private void DeleteExistFrptsAndGfs(int term, int year, int form)
        {
            using (var context = new EschoolEntities())
            {
                var fRPTerms= context.FeesRequiredPerTerms
                .Where(c => c.Form == form & c.Year == year & c.Term == term)
                .ToList();
 
                foreach (FeesRequiredPerTerm fitem in fRPTerms)
                {
                    context.Entry<FeesRequiredPerTerm>(fitem).State = EntityState.Deleted;
                }
                var gpFs = context.GroupedFeeStructures
               .Where(c => c.selYear==year & c.selTerm ==term)
               .Where(c=> c.selFm1==form | c.selFm2 == form | c.selFm3 == form | c.selFm4 == form)
               .ToList();

                foreach (GroupedFeeStructure gpfitem in gpFs)
                {
                    context.Entry<GroupedFeeStructure>(gpfitem).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
    }
}
