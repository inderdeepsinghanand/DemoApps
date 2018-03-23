using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoManufacturing.Entities
{
    public class CustomerOrder
    {
        public long OrderID { get; set; }
        public string Color { get; set; }
        public string EmissionNorms { get; set; }
        public string BumperType { get; set; }
        public string CustomerCode { get; set; }
        public bool IsBarCodePrinted { get; set; }

        public string MajorVariant
        {
            get;
            set;
        }
        
    }
}
