using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class CancellationPolicyClausesViewModel : BaseViewModel
    {
        public int CancellationPolicyClausesId { get; set; }
        public int DaysBeforeArrival { get; set; }
        public decimal PercentageCharge { get; set; }
        public int CancellationChargesId { get; set; }
        public int CancellationPolicyId { get; set; }
    }
}
