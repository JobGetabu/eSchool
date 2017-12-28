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

namespace eSchool
{
    public delegate void ReLoadSettingsHandler(object sender, EventArgs e);
    public partial class FrmAddCategories : Form
    {
        String catType = "";
        private int close;
        public FrmAddCategories()
        {
            InitializeComponent();
        }
       
        private void FrmAddCategories_Load(object sender, EventArgs e)
        {            
            this.cbCat.SelectedIndex = 1;
            catType = (string)cbCat.SelectedItem.ToString();
        }

        private void metroComboBoxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            catType = (string)cbCat.SelectedItem;           
        }

        private void FrmAddCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }

            if (string.IsNullOrEmpty(tbCatName.Text))
            {
                alert.Show("Required info \n Input a Category !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            using (var context = new EschoolEntities())
            {
                //category object
                Category cat = new Category();
                cat.CategoryName = tbCatName.Text;
                cat.Type = catType;

                context.Categories.Add(cat);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }

            alert.Show("Category Added !", alert.AlertType.success);

            e.Cancel = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }
    }
}
