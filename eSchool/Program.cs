using eSchool.TheLogins;
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
                    Application.Run(new Frm_Home()); 
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
