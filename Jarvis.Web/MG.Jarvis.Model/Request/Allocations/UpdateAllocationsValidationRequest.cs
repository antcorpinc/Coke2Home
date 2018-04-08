using System.Collections.Generic;
using System.Xml.Serialization;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    [XmlRoot(ElementName = "UpdateAllocationsValidationRequest")]
    public class UpdateAllocationsValidationRequest : RoomTypeByHotelAndChannelManger
    {
        public UpdateAllocationsValidationRequest()
        {
            RoomTypeRatePlanList = new List<RoomTypeRatePlan>();
        }
        [XmlElement(ElementName = "RoomTypeRatePlan")]
        public List<RoomTypeRatePlan> RoomTypeRatePlanList { get; private set; }
    }
}
