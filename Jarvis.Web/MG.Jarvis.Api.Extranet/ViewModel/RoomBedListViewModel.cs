using System.ComponentModel.DataAnnotations;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RoomBedListViewModel:BaseViewModel
    {
        public int ID { get; set; }
        [Required]
        public int? BedId { get; set; }
        [Required]
        public int? NoOfBeds { get; set; }
    }
}
