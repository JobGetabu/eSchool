namespace eSchool.Profiles
{
    partial class FrmEditUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditUser));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.cbType = new MetroFramework.Controls.MetroComboBox();
            this.tbEmail = new MetroFramework.Controls.MetroTextBox();
            this.tbCell = new MetroFramework.Controls.MetroTextBox();
            this.tbUserName = new MetroFramework.Controls.MetroTextBox();
            this.tbFullName = new MetroFramework.Controls.MetroTextBox();
            this.tbOccupation = new MetroFramework.Controls.MetroTextBox();
            this.bunifuGradientPanel4 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuGradientPanel3 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuGradientPanel2 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bunifuGradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.ItemHeight = 23;
            this.cbType.Items.AddRange(new object[] {
            "Administrator",
            "Finance",
            "Teacher",
            "Secretary"});
            this.cbType.Location = new System.Drawing.Point(43, 125);
            this.cbType.Name = "cbType";
            this.cbType.PromptText = "Type";
            this.cbType.Size = new System.Drawing.Size(211, 29);
            this.cbType.TabIndex = 27;
            this.cbType.UseSelectable = true;
            // 
            // tbEmail
            // 
            // 
            // 
            // 
            this.tbEmail.CustomButton.Image = null;
            this.tbEmail.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.tbEmail.CustomButton.Name = "";
            this.tbEmail.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbEmail.CustomButton.TabIndex = 1;
            this.tbEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbEmail.CustomButton.UseSelectable = true;
            this.tbEmail.CustomButton.Visible = false;
            this.tbEmail.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbEmail.Lines = new string[0];
            this.tbEmail.Location = new System.Drawing.Point(288, 125);
            this.tbEmail.MaxLength = 32767;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.PasswordChar = '\0';
            this.tbEmail.PromptText = "Email";
            this.tbEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbEmail.SelectedText = "";
            this.tbEmail.SelectionLength = 0;
            this.tbEmail.SelectionStart = 0;
            this.tbEmail.ShortcutsEnabled = true;
            this.tbEmail.Size = new System.Drawing.Size(211, 25);
            this.tbEmail.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbEmail.TabIndex = 25;
            this.tbEmail.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbEmail.UseSelectable = true;
            this.tbEmail.WaterMark = "Email";
            this.tbEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tbCell
            // 
            // 
            // 
            // 
            this.tbCell.CustomButton.Image = null;
            this.tbCell.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.tbCell.CustomButton.Name = "";
            this.tbCell.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbCell.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbCell.CustomButton.TabIndex = 1;
            this.tbCell.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbCell.CustomButton.UseSelectable = true;
            this.tbCell.CustomButton.Visible = false;
            this.tbCell.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbCell.Lines = new string[0];
            this.tbCell.Location = new System.Drawing.Point(288, 82);
            this.tbCell.MaxLength = 32767;
            this.tbCell.Name = "tbCell";
            this.tbCell.PasswordChar = '\0';
            this.tbCell.PromptText = "Phone no.";
            this.tbCell.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbCell.SelectedText = "";
            this.tbCell.SelectionLength = 0;
            this.tbCell.SelectionStart = 0;
            this.tbCell.ShortcutsEnabled = true;
            this.tbCell.Size = new System.Drawing.Size(211, 25);
            this.tbCell.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbCell.TabIndex = 24;
            this.tbCell.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbCell.UseSelectable = true;
            this.tbCell.WaterMark = "Phone no.";
            this.tbCell.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbCell.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tbUserName
            // 
            // 
            // 
            // 
            this.tbUserName.CustomButton.Image = null;
            this.tbUserName.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.tbUserName.CustomButton.Name = "";
            this.tbUserName.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbUserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbUserName.CustomButton.TabIndex = 1;
            this.tbUserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbUserName.CustomButton.UseSelectable = true;
            this.tbUserName.CustomButton.Visible = false;
            this.tbUserName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbUserName.Lines = new string[0];
            this.tbUserName.Location = new System.Drawing.Point(43, 170);
            this.tbUserName.MaxLength = 32767;
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PasswordChar = '\0';
            this.tbUserName.PromptText = "School Name";
            this.tbUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbUserName.SelectedText = "";
            this.tbUserName.SelectionLength = 0;
            this.tbUserName.SelectionStart = 0;
            this.tbUserName.ShortcutsEnabled = true;
            this.tbUserName.Size = new System.Drawing.Size(211, 25);
            this.tbUserName.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbUserName.TabIndex = 22;
            this.tbUserName.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbUserName.UseSelectable = true;
            this.tbUserName.WaterMark = "School Name";
            this.tbUserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbUserName.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tbFullName
            // 
            // 
            // 
            // 
            this.tbFullName.CustomButton.Image = null;
            this.tbFullName.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.tbFullName.CustomButton.Name = "";
            this.tbFullName.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbFullName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbFullName.CustomButton.TabIndex = 1;
            this.tbFullName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbFullName.CustomButton.UseSelectable = true;
            this.tbFullName.CustomButton.Visible = false;
            this.tbFullName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbFullName.Lines = new string[0];
            this.tbFullName.Location = new System.Drawing.Point(43, 82);
            this.tbFullName.MaxLength = 32767;
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.PasswordChar = '\0';
            this.tbFullName.PromptText = "Full Name";
            this.tbFullName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFullName.SelectedText = "";
            this.tbFullName.SelectionLength = 0;
            this.tbFullName.SelectionStart = 0;
            this.tbFullName.ShortcutsEnabled = true;
            this.tbFullName.Size = new System.Drawing.Size(211, 25);
            this.tbFullName.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbFullName.TabIndex = 21;
            this.tbFullName.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbFullName.UseSelectable = true;
            this.tbFullName.WaterMark = "Full Name";
            this.tbFullName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbFullName.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // tbOccupation
            // 
            // 
            // 
            // 
            this.tbOccupation.CustomButton.Image = null;
            this.tbOccupation.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.tbOccupation.CustomButton.Name = "";
            this.tbOccupation.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.tbOccupation.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbOccupation.CustomButton.TabIndex = 1;
            this.tbOccupation.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbOccupation.CustomButton.UseSelectable = true;
            this.tbOccupation.CustomButton.Visible = false;
            this.tbOccupation.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbOccupation.Lines = new string[0];
            this.tbOccupation.Location = new System.Drawing.Point(288, 170);
            this.tbOccupation.MaxLength = 32767;
            this.tbOccupation.Name = "tbOccupation";
            this.tbOccupation.PasswordChar = '\0';
            this.tbOccupation.PromptText = "Occupation";
            this.tbOccupation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbOccupation.SelectedText = "";
            this.tbOccupation.SelectionLength = 0;
            this.tbOccupation.SelectionStart = 0;
            this.tbOccupation.ShortcutsEnabled = true;
            this.tbOccupation.Size = new System.Drawing.Size(211, 25);
            this.tbOccupation.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbOccupation.TabIndex = 30;
            this.tbOccupation.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbOccupation.UseSelectable = true;
            this.tbOccupation.WaterMark = "Occupation";
            this.tbOccupation.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbOccupation.WaterMarkFont = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // bunifuGradientPanel4
            // 
            this.bunifuGradientPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel4.BackgroundImage")));
            this.bunifuGradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.bunifuGradientPanel4.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel4.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel4.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel4.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuGradientPanel4.Location = new System.Drawing.Point(556, 60);
            this.bunifuGradientPanel4.Name = "bunifuGradientPanel4";
            this.bunifuGradientPanel4.Quality = 10;
            this.bunifuGradientPanel4.Size = new System.Drawing.Size(10, 174);
            this.bunifuGradientPanel4.TabIndex = 29;
            // 
            // bunifuGradientPanel3
            // 
            this.bunifuGradientPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel3.BackgroundImage")));
            this.bunifuGradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel3.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel3.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel3.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel3.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuGradientPanel3.Location = new System.Drawing.Point(0, 60);
            this.bunifuGradientPanel3.Name = "bunifuGradientPanel3";
            this.bunifuGradientPanel3.Quality = 10;
            this.bunifuGradientPanel3.Size = new System.Drawing.Size(10, 174);
            this.bunifuGradientPanel3.TabIndex = 28;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(566, 60);
            this.bunifuGradientPanel1.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(85, 24);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(121, 25);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "User Details";
            // 
            // bunifuGradientPanel2
            // 
            this.bunifuGradientPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel2.BackgroundImage")));
            this.bunifuGradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel2.Controls.Add(this.btnCancel);
            this.bunifuGradientPanel2.Controls.Add(this.btnSave);
            this.bunifuGradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel2.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel2.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel2.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel2.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuGradientPanel2.Location = new System.Drawing.Point(0, 234);
            this.bunifuGradientPanel2.Name = "bunifuGradientPanel2";
            this.bunifuGradientPanel2.Quality = 10;
            this.bunifuGradientPanel2.Size = new System.Drawing.Size(566, 67);
            this.bunifuGradientPanel2.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.BorderRadius = 7;
            this.btnCancel.ButtonText = " Cancel";
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DisabledColor = System.Drawing.Color.Gray;
            this.btnCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCancel.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCancel.Iconimage")));
            this.btnCancel.Iconimage_right = null;
            this.btnCancel.Iconimage_right_Selected = null;
            this.btnCancel.Iconimage_Selected = null;
            this.btnCancel.IconMarginLeft = 70;
            this.btnCancel.IconMarginRight = 0;
            this.btnCancel.IconRightVisible = true;
            this.btnCancel.IconRightZoom = 0D;
            this.btnCancel.IconVisible = true;
            this.btnCancel.IconZoom = 50D;
            this.btnCancel.IsTab = false;
            this.btnCancel.Location = new System.Drawing.Point(310, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.OnHovercolor = System.Drawing.Color.Silver;
            this.btnCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCancel.selected = false;
            this.btnCancel.Size = new System.Drawing.Size(222, 31);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = " Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Textcolor = System.Drawing.Color.DarkGray;
            this.btnCancel.TextFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(164)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(157)))), ((int)(((byte)(194)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(157)))), ((int)(((byte)(194)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::eSchool.FeeUILogo.Ok_0px;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(32, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(222, 31);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = " Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // FrmEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(566, 301);
            this.Controls.Add(this.tbOccupation);
            this.Controls.Add(this.bunifuGradientPanel4);
            this.Controls.Add(this.bunifuGradientPanel3);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.bunifuGradientPanel2);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbCell);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbFullName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEditUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEditUser";
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bunifuGradientPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel2;
        private Bunifu.Framework.UI.BunifuFlatButton btnCancel;
        private System.Windows.Forms.Button btnSave;
        private MetroFramework.Controls.MetroComboBox cbType;
        private MetroFramework.Controls.MetroTextBox tbEmail;
        private MetroFramework.Controls.MetroTextBox tbCell;
        private MetroFramework.Controls.MetroTextBox tbUserName;
        private MetroFramework.Controls.MetroTextBox tbFullName;
        private MetroFramework.Controls.MetroTextBox tbOccupation;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel4;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel3;
    }
}