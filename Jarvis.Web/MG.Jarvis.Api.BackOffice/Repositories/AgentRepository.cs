using Dapper;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class AgentRepository : IAgent
    {
        #region private variable
        private IConnection<Agents> iAgents;
        readonly string ClassName = "";
        #endregion private variable
       
        public AgentRepository(IConnection<Agents> iAgents)
        {
            this.iAgents = iAgents;
            this.ClassName = "AgentRepository";
        }

        public virtual async Task<BaseResult<List<Models.Response.Agent>>> Get()
        {
            BaseResult<List<Models.Response.Agent>> agentList = new BaseResult<List<Models.Response.Agent>>();

            Func<Agents, bool> func = s => s.IsActive && !s.IsDeleted;

            var list = await iAgents.GetListByPredicate(func);
            
            if (list.IsError || list.ExceptionMessage != null)
            {
                agentList.IsError = list.IsError;
                agentList.ErrorCode = list.ErrorCode;
                agentList.ExceptionMessage = list.ExceptionMessage;
                agentList.Message = list.Message;
            }

            if (list != null && list.Result != null && list.Result.Count > 0)
            {
                agentList.Result = new List<Models.Response.Agent>();

                foreach (var agent in list.Result)
                {
                    agentList.Result.Add(new Models.Response.Agent { MGAgent = agent });
                }
            }
            else
            {
                agentList.IsError = list.IsError;
                agentList.Message = "List is Empty";
            }

            return agentList;            
        }
    }
}
