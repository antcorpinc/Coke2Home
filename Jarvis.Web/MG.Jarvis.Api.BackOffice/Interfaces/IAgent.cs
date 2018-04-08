using MG.Jarvis.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface IAgent
    {
        Task<BaseResult<List<Models.Response.Agent>>> Get();
    }
}
