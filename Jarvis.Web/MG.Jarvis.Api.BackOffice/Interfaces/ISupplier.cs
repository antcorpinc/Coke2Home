using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface ISupplier
    {
        Task<BaseResult<List<Models.Response.Supplier>>> Get();
        Task<BaseResult<Models.Response.Supplier>> GetById(int Id);
    }
}
