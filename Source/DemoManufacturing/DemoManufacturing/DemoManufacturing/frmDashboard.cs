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

namespace DemoManufacturing
{
    public partial class frmDashboard : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bSourceBack = new BindingSource();
        private BindingSource bSourceFront = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Button reloadButton = new Button();
        private Button submitButton = new Button();

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


            LoadGridData();
        }

        private void LoadGridData()
        {

    //        [ProductID] [bigint] IDENTITY(1,1) NOT NULL,
    //--[Name] [nvarchar](500) NOT NULL,
    //[Color] [nvarchar](50) NULL,
    //[EmissionNorms] nvarchar(100),
    //[MajorVariant] [nvarchar](500) NULL,
    //[Type] [nvarchar](20) NULL,
    //[CustomerCode] [nvarchar](150) NOT NULL,
    //[BarCode] [nvarchar](1000) NULL,


            // Bind the DataGridView to the BindingSource
            // and load the data from the database.
            dgFrontBumpers.DataSource = bSourceBack;
            GetData("select [Color],[EmissionNorms],[MajorVariant] from tbl_Products where Type ='Front'", bSourceBack);

            dgFrontBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgFrontBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";

            dgBackBumpers.DataSource = bSourceFront;
            GetData("select [Color],[EmissionNorms],[MajorVariant] from tbl_Products where Type ='Rear'", bSourceFront);

            dgBackBumpers.Columns["EmissionNorms"].HeaderText = "Emission Norms";
            dgBackBumpers.Columns["MajorVariant"].HeaderText = "Major Variant";
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
            frmOrderUpload orderUpload = new frmOrderUpload();
            orderUpload.ShowDialog();

        }
    }
}
