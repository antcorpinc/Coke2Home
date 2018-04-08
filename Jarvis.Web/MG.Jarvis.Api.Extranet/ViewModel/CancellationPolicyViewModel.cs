using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class CancellationPolicyViewModel : BaseViewModel
    {
        public int CancellationPolicyId { get; set; }
        public int CancellationPolicyTypeId { get; set; }
        public string CancellationPolicyTypeName { get; set; }
        public bool IsNoShowCharges { get; set; }
        public int? NoShowCancellationChargesId { get; set; }
        public string CancellationChargesName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public List<CancellationPolicyClausesViewModel>  CancellationPolicyClausesViewModelList { get; set; }
    }
}
