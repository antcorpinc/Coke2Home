using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface IBranch
    {
        Task<BaseResult<List<Models.Response.Branch>>> Get(int? agencyId);
    }
}
