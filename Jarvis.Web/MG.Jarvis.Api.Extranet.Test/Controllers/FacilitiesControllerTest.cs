using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    internal class FacilitiesControllerTest
    {
        #region Private Variables
        private FacilitiesController mockFacilitiesController;
        private Mock<IFacilities> mockFacilitiesRepository;
        #endregion Private Variables

        #region Settings
        public FacilitiesControllerTest()
        {
            mockFacilitiesRepository = new Moq.Mock<IFacilities>();
            mockFacilitiesController = new FacilitiesController(mockFacilitiesRepository.Object);
        }
        #endregion Settings

        #region GetHotelFacilityGroups

        #region Negative Test Cases

        [Test]

        public async Task TestGetHotelFacilityGroups_Exception_InternalServerError()
        {
            int id = 73;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelFacilityGroupList);
            //mockMasterDataRepository.Setup(a => a.GeHotelFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityGroup>> { IsError = true, ExceptionMessage = new Exception() }));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityGroup>>() { Result = new List<HotelFacilityGroup> { new HotelFacilityGroup { Id = 1, Name = "Group1" } } }));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacilityType()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacility()).Returns(Task.FromResult(new BaseResult<List<HotelFacility>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actioResult = await mockFacilitiesController.GetHotelFacilityGroups(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetHotelFacilityGroups_EmptyResult_NoContentResponse()
        {
            int id = 73;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelFacilityGroupList);
            mockFacilitiesRepository.Setup(a => a.GeHotelFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityGroup>>()));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacilityType()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityType>>()));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacility()).Returns(Task.FromResult(new BaseResult<List<HotelFacility>>()));
            IActionResult actioResult = await mockFacilitiesController.GetHotelFacilityGroups(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetHotelFacilityGroups_Success_OkResponse()
        {
            int id = 73;
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelFacilityGroupList);
            mockFacilitiesRepository.Setup(a => a.GeHotelFacilityGroup()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityGroup>>() { Result = new List<HotelFacilityGroup> { new HotelFacilityGroup { Id = 1, Name = "Group1", IsActive = true } } }));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacilityType()).Returns(Task.FromResult(new BaseResult<List<HotelFacilityType>>() { Result = new List<HotelFacilityType> { new HotelFacilityType { Id = 1, Name = "FacilityType1", FacilityGroupId = 1, IsActive = true } } }));
            mockFacilitiesRepository.Setup(a => a.GeHotelFacility()).Returns(Task.FromResult(new BaseResult<List<HotelFacility>>() { Result = new List<HotelFacility> { new HotelFacility { Id = 1, Name = "Facility1", FacilityTypeId = 1, FacilityGroupId = 1, IsActive = true } } }));
            IActionResult actioResult = await mockFacilitiesController.GetHotelFacilityGroups(id);
            BaseResult<List<HotelFacilityGroupViewModel>> comnbinedHotelFacilityGroupList = (actioResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<HotelFacilityGroupViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 200);
            Assert.IsTrue(comnbinedHotelFacilityGroupList.Result.Count > 0);
            Assert.IsNotNull(comnbinedHotelFacilityGroupList);
            Assert.IsTrue(!comnbinedHotelFacilityGroupList.IsError);
            Assert.IsTrue(comnbinedHotelFacilityGroupList.Result != null);
            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<HotelFacilityGroup>>(Constants.CacheKeys.HotelFacilityGroupList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.HotelFacilityGroupList);
        }


        #endregion Postive Test Cases

        #endregion GetHotelFacilityGroups

        #region CreateHotelFacilityRelation
        #region Negative test Cases
     
        [Test]
        public void TestCreateHotelFacilityRelation_Failed_Error()
        {
            //Arrange
            var facilities = new FacilityViewModel()
            {
                Id = 1,
                FacilityGroupId = 1,
                FacilityTypeId = 1,
                IsSelected = true,
                IsActive = true,
                Name = "ABC"
            };
            var facilityType = new HotelFacilityTypeViewModel()
            {
                FacilityTypeId = 1,
                FacilityGroupId = 1,
                FacilityTypeName = "TypeName",
            };
            facilityType.FacilityList.Add(facilities);
            var facilityGroup = new HotelFacilityGroupViewModel()
            {
                FacilityGroupId = 1,
                FacilityGroupName = "Group1",
                IconPath = "",
            };
            facilityGroup.HotelFacilityTypes.Add(facilityType);
            var facilityModel = new HotelFacilityViewModel()
            {
                HotelId = 73,
            };
            facilityModel.FacilityGroupList.Add(facilityGroup);
            mockFacilitiesRepository.Setup(x => x.InsertAndUpdateHotelFacilityRelation(It.IsAny<HotelFacilityViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<long>()
            { 
           
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            var result =  mockFacilitiesController.CreateHotelFacilityRelation(facilityModel);
            //Assert
            mockFacilitiesRepository.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        #endregion
        #region  Positive test cases
        [Test]
        public async Task TestCreateHotelFacilityRelation_SuccessOkResponse()
        {
            //Arrange
            var userName = "MGIT";
            var id = 1;
            var facilities = new FacilityViewModel()
            {
                Id = 1,
                FacilityGroupId = 1,
                FacilityTypeId = 1,
                IsSelected = true,
                IsActive = true,
                Name = "ABC"
            };       
            var facilityType = new HotelFacilityTypeViewModel()
            {
                FacilityTypeId = 1,
                FacilityGroupId = 1,
                FacilityTypeName = "TypeName",            
            };
            facilityType.FacilityList.Add(facilities);
            var facilityGroup = new HotelFacilityGroupViewModel()
            {
                FacilityGroupId = 1,
                FacilityGroupName = "Group1",
                IconPath = "",
            };
            facilityGroup.HotelFacilityTypes.Add(facilityType);
            var facilityModel = new HotelFacilityViewModel()
            {
                HotelId = 73,                
            };
            facilityModel.FacilityGroupList.Add(facilityGroup);
    
            mockFacilitiesRepository.Setup(x => x.InsertAndUpdateHotelFacilityRelation (It.IsAny<HotelFacilityViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1 }));


            //Act
            IActionResult result = await mockFacilitiesController.CreateHotelFacilityRelation(facilityModel);
            BaseResult<long> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<long>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
            Assert.IsTrue(finalResult.Result !=default(long));
            Assert.IsTrue(finalResult.Result == id);


        }
        #endregion  Positive test cases

        #endregion CreateHotelFacilityRelation
    }
}
