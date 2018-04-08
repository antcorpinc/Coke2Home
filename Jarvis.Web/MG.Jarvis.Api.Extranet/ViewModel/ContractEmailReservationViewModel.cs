using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractEmailReservationViewModel : BaseViewModel
    {
        public int EmailReservationId { get; set; }
        public int ContractId { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
