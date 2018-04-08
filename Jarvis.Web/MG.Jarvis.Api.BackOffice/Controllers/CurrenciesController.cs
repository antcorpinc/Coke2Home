using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Core.Logger;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class CurrenciesController : EntityBaseController<Currency,int>
    {
        public CurrenciesController(IMasterData<Currency,int> iMasterData, ILogger iLogger)
            : base(iMasterData, iLogger, "CurrenciesController")
        {            
        }

        public override async Task<IActionResult> Update([FromBody] Currency model)
        {
            if (model.Id > 0)
                return await base.Update(model);
            else
                return new BadRequestObjectResult(model);
        }
    }
}