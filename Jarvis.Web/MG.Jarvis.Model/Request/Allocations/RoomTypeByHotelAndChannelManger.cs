using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    public class RoomTypeByHotelAndChannelManger
    {
        //List<RoomTypeRatePlan> RoomTypeRatePlanList;

        [XmlAttribute(AttributeName = "HotelCode")]
        public string HotelCode { get; set; }
        [XmlAttribute(AttributeName = "ChannelManagerId")]
        public int ChannelManagerId { get; set; }

    }
}
