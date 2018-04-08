using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Interfaces;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class OccupancyCombinationsController : EntityBaseController<Core.Model.CacheBuilder.OccupancyCombinations, int>
    {
        private ILogger _iLogger;
        private string _className;        

        public OccupancyCombinationsController(IMasterData<Core.Model.CacheBuilder.OccupancyCombinations, int> iMasterData, ILogger iLogger)
            : base(iMasterData, iLogger, "OccupancyCombinationsController")
        {
            this._iLogger = iLogger;
            this._className = "OccupancyCombinationsController";           
        }

        public override async Task<IActionResult> Update([FromBody] Core.Model.CacheBuilder.OccupancyCombinations model)
        {
            if (model.Id > 0)
                return await base.Update(model);
            else
                return new BadRequestObjectResult(model);
        }
    }
}