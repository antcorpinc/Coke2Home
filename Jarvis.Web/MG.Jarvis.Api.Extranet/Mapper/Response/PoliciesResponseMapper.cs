using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public class PoliciesResponseMapper
    {
        
        /// <summary>
        ///  Return the mapped ChildrenAndExtraBedPoliciesList 
        /// </summary>
        /// <param name="ChildrenAndExtraBedPolicies"></param>
        /// <returns>ChildAndExraBedPolicyListViewModel</returns>
        public static BaseResult<List<ChildAndExraBedPolicyListViewModel>> MapChildrenAndExtraBedPolicyList(BaseResult<List<ChildrenAndExtraBedPolicies>> childrenAndExtraBedPoliciesListDetail)
        {
            BaseResult<List<ChildAndExraBedPolicyListViewModel>> childrenAndExtraBedPoliciesViewModelList = new BaseResult<List<ChildAndExraBedPolicyListViewModel>>();
            List<ChildAndExraBedPolicyListViewModel> modelList = new List<ChildAndExraBedPolicyListViewModel>();
            foreach (var item in childrenAndExtraBedPoliciesListDetail.Result)
            {
                ChildAndExraBedPolicyListViewModel model = new ChildAndExraBedPolicyListViewModel
                {
                    ChildAndExtrabedPolicyId = item.Id,
                    MinChildAge = item.MinChildAge,
                    MaxChildAge = item.MaxChildAge,
                    MaxInfantAge = item.MaxInfantAge,
                    CotPriceTypeId = item.CotPriceTypeId,
                    CotPrice = item.CotPrice,
                    IsExtraBedAllowed = item.IsExtraBedAllowed
                };
                modelList.Add(model);
            }
            childrenAndExtraBedPoliciesViewModelList.Result = modelList;
            return childrenAndExtraBedPoliciesViewModelList;
        }
        /// <summary>
        ///  Return the mapped ChildrenAndExtraBedPoliciesViewModel 
        /// </summary>
        /// <param name="ChildrenAndExtraBedPolicies"></param>
        /// <returns>ChildAndExraBedPolicyListViewModel</returns>
        public static BaseResult<List<ChildrenAndExtraBedPoliciesViewModel>> MapChildrenAndExtraBedPolicyToAddOrUpdate(BaseResult<List<ChildrenAndExtraBedPolicies>> childrenAndExtraBedPoliciesListDetail, BaseResult<List<MaxChildAndExtraBedPerRoom>> maxChildAndExtraBedPerRoomViewModelListDetail)
        {
            BaseResult<List<ChildrenAndExtraBedPoliciesViewModel>> childrenAndExtraBedPoliciesViewModelList = new BaseResult<List<ChildrenAndExtraBedPoliciesViewModel>>();
            ChildrenAndExtraBedPoliciesViewModel model = new ChildrenAndExtraBedPoliciesViewModel();
            List<ChildrenAndExtraBedPoliciesViewModel> modelList = new List<ChildrenAndExtraBedPoliciesViewModel>();
            foreach (var item in childrenAndExtraBedPoliciesListDetail.Result)
            {
                model.Id = item.Id;
                model.IsChildrenAllowed = item.IsChildrenAllowed;
                model.MinChildAge = item.MinChildAge;
                model.MaxChildAge = item.MaxChildAge;
                model.IsExtraCotAllowed = item.IsExtraCotAllowed;
                model.MinInfantAge = item.MinInfantAge;
                model.MaxInfantAge = item.MaxInfantAge;
                model.CotPrice = item.CotPrice;
                model.CotPriceTypeId = item.CotPriceTypeId; 
                model.IsExtraBedAllowed = item.IsExtraBedAllowed;
                model.HotelId = item.HotelId;
            }
            var maxChildAndExtraBedPerRoomListResult = MapMaxChildAndExtraBedPerRoom(maxChildAndExtraBedPerRoomViewModelListDetail);
            model.MaxChildAndExtraBedPerRoomList.AddRange(maxChildAndExtraBedPerRoomListResult.Result);
            modelList.Add(model);
            childrenAndExtraBedPoliciesViewModelList.Result = modelList;
            return childrenAndExtraBedPoliciesViewModelList;
        }

        /// <summary>
        ///  Return the mapped ChildrenAndExtraBedPoliciesList 
        /// </summary>
        /// <param name="MaxChildAndExtraBedPerRoom"></param>
        /// <returns>MaxChildAndExtraBedPerRoomViewModel</returns>
        public static BaseResult<List<MaxChildAndExtraBedPerRoomViewModel>> MapMaxChildAndExtraBedPerRoom(BaseResult<List<MaxChildAndExtraBedPerRoom>> maxChildAndExtraBedPerRoomViewModelListDetail)
        {
            BaseResult<List<MaxChildAndExtraBedPerRoomViewModel>> maxChildAndExtraBedPerRoomViewModelList = new BaseResult<List<MaxChildAndExtraBedPerRoomViewModel>>();
            List<MaxChildAndExtraBedPerRoomViewModel> modelList = new List<MaxChildAndExtraBedPerRoomViewModel>();
            foreach (var item in maxChildAndExtraBedPerRoomViewModelListDetail.Result)
            {
                MaxChildAndExtraBedPerRoomViewModel model = new MaxChildAndExtraBedPerRoomViewModel();
                model.HotelId = item.HotelId;
                model.RoomId = item.RoomId;
                model.RoomName = item.RoomName;
                model.NoOfGuest = item.NoOfGuest;
                model.BedCount = item.BedCount;
                model.MaxChildren = item.MaxChildren;
                if (item.NoOfGuest == null)
                {
                    model.NoOfGuest = 0;
                }
                else
                {
                    model.NoOfGuest = item.NoOfGuest;
                }
                if (item.BedCount == null)
                {
                    model.BedCount = 0;
                }
                else
                {
                    model.BedCount = item.BedCount;
                }
                model.ExtraBedCount = item.ExtraBedCount;
                modelList.Add(model);

            }
            maxChildAndExtraBedPerRoomViewModelList.Result = modelList;
            return maxChildAndExtraBedPerRoomViewModelList;
        }
    }
}
