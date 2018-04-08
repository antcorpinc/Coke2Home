using MG.Jarvis.Api.Extranet.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContractTemplateViewModel
    {
        public ContractTemplateViewModel()
        {
            HotelFields = new List<HotelFieldViewModel>();
            RoomFields = new List<RoomFieldViewModel>();
            HotelFacilityFields = new List<HotelFacilityGroupViewModel>();
            RoomFacilityFields = new List<RoomFacilityGroupViewModel>();
            ClauseLibraryFields = new List<TemplateClauseLibraryViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NameItemId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<RoomFieldViewModel> RoomFields { get; }
        public List<HotelFieldViewModel> HotelFields { get; }
        [Required]
        public ObjectState? ObjectState { get; set; }

        public bool IsPublished { get; set; }

        public List<HotelFacilityGroupViewModel> HotelFacilityFields { get; }
        public List<RoomFacilityGroupViewModel> RoomFacilityFields { get;}
        public List<TemplateClauseLibraryViewModel> ClauseLibraryFields { get; }
    }
}
