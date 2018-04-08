using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Markup;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Markup;
using System.Globalization;
using Dapper;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class AgencyMarkupRepository : IAgencyMarkup
    {       
        private IConnection<Core.Model.MasterData.AgencyMarkup> iAgencyMarkup;
        private readonly string ClassName = "";

        public AgencyMarkupRepository(IConnection<Core.Model.MasterData.AgencyMarkup> iAgencyMarkup)
        {            
            this.iAgencyMarkup = iAgencyMarkup;
            this.ClassName = "AgencyMarkupRepository";
        }
        
        public virtual async Task<BaseResult<IEnumerable<dynamic>>> Get()
        {
            var param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.MarkupType, "agency");
            param.Add(Constants.StoredProcedureParameters.MarkupName, string.Empty);
            return await iAgencyMarkup.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.GetMarkups, param);
        }

       
    }
}
