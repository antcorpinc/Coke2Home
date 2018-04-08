using AutoMapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.RatesCategory;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public class RatesCategoryRequestMapper
    {
        /// <summary>
        /// Map Rate Category while inserting record
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static RateCategory MapToRateCategoryModel(RateCategoryViewModel source, string userName)
        {
            var destination = AutoMapper.Mapper.Map<RateCategoryViewModel, RateCategory>(source);
            destination.CreatedBy = userName;
            destination.UpdatedBy = userName;
            destination.CreatedDate = DateTime.Now.JakartaOffset();
            destination.UpdatedDate = DateTime.Now.JakartaOffset();
            destination.IsActive = true;
            destination.IsDeleted = false;
            return destination;
        }

        /// <summary>
        /// Map Rate Plans while inserting record
        /// </summary>
        /// <param name="source"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static List<RatePlans> MapToRatePlansModel(RateCategoryViewModel source, string userName)
        {
            List<RatePlans> ratePlansResult = new List<RatePlans>();
            foreach (var item in source.RoomTypeList)
            {
                var destination = AutoMapper.Mapper.Map<RatePlansViewModel, RatePlans>(item);
                destination.RateCategoryId = source.Id;
                destination.CreatedBy = userName;
                destination.UpdatedBy = userName;
                destination.CreatedDate = DateTime.Now.JakartaOffset();
                destination.UpdatedDate = DateTime.Now.JakartaOffset();
                destination.IsActive = true;
                if(item.IsSelected)
                {
                    destination.IsDeleted = false;
                }
                else
                {
                    destination.IsDeleted = true;
                }
                
                ratePlansResult.Add(destination);
            }
            return ratePlansResult;
        }

        /// <summary>
        /// Map Rate Category while updating record
        /// </summary>
        /// <param name="rateCategoryToMap"></param>
        /// <param name="rateCategoryDatabase"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static RateCategory AutoMapperRateCategory(RateCategoryViewModel rateCategoryToMap, RateCategory rateCategoryDatabase, string userName)
        {
            var rateCategoryMapped = AutoMapper.Mapper.Map<RateCategory>(rateCategoryToMap);
            rateCategoryMapped.CreatedBy = rateCategoryDatabase.CreatedBy;
            rateCategoryMapped.CreatedDate = rateCategoryDatabase.CreatedDate;
            rateCategoryMapped.UpdatedBy = userName;
            rateCategoryMapped.UpdatedDate = DateTime.Now.JakartaOffset();
            rateCategoryMapped.IsDeleted = rateCategoryDatabase.IsDeleted;
            return rateCategoryMapped;
        }

        /// <summary>
        /// Map Rate Plans while updating record
        /// </summary>
        /// <param name="ratePlansToMap"></param>
        /// <param name="ratePlansDatabase"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static RatePlans AutoMapperRatePlans(RatePlansViewModel ratePlansToMap, RatePlans ratePlansDatabase, string userName)
        {
            var ratePlansMapped = AutoMapper.Mapper.Map<RatePlans>(ratePlansToMap);
            ratePlansMapped.IsActive = true;
            if (ratePlansToMap.IsSelected)
            {
                ratePlansMapped.IsDeleted = false;
            }
            else
            {
                ratePlansMapped.IsDeleted = true;
            }
            ratePlansMapped.Id = ratePlansDatabase.Id;
            ratePlansMapped.RateCategoryId = ratePlansDatabase.RateCategoryId;
            ratePlansMapped.CreatedBy = ratePlansDatabase.CreatedBy;
            ratePlansMapped.CreatedDate = ratePlansDatabase.CreatedDate;
            ratePlansMapped.UpdatedBy = userName;
            ratePlansMapped.UpdatedDate = DateTime.Now.JakartaOffset();
            return ratePlansMapped;
        }
    }
}
