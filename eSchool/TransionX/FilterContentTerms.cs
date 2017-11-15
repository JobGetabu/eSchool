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
        //Singleton pattern ***best practices***
        private static FilterContentTerms _instance;
        public static FilterContentTerms Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FilterContentTerms();
                }
                return _instance;
            }
            set
            {
                value = _instance;
            }
        }
        public FilterContentTerms()
        {
            InitializeComponent();          
        }
        
        public List<int> selFilTerms;

        public string trmslbl;

        private void ListInit()
        {
            selFilTerms.Clear();
            selFilTerms.Add(1); selFilTerms.Add(2); selFilTerms.Add(3);
        }
        private void Nullify()
        {
            trmslbl = "";
            selFilTerms = new List<int>();

        }
        private void FilterContentTerms_Load(object sender, EventArgs e)
        {
            Nullify();
            ListInit();
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
