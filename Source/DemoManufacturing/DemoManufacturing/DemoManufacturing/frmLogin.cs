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
using BarCodePrinting.DataAccess;
using BarCodePrinting.Entities;

namespace BarCodePrinting
{
    public partial class frmLogin : Form
    {

        private BindingSource bSourceFront = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        private frmDashboard masterForm = null;
        public frmLogin()
        {
            //masterForm = dash;
            InitializeComponent();
            txtUsername.Focus();
            //RefreshPage();

        }


        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtUsername.Text;
            var password = txtPassword.Text;
            string query = "Select tr.*,ISNULL(u.FirstName,'') + ISNULL(u.LastName,'') as Name  from [tbl_UserRights] tr inner join dbo.tbl_Users u on u.UserID = tr.UserID where u.Username = '{0}' AND u.[Password] = '{1}' ";

            var table = GetData(string.Format(query, userName, password));

            if (table != null && table.Rows.Count > 0)
            {

                txtUsername.Text = txtPassword.Text = "";
                //check screen access 
                //map screen access
                var rights = MapUserRights(table);
              //  LoggedInUser.ScreenRights = rights.ToList<UserRights>();
                LoggedInUser.UserID = rights[0].UserID;
                LoggedInUser.Name = rights[0].Name;
                //Dashboard aceess
                bool dashboardAccess = rights.Where(x => x.ScreenID == (long)Screens.Dashboard).Count() > 0 ? true : false;
                bool inspAccess = rights.Where(x => x.ScreenID == (long)Screens.Inspection).Count() > 0 ? true : false;
                //inspector access

                if (dashboardAccess) {
                    new frmDashboard().Show();
                    this.Hide();
                }
                else if (inspAccess)
                {
                    new frmInspDashboard().Show();
                    this.Hide();
                }
                else { }
            }
            else
            {
                MessageBox.Show("Invalid login credentials, Please try again");

            }
        }

        private IList<UserRights> MapUserRights(DataTable table)
        {
            IList<UserRights> rights = new List<UserRights>();

            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var right = new UserRights();
                    right.UserID = table.Columns.Contains("UserID") ? Convert.ToInt64(row["UserID"]) : 0; //  row.GetColumnsInError [
                    right.ScreenID = table.Columns.Contains("ScreenID") ? Convert.ToInt64(row["ScreenID"]) : 0;
                    right.Name = table.Columns.Contains("Name") ? row["Name"].ToString() : "";
                    rights.Add(right);
                }
            }
            return rights;
        }

        private DataTable GetData(string selectCommand)
        {
            try
            {
              //  DataTable tblResult = new DataTable();
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
            catch (SqlException ex)
            {
                MessageBox.Show("Exception Occured: " + ex.Message + "\n Trace:" + ex.StackTrace);
                return null;
            }
        }


    }
}
