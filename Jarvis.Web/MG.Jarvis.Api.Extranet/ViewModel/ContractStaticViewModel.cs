
namespace MG.Jarvis.Api.Extranet.ViewModel
{
    using System;
    using MG.Jarvis.Api.Extranet.Helper;
    using MG.Jarvis.Api.Extranet.Models.ViewModels;

    /// <summary>
    /// The contract static view model.
    /// </summary>
    public class ContractStaticViewModel : BaseViewModel
    {
        public int ContractId { get; set; }
        public int TemplateId { get; set; }
        public int? ParentContractId { get; set; }
        public int StatusID { get; set; }
        public string Name { get; set; }
        public int? NameItemId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDynamic { get; set; }
        public bool? IsDomestic { get; set; }
        public bool? IsPromotional { get; set; }
        public bool IsDeleted { get; set; }
        public string ContractDetails { get; set; }
        public string PDFLink { get; set; }
        public ObjectState? ObjectState { get; set; }
        public HotelDetailsViewModel HotelDetailsViewModel { get; set; }
        public int Id { get; set; }
        public int HotelID { get; set; }
        public Enums.ContractType? ContractType { get; set; }//enum
    }
}
