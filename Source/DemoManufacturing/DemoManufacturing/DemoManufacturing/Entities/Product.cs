using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoManufacturing.Entities
{
    public class Product
    {
        public long ProductID { get; set; }

        public int ProductVariant
        {
            get;
            set;
        }

        public int ProductModel
        {
            get;
            set;
        }
    }
}
