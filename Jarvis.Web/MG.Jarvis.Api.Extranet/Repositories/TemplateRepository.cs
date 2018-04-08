using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Common;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;
namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class TemplateRepository : ITemplate
    {
        #region Private Member
        private IConnection<TemplateClauseLibrary> iTemplateCaluseLibrary;
        private IConnection<TemplateClauseLibraryRelation> iTemplateClauseLibraryRelation;
        private IConnection<Field> iTemplate;
        private IConnection<ContractTemplate> iContractTemplateLibrary;
        private IConnection<HotelField> iHotelFieldLibrary;
        private IConnection<RoomField> iRoomFieldLibrary;
        private IConnection<TemplateHotelField> iTemplateHotelFieldLibrary;
        private IConnection<TemplateRoomField> iTemplateRoomFieldLibrary;
        private IConfiguration iConfiguration;
        #endregion Private Member
        public TemplateRepository(IConnection<TemplateClauseLibrary> iTemplateCaluseLibrary,
                                  IConnection<TemplateClauseLibraryRelation> iTemplateClauseLibraryRelations,
                                  IConnection<Field> iTemplate,
                                  IConnection<ContractTemplate> iContractTemplateLibrary,
                                  IConnection<HotelField> iHotelFieldLibrary,
                                  IConnection<RoomField> iRoomFieldLibrary,
                                  IConnection<TemplateHotelField> iTemplateHotelFieldLibrary,
                                  IConnection<TemplateRoomField> iTemplateRoomFieldLibrary,
                                  IConfiguration iConfiguration)
        {
            this.iTemplateCaluseLibrary = iTemplateCaluseLibrary;
            this.iTemplateClauseLibraryRelation = iTemplateClauseLibraryRelations;
            this.iTemplate = iTemplate;
            this.iContractTemplateLibrary = iContractTemplateLibrary;
            this.iHotelFieldLibrary = iHotelFieldLibrary;
            this.iRoomFieldLibrary = iRoomFieldLibrary;
            this.iTemplateHotelFieldLibrary = iTemplateHotelFieldLibrary;
            this.iTemplateRoomFieldLibrary = iTemplateRoomFieldLibrary;
            this.iConfiguration = iConfiguration;
        }

        public async Task<BaseResult<List<TemplateClauseLibraryViewModel>>> GetClauseLibraryFields(int templateId, int languageId)
        {
            BaseResult<List<TemplateClauseLibraryViewModel>> clauses = new BaseResult<List<TemplateClauseLibraryViewModel>>();
            DynamicParameters paramCollection = ContractsRequestMapper.CreateTemplateClauseLibraryFieldsRequest(templateId, languageId);
            var clauseLibraryFieldList = await iTemplateCaluseLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetClauseLibraryFieldsByTemplateId, paramCollection).ConfigureAwait(false);
            clauses.Result = ContractTemplateResponseMapper.MapToClauseLibraryFieldsToViewModel(clauseLibraryFieldList.Result);
            return clauses;
        }

        /// <summary>
        /// Insert Template Clause Library Fields
        /// </summary>
        /// <param name="requestClauseLibraryFields">request Clause Library Fields</param>
        /// <param name="userName">user Name</param>
        /// <param name="templateId">template Id</param>
        /// <returns></returns>
        public Task<BaseResult<long>> InsertTemplateClauseLibraryFields(List<TemplateClauseLibraryViewModel> requestClauseLibraryFields, string userName, int templateId)
        {
            var templateClauseLibraryFields = ContractTemplateRequestMapper.MapToContractTemplateClauseLibraryModel(requestClauseLibraryFields, userName, templateId);
            return iTemplateClauseLibraryRelation.InsertEntityList(templateClauseLibraryFields);
        }

        /// <summary>
        /// UpdateTemplateClauseLibraryFields
        /// </summary>
        /// <param name="requestClauseLibraryFields">requestClauseLibraryFields</param>
        /// <param name="userName">user Name</param>
        /// <param name="templateId">template Id</param>
        /// <returns>Status</returns>
        public async Task<BaseResult<bool>> UpdateTemplateClauseLibraryFields(List<TemplateClauseLibraryViewModel> requestClauseLibraryFields, string userName, int templateId)
        {
            BaseResult<bool> result = new BaseResult<bool>();

            foreach (var item in requestClauseLibraryFields)
            {
               DynamicParameters paramCollection = ContractsRequestMapper.UpdateTemplateClauseLibraryFieldsRequest(item, userName, templateId);
                var res =    await iTemplateCaluseLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.UpdateClauseLibraryFieldsByTemplateId, paramCollection).ConfigureAwait(false);

                if (res.IsError || res.ExceptionMessage != null)
                {
                    result.IsError = res.IsError;
                    result.ExceptionMessage = res.ExceptionMessage;
                    return result;
                }
            }

            return result;
        }

        public async Task<BaseResult<Field>> CreateTemplateCopy(CopyTemplate request, string userName)
        {
            BaseResult<List<Field>> templateList = new BaseResult<List<Field>>();
            DynamicParameters paramCollection = ContractTemplateRequestMapper.CreateTemplateCopyRequest(request, userName);
            templateList =  await iTemplate.ExecuteStoredProcedure(Constants.StoredProcedure.CreateTemplateCopy, paramCollection).ConfigureAwait(false);
            if (templateList != null )
            {
                BaseResult<Field> copiedtemplate = new BaseResult<Field>
                {
                    IsError = templateList.IsError,
                    ExceptionMessage = templateList.ExceptionMessage
                };
                if (templateList.Result != null && templateList.Result.Any())
                {
                    copiedtemplate.Result = templateList.Result[0];
                }
                return copiedtemplate;
            }
            return null;

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> DeleteTemplate(int templateId, string userName)
        {
            BaseResult<bool> updateResult = new BaseResult<bool>();
            var template = iContractTemplateLibrary.GetListByPredicate(x => x.Id == templateId).Result.Result.FirstOrDefault(); ;
            if (template != null)
            {
                template.IsDeleted = true;
                template.UpdatedBy = userName;
                template.UpdatedDate = DateTime.Now.JakartaOffset();
                updateResult = await this.iContractTemplateLibrary.UpdateEntityByDapper(template);
            }
            else
            {
                updateResult.IsError = true;
                updateResult.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoTemplateOfID;
                updateResult.Message = string.Format(coreHelper.Constants.ErrorMessage.NoTemplateOfID, templateId);
                return updateResult;
            }
            return updateResult;
        }
        public async Task<BaseResult<List<HotelField>>> GetHotelFields()
        {
            return await iHotelFieldLibrary.GetListByPredicate
                (
                    x => x.IsActive && !x.IsDeleted
                    &&
                    x.FacilityGroupId == default(int) && x.FacilityId == default(int) && x.FacilityTypeId == default(int)
                ).ConfigureAwait(false);
        }

        public async Task<BaseResult<List<RoomField>>> GetRoomFields()
        {
            return await iRoomFieldLibrary.GetListByPredicate
                (
                    x => x.IsActive && !x.IsDeleted
                    &&
                    x.FacilityGroupId == default(int) && x.FacilityId == default(int) && x.FacilityTypeId == default(int)
                ).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Contract templates.
        /// </summary>
        /// <returns>Contract templates</returns>
        public async Task<BaseResult<List<ContractTemplate>>> GetContractTemplates()
        {
            return await iContractTemplateLibrary.GetListByPredicate(x => x.IsActive && !x.IsDeleted).ConfigureAwait(false);
        }


        public async Task<BaseResult<List<TemplateHotelField>>> GetTemplateHotelFields(int templateId, bool isFacility = false)
        {
            var paramCollection = ContractTemplateRequestMapper.CreateTemplateHotelFacilityRequestParams(templateId, 1, isFacility);
            return await iTemplateHotelFieldLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelFieldsByTemplateId, paramCollection).ConfigureAwait(false);

        }

        public async Task<BaseResult<List<TemplateRoomField>>> GetTemplateRoomFields(int templateId, bool isFacility = false)
        {
            var paramCollection = ContractTemplateRequestMapper.CreateTemplateHotelFacilityRequestParams(templateId, 1, isFacility);
            return await iTemplateRoomFieldLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetRooomFieldsByTemplateId, paramCollection).ConfigureAwait(false);
        }

        public async Task<BaseResult<ContractTemplate>> GetContractTemplateByID(int id)
        {
            return await iContractTemplateLibrary.GetEntity(id).ConfigureAwait(false);
        }

        public Task<BaseResult<long>> CreateContractTemplate(ContractTemplateViewModel contractTemplateViewModel, string userName)
        {
            var contractTemplate = ContractTemplateRequestMapper.MapToContractTemplateModel(contractTemplateViewModel, userName);
            return iContractTemplateLibrary.InsertEntity(contractTemplate);
        }

        public Task<BaseResult<long>> InsertContractTemplateHotelProperties(List<HotelFieldViewModel> requestHotelFields, string userName, int templateId)
        {
            var hotelFieldProperties = ContractTemplateRequestMapper.MapToContractTemplateHotelFieldsModel(requestHotelFields, userName, templateId);
            return iTemplateHotelFieldLibrary.InsertEntityList(hotelFieldProperties);
        }

        public Task<BaseResult<long>> InsertContractTemplateRoomProperties(List<RoomFieldViewModel> requestRoomFields, string userName, int templateId)
        {
            var roomFieldsProperties = ContractTemplateRequestMapper.MapToContractTemplateRoomFieldsModel(requestRoomFields, userName, templateId);
            return iTemplateRoomFieldLibrary.InsertEntityList(roomFieldsProperties);
        }


        public Task<BaseResult<long>> InsertContractTemplateHotelFacilities(List<HotelFacilityGroupViewModel> requestFacilityFields, string userName, int templateId)
        {
            var hotelFacilities = ContractTemplateRequestMapper.MapToContractTemplateHotelFacilityModel(requestFacilityFields, userName, templateId);
            return iTemplateHotelFieldLibrary.InsertEntityList(hotelFacilities);
        }
        public async Task<BaseResult<List<HotelFacilityGroupViewModel>>> GetTemplateHotelFacilityFields(int templateId, int languageId)
        {
            DynamicParameters paramCollection = ContractTemplateRequestMapper.CreateTemplateHotelFacilityRequestParams(templateId, languageId, true);
            //return await iTemplateHotelFieldLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelFieldsByTemplateId, paramCollection).ConfigureAwait(false);
            var facilityGroup = await iTemplateHotelFieldLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelFieldsByTemplateId, paramCollection).ConfigureAwait(false);
            //IConnection<HotelFacilityGroup> iHotelFacilityGroupLibrary,
            //                        IConnection< HotelFacilityType > iHotelFacilityTypeLibrary,
            //                        IConnection<HotelFacility> iHotelFacilityLibrary,
            //                        IConnection< HotelFacilityRelation > iHotelFacilityRelationLibrary,
            //                        IConnection<InOutTime> inOutTimeLibrary


            IFacilities iFacilities = new FacilitiesRepository(new DapperConnection<HotelFacilityGroup>(iConfiguration), new DapperConnection<HotelFacilityType>(iConfiguration), new DapperConnection<HotelFacility>(iConfiguration), null, null);
            BaseResult<List<HotelFacilityGroup>> hotelFacilityGroup = await iFacilities.GeHotelFacilityGroup().ConfigureAwait(false);
            BaseResult<List<HotelFacilityType>> hotelFacilityType = await iFacilities.GeHotelFacilityType().ConfigureAwait(false);
            BaseResult<List<HotelFacility>> hotelFacility = await iFacilities.GeHotelFacility().ConfigureAwait(false);
            var facilities = FacilitiesResponseMapper.MapHotelFacilities(hotelFacility); ////maps to facilityViewModel
            var result = FacilitiesResponseMapper.MapHotelFacilityType(facilities, hotelFacilityType); ////maps to HotelFacilityTypeViewModel
            var result1 = FacilitiesResponseMapper.MapHotelFacilityGroup(facilities, hotelFacilityGroup, result);  ////Maps to HotelFacilityGroupViewModel

            ContractTemplateResponseMapper.MapToFacilityFieldToViewModel(facilityGroup.Result, result1.Result);

            return result1;
        }

        public async Task<BaseResult<long>> InsertContractTemplateRoomFacilities(List<RoomFacilityGroupViewModel> requestFacilityFields, string userName, int templateId)
        {
            var roomFacilities = ContractTemplateRequestMapper.MapToContractTemplateRoomFacilityModel(requestFacilityFields, userName, templateId);
            return await iTemplateRoomFieldLibrary.InsertEntityList(roomFacilities).ConfigureAwait(false);
        }

        public async Task<BaseResult<bool>> UpdateContractTemplateHotelFields(List<HotelFacilityGroupViewModel> requestFields, string userName, int templateId)
        {
            var result = new BaseResult<bool>() { Result = true };
            var hotelFields = ContractTemplateRequestMapper.MapToContractTemplateHotelFacilityModel(requestFields, userName, templateId, true);
            foreach (var field in hotelFields)
            {
                var param = ContractTemplateRequestMapper.CreateTemplateFieldsRequestParams(field);
                var updateResult = await iTemplateHotelFieldLibrary.ExecuteStoredProcedureInsertUpdate(Constants.StoredProcedure.UpdateHotelFields, param).ConfigureAwait(false);
                if (updateResult.IsError && updateResult.ExceptionMessage != null)
                {
                    return updateResult;
                }
            }
            return result;
        }

        public async Task<BaseResult<bool>> UpdateContractTemplateRoomFields(List<RoomFacilityGroupViewModel> requestFields, string userName, int templateId)
        {
            var result = new BaseResult<bool>() { Result = true };
            var roomFields = ContractTemplateRequestMapper.MapToContractTemplateRoomFacilityModel(requestFields, userName, templateId, true);
            foreach (var field in roomFields)
            {
                var param = ContractTemplateRequestMapper.CreateTemplateFieldsRequestParams(field);
                var updateResult = await iTemplateRoomFieldLibrary.ExecuteStoredProcedureInsertUpdate(Constants.StoredProcedure.UpdateRooomFields, param).ConfigureAwait(false);
                if (updateResult.IsError && updateResult.ExceptionMessage != null)
                {
                    return updateResult;
                }
            }
            return result;
        }

        public async Task<BaseResult<bool>> UpdateContractTemplateHotelFields(List<HotelFieldViewModel> requestFields, string userName, int templateId)
        {
            var result = new BaseResult<bool>() { Result = true };
            var hotelFields = ContractTemplateRequestMapper.MapToContractTemplateHotelFieldsModel(requestFields, userName, templateId, true);
            foreach (var field in hotelFields)
            {
                var param = ContractTemplateRequestMapper.CreateTemplateFieldsRequestParams(field);
                var updateResult = await iTemplateHotelFieldLibrary.ExecuteStoredProcedureInsertUpdate(Constants.StoredProcedure.UpdateHotelFields, param).ConfigureAwait(false);
                if (updateResult.IsError && updateResult.ExceptionMessage != null)
                {
                    return updateResult;
                }
            }
            return result;
        }

        public async Task<BaseResult<bool>> UpdateContractTemplateRoomFields(List<RoomFieldViewModel> requestFields, string userName, int templateId)
        {
            var result = new BaseResult<bool>() { Result = true };
            var roomFields = ContractTemplateRequestMapper.MapToContractTemplateRoomFieldsModel(requestFields, userName, templateId, true);
            foreach (var field in roomFields)
            {
                var param = ContractTemplateRequestMapper.CreateTemplateFieldsRequestParams(field);
                var updateResult = await iTemplateRoomFieldLibrary.ExecuteStoredProcedureInsertUpdate(Constants.StoredProcedure.UpdateRooomFields, param).ConfigureAwait(false);
                if (updateResult.IsError && updateResult.ExceptionMessage != null)
                {
                    return updateResult;
                }
            }
            return result;
        }

        /// <summary>
        /// Update Contract Template
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="userName">userName</param>
        /// <returns>Bool Value (Success or not)</returns>
        public async Task<BaseResult<bool>> UpdateContractTemplateName(ContractTemplateViewModel request, string userName)
        {
            var templateRequest = ContractTemplateRequestMapper.MapToContractTemplateModel(request, userName);
            var param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.TemplateId, templateRequest.Id);
            param.Add(Constants.StoredProcedureParameters.Name, templateRequest.Name);
            param.Add(Constants.StoredProcedureParameters.UpdatedBy, templateRequest.UpdatedBy);
            param.Add(Constants.StoredProcedureParameters.UpdatedDate, templateRequest.UpdatedDate);
            param.Add(Constants.StoredProcedureParameters.IsPublished, templateRequest.IsPublished);
            return await iContractTemplateLibrary.ExecuteStoredProcedureInsertUpdate(Constants.StoredProcedure.UpdateContractTemplateName, param).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Published templates.
        /// </summary>
        /// <returns>Published templates</returns>
        public async Task<BaseResult<List<ContractTemplate>>> GetPublishedTemplatesForContract()
        {
            return await iContractTemplateLibrary.GetListByPredicate(x => x.IsActive && !x.IsDeleted && x.IsPublished).ConfigureAwait(false);
        }
        /// <summary>
        /// Get The count of facilities for selected template (while creating contract).
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="languageId"></param>
        /// <returns>Count of facilities</returns>
        public async Task<BaseResult<int>> GetCountOfFacilitiesForSelectedTemplate(int templateId, int languageId)
        {
            var result = new BaseResult<int>();
            DynamicParameters paramCollection = ContractTemplateRequestMapper.CreateTemplateHotelFacilityRequestParams(templateId, languageId, true);
            var list = await iTemplateHotelFieldLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetHotelFieldsByTemplateId, paramCollection).ConfigureAwait(false);
            if(list.IsError==true && list.ExceptionMessage!=null)
            {
                result.IsError = list.IsError;
                result.ExceptionMessage = list.ExceptionMessage;
                return result;
            }
            if (list != null && list.Result.Any())
            {
                var count = list.Result.Count(a => a.IsSelected == true);
                result.Result = count;
                return result;
            }
            return result;
        }
        /// <summary>
        /// Get The count of amenities for selected template (while creating contract).
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="languageId"></param>
        /// <returns> Count of amenities</returns>
        public async Task<BaseResult<int>> GetCountOfAmenitiesForSelectedTemplate(int templateId, int languageId)
        {
            var result = new BaseResult<int>();
            DynamicParameters paramCollection = ContractTemplateRequestMapper.CreateTemplateHotelFacilityRequestParams(templateId, languageId, true);
            var list = await iTemplateRoomFieldLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetRooomFieldsByTemplateId, paramCollection).ConfigureAwait(false);
            if (list.IsError == true && list.ExceptionMessage != null)
            {
                result.IsError = list.IsError;
                result.ExceptionMessage = list.ExceptionMessage;
                return result;
            }
            if (list != null && list.Result.Any())
            {
                var count = list.Result.Count(a => a.IsSelected == true);
                result.Result = count;
                return result;
            }
            return result;
        }
    }

}
