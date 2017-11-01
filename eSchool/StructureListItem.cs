using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }
        private void MouseLeaveEffect(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.White;
            pictureBox1.Image = GridIcon.Accounting_50px;
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
                if (selFs.selFm2 == 2) { data.Add(2); frmslbl += " 2";}
                if (selFs.selFm3 == 3) { data.Add(3); frmslbl += " 3";}
                if (selFs.selFm4 == 4) { data.Add(4); frmslbl += " 4";}

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

                ////save btn not visible
                //no func for editing saved fee structures is not available
                //refresh the list of fee items
                FeeUI_Show fui = FeeUI_Show.Instance;
                fui.btnSaveStructure.Visible = false;
                fui.OlistControlInitAsync();
                //change label
                FeesStructure feeIns = FeesStructure.Instance;
                feeIns.lblYFeeStructure.Text = yrData + " Fee Structure ";
                feeIns.lblFFeeStructure.Text = frmslbl;
                feeIns.lblTFeeStructure.Text = "Term " + tmData;
                feeIns.lblTotalFeeStructure.Text = $"Total {selFs.TotalTitle}"; //Total KES 30,000
                //loading comboBox
                string[] n = { };
                feeIns.bMenu.Items = n;
                feeIns.bMenu.AddItem("Print"); //No print at this point
            }

        }
    }
}
