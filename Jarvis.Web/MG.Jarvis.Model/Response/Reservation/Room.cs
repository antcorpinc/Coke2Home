using System.Collections.Generic;

namespace MG.Jarvis.Model.Response.Reservation
{
    public class ReservationRoom
    {
        public ReservationRoom()
        {
            RoomPriceDetail = new List<RoomPrice>();
            GuestDetail = new List<GuestDetails>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ReservationId { get; set; }
        public int TotalNumberOfGuest { get; set; }
        public int TotalNumberOfAdults { get; set; }
        public int TotalNumberOfChildren{ get; set; }
        public List<RoomPrice> RoomPriceDetail {get; private set;}
        public List<GuestDetails> GuestDetail {get; private set; }
    }
}
