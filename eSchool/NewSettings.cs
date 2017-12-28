using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using custom_alert_notifications;
using eSchool.MySettings;
using System.Resources;
using System.IO;

namespace eSchool
{
    public partial class NewSettings : UserControl
    {

        //Singleton pattern ***best practices***
        private static NewSettings _instance;


        public static NewSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NewSettings();
                }
                return _instance;
            }
        }
        public NewSettings()
        {
            InitializeComponent();
        }

        private string path;
        //MyLogos.resx
        string resxFile = @".\MyLogo.resx";

        private void NewSettings_Load(object sender, EventArgs e)
        {
            //init school details
            InitSchool();
            //change color of Type to greenish
            gData.Columns[0].DefaultCellStyle.ForeColor = Color.FromArgb(23, 123, 189);
            GridInitilizer();


            ReadLogo();
        }

        private void InitSchool()
        {
            lblAddress.Text = Properties.Settings.Default.schoolAddress;//
            btnScCell.Text = Properties.Settings.Default.schoolCell;
            btnScEmail.Text = Properties.Settings.Default.schoolEmail;
            lblScType.Text = $"Secondary - {Properties.Settings.Default.schoolType}"; //Secondary - Bording School
            lblName.Text = Properties.Settings.Default.schoolName;
            lblScCode.Text = $"Code : {Properties.Settings.Default.schoolreg}"; //Code : 2040700

        }
        public async void GridInitilizer()
        {
            var catListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Categories
                    .OrderBy(t => t.Id)
                    .ToList();
                }
            });
            gData.Rows.Clear();
            foreach (var item in catListAsync)
            {
                gData.Rows.Add(new string[]
                {
                       item.Type,
                       item.CategoryName
                });
            }
        }

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //this.lblRowCount.Text = gData.Rows.Count.ToString();
            this.gData.Rows[e.RowIndex].Cells[2].Value = GridIcon.Trash_Can_50px;
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                context.Entry<Category>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();

                                //short Custom Notification
                                alert.Show("Deleted", alert.AlertType.warnig);
                                gData.Rows[e.RowIndex].Visible = false;
                                //Load the grid again
                                GridInitilizer();
                            }
                            catch (Exception exp)
                            {
                                MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");
                            }
                        }
                    }
                }
            }
        }

        private async Task<Category> GridDelImageAsync(int rowIndex)
        {
            List<Category> catList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Categories.ToList();
                }
            });

            string details;
            details = $"({(string)this.gData.Rows[rowIndex].Cells[0].Value}){(string)this.gData.Rows[rowIndex].Cells[1].Value}";

            foreach (Category cc in catList)
            {
                string s = $"({cc.Type}){cc.CategoryName}";
                if (s.Equals(details))
                {
                    return cc;
                }
            }
            return null;
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            FrmAddCategories frm = new FrmAddCategories();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GridInitilizer();
            }

        }

        private void btnUpdateSchool_Click(object sender, EventArgs e)
        {
            FrmAddSchool frm = new FrmAddSchool();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                InitSchool();
            }
        }

        private void btnChangePic_Click(object sender, EventArgs e)
        {
            //Open up the search pic dialogue
            try
            {
                using (OpenFileDialog opf = new OpenFileDialog()
                { Filter = "Select Picture|*.jpg|*.JPEG|*.png|GIF|*gif", ValidateNames = true, Multiselect = false })
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                       // this.pictureBox1.Image = Image.FromFile(opf.FileName);
                       // this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        path = opf.FileName;

                        byte[] imageByte = ConvertFileToByte(path);
                        Image immm = ConvertByteToImage(imageByte);

                        //method to save it to resources
                        //SaveLogo(path, imageByte);
                        SaveLogo(path);
                        ReadLogo();
                        // short Custom Notification
                        alert.Show("Updated", alert.AlertType.success);
                    }

                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void SetUpImage()
        {
            // Get resources from .resx file.
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                Image mByte = null;
                try
                {
                    mByte = (Image)resxSet.GetObject("elogo");
                }
                catch (Exception)
                {

                    //throw;
                }
                //set up picture
                if (mByte == null)
                {
                    // path = "";
                    pictureBox1.Image = GridIcon.logo;
                }
                else
                {
                    try
                    {
                        this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox1.Image = mByte;
                    }
                    catch (Exception exp)
                    {
                        throw;
                    }
                }
            }
        }
        private void SaveLogo(string path, byte[] imageByte)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(resxFile))
            {
                resx.AddResource("elogo", imageByte);
            }
        }

        private void SaveLogo(string path)
        {
            //read image
            Bitmap bmp = new Bitmap(path);

            //load image in picturebox
            pictureBox1.Image = bmp;

            //write image
            bmp.Save(".\\Output.png");
        }
        private void ReadLogo()
        {
            Image mByte = null;
            try
            {
                mByte = new Bitmap(".\\Output.png");
            }
            catch (Exception)
            {

                //throw;
            }
            //set up picture
            if (mByte == null)
            {
                // path = "";
                pictureBox1.Image = GridIcon.logo;
            }
            else
            {
                try
                {
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = mByte;
                }
                catch (Exception exp)
                {
                    throw;
                }
            }
        }

        private byte[] ConvertFileToByte(string spath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(spath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(spath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private Image ConvertByteToImage(byte[] photoByte)
        {
            Image nImage;
            using (MemoryStream ms = new MemoryStream(photoByte, 0, photoByte.Length))
            {
                ms.Write(photoByte, 0, photoByte.Length);
                nImage = Image.FromStream(ms, true);
            }

            return nImage;
        }
    }
}
