using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RoomFacilityViewModel:BaseViewModel
    {
        public RoomFacilityViewModel()
        {
            this.FacilitiesRoomList = new List<FacilitiesRoomList>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FacilityTypeId { get; set; }
        public int FacilityGroupId { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public IList<FacilitiesRoomList> FacilitiesRoomList { get; }
    }
}
