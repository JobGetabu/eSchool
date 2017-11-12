using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Importss
{
    public partial class FrmFilterStudents : Form
    {

        private int close;
        public static bool male;
        public static bool female;
        public static List<int> selFilForms;
        public static string FrmsLbl = "Form";
        public FrmFilterStudents()
        {
            InitializeComponent();
            Nullify();
        }

        private void Nullify()
        {
            male = false; female = false;
            selFilForms = new List<int>();
            FrmsLbl = "Form ";
    }

        private void ListInit()
        {
            selFilForms.Clear();
            selFilForms.Add(1); selFilForms.Add(2); selFilForms.Add(3); selFilForms.Add(4);
            male = true;
            female = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmFilterStudents_Load(object sender, EventArgs e)
        {
            ListInit();
        }

        private void FrmFilterStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }
            if (selFilForms.Count == -1)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select at least a form !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            foreach (var f in selFilForms)
            {
                FrmsLbl +=" "+f.ToString();
            }

            e.Cancel = false;
        }

        private void Gender_Switch_OnValueChange(object sender, EventArgs e)
        {

            if (sw_male.Value == false)
            {
                if (sw_female.Value == false)
                {
                    sw_male.Value = true;
                    sw_male.Validate();
                    sw_male.Update();
                }
            }
            else if (sw_female.Value == false)
            {
                if (sw_male.Value == false)
                {
                    sw_female.Value = true;
                    sw_female.Validate();
                    sw_female.Update();
                }
            }

            male = sw_male.Value;
            female = sw_female.Value;
        }
        private void Switch_OnValueChange(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuiOSSwitch sw = sender as Bunifu.Framework.UI.BunifuiOSSwitch;
            if (sw.Value)
            {
                selFilForms.Add(int.Parse(sw.Tag.ToString()));
            }
            else
            {
                selFilForms.Remove(int.Parse(sw.Tag.ToString()));
            }
        }
    }
}
