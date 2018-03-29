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
using DemoManufacturing.DataAccess;
using DemoManufacturing.Entities;

namespace DemoManufacturing
{
    public partial class frmDashboard : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bSourceBack = new BindingSource();
        private BindingSource bSourceFront = new BindingSource();
        
        private Button reloadButton = new Button();
        private Button submitButton = new Button();
        private Color red = Color.FromArgb(201, 33, 28);
        private Color green = Color.FromArgb(127, 186, 0);
        private Color amber = Color.FromArgb(255, 140, 0);

        public int frnRowIndex, RearRowIndex;
        //public bool 

        public frmDashboard()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;//.Fixed3D;
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
        }

        public void LoadGridData()
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
            GetData("select OrderID, [Color],[EmissionNorms],[MajorVariant],[BarCode],[OrderStatusID],os.[DisplayName], [Reason],[CustomerCode] from [tbl_CustomerOrders] co inner join dbo.tbl_OrderStatus os on co.[OrderStatusID] = os.[StatusID] where Type ='Front'", bSourceBack);

            dgFrontBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgFrontBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";
            dgFrontBumpers.Columns["DisplayName"].HeaderText = "Status";

            dgBackBumpers.DataSource = bSourceFront;
            GetData("select OrderID, [Color],[EmissionNorms],[MajorVariant],[BarCode],[OrderStatusID],os.[DisplayName], [Reason],[CustomerCode] from [tbl_CustomerOrders]  co inner join dbo.tbl_OrderStatus os on co.[OrderStatusID] = os.[StatusID] where Type ='Rear'", bSourceFront);

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

              lblFrontStats.Text = "New(" + newCount.ToString() + "), BC Printed(" + printedCount + "), Tested Ok(" + approvedCount + "), Rejected(" + rejectedCount + ")";
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

              lblRearStats.Text = "New(" + newCount.ToString() + "), BC Printed(" + printedCount + "), Tested Ok(" + approvedCount + "), Rejected(" + rejectedCount + ")";
             // lblRearStats.Text = "Rear Bumpers" + "(" + dgBackBumpers.Rows.Count + ")";
          }


          if (frnRowIndex < dgFrontBumpers.Rows.Count)
          {
              var nextRow = dgFrontBumpers.Rows[frnRowIndex];
              nextRow.Selected = true;
          }

          if (RearRowIndex < dgBackBumpers.Rows.Count)
          {
              var nextRow = dgBackBumpers.Rows[RearRowIndex];
              nextRow.Selected = true;
          }


            var print = GetRejectButton();

            var printBack = GetRejectButton();

            this.dgFrontBumpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            print});

            this.dgBackBumpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            printBack});

            
        }

        private static DataGridViewLinkColumn GetRejectButton()
        {
            var print = new System.Windows.Forms.DataGridViewLinkColumn();
            print.Text = "Reject";
           // print.Name = "lnkReject";

            print.UseColumnTextForLinkValue = true;
            print.LinkBehavior = LinkBehavior.SystemDefault;
            print.HeaderText = "";
            print.Name = "Reject";
            print.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 6.00f); 
            print.LinkColor = Color.Black;
            print.TrackVisitedState = true;
           // print.Text = "Print";
            print.UseColumnTextForLinkValue = true;
            print.DefaultCellStyle.SelectionBackColor = Color.White;
            //print.InheritedStyle = 


            return print;
        }

        private void GetData(string selectCommand, BindingSource bSource)
        {
            try
            {
                var table = new CommonRepository().Get(selectCommand, CommandType.Text);



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
            this.Close();
        }

        private void btnUploadOrder_Click(object sender, EventArgs e)
        {
            frmOrderUpload orderUpload = new frmOrderUpload(this);
            orderUpload.ShowDialog();
            orderUpload.FormClosed += frmOrder_FormClosed;

        }

        private void dgFrontBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
                        row.Cells[rejectIndex].Style.Font = new Font(FontFamily.GenericSansSerif, 10.00f);
                        row.Cells[rejectIndex].Style.BackColor = Color.White;
                        //        print.DefaultCellStyle.Font = 
                    }
                
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
            if (e.RowIndex >= 0)
            {
                frnRowIndex = e.RowIndex +1;
                var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                //green
                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

              //  row.Selected = true;
                //var rejectIndex = this.dgFrontBumpers.Columns["lnkReject"].Index;
                //row.Cells[rejectIndex].Selected=false;
                //row.Cells[rejectIndex].ba;
                // MessageBox.Show(row.Cells["OrderID"].Value.ToString());


                var rejectColumn = this.dgFrontBumpers.Columns["Reject"];
                if (rejectColumn != null)
                {
                    var rejectIndex = rejectColumn.Index;
                   
                    //        print.DefaultCellStyle.Font = 
                    if (e.ColumnIndex == rejectIndex)
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
            barcodePrint.ShowDialog();
        }

        private void dgBackBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
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


                    var rejectColumn = this.dgBackBumpers.Columns["Reject"];
                    if (rejectColumn != null)
                    {
                        var rejectIndex = rejectColumn.Index;

                        //        print.DefaultCellStyle.Font = 
                        if (e.ColumnIndex == rejectIndex)
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
                    row.Cells[rejectIndex].Style.Font = new Font(FontFamily.GenericSansSerif, 10.00f);
                    row.Cells[rejectIndex].Style.BackColor = Color.White;
                    //        print.DefaultCellStyle.Font = 
                }

            }

        }

        private void frmOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadGridData();
        }

        private void dgFrontBumpers_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                var cell = dgFrontBumpers.SelectedCells[0];
                //dgFrontBumpers.se
              


                if (cell !=null && cell.RowIndex >= 0)
                {
                    var row = dgFrontBumpers.Rows[cell.RowIndex];
                    row.Selected = true;
                    
                  //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

                    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                    var order = new PrintProduct();
                    order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
                    order.BarCode =  row.Cells["BarCode"].Value.ToString();
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

               
                //MessageBox.Show(cell.Value.ToString());
                //MessageBox.Show(cell.RowIndex.ToString());

            }
        }

        private void dgFrontBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    frnRowIndex = e.RowIndex + 1;
            //    var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
            //    //green
            //    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

            //    row.Selected = true;
            //    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());

                
            //    //  var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se

            //    //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
            //    var order = new PrintProduct();
            //    order.OrderID = Convert.ToInt64(row.Cells["OrderID"].Value.ToString());
            //    order.BarCode = row.Cells["BarCode"].Value.ToString();
            //    order.CustomerCode = row.Cells["CustomerCode"].Value.ToString();
            //    order.EmissionNorms = row.Cells["EmissionNorms"].Value.ToString();
            //    order.Color = row.Cells["Color"].Value.ToString();
            //    order.MajorVariant = row.Cells["MajorVariant"].Value.ToString();
            //    order.Type = "Front";


            //    //set print status
            //    SetPrintStatus(order);

            //}
        }

        private void dgBackBumpers_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                var cell = dgBackBumpers.SelectedCells[0];
                //dgFrontBumpers.se



                if (cell != null && cell.RowIndex >= 0)
                {
                  //  RearRowIndex = cell.RowIndex +1;
                    var row = dgBackBumpers.Rows[cell.RowIndex];
                    row.Selected = true;

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

        private void dgBackBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (e.RowIndex >= 0)
            {

                RearRowIndex = e.RowIndex + 1;
                //var connectionString = e.RowIndex +1 ;
                var row = dgBackBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                //green
                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

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

                        row.Selected = true;
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
}
