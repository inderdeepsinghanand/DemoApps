using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarCodePrinting.DataAccess;
using BarCodePrinting.Entities;
using BarCodePrinting.Helpers;

namespace BarCodePrinting
{
    public partial class frmDashboard : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bSourceBack = new BindingSource();
        private BindingSource bSourceFront = new BindingSource();

        private Button reloadButton = new Button();
        private Button submitButton = new Button();
        private Color red = Color.FromArgb(214, 14, 16);////201, 33, 28
        private Color green = Color.FromArgb(0, 173, 39); // //127, 186, 0
        private Color amber = Color.FromArgb(255, 216, 0); //212, 172, 17 //255, 140, 0
        private Color selectionBlue = Color.FromArgb(51, 153, 255);


        public int frnRowIndex, RearRowIndex;
        //public bool 

        public frmDashboard()
        {
            InitializeComponent();

            //FormBorderStyle = FormBorderStyle.None;//.Fixed3D;
            WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            //pnlData.Width = this.Width - 20;
            //pnlData.Height = this.Height - 50;
            //pnlData.Padding = pnlData.Margin = new Padding(0, 50, 0, 0);
            //pnlData.Location = new Point(this.Location.X, this.Location.Y + 50);
            //dgFrontBumpers.Width = dgBackBumpers.Width = pnlData.Width / 2;

            //dgFrontBumpers.Height = dgBackBumpers.Height = pnlData.Height;

            //dgFrontBumpers.Location = new Point(pnlData.Location.X, pnlData.Location.Y);

            //dgBackBumpers.Location = new Point(pnlData.Location.X + dgFrontBumpers.Width + 10, pnlData.Location.Y);

            // dgFrontBumpers.cellhe
            LoadGridData();
            dgFrontBumpers.Focus();


        }

        public void LoadGridData()
        {
            try
            {
                //        [ProductID] [bigint] IDENTITY(1,1) NOT NULL,
                //--[Name] [nvarchar](500) NOT NULL,
                //[Color] [nvarchar](50) NULL,
                //[EmissionNorms] nvarchar(100),
                //[MajorVariant] [nvarchar](500) NULL,
                //[Type] [nvarchar](20) NULL,
                //[CustomerCode] [nvarchar](150) NOT NULL,
                //[BarCode] [nvarchar](1000) NULL,

                dgFrontBumpers.DataSource = null;
                dgBackBumpers.DataSource = null;
                dgBackBumpers.Columns.Clear();
                dgFrontBumpers.Columns.Clear();

                // Bind the DataGridView to the BindingSource
                // and load the data from the database.
                dgFrontBumpers.DataSource = bSourceBack;
                var parameters = new List<SqlParameter>(){
             new SqlParameter("@Type", SqlDbType.NVarChar,20){ Value = "Front"}
            };

                GetData("[dbo].[usp_GetOrdersForDashboard]", bSourceBack, parameters);

                dgFrontBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
                dgFrontBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";
                dgFrontBumpers.Columns["DisplayName"].HeaderText = "Status";

                dgBackBumpers.DataSource = bSourceFront;
                parameters.Clear();
                parameters = new List<SqlParameter>(){
             new SqlParameter("@Type", SqlDbType.NVarChar,20){ Value = "Rear"}
            };

                GetData("[dbo].[usp_GetOrdersForDashboard]", bSourceFront, parameters);

                dgBackBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
                dgBackBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";
                dgBackBumpers.Columns["DisplayName"].HeaderText = "Status";


                dgFrontBumpers.Columns["OrderID"].Visible = false;
                dgBackBumpers.Columns["OrderID"].Visible = false;
                dgFrontBumpers.Columns["BarCode"].Visible = false;
                dgBackBumpers.Columns["BarCode"].Visible = false;
                dgBackBumpers.Columns["CustomerCode"].Visible = false;
                dgFrontBumpers.Columns["CustomerCode"].Visible = false;
                dgFrontBumpers.Columns["OrderStatusID"].Visible = false;
                dgBackBumpers.Columns["OrderStatusID"].Visible = false;

                dgBackBumpers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgFrontBumpers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //dgFrontBumpers.Columns["IsBarCodePrinted"].Visible = false;
                //dgBackBumpers.Columns["IsBarCodePrinted"].Visible = false;

                //Getthe counts
                var cmdparams = new List<SqlParameter>();
                cmdparams.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = "Front" });


                var tableFrnt = new CommonRepository().Get("[dbo].[usp_GetStatusCount]", CommandType.StoredProcedure, cmdparams);
                if (tableFrnt.Rows.Count > 0)
                {
                    var row = tableFrnt.Rows[0];
                    var newCount = row["New"].ToString();
                    var printedCount = row["Printed"].ToString();
                    var approvedCount = row["Approved"].ToString();
                    var rejectedCount = row["Rejected"].ToString();
                    var skippedCount = row["Skipped"].ToString();

                    lblFrontStats.Text = "New(" + newCount.ToString() + "), In Process(" + printedCount + "), Tested Ok(" + approvedCount + "), Rejected(" + rejectedCount + "), Skipped(" + skippedCount + ")";
                    //lblRearStats.Text = "Rear Bumpers" + "(" + dgBackBumpers.Rows.Count + ")";
                }

                cmdparams.Clear();
                cmdparams.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = "Rear" });


                var tableRear = new CommonRepository().Get("[dbo].[usp_GetStatusCount]", CommandType.StoredProcedure, cmdparams);
                if (tableRear.Rows.Count > 0)
                {
                    var row = tableRear.Rows[0];
                    var newCount = row["New"].ToString();
                    var printedCount = row["Printed"].ToString();
                    var approvedCount = row["Approved"].ToString();
                    var rejectedCount = row["Rejected"].ToString();
                    var skippedCount = row["Skipped"].ToString();


                    lblRearStats.Text = "New(" + newCount.ToString() + "), In Process(" + printedCount + "), Tested Ok(" + approvedCount + "), Rejected(" + rejectedCount + "), Skipped(" + skippedCount + ")";
                    // lblRearStats.Text = "Rear Bumpers" + "(" + dgBackBumpers.Rows.Count + ")";
                }

                RowSelect();

                //if()

                var print = GetRejectButton();

                var printBack = GetRejectButton();

                this.dgFrontBumpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            print});

                this.dgBackBumpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            printBack});

                new ScreensRepository().UpdateScreenReload(3, false);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void RowSelect()
        {
            dgFrontBumpers.ClearSelection();
            dgBackBumpers.ClearSelection();


            int frontrowIndex = -1, rearRowIndex = -1;

            var newStatusId = ((long)OrderStatus.New).ToString();

            DataGridViewRow dgFrontRow = dgFrontBumpers.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["OrderStatusID"].Value.ToString().Equals(newStatusId))
                .FirstOrDefault();
            if (dgFrontRow != null)
                frnRowIndex = dgFrontRow.Index;
            else
                frnRowIndex = -1;


            DataGridViewRow dgBackRow = dgBackBumpers.Rows
              .Cast<DataGridViewRow>()
              .Where(r => r.Cells["OrderStatusID"].Value.ToString().Equals(newStatusId))
              .FirstOrDefault();

            if (dgFrontRow != null)
                RearRowIndex = dgBackRow.Index;
            else
                RearRowIndex = -1;




            if (frnRowIndex >= 0 && frnRowIndex < dgFrontBumpers.Rows.Count)
            {
                var nextRow = dgFrontBumpers.Rows[frnRowIndex];
                nextRow.Selected = true;
                //dgFrontBumpers.FirstDisplayedScrollingRowIndex = frnRowIndex;
            }

            if (RearRowIndex >= 0 && RearRowIndex < dgBackBumpers.Rows.Count)
            {
                var nextRow = dgBackBumpers.Rows[RearRowIndex];
                nextRow.Selected = true;
                //nextRow.
                //dgBackBumpers.FirstDisplayedScrollingRowIndex = RearRowIndex;
            }

            //if (dgFrontBumpers.SelectedCells.Count <= 0 && dgFrontBumpers.Rows.Count > 0)
            //{
            //    dgFrontBumpers.Rows[0].Selected = true;
            //    //dgFrontBumpers.FirstDisplayedScrollingRowIndex = 0;

            //}

            //if (dgBackBumpers.SelectedCells.Count <= 0 && dgBackBumpers.Rows.Count > 0)
            //{
            //    dgBackBumpers.Rows[0].Selected = true;
            //    //dgBackBumpers.FirstDisplayedScrollingRowIndex = 0;

            //}
        }

        private static DataGridViewLinkColumn GetRejectButton()
        {
            var print = new System.Windows.Forms.DataGridViewLinkColumn();
            print.Text = "Action";
            // print.Name = "lnkReject";

            print.UseColumnTextForLinkValue = true;
            print.LinkBehavior = LinkBehavior.SystemDefault;
            print.HeaderText = "";
            print.Name = "Reject";
            // print.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 6.00f); 
            print.LinkColor = Color.Black;
            print.TrackVisitedState = true;
            print.HeaderText = "Skip/Reject";
            //print.
            // print.Text = "Print";
            print.UseColumnTextForLinkValue = true;
            print.DefaultCellStyle.SelectionBackColor = Color.White;
            //print.InheritedStyle = 


            return print;
        }

        private void GetData(string selectCommand, BindingSource bSource, List<SqlParameter> parameters = null)
        {
            try
            {
                var table = new CommonRepository().Get(selectCommand, CommandType.StoredProcedure, parameters);



                bSource.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }

            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMasterUpload_Click(object sender, EventArgs e)
        {
            frmMasterUpload upload = new frmMasterUpload();
            upload.ShowDialog();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                int openForms = Application.OpenForms.Count;
                for (int i = 0; i < openForms; i++)
                {
                    Application.OpenForms[i].Close();
                }
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }

        private void btnUploadOrder_Click(object sender, EventArgs e)
        {
            frmOrderUpload orderUpload = new frmOrderUpload(this);
            orderUpload.ShowDialog();
            orderUpload.FormClosed += frmOrder_FormClosed;

        }

        private void dgFrontBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //DataView tb = dgFrontBumpers.DataS as DataTable;
                if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
                {
                    DataGridViewRow row = dgFrontBumpers.Rows[e.RowIndex];// get you required index
                    // check the cell value under your specific column and then you can toggle your colors

                    var cell = row.Cells["OrderStatusID"];

                    // var cell = row.Cells["OrderStatusID"];


                    FormatRow(row, cell);



                    //set the reject button cell
                    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;
                        // row.Cells[rejectIndex].Style.Font = new Font(FontFamily.GenericSansSerif, 10.00f);
                        row.Cells[rejectIndex].Style.BackColor = Color.White;
                        //        print.DefaultCellStyle.Font = 
                        if (((long)cell.Value) == (long)OrderStatus.New)
                        {
                            // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                        }
                        else if (((long)cell.Value) == (long)OrderStatus.Approved)
                        {
                            row.Cells[rejectIndex].ReadOnly = true;
                        }
                        else if (((long)cell.Value) == (long)OrderStatus.BCPrinted)
                            row.Cells[rejectIndex].ReadOnly = true;
                        else
                            row.DefaultCellStyle.BackColor = red;

                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void FormatRow(DataGridViewRow row, DataGridViewCell cell)
        {
            if (((long)cell.Value) == (long)OrderStatus.New)
            {
                // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
            }
            else if (((long)cell.Value) == (long)OrderStatus.Approved)
            {
                row.DefaultCellStyle.BackColor = green;
            }
            else if (((long)cell.Value) == (long)OrderStatus.BCPrinted)
                row.DefaultCellStyle.BackColor = amber;
            else
                row.DefaultCellStyle.BackColor = red;
        }

        private void dgFrontBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    frnRowIndex = e.RowIndex + 1;
                    var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                    //green
                    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                    //  row.Selected = true;
                    //var rejectIndex = this.dgFrontBumpers.Columns["lnkReject"].Index;
                    //row.Cells[rejectIndex].Selected=false;
                    //row.Cells[rejectIndex].ba;
                    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                    var cell = row.Cells["OrderStatusID"];
                    var statusId = (long)cell.Value;

                    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;

                        //        print.DefaultCellStyle.Font = 
                        if (e.ColumnIndex == rejectIndex && (statusId == (long)OrderStatus.New || statusId == (long)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip))
                        {


                            //green
                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                            //set print status
                            SetRejectStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()));
                            LoadGridData();
                            // MessageBox.Show("Barcode printed successfully");
                            // MessageBox.Show(row.Cells["OrderID"].Value.ToString());

                        }
                        else
                        {
                            //TODO check the status
                            //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                            ////  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                            //var order = new PrintProduct();
                            //order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
                            //order.BarCode = row.Cells["BarCode"].Value.ToString();
                            //order.CustomerCode = row.Cells["CustomerCode"].Value.ToString();
                            //order.EmissionNorms = row.Cells["EmissionNorms"].Value.ToString();
                            //order.Color = row.Cells["Color"].Value.ToString();
                            //order.MajorVariant = row.Cells["MajorVariant"].Value.ToString();
                            //order.Type = "Front";


                            ////set print status
                            //SetPrintStatus(order);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }


        }

        public void SetRejectStatus(long OrderID)
        {
            //new CustomerOrderRepository

            // new CustomerOrderRepository().ChangePrintStatus(OrderID);

            //var barcode = "select * from tbl"

            frmApproveRejectOrder approve = new frmApproveRejectOrder(OrderID, this);
            approve.ShowDialog();
        }

        public void SetPrintStatus(PrintProduct order)
        {
            //new CustomerOrderRepository

            // new CustomerOrderRepository().ChangePrintStatus(OrderID);

            //var barcode = "select * from tbl"

            frmBarcodePrinting barcodePrint = new frmBarcodePrinting(order, this);
            // barcodePrint.ShowDialog();
        }

        private void dgBackBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                    //green
                    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                    //  row.Selected = true;
                    //var rejectIndex = this.dgFrontBumpers.Columns["lnkReject"].Index;
                    //row.Cells[rejectIndex].Selected=false;
                    //row.Cells[rejectIndex].ba;
                    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());

                    var cell = row.Cells["OrderStatusID"];
                    var statusId = (long)cell.Value;

                    var rejectColumn = this.dgBackBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;

                        //        print.DefaultCellStyle.Font = 
                        if (e.ColumnIndex == rejectIndex && (statusId == (long)OrderStatus.New || statusId == (long)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip))
                        {


                            //green
                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                            //set print status
                            SetRejectStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()));
                            LoadGridData();
                            // MessageBox.Show("Barcode printed successfully");
                            // MessageBox.Show(row.Cells["OrderID"].Value.ToString());

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogException(ex);
            }

        }

        private void dgBackBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
                //{
                //    DataGridViewRow row = dgBackBumpers.Rows[e.RowIndex];// get you required index
                //    // check the cell value under your specific column and then you can toggle your colors

                //    var cell = row.Cells["OrderStatusID"];
                //    if (((long)cell.Value) == (long)OrderStatus.New)
                //    {
                //       // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                //    }
                //    else
                //        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);

                //}
                //DataView tb = dgFrontBumpers.DataS as DataTable;
                if (dgBackBumpers.Rows != null && dgBackBumpers.Rows.Count > 0)
                {
                    DataGridViewRow row = dgBackBumpers.Rows[e.RowIndex];// get you required index
                    // check the cell value under your specific column and then you can toggle your colors

                    var cell = row.Cells["OrderStatusID"];

                    // var cell = row.Cells["OrderStatusID"];


                    FormatRow(row, cell);



                    //set the reject button cell
                    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;
                        // row.Cells[rejectIndex].Style.Font = new Font(FontFamily.GenericSansSerif, 10.00f);
                        row.Cells[rejectIndex].Style.BackColor = Color.White;
                        //        print.DefaultCellStyle.Font = 
                        if (((long)cell.Value) == (long)OrderStatus.New)
                        {
                            // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                        }
                        else if (((long)cell.Value) == (long)OrderStatus.Approved)
                        {
                            // row.Cells[rejectIndex].Style.BackColor = disabled//.ReadOnly = true;
                        }
                        else if (((long)cell.Value) == (long)OrderStatus.BCPrinted)
                            row.Cells[rejectIndex].ReadOnly = true;
                        else
                            row.DefaultCellStyle.BackColor = red;

                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex, true);
            }
        }

        private void frmOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadGridData();
        }

        private void dgFrontBumpers_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }


                if (e.KeyCode == Keys.Enter)
                {
                    var cell = dgFrontBumpers.SelectedCells[0];
                    //dgFrontBumpers.se



                    if (cell != null && cell.RowIndex >= 0)
                    {
                        dgFrontBumpers.ClearSelection();
                        //                    dgBackBumpers.ClearSelection();

                        var row = dgFrontBumpers.Rows[cell.RowIndex];
                        // dgFrontBumpers.Rows[cell.RowIndex].Selected = true;
                        //dgFrontBumpers.FirstDisplayedScrollingRowIndex = cell.RowIndex;
                        e.Handled = true;
                        //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                        var cell1 = row.Cells["OrderStatusID"];
                        var statusId = (long)cell1.Value;
                        //  row.Selected = true;
                        if (statusId == (long)OrderStatus.New || statusId == (long)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip)
                        {
                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                            var order = new PrintProduct();
                            order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
                            order.BarCode = row.Cells["BarCode"].Value.ToString();
                            order.CustomerCode = row.Cells["CustomerCode"].Value.ToString();
                            order.EmissionNorms = row.Cells["EmissionNorms"].Value.ToString();
                            order.Color = row.Cells["Color"].Value.ToString();
                            order.MajorVariant = row.Cells["MajorVariant"].Value.ToString();
                            order.Type = "Front";


                            //set print status
                            SetPrintStatus(order);
                            // row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                            // LoadGridData();
                            //if (cell.RowIndex < dgFrontBumpers.Rows.Count)
                            //{
                            //    var nextRow = dgFrontBumpers.Rows[cell.RowIndex +1];
                            //    nextRow.Selected =true;
                            //}
                            // MessageBox.Show("Barcode printed successfully");
                            // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                        }
                    }


                    //MessageBox.Show(cell.Value.ToString());
                    //MessageBox.Show(cell.RowIndex.ToString());

                }
            }
            catch (Exception ex)
            {
                LogException(ex, true);
            }
        }

        private void dgFrontBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    frnRowIndex = e.RowIndex + 1;
                    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;

                        //        print.DefaultCellStyle.Font = 
                        if (e.ColumnIndex == rejectIndex)
                        {


                        }
                        else
                        {

                            var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                            //green
                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                            dgFrontBumpers.ClearSelection();
                            //dgBackBumpers.ClearSelection();

                            var cell = row.Cells["OrderStatusID"];
                            var statusId = (long)cell.Value;
                            // dgFrontBumpers.Rows[e.RowIndex].Selected = true;
                            //dgFrontBumpers.FirstDisplayedScrollingRowIndex = e.RowIndex;
                            if (statusId == (long)OrderStatus.New || statusId == (long)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip)
                            {
                                // MessageBox.Show(row.Cells["OrderID"].Value.ToString());


                                //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                                var order = new PrintProduct();
                                order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
                                order.BarCode = row.Cells["BarCode"].Value.ToString();
                                order.CustomerCode = row.Cells["CustomerCode"].Value.ToString();
                                order.EmissionNorms = row.Cells["EmissionNorms"].Value.ToString();
                                order.Color = row.Cells["Color"].Value.ToString();
                                order.MajorVariant = row.Cells["MajorVariant"].Value.ToString();
                                order.Type = "Front";


                                //set print status
                                SetPrintStatus(order);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex, true);
            }
        }

        private void dgBackBumpers_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    var cell = dgBackBumpers.SelectedCells[0];
                    //dgFrontBumpers.se



                    if (cell != null && cell.RowIndex >= 0)
                    {
                        //                    dgFrontBumpers.ClearSelection();
                        dgBackBumpers.ClearSelection();

                        //  RearRowIndex = cell.RowIndex +1;
                        var row = dgBackBumpers.Rows[cell.RowIndex];
                        // dgBackBumpers.Rows[cell.RowIndex].Selected = true;
                        e.Handled = true;
                        var cell1 = row.Cells["OrderStatusID"];
                        var statusId = (long)cell1.Value;
                        //    row.Selected = true;
                        //dgFrontBumpers.FirstDisplayedScrollingRowIndex = cell.RowIndex;

                        if (statusId == (long)OrderStatus.New || statusId == (long)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip)
                        {

                            //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                            var order = new PrintProduct();
                            order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
                            order.BarCode = row.Cells["BarCode"].Value.ToString();
                            order.CustomerCode = row.Cells["CustomerCode"].Value.ToString();
                            order.EmissionNorms = row.Cells["EmissionNorms"].Value.ToString();
                            order.Color = row.Cells["Color"].Value.ToString();
                            order.MajorVariant = row.Cells["MajorVariant"].Value.ToString();
                            order.Type = "Rear";

                            //set print status
                            SetPrintStatus(order);
                        }
                        // row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                        // LoadGridData();
                        //if (cell.RowIndex < dgBackBumpers.Rows.Count)
                        //{
                        //    var nextRow = dgBackBumpers.Rows[cell.RowIndex + 1];
                        //    nextRow.Selected = true;
                        //}
                        // MessageBox.Show("Barcode printed successfully");
                        // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                    }


                    //MessageBox.Show(cell.Value.ToString());
                    //MessageBox.Show(cell.RowIndex.ToString());

                }
            }
            catch (Exception ex)
            {
                LogException(ex, true);
            }
        }

        private void dgBackBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {


                    RearRowIndex = e.RowIndex + 1;
                    var rejectColumn = this.dgBackBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;

                        //        print.DefaultCellStyle.Font = 
                        if (e.ColumnIndex == rejectIndex)
                        {


                        }
                        else
                        {

                            //var connectionString = e.RowIndex +1 ;
                            var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se


                            //green
                            //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                            // dgFrontBumpers.ClearSelection();
                            dgBackBumpers.ClearSelection();

                            var cell = row.Cells["OrderStatusID"];
                            var statusId = (long)cell.Value;
                            // dgBackBumpers.Rows[e.RowIndex].Selected = true;
                            //dgBackBumpers.FirstDisplayedScrollingRowIndex = e.RowIndex;
                            if (statusId == (long)OrderStatus.New || statusId == (long)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip)
                            {
                                //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                                var order = new PrintProduct();
                                order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
                                order.BarCode = row.Cells["BarCode"].Value.ToString();
                                order.CustomerCode = row.Cells["CustomerCode"].Value.ToString();
                                order.EmissionNorms = row.Cells["EmissionNorms"].Value.ToString();
                                order.Color = row.Cells["Color"].Value.ToString();
                                order.MajorVariant = row.Cells["MajorVariant"].Value.ToString();
                                order.Type = "Rear";

                                //set print status
                                SetPrintStatus(order);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex, true);
            }
        }

        private void frmDashboard_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                e.Handled = true;
            }
        }

        private void tmrBlinkRecord_Tick(object sender, EventArgs e)
        {
            try
            {
                if (dgFrontBumpers.SelectedRows.Count > 0 && dgFrontBumpers.SelectedRows[0] != null)
                {
                    var row = dgFrontBumpers.SelectedRows[0];

                    var statusCell = row.Cells["OrderStatusID"];
                    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                    int rejectCellIndex = 0, statusId = 0;
                    if (rejectColumn != null)
                    {
                        rejectCellIndex = rejectColumn.Index;
                    }
                    if (statusCell != null)
                    {
                        statusId = Convert.ToInt32(statusCell.Value);
                    }

                    SetBlinkColor(row, rejectCellIndex, statusId);
                }
                if (dgBackBumpers.SelectedRows.Count > 0 && dgBackBumpers.SelectedRows[0] != null)
                {
                    var row = dgBackBumpers.SelectedRows[0];

                    var statusCell = row.Cells["OrderStatusID"];
                    var rejectColumn = this.dgBackBumpers.Columns["Reject"];
                    int rejectCellIndex = 0, statusId = 0;
                    if (rejectColumn != null)
                    {
                        rejectCellIndex = rejectColumn.Index;
                    }
                    if (statusCell != null)
                    {
                        statusId = Convert.ToInt32(statusCell.Value);
                    }

                    SetBlinkColor(row, rejectCellIndex, statusId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }

        private void SetBlinkColor(DataGridViewRow row, int rejectCellIndex, int statusId)
        {
            if (statusId != (int)OrderStatus.Rejected || statusId == (long)OrderStatus.Skip)
            {
                if (row.DefaultCellStyle.SelectionBackColor.ToArgb() == selectionBlue.ToArgb()) // Color..Highlight)
                {
                    if (row.DefaultCellStyle.BackColor.ToArgb() == 0)
                    {
                        row.DefaultCellStyle.SelectionBackColor = Color.White;
                    }
                    else
                        row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;

                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = selectionBlue;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                    if (rejectCellIndex > 0)
                        row.Cells[rejectCellIndex].Style.SelectionBackColor = Color.White;
                }
            }
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tmrReloadGrids_Tick(object sender, EventArgs e)
        {
            try
            {
                var dt = new CommonRepository().Get("Select [RefreshNeeded] from [dbo].[tbl_Screens] where ScreenID =3", CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var status = (bool)dt.Rows[0][0];
                    if (status)
                        LoadGridData();
                }
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }

        private void dgFrontBumpers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void tmrSelectRow_Tick(object sender, EventArgs e)
        {
            try
            {
                RowSelect();
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int openForms = Application.OpenForms.Count;
                //if
                for (int i = 0; i < openForms; i++)
                {

                    Application.OpenForms[i].Close();
                }
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }

        public void LogException(Exception ex, bool showMessage = true)
        {

            ExceptionLogger.LogException(ex, "Admin Dashboard");

            if (showMessage)
                MessageBox.Show("Error occured during execution, please contact administrator for details");
        }

    }
}
