namespace eSchool
{
    partial class FrmAddFeeCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddFeeCategory));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.mTBoxFeeItem = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bFlatButtonCancel = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bFlatBtnSave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.bunifuGradientPanel1;
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
            this.bunifuGradientPanel1.Quality = 20;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(284, 63);
            this.bunifuGradientPanel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 22);
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
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(60, 24);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(130, 25);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Add Fee Item";
            // 
            // mTBoxFeeItem
            // 
            // 
            // 
            // 
            this.mTBoxFeeItem.CustomButton.Image = null;
            this.mTBoxFeeItem.CustomButton.Location = new System.Drawing.Point(214, 1);
            this.mTBoxFeeItem.CustomButton.Name = "";
            this.mTBoxFeeItem.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.mTBoxFeeItem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mTBoxFeeItem.CustomButton.TabIndex = 1;
            this.mTBoxFeeItem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mTBoxFeeItem.CustomButton.UseSelectable = true;
            this.mTBoxFeeItem.CustomButton.Visible = false;
            this.mTBoxFeeItem.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.mTBoxFeeItem.Lines = new string[0];
            this.mTBoxFeeItem.Location = new System.Drawing.Point(18, 91);
            this.mTBoxFeeItem.MaxLength = 32767;
            this.mTBoxFeeItem.Multiline = true;
            this.mTBoxFeeItem.Name = "mTBoxFeeItem";
            this.mTBoxFeeItem.PasswordChar = '\0';
            this.mTBoxFeeItem.PromptText = "Fee Item";
            this.mTBoxFeeItem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mTBoxFeeItem.SelectedText = "";
            this.mTBoxFeeItem.SelectionLength = 0;
            this.mTBoxFeeItem.SelectionStart = 0;
            this.mTBoxFeeItem.ShortcutsEnabled = true;
            this.mTBoxFeeItem.Size = new System.Drawing.Size(250, 37);
            this.mTBoxFeeItem.Style = MetroFramework.MetroColorStyle.Green;
            this.mTBoxFeeItem.TabIndex = 4;
            this.mTBoxFeeItem.UseSelectable = true;
            this.mTBoxFeeItem.WaterMark = "Fee Item";
            this.mTBoxFeeItem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mTBoxFeeItem.WaterMarkFont = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 190);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(274, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 190);
            this.panel2.TabIndex = 9;
            // 
            // bFlatButtonCancel
            // 
            this.bFlatButtonCancel.Activecolor = System.Drawing.Color.WhiteSmoke;
            this.bFlatButtonCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bFlatButtonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bFlatButtonCancel.BorderRadius = 7;
            this.bFlatButtonCancel.ButtonText = "Cancel";
            this.bFlatButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bFlatButtonCancel.DisabledColor = System.Drawing.Color.Gray;
            this.bFlatButtonCancel.Iconcolor = System.Drawing.Color.Transparent;
            this.bFlatButtonCancel.Iconimage = ((System.Drawing.Image)(resources.GetObject("bFlatButtonCancel.Iconimage")));
            this.bFlatButtonCancel.Iconimage_right = null;
            this.bFlatButtonCancel.Iconimage_right_Selected = null;
            this.bFlatButtonCancel.Iconimage_Selected = null;
            this.bFlatButtonCancel.IconMarginLeft = 70;
            this.bFlatButtonCancel.IconMarginRight = 0;
            this.bFlatButtonCancel.IconRightVisible = true;
            this.bFlatButtonCancel.IconRightZoom = 0D;
            this.bFlatButtonCancel.IconVisible = true;
            this.bFlatButtonCancel.IconZoom = 50D;
            this.bFlatButtonCancel.IsTab = false;
            this.bFlatButtonCancel.Location = new System.Drawing.Point(18, 188);
            this.bFlatButtonCancel.Name = "bFlatButtonCancel";
            this.bFlatButtonCancel.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.bFlatButtonCancel.OnHovercolor = System.Drawing.Color.Silver;
            this.bFlatButtonCancel.OnHoverTextColor = System.Drawing.Color.White;
            this.bFlatButtonCancel.selected = false;
            this.bFlatButtonCancel.Size = new System.Drawing.Size(250, 33);
            this.bFlatButtonCancel.TabIndex = 11;
            this.bFlatButtonCancel.Text = "Cancel";
            this.bFlatButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bFlatButtonCancel.Textcolor = System.Drawing.Color.DarkGray;
            this.bFlatButtonCancel.TextFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.bFlatButtonCancel.Click += new System.EventHandler(this.bFlatButtonCancel_Click);
            // 
            // bFlatBtnSave
            // 
            this.bFlatBtnSave.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bFlatBtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(164)))));
            this.bFlatBtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bFlatBtnSave.BorderRadius = 7;
            this.bFlatBtnSave.ButtonText = "Save";
            this.bFlatBtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bFlatBtnSave.DisabledColor = System.Drawing.Color.Gray;
            this.bFlatBtnSave.Iconcolor = System.Drawing.Color.Transparent;
            this.bFlatBtnSave.Iconimage = ((System.Drawing.Image)(resources.GetObject("bFlatBtnSave.Iconimage")));
            this.bFlatBtnSave.Iconimage_right = null;
            this.bFlatBtnSave.Iconimage_right_Selected = null;
            this.bFlatBtnSave.Iconimage_Selected = null;
            this.bFlatBtnSave.IconMarginLeft = 70;
            this.bFlatBtnSave.IconMarginRight = 0;
            this.bFlatBtnSave.IconRightVisible = true;
            this.bFlatBtnSave.IconRightZoom = 0D;
            this.bFlatBtnSave.IconVisible = true;
            this.bFlatBtnSave.IconZoom = 55D;
            this.bFlatBtnSave.IsTab = false;
            this.bFlatBtnSave.Location = new System.Drawing.Point(18, 146);
            this.bFlatBtnSave.Name = "bFlatBtnSave";
            this.bFlatBtnSave.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(108)))), ((int)(((byte)(164)))));
            this.bFlatBtnSave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(157)))), ((int)(((byte)(194)))));
            this.bFlatBtnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.bFlatBtnSave.selected = false;
            this.bFlatBtnSave.Size = new System.Drawing.Size(250, 33);
            this.bFlatBtnSave.TabIndex = 10;
            this.bFlatBtnSave.Text = "Save";
            this.bFlatBtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bFlatBtnSave.Textcolor = System.Drawing.Color.White;
            this.bFlatBtnSave.TextFont = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.bFlatBtnSave.Click += new System.EventHandler(this.bFlatBtnSave_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.bunifuGradientPanel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // FrmAddFeeCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(284, 253);
            this.Controls.Add(this.bFlatButtonCancel);
            this.Controls.Add(this.bFlatBtnSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mTBoxFeeItem);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAddFeeCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAddFeeCategory";
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private MetroFramework.Controls.MetroTextBox mTBoxFeeItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuFlatButton bFlatButtonCancel;
        private Bunifu.Framework.UI.BunifuFlatButton bFlatBtnSave;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}