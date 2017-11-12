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
    public partial class ImportsData : UserControl
    {

        private static ImportsData _instance;
        public static ImportsData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportsData();
                }
                return _instance;
            }
        }
        public ImportsData()
        {
            InitializeComponent();
        }

        private void ImportsData_Load(object sender, EventArgs e)
        {
            //Load the custom list
            LoadListAsync();
        }

        public async void LoadListAsync()
        {
            var studentImportListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.StudentImports.OrderBy(c => c.Id)
                    .ToList();
                }
            });

            listControl1.Clear();
            foreach (var fs in studentImportListAsync)
            {
                listControl1.Add(fs.Title, fs.Size, fs.TimeStamp.ToString(), true, fs.FileLocation);
            }

            NewImportsUI nUI = NewImportsUI.Instance;
            nUI.lblStudentCount.Text = (await StudentListAsync()).Count.ToString();
        }
        private async Task<List<Student_Basic>> StudentListAsync()
        {
            return await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Student_Basic.OrderBy(c => c.Admin_No).ToList();
                }
            });
        }
    }
}
