using custom_alert_notifications;
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
    public partial class FrmEditStudent : Form
    {
        //object passed
        Student_Basic obj;
        public FrmEditStudent(Student_Basic obj)
        {
            InitializeComponent();
            this.obj = obj;
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {
            //initialize objects

            //edit current student
            metroTbAdminNo.Text = obj.Admin_No.ToString();
            metroTbFName.Text = obj.First_Name;
            metroTbMName.Text = obj.Middle_Name;
            metroTbLName.Text = obj.Last_Name;
            metroTbForm.Text = obj.Form.ToString();
            metroTbClass.Text = obj.Class;
            metroTbTerm.Text = obj.RegTerm.ToString();
            metroTbYear.Text = obj.RegYear.ToString();

            if (obj.Gender == "M")
            {
                metroComboGender.SelectedIndex = 0;
            }
            else
            {
                metroComboGender.SelectedIndex = 1;
            }
            if (obj.ModeOfLearning == "Bording")
            {
                metroComboMofLearn.SelectedIndex = 0;
            }
            else
            {
                metroComboMofLearn.SelectedIndex = 1;
            }
        }

        private void bunifuFlatCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatBtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTbAdminNo.Text) & string.IsNullOrEmpty(metroTbFName.Text) | string.IsNullOrEmpty(metroTbForm.Text))
            {
                alert.Show("Please fill all required fields", alert.AlertType.error);
                return;
            }

            if (string.IsNullOrEmpty(metroComboMofLearn.SelectedItem.ToString()) )
            {
                alert.Show("Please select Mode of learning", alert.AlertType.error);
                return;
            }
            if (string.IsNullOrEmpty(metroComboGender.SelectedItem.ToString()))
            {
                alert.Show("Please select Mode of learning", alert.AlertType.error);
                return;
            }


            using (var db = new EschoolEntities())
            {
                obj.Admin_No = int.Parse(metroTbAdminNo.Text);
                obj.First_Name = metroTbFName.Text;
                obj.Middle_Name = metroTbMName.Text;
                obj.Last_Name = metroTbLName.Text;
                obj.Form = int.Parse(metroTbForm.Text.Trim());
                obj.Class = metroTbClass.Text;
                if (metroComboGender.SelectedIndex == 0)
                    obj.Gender = "M";
                else
                    obj.Gender = "F";
                obj.ModeOfLearning = metroComboMofLearn.SelectedItem.ToString();
                obj.RegTerm = int.Parse(metroTbTerm.Text);
                obj.RegYear = int.Parse(metroTbYear.Text);



                try
                {
                    db.Entry<Student_Basic>(obj).State = EntityState.Modified;

                    db.SaveChanges();
                    alert.Show("Updated", alert.AlertType.success);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                } 
            }

            // add custom notification
            //MetroMessageBox.Show(this, "Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //refresh
            StudentsData s = StudentsData.Instance;
            NewImportsUI n = NewImportsUI.Instance;
            s.GridInitilizer();
            n.Global_tab2_Click();

            this.Close();
        }

        private void metroComboMofLearn_SelectedIndexChanged(object sender, EventArgs e)
        {

                obj.ModeOfLearning = metroComboMofLearn.SelectedItem.ToString();

        }

       /* public bool IsIdDuplicateuplicate(int adminNo)
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
        }*/
        private void FrmAddStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void metroComboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboGender.SelectedIndex == 0)
            {
                if (obj != null)
                {
                    obj.Gender = "M";
                }

            }
            else
            {
                if (obj != null)
                {
                    obj.Gender = "F";
                }
            }
        }
    }
}
