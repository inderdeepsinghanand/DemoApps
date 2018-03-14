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
    public class ProductRepository
    {
        public void AddProduct(Product prod)
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

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO [EnterpriseApp].[dbo].[tbl_Products]
                                       ([Name]
                                       ,[Variant]
                                       ,[BarCode])
                                 VALUES
                                       (
                                       'Front Wagon R Bumper'
                                       ,'LXI'
                                       ,'0002223111010202020');";
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

