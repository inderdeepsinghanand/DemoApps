using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BarCodePrinting.Entities
{
    public static class LoggedInUser
    {
        public static long UserID { get; set; }

       // public static List<UserRights> ScreenRights { get; set; }

        public static string Name { get; set; }

        public static void SetUserParameters(IDbCommand command) {
            if (command != null) {
                command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.BigInt) { Value = LoggedInUser.UserID });
                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 150) { Value = LoggedInUser.Name });
            }
        
        }
    }
}
