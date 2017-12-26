using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class NewSettings : UserControl
    {

        //Singleton pattern ***best practices***
        private static NewSettings _instance;

        public static NewSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NewSettings();
                }
                return _instance;
            }
        }
        public NewSettings()
        {
            InitializeComponent();
        }

        private void NewSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
