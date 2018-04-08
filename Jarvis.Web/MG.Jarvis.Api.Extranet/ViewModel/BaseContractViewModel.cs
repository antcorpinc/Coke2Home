using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class BaseContractViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public virtual int? Id { get; set; }
        [Required]
        public  int? HotelID { get; set; }
    }
}
