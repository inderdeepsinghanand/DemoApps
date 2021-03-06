﻿using System;
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
using BarCodePrinting.DataAccess;
using BarCodePrinting.Entities;
using BarCodePrinting.Helpers;

namespace BarCodePrinting
{
    public partial class frmOrderUpload : Form
    {

        private BindingSource bSourceFront = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        private frmDashboard masterForm = null;
        public frmOrderUpload( frmDashboard dash)
        {
            masterForm = dash;
            InitializeComponent();
            RefreshPage();

        }

        private void RefreshPage()
        {
            try
            {
                if(dataGridView1.Rows.Count > 0)
                    dataGridView1.Rows[0].Selected = true;

                GetData("select OrderID,Color,EmissionNorms, MajorVariant,Type , CustomerCode from [tbl_CustomerOrdersMisMatch] ", bSourceFront);
                dataGridView1.DataSource = bSourceFront;

                dataGridView1.Columns["OrderID"].Visible = false;

                BindCombo("Select distinct Color as [Key] from tbl_Products", cmbColor);

                BindCombo("Select distinct [EmissionNorms] as [Key] from tbl_Products", cmbEmissionNorms);

                BindCombo("Select distinct [MajorVariant] as [Key] from tbl_Products", cmbMajorVariant);

                BindCombo("Select distinct [Type] as [Key] from tbl_Products", cmbBumperType);
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
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
            catch (Exception ex)
            {
                LogException(ex);
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
            try
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

                            GetData("select OrderID,Color,EmissionNorms, MajorVariant,Type , CustomerCode from [tbl_CustomerOrdersMisMatch] ", bSourceFront);
                            dataGridView1.DataSource = bSourceFront;

                            MessageBox.Show("Orders uploaded successfully, Invalid orders displayed below in grid.");

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
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public void SaveToDb(DataTable dt)
        {
            IList<CustomerOrder> orders = new List<CustomerOrder>();
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (i == 0) { }
                else
                {

                    CustomerOrder order = new CustomerOrder();
                    //Sr. No	Color	EmissionNorms	MajorVariant	Type	CustomerCode	BarCode

                    order.Color = dr["F2"].ToString();
                    order.EmissionNorms = dr["F3"].ToString();
                    order.MajorVariant = dr["F4"].ToString();
                   // order.BumperType = dr["F5"].ToString();
                    //order.CustomerCode = dr["F6"].ToString();
                   //[o order.IsBarCodePrinted = false;

                    orders.Add(order);
                }
                i++;
            }

            new CustomerOrderRepository().AddOrder(orders);
        }

        public DataTable ReadExcel(string fileName, string fileExt)
        {
            try{
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
             }
            catch (Exception ex)
            {
                LogException(ex);
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

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try{
            //var rowIndex = e.RowIndex;
            //var row = dataGridView1.Rows[rowIndex];
            //if (row != null)
            //{
            //    //if(
            //    var orderID = dataGridView1.Columns.Contains("OrderID") ? row.Cells["OrderID"].Value.ToString() : "";
            //    if (!string.IsNullOrEmpty(orderID))
            //    {
            //        lblProductID.Text = dataGridView1.Columns.Contains("OrderID") ? row.Cells["OrderID"].Value.ToString() : "";
            //        cmbEmissionNorms.SelectedValue = dataGridView1.Columns.Contains("EmissionNorms") ? row.Cells["EmissionNorms"].Value : "";
            //        cmbColor.SelectedValue = dataGridView1.Columns.Contains("Color") ? row.Cells["Color"].Value : "";
            //        cmbMajorVariant.SelectedValue = dataGridView1.Columns.Contains("MajorVariant") ? row.Cells["MajorVariant"].Value : "";
            //        cmbBumperType.SelectedValue = dataGridView1.Columns.Contains("Type") ? row.Cells["Type"].Value : "";
            //        // txtCustomerCode.Text = row.Cells["CustomerCode"].Value.ToString();
            //        // txtBarCode.Text = row.Cells["BarCode"].Value.ToString();
            //    }
            //}
            //}
            //catch (Exception ex)
            //{
            //    LogException(ex);
            //}
        }

        private void lblProductID_TextChanged(object sender, EventArgs e)
        {
            var productId = Convert.ToInt64(lblProductID.Text);
            if (productId > 0)
            {
                btnSave.Text = "Save";
            }
            else
                btnSave.Text = "Add";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                //IList<CustomerOrder> orders

                CustomerOrder order = new CustomerOrder();
                order.OrderID = Convert.ToInt64(lblProductID.Text);
                order.MajorVariant = cmbMajorVariant.SelectedValue != null ? cmbMajorVariant.SelectedValue.ToString() : "";
                order.EmissionNorms = cmbEmissionNorms.SelectedValue != null ? cmbEmissionNorms.SelectedValue.ToString() : "";
                order.BumperType = cmbBumperType.SelectedValue != null ? cmbBumperType.SelectedValue.ToString() : "";
                order.Color = cmbColor.SelectedValue != null ? cmbColor.SelectedValue.ToString() : "";
                order.CustomerCode = txtCustomerCode.Text;

                new CustomerOrderRepository().UpdateMisMatchOrder(order);
                RefreshPage();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        private void frmOrderUpload_FormClosed(object sender, FormClosedEventArgs e)
        {
            masterForm.LoadGridData();
        }

        public void LogException(Exception ex, bool showMessage = true)
        {

            ExceptionLogger.LogException(ex, "Order Upload");

            if (showMessage)
                MessageBox.Show("Error occured during execution, please contact administrator for details");
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (e.StateChanged == DataGridViewElementStates.Selected)
                {
                    //var rowIndex = e.RowIndex;
                    var row = e.Row;
                    if (row != null)
                    {
                        //if(
                        var orderIdCell = row.Cells["OrderID"];
                        var ENCell = row.Cells["EmissionNorms"];
                        var colorCell = row.Cells["Color"];
                        var MVCell = row.Cells["MajorVariant"];
                        var typeCell = row.Cells["Type"];
                        if (orderIdCell != null && ENCell != null && colorCell != null && MVCell != null &&
                            orderIdCell.Value != null && ENCell.Value != null && colorCell.Value != null && MVCell.Value != null)
                        {
                            var orderID = dataGridView1.Columns.Contains("OrderID") ? row.Cells["OrderID"].Value.ToString() : "";
                            if (!string.IsNullOrEmpty(orderID))
                            {
                                lblProductID.Text = dataGridView1.Columns.Contains("OrderID") ? row.Cells["OrderID"].Value.ToString() : "";
                                cmbEmissionNorms.SelectedValue = dataGridView1.Columns.Contains("EmissionNorms") ? row.Cells["EmissionNorms"].Value : "";
                                cmbColor.SelectedValue = dataGridView1.Columns.Contains("Color") ? row.Cells["Color"].Value : "";
                                cmbMajorVariant.SelectedValue = dataGridView1.Columns.Contains("MajorVariant") ? row.Cells["MajorVariant"].Value : "";
                                cmbBumperType.SelectedValue = dataGridView1.Columns.Contains("Type") ? row.Cells["Type"].Value : "";
                                // txtCustomerCode.Text = row.Cells["CustomerCode"].Value.ToString();
                                // txtBarCode.Text = row.Cells["BarCode"].Value.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }
    }
}
