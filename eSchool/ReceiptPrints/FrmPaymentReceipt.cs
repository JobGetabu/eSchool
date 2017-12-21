using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eSchool.ReceiptPrints
{
    public partial class FrmPaymentReceipt : Form
    {
        public FrmPaymentReceipt(List<PaymentOverheads> listPayOv, PaymentDetails pDetails,StudentDetails sDetails)
        {
            InitializeComponent();
        }

        private void FrmPaymentReceipt_Load(object sender, EventArgs e)
        {

        }
    }
}
