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
    public partial class FeesUI : UserControl
    {
        private static FeesUI _instance;
        public static FeesUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeesUI();
                }
                return _instance;
            }
        }
        public FeesUI()
        {
            InitializeComponent();
        }

        private void FeesUI_Load(object sender, EventArgs e)
        {

            //TODO 1 Check if there already existing fee structure for that 
            //term and decide which UI to load
            //create an option to create feeStructure in the dropdown option

            if (CheckForCurrentFeeStruct(Properties.Settings.Default.CurrentTerm, Properties.Settings.Default.CurrentYear))
            {
                TabSwitcher(FeeUI_Show.Instance);
            }
            else
            {

                TabSwitcher(FeeUI_Default.Instance);
            }

            //loading comboBox

            this.bMenu.AddItem("Print");
            this.bMenu.AddItem("New Fee Structure");
                   
        }
        private void TabSwitcher(Control UIinstance)
        {
            if (!FeesUI.Instance.container.Controls.Contains(UIinstance))
            {
                FeesUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        private bool CheckForCurrentFeeStruct(int cTerm, int cYear)
        {
            bool available = false;
            using (var context = new EschoolEntities())
            {
                var query = context.FeeStructures.Select(c => new
                {
                    c.Term,
                    c.Year
                }).ToList();

                foreach (var cur in query)
                {
                    if (cTerm == cur.Term)
                    {
                        if (cYear == cur.Year)
                        {
                            available = true;
                            return available;
                        }
                    }
                }
            }
            return available;
        }

        private void bMenu_onItemSelected(object sender, EventArgs e)
        {
            if (bMenu.selectedIndex == 1)
            {
                //TODO 1
                //create a delegate pointing to the create fee structure tile click
                //or just

                int term = Properties.Settings.Default.CurrentTerm;
                int year = Properties.Settings.Default.CurrentYear;

                FrmCreateFStruct frm = new FrmCreateFStruct(term, year);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //need to send FeeUI_Show to front
                    //at exit save of FrmCreateFStruct

                }
            }
        }
    }
}
