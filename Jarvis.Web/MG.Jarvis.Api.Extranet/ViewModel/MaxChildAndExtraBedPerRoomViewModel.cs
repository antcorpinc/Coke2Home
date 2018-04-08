namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class MaxChildAndExtraBedPerRoomViewModel : BaseViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int NoOfGuest { get; set; }
        public int BedCount { get; set; }
        public int? MaxChildren { get; set; }
        public int? ExtraBedCount { get; set; }
    }
}
