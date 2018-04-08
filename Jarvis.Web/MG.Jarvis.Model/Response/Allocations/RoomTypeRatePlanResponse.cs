namespace MG.Jarvis.Api.Extranet.Models
{
    public class RoomTypeRatePlanResponse
    {
        public string RoomTypeCode { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomTypeDescription { get; set; }
        public string RatePlanCode { get; set; }
        public string RatePlanName { get; set; }
        public string RatePlanDescription { get; set; }
        public int MaxOccupancy { get; set; }
    }
}
