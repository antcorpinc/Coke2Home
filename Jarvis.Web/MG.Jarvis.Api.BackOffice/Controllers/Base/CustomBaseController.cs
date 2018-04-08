using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Api.BackOffice.Helper;
using Newtonsoft.Json;
using Dapper;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    //[Produces("application/json")]
    //[Route("api/CustomBase")]
    public abstract class CustomBaseController<T, U> : EntityBaseController<T,U> where T : class
                                                                                 where U : struct
    {
        private IMasterData<T,U> iMasterData;
        private ILogger _iLogger;
        private string _className = string.Empty;
        public string StoreProcedure { get; set; }

        public CustomBaseController(IMasterData<T, U> iMasterData, ILogger iLogger, string className)
            :base(iMasterData, iLogger, className)
        {
            this.iMasterData = iMasterData;
            this._iLogger = iLogger;
            this._className = className;            
        }

        #region Public Methods
        /// <summary>
        /// Get the list 
        /// </summary>
        /// <returns>Action Result</returns>
        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                //Helper helper
                BaseResult<IEnumerable<dynamic>> result = null; // await iMasterData.GetByProcedure(this.StoreProcedure, helper. );//TODO : Add Procedure name and Parameters.

                if (result.IsError || result.ExceptionMessage != null)
                {
                    LogHelper.LogInformation(_iLogger, Constants.AppName, "Get", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), this._className);
                    return new StatusCodeResult(500);
                }

                if (result.Result == null || result.Result.Count() == 0)
                {
                    return NoContent(); //204
                }
                //TODO : Prepare response model.
                return Ok(result);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Create the parent child Entity
        /// </summary>
        /// <returns>Action Result</returns>
        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] T model)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            try
            {
                Core.DAL.Helper.Helper helper = new Core.DAL.Helper.Helper();

                result = await iMasterData.InsertOrUpdateByProcedure(this.StoreProcedure, helper.GetParameterList(typeof(T),model, Core.Model.CustomAttributes.ParameterIncludeInAction.Create)); //TODO : Add Procedure name and Parameters.

                if (result.IsError || result.ExceptionMessage != null)
                {
                    LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), this._className);
                    return new StatusCodeResult(500);
                }
                else if (result.Result == true)
                {
                    return Ok(result);
                }
                else
                {
                    return new StatusCodeResult(500);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>
                {
                    { "Request", JsonConvert.SerializeObject(model) }
                };
                LogHelper.LogError(_iLogger, Constants.AppName, "Create", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, inputParameter);
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Update the parent child Entity
        /// </summary>
        /// <returns>Action Result</returns>
        [Route("Update")]
        [HttpPut]
        public override async Task<IActionResult> Update([FromBody] T model)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            try
            {
                Core.DAL.Helper.Helper helper = new Core.DAL.Helper.Helper();

                result = await iMasterData.InsertOrUpdateByProcedure(this.StoreProcedure, helper.GetParameterList(typeof(T), model, Core.Model.CustomAttributes.ParameterIncludeInAction.Update)); //TODO : Add Procedure name and Parameters.

                if (result.IsError || result.ExceptionMessage != null)
                {
                    LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), this._className);
                    return new StatusCodeResult(500);
                }
                else if (result.Result == true)
                {
                    return Ok(result);
                }
                else
                {
                    return new StatusCodeResult(500);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>
                {
                    { "Request", JsonConvert.SerializeObject(model) }
                };
                LogHelper.LogError(_iLogger, Constants.AppName, "Create", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, inputParameter);
                return new StatusCodeResult(500);
            }

            #region ScarpCode

            //BaseResult<bool> result = new BaseResult<bool>();
            //try
            //{                
            //    result = await iMasterData.InsertOrUpdateByProcedure(this.StoreProcedure, new DynamicParameters()); //TODO : Add Procedure name and Parameters.

            //    if (result.IsError || result.ExceptionMessage != null)
            //    {
            //        LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), this._className);
            //        return new StatusCodeResult(500);
            //    }
            //    else if (result.Result == true)
            //    {
            //        return Ok(result);
            //    }
            //    else
            //    {
            //        return new StatusCodeResult(500);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Dictionary<string, string> inputParameter = new Dictionary<string, string>
            //    {
            //        { "Request", JsonConvert.SerializeObject(model) }
            //    };
            //    LogHelper.LogError(_iLogger, Constants.AppName, "Create", "Error Occurred. ", this._className, ex, Constants.InternalErrorStatusCode, inputParameter);
            //    return new StatusCodeResult(500);
            //}
            #endregion
        }

        #endregion
    }
}