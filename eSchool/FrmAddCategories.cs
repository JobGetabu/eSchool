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
    public partial class FrmAddCategories : Form
    {
        public FrmAddCategories()
        {
            InitializeComponent();
        }

        //category object
        Category cat = new Category();
        private void FrmAddCategories_Load(object sender, EventArgs e)
        {            
            this.metroComboBoxCat.SelectedIndex = 1;
            cat.Type = (string)metroComboBoxCat.SelectedItem;
        }

        private void metroComboBoxCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cat.Type = (string)metroComboBoxCat.SelectedItem;           
        }

        private void bunifuFlatBtnSave_Click(object sender, EventArgs e)
        {
            if (metroTbxCatName.Text ==null)
            {
                //call notification
                return;
            }
            //TODO 1 Add custom notification here
            using (var category = new EschoolEntities())
            {
                cat.CategoryName = metroTbxCatName.Text;
                category.Categories.Add(cat);
                //call notification
                category.SaveChanges();
                this.Close();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
