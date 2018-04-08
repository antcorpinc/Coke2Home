using MG.Jarvis.Api.BackOffice.Interfaces;
//using DapperParameters;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class BranchRepository : IBranch
    {
        #region private variable
        private IConnection<Core.Model.Agency.Branch> iBranch;
        private IConnection<BranchContacts> iBranchContacts;
        readonly string ClassName = "";
        #endregion private variable

        public BranchRepository(IConnection<Core.Model.Agency.Branch> branch, IConnection<BranchContacts> branchContacts)
        {
            this.iBranch = branch;
            this.iBranchContacts = branchContacts;
            this.ClassName = "BranchRepository";
        }
        
        public virtual async Task<BaseResult<List<Models.Response.Branch>>> Get(int? agencyId)
        {
            BaseResult<List<Models.Response.Branch>> branchList = new BaseResult<List<Models.Response.Branch>>();
            
            var list = await iBranch.GetListByPredicate(s => s.IsActive && !s.IsDeleted && s.AgencyId== (agencyId!=null?agencyId:s.AgencyId));

            if (list != null && list.Result != null && list.Result.Count > 0)
            {
                branchList.Result = new List<Models.Response.Branch>();
                foreach (var branch in list.Result)
                {
                    var branchContacts = await iBranchContacts.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.BranchId == branch.Id);

                    branchList.Result.Add(new Models.Response.Branch
                    {
                        MGBranch = branch,
                        BranchContacts = (branchContacts.IsError == false && branchContacts.Result != null && branchContacts.Result.Count > 0) ? branchContacts.Result : null                        
                    });
                }
            }
            else
            {
                branchList.IsError = list.IsError;
                branchList.ErrorCode = list.ErrorCode;
                branchList.ExceptionMessage = list.ExceptionMessage;
                branchList.Message = list.Message;
            }

            return branchList;
        }        
    }
}
