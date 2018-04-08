using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;


namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class AllocationsRepository : IAllocations
    {
        #region Private Variables
        IConnection<Calendar> iCalendarLibrary;
        private IConfiguration iConfiguration;
        private int defaultPeriod;
        private const int fixPeriod = 14;
        #endregion Private Varibales

        public AllocationsRepository(IConnection<Calendar> iCalendarLibrary, IConfiguration iConfiguration)
        {
            this.iCalendarLibrary = iCalendarLibrary;
            this.iConfiguration = iConfiguration;
            this.defaultPeriod = GetDefaultCalendarDaysToDisplay();
        }
        public int GetDefaultCalendarDaysToDisplay()
        {
            var appSettings = iConfiguration.GetSection("AppSettings");
            if (appSettings != null)
            {
                var defaultDays = appSettings.GetValue<string>("DefaultCalendarDaysToDisplay");
                return Convert.ToInt32(defaultDays);
            }
            return fixPeriod;
        }
        /// <summary>
        /// Get th list of date in calendar
        /// </summary>
        /// <param name="request"></param>
        /// <returns>List<Calendar></returns>
        public async Task<BaseResult<List<Calendar>>> GetDates(DateViewModel request)
        {
            BaseResult<List<Calendar>> response = new BaseResult<List<Calendar>>();            
            if (request.StartDate == null && request.EndDate == null)
            {
                response = await iCalendarLibrary.GetListByPredicate(x => x.FullDateAlternatekey.Date >= DateTime.Now.Date
                                                                 && x.FullDateAlternatekey.Date <= DateTime.Now.AddDays(defaultPeriod).Date && !x.IsDeleted);
                return response;
            }
            if (request.StartDate.Value.Date > request.EndDate.Value.Date)
            {
                response.IsError = true;
                response.ErrorCode = (int)coreHelper.Constants.ErrorCodes.StartDateEndDateViolation;
                response.Message = string.Format(coreHelper.Constants.ErrorMessage.StartDateEndDateViolation);
                return response;
            }
            response = await iCalendarLibrary.GetListByPredicate(x => x.FullDateAlternatekey.Date >= request.StartDate.Value.Date
                                                                 && x.FullDateAlternatekey.Date <= request.EndDate.Value.Date && !x.IsDeleted);
            return response;
        }
    }
}
