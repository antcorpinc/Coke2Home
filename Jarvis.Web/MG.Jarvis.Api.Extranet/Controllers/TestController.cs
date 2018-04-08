using MG.Jarvis.Api.Extranet.Interfaces;

using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model.MasterData;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class TestController : Controller
    {


        private ITest iMasterData;
        public TestController(ITest iMasterData)
        {
            this.iMasterData = iMasterData;
        }
      

        #region Test Methods
        /// <summary>
        /// 
        /// </summary>
        public async Task<IActionResult> TestExceptionStatus()
        {
            BaseResult<List<HotelType>> hotelTyepResult = new BaseResult<List<HotelType>>();
            return new StatusCodeResult(500);
        }

        public IActionResult CheckCache()
        {
            //RedisCacheHelper.Instance.Set("HotelType", hotelTypes.Result);
            RedisCacheHelper.Instance.Set("TestKey", "TestData");
            string Cachedata = RedisCacheHelper.Instance.Get("TestKey");
            // HotelType cachedData = RedisCacheHelper.Instance.Get<HotelType>("HotelType");
            return Ok(Cachedata);
        }
    

        public async Task<IActionResult> GetHotelAndRoom()
        {
           //// DateTime.Now.JakartaOffset();
            BaseResult<List<Hotel>> hotelTyepResult = await iMasterData.GetHotelAndRooms().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }

        public async Task<IActionResult> GetHotelAndRoomsByDapper()
        {
            BaseResult<List<Hotel>> hotelTyepResult = await iMasterData.GetHotelAndRoomsByDapper().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }

        public async Task<IActionResult> GetHotelAndRoomsByDapperCustomModel()
        {
            BaseResult<dynamic> hotelTyepResult = await iMasterData.GetHotelAndRoomsByDapperCustomModel().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }
        public async Task<IActionResult> InsertHotelAndRoom()
        {
            BaseResult<long> hotelTyepResult = await iMasterData.InsertHotelAndRoomsByEntity().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }

        public async Task<IActionResult> InsertHotelAndRoomsByDapper()
        {
            BaseResult<long> hotelTyepResult = await iMasterData.InsertHotelAndRoomsByDapper().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }
        public async Task<IActionResult> UpdateHotelAndRooms()
        {
            BaseResult<Hotel> hotelTyepResult = await iMasterData.UpdateHotelAndRooms().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }

        public async Task<IActionResult> UpdateHotelAndRoomsByDapper()
        {
            BaseResult<bool> hotelTyepResult = await iMasterData.UpdateHotelAndRoomsByDapper().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }

        public async Task<IActionResult> TestGuidInsert()
        {
            Test t = new Test
            {
                TestName = "TestName"
            };
            BaseResult<long> hotelTyepResult = await iMasterData.InsertTestGuid(t).ConfigureAwait(false);
            if (hotelTyepResult.IsError || hotelTyepResult.ExceptionMessage != null)
                 return StatusCode(500);
            return Ok(hotelTyepResult); //200
        }

        public async Task<IActionResult> ExecuteStoredProcedureWithMultipleDataSet()
        {
            Test t = new Test
            {
                TestName = "TestName"
            };
            BaseResult<IEnumerable<Hotel>> hotelTyepResult = await iMasterData.ExecuteStoredProcedureWithMultipleDataSet().ConfigureAwait(false);
            return Ok(hotelTyepResult); //200
        }

        //public IActionResult InsertHotelAndContact()
        //{
           
        //    BaseResult<bool> hotelTyepResult =  iMasterData.InsertHotelByContact();
        //    return Ok(hotelTyepResult); //200
        //}
        #endregion Test Methods
    }
}
