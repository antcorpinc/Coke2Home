using System.Collections.Generic;


namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RoomFacilityTypeViewModel
    {
        public RoomFacilityTypeViewModel()
        {
            this.FacilityList = new List<RoomFacilityViewModel>();
        }
        public int? Id { get; set; }

        public string Name { get; set; }

        public int FacilityGroupId { get; set; }
        public IList<RoomFacilityViewModel> FacilityList { get; }
    }
}
