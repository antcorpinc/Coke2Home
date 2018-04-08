using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Response;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.ChannelManager;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChannelManagerRequestModel = MG.Jarvis.Api.BackOffice.Models.Request.ChannelManager;
using ChannelManagerResponseModel = MG.Jarvis.Api.BackOffice.Models.Response.ChannelManager;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture,Category("BackOffice")]
    public class ChannelManagerControllerTest
    {
        #region Private Variables
        private ChannelManagerController channelManagerControllerMock;
        private Mock<IChannelManager> _iChannelManagerRepositoryMock;
        private Mock<IConnection<Bank>> _bankMock;
        private Mock<IConnection<Contacts>> _contactsMock;
        private Mock<IConnection<Payment>> _paymentMock;
        private Mock<IConnection<Core.Model.ChannelManager.ChannelManager>> _channelManagerMock;
        private Mock<IConnection<FunctionChannelManagerRelation>> _functionChannelManagerRelationMock;
        private Mock<IConnection<Functions>> _functionsMock;
        private Mock<IConnection<UserRelation>> _userRelationMock;
        private Mock<IConnection<EmailAddresses>> _emailAddressesMock;
        private Mock<ILogger> _iLoggerMock;
        private Mock<IMasterData<ChannelManagerRequestModel, int>> _iMasterDataMock;
        #endregion Private Variables

        public ChannelManagerControllerTest()
        {
            _iChannelManagerRepositoryMock = new Mock<IChannelManager>();
            _bankMock = new Mock<IConnection<Bank>>();
            _contactsMock = new Mock<IConnection<Contacts>>();
            _paymentMock = new Mock<IConnection<Payment>>();
            _channelManagerMock = new Mock<IConnection<Core.Model.ChannelManager.ChannelManager>>();
            _functionChannelManagerRelationMock = new Mock<IConnection<FunctionChannelManagerRelation>>();
            _functionsMock = new Mock<IConnection<Functions>>();
            _userRelationMock = new Mock<IConnection<UserRelation>>();
            _emailAddressesMock = new Mock<IConnection<EmailAddresses>>();
            _iLoggerMock = new Mock<ILogger>();
            _iMasterDataMock = new Mock<IMasterData<ChannelManagerRequestModel, int>>();

            channelManagerControllerMock = new ChannelManagerController(_iMasterDataMock.Object,
                                                                        _iLoggerMock.Object,
                                                                        _bankMock.Object,
                                                                        _contactsMock.Object,
                                                                        _paymentMock.Object,
                                                                        _emailAddressesMock.Object,
                                                                        _channelManagerMock.Object,
                                                                        _functionChannelManagerRelationMock.Object,
                                                                        _functionsMock.Object,
                                                                        _userRelationMock.Object,
                                                                        _iChannelManagerRepositoryMock.Object);
        }

        [Test]
        public void TestChannelManagerGetAllNullObjectReturnsNoContentFail()
        {
            _iChannelManagerRepositoryMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<List<ChannelManagerResponseModel>>()));

            var result = channelManagerControllerMock.Get().Result;

            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestChannelManagerGetAllReturnsAnErrorOrExceptionFail()
        {
            _iChannelManagerRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<ChannelManagerResponseModel>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = channelManagerControllerMock.Get().Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestChannelManagerGetAllReturnOkSuccess()
        {
            List<ChannelManagerResponseModel> fakeChannelManagerResponseList = new List<ChannelManagerResponseModel>();
            fakeChannelManagerResponseList = this.GetFakeListOfChannelManagerResponseModel();

            _iChannelManagerRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<ChannelManagerResponseModel>> { Result = fakeChannelManagerResponseList, IsError = false }));

            var result = channelManagerControllerMock.Get().Result;
            BaseResult<List<ChannelManagerResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<ChannelManagerResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestChannelManagerGetAllThrowsException()
        {
            _iChannelManagerRepositoryMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = channelManagerControllerMock.Get().Result;
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }


        [Test]
        public void TestChannelManagerGetByIdNullObjectReturnsNoContentFail()
        {
            _iChannelManagerRepositoryMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<List<ChannelManagerResponseModel>>()));

            var result = channelManagerControllerMock.GetById(0).Result;

            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestChannelManagerGetByIdReturnsAnErrorOrExceptionFail()
        {
            _iChannelManagerRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<ChannelManagerResponseModel>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = channelManagerControllerMock.GetById(6).Result;

            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }

        [Test]
        public void TestChannelManagerGetByIdReturnOkSuccess()
        {
            List<ChannelManagerResponseModel> fakeChannelManagerResponseList = new List<ChannelManagerResponseModel>();
            fakeChannelManagerResponseList = this.GetFakeListOfChannelManagerResponseModel();

            _iChannelManagerRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<ChannelManagerResponseModel>> { Result = fakeChannelManagerResponseList, IsError = false }));

            var result = channelManagerControllerMock.GetById(1).Result;
            BaseResult<List<ChannelManagerResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<ChannelManagerResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestChannelManagerGetByIdThrowsException()
        {
            _iChannelManagerRepositoryMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = channelManagerControllerMock.GetById(6).Result;
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }
        private List<ChannelManagerResponseModel> GetFakeListOfChannelManagerResponseModel()
        {
            List<ChannelManagerResponseModel> fakeChannelManagerResponseList = new List<ChannelManagerResponseModel>();

            fakeChannelManagerResponseList = new List<ChannelManagerResponseModel>();
            {
                fakeChannelManagerResponseList.Add(new ChannelManagerResponseModel
                {
                    MGChannelManager = new Core.Model.ChannelManager.ChannelManager
                    {
                        Id =1,
                        BranchName = "Test",
                        AddressLine1 = "Add1",
                        CityId =1,
                        Code = "test",
                        Name = "CM1"
                    },
                    ChannelManagerContacts = new List<Contacts>
                    {
                        new Contacts
                        {
                            Id =1,ChannelManagerId=1,ContactPerson="Test Person",EmailAddress="abc@abc.com",
                            PhoneNumber="34234234"
                        }
                    },
                    ChannelManagerBanks = new List<Bank>
                    {
                        new Bank
                        {
                            Id =1,ChannelManagerId =1,Account="abc",AccountNumber = "232342432",
                            Branch = "Test",AccountTypeId =1
                        }
                    },
                    ChannelManagerPayment = new Payment
                    {
                        Id=1,ChannelManagerId=1,CreditDays=2,CurrencyId=1,PaymentTypeId=1,WithHoldingTaxId=1,
                        WithHoldingTaxRate="23"
                    },
                    ChannelManagerEmailAddresses = new List<EmailAddresses>
                    {
                        new EmailAddresses
                        {
                            Id=1,ChannelManagerId=1,EmailAddress="abc@abc.com",ReceipentsType="RT1",SendersTypeId=1
                        }
                    },
                    ChannelManagerCredentials = new List<UserRelation>
                    {
                        new UserRelation
                        {
                            ChannelManagerId=1,EnvironmentId=1,UserInfo="info"
                        }
                    },
                    FunctionEndpoints = new List<FunctionChannelManagerRelationModel>
                    {
                        new FunctionChannelManagerRelationModel
                        {
                            FunctionId=1,EnvironmentId=1,ChannelManagerId=1,CurrencyId=1,EndpointURL="https://abc.com",
                            FunctionName="test"
                        }
                    }
                });
            }
            return fakeChannelManagerResponseList;
        }

        private ChannelManagerResponseModel GetFakeChannelManagerResponseModel()
        {
            ChannelManagerResponseModel fakeChannelManagerResponseModel = new ChannelManagerResponseModel()
            {
                MGChannelManager = new Core.Model.ChannelManager.ChannelManager
                {
                    Id = 1,
                    BranchName = "Test",
                    AddressLine1 = "Add1",
                    CityId = 1,
                    Code = "test",
                    Name = "CM1"
                },
                ChannelManagerContacts = new List<Contacts>
                    {
                        new Contacts
                        {
                            Id =1,ChannelManagerId=1,ContactPerson="Test Person",EmailAddress="abc@abc.com",
                            PhoneNumber="34234234"
                        }
                    },
                ChannelManagerBanks = new List<Bank>
                    {
                        new Bank
                        {
                            Id =1,ChannelManagerId =1,Account="abc",AccountNumber = "232342432",
                            Branch = "Test",AccountTypeId =1
                        }
                    },
                ChannelManagerPayment = new Payment
                {
                    Id = 1,
                    ChannelManagerId = 1,
                    CreditDays = 2,
                    CurrencyId = 1,
                    PaymentTypeId = 1,
                    WithHoldingTaxId = 1,
                    WithHoldingTaxRate = "23"
                },
                ChannelManagerEmailAddresses = new List<EmailAddresses>
                    {
                        new EmailAddresses
                        {
                            Id=1,ChannelManagerId=1,EmailAddress="abc@abc.com",ReceipentsType="RT1",SendersTypeId=1
                        }
                    },
                ChannelManagerCredentials = new List<UserRelation>
                    {
                        new UserRelation
                        {
                            ChannelManagerId=1,EnvironmentId=1,UserInfo="info"
                        }
                    },
                FunctionEndpoints = new List<FunctionChannelManagerRelationModel>
                    {
                        new FunctionChannelManagerRelationModel
                        {
                            FunctionId=1,EnvironmentId=1,ChannelManagerId=1,CurrencyId=1,EndpointURL="https://abc.com",
                            FunctionName="test"
                        }
                    }
            };
            return fakeChannelManagerResponseModel;
        }
     }
}
