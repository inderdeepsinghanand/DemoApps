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
    public partial class frmInspDashboard : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bSourceBack = new BindingSource();
        private BindingSource bSourceFront = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();
        private Color red = Color.FromArgb(214, 14, 16);////201, 33, 28
        private Color green = Color.FromArgb(0, 173, 39); // //127, 186, 0
        private Color amber = Color.FromArgb(255, 216, 0); //212, 172, 17 //255, 140, 0

        private Color selectionBlue = Color.FromArgb(51, 153, 255);
        private Color disabledGray = Color.Red;//.LightGray;

        public int frnRowIndex, RearRowIndex;


        public frmInspDashboard()
        {
            InitializeComponent();

           // FormBorderStyle = FormBorderStyle.None;//.Fixed3D;
            WindowState = FormWindowState.Maximized;
            tmrRefresh.Start();
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


            LoadGridData();
        }

        public void LoadGridData()
        {
            try{
            tmrBlinkRecord.Stop();
            dgFrontBumpers.DataSource = null;
            dgBackBumpers.DataSource = null;
            dgBackBumpers.Columns.Clear();
            dgFrontBumpers.Columns.Clear();

            dgFrontBumpers.DefaultCellStyle.BackColor = amber;
            dgBackBumpers.DefaultCellStyle.BackColor = amber;
            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dgFrontBumpers.DataSource = bSourceBack;
            GetData("select OrderID, [Color],[EmissionNorms],[MajorVariant],[IsBarCodePrinted],[BarCode],[OrderStatusID],os.[DisplayName] as Status, [Reason] from [tbl_CustomerOrders]  co inner join dbo.tbl_OrderStatus os on co.[OrderStatusID] = os.[StatusID] where OrderStatusID = " + (long)OrderStatus.BCPrinted + "AND Type ='Front'", bSourceBack);

            dgFrontBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgFrontBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";

            dgBackBumpers.DataSource = bSourceFront;
            GetData("select OrderID, [Color],[EmissionNorms],[MajorVariant],[IsBarCodePrinted],[BarCode],[OrderStatusID],os.[DisplayName] as Status, [Reason] from [tbl_CustomerOrders]  co inner join dbo.tbl_OrderStatus os on co.[OrderStatusID] = os.[StatusID] where OrderStatusID = " + (long)OrderStatus.BCPrinted + "AND Type ='Rear'", bSourceFront);

            dgBackBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgBackBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";
          


            dgFrontBumpers.Columns["OrderID"].Visible = false;
            dgBackBumpers.Columns["OrderID"].Visible = false;
            dgFrontBumpers.Columns["BarCode"].Visible = false;
            dgBackBumpers.Columns["BarCode"].Visible = false;
            dgBackBumpers.Columns["OrderStatusID"].Visible = false;
            dgFrontBumpers.Columns["OrderStatusID"].Visible = false;


            dgFrontBumpers.Columns["IsBarCodePrinted"].Visible = false;
            dgBackBumpers.Columns["IsBarCodePrinted"].Visible = false;

            lblFrontBump.Text = "Front Bumpers" + "(" + dgFrontBumpers.Rows.Count + ")";
            lblRearBump.Text = "Rear Bumpers" + "(" + dgBackBumpers.Rows.Count + ")";

            dgBackBumpers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFrontBumpers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           



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

            frnRowIndex = frnRowIndex - 1;
            RearRowIndex = RearRowIndex - 1;
            //if (frnRowIndex >= 0 && frnRowIndex < dgFrontBumpers.Rows.Count)
            //{
            //    var nextRow = dgFrontBumpers.Rows[frnRowIndex];
            //    nextRow.Selected = true;
            //}

            //if (RearRowIndex >= 0 && RearRowIndex < dgBackBumpers.Rows.Count)
            //{
            //    var nextRow = dgBackBumpers.Rows[RearRowIndex];
            //    nextRow.Selected = true;
            //}
            tmrBlinkRecord.Start();
            new ScreensRepository().UpdateScreenReload(4, false);
            }
            catch (Exception ex) {
                LogException(ex);
            }
        }

        private static DataGridViewLinkColumn GetPrintButton()
        {
            var print = new System.Windows.Forms.DataGridViewLinkColumn();
            print.Text = "Print";
            print.Name = "Print";

            print.UseColumnTextForLinkValue = true;
            print.LinkBehavior = LinkBehavior.SystemDefault;
            print.HeaderText = "Print";
            print.Name = "Print";
          //  print.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 8.00f); 
            print.LinkColor = Color.Blue;
            print.TrackVisitedState = true;
            print.Text = "Print";
            print.UseColumnTextForLinkValue = true;


            return print;
        }

        private void GetData(string selectCommand, BindingSource bSource)
        {
            try
            {
                DataTable table = GetDataTable(selectCommand);



                bSource.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message + "\n Trace:" + ex.StackTrace);
            }
        }

        private DataTable GetDataTable(string selectCommand)
        {
            DataTable tblResult = new DataTable();
            // Specify a connection string. Replace the given value with a 
            // valid connection string for a Northwind SQL Server sample
            // database accessible to your system.
            //var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(selectCommand, ConnectionStringHelper.GetConnectionString());

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            //foreach()
            return table;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try{
            this.Close();
            
            int openForms = Application.OpenForms.Count;
            for (int i = 0; i < openForms; i++)
            {
                Application.OpenForms[i].Close();
            }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void btnMasterUpload_Click(object sender, EventArgs e)
        {
            frmMasterUpload upload = new frmMasterUpload();
            upload.ShowDialog();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            try{
            this.Close();
            
            int openForms = Application.OpenForms.Count;
            for (int i = 0; i < openForms; i++)
            {
                Application.OpenForms[i].Close();
            }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void btnUploadOrder_Click(object sender, EventArgs e)
        {
            //frmOrderUpload orderUpload = new frmOrderUpload(this);
            //orderUpload.ShowDialog();
            //orderUpload.FormClosed += frmOrder_FormClosed;

        }

        //private void dgFrontBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    //DataView tb = dgFrontBumpers.DataS as DataTable;
        //    if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
        //    {
        //        DataGridViewRow row = dgFrontBumpers.Rows[e.RowIndex];// get you required index
        //        // check the cell value under your specific column and then you can toggle your colors

        //            var cell = row.Cells["OrderStatusID"];
        //            if (((long)cell.Value) == (long)OrderStatus.Approved)
        //            {
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
        //            }
        //            else if (((long)cell.Value) == (long)OrderStatus.BCPrinted)
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
        //            else
        //                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0);
                
        //    }
        //}


        private void dgFrontBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ////DataView tb = dgFrontBumpers.DataS as DataTable;
            //if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
            //{
            //    DataGridViewRow row = dgFrontBumpers.Rows[e.RowIndex];// get you required index
            //    // check the cell value under your specific column and then you can toggle your colors

            //    var cell = row.Cells["OrderStatusID"];

            //    // var cell = row.Cells["OrderStatusID"];


            //    if (((long)cell.Value) == (long)OrderStatus.New)
            //    {
            //        // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
            //    }
            //    else if (((long)cell.Value) == (long)OrderStatus.Approved)
            //    {
            //        row.DefaultCellStyle.BackColor = green;
            //    }
            //    else if (((long)cell.Value) == (long)OrderStatus.BCPrinted)
            //        row.DefaultCellStyle.BackColor = amber;
            //    else
            //        row.DefaultCellStyle.BackColor = red;



            //    //set the reject button cell
            //    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
            //    if (rejectColumn != null)
            //    {
            //        var rejectIndex = rejectColumn.Index;
            //        row.Cells[rejectIndex].Style.Font = new Font(FontFamily.GenericSansSerif, 10.00f);
            //        row.Cells[rejectIndex].Style.BackColor = Color.White;
            //        //        print.DefaultCellStyle.Font = 
            //    }

            //}
        }

        private void dgFrontBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
            //    //green
            //    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

            //    row.Selected = true;
            //    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
            //}

            //if (e.ColumnIndex == this.dgFrontBumpers.Columns["Print"].Index)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
            //        //green
            //      //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

            //        //set print status
            //        SetPrintStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), row.Cells["BarCode"].Value.ToString());
            //        LoadGridData();
            //        MessageBox.Show("Barcode printed successfully");
            //        // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
            //    }
            //}
        }

        public void SetStatus(long OrderID,string Barcode)
        {
            //new CustomerOrderRepository

           // new CustomerOrderRepository().ChangePrintStatus(OrderID);

            //var barcode = "select * from tbl"

            frmApproveRejectOrder approve = new frmApproveRejectOrder(OrderID,this);
            approve.ShowDialog();
        }



        private void dgBackBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //if (e.RowIndex >= 0)
            //{
            //    RearRowIndex = e.RowIndex+1;
            //    var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
            //    //green
            //    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

            //    row.Selected = true;
            //    //var rejectIndex = this.dgFrontBumpers.Columns["lnkReject"].Index;
            //    //row.Cells[rejectIndex].Selected=false;
            //    //row.Cells[rejectIndex].ba;
            //    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());

            //   // row.Selected = true;
            //    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
            //    SetStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
            //    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
            //    // LoadGridData();
            //    if (e.RowIndex < dgBackBumpers.Rows.Count)
            //    {
            //        var nextRow = dgBackBumpers.Rows[e.RowIndex + 1];
            //        nextRow.Selected = true;
            //    }
            //}



        }

        private void dgBackBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            //if (dgBackBumpers.Rows != null && dgBackBumpers.Rows.Count > 0)
            //{
            //    DataGridViewRow row = dgBackBumpers.Rows[e.RowIndex];// get you required index
            //    // check the cell value under your specific column and then you can toggle your colors

            //    var cell = row.Cells["OrderStatusID"];

            //    // var cell = row.Cells["OrderStatusID"];


            //    if (((long)cell.Value) == (long)OrderStatus.New)
            //    {
            //        // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
            //    }
            //    else if (((long)cell.Value) == (long)OrderStatus.Approved)
            //    {
            //        row.DefaultCellStyle.BackColor = green;
            //    }
            //    else if (((long)cell.Value) == (long)OrderStatus.BCPrinted)
            //        row.DefaultCellStyle.BackColor = amber;
            //    else
            //        row.DefaultCellStyle.BackColor = red;



            //    //set the reject button cell
            //    var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
            //    if (rejectColumn != null)
            //    {
            //        var rejectIndex = rejectColumn.Index;
            //        row.Cells[rejectIndex].Style.Font = new Font(FontFamily.GenericSansSerif, 10.00f);
            //        row.Cells[rejectIndex].Style.BackColor = Color.White;
            //        //        print.DefaultCellStyle.Font = 
            //    }

            //}

        }

        //private void dgBackBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
        //    {
        //        DataGridViewRow row = dgBackBumpers.Rows[e.RowIndex];// get you required index
        //        // check the cell value under your specific column and then you can toggle your colors

        //        var cell = row.Cells["OrderStatusID"];
        //        if (((long)cell.Value) == (long)OrderStatus.New)
        //        {
        //           // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
        //        }
        //        else
        //            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);

        //    }
        //}

        private void frmOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadGridData();
        }

        private void dgFrontBumpers_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                //if (e.RowIndex >= 0)
                //{
                //    frnRowIndex = e.RowIndex + 1;

                //    var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                //    //green
                //    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                //    row.Selected = true;
                //    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                //    SetStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
                //    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                //    // LoadGridData();
                //    //if (e.RowIndex < dgFrontBumpers.Rows.Count)
                //    //{
                //    //    var nextRow = dgFrontBumpers.Rows[e.RowIndex + 1];
                //    //    nextRow.Selected = true;
                //    //}

                //}

                if (e.KeyCode == Keys.Enter)
                {
                    var cell = dgFrontBumpers.SelectedCells[0];
                    //dgFrontBumpers.se
                    var rowIndex = cell != null ? cell.RowIndex : -1; // dgFrontBumpers.SelectedRows[0].Index;


                    if (rowIndex >= 0)
                    {
                        frnRowIndex = rowIndex + 1;

                        var row = dgFrontBumpers.Rows[rowIndex];
                        row.Selected = true;
                        e.Handled = true;
                        //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                        //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                        //set print status
                        SetStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
                        // row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                        // LoadGridData();
                        //if (cell.RowIndex < dgFrontBumpers.Rows.Count)
                        //{
                        //    var nextRow = dgFrontBumpers.Rows[rowIndex];
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
                LogException(ex);
            }
            //e.h
        }

        private void dgFrontBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    frnRowIndex = e.RowIndex + 1;

                    var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                    //green
                    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                    row.Selected = true;
                    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                    SetStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
                    // row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                    // LoadGridData();
                    //if (e.RowIndex < dgFrontBumpers.Rows.Count)
                    //{
                    //    var nextRow = dgFrontBumpers.Rows[e.RowIndex + 1];
                    //    nextRow.Selected = true;
                    //}

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void dgBackBumpers_KeyDown(object sender, KeyEventArgs e)
        {
            try{
            if (e.KeyCode == Keys.Enter)
            {
                var cell = dgBackBumpers.SelectedCells[0];
                //dgFrontBumpers.se



                if (cell != null && cell.RowIndex >= 0)
                {
                    RearRowIndex = cell.RowIndex + 1;

                    var row = dgBackBumpers.Rows[cell.RowIndex];
                    row.Selected = true;
                    e.Handled = true;
                    //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                    //set print status
                    SetStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
                  //  row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
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
                LogException(ex);
            }
        }

        private void dgBackBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    RearRowIndex = e.RowIndex + 1;

                    var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                    //green
                    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                    row.Selected = true;
                    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                    SetStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
                    // row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                    // LoadGridData();
                    //if (e.RowIndex < dgBackBumpers.Rows.Count)
                    //{
                    //    var nextRow = dgBackBumpers.Rows[e.RowIndex + 1];
                    //    nextRow.Selected = true;
                    //}

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void frmInspDashboard_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmInspDashboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                e.Handled = true;
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            try
            {
                var dt = GetDataTable("Select [RefreshNeeded] from [dbo].[tbl_Screens] where ScreenID =4");
                if (dt != null && dt.Rows.Count > 0)
                {
                    var status = (bool)dt.Rows[0][0];
                    if (status) LoadGridData();
                }
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }

        private void tmrBlinkRecord_Tick(object sender, EventArgs e)
        {
            try
            {
                

                if (dgFrontBumpers.SelectedRows.Count <= 0 && dgFrontBumpers.Rows.Count > 0)
                {
                    dgFrontBumpers.Rows[0].Selected = true;
                    // row = dgFrontBumpers.Rows[0];

                }
                if (dgBackBumpers.SelectedRows.Count <= 0 && dgBackBumpers.Rows.Count > 0)
                {
                    dgBackBumpers.Rows[0].Selected = true;
                    // row = dgFrontBumpers.Rows[0];

                }
                if (dgFrontBumpers.SelectedRows.Count > 0 && dgFrontBumpers.SelectedRows[0] != null)
                {
                    var row = dgFrontBumpers.SelectedRows[0];

                    //var statusCell = row.Cells["OrderStatusID"];
                    //var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                    //int rejectCellIndex = 0, statusId = 0;
                    //if (rejectColumn != null)
                    //{
                    //    rejectCellIndex = rejectColumn.Index;
                    //}
                    //if (statusCell != null)
                    //{
                    //    statusId = Convert.ToInt32(statusCell.Value);
                    //}

                    SetBlinkColor(row);
                }
                if (dgBackBumpers.SelectedRows.Count > 0 && dgBackBumpers.SelectedRows[0] != null)
                {
                    var row = dgBackBumpers.SelectedRows[0];

                    if (row == null)
                    {
                        dgBackBumpers.Rows[0].Selected = true;
                        row = dgBackBumpers.Rows[0];
                    }

                    //var statusCell = row.Cells["OrderStatusID"];
                    //var rejectColumn = this.dgBackBumpers.Columns["Reject"];
                    //int rejectCellIndex = 0, statusId = 0;
                    //if (rejectColumn != null)
                    //{
                    //    rejectCellIndex = rejectColumn.Index;
                    //}
                    //if (statusCell != null)
                    //{
                    //    statusId = Convert.ToInt32(statusCell.Value);
                    //}

                    SetBlinkColor(row);
                }
            }
            catch (Exception ex)
            {
                LogException(ex, false);
            }
        }
        private void SetBlinkColor(DataGridViewRow row)
        {

                if (row.DefaultCellStyle.SelectionBackColor.ToArgb() == selectionBlue.ToArgb()) // Color..Highlight)
                {

                    row.DefaultCellStyle.SelectionBackColor = amber;
                   // row.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.SelectionBackColor = selectionBlue;
                    //row.DefaultCellStyle.SelectionForeColor = Color.White;
              
                }
            }

        private void frmInspDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {

            //int openForms = Application.OpenForms.Count;
            //for (int i = 1; i < openForms; i++)
            //{
            //    Application.OpenForms[i].Close();
            //}
        }

        private void frmInspDashboard_FormClosed(object sender, FormClosedEventArgs e)
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
            catch (Exception ex) {
                LogException(ex,false);
            }

        }

        public void LogException(Exception ex,bool showMessage = true) {
            
            ExceptionLogger.LogException(ex, "Quality Dashboard");

            if (showMessage)
                MessageBox.Show("Error occured during execution, please contact administrator");
        }
    }
}
