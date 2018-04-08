using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Reservation;
using MG.Jarvis.Model.Request.Reservation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IReservations
    {
        Task<BaseResult<List<Reservation>>> GetReservationDetail(ReservationDetailsById request);


    }
}
