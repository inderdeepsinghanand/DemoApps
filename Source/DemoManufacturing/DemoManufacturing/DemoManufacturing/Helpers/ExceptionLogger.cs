using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using BarCodePrinting.DataAccess;

namespace BarCodePrinting.Helpers
{
    public static class ExceptionLogger
    {
        public static void LogException(Exception ex,string screen)
        {
            using (var conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
            {
                using (var cmd = conn.CreateCommand())
                {
                    // var type = i % 2 == 0 ? 1 : 2;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO [EnterpriseApp].[dbo].[tbl_ErrorLogs]
                                       ([ErrorDate], [ErrorMessage],[Screen])
                                 VALUES
                                       (
                                       '" + DateTime.Now.ToString() + "',' " + ex.Message + "Stacktrace :" + ex.StackTrace
                                      + "','" + screen + "' );";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

    }
}
