using AutoMapper;
using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public class PoliciesRequestMapper
    {

        /// <summary>
        /// Map ChildrenAndExtraBedPolicies
        /// </summary>
        /// <param name="childrenAndExtraBedPoliciesViewModel"></param>
        /// <param name="isActive"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        public static void MapChildAndExtraBedPolicy(ref ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesResult, ref List<Room> roomListResult, List<Room> roomList, ChildrenAndExtraBedPoliciesViewModel childrenAndExtraBedPoliciesViewModel, string userName)
        {
            childrenAndExtraBedPoliciesResult = new ChildrenAndExtraBedPolicies();

            childrenAndExtraBedPoliciesResult.Id = childrenAndExtraBedPoliciesViewModel.Id;
            childrenAndExtraBedPoliciesResult.IsChildrenAllowed = childrenAndExtraBedPoliciesViewModel.IsChildrenAllowed;
            childrenAndExtraBedPoliciesResult.MinChildAge = childrenAndExtraBedPoliciesViewModel.MinChildAge;
            childrenAndExtraBedPoliciesResult.MaxChildAge = childrenAndExtraBedPoliciesViewModel.MaxChildAge;
            childrenAndExtraBedPoliciesResult.IsExtraCotAllowed = childrenAndExtraBedPoliciesViewModel.IsExtraCotAllowed;
            childrenAndExtraBedPoliciesResult.IsExtraBedAllowed = childrenAndExtraBedPoliciesViewModel.IsExtraBedAllowed;
            childrenAndExtraBedPoliciesResult.MinInfantAge = childrenAndExtraBedPoliciesViewModel.MinInfantAge;
            childrenAndExtraBedPoliciesResult.MaxInfantAge = childrenAndExtraBedPoliciesViewModel.MaxInfantAge;
            childrenAndExtraBedPoliciesResult.CotPrice = childrenAndExtraBedPoliciesViewModel.CotPrice;
            childrenAndExtraBedPoliciesResult.CotPriceTypeId = childrenAndExtraBedPoliciesViewModel.CotPriceTypeId; //(childrenAndExtraBedPoliciesViewModel.CotPriceTypeId==null)? 1: childrenAndExtraBedPoliciesViewModel.CotPriceTypeId.Value;
            childrenAndExtraBedPoliciesResult.HotelId = childrenAndExtraBedPoliciesViewModel.HotelId;
            childrenAndExtraBedPoliciesResult.IsActive = true;
            childrenAndExtraBedPoliciesResult.IsDeleted = false;

            foreach (var item in childrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList)
            {
                foreach (var room in roomList)
                {
                    if(room.Id==item.RoomId && item.ObjectState == ObjectState.Modified)//
                    {
                        room.ExtraBedCount = item.ExtraBedCount;
                        room.CreatedBy = userName;
                        room.UpdatedBy = userName;
                        room.MaxChildren = item.MaxChildren;
                        roomListResult.Add(room);
                    }
                }
            }
        }

        /// <summary>
        /// Maps view model of hotelmeal to hotelmeal model
        /// </summary>
        /// <param name="childrenAndExtraBedPoliciesToMap"></param>
        /// <param name="hotelMealDatabase"></param>
        /// <param name="userName"></param>
        /// <returns>Message</returns>
        public static ChildrenAndExtraBedPolicies AutoMapperChildrenAndExtraBedPolicy(ChildrenAndExtraBedPolicies childrenAndExtraBedPolicyToMap, ChildrenAndExtraBedPolicies childrenAndExtraBedPolicyDatabase)
        {
            var childrenAndExtraBedPolicyMapped = AutoMapper.Mapper.Map<ChildrenAndExtraBedPolicies>(childrenAndExtraBedPolicyToMap);
            ResolveRemainingParamtersChildrenAndExtraBedPolicy(childrenAndExtraBedPolicyToMap, childrenAndExtraBedPolicyDatabase);
            return childrenAndExtraBedPolicyMapped;
        }

        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamtersChildrenAndExtraBedPolicy(ChildrenAndExtraBedPolicies destination, ChildrenAndExtraBedPolicies source)
        {
            destination.Id = source.Id;
            destination.IsDeleted = source.IsDeleted;
        }
    }

    public class ChildrenAndExtraBedPolicyIdResolver : IValueResolver<ChildrenAndExtraBedPolicies, ChildrenAndExtraBedPolicies, int>
    {
        public int Resolve(ChildrenAndExtraBedPolicies source, ChildrenAndExtraBedPolicies destination, int destMember, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
