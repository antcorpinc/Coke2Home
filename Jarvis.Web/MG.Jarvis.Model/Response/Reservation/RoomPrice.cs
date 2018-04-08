using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.Response.Reservation
{
    public class RoomPrice
    {
        public DateTime Date { get; set; }
        public int RoomReservationId { get; set; }
        public double SellingPrice { get; set; }
        public double ExtraBedPrice { get; set; }
        public double BasePrice { get; set; }
        public double MealPrice { get; set; }
    }
}
