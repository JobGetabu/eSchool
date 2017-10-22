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
    public partial class FeesStructure : UserControl
    {
        private static FeesStructure _instance;
        private List<int> filterList;
        private int selTerm;
        private int selYear;



        public static FeesStructure Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeesStructure();
                }
                return _instance;
            }
        }
        public FeesStructure()
        {
            InitializeComponent();
        }

        private void TabSwitcher(Control UIinstance)
        {
            if (!FeesStructure.Instance.container.Controls.Contains(UIinstance))
            {
                FeesStructure.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        private bool CheckForCurrentFeeStruct(int cTerm, int cYear)
        {
            bool available = false;
            using (var context = new EschoolEntities())
            {
                var query = context.FeeStructures.Select(c => new
                {
                    c.Term,
                    c.Year
                }).ToList();

                foreach (var cur in query)
                {
                    if (cTerm == cur.Term)
                    {
                        if (cYear == cur.Year)
                        {
                            available = true;
                            return available;
                        }
                    }
                }
            }
            return available;
        }
        private void bMenu_onItemSelected(object sender, EventArgs e)
        {
            if (bMenu.selectedIndex == 1)
            {
                //TODO 1
                //create a delegate pointing to the create fee structure tile click
                //or just

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

        /// <summary>
        /// This method is called each time a fee structure is created 
        /// </summary>
        /// <param name="fmstore","tmData","yrData"></param>
        public void GridDataFilter(List<int> fmstore, int tmData, int yrData)
        {
            FeeUI_Show ins = FeeUI_Show.Instance;
            if (fmstore != null)
            {
                using (var context = new EschoolEntities())
                {
                    if (fmstore.Count > 1)
                    {
                        int r = int.Parse(fmstore[0].ToString());

                        ins.overHeadCategoryPerYearBindingSource.DataSource =
                             context.OverHeadCategoryPerYears.OrderBy(c => c.Id)
                                                             .Where(c => c.Form == r && c.Term == tmData && c.Year == yrData)
                                                             .ToList();
                    }
                    else
                    {
                        ins.overHeadCategoryPerYearBindingSource.DataSource =
                             context.OverHeadCategoryPerYears.OrderBy(c => c.Id)
                                                             .Where(c => c.Term == tmData && c.Year == yrData)
                                                             .ToList();
                    }
                }
            }
        }

        /// <summary>
        /// This method is called each time a fee structure is created returning a list of school forms
        /// </summary>
        /// <param name="sender", "e"></param>
        public void GridDataList(object sender, PassDataEventArgs e)
        {
            filterList = e.pfmStore;
            selTerm = e.ptmStore;
            selYear = e.pyrStore;
        }

        private void FeesStructure_Load(object sender, EventArgs e)
        {

            //TODO 1 Check if there already existing fee structure for that 
            //term and decide which UI to load
            //create an option to create feeStructure in the dropdown option

            if (CheckForCurrentFeeStruct(Properties.Settings.Default.CurrentTerm, Properties.Settings.Default.CurrentYear))
            {
                TabSwitcher(FeeUI_Show.Instance);
            }
            else
            {

                TabSwitcher(FeeUI_Default.Instance);
            }

            //loading comboBox

            this.bMenu.AddItem("Print");
            this.bMenu.AddItem("New Fee Structure");

            #region GridData
            ///this is data loaded at save with new fee structure
            // overHeadCategoryPerYearBindingSource.DataSource = context.OverHeadCategoryPerYears.OrderBy(c => c.Id).ToList();
            //alternative
            // initialize the data by subscribing our method
            FrmCreateFStruct.ListUpdated += new FrmCreateFStruct.PassMoreDataDelegate(GridDataList);
            //filter the data
            GridDataFilter(filterList, selTerm, selYear);
            #endregion
        }
    }
}
