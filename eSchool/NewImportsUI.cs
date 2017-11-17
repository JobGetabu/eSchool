using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSchool.Importss;
using System.IO;
using MetroFramework;
using ExcelDataReader;

namespace eSchool
{
    public partial class NewImportsUI : UserControl
    {

        private static NewImportsUI _instance;
        public static NewImportsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NewImportsUI();
                }
                return _instance;
            }
        }
        public NewImportsUI()
        {
            InitializeComponent();
        }

        private void TabSwitcher(Control UIinstance)
        {
            if (!NewImportsUI.Instance.container.Controls.Contains(UIinstance))
            {
                NewImportsUI.Instance.container.Controls.Add(UIinstance);
                UIinstance.Dock = DockStyle.Fill;
                UIinstance.BringToFront();
            }
            else
            {
                UIinstance.BringToFront();
            }
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab1.Width;
            bunifuSeparator1.Left = tab1.Left;

            //show imports UI with custom list
            TabSwitcher(ImportsData.Instance);
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab2.Width;
            bunifuSeparator1.Left = tab2.Left;

            //show students data UI
            TabSwitcher(StudentsData.Instance);
        }

        private void tab3_Click(object sender, EventArgs e)
        {
            //UI code
            bunifuSeparator1.Width = tab3.Width;
            bunifuSeparator1.Left = tab3.Left;

            //TODO charts baby
            TabSwitcher(Charts.Instance);

            //refresh chart
            Charts c = Charts.Instance;
            c.Global_Charts_Load();
        }

        private void SetToolTip(Control ctl)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.UseFading = true;
            toolTip1.UseAnimation = true;
            //toolTip1.IsBalloon = true;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(ctl, "Number of Students");
        }
        private void NewImportsUI_Load(object sender, EventArgs e)
        {
            //UI code
            lblDateNow.Text = DateTime.Now.ToString("dd MMM yyy");
            lblDateDay.Text = DateTime.Now.DayOfWeek.ToString();
            SetToolTip(lblStudentCount);
            SetToolTip(pictureBox1);
            //explicit tab1 click at load
            tab1_Click(sender, e);
        }

        private string FileSizeToString(long x)
        {
            long size = (long)x;
            int[] limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
            string[] units = new string[] { "GB", "MB", "KB" };

            for (int i = 0; i < limits.Length; i++)
            {
                if (size >= limits[i])
                    return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
            }
            return String.Format("{0} bytes", size);
        }

        DataSet results;
        private void ImportFunc()
        {
            StudentImport studentImport = new StudentImport();

            using (OpenFileDialog ofd = new OpenFileDialog()
            { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003 |*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = null;
                    try
                    {
                        fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);

                        //save data students imports
                        studentImport.Size = FileSizeToString(fs.Length);
                        studentImport.FileLocation = new FileInfo(ofd.FileName).ToString();
                        studentImport.TimeStamp = DateTime.Now;
                        studentImport.Status = 1;
                        studentImport.Title = $"Student-Import_{studentImport.TimeStamp.Year}{studentImport.TimeStamp.Month}{studentImport.TimeStamp.Day}_{studentImport.TimeStamp.Hour}{studentImport.TimeStamp.Minute}";//Student-Import_20171110_0900
                    }
                    catch (IOException)
                    {
                        MetroMessageBox.Show(this, "File is open in another program", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    IExcelDataReader reader;

                    if (ofd.FilterIndex == 1)
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(fs);

                    }
                    else
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    }


                    results = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {

                        // Gets or sets a value indicating whether to set the DataColumn.DataType 
                        // property in a second pass.
                        UseColumnDataType = false,

                        // Gets or sets a callback to obtain configuration options for a DataTable. 
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {

                            // Gets or sets a value indicating the prefix of generated column names.
                            EmptyColumnNamePrefix = "Column",

                            // Gets or sets a value indicating whether to use a row from the 
                            // data as column names.
                            UseHeaderRow = true,

                            // Gets or sets a callback to determine which row is the header row. 
                            // Only called when UseHeaderRow = true.
                            ReadHeaderRow = (rowReader) =>
                            {
                                // F.ex skip the first row and use the 2nd row as column headers:
                                rowReader.Read();
                            },

                            // Gets or sets a callback to determine whether to include the 
                            // current row in the DataTable.
                            FilterRow = (rowReader) =>
                            {
                                return true;
                            },

                        }
                    });
                    reader.Close();
                }

            }

            if (results != null)
            {

                DataSet tablesDataset = results;
                DataTable dataTable = results.Tables[0];

                FrmImportedData frm = new FrmImportedData(dataTable, tablesDataset);
                frm.ShowDialog();

                if (frm.MyDialogueResult)
                {
                    //save data students imports
                    try
                    {
                        using (var context = new EschoolEntities())
                        {
                            context.StudentImports.Add(studentImport);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    //TODO refresh grid
                    ImportsData imp = ImportsData.Instance;
                    imp.LoadListAsync();
                }
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            //TODO launch the import func/dialogue
            ImportFunc();
            //update the ImportsData and students records
            StudentsData studData = StudentsData.Instance;
            studData.GridInitilizer();
            tab2_Click(sender, e);
        }
        private void btnGetTempate_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Excel Template|*.xltx",
                ValidateNames = true,
                FileName = "eSchoolTemplate",
                OverwritePrompt = true,
                Title = "Save eschool Template"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(sfd.FileName, eSchoolResources.eschool_students);

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }       

    }
}
