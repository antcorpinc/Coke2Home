using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    class AmenitiesRepositoryTest:BaseTestFixture
    {
        private IAmenities amenitiesRepository;
        private Mock<IConnection<RoomFacilityGroup>> iRoomFacilityGroupLibrary;
        private Mock<IConnection<RoomFacilityType>> iRoomFacilityTypeLibrary;
        private Mock<IConnection<RoomFacility>> iRoomFacilityLibrary;
        private Mock<IConnection<RoomFacilityRelation>> iRoomFacilityRelationLibrary;

        public AmenitiesRepositoryTest()
        {
            this.iRoomFacilityGroupLibrary = new Mock<IConnection<RoomFacilityGroup>>();
            this.iRoomFacilityTypeLibrary = new Mock<IConnection<RoomFacilityType>>();
            this.iRoomFacilityLibrary = new Mock<IConnection<RoomFacility>>();
            this.iRoomFacilityRelationLibrary = new Mock<IConnection<RoomFacilityRelation>>();
            this.amenitiesRepository = new AmenitiesRepository(iRoomFacilityGroupLibrary.Object, iRoomFacilityTypeLibrary.Object, iRoomFacilityRelationLibrary.Object, iRoomFacilityLibrary.Object);

        }


        [Test]
        public void TestInsertAndUpdateRoomFacilityRelation_SaveRoomFacilities_Success()
        {
            var id = 1;
            string userName = "MGIT";
            
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
                ObjectState = ObjectState.Added,
                FacilityGroupId = 1,
                IsSelected = true

            };
            FacilitiesRoomList facilityRoom = new FacilitiesRoomList()
            {
                RoomTypeId = 1,
                RoomName = "Room1",
                IsSelected = true,
                ObjectState = ObjectState.Added
            };
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            iRoomFacilityRelationLibrary.Setup(a => a.InsertEntityList(It.IsAny<List<RoomFacilityRelation>>())).Returns(Task.FromResult(new BaseResult<long>() { Result = id })).Verifiable();
            //Act
            var result = amenitiesRepository.InsertAndUpdateRoomFacilityRelation(roomFacilities, userName);
            //Assert
            iRoomFacilityTypeLibrary.Verify();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result.Result == id);
        }
        [Test]
        public void TestInsertAndUpdateRoomFacilityRelation_DeleteRoomFacilities_Success()
        {

            var id = 1;
            string userName = "MGIT";
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
                ObjectState = ObjectState.Deleted,
                FacilityGroupId = 1,
                IsSelected = true

            };
            FacilitiesRoomList facilityRoom = new FacilitiesRoomList()
            {
                RoomTypeId = 1,
                RoomName = "Room1",
                IsSelected = true,
                ObjectState = ObjectState.Unchanged
            };
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            iRoomFacilityRelationLibrary.Setup(a => a.UpdateEntityList(It.IsAny<List<RoomFacilityRelation>>())).Returns(Task.FromResult(new BaseResult<bool>() { Result =true })).Verifiable();
            var baseResult = new BaseResult<List<RoomFacilityRelation>>() { Result=new List<RoomFacilityRelation>() { new RoomFacilityRelation() { Id = 1, IsDeleted = false, FacilityId = 1 } } };
            var pred = new Func<RoomFacilityRelation, bool>(x => x.FacilityId == id && x.IsDeleted == false);
            iRoomFacilityRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomFacilityRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var result = amenitiesRepository.InsertAndUpdateRoomFacilityRelation(roomFacilities, userName);
            //Assert
            iRoomFacilityTypeLibrary.Verify();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result.Result == 1);
        }

        public void TestInsertAndUpdateRoomFacilityRelation_UnchangedRoomFacilities_Success()
        {

            var id = 1;
            string userName = "MGIT";
            //Arrange
            RoomFacilityGroupListViewModel roomFacilities = new RoomFacilityGroupListViewModel()
            {
                HotelId = 1,
                ObjectState = ObjectState.Added,
            };
            RoomFacilityGroupViewModel facilityGroup = new RoomFacilityGroupViewModel()
            {
                Id = 1,
                Name = "Group1",
            };
            RoomFacilityTypeViewModel facilityType = new RoomFacilityTypeViewModel()
            {
                FacilityGroupId = 1,
            };
            RoomFacilityViewModel facility = new RoomFacilityViewModel()
            {
                Id = 1,
                Name = "facility1",
                ObjectState = ObjectState.Deleted,
                FacilityGroupId = 1,
                IsSelected = true

            };
            FacilitiesRoomList facilityRoom = new FacilitiesRoomList()
            {
                RoomTypeId = 1,
                RoomName = "Room1",
                IsSelected = true,
                ObjectState = ObjectState.Unchanged
            };
            facility.FacilitiesRoomList.Add(facilityRoom);
            facilityType.FacilityList.Add(facility);
            facilityGroup.RoomFacilityTypes.Add(facilityType);
            roomFacilities.FacilityGroupList.Add(facilityGroup);
            iRoomFacilityRelationLibrary.Setup(a => a.UpdateEntityList(It.IsAny<List<RoomFacilityRelation>>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();
            var baseResult = new BaseResult<List<RoomFacilityRelation>>() { Result = new List<RoomFacilityRelation>() { new RoomFacilityRelation() { Id = 1, IsDeleted = false, FacilityId = 1 } } };
            var pred = new Func<RoomFacilityRelation, bool>(x => x.FacilityId == id && x.IsDeleted == false);
            iRoomFacilityRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomFacilityRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var result = amenitiesRepository.InsertAndUpdateRoomFacilityRelation(roomFacilities, userName);
            //Assert
            iRoomFacilityTypeLibrary.Verify();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result.Result == 1);
        }


        #region IsAmenitiesExits

        #region Negative Test Cases

        [Test]

        public async Task TestIsAmenitiesExits_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            var baseResult = new BaseResult<List<RoomFacilityRelation>>() {IsError=true,ExceptionMessage=Helper.Common.GetMockException() };
            var pred = new Func<RoomFacilityRelation, bool>(x => x.FacilityId == id && x.IsDeleted == false && x.HotelId==id);
            iRoomFacilityRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomFacilityRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var result = await amenitiesRepository.IsAmenitiesExits(id);
            //Assert
            iRoomFacilityTypeLibrary.Verify();
            Assert.IsTrue(result.IsError);
            Assert.IsTrue(result.ExceptionMessage != null);
        }
        #endregion
        [Test]
        public async Task TestIsAmenitiesExits_Success_ReturnsTrue()
        {
            //Arrange
            int id = 1;
            
            var baseResult = new BaseResult<List<RoomFacilityRelation>>() { Result = new List<RoomFacilityRelation>() { new RoomFacilityRelation() { Id = 1, IsDeleted = false, FacilityId = 1 } } };
            var pred = new Func<RoomFacilityRelation, bool>(x => x.FacilityId == id && x.IsDeleted == false && x.HotelId == id);
            iRoomFacilityRelationLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<RoomFacilityRelation, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var result = await amenitiesRepository.IsAmenitiesExits(id);
            //Assert
            iRoomFacilityTypeLibrary.Verify();
            Assert.IsTrue(result.Result==true);

        }
     
        #endregion
    }
}
