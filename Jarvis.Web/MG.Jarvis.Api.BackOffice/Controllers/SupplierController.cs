using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.Supplier;
using MG.Jarvis.Core.Logger;
using Newtonsoft.Json;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class SupplierController : CustomBaseController<Models.Request.Supplier, int>
    {
        ISupplier _iSupplierRepository;
        private Core.DAL.Interfaces.IConnection<Bank> iBank;
        private Core.DAL.Interfaces.IConnection<Contacts> iContacts;
        private Core.DAL.Interfaces.IConnection<Payment> iPayment;
        private Core.DAL.Interfaces.IConnection<Suppliers> iSuppliers;
        private Core.DAL.Interfaces.IConnection<FunctionSupplierRelation> iSuppliersFunctionsMapping;
        private Core.DAL.Interfaces.IConnection<Functions> iFunctions;
        private Core.DAL.Interfaces.IConnection<UserRelation> iUserRelation;
        private ILogger _iLogger;

        public SupplierController(IMasterData<Models.Request.Supplier, int> iMasterData, ILogger iLogger,
            Core.DAL.Interfaces.IConnection<Bank> iBank, Core.DAL.Interfaces.IConnection<Contacts> iContacts
            ,Core.DAL.Interfaces.IConnection<Payment> iPayment, Core.DAL.Interfaces.IConnection<Suppliers> iSuppliers,
            Core.DAL.Interfaces.IConnection<FunctionSupplierRelation> iSuppliersFunctionsMapping, Core.DAL.Interfaces.IConnection<Functions> iFunctions,
            Core.DAL.Interfaces.IConnection<UserRelation> iUserRelation, ISupplier supplier) 
            : base(iMasterData, iLogger, "Supplier")
        {
            this.iBank = iBank;
            this.iContacts = iContacts;
            this.iPayment = iPayment;
            this.iSuppliers = iSuppliers;
            this.iSuppliersFunctionsMapping = iSuppliersFunctionsMapping;
            this.iFunctions = iFunctions;
            this.iUserRelation = iUserRelation;
            this._iLogger = iLogger;
            this._iSupplierRepository = supplier;
        }
        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.Supplier model)
        {
            base.StoreProcedure = Constants.StoredProcedure.AddSupplier;
            return await base.Create(model);
        }

        [Route("Update")]
        [HttpPost]
        public override async Task<IActionResult> Update([FromBody] Models.Request.Supplier model)
        {
            base.StoreProcedure = Constants.StoredProcedure.UpdateSupplier;
            return await base.Update(model);
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<List<Models.Response.Supplier>> result = await _iSupplierRepository.Get();

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
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "SupplierController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        [Route("GetById")]
        [HttpGet]
        public override async Task<IActionResult> GetById(int id)
        {
            try
            {
                BaseResult<Models.Response.Supplier> result = await _iSupplierRepository.GetById(id);

                if (result.IsError && result.ExceptionMessage != null)
                {
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
                LogHelper.LogError(_iLogger, Constants.AppName, "GetById", "Error Occurred. ", "SupplierController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }
    }
}