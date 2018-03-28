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
        public void AddOrder(IList<CustomerOrder> orders,bool SaveMisMatchOrder = false)
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

            foreach (var order in orders)
            {
                using (var conn = new SqlConnection(connectionString))
                {


                    using (SqlCommand command = new SqlCommand("[dbo].[usp_SaveOrder]", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //                            @OrderID BIGINT,
                        //@Color nvarchar(50),
                        //@EmissionNorms nvarchar(100)
                        //,@MajorVariant nvarchar(500)
                        //,@Type nvarchar(20)
                        //,@CustomerCode nvarchar(150)
                        //,@IsBarCodePrinted BIT


                        command.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.BigInt) { Value = order.OrderID });
                        command.Parameters.Add(new SqlParameter("@Color", SqlDbType.NVarChar, 50) { Value = order.Color });
                        command.Parameters.Add(new SqlParameter("@EmissionNorms", SqlDbType.NVarChar, 100) { Value = order.EmissionNorms });
                        command.Parameters.Add(new SqlParameter("@MajorVariant", SqlDbType.NVarChar, 500) { Value = order.MajorVariant });
                        //command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = order.BumperType });
                        command.Parameters.Add(new SqlParameter("@OrderStatusID",SqlDbType.BigInt) { Value = order.OrderStatusID });
                       // command.Parameters.Add(new SqlParameter("@SaveMisMatchOrder", SqlDbType.Bit) { Value = SaveMisMatchOrder });
                        LoggedInUser.SetUserParameters(command);

                        conn.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }
        }

        public void UpdateMisMatchOrder(CustomerOrder order)
        { 
        
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;


                using (var conn = new SqlConnection(connectionString))
                {


                    using (SqlCommand command = new SqlCommand("[dbo].[usp_SaveMisMatchOrder]", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //                            @OrderID BIGINT,
                        //@Color nvarchar(50),
                        //@EmissionNorms nvarchar(100)
                        //,@MajorVariant nvarchar(500)
                        //,@Type nvarchar(20)
                        //,@CustomerCode nvarchar(150)
                        //,@IsBarCodePrinted BIT


                        command.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.BigInt) { Value = order.OrderID });
                        command.Parameters.Add(new SqlParameter("@Color", SqlDbType.NVarChar, 50) { Value = order.Color });
                        command.Parameters.Add(new SqlParameter("@EmissionNorms", SqlDbType.NVarChar, 100) { Value = order.EmissionNorms });
                        command.Parameters.Add(new SqlParameter("@MajorVariant", SqlDbType.NVarChar, 500) { Value = order.MajorVariant });
                        //command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = order.BumperType });
                        command.Parameters.Add(new SqlParameter("@OrderStatusID",SqlDbType.BigInt) { Value = order.OrderStatusID });
                        //command.Parameters.Add(new SqlParameter("@SaveMisMatchOrder", SqlDbType.Bit) { Value = SaveMisMatchOrder });
                        LoggedInUser.SetUserParameters(command);

                        conn.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
           
            
        }

        public void ChangePrintStatus(long OrderID)
        {
       
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                using (var conn = new SqlConnection(connectionString))
                {


                    using (SqlCommand command = new SqlCommand("[dbo].[usp_ChangePrintStatus]", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        
                        command.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.BigInt) { Value = OrderID });
                        LoggedInUser.SetUserParameters(command);

                        //command.Parameters.Add(new SqlParameter("@Color", SqlDbType.NVarChar, 50) { Value = order.Color });
                        //command.Parameters.Add(new SqlParameter("@EmissionNorms", SqlDbType.NVarChar, 100) { Value = order.EmissionNorms });
                        //command.Parameters.Add(new SqlParameter("@MajorVariant", SqlDbType.NVarChar, 500) { Value = order.MajorVariant });
                        //command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = order.BumperType });
                        //command.Parameters.Add(new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 150) { Value = order.CustomerCode });
                        //command.Parameters.Add(new SqlParameter("@IsBarCodePrinted", SqlDbType.Bit, 1000) { Value = order.IsBarCodePrinted });


                        conn.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                    }
                }
            }


        public bool ApproveRejectOrder(long OrderID,OrderStatus status, string reason )
        {

            var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {


                using (SqlCommand command = new SqlCommand("[dbo].[usp_ApproveRejectOrder]", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@OrderID", SqlDbType.BigInt) { Value = OrderID });
                    command.Parameters.Add(new SqlParameter("@StatusID", SqlDbType.BigInt) { Value = (long)status });
                    command.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 1000) { Value = reason });
                    LoggedInUser.SetUserParameters(command);

 
                    //command.Parameters.Add(new SqlParameter("@Color", SqlDbType.NVarChar, 50) { Value = order.Color });
                    //command.Parameters.Add(new SqlParameter("@EmissionNorms", SqlDbType.NVarChar, 100) { Value = order.EmissionNorms });
                    //command.Parameters.Add(new SqlParameter("@MajorVariant", SqlDbType.NVarChar, 500) { Value = order.MajorVariant });
                    //command.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 20) { Value = order.BumperType });
                    //command.Parameters.Add(new SqlParameter("@CustomerCode", SqlDbType.NVarChar, 150) { Value = order.CustomerCode });
                    //command.Parameters.Add(new SqlParameter("@IsBarCodePrinted", SqlDbType.Bit, 1000) { Value = order.IsBarCodePrinted });


                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    return result > 0;
                       // Console.WriteLine("Error inserting data into Database!");
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

