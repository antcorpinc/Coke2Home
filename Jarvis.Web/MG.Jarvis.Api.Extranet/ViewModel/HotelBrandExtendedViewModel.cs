using MG.Jarvis.Api.Extranet.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelBrandExtendedViewModel : HotelBrandViewModel
    {
        public HotelBrandExtendedViewModel()
        {
            this.Hotels = new List<HotelDetailsExtendedViewModel>();
        }

        public IList<HotelDetailsExtendedViewModel> Hotels { get; }
        public bool IsExpanded { get; set; }
    }
}
