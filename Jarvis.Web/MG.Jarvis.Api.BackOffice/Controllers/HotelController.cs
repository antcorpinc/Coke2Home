using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Produces("application/json")]
    [Route("api/Hotel")]
    public class HotelController : Controller
    {
        private ILogger _iLogger;
        private string _className;
        private IMapping<Core.Model.Mappings.Hotel> _mappingRepository;

        public HotelController(ILogger iLogger, IMapping<Core.Model.Mappings.Hotel> mappingRepository)
        {
            this._iLogger = iLogger;
            this._className = "HotelController";
            this._mappingRepository = mappingRepository;
        }

        [HttpGet]
        [Route("Mapping")]
        public async Task<IActionResult> Mapping()
        {
            try
            {
                var result = await this._mappingRepository.Mapping(Constants.StoredProcedure.GetHotelCodeMappings);

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
                BaseResult<IEnumerable<dynamic>> baseResult = new BaseResult<IEnumerable<dynamic>>()
                {
                    Result = null,
                    IsError = true,
                    Message = "Internal Server Error"
                };
                if (ex.Message == Constants.NoContentExceptionMessage)
                {
                    baseResult.IsError = false;
                    baseResult.Message = Constants.NoContentExceptionMessage;
                    return NoContent();
                }
                LogHelper.LogError(_iLogger, Constants.AppName, "Mapping", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("CreateMapping")]
        public async Task<IActionResult> CreateMapping([FromBody]Models.Request.Mapping model)
        {
            try
            {
                if (model == null)
                {
                    return new BadRequestObjectResult(model);
                }

                Core.DAL.Helper.Helper helper = new Core.DAL.Helper.Helper();
                var result = await this._mappingRepository.InsertOrUpdateMapping(Constants.StoredProcedure.InsertHotelSupplierMapping, helper.GetParameterList(typeof(Models.Request.Mapping), model, Core.Model.CustomAttributes.ParameterIncludeInAction.Create));

                if (result.IsError || result.ExceptionMessage != null)
                    return new StatusCodeResult(500);

                return Ok(result);
            }
            catch (Exception ex)
            {
                LogHelper.LogError(_iLogger, Constants.AppName, "CreateMapping", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }
    }
}