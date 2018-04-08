using MG.Jarvis.Api.Extranet.Helper;
using System.ComponentModel.DataAnnotations;
using static MG.Jarvis.Api.Extranet.Helper.Enums;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class FieldViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FacilityGroupId { get; set; }
        public int? FacilityTypeId { get; set; }
        public int? FacilityId { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        //public bool IsActive { get; set; }
        //public bool IsDeleted { get; set; }
        public bool IsSelected { get; set; }
        public bool IsConfigurable { get; set; }
        [Required]
        public ObjectState? ObjectState { get; set; }
        public EntityState Status { get; set; }
    }
}
