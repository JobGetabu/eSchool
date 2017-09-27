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
    public partial class SettingsUI : UserControl
    {
        public SettingsUI()
        {
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
        }

        private void SettingsUI_Load(object sender, EventArgs e)
        {

        }
    }
}
