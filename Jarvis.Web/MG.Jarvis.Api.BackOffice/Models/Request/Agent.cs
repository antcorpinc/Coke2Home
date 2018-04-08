using MG.Jarvis.Core.Model.Agency;
using MG.Jarvis.Core.Model.CustomAttributes;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class Agent 
    {
        [ChildParameter(true)]
        public Agents MGAgent { get; set; }
    }
}
