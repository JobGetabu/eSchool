using custom_alert_notifications;
using eSchool.TheLogins;
using SoftwareLocker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    bool is_trial;
                    //If prog is not in trial continue normally
                    //check registration here
                    TrialMaker t = new TrialMaker("EschoolKe", Application.StartupPath + "\\EschoolReg.reg",
                        Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\EschoolReg.dbf",
                        "Phone: 0708440184 -\nMobile: Developer Job-",
                        30, 300, "777");

                    byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
                                        4, 54, 87, 56, 123, 10, 3, 62,
                                        7, 9, 20, 36, 37, 21, 101, 57};
                    t.TripleDESKey = MyOwnKey;



                    TrialMaker.RunTypes RT = t.ShowDialog();

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
                        //pass user
                        Application.Run(new Frm_Home(elogin.currentUser));
                    }
                    else
                    {
                        // must register launch about
                        FrmAbout abt = new FrmAbout();
                        abt.Show();
                    }

                    try
                    {
                        Properties.Settings.Default.TrialExpireDt = DateTime.Now.AddDays(FrmActivate1.LeftDays);
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception) { }


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
