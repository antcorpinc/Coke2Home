using System;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    using MG.Jarvis.Api.Extranet.Models.ViewModels;

    public class ContractHotelViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public HotelDetailsViewModel HotelDetailsViewModel { get; set; }
    }
}
