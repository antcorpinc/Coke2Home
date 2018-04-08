using System;

namespace MG.Jarvis.Model.Response.Reservation
{
    public class ReservationMaster
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public HotelDetail Hotel { get; set; }
        public ReservationCurrency Currency { get; set; }

        public string ReservationId { get; set; }
        public string MGReservationId { get; set; }
    }
}
