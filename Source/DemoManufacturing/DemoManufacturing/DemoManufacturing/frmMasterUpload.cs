using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DemoManufacturing.DataAccess;
using DemoManufacturing.Entities;

namespace DemoManufacturing
{
    public partial class frmMasterUpload : Form
    {

        private BindingSource bSourceFront = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public frmMasterUpload()
        {
            InitializeComponent();

            ReLoadGrid();

           // BindComboBoxes();
        }

        private void ReLoadGrid()
        {
            GetData(@"select [ProductID]
      ,[Color]
      ,[EmissionNorms]
      ,[MajorVariant]
      ,[Type]
      ,[CustomerCode]
      ,[BarCode] from tbl_Products ", bSourceFront);
            dataGridView1.DataSource = bSourceFront;

            dataGridView1.Columns["ProductID"].Visible = false;

           
            BindComboBoxes();

        }

        private void BindComboBoxes()
        {
            BindCombo("Select distinct Color as [Key] from tbl_Products", cmbColor1);

            BindCombo("Select distinct [EmissionNorms] as [Key] from tbl_Products", cmbEmission);

            BindCombo("Select distinct [MajorVariant] as [Key] from tbl_Products", cmbMajorVariant1);

            BindCombo("Select distinct [Type] as [Key] from tbl_Products", cmbBumperType1);
        }

        public void BindCombo(string selectCommand, ComboBox cmb)
        {

            var dt = FetchFromDb(selectCommand);

            cmb.ValueMember = "Key";
            cmb.DisplayMember = "Key";
            var row = dt.NewRow();
            row[0] = "Please select";
            dt.Rows.InsertAt(row, 0);
            cmb.DataSource = dt;
            // cmb.Items.Insert(0, new object[] { 0, "Please select" });  
        }


        private void GetData(string selectCommand, BindingSource bSource)
        {
            try
            {
                DataTable tblResult = new DataTable();
                tblResult = FetchFromDb(selectCommand);

               // tblResult.Rows.InsertAt(tblResult.NewRow(), 0);
                bSource.DataSource = tblResult;

                // Resize the DataGridView columns to fit the newly loaded content.
                //dataGridView1.AutoResizeColumns(
                //    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message + "\n Trace:" + ex.StackTrace);
            }
        }

        private DataTable FetchFromDb(string selectCommand)
        {
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


        private void btnMasterUpload_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            // OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (fdMasterUpload.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = fdMasterUpload.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = new DataTable();
                        dtExcel = ReadExcel(filePath, fileExt); //read excel file 

                        SaveToDb(dtExcel);
                        // object dataGridView1;
                        //dataGridView1.Visible = true;
                        //dataGridView1.DataSource = dtExcel;

                        ReLoadGrid();

                        MessageBox.Show("Master data uploaded successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        public void SaveToDb(DataTable dt)
        {
            IList<Product> products = new List<Product>();
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 0) { }
                else
                {

                    Product prod = new Product();
                    //Sr. No	Color	EmissionNorms	MajorVariant	Type	CustomerCode	BarCode

                    prod.Color = dr["F2"].ToString();
                    prod.EmissionNorms = dr["F3"].ToString();
                    prod.MajorVariant = dr["F4"].ToString();
                   // prod.BumperType = dr["F5"].ToString();
                    prod.CustomerCode = dr["F5"].ToString();
                    prod.BarCode = dr["F6"].ToString();

                    products.Add(prod);
                }
                i++;
            }

            new ProductRepository().AddProduct(products);
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            //string conn = string.Empty;
            //DataTable dtexcel = new DataTable();
            //if (fileExt.CompareTo(".xls") == 0)
            //    conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            //else
            //    conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 2007  
            //using (OleDbConnection con = new OleDbConnection(conn))
            //{
            //    try
            //    {
            //        OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
            //        oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
            //    }
            //    catch { }
            //}
            //return dtexcel;

            //  var fileName = @"C:\ExcelFile.xlsx";
            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text\""; ;
            using (var conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                var sheets = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [" + sheets.Rows[0]["TABLE_NAME"].ToString() + "] ";

                    var adapter = new OleDbDataAdapter(cmd);
                    var ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }


            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblPrintBarCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PrintProduct product = new PrintProduct();
            var productId = Convert.ToInt64(lblProductID.Text);
            if (productId > 0)
            {
               // lblProductID.Text = row.Cells["ProductID"].Value.ToString();
               product.EmissionNorms =  cmbEmission.SelectedValue.ToString() ;//= row.Cells["EmissionNorms"].Value;
               product.Color =  cmbColor1.SelectedValue.ToString(); //= row.Cells["Color"].Value;
               product.MajorVariant = cmbMajorVariant1.SelectedValue.ToString();// = row.Cells["MajorVariant"].Value;
               product.Type = cmbBumperType1.SelectedValue.ToString(); //= row.Cells["Type"].Value;
               product.CustomerCode = txtCustCode1.Text; //= row.Cells["CustomerCode"].Value.ToString();
              product.BarCode =  txtBarCode1.Text ;//= row.Cells["BarCode"].Value.ToString();

              PrintBarcode(product);
            }
            //else { 
            ////do 
            
            //}
            
        }


        public void PrintBarcode(PrintProduct order)
        {
           

            frmBarcodePrinting barcodePrint = new frmBarcodePrinting(order, null);
            barcodePrint.ShowDialog();
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var row = dataGridView1.Rows[rowIndex];

            var barcode = row.Cells["BarCode"].Value.ToString();
            if (!string.IsNullOrEmpty(barcode))
            {
                lblProductID.Text = row.Cells["ProductID"].Value.ToString();
                cmbEmission.SelectedValue = row.Cells["EmissionNorms"].Value;
                cmbColor1.SelectedValue = row.Cells["Color"].Value;
                cmbMajorVariant1.SelectedValue = row.Cells["MajorVariant"].Value;
                cmbBumperType1.SelectedValue = row.Cells["Type"].Value;
                txtCustCode1.Text = row.Cells["CustomerCode"].Value.ToString();
                txtBarCode1.Text = row.Cells["BarCode"].Value.ToString();
            }
        }

        private void lblProductID_TextChanged(object sender, EventArgs e)
        {
            var productId = Convert.ToInt64(lblProductID.Text);
            if (productId > 0)
            {
                btnAdd.Text = "Save";
            }
            else
            {
                btnAdd.Text = "Add";
                lnkPrint.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Specify a connection string. Replace the given value with a 
            // valid connection string for a Northwind SQL Server sample
            // database accessible to your system.
            //var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;


            using (SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[usp_SaveProduct]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;



                    command.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.BigInt) { Value = Convert.ToInt64(lblProductID.Text) });
                    command.Parameters.Add(new SqlParameter("@Color", SqlDbType.NVarChar, 50) { Value = cmbColor1.SelectedValue });
                    command.Parameters.Add(new SqlParameter("@EmissionNorms", SqlDbType.NVarChar, 100) { Value = cmbEmission.SelectedValue });
                    command.Parameters.Add(new SqlParameter("@MajorVariant", SqlDbType.NVarChar, 500) { Value = cmbMajorVariant1.SelectedValue });
                    command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = cmbBumperType1.SelectedValue });
                    command.Parameters.Add(new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 150) { Value = txtCustCode1.Text });
                    command.Parameters.Add(new SqlParameter("@BarCode", SqlDbType.NVarChar, 1000) { Value = txtBarCode1.Text });
                    LoggedInUser. SetUserParameters(command);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }

            ReLoadGrid();

            MessageBox.Show("Master record saved successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetEdit();       
        }

        private void ResetEdit()
        {
            cmbEmission.SelectedValue = "Please select";
            cmbColor1.SelectedValue = cmbMajorVariant1.SelectedValue = cmbBumperType1.SelectedValue = "Please select";
            txtCustCode1.Text = txtBarCode1.Text = "";
            lblProductID.Text = "0";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
