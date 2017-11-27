using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using custom_alert_notifications;

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

        public string FileLocation { get; set; }

        public ImportListItem(string title, string timestamp, string sizeoffile, bool status,string fileLocation)
        {
            this.Title = title;              //Student-Import_20171110_0900
            this.SizeOfFile = sizeoffile;    //20KB
            this.Timestamp = timestamp;      //2017-11-10 09:00
            this.Status = status;
            this.FileLocation = fileLocation;
        }
        private void ImportListItem_Load(object sender, EventArgs e)
        {
            //assign prop to labels
            lblTitle.Text = Title;
            lblSize.Text = SizeOfFile;
            lbltimestamp.Text = Timestamp;           
            if (File.Exists(FileLocation))
            {
                pictureStatus.Image = StatusGrid._1complete;
            }
            else
            {
                pictureStatus.Image = StatusGrid._1errors___Copy;
            }
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

        private async void imageDel_Click(object sender, EventArgs e)
        {
            // Delete the item refresh list
            if ((await StudentImportDel(Title)))
            {
                ImportsData Idata = ImportsData.Instance;
                Idata.listControl1.Remove(Title, Status);
                alert.Show("Deleted", alert.AlertType.info);
            }
        }

        //Perfecto
        private void btnView_Click(object sender, EventArgs e)
        {
            //Is  functional if status is true
            //Otherwise pop a toolbar message showing error || custom message
            if(File.Exists(FileLocation))
            {
                System.Diagnostics.Process.Start(FileLocation);
            }
            else
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.UseFading = true;
                toolTip1.UseAnimation = true;
                toolTip1.IsBalloon = true;
                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(btnView, " Data can not be found \n File may be missing \n File may be deleted");
            }
        }

        private async Task<bool> StudentImportDel(string title)
        {
            var studentImportListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.StudentImports.ToList();
                }
            });

            foreach (StudentImport item in studentImportListAsync)
            {
                if (item.Title.Equals(title))
                {
                    using (var context = new EschoolEntities())
                    {
                        context.Entry<StudentImport>(item).State = EntityState.Deleted;
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
            return false;
        }
    }
}
