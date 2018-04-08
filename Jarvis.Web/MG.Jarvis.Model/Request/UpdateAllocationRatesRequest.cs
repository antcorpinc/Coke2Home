using System;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    public class UpdateAllocationRatesRequest : RoomTypeByHotelAndChannelManger
    {
        public short RecordId { get; set; }
        public string AllocationDate { get; set; }
        public Decimal? SingleOccupancyPrice { get; set; }
        public Decimal? DoubleOccupancyPrice { get; set; }
        public Decimal? TrippleOccupancyPrice { get; set; }
        public Decimal? QuadOccupancyPrice { get; set; }
        public Decimal? ExtaBedPrice { get; set; }
        public string RoomTypeCode { get; set; }
        public string RatePlanCode { get; set; }
        public int MarketId { get; set; }
    }
}
