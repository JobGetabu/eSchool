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
    public partial class FrmFeePayment : Form
    {
        public FrmFeePayment()
        {
            InitializeComponent();
        }

        private void bunifuFlatCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFeePayment_Load(object sender, EventArgs e)
        {
            tbAmount.DisplayIcon = true;
        }

        List<Student_Basic> studentList = null;
        private async Task<List<Student_Basic>> StudListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Student_Basic.ToList();
                }
            });
        }
        private async Task<Student_Basic> StudFoundAsync(int admin)
        {
            if (studentList == null)
            {
                studentList = await StudListAsync();
            }

            foreach (var stud in studentList.Where(a => a.Admin_No == admin))
            {
                if (admin == stud.Admin_No)
                {
                    return stud;
                }
            }
            return null;
        }

        private async void tbAdminNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbAdminNo.DisplayIcon = false;
            if (e.KeyChar == (char)13)
            {
                int adminNo=0;
                if (int.TryParse(this.tbAdminNo.Text,out adminNo))
                {
                    Student_Basic stud = null;
                    stud = await StudFoundAsync(adminNo);
                    if (stud != null)
                    {
                        lblFLName.Text = $"- {stud.First_Name} {stud.Last_Name}";
                        //set up auto complete
                        tbFName.Text = stud.First_Name;
                        tbSName.Text = stud.Middle_Name;
                        tbLName.Text = stud.Last_Name;
                        tbForm.Text = stud.Form.ToString();
                        if (stud.Gender.Equals("M"))
                        {
                            tbGender.Text = "Male";
                        }
                        else
                        {
                            tbGender.Text = "Female";
                        }
                        tbClass.Text = stud.Class;
                        tbTerm.Text = Properties.Settings.Default.CurrentTerm.ToString();
                        tbYear.Text = Properties.Settings.Default.CurrentYear.ToString();
                        //TODO Auto-Complete feature //Cash //Mpesa
                        tbMOP.Text = "Cash";
                    }
                    else
                    {
                        if (MetroMessageBox.Show(this, $"No student with the admission number {adminNo} found \n Would you like to save him or her into the database ?", "Search Again", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            FrmAddStudent frm = new FrmAddStudent(stud);
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    tbAdminNo.Icon= GridIcon.Not_Applicable_50px;
                    tbAdminNo.DisplayIcon = true;
                }
            }
        }

        private void bunifuFlatBtnSave_Click(object sender, EventArgs e)
        {
            //TODO validate int in tb Term and Year
            //TODO validate existence of a fee structure of the term and year
        }
    }
}
