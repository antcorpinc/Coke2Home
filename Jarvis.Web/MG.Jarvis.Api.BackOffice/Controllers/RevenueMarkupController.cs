using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Controllers
{
    [Route("api/[Controller]")]
    public class RevenueMarkupController : CustomBaseController<Models.Request.RevenueMarkup, int>
    {
        IRevenueMarkup _iRevenueMarkupRepository;
        private ILogger _iLogger;
        private IMasterData<Core.Model.Markup.RevenueMarkupRule, int> _iMarkupDataRevenueMarkupRule;
        private IMasterData<Core.Model.MasterData.RevenueMarkup, int> _iMasterDataRevenueMarkup;
        private string _className;
        private static List<Core.Model.Markup.RevenueMarkupRule> exisitingRevenueMarkupRuleList;

        public RevenueMarkupController(IMasterData<Models.Request.RevenueMarkup, int> iMasterData,
            ILogger iLogger, IRevenueMarkup RevenueMarkupRepository,
            IMasterData<Core.Model.Markup.RevenueMarkupRule, int> iMarkupDataRevenueMarkupRule,
            IMasterData<Core.Model.MasterData.RevenueMarkup, int> iMasterDataRevenueMarkup)
            : base(iMasterData, iLogger, "RevenueMarkupController")
        {
            _iLogger = iLogger;
            this._iRevenueMarkupRepository = RevenueMarkupRepository;
            this._iMarkupDataRevenueMarkupRule = iMarkupDataRevenueMarkupRule;
            this._iMasterDataRevenueMarkup = iMasterDataRevenueMarkup;
            this._className = "RevenueMarkupController";
        }

        [Route("Get")]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            try
            {
                BaseResult<IEnumerable<dynamic>> result = await _iRevenueMarkupRepository.Get();

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
                LogHelper.LogError(_iLogger, Constants.AppName, "Get", "Error Occurred. ", "RevenueMarkupController", ex, Constants.InternalErrorStatusCode, null);
                return new StatusCodeResult(500);
            }
        }

        [Route("Create")]
        [HttpPost]
        public override async Task<IActionResult> Create([FromBody] Models.Request.RevenueMarkup model)
        {
            try
            {
                if (model == null || model.MGRevenueMarkup == null || model.RevenueMarkupRules.Count <= 0)
                {
                    return new BadRequestObjectResult(model);
                }
                else
                {
                    var exisitingRuleList = await _iMarkupDataRevenueMarkupRule.GetList();
                    if (exisitingRuleList.IsError == true || exisitingRuleList.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    exisitingRevenueMarkupRuleList = exisitingRuleList.Result;

                    var exisisitngRevenueMarkup = await _iMasterDataRevenueMarkup.GetList();
                    if (exisisitngRevenueMarkup.IsError == true || exisisitngRevenueMarkup.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Create", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    BaseResult<Core.Model.Markup.RevenueMarkupRule> result = VaildateRequest(model, exisisitngRevenueMarkup);
                    if (result.IsError || result.ExceptionMessage != null)
                    {
                        return new BadRequestObjectResult(result);
                    }

                    base.StoreProcedure = Constants.StoredProcedure.InsertRevenueMarkupRules;
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
        public override async Task<IActionResult> Update([FromBody] Models.Request.RevenueMarkup model)
        {
            try
            {
                if (model == null || model.MGRevenueMarkup == null || model.RevenueMarkupRules.Count <= 0)
                {
                    return new BadRequestObjectResult(model);
                }
                else
                {
                    var exisitingRuleList = await _iMarkupDataRevenueMarkupRule.GetList();
                    if (exisitingRuleList.IsError == true || exisitingRuleList.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Update", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    exisitingRevenueMarkupRuleList = exisitingRuleList.Result;

                    var exisisitngRevenueMarkup = await _iMasterDataRevenueMarkup.GetList();
                    if (exisisitngRevenueMarkup.IsError == true || exisisitngRevenueMarkup.ExceptionMessage != null)
                    {
                        LogHelper.LogInformation(_iLogger, Constants.AppName, "Update", "Error Occurred. " + exisitingRuleList.ExceptionMessage.Message.ToString(), this._className);
                        return new StatusCodeResult(500);
                    }

                    BaseResult<Core.Model.Markup.RevenueMarkupRule> result = VaildateRequest(model, exisisitngRevenueMarkup);
                    if (result.IsError || result.ExceptionMessage != null)
                    {
                        return new BadRequestObjectResult(result);
                    }

                    base.StoreProcedure = Constants.StoredProcedure.UpdateRevenueMarkupRules;
                    return await base.Update(model);
                }
            }
            catch (Exception ex)
            {
                Dictionary<string, string> inputParameter = new Dictionary<string, string>();
                inputParameter.Add(key: "model", value: JsonConvert.SerializeObject(model));
                LogHelper.LogError(_iLogger, Constants.AppName, "Update", "Error Occurred. " + ex.Message.ToString(), this._className,ex,null, inputParameter);
                return new StatusCodeResult(500);
            }
            
           
        }
                
        private BaseResult<Core.Model.Markup.RevenueMarkupRule> VaildateRequest(Models.Request.RevenueMarkup model, BaseResult<List<Core.Model.MasterData.RevenueMarkup>> exisisitngRevenueMarkup)
        {
            BaseResult<Core.Model.Markup.RevenueMarkupRule> result = new BaseResult<Core.Model.Markup.RevenueMarkupRule>();
            

            if (exisisitngRevenueMarkup.Result.Count > 0)
            {
                var duplicateMarkupName = exisisitngRevenueMarkup.Result.Where(x => x.Name.ToLower().Equals(model.MGRevenueMarkup.Name.ToLower()) && !x.IsDeleted);

                if (duplicateMarkupName.Count() > 0)
                {
                    result.IsError = true;
                    result.Message = Constants.DulpicateMarkupPresent;
                    return result;
                }
            }

            bool duplicate = false;
            int duplicateAt = 0;

            foreach (var item in model.RevenueMarkupRules)
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
                result.Result = model.RevenueMarkupRules[duplicateAt];
                return result;
            }
            else
            {
                result.IsError = false;
                return result;
            }
            
        }

        private static bool CheckDateRange(Core.Model.Markup.RevenueMarkupRule revenueMarkupRule)
        {
            if (exisitingRevenueMarkupRuleList.Count > 0 && (revenueMarkupRule.FromDatekey != null || revenueMarkupRule.ToDatekey != null))
            {
                DateTime.TryParseExact(revenueMarkupRule.ToDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime currentToDate);
                DateTime.TryParseExact(revenueMarkupRule.FromDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime currentFromDate);

                var markupPresentList = exisitingRevenueMarkupRuleList.Where(x => x.IsActive && !x.IsDeleted &&
                                                                    x.CityId == revenueMarkupRule.CityId &&
                                                                    x.CountryId == revenueMarkupRule.CountryId &&
                                                                    x.HotelId == revenueMarkupRule.HotelId &&
                                                                    x.HotelRoomTypeId == revenueMarkupRule.HotelRoomTypeId &&
                                                                    x.NationalityId == revenueMarkupRule.NationalityId &&
                                                                    x.SupplierId == revenueMarkupRule.SupplierId &&
                                                                    DateTime.ParseExact(x.ToDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None).Date > currentFromDate.Date &&
                                                                    DateTime.ParseExact(x.FromDatekey.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None).Date < currentToDate.Date
                                                                    ).Select(m => new { m.ToDatekey, m.FromDatekey });

                if (markupPresentList.Count() == 0)
                {
                    exisitingRevenueMarkupRuleList.Add(revenueMarkupRule);
                    return false;
                }
                return true;
            }
            exisitingRevenueMarkupRuleList.Add(revenueMarkupRule);
            return false;
        }
    }
}