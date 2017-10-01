using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;
using MetroFramework;

namespace eSchool
{
    public partial class SettingsUI : UserControl
    {
        //Singleton pattern ***best practices***
        private static SettingsUI _instance;

        private EschoolEntities db;
        public static SettingsUI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SettingsUI();
                }
                return _instance;
            }
        }
        public SettingsUI()
        {
            
                InitializeComponent();
        }

        IPagedList<Category> catList;
        
        int pageNumber = 1;
        private int rowIndex;


        //Not used anymore
        public  async Task<IPagedList<Category>> GetPagedCategoryList(int pageNumber=1,int pageSize = 10)
        {
            return await Task.Factory.StartNew(() => 
            {
                //HACK 1 get this list to populate the grid or hack grid methods
                //slowing the program
                 //var sList= db.Categories.OrderBy(c => c.Id)
                 //                   .Select((d) => new
                 //                   {
                 //                       d.Type,
                 //                       d.CategoryName
                 //                   }).ToPagedList(pageNumber,pageSize);
                                   
                 return db.Categories.OrderBy(c => c.Id).ToPagedList(pageNumber, pageSize);
            });
        }

        public static int CurrentYear { get; set; }
        public async void SettingsUI_Load(object sender, EventArgs e)
        {
            db = new EschoolEntities();

            categoryBindingSource.DataSource = await CategoryDataSourceAsync();
           


            //Settings preferences
            lblCurrentTerm.Text = Properties.Settings.Default.CurrentTerm.ToString();
            lblFinancialYear.Text = DateTime.Now.Year.ToString();
            //save static value
            CurrentYear = int.Parse(lblFinancialYear.Text);
            metroTextBxEditTerm.Text = lblCurrentTerm.Text;
        }

        //async datasource
        public async Task<List<Category>> CategoryDataSourceAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                return db.Categories.OrderBy(c => c.Id).ToList();
            });
        }
        private async void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            FrmAddCategories frm = new FrmAddCategories();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);

            //refresh list
            //catList = await GetPagedCategoryList(pageNumber);
            //this.bunifuCustomDataGrid1.DataSource = catList.ToList();
            //bunifuCustomDataGrid1.Columns[0].DataPropertyName = 

            categoryBindingSource.DataSource = await CategoryDataSourceAsync();
            bunifuCustomDataGrid1.Update();
            bunifuCustomDataGrid1.Refresh();
        }

        

        
        //static async void  GridGenerator()
        //{
        //    catList = await GetPagedCategoryList(Instance.pageNumber);
        //    int n = 0;
        //    Instance.btnHasNext.Visible = catList.HasNextPage;
        //    Instance.btnHasPrevious.Visible = catList.HasPreviousPage;

        //    catList.Count();
        //    MyClass cmplxType = new MyClass();
        //    foreach (var category in catList)
        //    {
        //        n = Instance.bunifuCustomDataGrid1.Rows.Add();

        //        //Instance.bunifuCustomDataGrid1.Rows[n].Cells[0].Value = category.Type;
        //        //Instance.bunifuCustomDataGrid1.Rows[n].Cells[1].Value = category.CategoryName;
        //        Instance.btnDel.Text = "Delete";
        //        Instance.btnDel.UseColumnTextForButtonValue = true;

        //        cmplxType.catType = category.Type;
        //        cmplxType.catName = category.CategoryName;
        //        cmplxType.delBtn =Instance.btnDel;
        //        cmplxType.cmplxList.Add(cmplxType);
        //    }
        //    Instance.bunifuCustomDataGrid1.DataSource = cmplxType.cmplxList.ToList();
        //}

        

        private async void btnHasPrevious_Click(object sender, EventArgs e)
        {
            if (btnHasPrevious.Visible)
            {
                catList = await GetPagedCategoryList(--pageNumber);
                this.bunifuCustomDataGrid1.DataSource = catList.ToList();
            }
        }

        private async void btnHasNext_Click(object sender, EventArgs e)
        {
            if (btnHasNext.Visible)
            {
                catList = await GetPagedCategoryList(++pageNumber);
                this.bunifuCustomDataGrid1.DataSource = catList.ToList();
            }
        }


        private void bunifuCustomDataGrid1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                this.bunifuCustomDataGrid1.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.bunifuCustomDataGrid1.CurrentCell = this.bunifuCustomDataGrid1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.bunifuCustomDataGrid1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }        
        }

        //returns a asynchrounous query of category Ids
        //not used

        public async Task<bool> IsIdDuplicateuplicate(int searchItemID)
        {
            bool duplicate = false;
            await Task.Factory.StartNew(() =>
            {
                var query = db.Categories.Select(c => c.Id).ToList();

                foreach (var catID in  query)
                {
                    if (searchItemID == catID)
                    {
                        duplicate = true;
                        return duplicate;
                    }
                }
                return duplicate;
            });
            return duplicate;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.bunifuCustomDataGrid1.Rows[this.rowIndex].IsNewRow)
            {
                //int catId = (int)this.bunifuCustomDataGrid1.Rows[this.rowIndex].Cells[0].Value;   
                if ((MetroMessageBox.Show(this, "Delete this category?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK))
                {
                    db.Categories.Remove(this.bunifuCustomDataGrid1.Rows[this.rowIndex].DataBoundItem as Category);
                    db.SaveChanges();
                    //notify success delete
                    this.bunifuCustomDataGrid1.Rows.RemoveAt(this.rowIndex);
                }                          
            }
        }

        private void bunifuFlatBtnSave_Click(object sender, EventArgs e)
        {           
            int t;           
            if (int.TryParse(metroTextBxEditTerm.Text, out t))
            {
                Properties.Settings.Default.CurrentTerm = t;
                Properties.Settings.Default.Save();
                //TODO 1 display notification
            }
            //reflects changes made at scope level
            lblCurrentTerm.Text = Properties.Settings.Default.CurrentTerm.ToString();
        }

        //TODO 1 set up UI for fee structure reporting
        //TODO 2 set up UI for fee receipt reporting
        //TODO 2 Delete all transaction 
        //TODO 2 promote students

    }
}
