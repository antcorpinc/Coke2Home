using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class ChannelManager
    {
        public ChannelManager()
        {
            this.ChannelManagerContacts = new List<MG.Jarvis.Core.Model.ChannelManager.Contacts>();
            this.ChannelManagerBanks = new List<Core.Model.ChannelManager.Bank>();
        }
        [ChildParameter(true)]
        public MG.Jarvis.Core.Model.ChannelManager.ChannelManager MGChannelManager { get; set; }
        [ChildParameter(true)]
        public MG.Jarvis.Core.Model.ChannelManager.Payment ChannelManagerPayment { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.ChannelManagerBanks, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_ChannelManagerBanks)]
        public List<MG.Jarvis.Core.Model.ChannelManager.Bank> ChannelManagerBanks { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.ChannelManagerContacts, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_ChannelManagerContacts)]
        public List<MG.Jarvis.Core.Model.ChannelManager.Contacts> ChannelManagerContacts { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.ChannelManagerEmailAddresses, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_ChannelManagerEmailAddresses)]
        public List<MG.Jarvis.Core.Model.ChannelManager.EmailAddresses> ChannelManagerEmailAddresses { get; set; }

        //[StoreProcedureParamterInfo(Constants.StoredProcedureParameters.ChannelManagerFunctions, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_ChannelManagerFunctions)]
        //public List<MG.Jarvis.Core.Model.ChannelManager.EmailAddresses> ChannelManagerFunctions { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.FunctionChannelManagerRelation, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_FunctionChannelManagerRelation)]
        public List<MG.Jarvis.Core.Model.ChannelManager.FunctionChannelManagerRelation> FunctionChannelManagerRelation { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.ChannelManagerUserRelation, ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_ChannelManagerUserRelation)]
        public List<MG.Jarvis.Core.Model.ChannelManager.UserRelation> ChannelManagerUserRelation { get; set; }
    }
}
