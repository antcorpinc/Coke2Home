using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class FunctionChannelManagerRelationModel : MG.Jarvis.Core.Model.ChannelManager.FunctionChannelManagerRelation
    {
        public string FunctionName { get; set; }
    }

}
