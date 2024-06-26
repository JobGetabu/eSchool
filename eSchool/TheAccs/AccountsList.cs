﻿using System;
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

namespace eSchool.TheAccs
{
    public partial class AccountsList : UserControl
    {
        private static AccountsList _instance;
        public static AccountsList Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountsList();
                }
                return _instance;
            }
        }
        public AccountsList()
        {
            InitializeComponent();
        }

        public void Global_AccountsList_Load()
        {
            //UI code
            //change color of TXN to green
            gData.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            //Load the grid
            GridInitilizer();
        }
        private void AccountsList_Load(object sender, EventArgs e)
        {
            //UI code
            //change color of TXN to green
            gData.Columns[2].DefaultCellStyle.ForeColor = Color.Blue;

            //Load the grid
            GridInitilizer();
        }
        public async void GridInitilizer()
        {
            gData.Rows.Clear();

            var accListAsync = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Accounts
                    .OrderBy(t => t.Id)
                    .ToList();
                }
            });

            gData.Rows.Clear();
            foreach (var acc in accListAsync)
            {
                gData.Rows.Add(new string[]
                {
                       null,
                       acc.Type,
                       acc.Bank,
                       acc.AccName,
                       acc.AccNo,
                       null
                });
            }
        }

        private void gData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            AccountsUI t = AccountsUI.Instance;
            t.lblRowCount.Text = gData.Rows.Count.ToString();

            this.gData.Rows[e.RowIndex].Cells[0].Value = GridIcon.Grid_View_50px;
            this.gData.Rows[e.RowIndex].Cells[5].Value = GridIcon.Trash_Can_50px;
        }

        private async Task<Account> GridDelImageAsync(int rowIndex)
        {
            List<Account> accList = await Task.Factory.StartNew(() =>
            {
                using (var context = new EschoolEntities())
                {
                    return context.Accounts.ToList();
                }
            });

            string accNoFound;
            accNoFound = (string)this.gData.Rows[rowIndex].Cells[4].Value;

            foreach (var fi in accList)
            {
                if (fi.AccNo.Equals(accNoFound))
                {
                    return fi;
                }
            }
            return null;
        }

        private async void gData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    if ((await GridDelImageAsync(e.RowIndex)) != null)
                    {
                        using (var context = new EschoolEntities())
                        {
                            try
                            {
                                if (MetroMessageBox.Show(this, $"Are You Sure You Want To Delete This Account ! \nThis action might result in loss of data of related transactions", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                                {
                                    context.Entry<Account>(await GridDelImageAsync(e.RowIndex)).State = EntityState.Deleted;
                                    context.SaveChanges();

                                    // short Custom Notification
                                    alert.Show("Deleted", alert.AlertType.info);
                                    gData.Rows[e.RowIndex].Visible = false;
                                    //Load the grid again
                                    GridInitilizer();       
                                }                         
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
    }
}
