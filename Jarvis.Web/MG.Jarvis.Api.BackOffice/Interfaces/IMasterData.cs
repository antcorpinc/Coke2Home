using Dapper;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface IMasterData<T, U>
    {
        Task<BaseResult<long>> InsertEntity(T entity);
        Task<BaseResult<List<T>>> GetList();
        Task<BaseResult<T>> GetById(U id);
        Task<BaseResult<bool>> UpdateEntity(T entity);
        Task<BaseResult<IEnumerable<dynamic>>> ExecuteStoredProcedureDynamicModel(string storedProcedurename, DynamicParameters paramCollection);
        Task<BaseResult<bool>> RemoveEntity(U id);
        Task<BaseResult<bool>> InsertOrUpdateByProcedure(string storedProcedurename, DynamicParameters paramCollection);
        Task<BaseResult<IEnumerable<dynamic>>> GetByProcedure(string storedProcedurename, DynamicParameters paramCollection);

    }
}
