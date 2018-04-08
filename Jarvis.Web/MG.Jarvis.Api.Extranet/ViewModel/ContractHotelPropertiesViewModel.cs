using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractHotelPropertiesViewModel
    {
        public int ContractId { get; set; }
        public int IsDeleted { get; set; }
        public List<FieldViewModel> FeildIdList { get; set; }
    }
}
