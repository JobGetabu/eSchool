using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using custom_alert_notifications;
using MetroFramework;

namespace eSchool.Profiles
{
    public partial class UserProfile : UserControl
    {

        private static UserProfile _instance;
        private static eUser cUser = new eUser();
        public static UserProfile Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserProfile(cUser);
                }
                return _instance;
            }
            set
            {
                _instance = new UserProfile(cUser);
            }
        }

        string name, school, type, reg, occupation, usern;
        private string path;


        private void btnEditUserName_Click(object sender, EventArgs e)
        {
            FrmEditUserN ff = new FrmEditUserN(cUser);

            if (ff.ShowDialog() == DialogResult.OK)
            {
                using (var context = new EschoolEntities())
                {
                    //pass the edited username

                    cUser.username = ff.userN;
                    context.Entry<eUser>(cUser).State = EntityState.Modified;
                    try
                    {
                        //save edited student
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    lblUsername.Text = $"UserName: {cUser.username}";//UserName: Admin
                    lblName.Text = $"{cUser.Type} {cUser.username}";//Administrator Jane
                }
            }
        }

        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            FrmEditUser uf = new FrmEditUser(cUser);
            if (uf.ShowDialog() == DialogResult.OK)
            {
                UIRefresh();
            }
        }

        private void UIRefresh()
        {
            //passed
            name = $"{cUser.Type} {cUser.username}";//Administrator Jane
            school = $"{Properties.Settings.Default.schoolName} - {Properties.Settings.Default.schoolreg}";//EschoolKe Secondary - 20154245
            type = $"Type : {cUser.Type}";//Type : Administrator
            reg = $"Registered: {cUser.DateRegistered.ToShortDateString()}";//Registered: 12/12/17 15:00
            occupation = $"{cUser.Occupation}";//

            usern = $"UserName: {cUser.username}";//UserName: Admin

            lblName.Text = name;
            lbloccupation.Text = occupation;
            lblRegDate.Text = reg;
            lblSchool.Text = school;
            lblUsername.Text = usern;
            lbluserType.Text = type;

            btnCell.Text = $"{cUser.Phone}";
            btnEmail.Text = $"{cUser.Email}";
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword cc = new FrmChangePassword(cUser);
            if (cc.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            if (!cUser.Type.Equals(UserTypes.UserType.Administrator.ToString()))
            {
                MetroMessageBox.Show(this, $"Administrator needed to reset password !", "Info ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmResetPassword ch = new FrmResetPassword();
            if (ch.ShowDialog() == DialogResult.OK)
            {

            }

        }

        public async void GridInitilizer()
        {
            this.gData.Rows.Clear();

            List<eUser> userlist = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.eUsers.OrderBy(c => c.Id)
                    .Where(x => !x.Email.Equals("getabujob@gmail.com"))
                    .ToList();
                }
            });

            this.gData.Rows.Clear();
            //Do a check whether link is approve or revoke
            foreach (var f in userlist)
            {
                string status;
                if (f.HasAccess == 1)
                {
                    status = "Revoke";
                }
                else
                {
                    status = "Approve";
                }

                gData.Rows.Add(new string[]
                {
                        $"{f.username}",
                        $"{f.Type}",
                        $"{f.Phone}",
                        null,
                        $"{status}",
                        null
                });
            }
            gData.Refresh();
        }

        private async void GridIconPicker(DataGridViewCell username, DataGridViewCell rPic, DataGridViewRowsAddedEventArgs e)
        {
            string uname = (string)username.Value;

            eUser mm = await UserFoundAsync(uname);

            if (mm != null)
            {
                if (mm.HasAccess == 1)
                {
                    rPic.Value = StatusGrid._1approved;
                }
                else
                {
                    rPic.Value = StatusGrid._1pending;
                }
            }
        }

        private async Task<eUser> UserFoundAsync(string username)
        {
            List<eUser> userlist = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.eUsers.OrderBy(c => c.Id)
                    .Where(x => !x.Email.Equals("getabujob@gmail.com"))
                    .ToList();
                }
            });

            foreach (var ss in userlist.Where(a => a.username.Equals(username)))
            {
                if (username == ss.username)
                {
                    return ss;
                }
            }
            return null;

        }

        private void gData_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.gData.Rows[e.RowIndex].Cells[5].Value = GridIcon.Trash_Can_50px;

            GridIconPicker(gData.Rows[e.RowIndex].Cells[0], gData.Rows[e.RowIndex].Cells[3], e);
            gData.Refresh();
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                if ((MetroMessageBox.Show(this, $"Are You Sure You Want To Delete This User !", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes))
                                {

                                    context.Entry<eUser>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                    context.SaveChanges();

                                    // Custom Notification
                                    alert.Show("Deleted", alert.AlertType.warnig);
                                    gData.Rows[e.RowIndex].Visible = false;

                                    //Load the grid again
                                    GridInitilizer();
                                }
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");
                            }
                        }
                    }
                }
            }
            if (e.ColumnIndex == 4)
            {
                if ((MetroMessageBox.Show(this, $"Confirm Action!", "Confirm ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
                {
                    GiveAccess(e.RowIndex);
                }
            }
        }

        private async Task<eUser> GridDelImageAsync(int rowIndex)
        {
            List<eUser> userlist = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.eUsers.OrderBy(c => c.Id)
                    .Where(x => !x.Email.Equals("getabujob@gmail.com"))
                    .ToList();
                }
            });

            string usernm;
            usernm = (string)this.gData.Rows[rowIndex].Cells[0].Value;

            eUser mm = await UserFoundAsync(usernm);

            if (mm != null)
            {
                return mm;
            }
            return null;
        }

        private async void GiveAccess(int rowIndex)
        {
            bool IsGivingAccess;
            string usernm = (string)this.gData.Rows[rowIndex].Cells[0].Value;
            string cmdType = (string)this.gData.Rows[rowIndex].Cells[4].Value;

            if (cmdType.Equals("Revoke"))
            {
                IsGivingAccess = false;
            }
            else
            {
                IsGivingAccess = true;
            }
            eUser mm = await UserFoundAsync(usernm);

            if (mm != null)
            {
                using (var context = new EschoolEntities())
                {
                    if (IsGivingAccess)
                    {
                        mm.HasAccess = 1;
                    }
                    else
                    {
                        mm.HasAccess = 0;
                    }
                    context.Entry<eUser>(mm).State = EntityState.Modified;
                    try
                    {
                        //save edited student
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
                // short Custom Notification
                alert.Show("Updated", alert.AlertType.success);
            }

            //Load the grid again
            GridInitilizer();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                //under auto modification 
                cUser.ProfImage = path;
                context.Entry<eUser>(cUser).State = EntityState.Modified;
                try
                {
                    //save edited student
                    context.SaveChanges();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }


            Frm_Home hh = Frm_Home.Instance;
            hh.ovalPictureBox1.Image = Image.FromFile(cUser.ProfImage);
            hh.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            // short Custom Notification
            alert.Show("Updated", alert.AlertType.success);
            btnSaveChanges.Visible = false;
        }


        private void btnChangePic_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog opf = new OpenFileDialog()
                { Filter = "Picture|*.jpg|*.JPEG|*.png", ValidateNames = true, Multiselect = false })
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        this.ovalPictureBox1.Image = Image.FromFile(opf.FileName);
                        this.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        path = opf.FileName;
                    }

                    btnSaveChanges.Visible = true;

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        public UserProfile(eUser currentUser)
        {
            InitializeComponent();

           
            cUser = currentUser;

            //passed
            name = $"{cUser.Type} {cUser.username}";//Administrator Jane
            school = $"{Properties.Settings.Default.schoolName} - {Properties.Settings.Default.schoolreg}";//EschoolKe Secondary - 20154245
            type = $"Type : {cUser.Type}";//Type : Administrator
            reg = $"Registered: {cUser.DateRegistered.ToShortDateString()}";//Registered: 12/12/17 15:00
            occupation = $"{cUser.Occupation}";//

            usern = $"UserName: {cUser.username}";//UserName: Admin
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            lblName.Text = name;
            lbloccupation.Text = occupation;
            lblRegDate.Text = reg;
            lblSchool.Text = school;
            lblUsername.Text = usern;
            lbluserType.Text = type;

            btnCell.Text = $"   {cUser.Phone}";
            btnEmail.Text = $"   {cUser.Email}";

            // picture
            DisplayProf();

            //grid
            if (cUser.Type.Equals(UserTypes.UserType.Administrator.ToString()))
            {
                gData.Visible = true;
            }

            //change color of INX to green
            gData.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;
            gData.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            GridInitilizer();
            _instance.Refresh();
        }

        private void DisplayProf()
        {
            //set up picture
            if (String.IsNullOrEmpty(cUser.ProfImage))
            {
                string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
                string fff = tt + ".\\profile1.jpg";
                if (File.Exists(fff))
                {
                    ovalPictureBox1.Image = Image.FromFile(fff);
                }
            }
            else
            {
                if (File.Exists(cUser.ProfImage))
                {
                    try
                    {
                        var y = Image.FromFile(cUser.ProfImage);
                        this.ovalPictureBox1.Image = y;
                        this.ovalPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
                else
                {
                    string tt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\eSchool\";
                    string fff = tt + ".\\profile1.jpg";
                    if (File.Exists(fff))
                    {
                        ovalPictureBox1.Image = Image.FromFile(fff);
                    }
                }
            }
        }

    }
}
