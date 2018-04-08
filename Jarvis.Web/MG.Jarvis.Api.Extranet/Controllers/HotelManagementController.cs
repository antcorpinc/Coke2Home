using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class HotelManagementController : BaseController
    {
        private IHotels iHotel;

        public HotelManagementController(IHotels iHotel)
        {
            this.iHotel = iHotel;
        }

        /// <summary>
        /// Get hotel by hotel id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task<IActionResult> GetHotel(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            BaseResult<List<HotelView>> hotelResult = await iHotel.GetHotel(id).ConfigureAwait(false);

            if (hotelResult.Result == null || !hotelResult.Result.Any())
            {
                if (hotelResult.IsError && hotelResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelResult.Result == null || !hotelResult.Result.Any())
                {
                    return NoContent(); //204
                }
            }
            HotelDetailsViewModel hotels = HotelManagementResponseMapper.MapHotelDetailsToHotelDetailsViewModel(hotelResult);
            return Ok(hotels);
        }

        #region API's to Create hotel
        /// <summary>
        /// API to create hotel
        /// </summary>
        /// <param name="hotelData"></param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDetailsViewModel Hotels)
        {
            if (Hotels == null)
            {
                return BadRequest();
            }

            var LoggedInUserName = this.LoggedInUserName;
            var result =  await  this.iHotel.SaveAndUpdateHotelInfo(Hotels, LoggedInUserName).ConfigureAwait(false);


            if (result.IsError && result.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            //else if (result.Result == null || result.Result.Count() == 0)
            //{
            //    return NoContent(); //204
            //}
            return Created(Url.RouteUrl(result.Result[0].Id), result.Result[0].Id);
        }


        #endregion API's to Create hotel

        /// <summary>
        ///
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            BaseResult<List<HotelBrandExtendedViewModel>> result;

            var hotelsData = await iHotel.GetAllHotels().ConfigureAwait(false);
            if (hotelsData.IsError && hotelsData.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (hotelsData.Result == null || !hotelsData.Result.Any())
            {
                return NoContent(); //204
            }
            result = DbMapperMasterdata.MapToHotelBrandExtendeViewModel(hotelsData);
            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> GetProfileCompleteness([FromBody][Required] int? HotelId)
        {
            BaseResult<ProfileCompletenessViewModel> result = new BaseResult<ProfileCompletenessViewModel>();
            var profileCompletenessViewModel = new ProfileCompletenessViewModel();
            var profileCompletenessData = await iHotel.GetProfileCompleteness(HotelId.Value).ConfigureAwait(false);
            if (profileCompletenessData.IsError && profileCompletenessData.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (profileCompletenessData.Result == null || !profileCompletenessData.Result.Any())
            {
                return NoContent(); //204
            }
            DbMapperMasterdata.FillProfileCompletenessViewModel(profileCompletenessViewModel, profileCompletenessData);
            result.Result = profileCompletenessViewModel;
            return Ok(result);
        }

        /// <summary>
        /// Get All Hotel Names List
        /// </summary>
        /// <returns>Hotel Names List</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllHotelNames()
        {
            BaseResult<List<HotelNameViewModel>> hotelNameResultFromCache = new BaseResult<List<HotelNameViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<HotelNameViewModel>>(Constants.CacheKeys.HotelNameList)
            };

            if (hotelNameResultFromCache.Result == null || hotelNameResultFromCache.Result.Count == 0)
            {
                BaseResult<List<HotelView>> hotelResult = await iHotel.GetHotels().ConfigureAwait(false);

                if (hotelResult.IsError && hotelResult.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (hotelResult.Result == null || hotelResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = DbMapperMasterdata.MapHotels(hotelResult);
                    RedisCacheHelper.Instance.Set<List<HotelNameViewModel>>(Constants.CacheKeys.HotelNameList, result.Result);
                    return Ok(result); //200
                }
            }

            return Ok(hotelNameResultFromCache); //200
        }


        [HttpPost]
        public async Task<IActionResult> GetHotelsByCityCode([FromBody] string cityCode)
        {
            var hotelsData = await iHotel.GetAllHotelsByCityId(cityCode).ConfigureAwait(false);
            if (hotelsData.IsError)
            {
                return new StatusCodeResult(500);
            }
            else if (!hotelsData.Result.Any())
            {
                return NoContent(); //204
            }

            return Ok(hotelsData);
        }
        /// <summary>
        /// Delete the hotel of particular id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteHotelByHotelId([FromBody]int hotelId)
        {
            BaseResult<bool> hotelResult = new BaseResult<bool>();
            if (hotelId <= default(int))
            {
                hotelResult.IsError = true;
                hotelResult.Message = string.Format(coreHelper.Constants.ErrorMessage.InvalidId);
                return BadRequest(hotelResult);
            }
            string userName = base.LoggedInUserName; 
            hotelResult = await iHotel.DeleteHotelByHotelId(hotelId, userName).ConfigureAwait(false);
            if (hotelResult.Message != null)
            {
                return BadRequest(hotelResult);
            }
            if (hotelResult.IsError || hotelResult.ExceptionMessage != null || hotelResult.Result==default(bool))
            {
                return StatusCode(500, hotelResult);
            }
            return Ok(hotelResult);
        }

        /// <summary>
        /// Get Hotels Without Brands
        /// </summary>
        /// <returns> Hotels Without Brands</returns>
        [HttpGet]
        public async Task<IActionResult> GetHotelsWithoutBrands()
        {
            BaseResult<List<HotelView>> hotelResult = await iHotel.GetHotels().ConfigureAwait(false);

            if (hotelResult.IsError && hotelResult.ExceptionMessage != null)
            {
                return  StatusCode(500, hotelResult);
            }
            else if (hotelResult.Result == null || hotelResult.Result.Count == 0)
            {
                return NoContent(); //204
            }
            else
            {
                var result = HotelManagementResponseMapper.MapHotelsWithoutBrands(hotelResult);
                return Ok(result); //200
            }
        }

        /// <summary>
        /// Get Hotels By BrandId
        /// </summary>
        /// <param name="BrandId">List of brand Id</param>
        /// <returns>Hotels</returns>
        [HttpPost]
        public async Task<IActionResult> GetHotelsByBrandId([FromBody] List<int> BrandIds)
        {
            BaseResult<List<HotelView>> hotelResult = await iHotel.GetAllHotelsByBrandId(BrandIds).ConfigureAwait(false);
            if (hotelResult.IsError && hotelResult.ExceptionMessage != null)
            {
                return StatusCode(500, hotelResult);
            }
            else if (hotelResult.Result == null || hotelResult.Result.Count == 0)
            {
                return NoContent(); //204
            }
            else
            {
                return Ok(hotelResult);
            }
        }
    }
}