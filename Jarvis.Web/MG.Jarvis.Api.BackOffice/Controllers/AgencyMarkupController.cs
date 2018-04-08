using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Markup;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Api.BackOffice.Models.Markup;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Api.BackOffice.Helper;
using Dapper;
using System.Globalization;
using Newtonsoft.Json;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class AgencyMarkupController : CustomBaseController<Models.Request.AgencyMarkup, int>
    {
        IAgencyMarkup _iAgencyMarkupRepository;
        private ILogger _iLogger;
        private IMasterData<Core.Model.Markup.AgencyMarkupRule, int> _iMarkupDataAgencyMarkupRule;
        private IMasterData<Core.Model.MasterData.AgencyMarkup, int> _iMasterDataAgencyMarkup;
        private string _className;
        private static List<Core.Model.Markup.AgencyMarkupRule> exisitingAgencyMarkupRuleList;

        public AgencyMarkupController(IMasterData<Models.Request.AgencyMarkup, int> iMasterData, ILogger iLogger,
            IAgencyMarkup _iAgencyMarkupRepository,
            IMasterData<Core.Model.Markup.AgencyMarkupRule, int> _iMarkupDataAgencyMarkupRule,
            IMasterData<Core.Model.MasterData.AgencyMarkup, int> _iMasterDataAgencyMarkup)
            : base(iMasterData, iLogger, "AgencyMarkupController")
        {
            _iLogger = iLogger;
            this._iAgencyMarkupRepository = _iAgencyMarkupRepository;
            this._iMarkupDataAgencyMarkupRule = _iMarkupDataAgencyMarkupRule;
            this._iMasterDataAgencyMarkup = _iMasterDataAgencyMarkup;
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<IEnumerable<dynamic>> result = await _iAgencyMarkupRepository.Get();

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
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "AgencyMarkupController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.AgencyMarkup model)
        {
            try
            {
                if (model == null || model.MGAgencyMarkup == null || model.AgencyMarkupRule.Count <= 0)
                {
                    return new BadRequestObjectResult(model);
                }
                else
                {
                    var exisitingRuleList = await _iMarkupDataAgencyMarkupRule.GetList();
                    if (exisitingRuleList.IsError == true || exisitingRuleList.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    exisitingAgencyMarkupRuleList = exisitingRuleList.Result;

                    var exisisitngAgencyMarkup = await _iMasterDataAgencyMarkup.GetList();
                    if (exisisitngAgencyMarkup.IsError == true || exisisitngAgencyMarkup.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    BaseResult<Core.Model.Markup.AgencyMarkupRule> result = VaildateRequest(model, exisisitngAgencyMarkup);
                    if (result.IsError || result.ExceptionMessage != null)
                    {
                        return new BadRequestObjectResult(result);
                    }

                    base.StoreProcedure = Constants.StoredProcedure.InsertAgencyMarkupRules;
                    return await base.Create(model);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                inputParameter.Add(key: "model", value: JsonConvert.SerializeObject(model));
                LogHelper.LogError(_iLogger, Constants.AppName, "Create", "Error Occurred. " + ex.Message.ToString(), this._className, ex, null, inputParameter);
                return new StatusCodeResult(500);
            }
        }

        [Route("Update")]
        [HttpPost]
        public override async Task<IActionResult> Update([FromBody] Models.Request.AgencyMarkup model)
        {
            try
            {
                if (model == null || model.MGAgencyMarkup == null || model.AgencyMarkupRule.Count <= 0)
                {
                    return new BadRequestObjectResult(model);
                }
                else
                {
                    var exisitingRuleList = await _iMarkupDataAgencyMarkupRule.GetList();
                    if (exisitingRuleList.IsError == true || exisitingRuleList.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Update", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    exisitingAgencyMarkupRuleList = exisitingRuleList.Result;

                    var exisisitngAgencyMarkup = await _iMasterDataAgencyMarkup.GetList();
                    if (exisisitngAgencyMarkup.IsError == true || exisisitngAgencyMarkup.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Update", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    BaseResult<Core.Model.Markup.AgencyMarkupRule> result = VaildateRequest(model, exisisitngAgencyMarkup);
                    if (result.IsError || result.ExceptionMessage != null)
                    {
                        return new BadRequestObjectResult(result);
                    }
                    base.StoreProcedure = Constants.StoredProcedure.UpdateAgencyMarkupRules;
                    return await base.Update(model);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                inputParameter.Add(key: "model", value: JsonConvert.SerializeObject(model));
                LogHelper.LogError(_iLogger, Constants.AppName, "Update", "Error Occurred. " + ex.Message.ToString(), this._className, ex, null, inputParameter);
                return new StatusCodeResult(500);
            }
        }

        private BaseResult<Core.Model.Markup.AgencyMarkupRule> VaildateRequest(Models.Request.AgencyMarkup model, BaseResult<List<Core.Model.MasterData.AgencyMarkup>> exisisitngAgencyMarkup)
        {
            BaseResult<Core.Model.Markup.AgencyMarkupRule> result = new BaseResult<Core.Model.Markup.AgencyMarkupRule>();


            if (exisisitngAgencyMarkup.Result.Count > 0)
            {
                var duplicateMarkupName = exisisitngAgencyMarkup.Result.Where(x => x.Name.ToLower().Equals(model.MGAgencyMarkup.Name.ToLower()) && !x.IsDeleted);

                if (duplicateMarkupName.Count() > 0)
                {
                    result.IsError = true;
                    result.Message = Constants.DulpicateMarkupPresent;
                    return result;
                }
            }

            bool duplicate = false;
            int duplicateAt = 0;

            foreach (var item in model.AgencyMarkupRule)
            {
                if (CheckDateRange(item))
                {
                    duplicate = true;
                    break;
                }
                duplicateAt++;
            }

            if (duplicate)
            {
                result.IsError = true;
                result.Message = Constants.DulpicateMarkupPresent;
                result.Result = model.AgencyMarkupRule[duplicateAt];
                return result;
            }
            else
            {
                result.IsError = false;
                return result;
            }

        }

        private static bool CheckDateRange(Core.Model.Markup.AgencyMarkupRule agencyMarkupRule)
        {
            if (exisitingAgencyMarkupRuleList.Count > 0 && (agencyMarkupRule.FromDatekey != null || agencyMarkupRule.ToDatekey != null))
            {
                DateTime.TryParseExact(agencyMarkupRule.ToDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime currentToDate);
                DateTime.TryParseExact(agencyMarkupRule.FromDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime currentFromDate);

                var markupPresentList = exisitingAgencyMarkupRuleList.Where(x => x.IsActive && !x.IsDeleted &&
                                                                    x.CityId == agencyMarkupRule.CityId &&
                                                                    x.CountryId == agencyMarkupRule.CountryId &&
                                                                    x.HotelId == agencyMarkupRule.HotelId &&
                                                                    x.HotelRoomTypeId == agencyMarkupRule.HotelRoomTypeId &&
                                                                    x.NationalityId == agencyMarkupRule.NationalityId &&
                                                                    x.AgencyId == agencyMarkupRule.AgencyId &&
                                                                    DateTime.ParseExact(x.ToDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None).Date > currentFromDate.Date &&
                                                                    DateTime.ParseExact(x.FromDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None).Date < currentToDate.Date
                                                                    ).Select(m => new { m.ToDatekey, m.FromDatekey });

                if (markupPresentList.Count() == 0)
                {
                    exisitingAgencyMarkupRuleList.Add(agencyMarkupRule);
                    return false;
                }
                return true;
            }
            exisitingAgencyMarkupRuleList.Add(agencyMarkupRule);
            return false;
        }
    }
}