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

namespace eSchool.Invoices
{
    public partial class FrmCreateInvoice : Form
    {
        public FrmCreateInvoice()
        {
            InitializeComponent();
        }

        private void FrmCreateInvoice_Load(object sender, EventArgs e)
        {
            tbCat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbCat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();

            col.Add("Fees");
            tbCat.AutoCompleteCustomSource = col;
        }

        List<Student_Basic> studentList = null;
        private int close;

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
                int adminNo = 0;
                if (int.TryParse(this.tbAdminNo.Text, out adminNo))
                {
                    Student_Basic stud = null;
                    stud = await StudFoundAsync(adminNo);
                    if (stud != null)
                    {
                        tbSDetails.Text = $" {stud.First_Name} {stud.Last_Name}";
                        tbCat.Text = "Fees";
                        tbCat.Focus();
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
                    tbAdminNo.Icon = GridIcon.Not_Applicable_50px;
                    tbAdminNo.DisplayIcon = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            close = 1;
            this.Close();
        }

        private void FrmCreateInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 1)
            {
                e.Cancel = false;
                return;
            }
            if (string.IsNullOrEmpty(tbAdminNo.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Enter Administration Number !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbSDetails.Text))
            {
                //TODO custom notification
                MetroMessageBox.Show(this, "Enter Some Student Details  !", "Required info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }
    }
}
