using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractListingViewModel
    {
        public ContractListingViewModel()
        {
            Contacts = new List<ContactDetailsViewModel>();
            PromoContracts = new List<PromoContractsViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string ContractType { get; set; }
        public IList<ContactDetailsViewModel> Contacts { get; set; }
        public IList<PromoContractsViewModel> PromoContracts { get; set; }
    }
}
