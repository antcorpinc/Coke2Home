//// <copyright file="FacilitiesRepository.cs" company="PlaceholderCompany">
//// Copyright (c) PlaceholderCompany. All rights reserved.
//// </copyright>

namespace MG.Jarvis.Api.Extranet.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MG.Jarvis.Api.Extranet.Helper;
    using MG.Jarvis.Api.Extranet.Interfaces;
    using MG.Jarvis.Api.Extranet.ViewModel;
    using MG.Jarvis.Core.DAL.Interfaces;
    using MG.Jarvis.Core.Model;
    using MG.Jarvis.Core.Model.Hotel;
    using MG.Jarvis.Core.Model.MasterData;

    public class FacilitiesRepository : IFacilities
    {
        private IConnection<HotelFacilityGroup> iHotelFacilityGroupLibrary;
        private IConnection<HotelFacilityType> iHotelFacilityTypeLibrary;
        private IConnection<HotelFacility> iHotelFacilityLibrary;
        private IConnection<HotelFacilityRelation> iHotelFacilityRelationLibrary;
        private IConnection<InOutTime> inOutTimeLibrary;

        public FacilitiesRepository(
                                    IConnection<HotelFacilityGroup> iHotelFacilityGroupLibrary,
                                    IConnection<HotelFacilityType> iHotelFacilityTypeLibrary,
                                    IConnection<HotelFacility> iHotelFacilityLibrary,
                                    IConnection<HotelFacilityRelation> iHotelFacilityRelationLibrary,
                                    IConnection<InOutTime> inOutTimeLibrary)
        {
            this.iHotelFacilityGroupLibrary = iHotelFacilityGroupLibrary;
            this.iHotelFacilityTypeLibrary = iHotelFacilityTypeLibrary;
            this.iHotelFacilityLibrary = iHotelFacilityLibrary;
            this.iHotelFacilityRelationLibrary = iHotelFacilityRelationLibrary;
            this.inOutTimeLibrary = inOutTimeLibrary;
        }

        /// <summary>
        /// Returns list of Hotel Facility Group list
        /// </summary>
        /// <returns>List<HotelFacilityGroup></returns>
        public async Task<BaseResult<List<HotelFacilityGroup>>> GeHotelFacilityGroup()
        {
            return await this.iHotelFacilityGroupLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns list of Hotel Facility type list
        /// </summary>
        /// <returns>List<HotelFacilityType></returns>
        public async Task<BaseResult<List<HotelFacilityType>>> GeHotelFacilityType()
        {
            return await this.iHotelFacilityTypeLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns list of Hotel Facility list
        /// </summary>
        /// <returns>List of Hotel Facility</returns>
        public async Task<BaseResult<List<HotelFacility>>> GeHotelFacility()
        {
            return await this.iHotelFacilityLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns list of facilities in hotels
        /// </summary>
        /// <returns>List of Selected Facilities</returns>
        public async Task<BaseResult<List<HotelFacilityRelation>>> GetSelectedFacilities(int? hotelId)
        {
            return await this.iHotelFacilityRelationLibrary.GetListByPredicate(x => x.IsDeleted == false && x.HotelId == hotelId).ConfigureAwait(false);
        }

        /// <summary>
        /// Saves The Facilities of that specific hotel
        /// </summary>
        /// <param name="hotelFacilityViewModel">hotel Facility View Model</param>
        /// <returns>long</returns>
        public async Task<BaseResult<long>> InsertAndUpdateHotelFacilityRelation(HotelFacilityViewModel hotelFacilityViewModel, string userName)
        {
            BaseResult<long> result = new BaseResult<long>();

            if (hotelFacilityViewModel != null)
            {
                foreach (var item in hotelFacilityViewModel.FacilityGroupList)
                {
                    foreach (var facilityType in item.HotelFacilityTypes)
                    {
                        foreach (var facility in facilityType.FacilityList)
                        {
                            if (facility.ObjectState == ObjectState.Added)
                            {
                                if (facility.IsSelected == true)
                                {
                                    HotelFacilityRelation hotelFacilityRelation = new HotelFacilityRelation
                                    {
                                        HotelId = hotelFacilityViewModel.HotelId,
                                        FacilityId = facility.Id,
                                        FacilityTypeId = facility.FacilityTypeId,
                                        FacilityGroupId = facility.FacilityGroupId,
                                        IsDeleted = false,
                                        IsProvisioned = facility.IsSelected,
                                        CreatedBy = userName,
                                        UpdatedBy = userName,
                                        StartDate = DateTime.Now,
                                        EndDate = DateTime.Now
                                    };
                                    result = await this.iHotelFacilityRelationLibrary.InsertEntity(hotelFacilityRelation);
                                    if (result.IsError)
                                    {
                                        return result;
                                    }
                                }
                            }

                            if (facility.ObjectState == ObjectState.Deleted)
                            {
                                BaseResult<bool> updateResult = new BaseResult<bool>();
                                var facilities = this.iHotelFacilityRelationLibrary.GetListByPredicate(x => x.HotelId == hotelFacilityViewModel.HotelId && x.Id == facility.HotelFacilityRelationId && x.FacilityId == facility.Id && x.IsDeleted==false).Result.Result.FirstOrDefault();
                                if (facilities != null)
                                {
                                    facilities.IsDeleted = true;
                                    facilities.UpdatedBy = userName;
                                    facilities.UpdatedDate = DateTime.Now.JakartaOffset();
                                    updateResult = await this.iHotelFacilityRelationLibrary.UpdateEntityByDapper(facilities);
                                }

                                if (result.IsError)
                                {
                                    return result;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// returns Whether the hotel has facilities or not
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<BaseResult<bool>></returns>
        public async Task<BaseResult<bool>> IsHotelFacilityExits(int? hotelId)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            result.Result = false;
            var selectedFacilities = await this.GetSelectedFacilities(hotelId);
            if (selectedFacilities.ExceptionMessage != null || selectedFacilities.IsError)
            {
                result.IsError = true;
                return result;
            }

            if (selectedFacilities != null)
            {
                if (selectedFacilities.Result.Count > 0)
                {
                    result.Result = true;
                }
            }

            return result;
        }
    }
}
