using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Profiles
{
    public partial class UserProfile : UserControl
    {

        private static UserProfile _instance;
        public static UserProfile Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserProfile();
                }
                return _instance;
            }
        }
        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
