using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.SearchCriteria
{
    public partial class FrmStudentSearch : Form
    {

        string tbSearch;
        public FrmStudentSearch(string tbSearch)
        {
            InitializeComponent();

            this.tbSearch = tbSearch;
        }

        private void FrmStudentSearch_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmStudentSearch_Load(object sender, EventArgs e)
        {
            GridInitilizer(tbSearch);
        }

        private async void GridInitilizer(string textSearch)
        {
            var studentListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Student_Basic
                    .OrderBy(c => c.Admin_No)
                    .ToList();
                }
            });

            // MetroFramework.Controls.MetroTextBox tbSearch = Frm_Home.Instance.tbSearch;
            gData.Rows.Clear();
            var filList = studentListAsync.Where(s =>
                  // Regex.IsMatch(s.Admin_No.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.First_Name.ToString(), textSearch, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Middle_Name.ToString(), textSearch, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Last_Name.ToString(), textSearch, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Class.ToString(), textSearch, RegexOptions.IgnoreCase) ||
                  // Regex.IsMatch(s.ModeOfLearning.ToString(), tbSearch.Text, RegexOptions.IgnoreCase) ||
                  Regex.IsMatch(s.Form.ToString(), textSearch, RegexOptions.IgnoreCase))
                 .OrderBy(t => t.Admin_No)
                 .ToList();

            foreach (var cat in filList)
            {
                gData.Rows.Add(new string[]
                {
                        cat.Admin_No.ToString(),
                        $"{cat.First_Name} {cat.Middle_Name} {cat.Last_Name}",
                        cat.Form.ToString(),
                        cat.Class,
                });
            }
        }

    }
}
