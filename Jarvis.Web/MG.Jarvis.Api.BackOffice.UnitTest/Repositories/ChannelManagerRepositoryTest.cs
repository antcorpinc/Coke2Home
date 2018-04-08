using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.ChannelManager;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Repositories
{
    [TestFixture]
    public class ChannelManagerRepositoryTest
    {
        private ChannelManagerRepository channelManagerRepositoryMock;
        private Mock<IConnection<Bank>> _bankMock;
        private Mock<IConnection<Contacts>> _contactsMock;
        private Mock<IConnection<Payment>> _paymentMock;
        private Mock<IConnection<ChannelManager>> _channelManagerMock;
        private Mock<IConnection<FunctionChannelManagerRelation>> _functionChannelManagerRelationMock;
        private Mock<IConnection<Functions>> _functionsMock;
        private Mock<IConnection<UserRelation>> _userRelationMock;
        private Mock<IConnection<EmailAddresses>> _emailAddressesMock;

        public ChannelManagerRepositoryTest()
        {
            _bankMock = new Mock<IConnection<Bank>>();
            _contactsMock = new Mock<IConnection<Contacts>>();
            _paymentMock = new Mock<IConnection<Payment>>();
            _channelManagerMock = new Mock<IConnection<ChannelManager>>();
            _functionChannelManagerRelationMock = new Mock<IConnection<FunctionChannelManagerRelation>>();
            _functionsMock = new Mock<IConnection<Functions>>();
            _userRelationMock = new Mock<IConnection<UserRelation>>();
            _emailAddressesMock = new Mock<IConnection<EmailAddresses>>();


            channelManagerRepositoryMock = new ChannelManagerRepository(_bankMock.Object, _contactsMock.Object, _paymentMock.Object, _emailAddressesMock.Object, _channelManagerMock.Object,
                                                                        _functionChannelManagerRelationMock.Object, _functionsMock.Object, _userRelationMock.Object);            
        }

        [Test]
        public void TestChannelManagerRepositoryGetSuccess()
        {
            this.Mocking(true);
            var result = channelManagerRepositoryMock.Get().Result;
            Assert.IsTrue(result.Result.Count > 0);
        }

        [Test]
        public void TestChannelManagerRepositoryGetEmptyChannelManagerListFail()
        {
            this.Mocking(false);
            var result = channelManagerRepositoryMock.Get().Result;
            Assert.IsNull(result.Result);
        }

        [Test]
        public void TestChannelManagerRepositoryGetEmptyFunctionChannelManagerRelationListFail()
        {
            this.Mocking(false);
            var result = channelManagerRepositoryMock.Get().Result;
            Assert.IsNull(result.Result);
        }
        
        private void Mocking(bool isSuccess)
        {
            Models.Response.ChannelManager mgChannelManager = MockResponseModel();
            var bank = new Bank()
            {
                Name = "Test Bank",
                IsActive = true,
                IsDeleted = false,
                Id = 1,
                ChannelManagerId = 1
            };
            var contact = new Contacts()
            {
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                ChannelManagerId = 1,
                ContactPerson = "Test Person"
            };
            var payment = new Payment()
            {
                ChannelManagerId = 1,
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                CurrencyId = 1,
                CreditDays = 20,
                PaymentTypeId = 1
            };
            var userRelation = new UserRelation()
            {
                ChannelManagerId = 1,
                EnvironmentId = 1,
                IsDeleted = false,
                UserInfo = "none"
            };
            var email = new EmailAddresses()
            {
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                ChannelManagerId = 1,
                SendersTypeId = 1,
                ReceipentsType = "Test"
            };
            var channelManagerPayment = new Payment()
            {
                ChannelManagerId = 1,
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                CurrencyId = 1,
                CreditDays = 20,
                PaymentTypeId = 1
            };
            var function = new Functions()
            {
                Id = 1,
                IsDeleted = false,
            };
            var endpoint = new FunctionChannelManagerRelation()
            {
                CurrencyId = 1,
                ChannelManagerId = 1,
                EndpointURL = "test.com",
                EnvironmentId = 1,
                FunctionId = 1,                
                IsDeleted = false,
                IsInScheduledOutage = false
            };
            var channelManager = new ChannelManager()
            {
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                BranchName = "Test",
                CityId = 1,
                Code = "TEST",
                CountryId = 1,
                NoOfRetries = 2,
                Name = "SM"
            };

            Func<ChannelManager, bool> func = s => s.IsActive && !s.IsDeleted;
            if(isSuccess)
                _channelManagerMock.Setup(x => x.GetListByPredicate(It.Is<Func<ChannelManager, bool>>(a => a.GetType() == func.GetType()))).Returns(Task.FromResult(new BaseResult<List<ChannelManager>> { Result = new List<ChannelManager>() { channelManager }, IsError = false }));
            else
                _channelManagerMock.Setup(x => x.GetListByPredicate(It.Is<Func<ChannelManager, bool>>(a => a.GetType() == func.GetType()))).Returns(Task.FromResult(new BaseResult<List<ChannelManager>> { Result = new List<ChannelManager>(), IsError = false }));
                
            Func<Bank, bool> bnkPred = b => b.IsActive && !b.IsDeleted && b.ChannelManagerId == channelManager.Id;
            _bankMock.Setup(x => x.GetListByPredicate(It.Is<Func<Bank, bool>>(a => a.GetType() == bnkPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Bank>> { Result = new List<Bank>() { bank }, IsError = false }));

            Func<Contacts, bool> contPred = b => b.IsActive && !b.IsDeleted && b.ChannelManagerId == channelManager.Id;
            _contactsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Contacts, bool>>(a => a.GetType() == contPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Contacts>> { Result = new List<Contacts>() { contact }, IsError = false }));

            Func<Payment, bool> paymentPred = b => b.IsActive && !b.IsDeleted && b.ChannelManagerId == channelManager.Id;
            _paymentMock.Setup(x => x.GetListByPredicate(It.Is<Func<Payment, bool>>(a => a.GetType() == paymentPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Payment>> { Result = new List<Payment>() { payment }, IsError = false }));

            Func<UserRelation, bool> userRelationPred = b => !b.IsDeleted && b.ChannelManagerId == channelManager.Id;
            _userRelationMock.Setup(x => x.GetListByPredicate(It.Is<Func<UserRelation, bool>>(a => a.GetType() == userRelationPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<UserRelation>> { Result = new List<UserRelation>() { userRelation }, IsError = false }));

            Func<EmailAddresses, bool> emailPred = b => !b.IsDeleted && b.ChannelManagerId == channelManager.Id;
            _emailAddressesMock.Setup(x => x.GetListByPredicate(It.Is<Func<EmailAddresses, bool>>(a => a.GetType() == emailPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<EmailAddresses>> { Result = new List<EmailAddresses>() { email }, IsError = false }));

            Func<Functions, bool> funPred = f => !f.IsDeleted;
            _functionsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Functions, bool>>(a => a.GetType() == funPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Functions>> { Result = new List<Functions>() { function }, IsError = false }));
            
            Func<FunctionChannelManagerRelation, bool> funcendPred = f => !f.IsDeleted && f.ChannelManagerId == channelManager.Id;
            if(isSuccess)
                _functionChannelManagerRelationMock.Setup(x => x.GetListByPredicate(It.Is<Func<FunctionChannelManagerRelation, bool>>(a => a.GetType() == funcendPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<FunctionChannelManagerRelation>> { Result = new List<FunctionChannelManagerRelation>() { endpoint }, IsError = false }));
            else
                _functionChannelManagerRelationMock.Setup(x => x.GetListByPredicate(It.Is<Func<FunctionChannelManagerRelation, bool>>(a => a.GetType() == funcendPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<FunctionChannelManagerRelation>> { Result = new List<FunctionChannelManagerRelation>(), IsError = false }));
        }

        private Models.Response.ChannelManager MockResponseModel()
        {
           return new Models.Response.ChannelManager()
            {
                ChannelManagerBanks = new List<Bank>()
                {
                    new Bank()
                    {
                        Name = "Test Bank",
                        IsActive = true,
                        IsDeleted = false,
                        Id = 1,
                        ChannelManagerId = 1
                    }
                },

                ChannelManagerContacts = new List<Contacts>()
                {
                    new Contacts()
                    {
                        Id = 1,
                        IsActive = true,
                        IsDeleted = false,
                        ChannelManagerId = 1,
                        ContactPerson = "Test Person"
                    }
                },

                ChannelManagerCredentials = new List<UserRelation>()
                {
                    new UserRelation()
                    {
                        ChannelManagerId = 1,
                        EnvironmentId = 1,
                        IsDeleted = false,
                        UserInfo = "none"
                    }
                },

                ChannelManagerEmailAddresses = new List<EmailAddresses>()
                {
                    new EmailAddresses()
                    {
                        Id = 1,
                        IsActive = true,
                        IsDeleted = false,
                        ChannelManagerId = 1,
                        SendersTypeId = 1,
                        ReceipentsType = "Test"
                    }
                },

                ChannelManagerPayment = new Payment()
                {
                    ChannelManagerId = 1,
                    Id = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CurrencyId = 1,
                    CreditDays = 20,
                    PaymentTypeId = 1
                },

                FunctionEndpoints = new List<Models.Response.FunctionChannelManagerRelationModel>()
                {
                    new Models.Response.FunctionChannelManagerRelationModel()
                    {
                        CurrencyId =1,
                        ChannelManagerId = 1,
                        EndpointURL = "test.com",
                        EnvironmentId = 1,
                        FunctionId =1,
                        FunctionName = "Test",
                        IsDeleted = false,
                        IsInScheduledOutage = false                        
                    }
                },

                MGChannelManager = new ChannelManager()
                {
                    Id = 1,
                    IsActive = true,
                    IsDeleted = false,
                    BranchName = "Test",
                    CityId = 1,
                    Code = "TEST",
                    CountryId = 1,
                    NoOfRetries = 2,
                    Name = "SM"                    
                }

            };
            
        }
    }
}
