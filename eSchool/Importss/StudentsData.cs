using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;
using custom_alert_notifications;
using eSchool.Profiles;

namespace eSchool.Importss
{   
    public partial class StudentsData : UserControl
    {

        private static StudentsData _instance;
        public static StudentsData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentsData();
                }
                return _instance;
            }
        }
        public StudentsData()
        {
            InitializeComponent();
        }

        private List<Student_Basic> studentListAsync;
        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GridIconPicker(this.gData.Rows[e.RowIndex].Cells[0], this.gData.Rows[e.RowIndex].Cells[1],e);
            this.gData.Rows[e.RowIndex].Cells[6].Value = GridIcon.Trash_Can_50px;
            //lblRowCount.Text = gData.RowCount.ToString();
            this.lblRowCount.Text = gData.Rows.Count.ToString();
        }

        private void StudentsData_Load(object sender, EventArgs e)
        {
            //UI code
            //change color of Nos to green
            gData.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;

            GridInitilizer();
        }

        private async Task<List<Student_Basic>> StudentListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Student_Basic.OrderBy(c => c.Admin_No).ToList();
                }
            });
        }

        public async void GridInitilizer()
        {

            this.gData.Rows.Clear();

            if (studentListAsync == null)
            {
                studentListAsync = await StudentListAsync(); 
            }

            NewImportsUI niUI = NewImportsUI.Instance;
            niUI.lblStudentCount.Text = studentListAsync.Count.ToString();
            foreach (var cat in studentListAsync)
            {
                gData.Rows.Add(new string[]
                {
                        null,
                        cat.Admin_No.ToString(),
                        $"{cat.First_Name} {cat.Middle_Name} {cat.Last_Name}",
                        cat.Form.ToString(),
                        cat.Class,
                        cat.ModeOfLearning,
                        null
                });
            }
        }

        private async Task<Student_Basic> StudFoundAsync(int admin)
        {
            if (studentListAsync == null)
            {
                studentListAsync = await StudentListAsync();
            }

            foreach (var stud in studentListAsync.Where(a => a.Admin_No == admin))
            {
                if (admin == stud.Admin_No)
                {
                    return stud;
                }
            }
            return null;
        }

        private async void GridIconPicker(DataGridViewCell rPic, DataGridViewCell adminNo, DataGridViewRowsAddedEventArgs e)
        {
            Student_Basic stud = await StudFoundAsync(int.Parse(adminNo.Value.ToString()));
            if (stud != null)
            {
                if (stud.Gender.Equals("M")|| stud.Gender.Equals("m"))
                {
                    rPic.Value = StatusGrid.Male_User_50px;
                }
                else
                {
                    rPic.Value = StatusGrid.Female_Profile_50px;

                    //this.gData.Rows[e.RowIndex].Cells[2].Style = new DataGridViewCellStyle { ForeColor = Color.Blue };
                    //this.gData.Rows[e.RowIndex].Cells[4].Style = new DataGridViewCellStyle { ForeColor = Color.Blue };
                    //this.gData.Rows[e.RowIndex].Cells[5].Style = new DataGridViewCellStyle { ForeColor = Color.Blue };
                }
            }
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == 0 | e.ColumnIndex == 1 | e.ColumnIndex == 2)
            {
                TabSwitcher(StudentProfile.Instance);
                //Todo pass the student
            }

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {               
                if (e.ColumnIndex == 6)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                context.Entry<Student_Basic>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();

                                // short Custom Notification
                                alert.Show("Deleted", alert.AlertType.warnig);

                                gData.Rows[e.RowIndex].Visible = false;
                                this.lblRowCount.Text = gData.Rows.Count.ToString();
                                NewImportsUI niUI = NewImportsUI.Instance;
                                niUI.lblStudentCount.Text = studentListAsync.Count.ToString();
                            }
                            catch (DbUpdateException)
                            {
                                MetroMessageBox.Show(this, "Can not delete this student \n There are related fee payment records", "Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Something went wrong \n" + exp.Message, "Unsuccessful");
                                throw;
                            }
                        }
                    }
                }
            }
        }

        private async Task<Student_Basic> GridDelImageAsync(int rowIndex)
        {
            if (studentListAsync == null)
            {
                studentListAsync = await StudentListAsync();
            }

            int adminNo;
            adminNo = int.Parse(this.gData.Rows[rowIndex].Cells[1].Value.ToString());

            foreach (var s in studentListAsync)
            {
                if (s.Admin_No == adminNo)
                {
                    return s;
                }
            }
            return null;
        }

        private async void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (studentListAsync == null)
            {
                studentListAsync = await StudentListAsync();
            }
            if (e.KeyChar == (char)13)
            {
                gData.Rows.Clear();
                var filList = studentListAsync.Where(s =>
                     Regex.IsMatch(s.Admin_No.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.First_Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.Middle_Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.Last_Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.Class.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                      Regex.IsMatch(s.ModeOfLearning.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                     Regex.IsMatch(s.Form.ToString(), tbSearch.Text, RegexOptions.IgnoreCase))
                     .OrderBy(t => t.Admin_No)
                     .ToList();

                foreach (var cat in filList)
                {
                    gData.Rows.Add(new string[]
                    {
                        null,
                        cat.Admin_No.ToString(),
                        $"{cat.First_Name} {cat.Middle_Name} {cat.Last_Name}",
                        cat.Form.ToString(),
                        cat.Class,
                        cat.ModeOfLearning,
                        null
                    });
                }

            }
        }

        private async void tbSearch_TextChanged(object sender, EventArgs e)
        {
            this.lblForm.Text = "Form : 1 2 3 4";
            if (studentListAsync == null)
            {
                studentListAsync = await StudentListAsync();
            }
            gData.Rows.Clear();
            var filList = studentListAsync.Where(s =>
                 Regex.IsMatch(s.Admin_No.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.First_Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Middle_Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Last_Name.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Class.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.ModeOfLearning.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                 Regex.IsMatch(s.Form.ToString(), tbSearch.Text, RegexOptions.IgnoreCase))
                 .OrderBy(t => t.Admin_No)
                 .ToList();

            foreach (var cat in filList)
            {
                gData.Rows.Add(new string[]
                {
                        null,
                        cat.Admin_No.ToString(),
                        $"{cat.First_Name} {cat.Middle_Name} {cat.Last_Name}",
                        cat.Form.ToString(),
                        cat.Class,
                        cat.ModeOfLearning,
                        null
                });
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            FrmAddStudent fas = new FrmAddStudent();
            if(fas.ShowDialog()== DialogResult.OK)
            {

            }
        }

        List<int> selForms;
        bool man, female;
        private void btnFilter_Click(object sender, EventArgs e)
        {
            FrmFilterStudents frm = new FrmFilterStudents();
            if (frm.ShowDialog()== DialogResult.OK)
            {
                //logic
                selForms = new List<int>();
                selForms = FrmFilterStudents.selFilForms;
                man = FrmFilterStudents.male;
                female = FrmFilterStudents.female;

                //refresh label
                this.lblForm.Text = FrmFilterStudents.FrmsLbl;
                //refresh grid
                GridInitilizer(man, female, selForms);
            }
        }
        public async void GridInitilizer(bool man,bool female,List<int> selFilForms)
        {
            this.gData.Rows.Clear();

            if (studentListAsync == null)
            {
                studentListAsync = await StudentListAsync();
            }
            List<Student_Basic> fil =null;
            if (female & man)
            {
                fil = studentListAsync
                    .Where(x => x.Gender.Equals("M") | x.Gender.Equals("m") | x.Gender.Equals("F") | x.Gender.Equals("F"))
                    .ToList();
                    
            }
            else
            {
                if (man)
                {
                    fil = studentListAsync.Where(x => x.Gender.Equals("M") | x.Gender.Equals("m")).ToList();
                    this.lblForm.Text += " " + " Male";
                }
                else
                {
                    fil = studentListAsync.Where(x => x.Gender.Equals("F") | x.Gender.Equals("F")).ToList();
                    this.lblForm.Text += " " + " Female";
                }
            }
            NewImportsUI niUI = NewImportsUI.Instance;
            niUI.lblStudentCount.Text = studentListAsync.Count.ToString();

            foreach (var fm in selFilForms)
            {
                foreach (var cat in fil.Where(x=>x.Form == fm))
                {
                    gData.Rows.Add(new string[]
                    {
                        null,
                        cat.Admin_No.ToString(),
                        $"{cat.First_Name} {cat.Middle_Name} {cat.Last_Name}",
                        cat.Form.ToString(),
                        cat.Class,
                        cat.ModeOfLearning,
                        null
                    });
                } 
            }
        }

        //nav

        private void TabSwitcher(Control UIinstance)
        {
            if (!NewImportsUI.Instance.container.Controls.Contains(UIinstance))
            {
                NewImportsUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }
    }
}
