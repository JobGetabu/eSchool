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
    public partial class OverHeadListItem : UserControl
    {
        public string OverHeadName { get; set; }
        public OverHeadListItem(string overheadName)
        {
            InitializeComponent();

            this.OverHeadName = overheadName;
        }

        private void OverHeadListItem_Load(object sender, EventArgs e)
        {
            this.bTBOverHaed.Text = OverHeadName;
        }

        private void btnAssignItem_Click(object sender, EventArgs e)
        {
            //ToDO
            //startup the AssignFeeItem form
            //pass overhead string & fmStore & selYear
        }
    }
}
