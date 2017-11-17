using System;

namespace eSchool.TransionX
{
    partial class FilterContentDates
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
            this.DatepickerStart = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lblYear = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.SuspendLayout();
            // 
            // DatepickerStart
            // 
            this.DatepickerStart.BackColor = System.Drawing.Color.SeaGreen;
            this.DatepickerStart.BorderRadius = 0;
            this.DatepickerStart.ForeColor = System.Drawing.Color.White;
            this.DatepickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatepickerStart.FormatCustom = "dd MMM yyy";
            this.DatepickerStart.Location = new System.Drawing.Point(3, 34);
            this.DatepickerStart.Name = "DatepickerStart";
            this.DatepickerStart.Size = new System.Drawing.Size(258, 36);
            this.DatepickerStart.TabIndex = 0;
            this.DatepickerStart.Value = DateTime.Now;
            this.DatepickerStart.onValueChanged += new System.EventHandler(this.DatepickerStart_onValueChanged);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblYear.Location = new System.Drawing.Point(14, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(111, 17);
            this.lblYear.TabIndex = 43;
            this.lblYear.Text = "Pick Month Date";
            // 
            // FilterContentDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.DatepickerStart);
            this.Name = "FilterContentDates";
            this.Size = new System.Drawing.Size(264, 89);
            this.Load += new System.EventHandler(this.FilterContentDates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDatepicker DatepickerStart;
        private Bunifu.Framework.UI.BunifuCustomLabel lblYear;
    }
}
