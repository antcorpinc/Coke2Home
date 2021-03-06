﻿using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class NationalitiesController : EntityBaseController<Core.Model.MasterData.Nationality,int>
    {
        private ILogger _iLogger;
        private string _className;
        private IMapping<Core.Model.Mappings.Nationality> _mappingRepository;
        public NationalitiesController(IMasterData<Core.Model.MasterData.Nationality,int> iMasterData, ILogger iLogger, IMapping<Core.Model.Mappings.Nationality> mappingRepository)
            : base(iMasterData, iLogger, "NationalitiesController")
        {
            this._iLogger = iLogger;
            this._className = "NationalitiesController";
            this._mappingRepository = mappingRepository;
        }

        public override async Task<IActionResult> Update([FromBody] Core.Model.MasterData.Nationality model)
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
                var result = await this._mappingRepository.Mapping(Constants.StoredProcedure.GetNationalityCodeMappings);

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
                var result = await this._mappingRepository.InsertOrUpdateMapping(Constants.StoredProcedure.InsertNationalitySupplierMapping, helper.GetParameterList(typeof(Models.Request.Mapping), model, Core.Model.CustomAttributes.ParameterIncludeInAction.Create));

                if (result.IsError || result.ExceptionMessage != null)
                    return new StatusCodeResult(500);

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
                LogHelper.LogError(_iLogger, Constants.AppName, "CreateMapping", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }
    }
}