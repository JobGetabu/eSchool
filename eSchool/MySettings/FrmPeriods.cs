using custom_alert_notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.MySettings
{
    public partial class FrmPeriods : Form
    {
        public FrmPeriods()
        {
            InitializeComponent();
        }

        private int close;
        private int selTerm = 0;
        private void FrmPeriods_Load(object sender, EventArgs e)
        {

        }

        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            selTerm = int.Parse(cbTerm.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private async void FrmPeriods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (selTerm == 0)
            {
                alert.Show("Required info \n Select Term !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            int test1;
            if (!int.TryParse(tbYear.Text, out test1))
            {
                alert.Show("Only numeric values \n allowed on year input !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (test1 < 1979)
            {
                alert.Show("Invalid year input !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            Properties.Settings.Default.CurrentTerm = selTerm;
            Properties.Settings.Default.CurrentYear = test1;
            Properties.Settings.Default.Save();

            using (var context = new EschoolEntities())
            {

                //add five last years
                for (int i = 0; i < 4; i++)
                {
                    SchoolPeriodYear y = new SchoolPeriodYear();
                    int xx = Properties.Settings.Default.CurrentYear - i;
                    y.Year = xx;
                    if (!(await DoesYearExist(xx)))
                    {
                        //add it
                        context.SchoolPeriodYears.Add(y);
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }


                //populate the schoolPeriods
                //check term 3 set next year available
                if (Properties.Settings.Default.CurrentTerm == 3)
                {
                    int x = Properties.Settings.Default.CurrentYear + 1;
                    //Add the year in the SchoolPeriodYears
                    SchoolPeriodYear spy = new SchoolPeriodYear();
                    spy.Year = x;

                    if (!(await DoesYearExist(x)))
                    {
                        //add it
                        context.SchoolPeriodYears.Add(spy);
                        try
                        {
                            context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                } 
            }


            alert.Show("Updated !", alert.AlertType.success);
            alert.Show("Updated\nRestart to effect changes !", alert.AlertType.success);
            e.Cancel = false;
        }

        private async Task<Boolean> DoesYearExist(int year)
        {
            var yAsyncList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.SchoolPeriodYears.ToList();
                }
            });

            foreach (var item in yAsyncList.Where(x => x.Year == year))
            {
                if (item.Year == year)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
