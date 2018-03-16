using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoManufacturing.Entities
{
    public class Product
    {
        public long ProductID { get; set; }
        public string Color { get; set; }
        public string EmissionNorms { get; set; }
        public string BumperType { get; set; }
        public string CustomerCode { get; set; }
        public string BarCode { get; set; }

        public string MajorVariant
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
