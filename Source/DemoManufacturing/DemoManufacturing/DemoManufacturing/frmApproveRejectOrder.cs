using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using DemoManufacturing.Entities;
using DemoManufacturing.DataAccess;

namespace DemoManufacturing
{
    public partial class frmApproveRejectOrder : Form
    {
        public long _orderID = 0;
        public frmApproveRejectOrder(long orderID)
        {
            InitializeComponent();
            _orderID = orderID;
            //if(barCode.
          //  string barCode = txtCode.Text;

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var status = cmbStatus.SelectedText;
            OrderStatus orderStatus;
            if ((status.ToUpper().Contains("OK") || status.ToUpper().Contains("REJECT")) && !string.IsNullOrEmpty(txtReason.Text))
            {
                if (status.ToUpper().Contains("OK")) {
                    orderStatus = OrderStatus.Approved;
                }else
                    orderStatus = OrderStatus.Rejected;

                new CustomerOrderRepository().ApproveRejectOrder(_orderID, orderStatus, txtReason.Text);


            }
            else {
                MessageBox.Show("Please select valid status");
            }
        }
    }
}
