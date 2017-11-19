using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.Dash
{

    public partial class TransOverview : UserControl
    {
        //Singleton pattern ***best practices***
        private static TransOverview _instance;
        public static TransOverview Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TransOverview();
                }
                return _instance;
            }
        }
        public TransOverview()
        {
            InitializeComponent();
        }

        int GTerm = Properties.Settings.Default.CurrentTerm;
        int GYear = Properties.Settings.Default.CurrentYear;
        private void TransOverview_Load(object sender, EventArgs e)
        {
            TransListAsync();
        }

        private async void TransListAsync()
        {
            var transListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Transations
                    .Where(t => t.Term == GTerm & t.Year == GYear)
                    .ToList();
                }
            });

            lblTrans.Text = (transListAsync.Count() + 1).ToString();
        }
    }
}
