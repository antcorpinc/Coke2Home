using MG.Jarvis.Api.Extranet.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static MG.Jarvis.Api.Extranet.Helper.Enums;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractViewModel:BaseContractViewModel
    {

        public int? ParentContractId { get; set; }
        public int StatusID { get; set; }//enum
        [Required]
        public string PDFLink { get; set; }
        [Required]
        public ContractType? ContractType { get; set; }//enum
        [Required]
        public ObjectState ObjectState { get; set; }
    }
}
