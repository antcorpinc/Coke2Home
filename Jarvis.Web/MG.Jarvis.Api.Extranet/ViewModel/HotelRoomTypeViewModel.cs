using System.ComponentModel.DataAnnotations;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelRoomTypeViewModel:BaseViewModel
    {
        public int RoomId { get; set; }
      
        public bool IsActive { get; set; }
        [Required]
        public new int? HotelId { get; set; }
        [Required]
        public int? RoomTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Size { get; set; }
        [Required]
        public int? SizeMeasureId { get; set; }
        [Required]
        public int? NoOfRooms { get; set; }
        public int NoOfTwinRooms { get; set; }
        public int NoOfDoubleRooms { get; set; }
        [Required]
        public bool? IsSmoking { get; set; }
        public bool? IsFreeSale { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public RoomBedOptionViewModel RoomBedOptions { get; set; }
    }
}
