using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgencyResponseModel = MG.Jarvis.Api.BackOffice.Models.Response.Agency;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class AgencyControllerTest
    {
        #region Private Variables
        private AgencyController agencyController;
        
        private Mock<ILogger> loggerMock;
        private Mock<IConfiguration> iConfigurationMock;
        private Mock<IConnection<Core.Model.Agency.Agency>> _iAgency;
        private Mock<IConnection<AgencyContacts>> _iAgencyContactMock;
        private Mock<IConnection<IncludedCountryRelation>> _iAgencyIncludedCountryMock;
        private Mock<IConnection<ExcludedCountryRelation>> _iAgencyExcludedCountryMock;
        private Mock<IConnection<AgencySupplierRelation>> _iAgencySupplierRelationMock;
        private Mock<IConnection<Bank>> _iAgencyBankMock;
        private Mock<IConnection<Payment>> _iAgencyPaymentMock;
        private Mock<IConnection<Agents>> _iAgencySuperUserMock;
        private Mock<IConnection<Core.Model.Agency.Branch>> _iAgencyBranchMock;
        private Mock<IConnection<BranchAgentRelation>> _iAgencyBranchAgentRelationMock;
        private Mock<IMasterData<Models.Request.Agency, int>> _iMasterData;
        private Mock<IAgency> _iAgencyRepositoryMock;

        #endregion Private Variables

        public AgencyControllerTest()
        {            
            iConfigurationMock = new Mock<IConfiguration>();
            loggerMock = new Mock<ILogger>();           
            _iAgency = new Mock<IConnection<Core.Model.Agency.Agency>>();
            _iAgencyContactMock = new Mock<IConnection<AgencyContacts>>();
            _iAgencyIncludedCountryMock = new Mock<IConnection<IncludedCountryRelation>>();
            _iAgencyExcludedCountryMock = new Mock<IConnection<ExcludedCountryRelation>>();
            _iAgencySupplierRelationMock = new Mock<IConnection<AgencySupplierRelation>>();
            _iAgencyBankMock = new Mock<IConnection<Bank>>();
            _iAgencyPaymentMock = new Mock<IConnection<Payment>>();
            _iAgencySuperUserMock = new Mock<IConnection<Agents>>();
            _iAgencyBranchMock = new Mock<IConnection<Core.Model.Agency.Branch>>();
            _iAgencyBranchAgentRelationMock = new Mock<IConnection<BranchAgentRelation>>();
            _iMasterData = new Mock<IMasterData<Models.Request.Agency, int>>();
            _iAgencyRepositoryMock = new Mock<IAgency>();

            agencyController = new AgencyController(_iMasterData.Object, loggerMock.Object, _iAgency.Object, iConfigurationMock.Object,
                _iAgencyContactMock.Object, _iAgencyIncludedCountryMock.Object, _iAgencyExcludedCountryMock.Object, _iAgencyPaymentMock.Object,
                _iAgencyBankMock.Object, _iAgencySupplierRelationMock.Object, _iAgencySuperUserMock.Object, _iAgencyBranchMock.Object,
                _iAgencyBranchAgentRelationMock.Object, _iAgencyRepositoryMock.Object);
        }
        
        [Test]
        public void TestGetAllAgenciesNullObjectReturnsNoContentFail()
        {
            _iAgencyRepositoryMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<List<AgencyResponseModel>>()));

            var result = agencyController.Get().Result;

            Assert.IsTrue(result is NoContentResult);
            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        }

        [Test]
        public void TestGetAllAgenciesReturnsAnErrorOrExceptionFail()
        {
            _iAgencyRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<AgencyResponseModel>> { IsError = true, ExceptionMessage = Common.GetMockException()}));

            var result = agencyController.Get().Result;

            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllAgenciesReturnOkSuccess()
        {
            List<AgencyResponseModel> fakeAgencyResponseList = new List<AgencyResponseModel>();
            fakeAgencyResponseList = this.GetFakeListOfAgencyResponseModel();

            _iAgencyRepositoryMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<AgencyResponseModel>> { Result = fakeAgencyResponseList, IsError = false }));

            var result = agencyController.Get().Result;
            BaseResult<List<AgencyResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<AgencyResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestGetAllAgenciesThrowsException()
        {
            _iAgencyRepositoryMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = agencyController.Get().Result;
            Assert.That(((StatusCodeResult)result).StatusCode is 500);
        }
        
        private List<AgencyResponseModel> GetFakeListOfAgencyResponseModel()
        {
            List<AgencyResponseModel> fakeAgencyResponseList = new List<AgencyResponseModel>();
            fakeAgencyResponseList = new List<AgencyResponseModel>();
            {
                fakeAgencyResponseList.Add(new AgencyResponseModel
                {

                    MGAgency = new Models.Response.AgencyViewModel
                    {
                        CountryId = 5,
                        CityId = 5,
                        CurrencyId = 1,
                        Name = "GTA",
                        IsActive = true,
                        IsDeleted = false,
                        HasDynamicAvailabilityAccess = true,
                        HasStaticAvailabilityAccess = false,
                        Code = "AC10005",
                        LogoURL = "GTAlogo.jpg",
                        Website = "www.GTA.com",
                        AddressLine1 = "Society",
                        AddressLine2 = "LandMark",
                        Zipcode = "1234",
                        Remark = "GTA Remark Testing",
                        InternalRemark = "GTA Internal Remark Testing",
                        XMLUserName = "UserName",
                        XMLPassword = "XML PWD",
                        IsB2BUser = true,
                        IsXMLUser = false,
                        IsB2B = true,
                        IsB2C = true,
                        IsAccessCache = true,
                        IsAccessLiveRequest = true,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    AgencyContacts = new List<AgencyContacts>
                        {
                            new AgencyContacts{ ContactPerson ="Jon Doe", DesignationId = 1, Email ="john@gta.com", ContactNumber ="1234567890",
                                IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false }
                        },
                    Payment = new Payment
                    {
                        PaymentTypeId = 1,
                        CurrencyId = 1,
                        CreditDays = 30,
                        IsActiveEPayment = true,
                        IsActiveTransferMoney = true,
                        CancelDays = 30,
                        IsDisabledCreditLimit = false,
                        IsDeleted = false,
                        Remark = "Payment Remark Testing",
                        InternalRemark = "Payment Internal Remark Testing",
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    Bank = new Bank
                    {
                        Name = "Bank Name",
                        FullName = "Full Bank Name",
                        AccountNumber = "1111111",
                        IsDeleted = false,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    IncludedCountryRelation = new List<Models.Response.AgencyIncludedCountry>
                    {
                        new Models.Response.AgencyIncludedCountry
                        {
                            CountryId = 5,
                            IsDeleted = false,
                            CreatedBy = "sa",
                            UpdatedBy = "sa"
                        }
                    },
                    ExcludedCountryRelation = new List<Models.Response.AgencyExcludedCountry>
                    {
                        new Models.Response.AgencyExcludedCountry
                        {
                            CountryId = 7,
                            IsDeleted = false,
                            CreatedBy = "sa",
                            UpdatedBy = "sa"
                        }
                    },
                    AgencySupplierRelation = new List<AgencySupplierRelation>
                    {
                        new AgencySupplierRelation { SupplierId=2, SupplierCode="MaxiRoom",CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false}
                    },
                    SuperUserAgent = new Agents
                    {
                        Name = "Supplier Agent",
                        PhoneNumber = "78787878",
                        EmailAddress = "agent@user.com",
                        DesignationId = 1,
                        IsDeleted = false
                    }
                });
                fakeAgencyResponseList.Add(new AgencyResponseModel
                {
                    MGAgency = new Models.Response.AgencyViewModel
                    {
                        CountryId = 5,
                        CityId = 5,
                        CurrencyId = 1,
                        Name = "GTA",
                        IsActive = true,
                        IsDeleted = false,
                        HasDynamicAvailabilityAccess = true,
                        HasStaticAvailabilityAccess = false,
                        Code = "AC10005",
                        LogoURL = "GTAlogo.jpg",
                        Website = "www.GTA.com",
                        AddressLine1 = "Society",
                        AddressLine2 = "LandMark",
                        Zipcode = "1234",
                        Remark = "GTA Remark Testing",
                        InternalRemark = "GTA Internal Remark Testing",
                        XMLUserName = "UserName",
                        XMLPassword = "XML PWD",
                        IsB2BUser = true,
                        IsXMLUser = false,
                        IsB2B = true,
                        IsB2C = true,
                        IsAccessCache = true,
                        IsAccessLiveRequest = true,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    AgencyContacts = new List<AgencyContacts>
                        {
                            new AgencyContacts{ ContactPerson ="Jon Doe", DesignationId = 1, Email ="john@gta.com", ContactNumber ="1234567890",
                                IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false }
                        },
                    Payment = new Payment
                    {
                        PaymentTypeId = 1,
                        CurrencyId = 1,
                        CreditDays = 30,
                        IsActiveEPayment = true,
                        IsActiveTransferMoney = true,
                        CancelDays = 30,
                        IsDisabledCreditLimit = false,
                        IsDeleted = false,
                        Remark = "Payment Remark Testing",
                        InternalRemark = "Payment Internal Remark Testing",
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    Bank = new Bank
                    {
                        Name = "Bank Name",
                        FullName = "Full Bank Name",
                        AccountNumber = "1111111",
                        IsDeleted = false,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    }
                 });
            }

            return fakeAgencyResponseList;
        }
    }
}
