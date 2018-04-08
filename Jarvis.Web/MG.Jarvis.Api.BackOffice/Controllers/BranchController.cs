using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Core.Model.Agency;
using MG.Jarvis.Api.BackOffice.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Helper;
using System.Linq;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class BranchController : CustomBaseController<Models.Request.Branch, int>
    {
        IBranch _iBranchRepository;
        //private Core.DAL.Interfaces.IConnection<Branch> iBranch;        
        //private Core.DAL.Interfaces.IConnection<BranchContacts> iBranchContacts;
        private ILogger _iLogger;

        public BranchController(IMasterData<Models.Request.Branch, int> iMasterData, ILogger iLogger, IBranch iBranchRepository)
            :base(iMasterData, iLogger, "BranchController")
        {
            //this.iBranch = iBranch;
            //this.iBranchContacts = iBranchContacts;
            _iLogger = iLogger;
            this._iBranchRepository = iBranchRepository;
        }

        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.Branch model)
        {
            base.StoreProcedure = Constants.StoredProcedure.AddBranch;            
            return await base.Create(model);
        }

        [Route("Update")]
        [HttpPut]
        public override async Task<IActionResult> Update([FromBody] Models.Request.Branch model)
        {
            base.StoreProcedure = Constants.StoredProcedure.UpdateBranch;
            return await base.Update(model);
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return await GetAgency(null);
        }

        [Route("GetBranchByAgancyId")]
        [HttpGet]
        public async Task<IActionResult> GetBranchByAgancyId(int? agencyId)
        {
            return await GetAgency(agencyId);
        }

        private async Task<IActionResult> GetAgency(int? id)
        {
            try
            {
                BaseResult<List<Models.Response.Branch>> result = await _iBranchRepository.Get(id);

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
                inputParameter.Add("Id", id.ToString());
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "BranchController", ex, Constants.InternalErrorStatusCode, inputParameter);
                return new StatusCodeResult(500);
            }
        }
    }
}