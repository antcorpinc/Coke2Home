using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.Enums
{
    [Flags]
    public enum UserType
    {        
        MG = 1,
        Hotel = 2,
        Supplier=4,
        Agency = 8
    }
}
