﻿using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class FrmFilter : Form
    {
        public FrmFilter()
        {
            InitializeComponent();
            Nullify();
        }
        private int close;
        public static int selFilYear;
        public static int selFilTerm;
        public static List<int> selFilForms; 
        private void FrmFilter_Load(object sender, EventArgs e)
        {
            PreparingComboBoxes();
            ListInit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void Nullify()
        {
            selFilYear = 0;
            selFilTerm = 0;
            selFilForms = new List<int>();
        }

        private void ListInit()
        {
            selFilForms.Clear();
            selFilForms.Add(1); selFilForms.Add(2); selFilForms.Add(3); selFilForms.Add(4);
        }
        private void FrmFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (selFilYear == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select a year !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (selFilTerm == 0)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select a term !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (switch1.Value & switch2.Value & switch3.Value & switch4.Value)
            {
                selFilForms.Clear();
                selFilForms.Add(1); selFilForms.Add(2); selFilForms.Add(3); selFilForms.Add(4);
            }
           
            if (selFilForms.Count == -1)
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Select at least a form !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            e.Cancel = false;
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
        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilYear = (int)cbYear.SelectedItem;
        }

        private void PreparingComboBoxes()
        {
            using (var context = new EschoolEntities())
            {
                var listYear = context.SchoolPeriodYears.OrderByDescending(y => y.Year).Select(y => y.Year).ToList();
                foreach (var y in listYear)
                {
                    cbYear.Items.Add(y);
                }
            }

            cbTerm.Items.Add(1);
            cbTerm.Items.Add(2);
            cbTerm.Items.Add(3);
        }

        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            selFilTerm = (int)cbTerm.SelectedItem;
        }
    }
}
