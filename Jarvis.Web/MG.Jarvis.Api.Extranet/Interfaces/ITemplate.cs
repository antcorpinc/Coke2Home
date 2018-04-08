using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Common;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface ITemplate
    {
        Task<BaseResult<List<TemplateClauseLibraryViewModel>>> GetClauseLibraryFields(int templateId, int languageId);
        Task<BaseResult<long>> InsertTemplateClauseLibraryFields(List<TemplateClauseLibraryViewModel> requestClauseLibraryFields, string userName, int templateId);
        Task<BaseResult<bool>> UpdateTemplateClauseLibraryFields(List<TemplateClauseLibraryViewModel> requestClauseLibraryFields, string userName, int templateId);
        Task<BaseResult<Field>> CreateTemplateCopy(CopyTemplate request, string userName);
        Task<BaseResult<bool>> DeleteTemplate(int templateId, string userName);
        Task<BaseResult<List<ContractTemplate>>> GetContractTemplates();
        Task<BaseResult<List<HotelField>>> GetHotelFields();
        Task<BaseResult<List<RoomField>>> GetRoomFields();
        Task<BaseResult<List<TemplateHotelField>>> GetTemplateHotelFields(int templateId, bool isFacility = false);
        Task<BaseResult<List<TemplateRoomField>>> GetTemplateRoomFields(int templateId, bool isFacility = false);
        Task<BaseResult<ContractTemplate>> GetContractTemplateByID(int id);
        Task<BaseResult<List<HotelFacilityGroupViewModel>>> GetTemplateHotelFacilityFields(int templateId, int languageId);
        Task<BaseResult<long>> CreateContractTemplate(ContractTemplateViewModel contractTemplateViewModel, string userName);
        Task<BaseResult<long>> InsertContractTemplateHotelProperties(List<HotelFieldViewModel> requestHotelFields, string userName, int templateId);
        Task<BaseResult<long>> InsertContractTemplateRoomProperties(List<RoomFieldViewModel> requestRoomFields, string userName, int templateId);
        Task<BaseResult<long>> InsertContractTemplateHotelFacilities(List<HotelFacilityGroupViewModel> requestFacilityFields, string userName, int templateId);
        Task<BaseResult<long>> InsertContractTemplateRoomFacilities(List<RoomFacilityGroupViewModel> requestFacilityFields, string userName, int templateId);
        Task<BaseResult<bool>> UpdateContractTemplateHotelFields(List<HotelFacilityGroupViewModel> requestFields, string userName, int templateId);
        Task<BaseResult<bool>> UpdateContractTemplateRoomFields(List<RoomFacilityGroupViewModel> requestFields, string userName, int templateId);
        Task<BaseResult<bool>> UpdateContractTemplateHotelFields(List<HotelFieldViewModel> requestFields, string userName, int templateId);
        Task<BaseResult<bool>> UpdateContractTemplateRoomFields(List<RoomFieldViewModel> requestFields, string userName, int templateId);
        Task<BaseResult<bool>> UpdateContractTemplateName(ContractTemplateViewModel request, string userName);
        Task<BaseResult<List<ContractTemplate>>> GetPublishedTemplatesForContract();
        Task<BaseResult<int>> GetCountOfFacilitiesForSelectedTemplate(int templateId, int languageId);
        Task<BaseResult<int>> GetCountOfAmenitiesForSelectedTemplate(int templateId, int languageId);


    }
}
