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

        private void btnBack_Click(object sender, EventArgs e)
        {
            
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

            btnCell.Text = $"{cUser.Phone}";
            btnEmail.Text = $"{cUser.Email}";

            // picture
            DisplayProf();
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
