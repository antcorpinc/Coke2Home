using Dapper;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class MasterRepository<T,U> : IMasterData<T, U> where T : class
                                                           where U : struct
    {
        IConnection<T> _dalConnection = null;
      
        public MasterRepository(IConnection<T> connection)
        {  
            _dalConnection = connection;
        }        

        public async Task<BaseResult<List<T>>> GetList()
        {
            return await _dalConnection.GetList();
        }
        
        public async Task<BaseResult<long>> InsertEntity(T entity)
        {
            return await _dalConnection.InsertEntity(entity);
        }

        public async Task<BaseResult<bool>> UpdateEntity(T entity)
        {
            return await _dalConnection.UpdateEntityByDapper(entity);
        }

        public async Task<BaseResult<IEnumerable<dynamic>>> ExecuteStoredProcedureDynamicModel(string storedProcedurename, DynamicParameters paramCollection)
        {
            return await _dalConnection.ExecuteStoredProcedureDynamicModel(storedProcedurename, paramCollection);
        }
        
        public async Task<BaseResult<T>> GetById(U id)
        {
            return await _dalConnection.GetEntity<U>(id);
        }

        public async Task<BaseResult<bool>> RemoveEntity(U id)
        {
            var entity = await GetById(id);
            if (entity.IsError == true || entity.Result == null)
                return new BaseResult<bool> { IsError = true, Message = "Unable to fetch the entity for this id" };

           return await _dalConnection.RemoveEntity(entity.Result);
        }

        public async Task<BaseResult<bool>> InsertOrUpdateByProcedure(string storedProcedurename, DynamicParameters paramCollection)
        {
            return await _dalConnection.ExecuteStoredProcedureInsertUpdate(storedProcedurename, paramCollection);
        }

        public async Task<BaseResult<IEnumerable<dynamic>>> GetByProcedure(string storedProcedurename, DynamicParameters paramCollection)
        {
            return await _dalConnection.ExecuteStoredProcedureDynamicModel(storedProcedurename, paramCollection);
        }


    }
}
