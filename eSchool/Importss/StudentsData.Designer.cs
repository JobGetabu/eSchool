namespace eSchool.Importss
{
    partial class StudentsData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbSearch = new MetroFramework.Controls.MetroTextBox();
            this.lblForm = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblRowCount = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFilter = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnAddStudent = new Bunifu.Framework.UI.BunifuThinButton2();
            this.paneldata = new System.Windows.Forms.Panel();
            this.gData = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.ColumnPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnAdminNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeOfLearning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuCards1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.paneldata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gData)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(98)))), ((int)(((byte)(115)))));
            this.bunifuCards1.Controls.Add(this.panel1);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(798, 70);
            this.bunifuCards1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.btnAddStudent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 70);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbSearch);
            this.panel2.Controls.Add(this.lblForm);
            this.panel2.Controls.Add(this.lblRowCount);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(449, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 70);
            this.panel2.TabIndex = 11;
            // 
            // tbSearch
            // 
            // 
            // 
            // 
            this.tbSearch.CustomButton.Image = null;
            this.tbSearch.CustomButton.Location = new System.Drawing.Point(211, 2);
            this.tbSearch.CustomButton.Name = "";
            this.tbSearch.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.tbSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbSearch.CustomButton.TabIndex = 1;
            this.tbSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSearch.CustomButton.UseSelectable = true;
            this.tbSearch.CustomButton.Visible = false;
            this.tbSearch.Lines = new string[0];
            this.tbSearch.Location = new System.Drawing.Point(15, 43);
            this.tbSearch.MaxLength = 32767;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PasswordChar = '\0';
            this.tbSearch.PromptText = "Search Me";
            this.tbSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSearch.SelectedText = "";
            this.tbSearch.SelectionLength = 0;
            this.tbSearch.SelectionStart = 0;
            this.tbSearch.ShortcutsEnabled = true;
            this.tbSearch.Size = new System.Drawing.Size(231, 22);
            this.tbSearch.TabIndex = 15;
            this.tbSearch.UseCustomBackColor = true;
            this.tbSearch.UseCustomForeColor = true;
            this.tbSearch.UseSelectable = true;
            this.tbSearch.WaterMark = "Search Me";
            this.tbSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblForm.Location = new System.Drawing.Point(13, 17);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(92, 17);
            this.lblForm.TabIndex = 14;
            this.lblForm.Text = "Form :1 2 3 4";
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(230, 17);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(16, 18);
            this.lblRowCount.TabIndex = 13;
            this.lblRowCount.Text = "0";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(204, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnFilter
            // 
            this.btnFilter.ActiveBorderThickness = 1;
            this.btnFilter.ActiveCornerRadius = 40;
            this.btnFilter.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.btnFilter.ActiveForecolor = System.Drawing.Color.White;
            this.btnFilter.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.btnFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter.BackgroundImage")));
            this.btnFilter.ButtonText = "Filter";
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnFilter.IdleBorderThickness = 1;
            this.btnFilter.IdleCornerRadius = 30;
            this.btnFilter.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(94)))), ((int)(((byte)(135)))));
            this.btnFilter.IdleForecolor = System.Drawing.Color.SeaShell;
            this.btnFilter.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(131)))), ((int)(((byte)(253)))));
            this.btnFilter.Location = new System.Drawing.Point(260, 12);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(164, 39);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.ActiveBorderThickness = 1;
            this.btnAddStudent.ActiveCornerRadius = 40;
            this.btnAddStudent.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.btnAddStudent.ActiveForecolor = System.Drawing.Color.White;
            this.btnAddStudent.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.btnAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.btnAddStudent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddStudent.BackgroundImage")));
            this.btnAddStudent.ButtonText = "Add Student";
            this.btnAddStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudent.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnAddStudent.IdleBorderThickness = 1;
            this.btnAddStudent.IdleCornerRadius = 30;
            this.btnAddStudent.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(109)))), ((int)(((byte)(99)))));
            this.btnAddStudent.IdleForecolor = System.Drawing.Color.SeaShell;
            this.btnAddStudent.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(188)))), ((int)(((byte)(115)))));
            this.btnAddStudent.Location = new System.Drawing.Point(43, 12);
            this.btnAddStudent.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(191, 39);
            this.btnAddStudent.TabIndex = 6;
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // paneldata
            // 
            this.paneldata.Controls.Add(this.gData);
            this.paneldata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneldata.Location = new System.Drawing.Point(0, 70);
            this.paneldata.Name = "paneldata";
            this.paneldata.Size = new System.Drawing.Size(798, 337);
            this.paneldata.TabIndex = 2;
            // 
            // gData
            // 
            this.gData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPic,
            this.ColumnAdminNo,
            this.ColumnName,
            this.Form,
            this.Class,
            this.ModeOfLearning,
            this.ColumnDel});
            this.gData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gData.DoubleBuffered = true;
            this.gData.EnableHeadersVisualStyles = false;
            this.gData.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.gData.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(68)))), ((int)(((byte)(74)))));
            this.gData.Location = new System.Drawing.Point(0, 0);
            this.gData.MultiSelect = false;
            this.gData.Name = "gData";
            this.gData.ReadOnly = true;
            this.gData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gData.RowHeadersVisible = false;
            this.gData.RowTemplate.Height = 30;
            this.gData.RowTemplate.ReadOnly = true;
            this.gData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gData.Size = new System.Drawing.Size(798, 337);
            this.gData.TabIndex = 0;
            this.gData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gData_CellContentClick);
            this.gData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gData_RowsAdded);
            // 
            // ColumnPic
            // 
            this.ColumnPic.HeaderText = "";
            this.ColumnPic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ColumnPic.Name = "ColumnPic";
            this.ColumnPic.ReadOnly = true;
            this.ColumnPic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnAdminNo
            // 
            this.ColumnAdminNo.HeaderText = "Admin No";
            this.ColumnAdminNo.Name = "ColumnAdminNo";
            this.ColumnAdminNo.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // Form
            // 
            this.Form.HeaderText = "Form";
            this.Form.Name = "Form";
            this.Form.ReadOnly = true;
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            // 
            // ModeOfLearning
            // 
            this.ModeOfLearning.HeaderText = "Mode Of Learning";
            this.ModeOfLearning.Name = "ModeOfLearning";
            this.ModeOfLearning.ReadOnly = true;
            // 
            // ColumnDel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.ColumnDel.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnDel.HeaderText = "";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.ReadOnly = true;
            // 
            // StudentsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.paneldata);
            this.Controls.Add(this.bunifuCards1);
            this.Name = "StudentsData";
            this.Size = new System.Drawing.Size(798, 407);
            this.Load += new System.EventHandler(this.StudentsData_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.paneldata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroTextBox tbSearch;
        private Bunifu.Framework.UI.BunifuCustomLabel lblForm;
        private Bunifu.Framework.UI.BunifuCustomLabel lblRowCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnFilter;
        private Bunifu.Framework.UI.BunifuThinButton2 btnAddStudent;
        private System.Windows.Forms.Panel paneldata;
        private Bunifu.Framework.UI.BunifuCustomDataGrid gData;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAdminNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeOfLearning;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDel;
    }
}
