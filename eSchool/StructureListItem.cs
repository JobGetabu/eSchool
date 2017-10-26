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
            var selFs = await SelectedFeeStructureAsync();
            if (selFs != null)
            {
                MessageBox.Show($"You clicked fee structure with id {selFs.Id} \n its title is {selFs.YearTitle} and term is {selFs.TermTitle} = KES {selFs.TotalFee}");
            }

        }
    }
}
