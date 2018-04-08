using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    public class UpdateAllocationRatesBaseRequest
    {
      //  private readonly IList<UpdateAllocationRatesRequest> _updateAllocationsRequest;

        public UpdateAllocationRatesBaseRequest()
        {
            UpdateAllocationsRateRequest = new List<UpdateAllocationRatesRequest>();
        }


        public UpdateAllocationsValidationRequest UpdateAllocationsValidationRequest { get; set; }
        public List<UpdateAllocationRatesRequest> UpdateAllocationsRateRequest { get;  private set; }
    }
}
