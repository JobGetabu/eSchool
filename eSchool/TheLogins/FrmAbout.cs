using productActivation;
using SoftwareLocker;
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
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (btnActivate.Enabled)
            {
                btnActivate.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            //init trialMaker library here
            //TODO check trial mode


            //check registration here   //TODO test 3 runs
            TrialMaker t = new TrialMaker("eschool", Application.StartupPath + "\\RegFile.reg",
                Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\eschoolReg.dbf",
                "Phone: 0708440184 -\nMobile: -",
                1, 3, "777");

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
                                4, 54, 87, 56, 123, 10, 3, 62,
                                7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;

            TrialMaker.RunTypes RT = t.ShowDialog();
            
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            //load the licence file

            this.tbLegalInfo.Text = MyLogo.License_eschool.ToString();
            this.tbLegalInfo.Text.TrimStart();

            //look at trial
            if (Properties.Settings.Default.IsTrialMode)
            {
                lblStatus.Text = "Not Activated";
                lblExpiry.Text = Properties.Settings.Default.TrialExpireDt.ToShortDateString();
            }
            else
            {
                lblStatus.Text = "Activated";
                lblExpiry.Text = "20/20/90";
            }

        }
    }
}
