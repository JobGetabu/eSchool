﻿using System;
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
    public partial class FeesStructure : UserControl
    {
        private static FeesStructure _instance;

        public static FeesStructure Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeesStructure();
                }
                return _instance;
            }
        }
        public FeesStructure()
        {
            InitializeComponent();
        }

        private void TabSwitcher(Control UIinstance)
        {
            if (!FeesStructure.Instance.container.Controls.Contains(UIinstance))
            {
                FeesStructure.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        private async Task<bool> AnyCurrentFeeStruct(int cYear)
        {
            bool available = false;
            var queryAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.GroupedFeeStructures.Select(c => new
                    {
                        c.selYear
                    }).ToList();
                }
            });

            foreach (var cur in queryAsync)
            {
                if (cYear == cur.selYear)
                {
                    available = true;
                    return available;
                }
            }
            return available;
        }


        private async void FeesStructure_Load(object sender, EventArgs e)
        {
            //UI code
            this.lblYFeeStructure.Text = $"{Properties.Settings.Default.CurrentYear.ToString()} Fees Structures"; //2017 Fees Structures

            //TODO 1 Check if there already existing fee structure for that 
            //year and decide which UI to load
            //create an option to create feeStructure in the dropdown option
            bool ch = await AnyCurrentFeeStruct(Properties.Settings.Default.CurrentYear);
            if (ch)
            {
                //show FeeUI_List
                TabSwitcher(FeeUI_List.Instance);
            }
            else
            {
                TabSwitcher(FeeUI_Default.Instance);
            }

            //loading comboBox

            this.bMenu.AddItem("Print");
            this.bMenu.AddItem("New Fee Structure");
        }

        private void bMenu_onItemSelected_1(object sender, EventArgs e)
        {
            if (bMenu.selectedIndex == 0)
            {
                MessageBox.Show("Select item to print ", "Error");
            }
            if (bMenu.selectedIndex == 1)
            {
                CreateFeeStructClick();
            }
        }
        private void CreateFeeStructClick()
        {
            int term = Properties.Settings.Default.CurrentTerm;
            int year = Properties.Settings.Default.CurrentYear;

            FrmCreateFStruct frm = new FrmCreateFStruct(term, year);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //need to send FeeUI_Show to front
                //at exit save of FrmCreateFStruct

            }
        }

        private void bTBtnChangeYear_Click(object sender, EventArgs e)
        {
            //UI code set the label to ""
            this.lblFFeeStructure.Text = "";
            this.lblTFeeStructure.Text = "";
            FrmChangeYear frm = new FrmChangeYear();
            if (frm.ShowDialog() == DialogResult.OK)
            {              
                FeeUI_List ful = FeeUI_List.Instance;
                //show FeeUI_List
                TabSwitcher(FeeUI_List.Instance);
                //updates the list with current year fee structures
                ful.LoadListAsync(FrmChangeYear.selChangeYear);
            }
        }

        public void SwitchTabExt()
        {
            //show FeeUI_List
            TabSwitcher(FeeUI_List.Instance);
        }
        public void SwitchTabExt2()
        {
            //show FeeUI_List
            TabSwitcher(FeeUI_Show.Instance);
        }
    }
}
