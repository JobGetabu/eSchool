namespace eSchool
{
    partial class Frm_Home
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.containerUIs = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuImageButton3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_settings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_imports = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_transations = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_fees = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_expenses = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_income = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_invoices = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_dashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelProf = new System.Windows.Forms.Panel();
            this.bunifuDropdownDashMenu = new Bunifu.Framework.UI.BunifuDropdown();
            this.bunifuImageBtnSearch = new Bunifu.Framework.UI.BunifuImageButton();
            this.metroComboBoxSearch = new MetroFramework.Controls.MetroComboBox();
            this.metro_search_box = new MetroFramework.Controls.MetroTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBxMenuHome = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuTransitionUIs = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.logoAnim = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.ovalPictureBox1 = new eSchool.OvalPictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelProf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageBtnSearch)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBxMenuHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.sidebar);
            this.panel1.Controls.Add(this.panelTop);
            this.logoAnim.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 593);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.containerUIs);
            this.logoAnim.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(240, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 543);
            this.panel2.TabIndex = 2;
            // 
            // containerUIs
            // 
            this.logoAnim.SetDecoration(this.containerUIs, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.containerUIs, BunifuAnimatorNS.DecorationType.BottomMirror);
            this.containerUIs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerUIs.Location = new System.Drawing.Point(0, 0);
            this.containerUIs.Name = "containerUIs";
            this.containerUIs.Size = new System.Drawing.Size(798, 543);
            this.containerUIs.TabIndex = 5;
            // 
            // sidebar
            // 
            this.sidebar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.btn_settings);
            this.sidebar.Controls.Add(this.btn_imports);
            this.sidebar.Controls.Add(this.btn_transations);
            this.sidebar.Controls.Add(this.btn_fees);
            this.sidebar.Controls.Add(this.btn_expenses);
            this.sidebar.Controls.Add(this.btn_income);
            this.sidebar.Controls.Add(this.btn_invoices);
            this.sidebar.Controls.Add(this.btn_dashboard);
            this.sidebar.Controls.Add(this.panel4);
            this.logoAnim.SetDecoration(this.sidebar, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.sidebar, BunifuAnimatorNS.DecorationType.None);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 50);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(240, 543);
            this.sidebar.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bunifuImageButton3);
            this.panel3.Controls.Add(this.bunifuImageButton2);
            this.logoAnim.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 503);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 40);
            this.panel3.TabIndex = 9;
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.logoAnim.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton3.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton3.Image")));
            this.bunifuImageButton3.ImageActive = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton3.ImageActive")));
            this.bunifuImageButton3.Location = new System.Drawing.Point(169, 3);
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.Size = new System.Drawing.Size(36, 35);
            this.bunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton3.TabIndex = 1;
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 2;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.logoAnim.SetDecoration(this.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.ImageActive")));
            this.bunifuImageButton2.Location = new System.Drawing.Point(21, 3);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(36, 35);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 0;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 2;
            // 
            // btn_settings
            // 
            this.btn_settings.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_settings.BorderRadius = 0;
            this.btn_settings.ButtonText = "   Settings";
            this.btn_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_settings, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_settings, BunifuAnimatorNS.DecorationType.None);
            this.btn_settings.DisabledColor = System.Drawing.Color.Gray;
            this.btn_settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_settings.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_settings.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_settings.Iconimage")));
            this.btn_settings.Iconimage_right = null;
            this.btn_settings.Iconimage_right_Selected = null;
            this.btn_settings.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_settings.Iconimage_Selected")));
            this.btn_settings.IconMarginLeft = 25;
            this.btn_settings.IconMarginRight = 0;
            this.btn_settings.IconRightVisible = true;
            this.btn_settings.IconRightZoom = 0D;
            this.btn_settings.IconVisible = true;
            this.btn_settings.IconZoom = 40D;
            this.btn_settings.IsTab = true;
            this.btn_settings.Location = new System.Drawing.Point(0, 488);
            this.btn_settings.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_settings.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_settings.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_settings.selected = false;
            this.btn_settings.Size = new System.Drawing.Size(240, 70);
            this.btn_settings.TabIndex = 8;
            this.btn_settings.Text = "   Settings";
            this.btn_settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_settings.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_settings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_imports
            // 
            this.btn_imports.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_imports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_imports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_imports.BorderRadius = 0;
            this.btn_imports.ButtonText = "   Imports";
            this.btn_imports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_imports, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_imports, BunifuAnimatorNS.DecorationType.None);
            this.btn_imports.DisabledColor = System.Drawing.Color.Gray;
            this.btn_imports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_imports.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_imports.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_imports.Iconimage")));
            this.btn_imports.Iconimage_right = null;
            this.btn_imports.Iconimage_right_Selected = null;
            this.btn_imports.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_imports.Iconimage_Selected")));
            this.btn_imports.IconMarginLeft = 25;
            this.btn_imports.IconMarginRight = 0;
            this.btn_imports.IconRightVisible = true;
            this.btn_imports.IconRightZoom = 0D;
            this.btn_imports.IconVisible = true;
            this.btn_imports.IconZoom = 40D;
            this.btn_imports.IsTab = true;
            this.btn_imports.Location = new System.Drawing.Point(0, 418);
            this.btn_imports.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.btn_imports.Name = "btn_imports";
            this.btn_imports.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_imports.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_imports.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_imports.selected = false;
            this.btn_imports.Size = new System.Drawing.Size(240, 70);
            this.btn_imports.TabIndex = 7;
            this.btn_imports.Text = "   Imports";
            this.btn_imports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_imports.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_imports.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imports.Click += new System.EventHandler(this.btn_imports_Click);
            // 
            // btn_transations
            // 
            this.btn_transations.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_transations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_transations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_transations.BorderRadius = 0;
            this.btn_transations.ButtonText = "   Transactions";
            this.btn_transations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_transations, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_transations, BunifuAnimatorNS.DecorationType.None);
            this.btn_transations.DisabledColor = System.Drawing.Color.Gray;
            this.btn_transations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_transations.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_transations.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_transations.Iconimage")));
            this.btn_transations.Iconimage_right = null;
            this.btn_transations.Iconimage_right_Selected = null;
            this.btn_transations.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_transations.Iconimage_Selected")));
            this.btn_transations.IconMarginLeft = 25;
            this.btn_transations.IconMarginRight = 0;
            this.btn_transations.IconRightVisible = true;
            this.btn_transations.IconRightZoom = 0D;
            this.btn_transations.IconVisible = true;
            this.btn_transations.IconZoom = 40D;
            this.btn_transations.IsTab = true;
            this.btn_transations.Location = new System.Drawing.Point(0, 348);
            this.btn_transations.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.btn_transations.Name = "btn_transations";
            this.btn_transations.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_transations.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_transations.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_transations.selected = false;
            this.btn_transations.Size = new System.Drawing.Size(240, 70);
            this.btn_transations.TabIndex = 6;
            this.btn_transations.Text = "   Transactions";
            this.btn_transations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_transations.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_transations.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_transations.Click += new System.EventHandler(this.btn_transations_Click);
            // 
            // btn_fees
            // 
            this.btn_fees.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_fees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_fees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_fees.BorderRadius = 0;
            this.btn_fees.ButtonText = "   Fees";
            this.btn_fees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_fees, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_fees, BunifuAnimatorNS.DecorationType.None);
            this.btn_fees.DisabledColor = System.Drawing.Color.Gray;
            this.btn_fees.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_fees.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_fees.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_fees.Iconimage")));
            this.btn_fees.Iconimage_right = null;
            this.btn_fees.Iconimage_right_Selected = null;
            this.btn_fees.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_fees.Iconimage_Selected")));
            this.btn_fees.IconMarginLeft = 25;
            this.btn_fees.IconMarginRight = 0;
            this.btn_fees.IconRightVisible = true;
            this.btn_fees.IconRightZoom = 0D;
            this.btn_fees.IconVisible = true;
            this.btn_fees.IconZoom = 40D;
            this.btn_fees.IsTab = true;
            this.btn_fees.Location = new System.Drawing.Point(0, 278);
            this.btn_fees.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.btn_fees.Name = "btn_fees";
            this.btn_fees.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_fees.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_fees.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_fees.selected = false;
            this.btn_fees.Size = new System.Drawing.Size(240, 70);
            this.btn_fees.TabIndex = 5;
            this.btn_fees.Text = "   Fees";
            this.btn_fees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_fees.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_fees.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fees.Click += new System.EventHandler(this.btn_fees_Click);
            // 
            // btn_expenses
            // 
            this.btn_expenses.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_expenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_expenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_expenses.BorderRadius = 0;
            this.btn_expenses.ButtonText = "   Expense";
            this.btn_expenses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_expenses, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_expenses, BunifuAnimatorNS.DecorationType.None);
            this.btn_expenses.DisabledColor = System.Drawing.Color.Gray;
            this.btn_expenses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_expenses.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_expenses.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_expenses.Iconimage")));
            this.btn_expenses.Iconimage_right = null;
            this.btn_expenses.Iconimage_right_Selected = null;
            this.btn_expenses.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_expenses.Iconimage_Selected")));
            this.btn_expenses.IconMarginLeft = 25;
            this.btn_expenses.IconMarginRight = 0;
            this.btn_expenses.IconRightVisible = true;
            this.btn_expenses.IconRightZoom = 0D;
            this.btn_expenses.IconVisible = true;
            this.btn_expenses.IconZoom = 40D;
            this.btn_expenses.IsTab = true;
            this.btn_expenses.Location = new System.Drawing.Point(0, 208);
            this.btn_expenses.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.btn_expenses.Name = "btn_expenses";
            this.btn_expenses.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_expenses.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_expenses.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_expenses.selected = false;
            this.btn_expenses.Size = new System.Drawing.Size(240, 70);
            this.btn_expenses.TabIndex = 4;
            this.btn_expenses.Text = "   Expense";
            this.btn_expenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_expenses.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_expenses.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_expenses.Click += new System.EventHandler(this.btn_expenses_Click);
            // 
            // btn_income
            // 
            this.btn_income.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_income.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_income.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_income.BorderRadius = 0;
            this.btn_income.ButtonText = "   Income";
            this.btn_income.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_income, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_income, BunifuAnimatorNS.DecorationType.None);
            this.btn_income.DisabledColor = System.Drawing.Color.Gray;
            this.btn_income.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_income.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_income.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_income.Iconimage")));
            this.btn_income.Iconimage_right = null;
            this.btn_income.Iconimage_right_Selected = null;
            this.btn_income.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_income.Iconimage_Selected")));
            this.btn_income.IconMarginLeft = 25;
            this.btn_income.IconMarginRight = 0;
            this.btn_income.IconRightVisible = true;
            this.btn_income.IconRightZoom = 0D;
            this.btn_income.IconVisible = true;
            this.btn_income.IconZoom = 40D;
            this.btn_income.IsTab = true;
            this.btn_income.Location = new System.Drawing.Point(0, 138);
            this.btn_income.Margin = new System.Windows.Forms.Padding(12, 3, 12, 3);
            this.btn_income.Name = "btn_income";
            this.btn_income.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_income.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_income.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_income.selected = false;
            this.btn_income.Size = new System.Drawing.Size(240, 70);
            this.btn_income.TabIndex = 3;
            this.btn_income.Text = "   Income";
            this.btn_income.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_income.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_income.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_income.Click += new System.EventHandler(this.btn_income_Click);
            // 
            // btn_invoices
            // 
            this.btn_invoices.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_invoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_invoices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_invoices.BorderRadius = 0;
            this.btn_invoices.ButtonText = "   Invoice && Receipts";
            this.btn_invoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_invoices, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_invoices, BunifuAnimatorNS.DecorationType.None);
            this.btn_invoices.DisabledColor = System.Drawing.Color.Gray;
            this.btn_invoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_invoices.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_invoices.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_invoices.Iconimage")));
            this.btn_invoices.Iconimage_right = null;
            this.btn_invoices.Iconimage_right_Selected = null;
            this.btn_invoices.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_invoices.Iconimage_Selected")));
            this.btn_invoices.IconMarginLeft = 25;
            this.btn_invoices.IconMarginRight = 0;
            this.btn_invoices.IconRightVisible = true;
            this.btn_invoices.IconRightZoom = 0D;
            this.btn_invoices.IconVisible = true;
            this.btn_invoices.IconZoom = 40D;
            this.btn_invoices.IsTab = true;
            this.btn_invoices.Location = new System.Drawing.Point(0, 77);
            this.btn_invoices.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.btn_invoices.Name = "btn_invoices";
            this.btn_invoices.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_invoices.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_invoices.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_invoices.selected = false;
            this.btn_invoices.Size = new System.Drawing.Size(240, 61);
            this.btn_invoices.TabIndex = 2;
            this.btn_invoices.Text = "   Invoice && Receipts";
            this.btn_invoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_invoices.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_invoices.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_invoices.Click += new System.EventHandler(this.btn_invoices_Click);
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_dashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dashboard.BorderRadius = 0;
            this.btn_dashboard.ButtonText = "   Dashboard";
            this.btn_dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoAnim.SetDecoration(this.btn_dashboard, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.btn_dashboard, BunifuAnimatorNS.DecorationType.None);
            this.btn_dashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btn_dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_dashboard.ForeColor = System.Drawing.Color.White;
            this.btn_dashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_dashboard.Iconimage = ((System.Drawing.Image)(resources.GetObject("btn_dashboard.Iconimage")));
            this.btn_dashboard.Iconimage_right = null;
            this.btn_dashboard.Iconimage_right_Selected = null;
            this.btn_dashboard.Iconimage_Selected = ((System.Drawing.Image)(resources.GetObject("btn_dashboard.Iconimage_Selected")));
            this.btn_dashboard.IconMarginLeft = 25;
            this.btn_dashboard.IconMarginRight = 0;
            this.btn_dashboard.IconRightVisible = true;
            this.btn_dashboard.IconRightZoom = 0D;
            this.btn_dashboard.IconVisible = true;
            this.btn_dashboard.IconZoom = 40D;
            this.btn_dashboard.IsTab = true;
            this.btn_dashboard.Location = new System.Drawing.Point(0, 16);
            this.btn_dashboard.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
            this.btn_dashboard.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.btn_dashboard.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_dashboard.selected = false;
            this.btn_dashboard.Size = new System.Drawing.Size(240, 61);
            this.btn_dashboard.TabIndex = 0;
            this.btn_dashboard.Text = "   Dashboard";
            this.btn_dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dashboard.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(135)))), ((int)(((byte)(169)))));
            this.btn_dashboard.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // panel4
            // 
            this.logoAnim.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 16);
            this.panel4.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.panelProf);
            this.panelTop.Controls.Add(this.bunifuImageBtnSearch);
            this.panelTop.Controls.Add(this.metroComboBoxSearch);
            this.panelTop.Controls.Add(this.metro_search_box);
            this.panelTop.Controls.Add(this.panel5);
            this.logoAnim.SetDecoration(this.panelTop, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panelTop, BunifuAnimatorNS.DecorationType.None);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1038, 50);
            this.panelTop.TabIndex = 0;
            // 
            // panelProf
            // 
            this.panelProf.Controls.Add(this.ovalPictureBox1);
            this.panelProf.Controls.Add(this.bunifuDropdownDashMenu);
            this.logoAnim.SetDecoration(this.panelProf, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panelProf, BunifuAnimatorNS.DecorationType.None);
            this.panelProf.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelProf.Location = new System.Drawing.Point(754, 0);
            this.panelProf.Name = "panelProf";
            this.panelProf.Size = new System.Drawing.Size(284, 50);
            this.panelProf.TabIndex = 5;
            // 
            // bunifuDropdownDashMenu
            // 
            this.bunifuDropdownDashMenu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuDropdownDashMenu.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdownDashMenu.BorderRadius = 3;
            this.bunifuTransitionUIs.SetDecoration(this.bunifuDropdownDashMenu, BunifuAnimatorNS.DecorationType.None);
            this.logoAnim.SetDecoration(this.bunifuDropdownDashMenu, BunifuAnimatorNS.DecorationType.None);
            this.bunifuDropdownDashMenu.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDropdownDashMenu.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdownDashMenu.Items = new string[] {
        "Profile",
        "Settings",
        "Log out"};
            this.bunifuDropdownDashMenu.Location = new System.Drawing.Point(96, 7);
            this.bunifuDropdownDashMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bunifuDropdownDashMenu.Name = "bunifuDropdownDashMenu";
            this.bunifuDropdownDashMenu.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuDropdownDashMenu.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(174)))), ((int)(((byte)(136)))));
            this.bunifuDropdownDashMenu.selectedIndex = 0;
            this.bunifuDropdownDashMenu.Size = new System.Drawing.Size(175, 35);
            this.bunifuDropdownDashMenu.TabIndex = 8;
            // 
            // bunifuImageBtnSearch
            // 
            this.bunifuImageBtnSearch.BackColor = System.Drawing.Color.White;
            this.bunifuImageBtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoAnim.SetDecoration(this.bunifuImageBtnSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.bunifuImageBtnSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageBtnSearch.Image")));
            this.bunifuImageBtnSearch.ImageActive = null;
            this.bunifuImageBtnSearch.Location = new System.Drawing.Point(713, 13);
            this.bunifuImageBtnSearch.Margin = new System.Windows.Forms.Padding(5);
            this.bunifuImageBtnSearch.Name = "bunifuImageBtnSearch";
            this.bunifuImageBtnSearch.Size = new System.Drawing.Size(29, 29);
            this.bunifuImageBtnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageBtnSearch.TabIndex = 4;
            this.bunifuImageBtnSearch.TabStop = false;
            this.bunifuImageBtnSearch.Zoom = 10;
            // 
            // metroComboBoxSearch
            // 
            this.logoAnim.SetDecoration(this.metroComboBoxSearch, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.metroComboBoxSearch, BunifuAnimatorNS.DecorationType.None);
            this.metroComboBoxSearch.FormattingEnabled = true;
            this.metroComboBoxSearch.ItemHeight = 23;
            this.metroComboBoxSearch.Items.AddRange(new object[] {
            "Student",
            "Class",
            "Form"});
            this.metroComboBoxSearch.Location = new System.Drawing.Point(537, 13);
            this.metroComboBoxSearch.Name = "metroComboBoxSearch";
            this.metroComboBoxSearch.Size = new System.Drawing.Size(164, 29);
            this.metroComboBoxSearch.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroComboBoxSearch.TabIndex = 3;
            this.metroComboBoxSearch.UseSelectable = true;
            // 
            // metro_search_box
            // 
            this.metro_search_box.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.metro_search_box.CustomButton.Image = null;
            this.metro_search_box.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.metro_search_box.CustomButton.Name = "";
            this.metro_search_box.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.metro_search_box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metro_search_box.CustomButton.TabIndex = 1;
            this.metro_search_box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metro_search_box.CustomButton.UseSelectable = true;
            this.metro_search_box.CustomButton.Visible = false;
            this.logoAnim.SetDecoration(this.metro_search_box, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.metro_search_box, BunifuAnimatorNS.DecorationType.None);
            this.metro_search_box.Lines = new string[0];
            this.metro_search_box.Location = new System.Drawing.Point(269, 13);
            this.metro_search_box.MaxLength = 32767;
            this.metro_search_box.Name = "metro_search_box";
            this.metro_search_box.PasswordChar = '\0';
            this.metro_search_box.PromptText = "Search";
            this.metro_search_box.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metro_search_box.SelectedText = "";
            this.metro_search_box.SelectionLength = 0;
            this.metro_search_box.SelectionStart = 0;
            this.metro_search_box.ShortcutsEnabled = true;
            this.metro_search_box.Size = new System.Drawing.Size(262, 29);
            this.metro_search_box.Style = MetroFramework.MetroColorStyle.Blue;
            this.metro_search_box.TabIndex = 2;
            this.metro_search_box.UseSelectable = true;
            this.metro_search_box.WaterMark = "Search";
            this.metro_search_box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.metro_search_box.WaterMarkFont = new System.Drawing.Font("Lucida Bright", 11.75F);
            // 
            // panel5
            // 
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Controls.Add(this.pictureBxMenuHome);
            this.panel5.Controls.Add(this.pictureBox1);
            this.logoAnim.SetDecoration(this.panel5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuTransitionUIs.SetDecoration(this.panel5, BunifuAnimatorNS.DecorationType.None);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(237, 50);
            this.panel5.TabIndex = 0;
            // 
            // pictureBxMenuHome
            // 
            this.bunifuTransitionUIs.SetDecoration(this.pictureBxMenuHome, BunifuAnimatorNS.DecorationType.None);
            this.logoAnim.SetDecoration(this.pictureBxMenuHome, BunifuAnimatorNS.DecorationType.None);
            this.pictureBxMenuHome.Image = ((System.Drawing.Image)(resources.GetObject("pictureBxMenuHome.Image")));
            this.pictureBxMenuHome.Location = new System.Drawing.Point(14, 11);
            this.pictureBxMenuHome.Name = "pictureBxMenuHome";
            this.pictureBxMenuHome.Size = new System.Drawing.Size(25, 25);
            this.pictureBxMenuHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBxMenuHome.TabIndex = 1;
            this.pictureBxMenuHome.TabStop = false;
            this.pictureBxMenuHome.Click += new System.EventHandler(this.pictureBxMenuHome_Click);
            // 
            // pictureBox1
            // 
            this.bunifuTransitionUIs.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.logoAnim.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuTransitionUIs
            // 
            this.bunifuTransitionUIs.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndHorizSlide;
            this.bunifuTransitionUIs.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.bunifuTransitionUIs.DefaultAnimation = animation2;
            this.bunifuTransitionUIs.MaxAnimationTime = 1000;
            // 
            // logoAnim
            // 
            this.logoAnim.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate;
            this.logoAnim.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(30);
            animation1.RotateCoeff = 0.5F;
            animation1.RotateLimit = 0.2F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.logoAnim.DefaultAnimation = animation1;
            // 
            // ovalPictureBox1
            // 
            this.ovalPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovalPictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.bunifuTransitionUIs.SetDecoration(this.ovalPictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.logoAnim.SetDecoration(this.ovalPictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.ovalPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("ovalPictureBox1.Image")));
            this.ovalPictureBox1.Location = new System.Drawing.Point(46, 7);
            this.ovalPictureBox1.Name = "ovalPictureBox1";
            this.ovalPictureBox1.Size = new System.Drawing.Size(35, 35);
            this.ovalPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ovalPictureBox1.TabIndex = 9;
            this.ovalPictureBox1.TabStop = false;
            // 
            // Frm_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 593);
            this.Controls.Add(this.panel1);
            this.bunifuTransitionUIs.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.logoAnim.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1054, 632);
            this.Name = "Frm_Home";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eSchool Finance ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelProf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageBtnSearch)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBxMenuHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel containerUIs;
        private BunifuAnimatorNS.BunifuTransition bunifuTransitionUIs;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelProf;
        private OvalPictureBox ovalPictureBox1;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdownDashMenu;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageBtnSearch;
        private MetroFramework.Controls.MetroComboBox metroComboBoxSearch;
        private MetroFramework.Controls.MetroTextBox metro_search_box;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBxMenuHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Bunifu.Framework.UI.BunifuFlatButton btn_settings;
        private Bunifu.Framework.UI.BunifuFlatButton btn_imports;
        private Bunifu.Framework.UI.BunifuFlatButton btn_transations;
        private Bunifu.Framework.UI.BunifuFlatButton btn_fees;
        private Bunifu.Framework.UI.BunifuFlatButton btn_expenses;
        private Bunifu.Framework.UI.BunifuFlatButton btn_income;
        private Bunifu.Framework.UI.BunifuFlatButton btn_invoices;
        private Bunifu.Framework.UI.BunifuFlatButton btn_dashboard;
        private System.Windows.Forms.Panel panel4;
        private BunifuAnimatorNS.BunifuTransition logoAnim;
    }
}