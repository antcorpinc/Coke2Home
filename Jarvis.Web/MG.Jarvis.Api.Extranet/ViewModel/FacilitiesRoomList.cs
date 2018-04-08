namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class FacilitiesRoomList:BaseViewModel
    {
        public int RoomFacilityRelationId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; }
        public bool IsSelected { get; set; }
    }
}
