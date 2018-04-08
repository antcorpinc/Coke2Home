using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RoomFacilityGroupViewModel : FieldViewModel
    {

        public RoomFacilityGroupViewModel()
        {
            this.RoomFacilityTypes = new List<RoomFacilityTypeViewModel>();
        }
        //public int FacilityGroupId { get; set; }

        public string FacilityGroupName { get; set; }
        public string  IconPath { get; set; }

        public IList<RoomFacilityTypeViewModel> RoomFacilityTypes { get; }
    }
}
