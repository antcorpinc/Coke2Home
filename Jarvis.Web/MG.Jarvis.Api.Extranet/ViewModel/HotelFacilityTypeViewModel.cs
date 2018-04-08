using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelFacilityTypeViewModel
    {
        public HotelFacilityTypeViewModel()
        {
            this.FacilityList = new List<FacilityViewModel>();
        }
        public int  FacilityTypeId { get; set; }

        public string FacilityTypeName { get; set; }

        public int FacilityGroupId { get; set; }
        public IList<FacilityViewModel> FacilityList { get;  }

    }
}
