using System.Collections.Generic;
using System.Threading.Tasks;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.ChannelManager;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Api.BackOffice.Interfaces;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class ChannelManagerRepository : IChannelManager
    {
        private IConnection<Bank> _bank;
        private IConnection<Contacts> _contacts;
        private IConnection<Payment> _payment;
        private IConnection<ChannelManager> _channelManager;
        private IConnection<FunctionChannelManagerRelation> _functionChannelManagerRelation;
        private IConnection<Functions> _functions;
        private IConnection<UserRelation> _userRelation;
        private IConnection<EmailAddresses> _emailAddresses;

        private readonly string ClassName = "";
        public ChannelManagerRepository(IConnection<Bank> banks,
                                        IConnection<Contacts> contacts,
                                        IConnection<Payment> payment,
                                        IConnection<EmailAddresses> emailAddresses,
                                        IConnection<ChannelManager> channelManager,
                                        IConnection<FunctionChannelManagerRelation> functionChannelManagerRelation,
                                        IConnection<Functions> functions,
                                        IConnection<UserRelation> userRelation)
        {
            this._bank = banks;
            this._contacts = contacts;
            this._payment = payment;
            this._channelManager = channelManager;
            this._functionChannelManagerRelation = functionChannelManagerRelation;
            this._functions = functions;
            this._userRelation = userRelation;
            this._emailAddresses = emailAddresses;
            this.ClassName = "ChannelManagerRepository";
        }

        public virtual async Task<BaseResult<List<Models.Response.ChannelManager>>> Get()
        {
            BaseResult<List<Models.Response.ChannelManager>> channelManagerList = new BaseResult<List<Models.Response.ChannelManager>>();
            var list = await _channelManager.GetListByPredicate(s => s.IsActive && !s.IsDeleted);

            if (list != null && list.Result != null && list.Result.Count > 0)
            {
                channelManagerList.Result = new List<Models.Response.ChannelManager>();
                foreach (var channelManager in list.Result)
                {
                    var bankDetails = await _bank.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.ChannelManagerId == channelManager.Id);
                    var contactDetails = await _contacts.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.ChannelManagerId == channelManager.Id);
                    var paymentDetails = await _payment.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.ChannelManagerId == channelManager.Id);
                    var userRelationList = await _userRelation.GetListByPredicate(b => !b.IsDeleted && b.ChannelManagerId == channelManager.Id);
                    var emailAddresses = await _emailAddresses.GetListByPredicate(b => !b.IsDeleted && b.ChannelManagerId == channelManager.Id);
                    channelManagerList.Result.Add(new Models.Response.ChannelManager
                    {
                        MGChannelManager = channelManager,
                        ChannelManagerBanks = (bankDetails.IsError == false && bankDetails.Result != null && bankDetails.Result.Count > 0) ? bankDetails.Result : null,
                        ChannelManagerContacts = (contactDetails.IsError == false && contactDetails.Result != null && contactDetails.Result.Count > 0) ? contactDetails.Result : null,
                        ChannelManagerPayment = (paymentDetails.IsError == false && paymentDetails.Result != null && paymentDetails.Result.Count > 0) ? paymentDetails.Result[0] : null,
                        ChannelManagerCredentials = (userRelationList.IsError == false && userRelationList.Result != null && userRelationList.Result.Count > 0) ? userRelationList.Result : null,
                        //FunctionEndpoints = (functionEndpoints.IsError == false && functionEndpoints.Result != null && functionEndpoints.Result.Count > 0) ? functionEndpoints.Result : null,
                        FunctionEndpoints = await GetChannelManagerFunctionEndpoints(channelManager.Id),
                        ChannelManagerEmailAddresses = (emailAddresses.IsError == false && emailAddresses.Result != null && emailAddresses.Result.Count > 0) ? emailAddresses.Result : null,
                    });
                }
            }
            else
            {
                channelManagerList.IsError = list.IsError;
                channelManagerList.ErrorCode = list.ErrorCode;
                channelManagerList.ExceptionMessage = list.ExceptionMessage;
                channelManagerList.Message = list.Message;
            }

            return channelManagerList;
        }

        private async Task<List<Models.Response.FunctionChannelManagerRelationModel>> GetChannelManagerFunctionEndpoints(int channelManagerId)
        {
            var functionList = await _functions.GetListByPredicate(f => !f.IsDeleted);
            var functionChannelManagerRelation = await _functionChannelManagerRelation.GetListByPredicate(f => !f.IsDeleted && f.ChannelManagerId == channelManagerId);

            if (functionChannelManagerRelation == null              ||
                functionList == null                         ||
                functionChannelManagerRelation.Result == null       ||
                functionList.Result == null                  ||
                functionChannelManagerRelation.Result.Count == 0    ||
                functionList.Result.Count == 0)
                return null;

            List<Models.Response.FunctionChannelManagerRelationModel> result = new List<Models.Response.FunctionChannelManagerRelationModel>();

            foreach (var item in functionChannelManagerRelation.Result)
            {
                result.Add(new Models.Response.FunctionChannelManagerRelationModel
                {
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    EndpointURL = item.EndpointURL,
                    EnvironmentId = item.EnvironmentId,
                    CurrencyId = item.CurrencyId,
                    IsInScheduledOutage = item.IsInScheduledOutage,
                    FunctionId = item.FunctionId,
                    FunctionName = functionList.Result.Find(f => f.Id == item.FunctionId).Name,
                    IsDeleted = item.IsDeleted,
                    LanguageID = item.LanguageID,
                    ChannelManagerId = item.ChannelManagerId,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate
                });
            }

            return result;
        }
    }
}
