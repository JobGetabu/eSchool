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
    public partial class FrmAddStudent : Form
    {
        EschoolEntities db;

        Student_Basic objNew;
        //object passed
        Student_Basic obj;
        public FrmAddStudent(Student_Basic obj)
        {
            InitializeComponent();
            this.obj = obj;
        }
        public FrmAddStudent()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {
            //initialize objects
            objNew = new Student_Basic();
            db = new EschoolEntities();
            if (obj != null)
            {
                //edit current student
                metroTbAdminNo.Text = obj.Admin_No.ToString();
                metroTbFName.Text = obj.First_Name;
                metroTbMName.Text = obj.Middle_Name;
                metroTbLName.Text = obj.Last_Name;
                metroTbForm.Text = obj.Form.ToString();
                metroTbClass.Text = obj.Class;

                if (obj.Gender == "M")
                {
                    metroComboGender.SelectedIndex = 0;
                    metroComboGender.SelectedItem = "Male";
                }
                else if (obj.Gender == "F")
                {
                    metroComboGender.SelectedIndex = 1;
                    metroComboGender.SelectedItem  = "Female";
                }
                if (obj.ModeOfLearning.Equals("Bording") || obj.ModeOfLearning.Equals("bording") || obj.ModeOfLearning.Equals("BOARDING"))
                {
                    metroComboGender.SelectedIndex = 0;
                    metroComboGender.SelectedItem = "Boarding";
                }
                else if (obj.ModeOfLearning.Equals("Day") || obj.ModeOfLearning.Equals("DAY") || obj.ModeOfLearning.Equals("day"))
                {
                    metroComboGender.SelectedIndex = 1;
                    metroComboGender.SelectedItem = "Day";
                }
            }

        }

        private void bunifuFlatCancel_Click(object sender, EventArgs e)
        {
            db.Dispose();
            this.Close();
        }

        private void bunifuFlatBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTbAdminNo.Text) && string.IsNullOrEmpty(metroTbFName.Text) && string.IsNullOrEmpty(metroTbForm.Text))
            {
                MetroMessageBox.Show(this, "Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //TODO add custom notification

            try
            {
                if (obj != null)
                {
                    //add 
                    objNew = null;
                    db.Entry<Student_Basic>(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    MetroMessageBox.Show(this, "Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objNew = new Student_Basic();
                    //TODO 1 check invalid primary key at save
                    objNew.Admin_No = int.Parse(metroTbAdminNo.Text);
                    objNew.First_Name = metroTbFName.Text;
                    objNew.Middle_Name = metroTbMName.Text;
                    objNew.Last_Name = metroTbLName.Text;
                    objNew.Form = int.Parse(metroTbForm.Text);
                    objNew.Class = metroTbClass.Text;
                    objNew.ModeOfLearning = metroComboMofLearn.SelectedItem.ToString();

                    if (metroComboGender.SelectedIndex == 0)
                    {
                        objNew.Gender = "M";

                    }
                    else
                    {
                        objNew.Gender = "F";

                    }



                    if ((IsIdDuplicateuplicate(objNew.Admin_No) == false))
                    {
                        
                        db.Student_Basic.Add(objNew);
                        db.SaveChanges();

                        //TODO custom notification
                        MetroMessageBox.Show(this, "Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, $"Fail \n The admnistration number {objNew.Admin_No} is already taken", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }            
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                throw;
            }
            finally
            {
                //close all connection
                //log all errors
            }
            this.Close();
        }

        private void metroComboMofLearn_SelectedIndexChanged(object sender, EventArgs e)
        {
            objNew.ModeOfLearning = metroComboMofLearn.SelectedItem.ToString();
            if (obj != null)
            {
                obj.ModeOfLearning = metroComboMofLearn.SelectedItem.ToString();
            }

        }

        public bool IsIdDuplicateuplicate(int adminNo)
        {
            bool duplicate = false;
 
                var query = db.Student_Basic.Select(c => c.Admin_No).ToList();

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
        private void FrmAddStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Dispose();
        }

        private void metroComboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboGender.SelectedIndex == 0)
            {
                objNew.Gender = "M";
                if (obj != null)
                {
                    obj.Gender = "M";
                }

            }
            else
            {
                objNew.Gender = "F";
                if (obj != null)
                {
                    obj.Gender = "F";
                }

            }
        }

      

        void toolTip(Object sender,EventArgs e)
        {
            MetroFramework.Controls.MetroTextBox TB = (MetroFramework.Controls.MetroTextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show(TB.WaterMark.ToString(), TB, 0, 0, VisibleTime);
        }
    }
}
