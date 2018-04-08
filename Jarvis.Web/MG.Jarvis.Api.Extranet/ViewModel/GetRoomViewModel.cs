namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class GetRoomViewModel
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomName { get; set; }
        public int NoOfRooms { get; set; }
        public bool IsFreeSale { get; set; }
        public int NoOfGuests { get; set; }
        public bool IsActive { get; set; }
        public string RoomCode { get; set; }
    }
}
