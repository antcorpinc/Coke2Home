using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    [XmlRoot(ElementName = "AllocationRestrictions")]
    public class AllocationRestrictions
    {
        [XmlAttribute(AttributeName = "IsClosedToArrival")]
        public bool IsClosedToArrival { set; get; }
        [XmlAttribute(AttributeName = "IsClosedToDeparture")]
        public bool IsClosedToDeparture{ set; get; }
        [XmlAttribute(AttributeName = "CutOffDays")]
        public short CutOffDays { get; set; }
        [XmlAttribute(AttributeName = "MinStay")]
        public short MinStay { get; set; }
        [XmlAttribute(AttributeName = "IsBlackOut")]
        public bool IsBlackOut { get; set; }
    }
}
