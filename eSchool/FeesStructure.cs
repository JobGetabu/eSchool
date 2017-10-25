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
        private List<int> filterListOfForms;
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

        private async Task<bool> CheckForCurrentFeeStruct(int cTerm, int cYear)
        {
            bool available = false;
            var queryAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.FeeStructures.Select(c => new
                    {
                        c.Term,
                        c.Year
                    }).ToList();
                }
            });

            foreach (var cur in queryAsync)
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
            return available;
        }
        

        private async void FeesStructure_Load(object sender, EventArgs e)
        {

            //TODO 1 Check if there already existing fee structure for that 
            //term and decide which UI to load
            //create an option to create feeStructure in the dropdown option
            bool ch = await CheckForCurrentFeeStruct(Properties.Settings.Default.CurrentTerm, Properties.Settings.Default.CurrentYear);
            if (ch)
            {
                //show FeeUI_List
                TabSwitcher(FeeUI_Default.Instance);
            }
            else
            {

                TabSwitcher(FeeUI_Default.Instance);
            }

            //loading comboBox

            this.bMenu.AddItem("Print");
            this.bMenu.AddItem("New Fee Structure");
        }

        private void bMenu_onItemSelected_1(object sender, EventArgs e)
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
    }
}
