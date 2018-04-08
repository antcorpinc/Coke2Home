using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class UploadContractViewModel: BaseContractViewModel
    {
        public UploadContractViewModel()
        {
            Bytes = new List<byte>();
        }
        public List<byte> Bytes { get;}
        public string  HotelName { get; set; }
        [Required]
        public override int? Id { get; set; }
    }
}
