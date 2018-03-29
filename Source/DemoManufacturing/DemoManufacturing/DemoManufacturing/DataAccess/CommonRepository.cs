using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DemoManufacturing.DataAccess
{
    class CommonRepository
    {

        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public DataTable Get(string selectCommand, System.Data.CommandType commandType, IList<SqlParameter> parameters = null)
        {
          //  DataTable tblResult = new DataTable();
            // Specify a connection string. Replace the given value with a 
            // valid connection string for a Northwind SQL Server sample
            // database accessible to your system.
            //var connectionString = "";// GetConnectionString();

            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(selectCommand, ConnectionStringHelper.GetConnectionString());

            // Create a command builder to generate SQL update, insert, and
            // delete commands based on selectCommand. These are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.SelectCommand.CommandType = commandType;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    dataAdapter.SelectCommand.Parameters.Add(param);
                }
            }

            dataAdapter.Fill(table);
            //foreach()
            return table;
        }

       
    }
}
