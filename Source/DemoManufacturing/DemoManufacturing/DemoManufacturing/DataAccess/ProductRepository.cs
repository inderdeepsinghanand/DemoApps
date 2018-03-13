using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using DemoManufacturing.Entities;

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


            using (var conn = new SqlConnection("DBConnectionString"))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = 

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

