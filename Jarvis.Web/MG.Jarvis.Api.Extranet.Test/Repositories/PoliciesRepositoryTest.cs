using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ER = MG.Jarvis.Api.Extranet.Repositories;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class PoliciesRepositoryTest:BaseTestFixture
    {
        #region private variables
        private IPolicies policiesRepository;

        private Mock<IConnection<ChildrenAndExtraBedPolicies>> iChildrenAndExtraBedPoliciesConnectionLibrary;
        private Mock<IConnection<MaxChildAndExtraBedPerRoom>> iMaxChildAndExtraBedPerRoomConnectionLibrary;
        private Mock<IConnection<CancellationCharges>> iCancellationChargesConnectionLibrary;
        private Mock<IConnection<CancellationPolicy>> iCancellationPolicyConnectionLibrary;
        private Mock<IConnection<CancellationPolicyClauses>> iCancellationPolicyClausesConnectionLibrary;
        private Mock<IConnection<CancellationPolicyType>> iCancellationPolicyTypeConnectionLibrary;
        private Mock<IConnection<Room>> iRoomConnectionLibrary;
        #endregion private variables

        #region settings
        public PoliciesRepositoryTest()
        {
            

            iChildrenAndExtraBedPoliciesConnectionLibrary = new Mock<IConnection<ChildrenAndExtraBedPolicies>>();
            iMaxChildAndExtraBedPerRoomConnectionLibrary = new Mock<IConnection<MaxChildAndExtraBedPerRoom>>();
            iCancellationChargesConnectionLibrary = new Mock<IConnection<CancellationCharges>>();
            iCancellationPolicyConnectionLibrary = new Mock<IConnection<CancellationPolicy>>();
            iCancellationPolicyClausesConnectionLibrary = new Mock<IConnection<CancellationPolicyClauses>>();
            iCancellationPolicyTypeConnectionLibrary = new Mock<IConnection<CancellationPolicyType>>();
            iRoomConnectionLibrary = new Mock<IConnection<Room>>();
            policiesRepository = new ER.PoliciesRepository(iChildrenAndExtraBedPoliciesConnectionLibrary.Object, iMaxChildAndExtraBedPerRoomConnectionLibrary.Object,
                iCancellationChargesConnectionLibrary.Object, iCancellationPolicyConnectionLibrary.Object, iCancellationPolicyClausesConnectionLibrary.Object, iCancellationPolicyTypeConnectionLibrary.Object, iRoomConnectionLibrary.Object);

        }
        #endregion settings

        #region Child And Extra Bed Policy
        [Test]
        public async Task TestGetChildrenAndExtraBedPolicyListingByHotelId_positive_Predicate_sample()
        {
            //Arrange
            int hotelId = 5;
            var childrenAndExtraBedPolicy = new ChildrenAndExtraBedPolicies();

            var baseResult = new BaseResult<List<ChildrenAndExtraBedPolicies>>() { Result = new List<ChildrenAndExtraBedPolicies>() { childrenAndExtraBedPolicy } };
            var pred = new Func<ChildrenAndExtraBedPolicies, bool>(x => x.HotelId == hotelId && x.IsActive && !x.IsDeleted);

            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<ChildrenAndExtraBedPolicies, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<ChildrenAndExtraBedPolicies>>> result = policiesRepository.GetChildrenAndExtraBedPolicyListingByHotelId(hotelId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<ChildrenAndExtraBedPolicies>>);
        }

        [Test]
        public async Task TestGetMaxChildAndExtraBedPerRoom_positive_Predicate_sample()
        {
            //Arrange
            int hotelId = 5;
            MaxChildAndExtraBedPerRoom maxChildAndExtraBedPerRoomModel = new MaxChildAndExtraBedPerRoom();

            var baseResult = new BaseResult<List<MaxChildAndExtraBedPerRoom>>() { Result = new List<MaxChildAndExtraBedPerRoom>() { maxChildAndExtraBedPerRoomModel } };

            iMaxChildAndExtraBedPerRoomConnectionLibrary.Setup(x => x.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<MaxChildAndExtraBedPerRoom>>> result = policiesRepository.GetMaxChildAndExtraBedPerRoom(hotelId);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<MaxChildAndExtraBedPerRoom>>);
        }

        [Test]
        public async Task TestGetRoomsById_positive_Predicate_sample()
        {
            //Arrange
            List<MaxChildAndExtraBedPerRoomViewModel> maxChildAndExtraBedPerRoomViewModelList = new List<MaxChildAndExtraBedPerRoomViewModel>();

            Room room = new Room();
            var baseResult = new BaseResult<List<Room>>() { Result = new List<Room>() { room } };
            var pred = new Func<Room, bool>(x => x.Id == 332 && x.IsActive && !x.IsDeleted);

            iRoomConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<Room, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            //Act
            Task<BaseResult<List<Room>>> result = policiesRepository.GetRoomsById(maxChildAndExtraBedPerRoomViewModelList);
            //Assert
            Assert.IsTrue(result.Result != null);
            Assert.IsTrue(result.Result is BaseResult<List<Room>>);
        }

        [Test]
        public async Task TestSaveAndUpdateChildAndExtraBedPolicy_Save_Failed_Error()
        {
            //Arrange
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies();
            ObjectState objectState = ObjectState.Added;
            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.InsertEntity(It.IsAny<ChildrenAndExtraBedPolicies>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();

            //Act
            Task<BaseResult<ChildrenAndExtraBedPolicies>> actionResult = policiesRepository.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesModel, objectState);

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestSaveAndUpdateChildAndExtraBedPolicy_Update_Failed_Error()
        {
            //Arrange
            ObjectState objectState = ObjectState.Modified;
            var childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies()
            {
                Id = 1,
                IsActive = true,
                IsChildrenAllowed = true,
                IsExtraCotAllowed = true,
                IsExtraBedAllowed = true,
                CotPrice = 1000,
                CotPriceTypeId = 2,
                HotelId = 5,
                MinChildAge = 0,
                MaxChildAge = 5,
                MinInfantAge = 2,
                MaxInfantAge = 5,
                IsDeleted = false
            };
            var childrenAndExtraBedPoliciesModelList = new List<ChildrenAndExtraBedPolicies>();
            childrenAndExtraBedPoliciesModelList.Add(childrenAndExtraBedPoliciesModel);
            var baseResult = new BaseResult<List<ChildrenAndExtraBedPolicies>>() { Result = childrenAndExtraBedPoliciesModelList };
            var pred = new Func<ChildrenAndExtraBedPolicies, bool>(x => x.HotelId == 5 && x.IsActive);

            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<ChildrenAndExtraBedPolicies, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));

            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<ChildrenAndExtraBedPolicies>())).Returns(Task.FromResult(new BaseResult<bool>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();


            //Act
            Task<BaseResult<ChildrenAndExtraBedPolicies>> actionResult = policiesRepository.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesModel, objectState);

            //Assert
            Assert.IsTrue(actionResult.Result.IsError);
            Assert.IsTrue(actionResult.Result.ExceptionMessage != null);
        }

        //[Test]
        //public async Task TestSaveAndUpdateChildAndExtraBedPolicy_Save_Failed_NullResult()
        //{
        //    //Arrange
        //    ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies();
        //    ObjectState objectState = ObjectState.Added;
        //    BaseResult<long> baseResult = null;
        //    iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.InsertEntity(It.IsAny<ChildrenAndExtraBedPolicies>())).Returns(Task.FromResult(baseResult));

        //    //Act
        //    Task<BaseResult<ChildrenAndExtraBedPolicies>> actionResult = policiesRepository.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesModel, objectState);

        //    //Assert
        //    Assert.IsTrue(actionResult.Result == null);
        //}

        //[Test]
        //public async Task TestSaveAndUpdateChildAndExtraBedPolicy_Update_Failed_NullResult()
        //{
        //    //Arrange
        //    ObjectState objectState = ObjectState.Modified;
        //    BaseResult<bool> updateEntityBaseResult = null;
        //    var childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies()
        //    {
        //        Id = 1,
        //        IsActive = true,
        //        IsChildrenAllowed = true,
        //        IsExtraCotAllowed = true,
        //        IsExtraBedAllowed = true,
        //        CotPrice = 1000,
        //        CotPriceTypeId = 2,
        //        HotelId = 5,
        //        MinChildAge = 0,
        //        MaxChildAge = 5,
        //        MinInfantAge = 2,
        //        MaxInfantAge = 5,
        //        IsDeleted = false
        //    };
        //    var childrenAndExtraBedPoliciesModelList = new List<ChildrenAndExtraBedPolicies>();
        //    childrenAndExtraBedPoliciesModelList.Add(childrenAndExtraBedPoliciesModel);
        //    var baseResult = new BaseResult<List<ChildrenAndExtraBedPolicies>>() { Result = childrenAndExtraBedPoliciesModelList };
        //    var pred = new Func<ChildrenAndExtraBedPolicies, bool>(x => x.HotelId == 5 && x.IsActive);
            
        //    iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<ChildrenAndExtraBedPolicies, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
        //    iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<ChildrenAndExtraBedPolicies>())).Returns(Task.FromResult(updateEntityBaseResult));

        //    //Act
        //    Task<BaseResult<ChildrenAndExtraBedPolicies>> actionResult = policiesRepository.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesModel, objectState);

        //    //Assert
        //    Assert.IsTrue(actionResult.Result == null);
        //}

        #region Positive Test Cases
        [Test]
        public async Task TestSaveAndUpdateChildAndExtraBedPolicy_Save_Passed_Success()
        {
            //Arrange
            ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies();
            ObjectState objectState = ObjectState.Added;
            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.InsertEntity(It.IsAny<ChildrenAndExtraBedPolicies>())).Returns(Task.FromResult(new BaseResult<long>() { Result=3}));

            //Act
            Task<BaseResult<ChildrenAndExtraBedPolicies>> actionResult = policiesRepository.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesModel, objectState);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.IsTrue(actionResult.Result != null);
            Assert.IsTrue(!actionResult.Result.IsError);
        }
        [Test]
        public async Task TestSaveAndUpdateChildAndExtraBedPolicy_Update_Passed_Success()
        {
            //Arrange
            var childrenAndExtraBedPoliciesModel = new ChildrenAndExtraBedPolicies()
            {
                Id=1,
                IsActive=true,
                IsChildrenAllowed=true,
                IsExtraCotAllowed=true,
                IsExtraBedAllowed=true,
                CotPrice=1000,
                CotPriceTypeId=2,
                HotelId=5,
                MinChildAge=0,
                MaxChildAge=5,
                MinInfantAge=2,
                MaxInfantAge=5,
                IsDeleted=false
            };
            var childrenAndExtraBedPoliciesModelList = new List<ChildrenAndExtraBedPolicies>();
            childrenAndExtraBedPoliciesModelList.Add(childrenAndExtraBedPoliciesModel);
            ObjectState objectState = ObjectState.Modified;
            var baseResult = new BaseResult<List<ChildrenAndExtraBedPolicies>>() { Result = childrenAndExtraBedPoliciesModelList };
            var pred = new Func<ChildrenAndExtraBedPolicies, bool>(x => x.HotelId == 5 && x.IsActive );

            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.GetListByPredicate(It.Is<Func<ChildrenAndExtraBedPolicies, bool>>(y => y.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));

            iChildrenAndExtraBedPoliciesConnectionLibrary.Setup(x => x.UpdateEntityByDapper(It.IsAny<ChildrenAndExtraBedPolicies>())).Returns(Task.FromResult(new BaseResult<bool>() { Result=true }));

            //Act
            Task<BaseResult<ChildrenAndExtraBedPolicies>> actionResult = policiesRepository.SaveAndUpdateChildAndExtraBedPolicy(childrenAndExtraBedPoliciesModel, objectState);

            //Assert
            Assert.IsTrue(actionResult != null);
            Assert.IsTrue(actionResult.Result != null);
            Assert.IsTrue(!actionResult.Result.IsError);
        }
        #endregion Positive Test Cases
        #endregion Child And Extra Bed Policy
    }
}
