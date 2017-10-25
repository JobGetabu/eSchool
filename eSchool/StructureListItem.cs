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
            this.lblTitle.Text = Title; //i.e 2017 Form 1, 2
            this.lblSession.Text = Session; //i.e Term 3
            this.lblTotal.Text = TotalFeeTerm; //i.e KES 20,000
        }

        private void bunifuCards1_MouseHover(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.FromArgb(247, 246, 248);
        }

        private void bunifuCards1_MouseLeave(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.White;
        }
    }
}
