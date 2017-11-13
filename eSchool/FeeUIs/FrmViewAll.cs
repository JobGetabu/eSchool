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
    public partial class FrmViewAll : Form
    {
        public FrmViewAll()
        {
            InitializeComponent();
        }

        private void FrmViewAll_Load(object sender, EventArgs e)
        {
            GridInitilizer();
        }

        //More efficient grid initilizer
        private async void GridInitilizer()
        {
            this.bGrid.Rows.Clear();

            var categoryListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                }
            });

            foreach (var cat in categoryListAsync)
            {
                this.bGrid.Rows.Add(new string[]
                {
                        null,
                        cat.OverHead,
                        null
                });
            }
        }
        private void bGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.bGrid.Rows[e.RowIndex].Cells[0].Value = GridIcon.Grid_View_50px;
            this.bGrid.Rows[e.RowIndex].Cells[2].Value = GridIcon.Trash_Can_50px;
        }

        private async void bGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    if ((await GridDelImageAsync(e.RowIndex))!=null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                context.Entry<OverHeadCategory>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                context.SaveChanges();

                                //TODO short Custom Notification
                                bGrid.Rows[e.RowIndex].Visible = false;

                                //update the all lists
                                FeeUI_List ful = FeeUI_List.Instance;
                                ful.GridInitilizer();
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
        private async Task<OverHeadCategory> GridDelImageAsync(int rowIndex)
        {
            List<OverHeadCategory> overHeadList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                }
            });

            string name;
            name = (string)this.bGrid.Rows[rowIndex].Cells[1].Value;

                foreach (var fi in overHeadList)
                {
                    if (fi.OverHead.Equals(name))
                    {
                        return fi;
                    }
                }
            return null;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
            FrmAddFeeCategory frm = new FrmAddFeeCategory();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                //logic
            }
            //refresh listcontrol
            GridInitilizer();
            FeeUI_List ful = FeeUI_List.Instance;
            ful.GridInitilizer();
        }

        private void FrmViewAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            // refresh all lists
            FeeUI_Show fuui = FeeUI_Show.Instance;
            fuui.OlistControlInitAsync();
            FeeUI_List ful = FeeUI_List.Instance;
            ful.GridInitilizer();
        }
    }
}
