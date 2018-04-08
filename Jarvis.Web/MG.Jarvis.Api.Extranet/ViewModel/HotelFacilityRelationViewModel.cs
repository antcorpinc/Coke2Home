using MG.Jarvis.Core.Model.Hotel;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelFacilityRelationViewModel
    {
        public int HotelId { get; set; }
        public string CheckInTo { get; set; }
        public string CheckInFrom { get; set; }
        public string CheckOutTo { get; set; }
        public string CheckOutFrom { get; set; }
        public IList<HotelFacilityRelation> facilityList { get; set; }
    }
}
