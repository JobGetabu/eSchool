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
    public partial class FeesUI : UserControl
    {
        public static List<int> filterListOfForms;
        public static int selTerm;
        public static int selYear;

        private static FeesUI _instance;
        public static FeesUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeesUI();
                }
                return _instance;
            }
        }
        public FeesUI()
        {
            InitializeComponent();
        }

        private void FeesUI_Load(object sender, EventArgs e)
        {
            //UI code
            this.pBoxLogoTerm.Image = FeeUILogo.logo_term2;
            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();
            //tab1 selected =true;
            //Show FeePayment
            TabSwitcher(FeePayment.Instance);


            #region GridData
            ///this is data loaded at save with new fee structure
            // initialize the data by subscribing our method
            FrmCreateFStruct.ListUpdated += new FrmCreateFStruct.PassMoreDataDelegate(GridDataList);
            //filter the data
            GridDataFilter(filterListOfForms, selTerm, selYear);
            #endregion
        }
        private void TabSwitcher(Control UIinstance)
        {
            if (!FeesUI.Instance.container.Controls.Contains(UIinstance))
            {
                FeesUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
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
            filterListOfForms = e.pfmStore;
            selTerm = e.ptmStore;
            selYear = e.pyrStore;
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab1.Width;
            bunifuSeparator1.Left = tab1.Left;

            //Show FeePayment
            TabSwitcher(FeePayment.Instance);
        }

        private async void tab2_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab2.Width;
            bunifuSeparator1.Left = tab2.Left;

            //Show 
            TabSwitcher(FeesStructure.Instance);
        }

        //check existence multiple fee strucure current year
        //private async Task<bool> MultipleFeeStructureAsync()
        //{
        //    bool check = false;
        //    var structureListAsync = await Task.Factory.StartNew(() =>
        //    {
        //        using (var context = new EschoolEntities())
        //        {
        //            return context.FeeStructures.OrderBy(c => c.Id).ToList();
        //        }
        //    });

        //    int count = 0;
        //    foreach (var fs in structureListAsync)
        //    {
        //        if (fs.Year == Properties.Settings.Default.CurrentYear)
        //        {
        //            if (fs.Term == Properties.Settings.Default.CurrentTerm)
        //            {
        //                count+=1;
        //            }
        //            if (count > 0)
        //            {
        //                check = true;
        //                break;
        //            }
        //        }
        //    }
        //    return check;
        //}
        private void tab3_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab3.Width;
            bunifuSeparator1.Left = tab3.Left;

            //TODO charts baby
        }
    }
}
