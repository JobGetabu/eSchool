using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TransionX
{
    public partial class FilterContentTerms : UserControl
    {
        public FilterContentTerms()
        {
            InitializeComponent();

            Nullify();
            ListInit();
        }
        
        public List<int> selFilTerms;

        public string trmslbl;

        private void ListInit()
        {
            selFilTerms.Clear();
            selFilTerms.Add(1); selFilTerms.Add(2); selFilTerms.Add(3);
            // switch1.Value = true; switch2.Value = true; switch3.Value = true;
        }
        private void Nullify()
        {
            trmslbl = "";
            selFilTerms = new List<int>();

        }
        private void FilterContentTerms_Load(object sender, EventArgs e)
        {
            
        }
        private void lblSetter(string tag, bool value)
        {
            if (value)
            {
                if (trmslbl.Contains(tag))
                {
                    trmslbl.Replace(tag, "");
                }
            }
            else
            {
                if (!trmslbl.Contains(tag))
                {
                    trmslbl.Replace(tag, "");
                }
            }
        }

        private void Switch_OnValueChange(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuiOSSwitch sw = sender as Bunifu.Framework.UI.BunifuiOSSwitch;
            if (sw.Value)
            {
                selFilTerms.Add(int.Parse(sw.Tag.ToString()));
            }
            else
            {
                selFilTerms.Remove(int.Parse(sw.Tag.ToString()));
            }
        }
    }
}
