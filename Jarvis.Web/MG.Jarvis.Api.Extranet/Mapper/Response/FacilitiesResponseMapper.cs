using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class FacilitiesResponseMapper
    {
        /// <summary>
        /// Maps hotelfacility to hotelfacilityViewModel
        /// </summary>
        /// <param name="facilityList"></param>
        /// <returns></returns>
        public static BaseResult<List<FacilityViewModel>> MapHotelFacilities(BaseResult<List<HotelFacility>> facilityList)
        {
            BaseResult<List<FacilityViewModel>> responseModelList = new BaseResult<List<FacilityViewModel>>();
            List<FacilityViewModel> modelList = new List<FacilityViewModel>();

            foreach (var item in facilityList.Result)
            {

                FacilityViewModel hotelFacilityModel = new FacilityViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    FacilityTypeId = item.FacilityTypeId,
                    FacilityGroupId = item.FacilityGroupId,
                    IsActive = item.IsActive,
                    IsSelected = false
                };

                modelList.Add(hotelFacilityModel);

            }
            responseModelList.Result = modelList;
            return responseModelList;
        }
        /// <summary>
        /// Maps list of facilities to HotelfacilityTypeViewModel
        /// </summary>
        /// <param name="facilityList"></param>
        /// <param name="facilityTypeList"></param>
        /// <returns>List<HotelFacilityTypeViewModel></returns>
        public static BaseResult<List<HotelFacilityTypeViewModel>> MapHotelFacilityType(BaseResult<List<FacilityViewModel>> facilityList, BaseResult<List<HotelFacilityType>> facilityTypeList)
        {
            BaseResult<List<HotelFacilityTypeViewModel>> responseModelList = new BaseResult<List<HotelFacilityTypeViewModel>>();
            List<HotelFacilityTypeViewModel> modelList = new List<HotelFacilityTypeViewModel>();

            foreach (var item in facilityTypeList.Result)
            {

                List<HotelFacility> facility = new List<HotelFacility>();
                List<HotelFacility> facilityWithoutType = new List<HotelFacility>();

                HotelFacilityTypeViewModel hotelFacilityTypeModel = new HotelFacilityTypeViewModel
                {
                    FacilityTypeId = item.Id,
                    FacilityTypeName = item.Name,
                    FacilityGroupId = item.FacilityGroupId,
                    // FacilityList = facility
                };

                foreach (var facilities in facilityList.Result)
                {

                    if (facilities.FacilityTypeId == item.Id && facilities.IsActive)
                        //  facility.Add(facilities);
                        hotelFacilityTypeModel.FacilityList.Add(facilities);
                }
                modelList.Add(hotelFacilityTypeModel);

            }
            responseModelList.Result = modelList;
            return responseModelList;
        }
        /// <summary>
        /// Maps HotelFacilityTypeViewModel to HotelFacilityGroupViewModel
        /// </summary>
        /// <param name="hotelFacilityGroupList"></param>
        /// <param name="hotelFacilityViewModel"></param>
        /// <returns>List<HotelFacilityGroupViewModel></returns>
        public static BaseResult<List<HotelFacilityGroupViewModel>> MapHotelFacilityGroup(BaseResult<List<FacilityViewModel>> hotelFacilityList, BaseResult<List<HotelFacilityGroup>> hotelFacilityGroupList, BaseResult<List<HotelFacilityTypeViewModel>> hotelFacilityViewModel)
        {
            BaseResult<List<HotelFacilityGroupViewModel>> responseModelList = new BaseResult<List<HotelFacilityGroupViewModel>>();
            List<HotelFacilityGroupViewModel> modelList = new List<HotelFacilityGroupViewModel>();
            List<HotelFacilityTypeViewModel> facilityTypeModelList = new List<HotelFacilityTypeViewModel>();

            foreach (var item in hotelFacilityGroupList.Result)
            {

                List<HotelFacility> facilities = new List<HotelFacility>();
                List<HotelFacilityTypeViewModel> facilityTypeList = new List<HotelFacilityTypeViewModel>();

                HotelFacilityTypeViewModel hotelFacilityTypeModel = new HotelFacilityTypeViewModel
                {
                    FacilityGroupId = item.Id,

                };
                foreach (var facility in hotelFacilityList.Result)
                {
                    if (facility.FacilityTypeId == null && facility.FacilityGroupId == item.Id && facility.IsActive)
                    {

                        hotelFacilityTypeModel.FacilityList.Add(facility);
                    }
                }
                if (hotelFacilityTypeModel.FacilityList.Count > 0)
                {
                    hotelFacilityViewModel.Result.Add(hotelFacilityTypeModel);
                }

                HotelFacilityGroupViewModel hotelfacilityGroupModel = new HotelFacilityGroupViewModel
                {
                    FacilityGroupId = item.Id,
                    FacilityGroupName = item.Name,
                    IconPath = item.IconPath

                };

                foreach (var facilityTypes in hotelFacilityViewModel.Result)
                {
                    if (facilityTypes.FacilityGroupId == item.Id)
                    {

                        hotelfacilityGroupModel.HotelFacilityTypes.Add(facilityTypes);

                    }
                }
                modelList.Add(hotelfacilityGroupModel);

            }
            responseModelList.Result = modelList;
            return responseModelList;
        }


        /// <summary>
        /// Maps Selected Facilities
        /// </summary>
        /// <param name="facilityList"></param>
        /// <param name="selectedfacilityList"></param>
        /// <returns></returns>
        public static BaseResult<List<HotelFacilityGroupViewModel>> MapSelectedHotelFacilities(BaseResult<List<HotelFacilityGroupViewModel>> facilityList, BaseResult<List<HotelFacilityRelation>> selectedfacilityList)
        {
            foreach (var item in facilityList.Result)
            {
                foreach (var type in item.HotelFacilityTypes)
                {
                    foreach (var facilities in type.FacilityList)
                    {
                        if (selectedfacilityList != null)
                        {
                            var facility = selectedfacilityList.Result.Where(x => x.FacilityId == facilities.Id).FirstOrDefault();
                            if (facility != null)
                            {
                                facilities.IsSelected = true;
                                facilities.HotelFacilityRelationId = facility.Id;
                            }
                        }
                    }
                }
            }

            return facilityList;
        }
    }
}
