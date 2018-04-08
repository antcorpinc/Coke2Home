//using MG.Jarvis.Core.Model.ChannelManager;
using System.Collections.Generic;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class ChannelManager
    {
        public ChannelManager()
        {
            this.ChannelManagerContacts = new List<Core.Model.ChannelManager.Contacts>();
            this.ChannelManagerBanks = new List<Core.Model.ChannelManager.Bank>();
            this.FunctionEndpoints = new List<FunctionChannelManagerRelationModel>();
            this.ChannelManagerCredentials = new List<Core.Model.ChannelManager.UserRelation>();
            this.ChannelManagerEmailAddresses = new List<Core.Model.ChannelManager.EmailAddresses>();
        }

        public Core.Model.ChannelManager.ChannelManager MGChannelManager { get; set; }
        public Core.Model.ChannelManager.Payment ChannelManagerPayment { get; set; }
        public List<Core.Model.ChannelManager.Contacts> ChannelManagerContacts { get; set; }
        public List<Core.Model.ChannelManager.Bank> ChannelManagerBanks { get; set; }
        public List<Core.Model.ChannelManager.EmailAddresses> ChannelManagerEmailAddresses { get; set; }
        public List<FunctionChannelManagerRelationModel> FunctionEndpoints { get; set; }
        public List<Core.Model.ChannelManager.UserRelation> ChannelManagerCredentials { get; set; }
    }
}
