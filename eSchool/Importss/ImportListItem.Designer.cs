namespace eSchool.Importss
{
    partial class ImportListItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportListItem));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSize = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbltimestamp = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.pictureStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageDel = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCards1.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDel)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.White;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.White;
            this.bunifuCards1.Controls.Add(this.panelBody);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(798, 43);
            this.bunifuCards1.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.panel5);
            this.panelBody.Controls.Add(this.panel4);
            this.panelBody.Controls.Add(this.panel3);
            this.panelBody.Controls.Add(this.panel2);
            this.panelBody.Controls.Add(this.panel1);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 0);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(798, 43);
            this.panelBody.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageDel);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 43);
            this.panel1.TabIndex = 0;
            this.panel1.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(79, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(229, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Student-Import_20171110_0900";
            this.lblTitle.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(314, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 43);
            this.panel2.TabIndex = 1;
            this.panel2.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(36, 10);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(47, 20);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "28 KB";
            this.lblSize.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.lblSize.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbltimestamp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(399, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 43);
            this.panel3.TabIndex = 2;
            this.panel3.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // lbltimestamp
            // 
            this.lbltimestamp.AutoSize = true;
            this.lbltimestamp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimestamp.Location = new System.Drawing.Point(33, 10);
            this.lbltimestamp.Name = "lbltimestamp";
            this.lbltimestamp.Size = new System.Drawing.Size(123, 20);
            this.lbltimestamp.TabIndex = 3;
            this.lbltimestamp.Text = "2017-11-10 09:00";
            this.lbltimestamp.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.lbltimestamp.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureStatus);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(562, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 43);
            this.panel4.TabIndex = 3;
            this.panel4.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.panel4.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnView);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(672, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(126, 43);
            this.panel5.TabIndex = 4;
            this.panel5.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.panel5.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(238)))), ((int)(((byte)(244)))));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.DimGray;
            this.btnView.Image = global::eSchool.GridIcon.Sheet_of_Paper_52px;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(23, 11);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 22);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "     View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.btnView.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // pictureStatus
            // 
            this.pictureStatus.BackColor = System.Drawing.Color.Transparent;
            this.pictureStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureStatus.Image")));
            this.pictureStatus.Location = new System.Drawing.Point(4, 12);
            this.pictureStatus.Name = "pictureStatus";
            this.pictureStatus.Size = new System.Drawing.Size(106, 20);
            this.pictureStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureStatus.TabIndex = 1;
            this.pictureStatus.TabStop = false;
            this.pictureStatus.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.pictureStatus.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(36, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // imageDel
            // 
            this.imageDel.BackColor = System.Drawing.Color.Transparent;
            this.imageDel.Image = global::eSchool.StatusGrid.Waste_64px;
            this.imageDel.ImageActive = null;
            this.imageDel.Location = new System.Drawing.Point(8, 10);
            this.imageDel.Name = "imageDel";
            this.imageDel.Size = new System.Drawing.Size(22, 20);
            this.imageDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageDel.TabIndex = 4;
            this.imageDel.TabStop = false;
            this.imageDel.Zoom = 10;
            this.imageDel.Click += new System.EventHandler(this.imageDel_Click);
            this.imageDel.MouseEnter += new System.EventHandler(this.my_MouseEnter);
            this.imageDel.MouseLeave += new System.EventHandler(this.my_MouseLeave);
            // 
            // ImportListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.bunifuCards1);
            this.Name = "ImportListItem";
            this.Size = new System.Drawing.Size(798, 43);
            this.Load += new System.EventHandler(this.ImportListItem_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTitle;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel lblSize;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomLabel lbltimestamp;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureStatus;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnView;
        private Bunifu.Framework.UI.BunifuImageButton imageDel;
    }
}
