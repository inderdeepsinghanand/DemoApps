using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using DemoManufacturing.Entities;


using System.Configuration;

using System.Windows.Forms;


namespace DemoManufacturing.DataAccess
{
    public class CustomerOrderRepository
    {
        public void AddOrder(IList<CustomerOrder> orders)
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


            var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            foreach(var order in orders){
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                       // var type = i % 2 == 0 ? 1 : 2;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"INSERT INTO [dbo].[tbl_CustomerOrders]
                                       ([Color], [EmissionNorms]
                                       ,[MajorVariant]
                                       ,[Type],[CustomerCode],[IsBarCodePrinted])
                                 VALUES
                                       (
                                       '" + order.Color + "',' " + order.EmissionNorms 
                                          + "','" + order.MajorVariant 
                                          + "','" + order.BumperType + "','" + order.CustomerCode + "','"+ (order.IsBarCodePrinted?1:0).ToString() + "');";
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                    }
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

