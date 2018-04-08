using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Helper;
using Newtonsoft.Json;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class ChargeTypeController : EntityBaseController<ChargeTypes, int>
    {

        public ChargeTypeController(IMasterData<ChargeTypes,int> iMasterData, ILogger iLogger)
            : base(iMasterData, iLogger, "ChargeTypeController")
        {            
        }

        public override async Task<IActionResult> Update([FromBody] ChargeTypes model)
        {
            if (model.Id > 0)
                return await base.Update(model);
            else
                return new BadRequestObjectResult(model);
        }
    }
}