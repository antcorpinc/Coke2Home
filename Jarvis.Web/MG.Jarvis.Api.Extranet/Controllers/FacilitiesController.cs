// <copyright file="FacilitiesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MG.Jarvis.Api.Extranet.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MG.Jarvis.Api.Extranet.Helper;
    using MG.Jarvis.Api.Extranet.Helper.Mapper;
    using MG.Jarvis.Api.Extranet.Interfaces;
    using MG.Jarvis.Api.Extranet.Mapper.Response;
    using MG.Jarvis.Api.Extranet.ViewModel;
    using MG.Jarvis.Core.Cache;
    using MG.Jarvis.Core.Model;
    using MG.Jarvis.Core.Model.Hotel;
    using MG.Jarvis.Core.Model.MasterData;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Facilities Controller
    /// </summary>
    public class FacilitiesController : BaseController
    {
        private IFacilities iFacilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilitiesController"/> class.
        /// </summary>
        /// <param name="iFacilities">iFacilities</param>
        public FacilitiesController(IFacilities iFacilities)
        {
            this.iFacilities = iFacilities;
        }

        /// <summary>
        ///  Returns the list of facility groups with thier respective facility type and facilities
        /// </summary>
        /// <param name="hotelId">hotel Id</param>
        /// <returns>Hotel Facility Group</returns>
        [HttpPost]
        public async Task<IActionResult> GetHotelFacilityGroups([FromBody]int? hotelId)
        {
            if (hotelId < 1)
            {
                return this.BadRequest();
            }

            BaseResult<List<HotelFacilityGroupViewModel>> hotelFacilityGroupResult = new BaseResult<List<HotelFacilityGroupViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<HotelFacilityGroupViewModel>>(Constants.CacheKeys.HotelFacilityGroupList)
            };
            BaseResult<List<HotelFacilityRelation>> facilitiesSelected = await this.iFacilities.GetSelectedFacilities(hotelId).ConfigureAwait(false);

            if (hotelFacilityGroupResult.Result == null || hotelFacilityGroupResult.Result.Count == 0) 
            {
                BaseResult<List<HotelFacilityGroup>> hotelFacilityGroup = await this.iFacilities.GeHotelFacilityGroup().ConfigureAwait(false);
                BaseResult<List<HotelFacilityType>> hotelFacilityType = await this.iFacilities.GeHotelFacilityType().ConfigureAwait(false);
                BaseResult<List<HotelFacility>> hotelFacility = await this.iFacilities.GeHotelFacility().ConfigureAwait(false);

                if ((hotelFacilityGroup.IsError && hotelFacilityGroup.ExceptionMessage != null) || (hotelFacilityType.IsError && hotelFacilityType.ExceptionMessage != null) || (hotelFacility.IsError && hotelFacility.ExceptionMessage != null))
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelFacilityGroup.Result == null || hotelFacilityGroup.Result.Count == 0 || hotelFacilityType.Result == null || hotelFacilityType.Result.Count == 0 || hotelFacility.Result == null || hotelFacility.Result.Count == 0)
                {
                    return this.NoContent(); ////204
                }
                else
                {
                    var facilities = FacilitiesResponseMapper.MapHotelFacilities(hotelFacility); ////maps to facilityViewModel
                    var result = FacilitiesResponseMapper.MapHotelFacilityType(facilities, hotelFacilityType); ////maps to HotelFacilityTypeViewModel
                    var result1 = FacilitiesResponseMapper.MapHotelFacilityGroup(facilities, hotelFacilityGroup, result);  ////Maps to HotelFacilityGroupViewModel
                    RedisCacheHelper.Instance.Set<List<HotelFacilityGroupViewModel>>(Constants.CacheKeys.HotelFacilityGroupList, result1.Result);
                    var mappedFacility = FacilitiesResponseMapper.MapSelectedHotelFacilities(result1, facilitiesSelected);
                    return this.Ok(mappedFacility);
                }
            }

            if (facilitiesSelected.Result == null || facilitiesSelected.Result.Count == 0)
            {
                return this.Ok(hotelFacilityGroupResult);
            }
            else
            {
                var mappedFacilities = FacilitiesResponseMapper.MapSelectedHotelFacilities(hotelFacilityGroupResult, facilitiesSelected);
                return this.Ok(mappedFacilities); ////200
            }
        }

        /// <summary>
        /// Save Facilities
        /// </summary>
        /// <param name="hotelFacilityViewModel">hotel Facility View Model</param>
        /// <returns>Create and update hotel Facility relation</returns>
        [HttpPost]
        public async Task<IActionResult> CreateHotelFacilityRelation([FromBody] HotelFacilityViewModel hotelFacilityViewModel)
        {
            string userName = base.LoggedInUserName;
            if (hotelFacilityViewModel != null)
            {
                BaseResult<long> result = await this.iFacilities.InsertAndUpdateHotelFacilityRelation(hotelFacilityViewModel, userName);
                if (result.IsError || result.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }

                return this.Ok(result); ////200
            }
            else
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Returns true If Hotel has Facilities
        /// </summary>
        /// <param name="hotelId">hotelId</param>
        /// <returns>Boolean value weather facility exist fro hotel or not</returns>
        [HttpPost]
        public async Task<IActionResult> IsHotelFacilityExits([FromBody]int? hotelId)
        {
            if (hotelId == null)
            {
                return this.BadRequest();
            }

            BaseResult<bool> result = new BaseResult<bool>();
            result = await this.iFacilities.IsHotelFacilityExits(hotelId);
            if (result.IsError && result.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }

            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }
    }
}