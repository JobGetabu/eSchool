
//using SoftwareLocker;
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


            //check registration here
            SoftwareLocker.TrialMaker t = new SoftwareLocker.TrialMaker("EschoolKe", Application.StartupPath + "\\EschoolReg.reg",
                Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\EschoolReg.dbf",
                "Phone: 0708440184 -\nMobile: Developer Job-",
                30, 300, "777");

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
                                4, 54, 87, 56, 123, 10, 3, 62,
                                7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;

            SoftwareLocker.TrialMaker.RunTypes RT = t.ShowDialog();

            if (RT == SoftwareLocker.TrialMaker.RunTypes.Trial)
            {
                try
                {
                    Properties.Settings.Default.TrialExpireDt = DateTime.Now.AddDays(SoftwareLocker.FrmActivate1.LeftDays);
                    Properties.Settings.Default.Save();
                    lblExpiry.Text = Properties.Settings.Default.TrialExpireDt.ToShortDateString();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    Properties.Settings.Default.TrialExpireDt = DateTime.Now.AddDays(SoftwareLocker.FrmActivate1.LeftDays);
                    Properties.Settings.Default.Save();
                    lblExpiry.Text = Properties.Settings.Default.TrialExpireDt.ToShortDateString();
                }
                catch (Exception) { }
            }
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.TrialExpireDt = DateTime.Now.AddDays(SoftwareLocker.FrmActivate1.LeftDays);
                Properties.Settings.Default.Save();
            }
            catch (Exception) { }


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

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            string twitterPage = "https://twitter.com/eschoolke";
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(twitterPage);
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception) { }

        }

        private void btnfB_Click(object sender, EventArgs e)
        {
            string fbPage = "https://web.facebook.com/eschoolke?_rdc=1&_rdr";
            try
            {
                System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo(fbPage);
                System.Diagnostics.Process.Start(sInfo);
            }
            catch (Exception) { }
        }
    }
}
