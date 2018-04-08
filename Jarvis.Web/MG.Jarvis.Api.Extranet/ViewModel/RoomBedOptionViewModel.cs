using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RoomBedOptionViewModel:BaseViewModel
    {
        public RoomBedOptionViewModel()
        {
            this.RoomBedList = new List<RoomBedListViewModel>();
        }
        [Required]
        public int? OccupancyId { get; set; }
        [Required]
        public IList<RoomBedListViewModel> RoomBedList { get; set; }

    }
}
