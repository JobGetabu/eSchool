using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool
{
    public partial class Form1 : Form
    {
        EschoolEntities db;
        public Form1()
        {
            InitializeComponent();

            db = new EschoolEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new EschoolEntities())
            {
                foreach (var t in context.SchoolPeriodTerms.ToList())
                {
                    t.Term.ToString();
                }

                comboBox1.DataSource = context.SchoolPeriodTerms.ToList();
                comboBox1.DisplayMember = "Term";
                comboBox1.ValueMember = "Term";
            }

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
