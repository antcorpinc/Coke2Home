using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    internal class FacilitiesRepositoryTest
    {
        private IFacilities facilitiesRepository;
        private Mock<IConnection<HotelFacilityGroup>> iHotelFacilityGroupLibrary;
        private Mock<IConnection<HotelFacilityType>> iHotelFacilityTypeLibrary;
        private Mock<IConnection<HotelFacility>> iHotelFacilityLibrary;
        private Mock<IConnection<HotelFacilityRelation>> iHotelFacilityRelationLibrary;
        private Mock<IConnection<InOutTime>> iInOutTimeLibrary;

        public FacilitiesRepositoryTest()
        {
            iHotelFacilityGroupLibrary = new Mock<IConnection<HotelFacilityGroup>>();
            iHotelFacilityTypeLibrary = new Mock<IConnection<HotelFacilityType>>();
            iHotelFacilityLibrary = new Mock<IConnection<HotelFacility>>();
            iHotelFacilityRelationLibrary = new Mock<IConnection<HotelFacilityRelation>>();
            iInOutTimeLibrary = new Mock<IConnection<InOutTime>>();
            facilitiesRepository = new FacilitiesRepository(iHotelFacilityGroupLibrary.Object, iHotelFacilityTypeLibrary.Object, iHotelFacilityLibrary.Object,
                                                           iHotelFacilityRelationLibrary.Object, iInOutTimeLibrary.Object);
        }


        [Test]
        public void TestGetHotelFacilityGroups_ListOfFacilityGroup()
        {
            //Arrange
            int id = 1;
            var hotelFacilityGroups = new HotelFacilityGroup() { Id = id, Name = "Group1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<HotelFacilityGroup>>() { Result = new List<HotelFacilityGroup>() { hotelFacilityGroups } };
            var pred = new Func<HotelFacilityGroup, bool>(x => x.IsActive && !x.IsDeleted);
            iHotelFacilityGroupLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<HotelFacilityGroup, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(new BaseResult<List<HotelFacilityGroup>> { }));
            //Act
            var facilityList = facilitiesRepository.GeHotelFacilityGroup();
            //Assert
            Assert.IsTrue(facilityList != null);
            Assert.IsTrue(facilityList.Result is BaseResult<List<HotelFacilityGroup>>);
            //Assert.IsTrue(facilityList.Result.Result.Exists(x=>x.Id==id));

        }
        [Test]
        public void TestGetHotelFacilityGroup_ListOfFacilityType()
        {
            //Arrange
            int id = 1;
            var hotelFacilityType = new HotelFacilityType() { Id = id, FacilityGroupId = 1, Name = "Type1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<HotelFacilityType>>() { Result = new List<HotelFacilityType>() { hotelFacilityType } };
            var pred = new Func<HotelFacilityType, bool>(x => x.IsActive && !x.IsDeleted);
            iHotelFacilityTypeLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<HotelFacilityType, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(new BaseResult<List<HotelFacilityType>> { }));
            //Act
            var facilityList = facilitiesRepository.GeHotelFacilityType();
            //Assert
            Assert.IsTrue(facilityList != null);
            Assert.IsTrue(facilityList.Result is BaseResult<List<HotelFacilityType>>);
           // Assert.IsTrue(facilityList.Result.Result.Exists(x => x.Id == id));
        }
        [Test]

   
        public void TestGetHotelFacilityGroup_ListOfFacility()
        {
            //Arrange
            int id = 1;
            var hotelFacility = new HotelFacility() { Id = id, FacilityGroupId = 1, Name = "facility1", IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<HotelFacility>>() { Result = new List<HotelFacility>() { hotelFacility } };
            var pred = new Func<HotelFacility, bool>(x => x.IsActive && !x.IsDeleted);
            iHotelFacilityLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<HotelFacility, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(new BaseResult<List<HotelFacility>> { }));
            //Act
            var facilityList = facilitiesRepository.GeHotelFacility();
            //Assert
            Assert.IsTrue(facilityList != null);
            Assert.IsTrue(facilityList.Result is BaseResult<List<HotelFacility>>);
            //Assert.IsTrue(facilityList.Result.Result.Exists(x => x.Id == id));
        }
        [Test]
        public void TestGetSelectedFacilities_ListOfHotelFacilities()
        {
            //Arrange
            int id = 1;
            var hotelFacility = new HotelFacilityRelation() { Id = id, HotelId=id,FacilityId=id,FacilityGroupId=id ,IsDeleted = false };
            var baseResult = new BaseResult<List<HotelFacilityRelation>>() { Result = new List<HotelFacilityRelation>() { hotelFacility } };
            var pred = new Func<HotelFacilityRelation, bool>(x => !x.IsDeleted &&  x.HotelId== id);
            iHotelFacilityRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<HotelFacilityRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            var facilityList = facilitiesRepository.GetSelectedFacilities(id);
            //Assert
            Assert.IsTrue(facilityList != null);
            Assert.IsTrue(facilityList.Result is BaseResult<List<HotelFacilityRelation>>);
            Assert.IsTrue(facilityList.Result.Result.Exists(x => x.Id == id));
        }


        [Test]
        public void TestCreateHotelFacilityRelation_Id()
        {
            //Arrange
            var hotelId = 73;
            var id = 1;
            HotelFacilityRelation hotelFacilityRelation = new HotelFacilityRelation
            {
                HotelId = hotelId,
                FacilityId =id,
                FacilityTypeId = id,
                FacilityGroupId = id,
                IsDeleted = false,
                IsProvisioned = true,
                CreatedBy = "MGIT",
                UpdatedBy = "MGIT",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
            var userName = "MGIT";
       
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
            iHotelFacilityRelationLibrary.Setup(a=>a.InsertEntity(It.IsAny<HotelFacilityRelation>())).Returns(Task.FromResult(new BaseResult<long>() { Result = id }));
            //Act
            var result = facilitiesRepository.InsertAndUpdateHotelFacilityRelation(facilityModel,userName);
            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result.Result == id);
            
           
        }


    }
}
