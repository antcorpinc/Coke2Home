
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface ITest
    {
        Task<BaseResult<List<Hotel>>> GetHotelAndRooms();
        Task<BaseResult<List<Hotel>>> GetHotelAndRoomsByDapper();
        Task<BaseResult<dynamic>> GetHotelAndRoomsByDapperCustomModel();
        Task<BaseResult<long>> InsertHotelAndRoomsByEntity();
        Task<BaseResult<long>> InsertHotelAndRoomsByDapper();
        Task<BaseResult<bool>> UpdateHotelAndRoomsByDapper();
        Task<BaseResult<Hotel>> UpdateHotelAndRooms();
        Task<BaseResult<long>> InsertTestGuid(Test t);
        Task<BaseResult<IEnumerable<Hotel>>> ExecuteStoredProcedureWithMultipleDataSet();
    //    BaseResult<bool> InsertHotelByContact();
        // Task<BaseResult<bool>> ActivateUser(string userId= null);
    }
}
