using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Common;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class ContractTemplateRequestMapper
    {
        public static ContractTemplate MapToContractTemplateModel(ContractTemplateViewModel source, string userName)
        {
            var destination = AutoMapper.Mapper.Map<ContractTemplateViewModel, ContractTemplate>(source);
            destination.CreatedBy = userName;
            destination.UpdatedBy = userName;
            destination.CreatedDate = DateTime.Now.JakartaOffset();
            destination.UpdatedDate = DateTime.Now.JakartaOffset();
            destination.IsActive = true;
            destination.IsDeleted = false;
            return destination;
        }
        public static List<TemplateRoomField> MapToContractTemplateRoomFieldsModel(List<RoomFieldViewModel> source, string userName, int templateId, bool IncludeUnSelected = false)
        {
            var destination = new List<TemplateRoomField>();
            foreach (var item in source)
            {
                if (IncludeUnSelected || item.IsSelected)
                {
                    var field = AutoMapper.Mapper.Map<RoomFieldViewModel, TemplateRoomField>(item);
                    field.TemplateId = templateId;
                    field.CreatedBy = userName;
                    field.UpdatedBy = userName;
                    field.CreatedDate = DateTime.Now.JakartaOffset();
                    field.UpdatedDate = DateTime.Now.JakartaOffset();
                    destination.Add(field);
                }
            }
            return destination;
        }

        /// <summary>
        /// Maps ClauseLibraryViewModel to template clause Library.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userName"></param>
        /// <param name="templateId"></param>
        /// <returns>List of TemplateClauseLibraryRelation</returns>
        public static List<TemplateClauseLibraryRelation> MapToContractTemplateClauseLibraryModel(List<TemplateClauseLibraryViewModel> source, string userName, int templateId)
        {
            var destination = new List<TemplateClauseLibraryRelation>();
            foreach (var item in source)
            {
                var field = AutoMapper.Mapper.Map<TemplateClauseLibraryViewModel, TemplateClauseLibraryRelation>(item);
                field.TemplateId = templateId;
                field.CreatedBy = userName;
                field.UpdatedBy = userName;
                field.CreatedDate = DateTime.Now.JakartaOffset();
                field.UpdatedDate = DateTime.Now.JakartaOffset();
                destination.Add(field);
            }

            return destination;
        }
        public static List<TemplateHotelField> MapToContractTemplateHotelFieldsModel(List<HotelFieldViewModel> source,string userName,int templateId,bool IncludeUnSelected=false)
        {
            var destination = new List<TemplateHotelField>();
            foreach (var item in source)
            {
                if (IncludeUnSelected||item.IsSelected)
                {
                    var field = AutoMapper.Mapper.Map<HotelFieldViewModel, TemplateHotelField>(item);
                    field.TemplateId = templateId;
                    field.CreatedBy = userName;
                    field.UpdatedBy = userName;
                    field.CreatedDate = DateTime.Now.JakartaOffset();
                    field.UpdatedDate = DateTime.Now.JakartaOffset();
                    destination.Add(field);
                }
            }
            return destination;
        }

        public static List<TemplateHotelField> MapToContractTemplateHotelFacilityModel(List<HotelFacilityGroupViewModel> source, string userName, int templateId, bool IncludeUnSelected = false)
        {
            var destination = new List<TemplateHotelField>();
            foreach (var item in source)
            {
                if (IncludeUnSelected || item.IsSelected)
                {
                    var field = AutoMapper.Mapper.Map<HotelFacilityGroupViewModel, TemplateHotelField>(item);
                    field.TemplateId = templateId;
                    field.UpdatedBy = field.CreatedBy = userName;
                    field.UpdatedDate = field.CreatedDate = DateTime.Now.JakartaOffset();
                    destination.Add(field);
                }
            }
            return destination;
        }
        public static List<TemplateRoomField> MapToContractTemplateRoomFacilityModel(List<RoomFacilityGroupViewModel> source, string userName, int templateId, bool IncludeUnSelected = false)
        {
            var destination = new List<TemplateRoomField>();
            foreach (var item in source)
            {
                if (IncludeUnSelected || item.IsSelected)
                {
                    var field = AutoMapper.Mapper.Map<RoomFacilityGroupViewModel, TemplateRoomField>(item);
                    field.TemplateId = templateId;
                    field.UpdatedBy = field.CreatedBy = userName;
                    field.UpdatedDate = field.CreatedDate = DateTime.Now.JakartaOffset();
                    destination.Add(field);
                }
            }
            return destination;
        }
        public static DynamicParameters CreateTemplateHotelFacilityRequestParams(int templateId, int languageId,bool IsFacility)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.TemplateId, templateId);
            param.Add(Constants.StoredProcedureParameters.LanguageId, languageId);
            param.Add(Constants.StoredProcedureParameters.IsFacility, IsFacility);
            return param;
        }
        public static DynamicParameters CreateTemplateFieldsRequestParams(Field request)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.TemplateId, request.TemplateId);
            param.Add(Constants.StoredProcedureParameters.FieldId, request.FieldId);
            param.Add(Constants.StoredProcedureParameters.IsSelected, request.IsSelected);
            param.Add(Constants.StoredProcedureParameters.UpdatedBy, request.UpdatedBy);
            param.Add(Constants.StoredProcedureParameters.UpdatedDate, request.UpdatedDate);
            return param;
        }
        public static DynamicParameters CreateTemplateCopyRequest(CopyTemplate request,string userName)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.TemplateId, request.TemplateId);
            param.Add(Constants.StoredProcedureParameters.TemplateName, request.TemplateName);
            param.Add(Constants.StoredProcedureParameters.CreatedBy, userName);
          
            return param;
        }
    }
}
