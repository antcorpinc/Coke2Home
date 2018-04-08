using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RateCategoryViewModel:BaseViewModel
    {
        public RateCategoryViewModel()
        {
            this.RoomTypeList = new List<RatePlansViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public int? ChildrenAndExtraBedPoliciesId { get; set; }
        public int CancellationPolicyId { get; set; }
        public string RatePlanInfo { get; set; }
        public int HotelMealId { get; set; }
        public bool IsActive { get; set; }
        public List<RatePlansViewModel> RoomTypeList { get; }
    }
}
