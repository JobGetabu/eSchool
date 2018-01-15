using custom_alert_notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.TheLogins
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private bool isSignUP = false;
        public eUser currentUser;
        private string role = "Administrator";
        private int close = 0;
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabSignUp_Click(object sender, EventArgs e)
        {
           

            //UI code          
            if (slideA.Left == 626)
            {
                slideB.Visible = false;
                slideB.Left = 626;

                slideA.Visible = false;
                slideA.Left = 39;
                slideA.Visible = true;
                slideA.Refresh();

                bSeparator1.Width = this.tabSignUp.Width;
                bSeparator1.Left = this.tabSignUp.Left;

            }

        }

        private void tabSignIn_Click(object sender, EventArgs e)
        {
           

            //UI code          
            if (slideB.Left == 626)
            {
                slideA.Visible = false;
                slideA.Left = 626;

                slideB.Visible = false;
                slideB.Left = 39;
                slideB.Visible = true;
                slideB.Refresh();


                bSeparator1.Width = this.tabSignIn.Width;
                bSeparator1.Left = this.tabSignIn.Left;

            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tabSignIn_Click(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            close = 1;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSignUP_Click(object sender, EventArgs e)
        {
            isSignUP = true;

            //sign this up
            this.Close();
        }

        private void UIcode()
        {
            //UI code  
            btnExit.Image = GridIcon.Shutdown_32px;  //red exit is now visible;
            btnExit.Focus();
        }

        private void UIcode2()
        {
            //UI code 
            btnExit.Image = GridIcon.Shutdown_px;  // exit is now invisible;
            btnExit.Focus();
        }
        private eUser UserFoundAsync(string username)
        {
            using (var context = new EschoolEntities())
            {
                var userList =  context.eUsers.ToList();

                foreach (var ss in userList.Where(a => a.username.Equals(username)))
                {
                    if (username == ss.username)
                    {
                        return ss;
                    }
                }
                return null; 
            }
        }

        private eUser UserFoundAsync(string username, string password)
        {
            using (var context = new EschoolEntities())
            {
                var userList = context.eUsers.ToList();
                //encode password
                string yy = Encode(password);

                foreach (var ss in userList.Where(a => a.username.Equals(username) & a.Password.Equals(yy)))
                {
                    if (username == ss.username)
                    {                        
                        //await Task.Delay(2000);
                        return ss;
                    }
                }
                return null; 
            }
        }
        private void ValidateSignUp(FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFullName.Text))
            {
                //UI code  
                UIcode();

                alert.Show("Required info \n Enter Full Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }

            //check availability of user name

            if (string.IsNullOrEmpty(tbUserNameSignUP.Text))
            {
                //UI code  
                UIcode();

                alert.Show("Required info \n Enter User Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            eUser xx = UserFoundAsync(tbUserNameSignUP.Text);
            if (xx != null)
            {
                //UI code  
                UIcode();

                alert.Show("This UserName is not available", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                alert.Show("Required info \n Enter Email !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbPasswordSignUp.Text))
            {
                //UI code  
                UIcode();

                alert.Show("Required info \n Enter Password !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
        }
        private void ValidateSignIn(FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserName.Text))
            {
                //UI code  
                UIcode();

                alert.Show("Required info \n Enter User Name !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                //UI code  
                UIcode();

                alert.Show("Required info \n Enter Password !", alert.AlertType.warnig);
                e.Cancel = true;
                return;
            }
        }

        private void Register()
        {
            eUser reg = new eUser();
            reg.FullName = tbFullName.Text;
            short x = 0;
            reg.HasAccess = x;
            reg.Email = tbEmail.Text;
            reg.DateRegistered = DateTime.Now;
            reg.Password = Encode(tbPasswordSignUp.Text);
            reg.username = tbUserNameSignUP.Text;
            reg.Type = role;

            
            using (var context = new EschoolEntities())
            {
                context.eUsers.Add(reg);
                try
                {
                    context.SaveChanges();

                    alert.Show("Success !", alert.AlertType.success);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void ClearTxt()
        {
            tbFullName.Text = "";
            tbEmail.Text = "";
            tbPasswordSignUp.Text = "";
            tbUserNameSignUP.Text = "";
            tbPassword.Text = "";
        }
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close ==1)
            {
                e.Cancel = false;
                return;
            }
            if (isSignUP)
            {
                //validate
                #region ValidateSignUp
                if (string.IsNullOrEmpty(tbFullName.Text))
                {
                    //UI code  
                    UIcode();

                    alert.Show("Required info \n Enter Full Name !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }

                //check availability of user name
                
                if (string.IsNullOrEmpty(tbUserNameSignUP.Text))
                {
                    //UI code  
                    UIcode();

                    alert.Show("Required info \n Enter User Name !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                eUser xx =  UserFoundAsync(tbUserNameSignUP.Text);
                if (xx != null)
                {
                    //UI code  
                    UIcode();

                    alert.Show("This UserName is not available", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                if (string.IsNullOrEmpty(tbEmail.Text))
                {
                    alert.Show("Required info \n Enter Email !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                if (string.IsNullOrEmpty(tbPasswordSignUp.Text))
                {
                    //UI code  
                    UIcode();

                    alert.Show("Required info \n Enter Password !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                #endregion

                Register();

                //sign in page
                tabSignIn.Focus();
                tabSignIn.Select();
                tabSignIn_Click(sender, e);

                UIcode2();
                ClearTxt();
                e.Cancel = true;


            }
            else
            {
                //validate
                #region ValidateSignIn
                if (string.IsNullOrEmpty(tbUserName.Text))
                {
                    //UI code  
                    UIcode();

                    alert.Show("Required info \n Enter User Name !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                if (string.IsNullOrEmpty(tbPassword.Text))
                {
                    //UI code  
                    UIcode();

                    alert.Show("Required info \n Enter Password !", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }
                #endregion

                //check the user
                eUser xx = UserFoundAsync(tbUserName.Text, tbPassword.Text);

                if (xx == null)
                {
                    //UI code  
                    UIcode();

                    alert.Show("Wrong UserName or Password!", alert.AlertType.warnig);
                    e.Cancel = true;
                    return;
                }

                if (xx.HasAccess == 0)
                {
                    //UI code  
                    UIcode();

                    alert.Show("Contact Administrator \n For Access Privilage!", alert.AlertType.success);
                    ClearTxt();
                    e.Cancel = true;
                    return;
                }
                currentUser = xx;
                //successfull
                UIcode2();
                //alert.Show($"Welcome back {xx.username}", alert.AlertType.warnig);

                e.Cancel = false;
            }
        }

        private void btnSignIn_Click_1(object sender, EventArgs e)
        {
            isSignUP = false;
            this.Close();
        }

        private string Encode(String password)
        {
            string encode = "";
            int num = 7;

            for (int i = 0; i < password.Length; i++)
            {
                encode += (char)(password[i] + num);
            }

            return encode;
        }

        private string Decode(string encryptedPass)
        {
            string decode = "";
            int num = 7;

            for (int i = 0; i < encryptedPass.Length; i++)
            {
                decode += (char)(encryptedPass[i] - num);
            }

            return decode;
        }

        private void bDropdownRole_onItemSelected(object sender, EventArgs e)
        {
            role = bDropdownRole.selectedValue.ToString();
        }

        private void lblTrademark_Click(object sender, EventArgs e)
        {
            // About page
            FrmAbout ab = new FrmAbout();
            ab.Show();
        }

        private void tbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                tbPassword.Focus();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSignIn.Focus();
            }
        }
    }
}
