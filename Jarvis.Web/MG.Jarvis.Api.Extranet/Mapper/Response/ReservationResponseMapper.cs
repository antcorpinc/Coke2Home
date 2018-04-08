using MG.Jarvis.Core.Model.Reservation;
using MG.Jarvis.Model.Response.Reservation;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class ReservationResponseMapper
    {
        public static ReservationDetail MapReservationResponse(List<Reservation> reservationDetail)
        {
            ReservationDetail reservationMaster = new ReservationDetail();

            AutoMapper.Mapper.Map<Reservation, ReservationDetail>(reservationDetail[0], reservationMaster);
            List<Reservation> distinctRoom = reservationDetail
                                                           // .Select(o => new Reservation{ RoomCode =  o.RoomCode, RoomName = o.RoomName,RoomReservationId = o.RoomReservationId })
                                                           //.Distinct().ToList();
                                                           .GroupBy(o => new { o.RoomCode, o.RoomName, o.RoomReservationId })
                                                           .Select(o => o.FirstOrDefault()).ToList();
            AutoMapper.Mapper.Map<List<Reservation>, List<ReservationRoom>>(distinctRoom, reservationMaster.RoomList);
            foreach (ReservationRoom room in reservationMaster.RoomList)
            {
                List<Reservation> roomPrice = //from r in reservationDetail
                                            //                            where r.RoomReservationId == room.ReservationId
                                            //                            select (new RoomPrice{ BasePrice = r.BasePrice, SellingPrice= r.SellingPrice, MealPrice= r.MealPrice, ExtraBedPrice= r.ExtraBedPrice });
                                            reservationDetail.Where(a => a.RoomReservationId == room.ReservationId)
                                            // .GroupBy(r=> new RoomPrice { Date = r.BookingDate,
                                            //    BasePrice = r.BasePrice, SellingPrice = r.SellingPrice, MealPrice = r.MealPrice, ExtraBedPrice = r.ExtraBedPrice })
                                            //.Distinct().ToList<RoomPrice>(); ;
                                            .GroupBy(r => new  {r.BookingDate,r.BasePrice,r.SellingPrice,r.MealPrice,r.ExtraBedPrice })
                                            .Select(r => r.FirstOrDefault()).ToList();
                AutoMapper.Mapper.Map<List<Reservation>, List<RoomPrice>>(roomPrice, room.RoomPriceDetail);

                List<Reservation> guestDetails = //from r in reservationDetail
                                              //                            where r.RoomReservationId == room.ReservationId
                                              //                            select (new RoomPrice{ BasePrice = r.BasePrice, SellingPrice= r.SellingPrice, MealPrice= r.MealPrice, ExtraBedPrice= r.ExtraBedPrice });
                                            reservationDetail.Where(a => a.RoomReservationId == room.ReservationId)
                                            // .GroupBy(r=> new RoomPrice { Date = r.BookingDate,
                                            //    BasePrice = r.BasePrice, SellingPrice = r.SellingPrice, MealPrice = r.MealPrice, ExtraBedPrice = r.ExtraBedPrice })
                                            //.Distinct().ToList<RoomPrice>(); ;
                                            .GroupBy(r => new { r.BookingDate ,r.FirstName,r.LastName})
                                            .Select(r => r.FirstOrDefault()).ToList();

                AutoMapper.Mapper.Map<List<Reservation>, List<GuestDetails>>(guestDetails, room.GuestDetail);
                // room.RoomPriceDetail.AddRange(roomPrice);
            }

            return reservationMaster;
        }
    }
}
