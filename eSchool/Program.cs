using custom_alert_notifications;
using eSchool.TheLogins;
using SoftwareLocker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    static class Program
    {
        private static FrmLogin elogin = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TODO 1 Deployment code
            //CreateIfNotExists(Frm_Home.databaseFile);
            //When need arises
            //Application.Run(Frm_Home.Instance);


            try
            {
                elogin = new FrmLogin();
                Application.Run(elogin);
                if (elogin.DialogResult == DialogResult.OK)
                {
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
                    bool is_trial;
                    if (RT != TrialMaker.RunTypes.Expired)
                    {
                        if (RT == TrialMaker.RunTypes.Full)
                        {
                            is_trial = false;

                            Properties.Settings.Default.IsTrialMode = false;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            is_trial = true;
                            Properties.Settings.Default.IsTrialMode = true;
                            Properties.Settings.Default.Save();
                        }

                        //runs anyway since trial still on
                        Application.Run(new Frm_Home(elogin.currentUser));
                    }
                    else 
                    {
                        // must register launch about

                    }

                    //pass user
                    //Application.Run(new Frm_Home(elogin.currentUser));
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void CreateIfNotExists(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Set the data directory to the users %AppData% folder            
            // So the database file will be placed in:  C:\\Users\\<Username>\\AppData\\Roaming\\            
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            // Enure that the database file is present
            if (!System.IO.File.Exists(System.IO.Path.Combine(path, fileName)))
            {
                //Get path to our .exe, which also has a copy of the database file
                var exePath = System.IO.Path.GetDirectoryName(
                    new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
                //Copy the file from the .exe location to the %AppData% folder
                System.IO.File.Copy(
                    System.IO.Path.Combine(exePath, fileName),
                    System.IO.Path.Combine(path, fileName));
            }
        }

    }
}
