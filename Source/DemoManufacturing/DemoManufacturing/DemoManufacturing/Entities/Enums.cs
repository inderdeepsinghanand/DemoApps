using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarCodePrinting.Entities
{
    public enum OrderStatus
    {
        New = 1,
        BCPrinted,
        Approved,
        Rejected,
        Skip
    }

    public enum Screens
    {
        MasterUpload = 1,
        OrderUpload,
        Dashboard,
        Inspection,
    }
}
