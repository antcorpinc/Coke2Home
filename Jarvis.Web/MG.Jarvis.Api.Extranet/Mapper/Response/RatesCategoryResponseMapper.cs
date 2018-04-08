using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.RatesCategory;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class RatesCategoryResponseMapper
    {
        /// <summary>
        ///  Return the mapped Market viewmodel
        /// </summary>
        /// <param name="marketListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<MarketViewModel>> MapMarket(BaseResult<List<Market>> marketListDetail)
        {
            BaseResult<List<MarketViewModel>> marketViewModelList = new BaseResult<List<MarketViewModel>>();
            List<MarketViewModel> modelList = new List<MarketViewModel>();
            foreach (var item in marketListDetail.Result)
            {
                MarketViewModel model = new MarketViewModel
                {
                    MarketId = item.Id,
                    MarketName = item.Name
                };
                modelList.Add(model);
            }
            marketViewModelList.Result = modelList;
            return marketViewModelList;
        }

        /// <summary>
        /// Maps rate Category 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>BaseResult<List<RateCategoryViewModel>></returns>
        public static BaseResult<List<RateCategoryListViewModel>> MapRateCategoryList(List<RateCategoryList> request)
        {
            BaseResult<List<RateCategoryListViewModel>> model = new BaseResult<List<RateCategoryListViewModel>>();
            List<RateCategoryListViewModel> rateCategoryList = new List<RateCategoryListViewModel>();
            foreach (var item in request)
            {
                RateCategoryListViewModel rateCategoryModel = new RateCategoryListViewModel
                {
                    Id = item.Id,
                    CancellationPolicyName = item.CancellationPolicyName,
                    Markets = item.Markets,
                    MealPlanName = item.MealPlanName,
                    Name = item.Name,
                    RoomTypeName = item.RoomTypeName,
                    IsActive = item.IsActive
                };
                rateCategoryList.Add(rateCategoryModel);
            }
            model.Result = rateCategoryList;
            return model;
        }
        
        /// <summary>
        /// Map RateCategoryViewModel
        /// </summary>
        /// <param name="rateCategoryResponse"></param>
        /// <param name="roomTypeList"></param>
        /// <returns></returns>
        public static RateCategoryViewModel MapToRateCategoryViewModel(RateCategory rateCategoryResponse, List<RatePlans> roomTypeList)
        {
            var rateCategoryViewModel = AutoMapper.Mapper.Map<RateCategory, RateCategoryViewModel>(rateCategoryResponse);
            if (roomTypeList != null)
            {
                foreach (var item in roomTypeList)
                {
                    var ratePlansViewModel = AutoMapper.Mapper.Map<RatePlans, RatePlansViewModel>(item);
                    if(item.IsDeleted)
                    {
                        ratePlansViewModel.IsSelected = false;
                    }
                    else
                    {
                        ratePlansViewModel.IsSelected = true;
                    }
                    rateCategoryViewModel.RoomTypeList.Add(ratePlansViewModel);
                }
            }
            return rateCategoryViewModel;
        }
    }
}
