using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using custom_alert_notifications;
using eSchool.MyPrints;
using eSchool.MyPrints2;

namespace eSchool
{
    public partial class FeeUI_Show : UserControl
    {

        //Singleton pattern ***best practices***
        private static FeeUI_Show _instance;
        public static FeeUI_Show Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FeeUI_Show();
                }
                return _instance;
            }
        }
        public FeeUI_Show()
        {
            InitializeComponent();
        }

        private void FeeUI_Show_Load(object sender, EventArgs e)
        {
            //loading comboBox
            FeesStructure fs = FeesStructure.Instance;
            string[] n = { };
            fs.bMenu.Items = n;
            fs.bMenu.AddItem("Print"); //No print at this point
            fs.bMenu.AddItem("New Fee Structure");

            bGrid.Rows.Clear();
            this.btnSaveStructure.Visible = true;
            OlistControlInitAsync();
        }

        private void bThinBtnAddFeeItem_Click(object sender, EventArgs e)
        {
            FrmAddFeeCategory frm = new FrmAddFeeCategory();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                //logic
            }
            //refresh listcontrol
            OlistControlInitAsync();
        }

        public async void OlistControlInitAsync()
        {
            var overHeadListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.OverHeadCategories.OrderBy(c => c.Id).ToList();
                }
            });
            listControl1.Clear();
            foreach (var ol in overHeadListAsync)
            {
                listControl1.Add(ol.OverHead);
            }
        }

        private void bGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.bGrid.Rows[e.RowIndex].Cells[0].Value = GridIcon.Grid_View_50px;
            this.bGrid.Rows[e.RowIndex].Cells[3].Value = GridIcon.Trash_Can_50px;
        }

        public List<AnnualFeeStructure> SelectedOverHeads(List<OverHeadCategoryPerYear> ovfeestructureListAsync, int selYear, int selform, int selTerm)
        {
            List<AnnualFeeStructure> feestructureList = new List<AnnualFeeStructure>();

            foreach (var ov in ovfeestructureListAsync)
            {
                AnnualFeeStructure afs = new AnnualFeeStructure();
                afs.overHeadName = ov.Category;
                afs.costCurrent = ov.Amount;

                afs.costTerm1 = 0;
                afs.costTerm2 = 0;
                afs.costTerm3 = 0;               

                feestructureList.Add(afs);
            }
            return feestructureList;
        }
        public async void btnSaveStructure_Click(object sender, EventArgs e)
        {
            //TODO 2 prompt to print fee structure           

            #region autoGen is true
            List<OverHeadCategoryPerYear> myOvList1 = new List<OverHeadCategoryPerYear>();
            if (FeesUI.autoGen)
            {
                string frmslbl = "Form ";

                //Add new ov before delete
                myOvList1 = AddExistToNewFrptsAndGfs(FeesUI.autoSelTerm, FeesUI.autoSelYear, FeesUI.autoFilterListOfForms);
                //Making sure method runs here;
                int s = myOvList1.Count();

                ///Delete preexisting data of the same kind we are saving
                foreach (var fm in FeesUI.autoFilterListOfForms)
                {
                    DeleteExistFrptsAndGfs(FeesUI.autoSelTerm, FeesUI.autoSelYear, fm);
                    frmslbl += " " + fm.ToString();
                }
                //change label
                FeesStructure feeIns = FeesStructure.Instance;
                feeIns.lblYFeeStructure.Text = FeesUI.autoSelYear + " Fee Structure ";


                feeIns.lblFFeeStructure.Text = frmslbl;
                feeIns.lblTFeeStructure.Text = "Term " + FeesUI.autoSelTerm;
                feeIns.lblTotalFeeStructure.Text = "";

                string title = $"{FeesUI.autoSelYear} {frmslbl}";
                string tmTitle = $"Term {FeesUI.autoSelTerm}";
                decimal updateTotal = EditedAutoGenFsCash(FeesUI.autoSelTerm, FeesUI.autoSelYear, FeesUI.autoFilterListOfForms[0]);
                string totalCash = $"KES {String.Format("{0:0,0}", updateTotal)}";
                using (var context = new EschoolEntities())
                {
                    GroupedFeeStructure gp = new GroupedFeeStructure()
                    {
                        YearTitle = title,
                        TermTitle = tmTitle,
                        TotalTitle = totalCash,
                        TotalFee = updateTotal,
                        selTerm = FeesUI.autoSelTerm,
                        selYear = FeesUI.autoSelYear
                    };
                    foreach (var fm in FeesUI.autoFilterListOfForms)
                    {
                        if (fm == 1)
                        {
                            gp.selFm1 = 1; //true
                        }
                        if (fm == 2)
                        {
                            gp.selFm2 = 2; //true
                        }
                        if (fm == 3)
                        {
                            gp.selFm3 = 3; //true
                        }
                        if (fm == 4)
                        {
                            gp.selFm4 = 4; //true
                        }
                    }

                    context.GroupedFeeStructures.Add(gp);
                    context.SaveChanges();

                    foreach (var fm in FeesUI.autoFilterListOfForms)
                    {
                        ModiFyOverHeads(gp.Id, fm, FeesUI.autoSelTerm, FeesUI.autoSelYear, context, myOvList1);
                    }
                    context.SaveChanges();

                    //update changes
                    updateTotal = EditedAutoGenFsCash(FeesUI.autoSelTerm, FeesUI.autoSelYear, FeesUI.autoFilterListOfForms[0]);
                    totalCash = $"KES {String.Format("{0:0,0}", updateTotal)}";

                    gp.TotalFee = updateTotal;
                    gp.TotalTitle = totalCash;


                    foreach (var fm in FeesUI.autoFilterListOfForms)
                    {
                        FeesRequiredPerTerm frpt = new FeesRequiredPerTerm()
                        {
                            Form = fm,
                            Term = FeesUI.autoSelTerm,
                            FeeRequired = updateTotal,
                            Year = FeesUI.autoSelYear,
                            GrpFeestructure_Id = gp.Id
                        };
                        context.FeesRequiredPerTerms.Add(frpt);
                    }


                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "Modifying Multiple overheads & saving frpt");
                        throw;
                    }



                }

                FeesStructure fss = FeesStructure.Instance;

                if ((MetroMessageBox.Show(this, $"{title} has been saved for {tmTitle} \n Total fee for {tmTitle} is {totalCash} \n Do you wish to print the Fee Structure ?", "Print Fee Structure", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
                {
                    //alert.Show("Generating Document !", alert.AlertType.success);
                    int fm = FeesUI.autoFilterListOfForms[0];
                    var feestructureListAsync = await Task.Factory.StartNew(() =>
                    {
                        using (var context = new EschoolEntities())
                        {
                            return context.OverHeadCategoryPerYears
                                               .OrderBy(c => c.Id)
                                               .Where(c => c.Year == FeesUI.autoSelYear & c.Form == fm
                                                & c.Term == FeesUI.autoSelTerm)
                                               .ToList();
                        }
                    });

                   
                    List<AnnualFeeStructure> feestructureList = SelectedOverHeads(feestructureListAsync, FeesUI.autoSelYear, fm, FeesUI.autoSelTerm);

                    string lbl = $"{title} Term {FeesUI.autoSelTerm} Fees Structure"; //2017 Form Four Fees Structure

                    FrmTermFsReport frm = new FrmTermFsReport(lbl, feestructureList);
                    frm.ShowDialog();

                }
                this.btnSaveStructure.Visible = false;
                //switch tabs to feeS list
                //refresh the list

                fss.SwitchTabExt();
                FeeUI_List ful = FeeUI_List.Instance;
                ful.LoadListAsync(FeesUI.autoSelYear);

            }
            #endregion
            #region autogen is false
            else
            {
                List<OverHeadCategoryPerYear> myOvList2 = new List<OverHeadCategoryPerYear>();

                //Add new ov before delete
                myOvList2 = AddExistToNewFrptsAndGfs(OverHeadListItem.selTerm, OverHeadListItem.selYear, OverHeadListItem.filterListOfForms);
                //Making sure method runs here;
                int s = myOvList2.Count();

                ///Delete preexisting data of the same kind we are saving
                foreach (var fm in OverHeadListItem.filterListOfForms)
                {
                    DeleteExistFrptsAndGfs(OverHeadListItem.selTerm, OverHeadListItem.selYear, fm);
                }

                string title = $"{OverHeadListItem.selYear} {FrmCreateFStruct.frmslbl}";
                string tmTitle = $"Term {OverHeadListItem.selTerm}";
                string totalCash = $"KES {String.Format("{0:0,0}", OverHeadListItem.totalCashPas)}";

                using (var context = new EschoolEntities())
                {
                    GroupedFeeStructure gp = new GroupedFeeStructure()
                    {
                        YearTitle = title,
                        TermTitle = tmTitle,
                        TotalTitle = totalCash,
                        TotalFee = OverHeadListItem.totalCashPas,
                        selTerm = OverHeadListItem.selTerm,
                        selYear = OverHeadListItem.selYear
                    };
                    foreach (var fm in FeesUI.filterListOfForms)
                    {
                        if (fm == 1)
                        {
                            gp.selFm1 = 1; //true
                        }
                        if (fm == 2)
                        {
                            gp.selFm2 = 2; //true
                        }
                        if (fm == 3)
                        {
                            gp.selFm3 = 3; //true
                        }
                        if (fm == 4)
                        {
                            gp.selFm4 = 4; //true
                        }
                    }

                    context.GroupedFeeStructures.Add(gp);
                    context.SaveChanges();

                    foreach (var fm in FeesUI.filterListOfForms)
                    {
                        ModiFyOverHeads(gp.Id, fm, FeesUI.autoSelTerm, FeesUI.autoSelYear, context, myOvList1);
                    }
                    context.SaveChanges();


                    foreach (var fm in FeesUI.filterListOfForms)
                    {
                        FeesRequiredPerTerm frpt = new FeesRequiredPerTerm()
                        {
                            Form = fm,
                            Term = OverHeadListItem.selTerm,
                            FeeRequired = OverHeadListItem.totalCashPas,
                            Year = OverHeadListItem.selYear,
                            GrpFeestructure_Id = gp.Id
                        };
                        context.FeesRequiredPerTerms.Add(frpt);

                        ModiFyOverHeads(gp.Id, fm, OverHeadListItem.selTerm, OverHeadListItem.selYear, context, myOvList2);
                    }

                    context.SaveChanges();
                }

                FeesStructure fss = FeesStructure.Instance;

                if ((MetroMessageBox.Show(this, $"{title} has been saved for {tmTitle} \n Total fee for {tmTitle} is {totalCash} \n Do you wish to print the Fee Structure ?", "Print Fee Structure", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
                {
                    //print fee structure

                    if ((MetroMessageBox.Show(this, $"{title} has been saved for {tmTitle} \n Total fee for {tmTitle} is {totalCash} \n Do you wish to print the Fee Structure ?", "Print Fee Structure", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
                    {
                        // print fee structure
                        //alert.Show("Generating Document !", alert.AlertType.success);
                        int fm = OverHeadListItem.filterListOfForms[0];
                        var feestructureListAsync = await Task.Factory.StartNew(() =>
                        {
                            using (var context = new EschoolEntities())
                            {
                                return context.OverHeadCategoryPerYears
                                                   .OrderBy(c => c.Id)
                                                   .Where(c => c.Year == OverHeadListItem.selYear
                                                   & c.Form == fm
                                                    & c.Term == OverHeadListItem.selTerm)
                                                   .ToList();
                            }
                        });

                        List<AnnualFeeStructure> feestructureList = SelectedOverHeads(feestructureListAsync, OverHeadListItem.selYear, fm, OverHeadListItem.selTerm);

                        string lbl = $"{title} Term {OverHeadListItem.selTerm} Fees Structure"; //2017 Form Four Fees Structure

                        FrmTermFsReport frm = new FrmTermFsReport(lbl, feestructureList);
                        frm.ShowDialog();
                    }
                    this.btnSaveStructure.Visible = false;

                    //switch tabs to feeS list
                    //refresh the list

                    fss.SwitchTabExt();
                    FeeUI_List ful = FeeUI_List.Instance;
                    ful.LoadListAsync(OverHeadListItem.selYear);
                }
                #endregion

                //referesh the progress bars
                FeePayment fp = FeePayment.Instance;
                fp.Copy_FeePayment_Load();


            }

        }

        private async void bGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            bool deleted = false;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    using (var context = new EschoolEntities())
                    {
                        if (FeesUI.autoGen)
                        {
                            for (int i = 0; i < FeesUI.autoFilterListOfForms.Count; i++)
                            {
                                if (GridDelImageAsync(e.RowIndex) != null)
                                {
                                    try
                                    {
                                        context.Entry<OverHeadCategoryPerYear>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                        context.SaveChanges();
                                        //enable save btn visible
                                        btnSaveStructure.Visible = true;
                                        deleted = true;
                                    }
                                    catch (Exception exp)
                                    {
                                        MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");

                                    }
                                }
                            }
                            if (deleted)
                            {
                                alert.Show("Deleted", alert.AlertType.warnig);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < FeesUI.filterListOfForms.Count; i++)
                            {
                                if (GridDelImageAsync(e.RowIndex) != null)
                                {
                                    try
                                    {
                                        context.Entry<OverHeadCategoryPerYear>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                        context.SaveChanges();
                                    }
                                    catch (Exception exp)
                                    {
                                        MessageBox.Show("Something went wrong" + exp.Message, "Unsuccessful");

                                    }
                                }
                            }
                        }
                        // custom notification 
                        alert.Show("Deleted", alert.AlertType.warnig);
                        bGrid.Rows[e.RowIndex].Visible = false;
                        if (FeesUI.autoGen)
                        {
                            //call the GridInit to update
                            OverHeadListItem d = new OverHeadListItem();
                            d.GridData(FeesUI.autoFilterListOfForms, FeesUI.autoSelTerm, FeesUI.autoSelYear);
                        }
                        else
                        {
                            //call the GridInit to update
                            OverHeadListItem d = new OverHeadListItem();
                            d.GridData(FeesUI.filterListOfForms, FeesUI.selTerm, FeesUI.selYear);
                        }
                    }
                }
            }
        }

        private async Task<OverHeadCategoryPerYear> GridDelImageAsync(int rowIndex)
        {
            //call the GridDataPass to update list
            OverHeadListItem c = new OverHeadListItem();
            List<OverHeadCategoryPerYear> overHeadPYList = null;
            if (FeesUI.autoGen)
            {
                overHeadPYList = await c.GridDataPass(FeesUI.autoFilterListOfForms, FeesUI.autoSelTerm, FeesUI.autoSelYear);
            }
            else
            {

                overHeadPYList = await c.GridDataPass(FeesUI.filterListOfForms, FeesUI.selTerm, FeesUI.selYear);
            }

            string name;
            name = (string)this.bGrid.Rows[rowIndex].Cells[1].Value;
            if (overHeadPYList != null)
            {
                foreach (var fi in overHeadPYList)
                {
                    if (fi.Category.Equals(name))
                    {
                        return fi;
                    }
                }
            }
            return null;
        }

        private List<OverHeadCategoryPerYear> AddExistToNewFrptsAndGfs(int term, int year, List<int> forms)
        {
            List<OverHeadCategoryPerYear> theList = new List<OverHeadCategoryPerYear>();

            using (var context = new EschoolEntities())
            {
                var form = forms[0];
                var gpFs = context.GroupedFeeStructures
                .Where(c => c.selFm1 == form | c.selFm2 == form | c.selFm3 == form | c.selFm4 == form)
                .ToList();
                if (gpFs != null)
                {

                    GroupedFeeStructure gpfitem = gpFs.Where(c => c.selYear == year & c.selTerm == term)
                        .FirstOrDefault();
                    if (gpfitem != null)
                    {
                        var xyzList = ReturnOvPerYear(forms, term, year, gpfitem.Id, context);
                        foreach (var xyz in xyzList)
                        {
                            OverHeadCategoryPerYear ov = new OverHeadCategoryPerYear()
                            {
                                Amount = xyz.Amount,
                                Form = xyz.Form,
                                Category = xyz.Category,
                                Term = xyz.Term,
                                Year = xyz.Year,
                            };
                            theList.Add(ov);
                        }
                    }
                }
            }
            return theList;
        }

        private List<OverHeadCategoryPerYear> ReturnOvPerYear(List<int> forms, int term, int year, int fkGrpFeeStruct, EschoolEntities context)
        {
            return context.OverHeadCategoryPerYears
                    .Where(x => x.Term == term & x.Year == year & x.GrpFeeStructureId_Fk == fkGrpFeeStruct)
                    .ToList();
        }
        private void DeleteExistFrptsAndGfs(int term, int year, int form)
        {
            using (var context = new EschoolEntities())
            {
                //var fRPTerms= context.FeesRequiredPerTerms
                //.Where(c => c.Form == form & c.Year == year & c.Term == term)
                //.ToList();

                //foreach (FeesRequiredPerTerm fitem in fRPTerms)
                //{
                //    context.Entry<FeesRequiredPerTerm>(fitem).State = EntityState.Deleted;
                //    context.SaveChanges();
                //}

                var gpFs = context.GroupedFeeStructures
               .Where(c => c.selFm1 == form | c.selFm2 == form | c.selFm3 == form | c.selFm4 == form)
               .ToList();

                foreach (GroupedFeeStructure gpfitem in gpFs.Where(c => c.selYear == year & c.selTerm == term))
                {
                    context.Entry<GroupedFeeStructure>(gpfitem).State = EntityState.Deleted;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "Deleting Multiple GpF & Frpts");
                        //throw;
                    }
                }
            }
        }

        private void ModiFyOverHeads(int gprId, int form, int term, int year, EschoolEntities context, List<OverHeadCategoryPerYear> myOverhList)
        {
            var ovHCpyList = context.OverHeadCategoryPerYears
              .Where(c => c.Form == form & c.Term == term & c.Year == year)
              .ToList();

            foreach (var ov in ovHCpyList)
            {
                ov.GrpFeeStructureId_Fk = gprId;
                context.Entry<OverHeadCategoryPerYear>(ov).State = EntityState.Modified;
            }
            foreach (OverHeadCategoryPerYear ov in myOverhList)
            {
                ov.GrpFeeStructureId_Fk = gprId;
                context.OverHeadCategoryPerYears.Add(ov);
            }
        }

        /// <summary>
        /// This method fetches the updated total for fs if any changes are there
        /// </summary>
        /// <param name="term"></param>
        /// <param name="year"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        private decimal EditedAutoGenFsCash(int term, int year, int form)
        {
            decimal total = 0;
            using (var context = new EschoolEntities())
            {
                var oHCPY = context.OverHeadCategoryPerYears
                .Where(c => c.Form == form & c.Year == year & c.Term == term)
                .ToList();

                foreach (OverHeadCategoryPerYear fitem in oHCPY)
                {
                    total += fitem.Amount;
                }
            }
            return total;
        }

        public void SetTotalsLabel()
        {
            //change label
            FeesStructure feeIns = FeesStructure.Instance;
            if (FeesUI.autoGen)
            {
                decimal updateTotal = EditedAutoGenFsCash(FeesUI.autoSelTerm, FeesUI.autoSelYear, FeesUI.autoFilterListOfForms[0]);
                string totalCash = $"KES {String.Format("{0:0,0}", updateTotal)}";
                feeIns.lblTotalFeeStructure.Text = "Total " + totalCash;//Total KES 30,000
            }
            else
            {
                string totalCash = $"KES {String.Format("{0:0,0}", OverHeadListItem.totalCashPas)}";
                feeIns.lblTotalFeeStructure.Text = "Total " + totalCash;//Total KES 30,000
            }
        }
    }
}
