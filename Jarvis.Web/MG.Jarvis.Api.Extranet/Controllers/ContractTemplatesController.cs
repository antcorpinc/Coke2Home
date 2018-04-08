using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class ContractTemplatesController : BaseController
    {
        #region Private Methods
        private IMasterData iMasterData;
        private IContract iContract;
        private ITemplate iTemplate;
        private IConfiguration iconfiguration;
        private IAmenities iamenities;
        #endregion Private Methods

        public ContractTemplatesController(IMasterData iMasterData, IContract iContract, IConfiguration configuration, IAmenities iamenities, ITemplate iTemplate)
        {
            this.iMasterData = iMasterData;
            this.iContract = iContract;
            this.iconfiguration = configuration;
            this.iamenities = iamenities;
            this.iTemplate = iTemplate;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelFields()
        {
            return await GetHotelFields(default(int)).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomFields()
        {
            return await GetRoomFields(default(int)).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IActionResult> GetContractTemplates()
        {
            var ContractTemplatesData = await iTemplate.GetContractTemplates().ConfigureAwait(false);
            if (ContractTemplatesData.IsError)
            {
                return new StatusCodeResult(500);
            }
            else if (!ContractTemplatesData.Result.Any())
            {
                return NoContent(); //204
            }
            //result = DbMapperMasterdata.MapTo...ViewModel(Data);
            return Ok(ContractTemplatesData);
        }

        /// <summary>
        /// Get List of Published Templates For Contract Creation
        /// </summary>
        /// <returns>List of Published Templates</returns>
        [HttpGet]
        public async Task<IActionResult> GetPublishedTemplatesForContractCreation()
        {
            var ContractTemplatesData = await iTemplate.GetPublishedTemplatesForContract().ConfigureAwait(false);
            if (ContractTemplatesData.IsError && ContractTemplatesData.ExceptionMessage!=null)
            {
                return new StatusCodeResult(500);
            }
            else if (!ContractTemplatesData.Result.Any())
            {
                return NoContent(); //204
            }
            return Ok(ContractTemplatesData);
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> GetHotelFields([FromBody]IntegerEntityViewModel request)
        {
            return await GetHotelFields(request.Id.Value).ConfigureAwait(false);
        }
        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> GetRoomFields([FromBody] IntegerEntityViewModel request)
        {
            return await GetRoomFields(request.Id.Value).ConfigureAwait(false);
        }
        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateContractTemplate([FromBody] ContractTemplateViewModel request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            if (!Enum.IsDefined(typeof(ObjectState),request.ObjectState.Value))
            {
                //wrong object state
                return BadRequest();
            }
            return await CreateOrUpdateContractTemplateInternal(request).ConfigureAwait(false);
        }
        [HttpPost]
        public async Task<IActionResult> GetHotelFacilityFields([FromBody] int templateId)
        {
            var result = new BaseResult<ContractTemplateViewModel>
            {
                Result = new ContractTemplateViewModel()
            };

            if (templateId < 1)
            {
                result.IsError = true;
                result.Message = Constants.BadRequestErrorMessage.InvalidTemplateId;
                return BadRequest(result);
            }

            var hotelFacilityFields = await iTemplate.GetTemplateHotelFacilityFields(templateId, base.LanguageId).ConfigureAwait(false);

            if (hotelFacilityFields.IsError || hotelFacilityFields.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (hotelFacilityFields.Result == null || !hotelFacilityFields.Result.Any())
            {
                return NoContent(); //204
            }
            result.Result.HotelFacilityFields.AddRange(hotelFacilityFields.Result);

            // ContractTemplateResponseMapper.MapToFacilityFieldToViewModel(hotelFacilityFields.Result, result.Result.HotelFacilityFields);
            //RedisCacheHelper.Instance.Set(Constants.CacheKeys.RoomFieldList, conatractTemplate.RoomFields);
            //}
            return Ok(hotelFacilityFields);

        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> GetRoomFacilityFields([FromBody]IntegerEntityViewModel request)
         {
            var result = new BaseResult<ContractTemplateViewModel>
            {
                Result = new ContractTemplateViewModel()
            };
            var roomFacilityFields = await iTemplate.GetTemplateRoomFields(request.Id.Value, true).ConfigureAwait(false);
            if (roomFacilityFields.IsError || roomFacilityFields.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (!roomFacilityFields.Result.Any())
            {
                return NoContent(); //204
            }
            var roomFacilityResult = await iamenities.GetRoomFacility().ConfigureAwait(false);
            if (roomFacilityResult.IsError || roomFacilityResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (!roomFacilityResult.Result.Any())
            {
                return NoContent(); //204
            }
            var roomFacilityTypeResult = await iamenities.GetRoomFacilityType().ConfigureAwait(false);
            if (roomFacilityTypeResult.IsError || roomFacilityTypeResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            //can be empty
            var roomFacilityGroupResult = await iamenities.GetRoomFacilityGroup().ConfigureAwait(false);
            if (roomFacilityGroupResult.IsError || roomFacilityGroupResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (!roomFacilityGroupResult.Result.Any())
            {
                return NoContent(); //204
            }
            var amenities = AmenitiesResponseMapper.MapRoomFacilitiesToRoomFacilityViewModel(roomFacilityResult.Result);//maps to facilityViewModel
            var amenitiesTypes = AmenitiesResponseMapper.MapRoomFacilityTypeToRoomFacilityViewModel(amenities, roomFacilityTypeResult.Result); //maps to HotelFacilityTypeViewModel
            var amenitiesGroups = AmenitiesResponseMapper.MapRoomFacilityGroupToRoomFacilityGroupViewModel(amenities, roomFacilityGroupResult.Result, amenitiesTypes);  //Maps to HotelFacilityGroupViewModel
            var resultToReturn=ContractTemplateResponseMapper.MapToRoomFacilityFieldViewModel(roomFacilityFields.Result, amenitiesGroups.Result);
            result.Result.RoomFacilityFields.AddRange(resultToReturn);


            return Ok(result);

        }



        /// <summary>
        /// Get Clause Library master data
        /// </summary>
        /// <returns>Clause Library master data</returns>
        [HttpPost]
        public async Task<IActionResult> GetClauseLibraryFields([FromBody] int templateId)
        {
            var result = new BaseResult<ContractTemplateViewModel>
            {
                Result = new ContractTemplateViewModel()
            };

            if (templateId < 1)
            {
                result.IsError = true;
                result.Message = Constants.BadRequestErrorMessage.InvalidTemplateId;
                return BadRequest(result);
            }

            var clauseLibraryField = await iTemplate.GetClauseLibraryFields(templateId, base.LanguageId).ConfigureAwait(false);

            if (clauseLibraryField.IsError && clauseLibraryField.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (clauseLibraryField.Result == null || !clauseLibraryField.Result.Any())
            {
                return NoContent(); //204
            }
            return Ok(clauseLibraryField);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTemplateCopy([FromBody] CopyTemplate request)
        {
            var result = new BaseResult<long>
            {
                Result = 123L
            };
            var templateCopy = await iTemplate.CreateTemplateCopy(request, base.LoggedInUserName).ConfigureAwait(false);

            if (templateCopy.IsError && templateCopy.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (templateCopy.Result == null )
            {
                return NoContent(); //204
            }
            return Ok(templateCopy);
        }
        /// <summary>
        /// Get the count of Hotel Facilities for selected template (while creating contract).
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>Count of facilities</returns>
        [HttpPost]
        public async Task<IActionResult> GetCountOfFacilitiesForSelectedTemplate([FromBody]int templateId)
        {
            var result = new BaseResult<int>();
            if (templateId <= default(int))
            {
                result.IsError = true;
                result.Message = Constants.BadRequestErrorMessage.InvalidTemplateId;
                return BadRequest(result);
            }
            result = await iTemplate.GetCountOfFacilitiesForSelectedTemplate(templateId, base.LanguageId);
            if (result.IsError && result.ExceptionMessage != null)
            {
                return StatusCode(500, result);
            }
            return Ok(result);
        }
        /// <summary>
        ///	Get The count of amenities for selected template (while creating contract).
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>Count of amenities</returns>
        [HttpPost]
        public async Task<IActionResult> GetCountOfAmenitiesForSelectedTemplate([FromBody]int templateId)
        {
            var result = new BaseResult<int>();
            if (templateId <= default(int))
            {
                result.IsError = true;
                result.Message = Constants.BadRequestErrorMessage.InvalidTemplateId;
                return BadRequest(result);
            }
            result = await iTemplate.GetCountOfAmenitiesForSelectedTemplate(templateId, base.LanguageId);
            if (result.IsError && result.ExceptionMessage != null)
            {
                return StatusCode(500, result);
            }
            return Ok(result);
        }
        /// <summary>
        /// Get the count of Hotel Facilities and Room Amenities for selected template (while creating contract).
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>Count of facilities and amenities</returns>
        [HttpPost]
        public async Task<IActionResult> GetCountOfFacilitiesAndAmenitiesForSelectedTemplate([FromBody]int templateId)
        {
            var result = new BaseResult<HotelFacilityRoomAmenity>();
            if (templateId <=default(int))
            {
                result.IsError = true;
                result.Message = Constants.BadRequestErrorMessage.InvalidTemplateId;
                return BadRequest(result);
            }         
            var facilityCount= await iTemplate.GetCountOfFacilitiesForSelectedTemplate(templateId, base.LanguageId);
            var amenityCount= await iTemplate.GetCountOfAmenitiesForSelectedTemplate(templateId, base.LanguageId);
            if (facilityCount.IsError && facilityCount.ExceptionMessage!=null || amenityCount.IsError && amenityCount.ExceptionMessage != null)
            {
                return StatusCode(500, result);
            }
            result.Result = ContractTemplateResponseMapper.MapCountOfHotelFacilityRoomAmenity(facilityCount.Result, amenityCount.Result);
            return Ok(result);
        }
       

        /// <summary>
        /// Deletes Templates
        /// Story 3069 Template - Delete
        /// Task 3380 Extranet Api for Delete template
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteTemplate([FromBody] int templateId)
        {
            var result = new BaseResult<bool>
            {
                Result = new bool()
            };

            if (templateId < 1)
            {
                result.IsError = true;
                result.Message = Constants.BadRequestErrorMessage.InvalidTemplateId;
                return BadRequest(result);
            }

            var template = await iTemplate.DeleteTemplate(templateId, base.LoggedInUserName).ConfigureAwait(false);

            if (template.IsError && template.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }

            return Ok(template);
        }

        #region Private Actions
        private async Task<BaseResult<long>> CreateOrUpdateTemplate( ContractTemplateViewModel request)
        {
            if (request.ObjectState.Value==ObjectState.Added)
            {
                var createContractTemplateResult = await iTemplate.CreateContractTemplate(request, LoggedInUserName).ConfigureAwait(false);
                if(createContractTemplateResult.IsError && createContractTemplateResult.ExceptionMessage != null)
                {
                    createContractTemplateResult.IsError = createContractTemplateResult.IsError;
                    createContractTemplateResult.ExceptionMessage = createContractTemplateResult.ExceptionMessage;
                    return createContractTemplateResult;
                }
                request.Id = (int)createContractTemplateResult.Result;
                return createContractTemplateResult;

            }
            else if(request.ObjectState.Value==ObjectState.Modified)
            {
                var result = new BaseResult<long>() { Result= request.Id };
                var updateContractTemplateResult =await iTemplate.UpdateContractTemplateName(request, LoggedInUserName).ConfigureAwait(false);
                if (updateContractTemplateResult.IsError && updateContractTemplateResult.ExceptionMessage != null)
                {
                    result.IsError = updateContractTemplateResult.IsError;
                    result.ExceptionMessage = updateContractTemplateResult.ExceptionMessage;
                    return result;
                }
                return result;
            }
            else
            {
                return new BaseResult<long>() { Result = request.Id }; ;
            }

        }
        private async Task<BaseResult<bool>> CreateOrUpdateHotelFields(ContractTemplateViewModel request)
        {
            var result = new BaseResult<bool>() { Result = true };
            var hotelFieldsToAdd = request.HotelFields.Where(x => x.ObjectState == ObjectState.Added && x.IsSelected).ToList();
            if (hotelFieldsToAdd.Any())
            {

                var insertHotelFieldsResult = await iTemplate.InsertContractTemplateHotelProperties(hotelFieldsToAdd, LoggedInUserName, request.Id).ConfigureAwait(false);
                if (insertHotelFieldsResult.IsError && insertHotelFieldsResult.ExceptionMessage!=null)
                {
                    result.IsError = insertHotelFieldsResult.IsError;
                    result.ExceptionMessage = insertHotelFieldsResult.ExceptionMessage;
                    return result;
                }

            }
            var hotelFieldsToUpdate = request.HotelFields.Where(x => x.ObjectState == ObjectState.Modified).ToList();
            if (hotelFieldsToUpdate.Any())
            {
                result = await iTemplate.UpdateContractTemplateHotelFields(hotelFieldsToUpdate, LoggedInUserName, request.Id).ConfigureAwait(false);
            }
            return result;
        }
        private async Task<BaseResult<bool>> CreateOrUpdateRoomFields(ContractTemplateViewModel request)
        {
            var result = new BaseResult<bool>() { Result = true };
            var roomFieldsToAdd = request.RoomFields.Where(x => x.ObjectState == ObjectState.Added && x.IsSelected).ToList();
            if (roomFieldsToAdd.Any())
            {

                var insertRoomFieldsResult = await iTemplate.InsertContractTemplateRoomProperties(roomFieldsToAdd, LoggedInUserName, request.Id).ConfigureAwait(false);
                if (insertRoomFieldsResult.IsError && insertRoomFieldsResult.ExceptionMessage != null)
                {
                    result.IsError = insertRoomFieldsResult.IsError;
                    result.ExceptionMessage = insertRoomFieldsResult.ExceptionMessage;
                    return result;
                }
            }
            var roomFieldsToUpdate = request.RoomFields.Where(x => x.ObjectState == ObjectState.Modified).ToList();
            if (roomFieldsToUpdate.Any())
            {
                result = await iTemplate.UpdateContractTemplateRoomFields(roomFieldsToUpdate, LoggedInUserName, request.Id).ConfigureAwait(false);
            }
            return result;
        }
        private async Task<BaseResult<bool>> CreateOrUpdateHotelFacilityFields(ContractTemplateViewModel request)
        {
            var result = new BaseResult<bool>() { Result = true };
            var hotelFacilityFieldsToAdd = request.HotelFacilityFields.Where(x => x.ObjectState == ObjectState.Added && x.IsSelected).ToList();
            if (hotelFacilityFieldsToAdd.Any())
            {
                var insertFacilityFieldResult = await InsertContractTemplateFacilities(request).ConfigureAwait(false);
                if (insertFacilityFieldResult.IsError && insertFacilityFieldResult.ExceptionMessage != null)
                {
                    result.IsError = insertFacilityFieldResult.IsError;
                    result.ExceptionMessage = insertFacilityFieldResult.ExceptionMessage;
                    return result;
                }
            }
            var hotelFacilityFieldsToUpdate = request.HotelFacilityFields.Where(x => x.ObjectState == ObjectState.Modified).ToList();
            if (hotelFacilityFieldsToUpdate.Any())
            {
                result = await iTemplate.UpdateContractTemplateHotelFields(hotelFacilityFieldsToUpdate, LoggedInUserName, request.Id).ConfigureAwait(false);
            }
            return result;
        }
        private async Task<BaseResult<bool>> CreateOrUpdateRoomFacilityFields(ContractTemplateViewModel request)
        {
            var result = new BaseResult<bool>() { Result = true };
            var roomFacilityFieldsToAdd = request.RoomFacilityFields.Where(x => x.ObjectState == ObjectState.Added && x.IsSelected).ToList();
            if (roomFacilityFieldsToAdd.Any())
            {
                var insertRoomFacilityFieldResult = await iTemplate.InsertContractTemplateRoomFacilities(roomFacilityFieldsToAdd, LoggedInUserName, request.Id).ConfigureAwait(false);
                if (insertRoomFacilityFieldResult.IsError && insertRoomFacilityFieldResult.ExceptionMessage != null)
                {
                    result.IsError = insertRoomFacilityFieldResult.IsError;
                    result.ExceptionMessage = insertRoomFacilityFieldResult.ExceptionMessage;
                    return result;
                }

            }
            var roomFacilityFieldsToUpdate = request.RoomFacilityFields.Where(x => x.ObjectState == ObjectState.Modified).ToList();
            if (roomFacilityFieldsToUpdate.Any())
            {
                result = await iTemplate.UpdateContractTemplateRoomFields(roomFacilityFieldsToUpdate, LoggedInUserName, request.Id).ConfigureAwait(false);
            }
            return result;
        }
        private async Task<IActionResult> CreateOrUpdateContractTemplateInternal(ContractTemplateViewModel request)
        {
            BaseResult<long> createContractTemplateResult = null;
            //
            createContractTemplateResult = await CreateOrUpdateTemplate( request).ConfigureAwait(false);
            if (createContractTemplateResult.IsError && createContractTemplateResult.ExceptionMessage != null)
            {
                return StatusCode(500, createContractTemplateResult);
            }
            //
            if (request.HotelFields.Any(x => !x.IsConfigurable && x.IsSelected))
            {
                return BadRequest();
            }
            var createOrUpdateHotelFieldsResult = await CreateOrUpdateHotelFields(request).ConfigureAwait(false);
            if(createOrUpdateHotelFieldsResult.IsError&& createOrUpdateHotelFieldsResult.ExceptionMessage != null)
            {
                return StatusCode(500, createOrUpdateHotelFieldsResult);
            }
            //
            if (request.RoomFields.Any(x => !x.IsConfigurable && x.IsSelected))
            {
                return BadRequest();
            }
            var createOrUpdateRoomFieldsResult= await CreateOrUpdateRoomFields(request).ConfigureAwait(false);
            if (createOrUpdateRoomFieldsResult.IsError && createOrUpdateRoomFieldsResult.ExceptionMessage != null)
            {
                return StatusCode(500, createOrUpdateRoomFieldsResult);
            }
            //
            var createOrUpdateHotelFacilityResult=await  CreateOrUpdateHotelFacilityFields(request).ConfigureAwait(false);
            if (createOrUpdateHotelFacilityResult.IsError && createOrUpdateHotelFacilityResult.ExceptionMessage != null)
            {
                return StatusCode(500, createOrUpdateHotelFacilityResult);
            }
            //
            var createOrUpdateRoomFacilityResult = await CreateOrUpdateRoomFacilityFields(request).ConfigureAwait(false);
            if (createOrUpdateRoomFacilityResult.IsError && createOrUpdateRoomFacilityResult.ExceptionMessage != null)
            {
                return StatusCode(500, createOrUpdateRoomFacilityResult);
            }
            //

            var clauseLibraryToAdd = request.ClauseLibraryFields.Where(x => x.ObjectState == ObjectState.Added && x.IsSelected);
            if (clauseLibraryToAdd.Any())
            {
                var insertClauseLibraryFieldResult = await InsertTemplateClauseLibraryFields(request).ConfigureAwait(false);
            }

            var clauseLibraryToUpdate = request.ClauseLibraryFields.Where(x => x.ObjectState == ObjectState.Modified);
            if (clauseLibraryToUpdate.Any())
            {
                var UpdateClauseLibraryFieldResult = await UpdateTemplateClauseLibraryFields(request).ConfigureAwait(false);
            }
            return Ok(createContractTemplateResult);
        }

        /// <summary>
        /// Insert Template Clause Library Fields
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>result</returns>
        private async Task<BaseResult<long>> InsertTemplateClauseLibraryFields(ContractTemplateViewModel request)
        {
            List<TemplateClauseLibraryViewModel> clauseLibraryToAdd = request.ClauseLibraryFields.Where(x => x.ObjectState == ObjectState.Added && x.IsSelected).ToList();
            return await iTemplate.InsertTemplateClauseLibraryFields(clauseLibraryToAdd, LoggedInUserName, request.Id).ConfigureAwait(false);
        }

        /// <summary>
        /// Update Template Clause Library Fields
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Result</returns>
        private async Task<BaseResult<bool>> UpdateTemplateClauseLibraryFields(ContractTemplateViewModel request)
        {
            List<TemplateClauseLibraryViewModel> clauseLibraryToUpdate = request.ClauseLibraryFields.Where(x => x.ObjectState == ObjectState.Modified).ToList();
            return await iTemplate.UpdateTemplateClauseLibraryFields(clauseLibraryToUpdate, LoggedInUserName, request.Id).ConfigureAwait(false);
        }

        private async Task<BaseResult<long>> InsertContractTemplateFacilities(ContractTemplateViewModel request)
        {
            return await iTemplate.InsertContractTemplateHotelFacilities(request.HotelFacilityFields, LoggedInUserName, request.Id).ConfigureAwait(false);
        }

        private async Task<IActionResult> GetHotelFields(int id)
        {
            var result = new BaseResult<ContractTemplateViewModel>();
            var IsNew = id == default(int);
            BaseResult<ContractTemplate> contaractTemaplateDescriptionData = null;
            if (!IsNew)
            {
                contaractTemaplateDescriptionData = await iTemplate.GetContractTemplateByID(id).ConfigureAwait(false);
                if (contaractTemaplateDescriptionData.IsError)
                {
                    return new StatusCodeResult(500);
                }
                else if (contaractTemaplateDescriptionData.Result == null)
                {
                    return NoContent(); //204
                }
            }
            var ContractTemplatesHotelFields = await iTemplate.GetTemplateHotelFields(id).ConfigureAwait(false);
            if (ContractTemplatesHotelFields.IsError)
            {
                return new StatusCodeResult(500);
            }
            else if (!ContractTemplatesHotelFields.Result.Any())
            {
                return NoContent(); //204
            }
            if (IsNew)
            {
                result.Result = new ContractTemplateViewModel();
                ContractTemplateResponseMapper.MapToHotelFieldViewModel(ContractTemplatesHotelFields.Result, result.Result.HotelFields);
            }
            else
            {
                result.Result = ContractTemplateResponseMapper.MapToContractTemplateHotelViewModel(contaractTemaplateDescriptionData.Result, ContractTemplatesHotelFields.Result);
            }
            return Ok(result);
        }
        private async Task<IActionResult> GetRoomFields(int id)
        {
            var result = new BaseResult<ContractTemplateViewModel>();
            var IsNew = id == default(int);
            BaseResult<ContractTemplate> contaractTemaplateDescriptionData = null;
            if (!IsNew)
            {
                contaractTemaplateDescriptionData = await iTemplate.GetContractTemplateByID(id).ConfigureAwait(false);
                if (contaractTemaplateDescriptionData.IsError)
                {
                    return new StatusCodeResult(500);
                }
                else if (contaractTemaplateDescriptionData.Result == null)
                {
                    return NoContent(); //204
                }
            }
            var ContractTemplatesRoomFields = await iTemplate.GetTemplateRoomFields(id).ConfigureAwait(false);
            if (ContractTemplatesRoomFields.IsError)
            {
                return new StatusCodeResult(500);
            }
            else if (!ContractTemplatesRoomFields.Result.Any())
            {
                return NoContent(); //204
            }
            if (IsNew)
            {
                result.Result = new ContractTemplateViewModel();
                ContractTemplateResponseMapper.MapToRoomFieldViewModel(ContractTemplatesRoomFields.Result, result.Result.RoomFields);
            }
            else
            {
                result.Result = ContractTemplateResponseMapper.MapToContractTemplateRoomViewModel(contaractTemaplateDescriptionData.Result, ContractTemplatesRoomFields.Result);
            }
            return Ok(result);
        }
        #endregion Private Actions
    }
}