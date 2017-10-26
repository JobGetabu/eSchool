namespace eSchool
{
    partial class OverHeadListItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverHeadListItem));
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.panelTxt = new System.Windows.Forms.Panel();
            this.bTBOverHaed = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAssignItem = new System.Windows.Forms.Button();
            this.panelIcon = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCards1.SuspendLayout();
            this.panelTxt.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bunifuCards1.Controls.Add(this.panelTxt);
            this.bunifuCards1.Controls.Add(this.panel2);
            this.bunifuCards1.Controls.Add(this.panelIcon);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(308, 45);
            this.bunifuCards1.TabIndex = 0;
            // 
            // panelTxt
            // 
            this.panelTxt.AutoSize = true;
            this.panelTxt.Controls.Add(this.bTBOverHaed);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.panelTxt.Location = new System.Drawing.Point(35, 7);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(150, 38);
            this.panelTxt.TabIndex = 4;
            // 
            // bTBOverHaed
            // 
            this.bTBOverHaed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bTBOverHaed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.bTBOverHaed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bTBOverHaed.Cursor = System.Windows.Forms.Cursors.Default;
            this.bTBOverHaed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bTBOverHaed.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTBOverHaed.Location = new System.Drawing.Point(0, 0);
            this.bTBOverHaed.Multiline = true;
            this.bTBOverHaed.Name = "bTBOverHaed";
            this.bTBOverHaed.ReadOnly = true;
            this.bTBOverHaed.Size = new System.Drawing.Size(150, 38);
            this.bTBOverHaed.TabIndex = 0;
            this.bTBOverHaed.Text = "Electricity and Water and Construction";
            this.bTBOverHaed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAssignItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(185, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 45);
            this.panel2.TabIndex = 3;
            // 
            // btnAssignItem
            // 
            this.btnAssignItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignItem.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAssignItem.FlatAppearance.BorderSize = 2;
            this.btnAssignItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignItem.ForeColor = System.Drawing.Color.DimGray;
            this.btnAssignItem.Image = global::eSchool.GridIcon.Plus_Matpx;
            this.btnAssignItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssignItem.Location = new System.Drawing.Point(11, 8);
            this.btnAssignItem.Name = "btnAssignItem";
            this.btnAssignItem.Size = new System.Drawing.Size(109, 27);
            this.btnAssignItem.TabIndex = 0;
            this.btnAssignItem.Text = "Assign ";
            this.btnAssignItem.UseVisualStyleBackColor = true;
            this.btnAssignItem.Click += new System.EventHandler(this.btnAssignItem_Click);
            // 
            // panelIcon
            // 
            this.panelIcon.Controls.Add(this.pictureBox1);
            this.panelIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIcon.Location = new System.Drawing.Point(0, 0);
            this.panelIcon.Name = "panelIcon";
            this.panelIcon.Size = new System.Drawing.Size(35, 45);
            this.panelIcon.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // OverHeadListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.bunifuCards1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OverHeadListItem";
            this.Size = new System.Drawing.Size(308, 45);
            this.Load += new System.EventHandler(this.OverHeadListItem_Load);
            this.MouseLeave += new System.EventHandler(this.OverHeadListItem_MouseLeave);
            this.MouseHover += new System.EventHandler(this.OverHeadListItem_MouseHover);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.panelTxt.ResumeLayout(false);
            this.panelTxt.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private System.Windows.Forms.Panel panelTxt;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox bTBOverHaed;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAssignItem;
        private System.Windows.Forms.Panel panelIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
