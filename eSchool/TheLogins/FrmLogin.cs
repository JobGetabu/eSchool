using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TheLogins
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabSignUp_Click(object sender, EventArgs e)
        {
            btnExit.Image = GridIcon.Shutdown_px;  // exit is now invisible;
            btnExit.Focus();

            //UI code          
            if (slideA.Left == 626)
            {
                slideB.Visible = false;
                slideB.Left = 626;

                slideA.Visible = false;
                slideA.Left = 39;
                slideA.Visible = true;
                slideA.Refresh();

                bSeparator1.Width = this.tabSignUp.Width;
                bSeparator1.Left = this.tabSignUp.Left;

            }

        }

        private void tabSignIn_Click(object sender, EventArgs e)
        {
            btnExit.Image = GridIcon.Shutdown_32px;  //red exit is now visible;
            btnExit.Focus();

            //UI code          
            if (slideB.Left == 626)
            {
                slideA.Visible = false;
                slideA.Left = 626;

                slideB.Visible = false;
                slideB.Left = 39;
                slideB.Visible = true;
                slideB.Refresh();


                bSeparator1.Width = this.tabSignIn.Width;
                bSeparator1.Left = this.tabSignIn.Left;

            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tabSignUp_Click(sender,e);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
