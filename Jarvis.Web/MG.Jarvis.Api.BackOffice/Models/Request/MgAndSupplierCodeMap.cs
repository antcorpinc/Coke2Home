using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class MgAndSupplierCodeMap
    {
        public string MgEntityCode { get; set; }
        public string SupplierEntityCode { get; set; }      
        public string SupplierHotelCityCode { get; set; }
        public string SupplierHotelCountryCode { get; set; }
        public bool IsActive { get; set; }
        public string SupplierRoomTypeHotelCode { get; set; }
    }
}
