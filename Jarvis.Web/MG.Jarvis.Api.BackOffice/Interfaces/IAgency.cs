﻿using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Interfaces
{
    public interface IAgency
    {
        Task<BaseResult<List<Models.Response.Agency>>> Get();
    }
}
