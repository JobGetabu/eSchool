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
        private void FrmFilterTransaction_Load(object sender, EventArgs e)
        {
            TabSwitcher(FilterContentTerms.Instance);
        }

        private void FrmFilterTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        bool _isIt;
        private void btnSwap_Click(object sender, EventArgs e)
        {
            _isIt = !_isIt;

            if (_isIt)
            {
                TabSwitcher(FilterContentDates.Instance);              
            }
            else
            {
                TabSwitcher(FilterContentTerms.Instance);
            }

        }
    }
}
