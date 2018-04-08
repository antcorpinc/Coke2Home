using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class PoliciesController : BaseController
    {
        private IPolicies iPolicies;
        public PoliciesController(IPolicies iPolicies)
        {
            this.iPolicies = iPolicies;
        }


        #region Children And Extra Bed Policy
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>ChildrenAndExtraBedPolicies</returns>
        [HttpPost]
        public async Task<IActionResult> GetChildrenAndExtraBedPolicyListingByHotelId([FromBody]int hotelId)
        {
            if (hotelId != default(int) && hotelId > default(int))
            {
                BaseResult<List<ChildrenAndExtraBedPolicies>> childrenAndExtraBedPoliciesResult = await iPolicies.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId).ConfigureAwait(false);

                if (childrenAndExtraBedPoliciesResult.IsError && childrenAndExtraBedPoliciesResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (childrenAndExtraBedPoliciesResult.Result == null || childrenAndExtraBedPoliciesResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = PoliciesResponseMapper.MapChildrenAndExtraBedPolicyList(childrenAndExtraBedPoliciesResult);
                    return Ok(result); //200
                }
            }
            return BadRequest();//400
        }

        /// <summary>
        /// Returns childrens and extra bed policy for specific hotel-Edit Page Get API
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetChildrenAndExtraBedPolicy([FromBody]int hotelId)
        {
            if (hotelId != default(int) && hotelId > default(int))
            {
                BaseResult<List<ChildrenAndExtraBedPolicies>> childrenAndExtraBedPoliciesResult = await iPolicies.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId).ConfigureAwait(false);

                if (childrenAndExtraBedPoliciesResult.IsError && childrenAndExtraBedPoliciesResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }

                BaseResult<List<MaxChildAndExtraBedPerRoom>> MaxChildAndExtraBedPerRoomResult = await iPolicies.GetMaxChildAndExtraBedPerRoom(hotelId).ConfigureAwait(false);

                if (MaxChildAndExtraBedPerRoomResult.IsError && MaxChildAndExtraBedPerRoomResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }

                var result = PoliciesResponseMapper.MapChildrenAndExtraBedPolicyToAddOrUpdate(childrenAndExtraBedPoliciesResult, MaxChildAndExtraBedPerRoomResult);
                return Ok(result); //200
            }
            return BadRequest();//400
        }

        /// <summary>
        /// Create child and extra bed policy
        /// </summary>
        /// <param name="ChildrenAndExtraBedPoliciesViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateModel]
        public async Task<IActionResult> CreateChildrenAndExtraBedPolicy([FromBody]ChildrenAndExtraBedPoliciesViewModel ChildrenAndExtraBedPoliciesViewModel)
        {
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesResult = null;
            string userName = base.LoggedInUserName;

            if (ChildrenAndExtraBedPoliciesViewModel != null && ChildrenAndExtraBedPoliciesViewModel.HotelId > default(int))
            {
                //Fetch list of room by id
                List<Room> roomListResult = new List<Room>();
                var maxChildAndExtraBedPerRoomList = ChildrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList;
                BaseResult<List<Room>> roomsResult = await iPolicies.GetRoomsById(ChildrenAndExtraBedPoliciesViewModel.MaxChildAndExtraBedPerRoomList).ConfigureAwait(false);
                if (roomsResult.IsError && roomsResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                var roomList = roomsResult.Result;

                //Map and retrieve childrenAndExtraBedPolicy and updated roomlist
                PoliciesRequestMapper.MapChildAndExtraBedPolicy(ref childrenAndExtraBedPoliciesResult, ref roomListResult, roomList, ChildrenAndExtraBedPoliciesViewModel, userName);

                //Save or Update Child and Extra Bed Policy
                BaseResult<ChildrenAndExtraBedPolicies> addOrUpdateChildrenAndExtraBedPoliciesResult = await iPolicies.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesResult, ChildrenAndExtraBedPoliciesViewModel.ObjectState).ConfigureAwait(false);

                if (addOrUpdateChildrenAndExtraBedPoliciesResult.IsError && addOrUpdateChildrenAndExtraBedPoliciesResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (addOrUpdateChildrenAndExtraBedPoliciesResult.Result == null)
                {
                    return new NoContentResult();
                }
                else if (addOrUpdateChildrenAndExtraBedPoliciesResult.Message != null)
                {
                    return BadRequest(addOrUpdateChildrenAndExtraBedPoliciesResult);
                }
                //update list of room
                if (roomListResult.Count > 0)
                {
                    BaseResult<bool> updateRoomListResult = await iPolicies.UpdateRoomList(roomListResult).ConfigureAwait(false);
                    if (updateRoomListResult.IsError && updateRoomListResult.ExceptionMessage != null)
                    {
                        return new StatusCodeResult(500);
                    }
                    else if (!updateRoomListResult.Result)
                    {
                        return new NotFoundResult();//404
                    }
                }
                return Ok(addOrUpdateChildrenAndExtraBedPoliciesResult);
            }

            return BadRequest();//400
        }
        #endregion Children And Extra Bed Policy

        #region Cancellation Policy
        /// <summary>
        /// Gets policy cancellation charges from MasterData 
        /// </summary>
        /// <returns>returns cancellation charges :- First night / full charge</returns>
        public async Task<IActionResult> GetCancellationCharges()
        {
            BaseResult<List<CancellationChargesViewModel>> cancellationChargesCache = new BaseResult<List<CancellationChargesViewModel>>()
            {
                Result = RedisCacheHelper.Instance.Get<List<CancellationChargesViewModel>>(Constants.CacheKeys.CancellationChargesList)
            };

            if (cancellationChargesCache.Result == null || cancellationChargesCache.Result.Count == 0)
            {
                BaseResult<List<CancellationCharges>> cancellationChargesResult = await iPolicies.GetCancellationCharges().ConfigureAwait(false);

                if (cancellationChargesResult.IsError && cancellationChargesResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (cancellationChargesResult.Result == null || cancellationChargesResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var chargesListVm = DbMapperMasterdata.MapCancellationCharges(cancellationChargesResult);
                    RedisCacheHelper.Instance.Set<List<CancellationChargesViewModel>>(Constants.CacheKeys.CancellationChargesList, chargesListVm.Result);
                    return Ok(chargesListVm); //200
                }
            }
            return Ok(cancellationChargesCache);
        }

        /// <summary>
        /// Gets Cancellation Policy types from MasterData
        /// </summary>
        /// <returns>Returns cancellation policy types :- Non </returns>
        public async Task<IActionResult> GetCancellationPolicyType()
        {
            BaseResult<List<CancellationPolicyTypeViewModel>> cancellationPolicyTypeChargesCache = new BaseResult<List<CancellationPolicyTypeViewModel>>()
            {
                Result = RedisCacheHelper.Instance.Get<List<CancellationPolicyTypeViewModel>>(Constants.CacheKeys.CancellationPolicyTypeList)
            };

            if (cancellationPolicyTypeChargesCache.Result == null || cancellationPolicyTypeChargesCache.Result.Count == 0)
            {
                BaseResult<List<CancellationPolicyType>> cancellationPolicyTypeResult = await iPolicies.GetCancellationPolicyType().ConfigureAwait(false);

                if (cancellationPolicyTypeResult.IsError && cancellationPolicyTypeResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (cancellationPolicyTypeResult.Result == null || cancellationPolicyTypeResult.Result.Count == 0)
                {
                    return this.NoContent(); // 204
                }
                else
                {
                    var chargesListVm = DbMapperMasterdata.MapCancellationPolicyType(cancellationPolicyTypeResult);
                    RedisCacheHelper.Instance.Set<List<CancellationPolicyTypeViewModel>>(Constants.CacheKeys.CancellationPolicyTypeList, chargesListVm.Result);
                    return this.Ok(chargesListVm); // 200
                }
            }
            return this.Ok(cancellationPolicyTypeChargesCache);
        }

        [HttpPost]
        public IActionResult GetCancellationPolicy([FromBody] int hotelId)
        {
            if (hotelId <= 0)
            {
                return BadRequest();
            }
            BaseResult<List<CancellationPolicyViewModel>> cancellationPolicyResult = this.iPolicies.GetCancellationPolicies(hotelId);
            if (cancellationPolicyResult.IsError && cancellationPolicyResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (cancellationPolicyResult.Result == null || cancellationPolicyResult.Result.Count == 0)
            {
                return this.NoContent(); // 204
            }
            else
            {
                //var chargesListVm = DbMapperMasterdata.MapCancellationPolicyType(cancellationPolicyResult);
                return this.Ok(cancellationPolicyResult); // 200
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCancellationPolicyById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var getResponse = await iPolicies.GetCancellationPolicyById(id).ConfigureAwait(false);
            if (getResponse.IsError && getResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if(getResponse.Result == null)
            {
                return this.NoContent(); // 204
            }
            else if (getResponse.Message != null)
            {
                return BadRequest(getResponse);
            }
            return Ok(getResponse); //200
        }

        [HttpPost]
        public async Task<IActionResult> GetCancellationPolicyClausesByPolicyId(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var getResponse = await iPolicies.GetCancellationPolicyClausesById(id).ConfigureAwait(false);
            if (getResponse.IsError && getResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (getResponse.Message != null)
            {
                return BadRequest(getResponse);
            }
            return Ok(getResponse); //200
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCancellationPolicyClause([FromBody]int policyClauseID)
        {
            if (policyClauseID <= 0)
            {
                return BadRequest();
            }
            var updateResponse = await iPolicies.DeleteCancellationPolicyClauses(policyClauseID).ConfigureAwait(false);
            if (updateResponse.IsError && updateResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (updateResponse.Message != null)
            {
                return BadRequest(updateResponse);
            }
            return Ok(updateResponse); //200

        }

        [HttpPost]
        public async Task<IActionResult> SaveAndUpdateCancellationPolicy([FromBody]CancellationPolicyViewModel cancellationPolicyViewModel )
        {
            if (cancellationPolicyViewModel == null || cancellationPolicyViewModel.HotelId==0)
            {
                return BadRequest();
            }
            var LoggedInUserName = this.LoggedInUserName;
            var updateResponse =await iPolicies.SaveAndUpdateCancellationPolicy(cancellationPolicyViewModel, base.LoggedInUserId).ConfigureAwait(false);
            if (updateResponse.IsError && updateResponse.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (updateResponse.Message != null)
            {
                return BadRequest(updateResponse);
            }
            return Ok(updateResponse); //200
        }
        #endregion Cancellation Policy
    }
}