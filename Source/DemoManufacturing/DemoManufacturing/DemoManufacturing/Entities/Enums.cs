using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoManufacturing.Entities
{
    public enum Enums
    {
        New = 1,
        BCPrinted,
        Approved,
        Rejected
    }

    public enum Screens
    {
        MasterUpload = 1,
        OrderUpload,
        Dashboard,
        Inspection,
    }
}
