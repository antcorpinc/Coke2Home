using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelFacilityGroupViewModel : FieldViewModel
    {
        public HotelFacilityGroupViewModel()
        {
            this.HotelFacilityTypes = new List<HotelFacilityTypeViewModel>();
        }
       // public int FacilityGroupId { get; set; }

        public string FacilityGroupName { get; set; }

        public string IconPath { get; set; }
      
        public IList<HotelFacilityTypeViewModel> HotelFacilityTypes { get;  }

      //  public bool IsConfigurable { get; set; }

      //  public bool IsSelected { get; set; }


    }
}
