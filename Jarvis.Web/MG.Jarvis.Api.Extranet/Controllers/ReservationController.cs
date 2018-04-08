using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Reservation;
using MG.Jarvis.Model.Request.Reservation;
using MG.Jarvis.Model.Response.Reservation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class ReservationController : Controller
    {
        #region Private Member
        IReservations iReservation;
        #endregion Private Members
        public ReservationController(IReservations iReservation)
        {
            this.iReservation = iReservation;
        }
        
        [HttpPost]
        public async Task<IActionResult> GetReservationDetailsById([FromBody]ReservationDetailsById request)
        {
            BaseResult<List<Reservation>> reservationResult = new BaseResult<List<Reservation>>();
            if (request == null || string.IsNullOrEmpty(request.ReservationId))
            {
                reservationResult.Message = Constants.BadRequestErrorMessage.InvalidReservationId;
                return BadRequest();
            }
            reservationResult = await iReservation.GetReservationDetail(request).ConfigureAwait(false);
            if (reservationResult.IsError && reservationResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            BaseResult<ReservationDetail> reservationMaster = new BaseResult<ReservationDetail>
            {
                Result = ReservationResponseMapper.MapReservationResponse(reservationResult.Result)
            };
            return Ok(reservationMaster);
        }
    }
}