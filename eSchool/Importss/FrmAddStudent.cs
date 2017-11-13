using eSchool.Importss;
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
            metroTbYear.Text = Properties.Settings.Default.CurrentYear.ToString();
            metroTbTerm.Text = Properties.Settings.Default.CurrentTerm.ToString();
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
                metroTbYear.Text = obj.RegYear.ToString();
                metroTbTerm.Text = obj.RegTerm.ToString();

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
            if (string.IsNullOrEmpty(metroTbAdminNo.Text) | string.IsNullOrEmpty(metroTbFName.Text) | string.IsNullOrEmpty(metroTbForm.Text))
            {
                MetroMessageBox.Show(this, "Please fill all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal test1;
            if (!decimal.TryParse(metroTbTerm.Text, out test1))
            {
                MetroMessageBox.Show(this, "Only numeric values  allowed on Admission Term input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int test;
            if (!int.TryParse(metroTbYear.Text, out test))
            {
                MetroMessageBox.Show(this, "Only numeric values  allowed on Registration Year input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    //refresh our list
                    StudentsData sData = StudentsData.Instance;
                    sData.GridInitilizer();
                    this.Close();
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
                    objNew.RegTerm = int.Parse(metroTbTerm.Text);
                    objNew.RegYear = int.Parse(metroTbYear.Text);

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

                        //refresh our list
                        StudentsData sData = StudentsData.Instance;
                        sData.GridInitilizer();

                        //referesh the progress bars
                        FeePayment fp = FeePayment.Instance;
                        fp.Copy_FeePayment_Load();
                        this.Close();
                    }
                    else
                    {
                        MetroMessageBox.Show(this, $"Fail \n The admnistration number {objNew.Admin_No}   exists !", "Duplicate Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }            
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                //close all connection
                //log all errors
            }                         
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
