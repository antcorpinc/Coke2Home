using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RoomFacilityGroupListViewModel:BaseViewModel
    {
        public RoomFacilityGroupListViewModel()
        {
            this.FacilityGroupList = new List<RoomFacilityGroupViewModel>();
        }
        public IList<RoomFacilityGroupViewModel> FacilityGroupList { get; set; }
    }
}
