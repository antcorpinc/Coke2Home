using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractContactViewModel : BaseViewModel
    {
        public int ContactId { get; set; }
        public int Contractid { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }
        public int DesignationId { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
