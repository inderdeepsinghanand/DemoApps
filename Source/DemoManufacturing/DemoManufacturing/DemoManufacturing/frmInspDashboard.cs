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
    public partial class frmInspDashboard : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bSourceBack = new BindingSource();
        private BindingSource bSourceFront = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();

        public frmInspDashboard()
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
            GetData("select OrderID, [Color],[EmissionNorms],[MajorVariant],[IsBarCodePrinted],[BarCode],[OrderStatusID], [Reason] from [tbl_CustomerOrders] where Type ='Front'", bSourceBack);

            dgFrontBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgFrontBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";

            dgBackBumpers.DataSource = bSourceFront;
            GetData("select OrderID, [Color],[EmissionNorms],[MajorVariant],[IsBarCodePrinted],[BarCode],[OrderStatusID], [Reason] from [tbl_CustomerOrders] where Type ='Rear'", bSourceFront);

            dgBackBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgBackBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";


            dgFrontBumpers.Columns["OrderID"].Visible = false;
            dgBackBumpers.Columns["OrderID"].Visible = false;
            dgFrontBumpers.Columns["BarCode"].Visible = false;
            dgBackBumpers.Columns["BarCode"].Visible = false;

            dgFrontBumpers.Columns["IsBarCodePrinted"].Visible = false;
            dgBackBumpers.Columns["IsBarCodePrinted"].Visible = false;

            lblFrontBump.Text = "Front Bumpers" + "(" + dgFrontBumpers.Rows.Count + ")";
            lblRearBump.Text = "Rear Bumpers" + "(" + dgBackBumpers.Rows.Count + ")";



            //var print = GetPrintButton();

            //var printBack = GetPrintButton();

            //this.dgFrontBumpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //print});

            //this.dgBackBumpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            //printBack});

            
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
            print.DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 8.00f); 
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
                DataTable tblResult = new DataTable();
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
                
                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                //foreach()



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
            //frmOrderUpload orderUpload = new frmOrderUpload(this);
            //orderUpload.ShowDialog();
            //orderUpload.FormClosed += frmOrder_FormClosed;

        }

        private void dgFrontBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataView tb = dgFrontBumpers.DataS as DataTable;
            if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
            {
                DataGridViewRow row = dgFrontBumpers.Rows[e.RowIndex];// get you required index
                // check the cell value under your specific column and then you can toggle your colors

                    var cell = row.Cells["OrderStatusID"];
                    if (((long)cell.Value) == (long)OrderStatus.New)
                    {
                       // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                    }
                    else
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                
            }
        }

        private void dgFrontBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                //green
                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                row.Selected = true;
                // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
            }

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

        public void SetPrintStatus(long OrderID,string Barcode)
        {
            //new CustomerOrderRepository

            new CustomerOrderRepository().ChangePrintStatus(OrderID);

            //var barcode = "select * from tbl"

            frmBarcodePrinting barcodePrint = new frmBarcodePrinting(Barcode);
            barcodePrint.ShowDialog();
        }

        private void dgBackBumpers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dgBackBumpers.Columns["Print"].Index)
            {
                
            }
        }

        private void dgBackBumpers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgFrontBumpers.Rows != null && dgFrontBumpers.Rows.Count > 0)
            {
                DataGridViewRow row = dgBackBumpers.Rows[e.RowIndex];// get you required index
                // check the cell value under your specific column and then you can toggle your colors

                var cell = row.Cells["OrderStatusID"];
                if (((long)cell.Value) == (long)OrderStatus.New)
                {
                   // row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);
                }
                else
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);

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

                    //set print status
                    SetPrintStatus(Convert.ToInt64(row.Cells["OrderID"].Value.ToString()), "123");
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 140, 0);
                   // LoadGridData();
                    if (cell.RowIndex < dgFrontBumpers.Rows.Count)
                    {
                        var nextRow = dgFrontBumpers.Rows[cell.RowIndex +1];
                        nextRow.Selected =true;
                    }
                   // MessageBox.Show("Barcode printed successfully");
                    // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
                }

               
                //MessageBox.Show(cell.Value.ToString());
                //MessageBox.Show(cell.RowIndex.ToString());

            }
        }

        private void dgFrontBumpers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgFrontBumpers.Rows[e.RowIndex]; //dgFrontBumpers.se
                //green
                //  row.DefaultCellStyle.BackColor = Color.FromArgb(127, 186, 0);

                row.Selected = true;
                // MessageBox.Show(row.Cells["OrderID"].Value.ToString());
            }
        }
    }
}
