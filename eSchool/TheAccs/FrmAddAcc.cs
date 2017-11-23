using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TheAccs
{
    public partial class FrmAddAcc : Form
    {
        public FrmAddAcc()
        {
            InitializeComponent();
        }

        private int close;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmAddAcc_Load(object sender, EventArgs e)
        {

        }

        private void FrmAddAcc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }
        }

       
    }
}
