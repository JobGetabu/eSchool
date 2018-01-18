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


            TrialMaker t = new TrialMaker("eschool", Application.StartupPath + "\\RegFile.reg",
               Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\TMSetp.dbf",
               "Phone: -\nMobile: -",
               1, 3, "777");

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;

            TrialMaker.RunTypes RT = t.ShowDialog();
            bool is_trial;
            if (RT != TrialMaker.RunTypes.Expired)
            {
                if (RT == TrialMaker.RunTypes.Full)
                    is_trial = false;
                else
                    is_trial = true;

                Application.Run(new Form1(is_trial));
            }








            // FrmActivate act = new FrmActivate();
            //act.ShowDialog();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            //load the licence file

            this.tbLegalInfo.Text = MyLogo.License_eschool.ToString();
            this.tbLegalInfo.Text.TrimStart();
        }
    }
}
