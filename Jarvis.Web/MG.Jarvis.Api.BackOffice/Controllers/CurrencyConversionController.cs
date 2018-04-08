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
    public class CurrencyConversionController : EntityBaseController<CurrencyConversion, int>
    {
        IMasterData<CurrencyConversion, int> _iMasterData;
        ILogger _iLogger;

        public CurrencyConversionController(IMasterData<CurrencyConversion, int> iMasterData, ILogger iLogger)
            : base(iMasterData, iLogger, "CurrencyConversionController")
        {
            this._iMasterData = iMasterData;
            this._iLogger = iLogger;
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<IEnumerable<dynamic>> result = await _iMasterData.GetByProcedure(Constants.StoredProcedure.GetCurrencyConversionRates, null);

                if (result.IsError || result.ExceptionMessage != null)
                {
                    LogHelper.LogInformation(_iLogger, Constants.AppName, "Get", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), "CurrencyConversionController");
                    return new StatusCodeResult(500);
                }

                if (result.Result == null)
                {
                    return NoContent(); //204
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "CurrencyConversionController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }

        }

        public override async Task<IActionResult> Update([FromBody] CurrencyConversion model)
        {
            if (model.Id > 0)
                return await base.Update(model);
            else
                return new BadRequestObjectResult(model);
        }
    }
}
