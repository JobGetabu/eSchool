namespace eSchool
{
    partial class FrmImportedData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportedData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuFBSave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bFClose = new Bunifu.Framework.UI.BunifuFlatButton();
            this.metroCBSheets = new MetroFramework.Controls.MetroComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.bCGridImportData = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bCGridImportData)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuFBSave);
            this.bunifuGradientPanel1.Controls.Add(this.bFClose);
            this.bunifuGradientPanel1.Controls.Add(this.metroCBSheets);
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
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(838, 60);
            this.bunifuGradientPanel1.TabIndex = 1;
            // 
            // bunifuFBSave
            // 
            this.bunifuFBSave.Activecolor = System.Drawing.Color.Transparent;
            this.bunifuFBSave.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFBSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bunifuFBSave.BorderRadius = 0;
            this.bunifuFBSave.ButtonText = " Save";
            this.bunifuFBSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFBSave.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFBSave.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFBSave.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFBSave.Iconimage")));
            this.bunifuFBSave.Iconimage_right = null;
            this.bunifuFBSave.Iconimage_right_Selected = null;
            this.bunifuFBSave.Iconimage_Selected = null;
            this.bunifuFBSave.IconMarginLeft = 10;
            this.bunifuFBSave.IconMarginRight = 0;
            this.bunifuFBSave.IconRightVisible = true;
            this.bunifuFBSave.IconRightZoom = 0D;
            this.bunifuFBSave.IconVisible = true;
            this.bunifuFBSave.IconZoom = 60D;
            this.bunifuFBSave.IsTab = false;
            this.bunifuFBSave.Location = new System.Drawing.Point(295, 20);
            this.bunifuFBSave.Name = "bunifuFBSave";
            this.bunifuFBSave.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFBSave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(167)))), ((int)(((byte)(179)))));
            this.bunifuFBSave.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFBSave.selected = false;
            this.bunifuFBSave.Size = new System.Drawing.Size(94, 29);
            this.bunifuFBSave.TabIndex = 0;
            this.bunifuFBSave.Text = " Save";
            this.bunifuFBSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFBSave.Textcolor = System.Drawing.Color.White;
            this.bunifuFBSave.TextFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFBSave.Click += new System.EventHandler(this.bunifuFBSave_Click);
            // 
            // bFClose
            // 
            this.bFClose.Activecolor = System.Drawing.Color.Transparent;
            this.bFClose.BackColor = System.Drawing.Color.Transparent;
            this.bFClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bFClose.BorderRadius = 0;
            this.bFClose.ButtonText = "Close";
            this.bFClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bFClose.DisabledColor = System.Drawing.Color.Gray;
            this.bFClose.Iconcolor = System.Drawing.Color.Transparent;
            this.bFClose.Iconimage = ((System.Drawing.Image)(resources.GetObject("bFClose.Iconimage")));
            this.bFClose.Iconimage_right = null;
            this.bFClose.Iconimage_right_Selected = null;
            this.bFClose.Iconimage_Selected = null;
            this.bFClose.IconMarginLeft = 10;
            this.bFClose.IconMarginRight = 0;
            this.bFClose.IconRightVisible = true;
            this.bFClose.IconRightZoom = 0D;
            this.bFClose.IconVisible = true;
            this.bFClose.IconZoom = 70D;
            this.bFClose.IsTab = false;
            this.bFClose.Location = new System.Drawing.Point(740, 17);
            this.bFClose.Name = "bFClose";
            this.bFClose.Normalcolor = System.Drawing.Color.Transparent;
            this.bFClose.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(167)))), ((int)(((byte)(179)))));
            this.bFClose.OnHoverTextColor = System.Drawing.Color.White;
            this.bFClose.selected = false;
            this.bFClose.Size = new System.Drawing.Size(94, 29);
            this.bFClose.TabIndex = 2;
            this.bFClose.Text = "Close";
            this.bFClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bFClose.Textcolor = System.Drawing.Color.White;
            this.bFClose.TextFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bFClose.Click += new System.EventHandler(this.bFClose_Click);
            // 
            // metroCBSheets
            // 
            this.metroCBSheets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.metroCBSheets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.metroCBSheets.FormattingEnabled = true;
            this.metroCBSheets.ItemHeight = 23;
            this.metroCBSheets.Location = new System.Drawing.Point(455, 17);
            this.metroCBSheets.Name = "metroCBSheets";
            this.metroCBSheets.PromptText = "Sheets";
            this.metroCBSheets.Size = new System.Drawing.Size(236, 29);
            this.metroCBSheets.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroCBSheets.TabIndex = 1;
            this.metroCBSheets.UseCustomBackColor = true;
            this.metroCBSheets.UseCustomForeColor = true;
            this.metroCBSheets.UseSelectable = true;
            this.metroCBSheets.UseStyleColors = true;
            this.metroCBSheets.SelectedIndexChanged += new System.EventHandler(this.metroCBSheets_SelectedIndexChanged);
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
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(146, 25);
            this.bunifuCustomLabel1.TabIndex = 2;
            this.bunifuCustomLabel1.Text = "Import Results";
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.bCGridImportData);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 60);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(838, 447);
            this.panelGrid.TabIndex = 2;
            // 
            // bCGridImportData
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bCGridImportData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bCGridImportData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bCGridImportData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bCGridImportData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bCGridImportData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bCGridImportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bCGridImportData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bCGridImportData.DoubleBuffered = true;
            this.bCGridImportData.EnableHeadersVisualStyles = false;
            this.bCGridImportData.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.bCGridImportData.HeaderForeColor = System.Drawing.Color.White;
            this.bCGridImportData.Location = new System.Drawing.Point(0, 0);
            this.bCGridImportData.Name = "bCGridImportData";
            this.bCGridImportData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bCGridImportData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bCGridImportData.Size = new System.Drawing.Size(838, 447);
            this.bCGridImportData.TabIndex = 0;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.bunifuGradientPanel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // FrmImportedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 507);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmImportedData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportedData";
            this.Load += new System.EventHandler(this.FrmImportedData_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bCGridImportData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panelGrid;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bCGridImportData;
        private MetroFramework.Controls.MetroComboBox metroCBSheets;
        private Bunifu.Framework.UI.BunifuFlatButton bFClose;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFBSave;
    }
}