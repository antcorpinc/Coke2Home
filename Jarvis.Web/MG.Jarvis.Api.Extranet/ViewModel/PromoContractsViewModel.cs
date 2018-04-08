using System;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class PromoContractsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string ContractType { get; set; }
    }
}
