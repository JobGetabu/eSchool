using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using custom_alert_notifications;

namespace eSchool
{
    public partial class StructureListItem : UserControl
    {
        public delegate void PassMoreDataDelegate(object sender, AutoGenFsEventArgs e);

        // add an event of the delegate type
        public static event PassMoreDataDelegate AutoListUpdated;
        public string Title { get; set; }
        public string Session { get; set; }
        public string TotalFeeTerm { get; set; }
        public StructureListItem()
        {
            InitializeComponent();
        }

        private void StructureListItem_Load(object sender, EventArgs e)
        {
            this.lblTitle.Text = Title; //i.e 2017 Form 1 2
            this.lblSession.Text = Session; //i.e Term 3
            this.lblTotal.Text = TotalFeeTerm; //i.e KES 20,000
        }

        //UI code
        private void MouseEnterEffect(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.FromArgb(247, 246, 248);
            pictureBox1.Image = GridIcon.Accounting_coloredpx;
            imageDel.Image = StatusGrid.Waste_Red;
        }
        private void MouseLeaveEffect(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.White;
            pictureBox1.Image = GridIcon.Accounting_50px;
            imageDel.Image = StatusGrid.Waste_64px;
        }

        private async Task<GroupedFeeStructure> SelectedFeeStructureAsync()
        {
            var gpFeeStructures = await Task.Factory.StartNew(() =>
             {
                 using (var context = new EschoolEntities())
                 {
                     return context.GroupedFeeStructures.ToList();
                 }
             });

            foreach (var gr in gpFeeStructures)
            {
                if (gr.YearTitle.Equals(lblTitle.Text) & gr.TermTitle.Equals(lblSession.Text) & gr.TotalTitle.Equals(lblTotal.Text))
                {
                    return gr;
                }
            }
            return null;
        }
        private async void AutoCreateFeeStructureAsync(int form)
        {
            using (var context = new EschoolEntities())
            {
                var selFs = await SelectedFeeStructureAsync();
                if (selFs != null)
                {
                    //ToDO 1 create fees structure
                }
            }
        }

        private async void FsClick(object sender, MouseEventArgs e)
        {
            string frmslbl = "Form ";
            var selFs = await SelectedFeeStructureAsync();
            if (selFs != null)
            {
                //raise our event
                bool autoGen = true;
                List<int> data = new List<int>();
                if (selFs.selFm1 == 1) { data.Add(1); frmslbl += "1"; }
                if (selFs.selFm2 == 2) { data.Add(2); frmslbl += " 2"; }
                if (selFs.selFm3 == 3) { data.Add(3); frmslbl += " 3"; }
                if (selFs.selFm4 == 4) { data.Add(4); frmslbl += " 4"; }

                decimal totalFee = selFs.TotalFee;
                int tmData = selFs.selTerm.Value;
                int yrData = selFs.selYear.Value; ;
                AutoGenFsEventArgs args = new AutoGenFsEventArgs(autoGen, totalFee, data, tmData, yrData);
                //give it updated args
                AutoListUpdated(this, args);


                //call the GridInit to update at switch
                OverHeadListItem d = new OverHeadListItem();
                d.GridData(FeesUI.autoFilterListOfForms, FeesUI.autoSelTerm, FeesUI.autoSelYear);


                //switch to FeeUI_Show
                FeesStructure fs = FeesStructure.Instance;
                fs.SwitchTabExt2();

                //save btn not visible
                //no func for editing saved fee structures is not available
                //refresh the list of fee items
                FeeUI_Show fui = FeeUI_Show.Instance;
                fui.btnSaveStructure.Visible = false;
                fui.btnCancel.Visible = true;
                fui.OlistControlInitAsync();

                //change label
                FeesStructure feeIns = FeesStructure.Instance;
                feeIns.lblYFeeStructure.Text = yrData + " Fee Structure ";
                feeIns.lblFFeeStructure.Text = frmslbl;
                feeIns.lblTFeeStructure.Text = "Term " + tmData;
                feeIns.lblTotalFeeStructure.Text = $"Total {selFs.TotalTitle}"; //Total KES 30,000

                //loading comboBox
                feeIns.bMenu.Clear();
                feeIns.bMenu.AddItem("Do Print"); //No print at this point
            }

        }

        private async void imageDel_Click(object sender, EventArgs e)
        {
            string foundStruc = Title + Session + TotalFeeTerm;

            // Delete the item refresh list
            if ((await GrpFeestructDel(foundStruc)))
            {
                FeeUI_List Idata = FeeUI_List.Instance;
                Idata.listControl1.Remove(Title, "Session");
                alert.Show("Deleted", alert.AlertType.info);
            }

            //change label
            FeesStructure feeIns = FeesStructure.Instance;
            feeIns.lblYFeeStructure.Text = $"{ Properties.Settings.Default.CurrentYear.ToString()}"+" Fee Structure ";
            feeIns.lblFFeeStructure.Text = "";
            feeIns.lblTFeeStructure.Text = "";
            feeIns.lblTotalFeeStructure.Text = "";//Total KES 30,000
            feeIns.CheckAnnualPrintAvail(Properties.Settings.Default.CurrentYear);

            //referesh the progress bars
            FeePayment fp = FeePayment.Instance;
            fp.Copy_FeePayment_Load();
        }

        private async Task<bool> GrpFeestructDel(string foundStruc)
        {

            var grpFeestructListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.GroupedFeeStructures.ToList();
                }
            });

            foreach (GroupedFeeStructure item in grpFeestructListAsync)
            {
                string f = item.YearTitle + item.TermTitle + item.TotalTitle;
                if (f.Equals(foundStruc))
                {
                    using (var context = new EschoolEntities())
                    {
                        if (MetroMessageBox.Show(this, "Are you sure you want to delete this fee structure ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            context.Entry<GroupedFeeStructure>(item).State = EntityState.Deleted;
                            try
                            {
                                context.SaveChanges();
                                return true;
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show(exp.Message);
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
