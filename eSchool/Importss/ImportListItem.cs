using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Importss
{
    public partial class ImportListItem : UserControl
    {
        public ImportListItem()
        {
            InitializeComponent();
        }

        public string Title { get; set; }
        public string SizeOfFile { get; set; }
        public string Timestamp { get; set; }
        public bool Status { get; set; }

        public ImportListItem(string title, string timestamp,string sizeoffile,bool status)
        {
            this.Title = title;              //Student-Import_20171110_0900
            this.SizeOfFile = sizeoffile;    //20KB
            this.Timestamp = timestamp;      //2017-11-10 09:00
            this.Status = status;
        }
        private void ImportListItem_Load(object sender, EventArgs e)
        {
            //assign prop to labels
            lblTitle.Text = Title;
            lblSize.Text = SizeOfFile;
            if (Status)
            {
                pictureStatus.Image = StatusGrid._1complete;
            }
            else
            {
                pictureStatus.Image = StatusGrid._1errors___Copy;
            }
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {

        }

        private void my_MouseEnter(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.FromArgb(247, 246, 248);
            bunifuCards1.color = Color.FromArgb(247, 246, 248);
            imageDel.Image = StatusGrid.Waste_Red;
        }
        private void my_MouseLeave(object sender, EventArgs e)
        {
            bunifuCards1.BackColor = Color.White;
            bunifuCards1.color = Color.White;
            imageDel.Image = StatusGrid.Waste_64px;
        }

        private void imageDel_Click(object sender, EventArgs e)
        {

        }
    }
}
