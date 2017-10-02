using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace eSchool
{
    public partial class ImportsUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static ImportsUI _instance;
        private int rowIndex;

        public static ImportsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportsUI();
                }
                return _instance;
            }
        }
        public ImportsUI()
        {
            InitializeComponent();
        }

        private void ImportsUI_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                studentBasicBindingSource.DataSource = context.Student_Basic.OrderBy(s => s.Admin_No).ToList();

            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuBtnAddNew_Click(object sender, EventArgs e)
        {
            FrmAddStudent frm = new FrmAddStudent();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //logic
                using (var context = new EschoolEntities())
                {
                    studentBasicBindingSource.DataSource = context.Student_Basic.OrderBy(s => s.Admin_No).ToList();
                }
            }
        }

        private void bunifuBtnEdit_Click(object sender, EventArgs e)
        {
            if (studentBasicBindingSource.Current == null)
            {
                return;
            }
            Student_Basic obj = studentBasicBindingSource.Current as Student_Basic;
            FrmAddStudent frm = new FrmAddStudent(obj);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //logic
            }
        }

        private void bunifuCustomDataGrid2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            #region stackoverflow
            //if (e.RowIndex < 0) return;                  // no image in the header
            //if (e.ColumnIndex == bunifuCustomDataGrid1.Columns[8].Index)
            //{
            //    e.PaintBackground(e.ClipBounds, false);  // no highlighting
            //    e.PaintContent(e.ClipBounds);
            //    Font n = new Font(FontFamily.GenericSerif, 10f);
            //    Brush b = Brushes.Red;
            //    // calculate the location of your text..:
            //    int y = e.CellBounds.Bottom - 35;         // your  font height
            //    e.Graphics.DrawString("Delete", n, b, e.CellBounds.Left, y);
            //    // maybe draw more text with other fonts etc..

            //    e.Handled = true;

            //    // add space for two lines:
            //    bunifuCustomDataGrid1.Rows[0].Height = ((Image)bunifuCustomDataGrid1[0, 0].Value).Height + 35;
            //    // if the previous line throws an error..
            //    // .. because you didn't put a 'real image' into the cell try this:
            //    // dataGridView1.Rows[0].Height = 
            //    // ((Image)bunifuCustomDataGrid1[0, 0].FormattedValue).Height + 35;

            //    // align the image top left:
            //    bunifuCustomDataGrid1[0, 0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            #endregion
        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.bunifuCustomDataGridStudentRecords.Rows[e.RowIndex].Selected = true;
            //this.rowIndex = e.RowIndex;
            //this.bunifuCustomDataGridStudentRecords.CurrentCell = this.bunifuCustomDataGridStudentRecords.Rows[e.RowIndex].Cells[1];

            //if (!bunifuCustomDataGridStudentRecords.Rows[rowIndex].IsNewRow)
            //{
            //    bunifuCustomDataGridStudentRecords.Rows.RemoveAt(rowIndex);
            //}

            //locate only delete cell
        }

        DataSet results;
        private void bunifuFlBtnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003 |*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader;

                    if (ofd.FilterIndex==1)
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(fs);               
                       
                    }
                    else
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    }


                    results = reader.AsDataSet(new ExcelDataSetConfiguration() {

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
                            ReadHeaderRow = (rowReader) => {
                                // F.ex skip the first row and use the 2nd row as column headers:
                                rowReader.Read();
                            },

                            // Gets or sets a callback to determine whether to include the 
                            // current row in the DataTable.
                            FilterRow = (rowReader) => {
                                return true;
                            },
                           
                       }                    
                   });
                    reader.Close();
                }
            }

            DataSet tablesDataset = results;
            DataTable dataTable = results.Tables[0];

            FrmImportedData frm = new FrmImportedData(dataTable, tablesDataset);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //logic
            }
        }
    }
}