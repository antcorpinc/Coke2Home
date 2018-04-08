using Dapper;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface ICustomData<T,U>
    {
        Task<BaseResult<bool>> InsertOrUpdateByProcedure(string storedProcedurename, DynamicParameters paramCollection);
        Task<BaseResult<IEnumerable<dynamic>>> Get(string storedProcedurename, DynamicParameters paramCollection);                
        Task<BaseResult<T>> GetById(U id);
        Task<BaseResult<bool>> RemoveEntity(U id);
    }
}
