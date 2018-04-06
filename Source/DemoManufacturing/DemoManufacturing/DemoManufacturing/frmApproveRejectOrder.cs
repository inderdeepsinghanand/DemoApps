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
using BarCodePrinting.Entities;
using BarCodePrinting.DataAccess;
using BarCodePrinting.Helpers;

namespace BarCodePrinting
{
    public partial class frmApproveRejectOrder : Form
    {
        public long _orderID = 0;
        public frmInspDashboard inspDashboard = null;
        public frmDashboard dashboard = null;
        public frmApproveRejectOrder(long orderID, frmInspDashboard dashboard)
        {
            InitializeComponent();
            _orderID = orderID;

            inspDashboard = dashboard;
            //if(barCode.
            //  string barCode = txtCode.Text;
            this.cmbStatus.Text = "Tested Ok";

        }

        public frmApproveRejectOrder(long orderID, frmDashboard _dashboard)
        {
            InitializeComponent();
            _orderID = orderID;

            dashboard = _dashboard;

            this.cmbStatus.Items.Clear();
            this.cmbStatus.Items.Add("Reject");
            this.cmbStatus.Items.Add("Skip");
            // this.cmbStatus.Enabled = false;
            this.cmbStatus.Text = "Skip";
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
            try
            {
                var status = cmbStatus.Text;
                OrderStatus orderStatus;
                //if ((status.ToUpper().Contains("OK") || status.ToUpper().Contains("REJECT")) )
                //{
                if (status.ToUpper().Contains("OK"))
                {
                    orderStatus = OrderStatus.Approved;
                }
                else if (status.ToUpper().Contains("REJECT"))
                    orderStatus = OrderStatus.Rejected;
                else if (status.ToUpper().Contains("SKIP"))
                    orderStatus = OrderStatus.Skip;
                else
                {
                    MessageBox.Show("Please select valid status");
                    return;
                }


                var saveStatus = new CustomerOrderRepository().ApproveRejectOrder(_orderID, orderStatus, txtReason.Text);
                if (saveStatus)
                {
                    MessageBox.Show("Status updated successfully.");
                    if (inspDashboard != null)
                    {
                        inspDashboard.LoadGridData();
                        new ScreensRepository().UpdateScreenReload(3, true);
                    }
                    if (dashboard != null) dashboard.LoadGridData();
                    this.Close();
                }
                else
                    MessageBox.Show("Error while updating status, please contact administrator.");

                //}
                //else {
                //    MessageBox.Show("Please select valid status");
                //}
            }
            catch (Exception ex) {
                LogException(ex);
            }

        }

        public void LogException(Exception ex, bool showMessage = true)
        {

            ExceptionLogger.LogException(ex, "Approve/Reject Order(OrderID:" + _orderID.ToString() + ")");

            if (showMessage)
                MessageBox.Show("Error occured during execution, please contact administrator for details");
        }
    }
}
