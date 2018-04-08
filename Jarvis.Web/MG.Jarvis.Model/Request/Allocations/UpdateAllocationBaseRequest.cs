using System.Collections.Generic;
using System.Xml.Serialization;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    [XmlRoot(ElementName = "UpdateAllocationBaseRequest")]
    public class UpdateAllocationBaseRequest
    {
        public UpdateAllocationBaseRequest()
        {
            UpdateAllocationsRequest = new List<UpdateAllocationsRequest>();
        }
        [XmlElement(ElementName = "UpdateAllocationsValidationRequest")]
        public UpdateAllocationsValidationRequest UpdateAllocationsValidationRequest { get; set; }
        [XmlElement(ElementName = "UpdateAllocationsRequest")]
        public List<UpdateAllocationsRequest> UpdateAllocationsRequest { get; private set; }
    }
}
