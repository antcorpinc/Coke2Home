using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Produces("application/json")]
    public abstract class EntityBaseController<T,U> : Controller     where T : class 
                                                                     where U : struct
    {
        IMasterData<T,U> _iMasterData;
        ILogger _iLogger;
        string _className = string.Empty;
       
        public EntityBaseController(IMasterData<T,U> iMasterData, ILogger iLogger, string className)
        {
            this._iMasterData = iMasterData;
            this._iLogger = iLogger;
            this._className = className;
        }

        #region Public Methods
        /// <summary>
        /// Get the list 
        /// </summary>
        /// <returns>Task IActionResult</returns>
        [Route("Get")]
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            try
            {

                BaseResult<List<T>> result = await _iMasterData.GetList();

                if (result.IsError || result.ExceptionMessage != null)
                {
                    LogHelper.LogInformation(_iLogger, Constants.AppName, "Get", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), this._className);
                    return new StatusCodeResult(500);
                }

                if (result.Result == null || result.Result.Count == 0)
                {
                    return NoContent(); //204
                }

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
        /// Create the Entity
        /// </summary>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T model)
        {
            BaseResult<long> result = new BaseResult<long>();
            try
            {
                if (model == null || !ModelState.IsValid)
                {
                    result.IsError = true;
                    result.Message = "Invalid request. Please make sure all the values are passed correctly";
                    return new BadRequestObjectResult(result);
                }

                result = await _iMasterData.InsertEntity(model);

                if (result.IsError || result.ExceptionMessage != null)
                {
                    LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + result.ExceptionMessage.Message.ToString(), this._className);
                    return new StatusCodeResult(500);
                }
                else if (result.Result > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return new BadRequestObjectResult(result);
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
        /// Update the Entity
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] T model)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            try
            {
                if (model == null || !ModelState.IsValid)
                {
                    result.IsError = true;
                    result.Message = Constants.InvalidRequest;
                    return BadRequest(result);
                }

                result = await _iMasterData.UpdateEntity(model);

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
        /// Soft delete the Entity
        /// </summary>
        [Route("Delete")]
        [HttpPut]
        public virtual async Task<IActionResult> Delete([FromBody] U id)
        {
            BaseResult<bool> result = await _iMasterData.RemoveEntity(id);
           
            if (result.IsError || result.ExceptionMessage != null)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        
        }

        [Route("GetById")]
        [HttpPut]
        public virtual async Task<IActionResult> GetById([FromBody] U id)
        {
            BaseResult<T> result = await _iMasterData.GetById(id);
            if(result.IsError || result.ExceptionMessage != null)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        #endregion

    }
}
