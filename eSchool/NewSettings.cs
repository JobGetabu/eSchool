using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using custom_alert_notifications;
using eSchool.MySettings;

namespace eSchool
{
    public partial class NewSettings : UserControl
    {

        //Singleton pattern ***best practices***
        private static NewSettings _instance;

        public static NewSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NewSettings();
                }
                return _instance;
            }
        }
        public NewSettings()
        {
            InitializeComponent();
        }

        private void NewSettings_Load(object sender, EventArgs e)
        {
            //init school details
            InitSchool();
            //change color of Type to greenish
            gData.Columns[0].DefaultCellStyle.ForeColor = Color.FromArgb(23, 123, 189);
            GridInitilizer();
        }

        private void InitSchool()
        {
            lblAddress.Text = Properties.Settings.Default.schoolAddress;//
            btnScCell.Text = Properties.Settings.Default.schoolCell;
            btnScEmail.Text = Properties.Settings.Default.schoolEmail;
            lblScType.Text = $"Secondary - {Properties.Settings.Default.schoolType}"; //Secondary - Bording School
            lblName.Text = Properties.Settings.Default.schoolName;
            lblScCode.Text = $"Code : {Properties.Settings.Default.schoolreg}"; //Code : 2040700
        }
        public async void GridInitilizer()
        {
            var catListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Categories
                    .OrderBy(t => t.Id)
                    .ToList();
                }
            });
            gData.Rows.Clear();
            foreach (var item in catListAsync)
            {
                gData.Rows.Add(new string[]
                {
                       item.Type,
                       item.CategoryName
                });
            }
        }

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //this.lblRowCount.Text = gData.Rows.Count.ToString();
            this.gData.Rows[e.RowIndex].Cells[2].Value = GridIcon.Trash_Can_50px;
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                context.Entry<Category>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();

                                //short Custom Notification
                                alert.Show("Deleted", alert.AlertType.warnig);
                                gData.Rows[e.RowIndex].Visible = false;
                                //Load the grid again
                                GridInitilizer();
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");
                            }
                        }
                    }
                }
            }
        }

        private async Task<Category> GridDelImageAsync(int rowIndex)
        {
            List<Category> catList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Categories.ToList();
                }
            });

            string details;
            details = $"({(string)this.gData.Rows[rowIndex].Cells[0].Value}){(string)this.gData.Rows[rowIndex].Cells[1].Value}";

            foreach (Category cc in catList)
            {
                string s = $"({cc.Type}){cc.CategoryName}";
                if (s.Equals(details))
                {
                    return cc;
                }
            }
            return null;
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            FrmAddCategories frm = new FrmAddCategories();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GridInitilizer();
            }

        }

        private void btnUpdateSchool_Click(object sender, EventArgs e)
        {
            FrmAddSchool frm = new FrmAddSchool();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                InitSchool();
            }
        }
    }
}
