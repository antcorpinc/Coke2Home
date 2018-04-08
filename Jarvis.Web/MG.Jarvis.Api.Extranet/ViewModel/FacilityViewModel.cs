namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class FacilityViewModel : BaseViewModel
    {
        public int HotelFacilityRelationId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? FacilityTypeId { get; set; }

        public int FacilityGroupId { get; set; }

        public bool IsActive { get; set; }

        public bool IsSelected { get; set; }
    }
}
