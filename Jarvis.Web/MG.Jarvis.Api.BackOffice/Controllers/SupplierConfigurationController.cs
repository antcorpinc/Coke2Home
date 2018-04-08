using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Core.Model.Supplier;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model;
using Newtonsoft.Json;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class SupplierConfigurationController : EntityBaseController<XMLConfiguration,int>
    {
        private ILogger _iLogger;
        private IMasterData<XMLConfiguration, int> _iMasterData;
        private string _className;
        public SupplierConfigurationController(IMasterData<XMLConfiguration,int> iMasterData, ILogger iLogger)
            : base(iMasterData, iLogger, "SupplierConfigurationController")
        {
            _iMasterData = iMasterData;
            _iLogger = iLogger;
        }

        public override async Task<IActionResult> Update([FromBody] XMLConfiguration model)
        {
            if (model.Id > 0)
                return await base.Update(model);
            else
                return new BadRequestObjectResult(model);
        }

        [HttpGet]
        [Route("GetCityCachingConfiguration")]
        public async Task<IActionResult> GetCityCachingConfiguration()
        {
            try
            {
                var result = await this._iMasterData.GetByProcedure(Constants.StoredProcedure.GetCitySuppliersCacheDays, null);

                if (result.IsError || result.ExceptionMessage != null)
                    return new StatusCodeResult(500);


                if (result == null || result.Result == null || result.Result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(_iLogger, Constants.AppName, "GetCitySupplierConfiguration", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }
    }
}