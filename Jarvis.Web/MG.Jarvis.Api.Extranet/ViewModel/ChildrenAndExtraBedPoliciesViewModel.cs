using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ChildrenAndExtraBedPoliciesViewModel : BaseViewModel
    {
        public ChildrenAndExtraBedPoliciesViewModel()
        {
            this.MaxChildAndExtraBedPerRoomList= new List<MaxChildAndExtraBedPerRoomViewModel>();
        }

        public int Id { get; set; }
        public bool IsChildrenAllowed { get; set; }
        public int? MinChildAge { get; set; }
        public int? MaxChildAge { get; set; }
        public bool IsExtraCotAllowed { get; set; }
        public int? MinInfantAge { get; set; }
        public int? MaxInfantAge { get; set; }
        public int? CotPrice { get; set; }
        public int? CotPriceTypeId { get; set; }
        public bool IsExtraBedAllowed { get; set; }
        public List<MaxChildAndExtraBedPerRoomViewModel> MaxChildAndExtraBedPerRoomList { get; }
    }
}
