using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.ChannelManager;
using MG.Jarvis.Core.Logger;
using Newtonsoft.Json;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Api.BackOffice.Repositories;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class ChannelManagerController : CustomBaseController<Models.Request.ChannelManager, int>
    {
        IChannelManager _iChannelManagerRepository;
        private IConnection<Bank> _bank;
        private IConnection<Contacts> _contacts;
        private IConnection<Payment> _payment;
        private IConnection<Core.Model.ChannelManager.ChannelManager> _channelManager;
        private IConnection<FunctionChannelManagerRelation> _functionChannelManagerRelation;
        private IConnection<Functions> _functions;
        private IConnection<UserRelation> _userRelation;
        private IConnection<EmailAddresses> _emailAddresses;
        private ILogger _logger;
        public ChannelManagerController(IMasterData<Models.Request.ChannelManager, int> iMasterData, ILogger iLogger,
                                                                IConnection<Bank> banks,
                                                                IConnection<Contacts> contacts,
                                                                IConnection<Payment> payment,
                                                                IConnection<EmailAddresses> emailAddresses,
                                                                IConnection<Core.Model.ChannelManager.ChannelManager> channelManager,
                                                                IConnection<FunctionChannelManagerRelation> functionChannelManagerRelation,
                                                                IConnection<Functions> functions,
                                                                IConnection<UserRelation> userRelation,
                                                                IChannelManager iChannelManagerRepository) 
            : base(iMasterData, iLogger, "ChannelManager")
        {
            this._bank = banks;
            this._contacts = contacts;
            this._payment = payment;
            this._channelManager = channelManager;
            this._functionChannelManagerRelation = functionChannelManagerRelation;
            this._functions = functions;
            this._userRelation = userRelation;
            this._emailAddresses = emailAddresses;
            this._logger = iLogger;
            this._iChannelManagerRepository = iChannelManagerRepository;
        }
        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.ChannelManager model)
        {
            base.StoreProcedure = Constants.StoredProcedure.InsertChannelManager;
            return await base.Create(model);
        }

        [Route("Update")]
        [HttpPost]
        public override async Task<IActionResult> Update([FromBody] Models.Request.ChannelManager model)
        {
            base.StoreProcedure = "";// Constants.StoredProcedure.UpdateChannelManager;
            return await base.Update(model);
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<List<Models.Response.ChannelManager>> result = await _iChannelManagerRepository.Get();

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
                LogHelper.LogError(_logger, Constants.AppName, "Get", "Error Occurred. ", "ChannelManagerController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        [Route("GetById")]
        [HttpGet]
        public override async Task<IActionResult> GetById(int id)
        {
            try
            {
                BaseResult<List<Models.Response.ChannelManager>> resultList = await _iChannelManagerRepository.Get();

                if (resultList.Result == null || resultList.Result.Count() == 0)
                {
                    if (resultList.IsError && resultList.ExceptionMessage != null)
                    {
                        return new StatusCodeResult(500);
                    }
                    else if (resultList.Result == null || resultList.Result.Count() == 0)
                    {
                        return NoContent(); //204
                    }
                }

                var result = resultList.Result.Where(x => x.MGChannelManager.Id == id).ToList();
                if(result.Count > 1)
                {
                    return new StatusCodeResult(500);
                }
                else if(result.Count <= 0 )
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                LogHelper.LogError(_logger, Constants.AppName, "Get", "Error Occurred. ", "ChannelManagerController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }
    }
}