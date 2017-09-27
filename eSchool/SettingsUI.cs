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

        //TODO 1 Do we need IPaged here really?
        public async Task<IPagedList<Category>> GetPagedCategoryList(int pageNumber=1,int pageSize = 9)
        {
            return await Task.Factory.StartNew(() => 
            {
               return db.Categories.OrderBy(c => c.Id).ToPagedList(pageNumber, pageSize);
            });
        }
        private async void SettingsUI_Load(object sender, EventArgs e)
        {
            db = new EschoolEntities();
            catList = await GetPagedCategoryList(pageNumber);

            //specify data as it gets in
            this.bunifuCustomDataGrid1.DataSource = catList.ToList();
        }

        private async void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            FrmAddCategories frm = new FrmAddCategories();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);

            //refresh list
            catList = await GetPagedCategoryList(pageNumber);
            this.bunifuCustomDataGrid1.DataSource = catList.ToList();
            //bunifuCustomDataGrid1.Columns["Type"].DataPropertyName = catList.w
        }
    }
}
