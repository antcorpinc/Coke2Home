using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    internal class HotelRepositoryTest
    {
        #region private variables
        private IHotels hotelRepository;
        private Mock<IConnection<Hotel>> iHotelLibrary;
        private Mock<IConnection<Contacts>> iContactsLibrary;
        private Mock<IConnection<EmailReservation>> iEmailReservationLibrary;
        private Mock<IConnection<TelephoneReservation>> iTelephoneReservationLibrary;
        private Mock<IConnection<HotelPaymentMethodRelation>> iHotelPaymentMethodRelationLibrary;
        private Mock<IConnection<HotelTaxRelation>> iHotelTaxRelationLibrary;
        private Mock<IConnection<ProfileCompletenessAggregateModel>> iProfileCompletenessAggregateModelLibrary;
        private Mock<IConnection<HotelView>> iHotelViewLibrary;
        #endregion

        #region settings
        public HotelRepositoryTest()
        {
            this.iHotelLibrary = new Mock<IConnection<Hotel>>();
            this.iContactsLibrary = new Mock<IConnection<Contacts>>();
            this.iEmailReservationLibrary = new Mock<IConnection<EmailReservation>>();
            this.iTelephoneReservationLibrary = new Mock<IConnection<TelephoneReservation>>();
            this.iHotelPaymentMethodRelationLibrary = new Mock<IConnection<HotelPaymentMethodRelation>>();
            this.iHotelTaxRelationLibrary = new Mock<IConnection<HotelTaxRelation>>();
            this.iProfileCompletenessAggregateModelLibrary = new Mock<IConnection<ProfileCompletenessAggregateModel>>();
            this.iHotelViewLibrary = new Mock<IConnection<HotelView>>();
            this.hotelRepository = new HotelRepository(iHotelLibrary.Object, iContactsLibrary.Object, iEmailReservationLibrary.Object, iTelephoneReservationLibrary.Object,
                                                       iHotelPaymentMethodRelationLibrary.Object, iHotelTaxRelationLibrary.Object, iProfileCompletenessAggregateModelLibrary.Object, iHotelViewLibrary.Object);
        }
        #endregion

        [Test]
        public void TestDeleteHotelByHotelId_Success_True()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
              var hotel = new Hotel() { Id = id, IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Hotel>>() { Result = new List<Hotel>() { hotel } };
            var pred = new Func<Hotel, bool>(x => x.Id == id && x.IsDeleted == false);
            iHotelLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Hotel, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iHotelLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Hotel>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true }));
            //Act
            var result = hotelRepository.DeleteHotelByHotelId(id, userName);
            //Assert        
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.Result == true);
        }
        [Test]
        public void TestDeleteHotelByHotelId_Failed_False()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var hotel = new Hotel() { Id = id, IsActive = true, IsDeleted = false};
            var baseResult = new BaseResult<List<Hotel>>() { Result = new List<Hotel>() { hotel } };
            var pred = new Func<Hotel, bool>(x => x.Id == id && x.IsDeleted == false);
            iHotelLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Hotel, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iHotelLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Hotel>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false }));
            //Act
            var result = hotelRepository.DeleteHotelByHotelId(id, userName);
            //Assert        
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.Result == false);
        }
        [Test]
        public void TestDeleteHotelByHotelId_Failed_Error()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var hotel = new Hotel() { Id = id, IsActive = true, IsDeleted = false };
            var baseResult = new BaseResult<List<Hotel>>() { Result = new List<Hotel>() { hotel } };
            var pred = new Func<Hotel, bool>(x => x.Id == id && x.IsDeleted == false);
            iHotelLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Hotel, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult));
            iHotelLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Hotel>())).Returns(Task.FromResult(new BaseResult<bool> {IsError=true,ExceptionMessage=Helper.Common.GetMockException() }));
            //Act
            var result = hotelRepository.DeleteHotelByHotelId(id, userName);
            //Assert        
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.IsError == true);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }
    }
}
