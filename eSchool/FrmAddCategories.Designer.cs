namespace eSchool
{
    partial class FrmAddCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddCategories));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.metroComboBoxCat = new MetroFramework.Controls.MetroComboBox();
            this.metroTbxCatName = new MetroFramework.Controls.MetroTextBox();
            this.bunifuFlatBtnSave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Controls.Add(this.bunifuCustomLabel1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 20;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(302, 63);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(42, 24);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(92, 25);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Category";
            // 
            // metroComboBoxCat
            // 
            this.metroComboBoxCat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.metroComboBoxCat.FormattingEnabled = true;
            this.metroComboBoxCat.ItemHeight = 23;
            this.metroComboBoxCat.Items.AddRange(new object[] {
            "Income",
            "Expense"});
            this.metroComboBoxCat.Location = new System.Drawing.Point(29, 81);
            this.metroComboBoxCat.Name = "metroComboBoxCat";
            this.metroComboBoxCat.Size = new System.Drawing.Size(236, 29);
            this.metroComboBoxCat.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroComboBoxCat.TabIndex = 1;
            this.metroComboBoxCat.UseSelectable = true;
            this.metroComboBoxCat.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxCat_SelectedIndexChanged);
            // 
            // metroTbxCatName
            // 
            // 
            // 
            // 
            this.metroTbxCatName.CustomButton.Image = null;
            this.metroTbxCatName.CustomButton.Location = new System.Drawing.Point(208, 2);
            this.metroTbxCatName.CustomButton.Name = "";
            this.metroTbxCatName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.metroTbxCatName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTbxCatName.CustomButton.TabIndex = 1;
            this.metroTbxCatName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTbxCatName.CustomButton.UseSelectable = true;
            this.metroTbxCatName.CustomButton.Visible = false;
            this.metroTbxCatName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTbxCatName.Lines = new string[0];
            this.metroTbxCatName.Location = new System.Drawing.Point(29, 129);
            this.metroTbxCatName.MaxLength = 32767;
            this.metroTbxCatName.Name = "metroTbxCatName";
            this.metroTbxCatName.PasswordChar = '\0';
            this.metroTbxCatName.PromptText = "Enter Category Name";
            this.metroTbxCatName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTbxCatName.SelectedText = "";
            this.metroTbxCatName.SelectionLength = 0;
            this.metroTbxCatName.SelectionStart = 0;
            this.metroTbxCatName.ShortcutsEnabled = true;
            this.metroTbxCatName.Size = new System.Drawing.Size(236, 30);
            this.metroTbxCatName.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTbxCatName.TabIndex = 2;
            this.metroTbxCatName.UseSelectable = true;
            this.metroTbxCatName.WaterMark = "Enter Category Name";
            this.metroTbxCatName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTbxCatName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 10F);
            // 
            // bunifuFlatBtnSave
            // 
            this.bunifuFlatBtnSave.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuFlatBtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(164)))));
            this.bunifuFlatBtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatBtnSave.BorderRadius = 7;
            this.bunifuFlatBtnSave.ButtonText = "Save";
            this.bunifuFlatBtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatBtnSave.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatBtnSave.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatBtnSave.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatBtnSave.Iconimage")));
            this.bunifuFlatBtnSave.Iconimage_right = null;
            this.bunifuFlatBtnSave.Iconimage_right_Selected = null;
            this.bunifuFlatBtnSave.Iconimage_Selected = null;
            this.bunifuFlatBtnSave.IconMarginLeft = 60;
            this.bunifuFlatBtnSave.IconMarginRight = 0;
            this.bunifuFlatBtnSave.IconRightVisible = true;
            this.bunifuFlatBtnSave.IconRightZoom = 0D;
            this.bunifuFlatBtnSave.IconVisible = true;
            this.bunifuFlatBtnSave.IconZoom = 55D;
            this.bunifuFlatBtnSave.IsTab = false;
            this.bunifuFlatBtnSave.Location = new System.Drawing.Point(29, 174);
            this.bunifuFlatBtnSave.Name = "bunifuFlatBtnSave";
            this.bunifuFlatBtnSave.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(164)))));
            this.bunifuFlatBtnSave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(164)))));
            this.bunifuFlatBtnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatBtnSave.selected = false;
            this.bunifuFlatBtnSave.Size = new System.Drawing.Size(236, 33);
            this.bunifuFlatBtnSave.TabIndex = 3;
            this.bunifuFlatBtnSave.Text = "Save";
            this.bunifuFlatBtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatBtnSave.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatBtnSave.TextFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuFlatBtnSave.Click += new System.EventHandler(this.bunifuFlatBtnSave_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 7;
            this.bunifuFlatButton2.ButtonText = "Cancel";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 60;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 50D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(29, 216);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.LightGray;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(236, 33);
            this.bunifuFlatButton2.TabIndex = 4;
            this.bunifuFlatButton2.Text = "Cancel";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.DarkGray;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // FrmAddCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(302, 261);
            this.Controls.Add(this.bunifuFlatButton2);
            this.Controls.Add(this.bunifuFlatBtnSave);
            this.Controls.Add(this.metroTbxCatName);
            this.Controls.Add(this.metroComboBoxCat);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(302, 261);
            this.Name = "FrmAddCategories";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddCategories";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmAddCategories_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatBtnSave;
        private MetroFramework.Controls.MetroTextBox metroTbxCatName;
        private MetroFramework.Controls.MetroComboBox metroComboBoxCat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
    }
}