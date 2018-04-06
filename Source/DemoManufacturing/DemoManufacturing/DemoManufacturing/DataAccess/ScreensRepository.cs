using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using BarCodePrinting.Entities;


using System.Configuration;

using System.Windows.Forms;


namespace BarCodePrinting.DataAccess
{
    public class ScreensRepository
    {
        public void UpdateScreenReload(long screenID,bool reloadNeeded )
        {
            //using (var ctx = new ProductContext())
            //{
            //    try
            //    {
            //        ctx.Products.Add(prod);

            //        ctx.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //var connString = System.Configuration.Conn


            //var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            var reload = reloadNeeded ? "1" : "0";
                using (var conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                       // var type = i % 2 == 0 ? 1 : 2;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE [EnterpriseApp].[dbo].[tbl_Screens]
                                        SET [RefreshNeeded] =" + reload +
                                        "where [ScreenID] = " + screenID.ToString();
                                 //      ([Color], [EmissionNorms]
                                 //      ,[MajorVariant]
                                 //      ,[BarCode],[Type],[CustomerCode],[CreatedByUserId],[CreatedByName])
                                 //VALUES
                                 //      (
                                 //      '" + prod.Color + "',' " + prod.EmissionNorms 
                                 //         + "','" + prod.MajorVariant 
                                 //         + "','" + prod.BarCode + "','" 
                                 //         + prod.BumperType + "','" + prod.CustomerCode + "'," +LoggedInUser.UserID + ",'"+LoggedInUser.Name+"' );";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
                }
            
        }

        }

    }

    //public class ProductContext 
    //{

    //    public ProductContext() {

    //    }

    //    public DbSet<Product> Products { get; set; }

       

    //}

