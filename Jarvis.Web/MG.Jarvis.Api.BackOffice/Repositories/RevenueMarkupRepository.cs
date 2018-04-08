using MG.Jarvis.Api.BackOffice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Markup;
using Microsoft.Extensions.Configuration;
using MG.Jarvis.Api.BackOffice.Helper;
using Dapper;
using MG.Jarvis.Api.BackOffice.Models.Markup;
using System.Data;
using System.Reflection;
using System.Globalization;
using MG.Jarvis.Core.DAL.Interfaces;
//using DapperParameters;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class RevenueMarkupRepository : IRevenueMarkup
    {       
        private IConnection<Core.Model.MasterData.RevenueMarkup> iRevenueMarkup;        
        private readonly string ClassName = "";
        public RevenueMarkupRepository(IConnection<Core.Model.MasterData.RevenueMarkup> iRevenueMarkup)
        {     
            this.iRevenueMarkup = iRevenueMarkup;

            this.ClassName = "RevenueMarkupRepository";
        }
        
        public virtual async Task<BaseResult<IEnumerable<dynamic>>> Get()
        {
            var param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.MarkupType, "revenue");
            param.Add(Constants.StoredProcedureParameters.MarkupName, string.Empty);
            return await iRevenueMarkup.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.GetMarkups, param);
        }

       
    }
}
