namespace eSchool
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.feesIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountPaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeOfPaymentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.schoolPeriodTermBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolPeriodTermBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 517);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.feesIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.adminNoDataGridViewTextBoxColumn,
            this.formDataGridViewTextBoxColumn,
            this.classDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.termDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.amountPaidDataGridViewTextBoxColumn,
            this.modeOfPaymentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.feeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(619, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.schoolPeriodTermBindingSource, "Term", true));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // feesIdDataGridViewTextBoxColumn
            // 
            this.feesIdDataGridViewTextBoxColumn.DataPropertyName = "FeesId";
            this.feesIdDataGridViewTextBoxColumn.HeaderText = "FeesId";
            this.feesIdDataGridViewTextBoxColumn.Name = "feesIdDataGridViewTextBoxColumn";
            this.feesIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.feesIdDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // adminNoDataGridViewTextBoxColumn
            // 
            this.adminNoDataGridViewTextBoxColumn.DataPropertyName = "Admin_No";
            this.adminNoDataGridViewTextBoxColumn.HeaderText = "Admin_No";
            this.adminNoDataGridViewTextBoxColumn.Name = "adminNoDataGridViewTextBoxColumn";
            this.adminNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.adminNoDataGridViewTextBoxColumn.Width = 50;
            // 
            // formDataGridViewTextBoxColumn
            // 
            this.formDataGridViewTextBoxColumn.DataPropertyName = "Form";
            this.formDataGridViewTextBoxColumn.HeaderText = "Form";
            this.formDataGridViewTextBoxColumn.Name = "formDataGridViewTextBoxColumn";
            this.formDataGridViewTextBoxColumn.Width = 40;
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "Class";
            this.classDataGridViewTextBoxColumn.HeaderText = "Class";
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            this.classDataGridViewTextBoxColumn.Width = 70;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // termDataGridViewTextBoxColumn
            // 
            this.termDataGridViewTextBoxColumn.DataPropertyName = "Term";
            this.termDataGridViewTextBoxColumn.HeaderText = "Term";
            this.termDataGridViewTextBoxColumn.Name = "termDataGridViewTextBoxColumn";
            this.termDataGridViewTextBoxColumn.Width = 40;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.Width = 50;
            // 
            // amountPaidDataGridViewTextBoxColumn
            // 
            this.amountPaidDataGridViewTextBoxColumn.DataPropertyName = "Amount_Paid";
            this.amountPaidDataGridViewTextBoxColumn.HeaderText = "Amount_Paid";
            this.amountPaidDataGridViewTextBoxColumn.Name = "amountPaidDataGridViewTextBoxColumn";
            this.amountPaidDataGridViewTextBoxColumn.Width = 70;
            // 
            // modeOfPaymentDataGridViewTextBoxColumn
            // 
            this.modeOfPaymentDataGridViewTextBoxColumn.DataPropertyName = "ModeOfPayment";
            this.modeOfPaymentDataGridViewTextBoxColumn.HeaderText = "ModeOfPayment";
            this.modeOfPaymentDataGridViewTextBoxColumn.Name = "modeOfPaymentDataGridViewTextBoxColumn";
            this.modeOfPaymentDataGridViewTextBoxColumn.Width = 70;
            // 
            // feeBindingSource
            // 
            this.feeBindingSource.DataSource = typeof(eSchool.Fee);
            // 
            // schoolPeriodTermBindingSource
            // 
            this.schoolPeriodTermBindingSource.DataSource = typeof(eSchool.SchoolPeriodTerm);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 517);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Db Information";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schoolPeriodTermBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn feesIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adminNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn termDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountPaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeOfPaymentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource feeBindingSource;
        private System.Windows.Forms.BindingSource schoolPeriodTermBindingSource;
        private System.Windows.Forms.Label label1;
    }
}

