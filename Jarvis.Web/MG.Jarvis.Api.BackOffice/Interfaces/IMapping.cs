using Dapper;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface IMapping<T> where T : class
    {
        Task<BaseResult<IEnumerable<dynamic>>> Mapping(string procedureName);

        Task<BaseResult<bool>> InsertOrUpdateMapping(string storedProcedurename, DynamicParameters paramCollection);
    }
}