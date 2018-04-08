using MG.Jarvis.Api.Extranet.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelDetailsExtendedViewModel: HotelDetailsViewModel
    {
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}
