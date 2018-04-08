using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Model.Request.Reservation;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class ReservationRequestMapper
    {
        public static DynamicParameters CreateGetReservationRequest(ReservationDetailsById request)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.ReservationId, request.ReservationId);
            return paramCollection;
        }

   

      
    }
}
