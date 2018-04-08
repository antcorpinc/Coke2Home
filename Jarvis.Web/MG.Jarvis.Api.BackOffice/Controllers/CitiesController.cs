using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class CitiesController : EntityBaseController<Core.Model.MasterData.City, int>
    {
        private ILogger _iLogger;
        private string _className;
        private IMapping<Core.Model.Mappings.City> _mappingRepository;

        public CitiesController(IMasterData<Core.Model.MasterData.City, int> iMasterData, ILogger iLogger, IMapping<Core.Model.Mappings.City> mappingRepository)
            : base(iMasterData, iLogger, "CityController")
        {
            this._iLogger = iLogger;
            this._className = "CityController";
            this._mappingRepository = mappingRepository;
        }



        public override async Task<IActionResult> Update([FromBody] Core.Model.MasterData.City model)
        {
            if (model.Id > 0)
                return await base.Update(model);
            else
                return new BadRequestObjectResult(model);
        }


        [HttpGet]
        [Route("Mapping")]
        public async Task<IActionResult> Mapping()
        {
            try
            {
                var result = await this._mappingRepository.Mapping(Constants.StoredProcedure.GetCityCodeMappings);

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
                if(model == null)
                {
                    return new BadRequestObjectResult(model);
                }

                Core.DAL.Helper.Helper helper = new Core.DAL.Helper.Helper();
                var result = await this._mappingRepository.InsertOrUpdateMapping(Constants.StoredProcedure.InsertCitySupplierMapping, helper.GetParameterList(typeof(Models.Request.Mapping), model, Core.Model.CustomAttributes.ParameterIncludeInAction.Create));

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
