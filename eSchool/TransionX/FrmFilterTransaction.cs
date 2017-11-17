using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TransionX
{
    public partial class FrmFilterTransaction : Form
    {

        //Singleton pattern ***best practices***
        private static FrmFilterTransaction _instance;
        public static FrmFilterTransaction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FrmFilterTransaction();
                }
                return _instance;
            }
        }
        public FrmFilterTransaction()
        {
            InitializeComponent();
        }
        private void TabSwitcher(Control UIinstance)
        {
            UIinstance.Visible = false;
            if (!FrmFilterTransaction.Instance.container.Controls.Contains(UIinstance))
            {
                UIinstance.Visible = false;
                FrmFilterTransaction.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();

                try
                {
                    this.bunifuTransition1.ShowSync(UIinstance);
                }
                catch (InvalidOperationException)
                {
                    //this exception occurs when the transition is not complete ;(
                }
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.Visible = false;
                try
                {
                    this.bunifuTransition1.ShowSync(UIinstance);
                }
                catch (InvalidOperationException)
                {
                    //this exception occurs when the transition is not complete ;(
                }
                UIinstance.BringToFront();
            }
        }

        private int close;
        public  int selFilYear;
        public  List<int> selFilTerms;
        public  DateTime selDate;
        public  string trmslbl;
        public  bool IsTerms; 
        private void Nullify()
        {
            trmslbl = "";
            selFilYear = 0;
            selFilTerms = new List<int>();

            selDate = DateTime.Now;
            IsTerms = false;
        }

        private void ListInit()
        {
            selFilTerms.Clear();
            selFilTerms.Add(1); selFilTerms.Add(2); selFilTerms.Add(3);
        }
        private void FrmFilterTransaction_Load(object sender, EventArgs e)
        {
            Nullify();
            ListInit();
            PreparingComboBoxesAsync();
            TabSwitcher(FilterContentTerms.Instance);
            IsTerms = true;
        }

        private async void PreparingComboBoxesAsync()
        {
            using (var context = new EschoolEntities())
            {
                var listYear = Task.Factory.StartNew(() =>
                {
                    return context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                });

                foreach (var y in await listYear)
                {
                    cbYear.Items.Add(y);
                }
            }
        }
        private void FrmFilterTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (selFilYear == 0)
            {
                MetroMessageBox.Show(this, "Select a year !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            FilterContentTerms frmTerm = FilterContentTerms.Instance;
            selFilTerms = frmTerm.selFilTerms;

            FilterContentDates frmDates = FilterContentDates.Instance;
            selDate = frmDates.selDate;
           
            if (frmTerm.switch1.Value & frmTerm.switch2.Value & frmTerm.switch3.Value)
            {
                ListInit();
            }
            if (IsTerms)
            {
                if (selFilTerms.Count == 0)
                {
                    //TODO custom notification
                    MetroMessageBox.Show(this, "Select at least a form !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            FilterContentDates.Instance = null;
            FilterContentTerms.Instance = null;
            _instance = null;
            e.Cancel = false;
        }

        bool _isIt;
        private void btnSwap_Click(object sender, EventArgs e)
        {
            _isIt = !_isIt;

            if (_isIt)
            {
                TabSwitcher(FilterContentDates.Instance);
                IsTerms = false;           
            }
            else
            {
                TabSwitcher(FilterContentTerms.Instance);
                IsTerms = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilYear = int.Parse(cbYear.SelectedItem.ToString());
        }

        private void lblSetter(string tag, bool value)
        {
            if (value)
            {
                if (trmslbl.Contains(tag))
                {
                    trmslbl.Replace(tag, "");
                }
            }
            else
            {
                if (!trmslbl.Contains(tag))
                {
                    trmslbl.Replace(tag, "");
                }
            }
        }
    }
}
