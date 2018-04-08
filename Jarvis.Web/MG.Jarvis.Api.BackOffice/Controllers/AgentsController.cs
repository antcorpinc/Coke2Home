using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Model.Agency;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Logger;
using Newtonsoft.Json;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class AgentsController : CustomBaseController<Models.Request.Agent, int>
    {
        private IAgent _iAgentRepository;
        private ILogger _iLogger;

        public AgentsController(IMasterData<Models.Request.Agent, int> iMasterData, ILogger iLogger, IAgent agentRepository)
            : base(iMasterData, iLogger, "Agents")
        {
            _iLogger = iLogger;
            _iAgentRepository = agentRepository;
        }

        /// <summary>
        /// Creates a new agent.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.Agent model)
        {
            base.StoreProcedure = Constants.StoredProcedure.InsertAgent;
            return await base.Create(model);
        }

        /// <summary>
        /// Updates existing agent.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public override async Task<IActionResult> Update([FromBody] Models.Request.Agent model)
        {
            base.StoreProcedure = Constants.StoredProcedure.UpdateAgent;
            return await base.Update(model);
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<List<Models.Response.Agent>> result = await _iAgentRepository.Get();

                if (result.Result == null || result.Result.Count() == 0)
                {
                    if (result.IsError && result.ExceptionMessage != null)
                    {
                        return new StatusCodeResult(500);
                    }
                    else if (result.Result == null || result.Result.Count() == 0)
                    {
                        return NoContent(); //204
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "AgentsController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }
    }
}