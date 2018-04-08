using MG.Jarvis.Core.Model.Hotel;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelFacilityViewModel:BaseViewModel
    {
        public HotelFacilityViewModel()
        {
            this.FacilityGroupList = new List<HotelFacilityGroupViewModel>();
        }
        public IList<HotelFacilityGroupViewModel> FacilityGroupList { get;  }
    }
}
