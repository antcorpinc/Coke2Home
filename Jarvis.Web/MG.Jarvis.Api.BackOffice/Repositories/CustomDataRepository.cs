using MG.Jarvis.Api.BackOffice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.DAL.Interfaces;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class CustomDataRepository<T, U> : ICustomData<T, U> where T : class
                                                                where U : struct
    {
        IConnection<T> _dalConnection = null;
        public CustomDataRepository(IConnection<T> connection)
        {
            _dalConnection = connection;
        }

        public async Task<BaseResult<bool>> InsertOrUpdateByProcedure(string storedProcedurename, DynamicParameters paramCollection)
        {
            return await _dalConnection.ExecuteStoredProcedureInsertUpdate(storedProcedurename, paramCollection);
        }

        public async Task<BaseResult<IEnumerable<dynamic>>> Get(string storedProcedurename, DynamicParameters paramCollection)
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
    }
}
