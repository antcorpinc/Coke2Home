using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.Response.Reservation
{
    public class ReservationDetail : ReservationMaster
    {
        public ReservationDetail()
        {
            RoomList = new List<ReservationRoom>();
        }
        public  List<ReservationRoom> RoomList { get;private set;}
    }
}
