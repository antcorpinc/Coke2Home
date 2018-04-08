using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
//using DapperParameters;

using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class AgencyController : CustomBaseController<Models.Request.Agency,int>
    {
        IAgency _iAgencyRepository;
        private IConnection<Core.Model.Agency.Agency> _iAgency;
        //private IAgency iAgencyRepository;
        private ILogger _iLogger;
        private IConnection<AgencyContacts> _iAgencyContact;
        private IConnection<IncludedCountryRelation> _iAgencyIncludedCountry;
        private IConnection<ExcludedCountryRelation> _iAgencyExcludedCountry;
        private IConnection<AgencySupplierRelation> _iAgencySupplierRelation;
        private IConnection<Bank> _iAgencyBank;
        private IConnection<Payment> _iAgencyPayment;
        private IConnection<Agents> _iAgencySuperUser;
        private IConnection<Branch> _iAgencyBranch;
        private IConnection<BranchAgentRelation> _iAgencyBranchAgentRelation;
        private IConfiguration _configuration;

        public AgencyController(IMasterData<Models.Request.Agency, int> iMasterData, ILogger iLogger, IConnection<Core.Model.Agency.Agency> iAgency,
                                                              IConfiguration configuration,
                                                              IConnection<AgencyContacts> iAgencyContacts,
                                                              IConnection<IncludedCountryRelation> iAgencyIncludedCountry,
                                                              IConnection<ExcludedCountryRelation> iAgencyExcludedCountry,
                                                              IConnection<Payment> iAgencyPayment,
                                                              IConnection<Bank> iAgencyBank,
                                                              IConnection<AgencySupplierRelation> iAgencySupplierRelation,
                                                              IConnection<Agents> iAgencySuperUser,
                                                              IConnection<Branch> iAgencyBranch,
                                                              IConnection<BranchAgentRelation> iBranchAgentRelation,
                                                              IAgency agencyRepository) 
            : base(iMasterData,iLogger,"AgencyController")
        {
            _iAgency = iAgency;
            _configuration = configuration;
            _iAgencyContact = iAgencyContacts;
            _iAgencyIncludedCountry = iAgencyIncludedCountry;
            _iAgencyExcludedCountry = iAgencyExcludedCountry;
            _iAgencySupplierRelation = iAgencySupplierRelation;
            _iAgencyBank = iAgencyBank;
            _iAgencyPayment = iAgencyPayment;
            _iAgencySuperUser = iAgencySuperUser;
            _iAgencyBranch = iAgencyBranch;
            _iAgencyBranchAgentRelation = iBranchAgentRelation;
            _iLogger = iLogger;
            _iAgencyRepository = agencyRepository;

        }

        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.Agency model)
        {
            base.StoreProcedure = Constants.StoredProcedure.InsertAgency;
            return await base.Create(model);
        }

        [Route("Update")]
        [HttpPut]
        public override async Task<IActionResult> Update([FromBody] Models.Request.Agency model)
        {
            base.StoreProcedure = Constants.StoredProcedure.UpdateAgency;
            return await base.Update(model);
        }


        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<List<Models.Response.Agency>> result = await _iAgencyRepository.Get();

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
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "AgencyController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        
    }
}