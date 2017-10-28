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
    public partial class OverHeadListItem : UserControl
    {

        public static List<int> filterListOfForms;
        public static int selTerm;
        public static int selYear;



        public static decimal totalCashPas;
        public string OverHeadName { get; set; }

        public int UTagIndex { get; set; }
        public OverHeadListItem()
        {
            InitializeComponent();

            //checks this otherwise takes the default values
            if (FeesUI.autoGen)
            {
                filterListOfForms = FeesUI.autoFilterListOfForms;
                selTerm = FeesUI.autoSelTerm;
                selYear = FeesUI.autoSelYear;
            }
            else
            {
                filterListOfForms = FeesUI.filterListOfForms;
                selTerm = FeesUI.selTerm;
                selYear = FeesUI.selYear;
            }
        }

        private void OverHeadListItem_Load(object sender, EventArgs e)
        {
            this.bTBOverHaed.Text = OverHeadName;
            //refresh the data grid
            if (FeesUI.autoGen)
            {
                GridData(FeesUI.autoFilterListOfForms, FeesUI.autoSelTerm, FeesUI.autoSelYear);
            }
            else
            {
                GridData(filterListOfForms, selTerm, selYear);
            }
        }

        private void btnAssignItem_Click(object sender, EventArgs e)
        {
            //startup the AssignFeeItem form
            //pass overhead string & fmStore & selYear
            if (filterListOfForms != null)
            {

                FrmAssignFeeItem frm = new FrmAssignFeeItem(OverHeadName, filterListOfForms, selTerm, selYear);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
                //logic hide if save was clicked
                if (frm.IsSaveClicked)
                {
                    //TODO hide dispose control;


                }
                //refresh the data grid
                if (FeesUI.autoGen)
                {
                    GridData(FeesUI.autoFilterListOfForms, FeesUI.autoSelTerm, FeesUI.autoSelYear);
                    //await GridDataPass(FeesUI.autoFilterListOfForms, FeesUI.autoSelTerm, FeesUI.autoSelYear);
                }
                else
                {
                    GridData(filterListOfForms, selTerm, selYear);
                }

                //Revive save for changes to be updated
                FeeUI_Show fui = FeeUI_Show.Instance;
                fui.btnSaveStructure.Visible = true;
            }
        }

        /// <summary>
        /// // data about all forms instead of just one
        //Used to give updated data for correct deletion in the grid
        /// </summary>
        /// <param name="fmstore"></param>
        /// <param name="tmData"></param>
        /// <param name="yrData"></param>
        /// <returns></returns>
        public async Task<List<OverHeadCategoryPerYear>> GridDataPass(List<int> fmstore, int tmData, int yrData)
        {
            // data about all forms instead of just one
            //Used to give updated data for correct deletion in the grid
            return await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategoryPerYears.
                                OrderBy(c => c.Id).
                                Where(c => c.Year == yrData & c.Term == tmData).
                                ToList();
                }
            });
        }
        public async void GridData(List<int> fmstore, int tmData, int yrData)
        {
            if (fmstore == null)
            {
                //check if auto generated fee structure
                if (FeesUI.autoGen)
                {
                    MessageBox.Show("The PassMoreDataDelegate for AutoGen is null", "No Fee Structure selected");
                }
                else
                {
                    MessageBox.Show("The PassMoreDataDelegate is null", "No Fee Structure selected");
                }
            }
            var overHeadPYListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    int r = fmstore[0];
                    return context.OverHeadCategoryPerYears.
                                OrderBy(c => c.Id).
                                Where(c => c.Form == r & c.Year == yrData & c.Term == tmData).
                                ToList();
                }
            });

            decimal totalCash = 0;
            FeeUI_Show feeuiShow = FeeUI_Show.Instance;
            feeuiShow.bGrid.Rows.Clear();
            //Populate grid
            foreach (var fo in overHeadPYListAsync)
            {
                feeuiShow.bGrid.Rows.Add(new string[]
                {
                        null,
                        fo.Category,
                        "KES "+fo.Amount.ToString()
                });
                totalCash += fo.Amount;
            }
            totalCashPas = totalCash;

        }


        private void OverHeadListItem_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void OverHeadListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(247, 246, 248);
        }
    }
}
