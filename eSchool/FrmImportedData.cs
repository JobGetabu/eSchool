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

namespace eSchool
{
    public partial class FrmImportedData : Form
    {
        DataTable tbl;
        DataSet tblSet;

        BindingSource importBS = new BindingSource();
        public FrmImportedData(DataTable tbl, DataSet tblSet)
        {
            InitializeComponent();
            this.tbl = tbl;
            this.tblSet = tblSet;
        }

        private void metroCBSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bCGridImportData.DataSource = tblSet.Tables[metroCBSheets.SelectedIndex];
        }

        private void FrmImportedData_Load(object sender, EventArgs e)
        {
            foreach (DataTable tbl in tblSet.Tables)
            {
                metroCBSheets.Items.Add(tbl.TableName);
            }

            this.bCGridImportData.DataSource = tbl;


        }

        private void bFClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFBSave_Click(object sender, EventArgs e)
        {
            using (EschoolEntities context = new EschoolEntities())
            {
                for (int i = 0; i < this.bCGridImportData.Rows.Count-1; i++)
                {
                    DataGridViewRow dr = bCGridImportData.Rows[i];
                    if (dr != null && (dr.Cells["ADMIN NO"].Value != null) && (dr.Cells["FIRST NAME"].Value != null) && (dr.Cells["FORM"].Value != null))
                    {
                        if (IsIdDuplicateuplicate((Convert.ToInt32(dr.Cells["ADMIN NO"].Value)), context) == true)
                        {
                            MetroMessageBox.Show(this, "One or more records already exists", "update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            dr.Cells["ADMIN NO"].Selected = true;
                           
                            dr.Cells["ADMIN NO"].ToolTipText = "This record exists in the database";
                            return;
                        }
                        context.Student_Basic.Add(new Student_Basic
                        {
                            //check for duplicate Admin number 
                            Admin_No = Convert.ToInt32(dr.Cells["ADMIN NO"].Value),
                            First_Name = dr.Cells["FIRST NAME"].Value.ToString(),
                            Middle_Name = dr.Cells["MIDDLE NAME"].Value.ToString(),
                            Last_Name = dr.Cells["LAST NAME"].Value.ToString(),
                            Form = Convert.ToInt32(dr.Cells["FORM"].Value.ToString()),
                            Class = dr.Cells["CLASS"].Value.ToString(),
                            Gender = dr.Cells["GENDER"].Value.ToString(),
                            ModeOfLearning = dr.Cells["MODE OF LEARNING"].Value.ToString(),
                        });
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Please use the template to import data", "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                try
                {
                    //save the data 
                    context.SaveChanges();
                    MetroMessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (metroCBSheets.Items.Count > 0)
                    {
                        metroCBSheets.Focus();
                        metroCBSheets.DroppedDown = true;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                    throw;
                }
                
                    this.Close();
                

            }
        }

        public bool IsIdDuplicateuplicate(int adminNo , EschoolEntities cntx)
        {
            bool duplicate = false;

            var query = cntx.Student_Basic.Select(c => c.Admin_No).ToList();

            foreach (var catID in query)
            {
                if (adminNo == catID)
                {
                    duplicate = true;
                    return duplicate;
                }
            }
            return duplicate;
        }
    }
}
