using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Models.Request;
using System.Data;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class ChannelManagerRequestMapper
    {
        #region Channel manager
        public static DynamicParameters CreateChannelMangerValidationRequest(RoomTypeByHotelAndChannelManger request)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.HotelCode, request.HotelCode);
            paramCollection.Add(Constants.StoredProcedureParameters.ChannelManagerId, request.ChannelManagerId);
            return paramCollection;
        }

        public static DynamicParameters CreateUpdateAllocationsValidationRequest(UpdateAllocationsValidationRequest request)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.HotelCode, request.HotelCode);
            paramCollection.Add(Constants.StoredProcedureParameters.ChannelManagerId, request.ChannelManagerId);

            DataTable dataTable = new DataTable("RoomRatePlan");
            dataTable.Columns.Add("RoomTypeCode", typeof(string));
            dataTable.Columns.Add("RatePlanCode", typeof(string));

            foreach (RoomTypeRatePlan  roomType in request.RoomTypeRatePlanList)
            {
                dataTable.Rows.Add(roomType.RoomTypeCode, roomType.RatePlanCode);
            }
            paramCollection.Add(Constants.StoredProcedureParameters.RoomTypeRatePlanList, request.RoomTypeRatePlanList);
            return paramCollection;
        }

        public static DynamicParameters CreateUpdateAllocationsRequest(UpdateAllocationsRequest request)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.HotelCode, request.HotelCode);
            paramCollection.Add(Constants.StoredProcedureParameters.ChannelManagerId, request.ChannelManagerId);
            // paramCollection.Add(Constants.StoredProcedureParameters.RoomTypeRatePlanList, request.RoomTypeRatePlanList);
            return paramCollection;
        }

        public static DynamicParameters CreateUpdateAllocationRatesRequest(UpdateAllocationRatesRequest request)
        {
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add(Constants.StoredProcedureParameters.HotelCode, request.HotelCode);
            paramCollection.Add(Constants.StoredProcedureParameters.ChannelManagerId, request.ChannelManagerId);
            // paramCollection.Add(Constants.StoredProcedureParameters.RoomTypeRatePlanList, request.RoomTypeRatePlanList);
            return paramCollection;
        }

        #endregion Channel manager


    }
}
