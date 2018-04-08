using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Reservation;
using MG.Jarvis.Model.Request.Reservation;
using MG.Jarvis.Model.Response.Reservation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class ReservationRepository : IReservations
    {

        #region Private Members
        IConnection<Reservation> iReseConnection;
        #endregion Private Members

        public ReservationRepository(IConnection<Reservation> iReseConnection)
        {
            this.iReseConnection = iReseConnection;
        }


        public async Task<BaseResult<List<Reservation>>> GetReservationDetail(ReservationDetailsById request)
        {
            DynamicParameters paramCollection = Mapper.Request.ReservationRequestMapper.CreateGetReservationRequest(request);
            return  await iReseConnection.ExecuteStoredProcedure(Constants.StoredProcedure.GetReservationDetails, paramCollection);
        }
    }
}
