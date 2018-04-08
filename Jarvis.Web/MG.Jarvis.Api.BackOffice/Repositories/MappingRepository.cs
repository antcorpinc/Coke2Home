using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System;
using MG.Jarvis.Api.BackOffice.Helper;
using Dapper;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class MappingRepository<T> : IMapping<T> where T : class
    {

        IConnection<T> _dalConnection = null;

        public MappingRepository(IConnection<T> connection)
        {
            _dalConnection = connection;
        }

        public async Task<BaseResult<bool>> InsertOrUpdateMapping(string storedProcedurename, DynamicParameters paramCollection)
        {
            return await _dalConnection.ExecuteStoredProcedureInsertUpdate(storedProcedurename, paramCollection);
        }

        public async Task<BaseResult<IEnumerable<dynamic>>> Mapping(string procedureName)
        {
            return await _dalConnection.ExecuteStoredProcedureDynamicModel(procedureName, null);
        }
    }
}