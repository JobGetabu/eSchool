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


    public delegate void CollapseToolBarHandler();
    public partial class DashboardUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static DashboardUI _instance;
        public static DashboardUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DashboardUI();
                }
                return _instance;
            }
        }

        public static event CollapseToolBarHandler collapse;
        public DashboardUI()
        {
            InitializeComponent();
            this.flowPanelBody.Padding = new Padding(2, 1, 2, 10);
        }
        public void Global_DashboardUI_Load()
        {
            
            this.monthlyOverview1.Global_MonthlyOverview();
           
            this.moneyOverview1.Global_MoneyOverview_Load();
           
            this.receiptOverview1.Global_ReceiptOverview_Load();
            
            this.termlyOverview1.Global_TermlyOverview();
           
            this.transOverview1.Global_TransOverview_Load();
          
        }
        private void DashboardUI_Load(object sender, EventArgs e)
        {
            DashboardTime();
        }
        void DashboardTime()
        {
            DateTime dt = DateTime.Now;

            string month = "";
            switch (dt.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
                default:
                    break;
            }
            this.bunifuCustomLabelDashboadTime.Text = $"{month} {dt.Year}";
        }

        private void bunifuImageBtnColapse_Click_1(object sender, EventArgs e)
        {
            collapse?.Invoke();
        }
    }
}
