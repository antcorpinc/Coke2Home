using System;
using System.ComponentModel.DataAnnotations;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelMessageViewModel:BaseViewModel
    {
        public int MessageId { get; set; }
        public bool? IsActive { get; set; }
        [Required]
        public int? MessageTypeId { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string MessageDescription { get; set; }
    }
}
