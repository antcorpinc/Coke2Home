using Dapper;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Agency;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest.Repositories
{
    [TestFixture]
    public class AgencyRepositoryTest
    {
        #region Private Variable
        private IAgency agencyRepositoryMock;
        private Mock<IConfiguration> iConfigurationMock;
        private Mock<IConnection<Agency>> iAgencyMock;
        private Mock<IConnection<AgencyContacts>> iAgencyContactsMock;
        private Mock<IConnection<Payment>> iAgencyPaymentMock;
        private Mock<IConnection<Bank>> iAgencyBankMock;
        private Mock<IConnection<AgencySupplierRelation>> iAgencySuppliersMock;
        private Mock<IConnection<IncludedCountryRelation>> iAgencyIncludedCountryMock;
        private Mock<IConnection<ExcludedCountryRelation>> iAgencyExcludedCountryMock;
        private Mock<IConnection<Branch>> iAgencyBranchMock;
        private Mock<IConnection<Agents>> iAgencyAgentsMock;
        private Mock<IConnection<BranchAgentRelation>> iAgencyBranchAgentMock;
        private Mock<IConnection<Currency>> iCurrencyMock;
        private Mock<IConnection<Country>> iCountryMock;

        #endregion Private Variable

        public AgencyRepositoryTest()
        {
            iConfigurationMock = new Mock<IConfiguration>();
            iAgencyMock = new Mock<IConnection<Agency>>();
            iAgencyContactsMock = new Mock<IConnection<AgencyContacts>>();
            iAgencyPaymentMock = new Mock<IConnection<Payment>>();
            iAgencyBankMock = new Mock<IConnection<Bank>>();
            iAgencySuppliersMock = new Mock<IConnection<AgencySupplierRelation>>();
            iAgencyIncludedCountryMock = new Mock<IConnection<IncludedCountryRelation>>();
            iAgencyExcludedCountryMock = new Mock<IConnection<ExcludedCountryRelation>>();
            iAgencyBranchMock = new Mock<IConnection<Branch>>();
            iAgencyAgentsMock = new Mock<IConnection<Agents>>();
            iAgencyBranchAgentMock = new Mock<IConnection<BranchAgentRelation>>();
            iCurrencyMock = new Mock<IConnection<Currency>>();
            iCountryMock = new Mock<IConnection<Country>>();
            agencyRepositoryMock = new AgencyRepository(iAgencyMock.Object, 
                                                        iAgencyContactsMock.Object,
                                                        iAgencyIncludedCountryMock.Object, 
                                                        iAgencyExcludedCountryMock.Object,
                                                        iAgencyPaymentMock.Object, 
                                                        iAgencyBankMock.Object, 
                                                        iAgencySuppliersMock.Object,
                                                        iAgencyAgentsMock.Object, 
                                                        iAgencyBranchMock.Object, 
                                                        iAgencyBranchAgentMock.Object,
                                                        iCurrencyMock.Object,
                                                        iCountryMock.Object
                                                        );
                                                        
        }

        //[Test]
        //public void TestCreateAgencyReturnsSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
            
        //    iAgencyMock.Setup(x => x. ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.CreateAgency(fakeAgencyRequest).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestCreateAgencyReturnsAgencyContactsCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.AgencyContacts = new List<AgencyContacts> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.CreateAgency(fakeAgencyRequest).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestCreateAgencyReturnsIncludedCountriesCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.IncludedCountryRelation = new List<IncludedCountryRelation> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.CreateAgency(fakeAgencyRequest).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestCreateAgencyReturnsExcludedCountriesCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.ExcludedCountryRelation = new List<ExcludedCountryRelation> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.CreateAgency(fakeAgencyRequest).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestCreateAgencyReturnsAgencySuppliersCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.AgencySupplierRelation = new List<AgencySupplierRelation> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.CreateAgency(fakeAgencyRequest).Result;

        //    Assert.IsTrue(result.Result);
        //}

        [Test]
        public void TestGetAllAgencyReturnsAgenciesListSuccess()
        {
            this.MockGetAllAgenciesResponseTables(true);

            var result = agencyRepositoryMock.Get().Result;
            Assert.IsTrue(result.Result.Count > 0);
            Assert.IsTrue(result.Result[0].MGAgency != null);
        }

        [Test]
        public void TestGetAllAgencyReturnsNullAgencyListFail()
        {
            this.MockGetAllAgenciesResponseTables(false);

            var result = agencyRepositoryMock.Get().Result;            
            Assert.IsNull(result.Result);
        }

        #region GetById
        //[Test]
        //public void TestGetAgencyByIdReturnsAgencySuccess()
        //{   
        //    this.MockGetAllAgenciesResponseTables(true);

        //    var result = agencyRepositoryMock.Get(5).Result;
        //    Assert.IsNotNull(result.Result);
        //    Assert.IsTrue(result.Result.Agency != null);
        //}

        //[Test]
        //public void TestGetAgencyByIdReturnsNullFail()
        //{
        //    this.MockGetAllAgenciesResponseTables(false);

        //    var result = agencyRepositoryMock.GetAgency(5).Result;
        //    Assert.IsNull(result.Result);
        //}
#endregion

        //[Test]
        //public void TestUpdateAgencyReturnsSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.UpdateAgency(fakeAgencyRequest, true, false).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestUpdateAgencyReturnsAgencyContactsCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.AgencyContacts = new List<AgencyContacts> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.UpdateAgency(fakeAgencyRequest, true, false).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestUpdateAgencyReturnsIncludedCountriesCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.IncludedCountryRelation = new List<IncludedCountryRelation> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.UpdateAgency(fakeAgencyRequest, true, false).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestUpdateAgencyReturnsExcludedCountriesCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.ExcludedCountryRelation = new List<ExcludedCountryRelation> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.UpdateAgency(fakeAgencyRequest, true, false).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestUpdateAgencyReturnsAgencySuppliersCountIsZeroSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();
        //    fakeAgencyRequest.AgencySupplierRelation = new List<AgencySupplierRelation> { };

        //    iAgencyMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.UpdateAgency(fakeAgencyRequest, true, false).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestDeleteAgencyReturnsSuccess()
        //{
        //    AgencyRequest fakeAgencyRequest = this.GetFakeAgencyRequestModel();

        //    iAgencyMock.Setup(x => x.UpdateEntityByDapper(fakeAgencyRequest.Agency)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = agencyRepositoryMock.UpdateAgency(fakeAgencyRequest, false, true).Result;

        //    Assert.IsTrue(result.Result);
        //}

        private void MockGetAllAgenciesResponseTables(bool ifSuccess)
        {
            Models.Response.Agency fakeAgencyResponse = this.GetFakeAgencyResponseModel();
            List<Models.Response.Agency> fakeLsitAgencyResponse = this.GetFakeListOfAgencyResponseModel();
            
            var branch = new Branch
            {
                Id = 1,Name = "Insert Test",AgencyId = 6,Address1 = "Test Address Insert",Address2 = "Add2",CityId = 2,CountryId = 4,
                NameItemId = 1,ZipCode = "13455",CreatedBy = "MGIT",UpdatedBy = "MGIT"
            };

            var agencyContacts = new AgencyContacts
            {
                ContactPerson = "Jon Doe",DesignationId = 1,Email = "john@gta.com",ContactNumber = "1234567890",IsPrimary = true,
                CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false
            };

            var agencyIncludedCountries = new IncludedCountryRelation
            {
                CountryId = 5,IsDeleted = false,CreatedBy = "sa",UpdatedBy = "sa"
            };

            var agencyExcludedCountries = new ExcludedCountryRelation
            {
                CountryId = 6,IsDeleted = false,CreatedBy = "sa",UpdatedBy = "sa"
            };

            var agencySuppliers = new AgencySupplierRelation
            {
                SupplierId = 2,SupplierCode = "MaxiRoom",CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false
            };

            var branchAgentRelation = new BranchAgentRelation { AgentId = 1, BranchId = 1, IsSuperUser = true };

            var agents = new Agents { Name = "Agent1", Address1 = "Agent Add1", Address2 = "Agent Add2", EmailAddress = "agent@agent.com", AgencyBranchId = 1, AgencyId = 5 ,Id = 2};
            

            var agencyPred = new Func<Agency, bool>(x => x.IsActive && !x.IsDeleted);

            if (ifSuccess)
            {

                iAgencyMock.Setup(x => x.GetListByPredicate(It.Is<Func<Agency, bool>>(a => a.GetType() == agencyPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Agency>> { Result = new List<Agency>() { fakeAgencyResponse.MGAgency }, IsError = false }));
            }
            else
            {
                iAgencyMock.Setup(x => x.GetListByPredicate(It.Is<Func<Agency, bool>>(a => a.GetType() == agencyPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Agency>> { Result = new List<Agency>(), IsError = false }));
            }

            var agencyContactsPred = new Func<AgencyContacts, bool>(a => a.IsActive && !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id);
            iAgencyContactsMock.Setup(x => x.GetListByPredicate(It.Is<Func<AgencyContacts, bool>>(a => a.GetType() == agencyContactsPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<AgencyContacts>> { Result = new List<AgencyContacts>() { agencyContacts }, IsError = false }));

            var agencyPaymentPred = new Func<Payment, bool>((a => !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id));
            iAgencyPaymentMock.Setup(x => x.GetListByPredicate(It.Is<Func<Payment, bool>>(a => a.GetType() == agencyPaymentPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Payment>> { Result = new List<Payment>() { fakeAgencyResponse.Payment }, IsError = false }));

            var branchPred = new Func<Branch, bool>(a => a.IsActive && !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id && a.IsHeadOffice == true);
            iAgencyBranchMock.Setup(x => x.GetListByPredicate(It.Is<Func<Branch, bool>>(a => a.GetType() == branchPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Branch>> { Result = new List<Branch>() { branch }, IsError = false }));

            var bankPred = new Func<Bank, bool>(a => a.IsActive && !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id);
            iAgencyBankMock.Setup(x => x.GetListByPredicate(It.Is<Func<Bank, bool>>(a => a.GetType() == bankPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Bank>> { Result = new List<Bank>() { fakeAgencyResponse.Bank }, IsError = false }));

            var includedCountryPred = new Func<IncludedCountryRelation, bool>(a => a.IsActive && !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id);
            iAgencyIncludedCountryMock.Setup(x => x.GetListByPredicate(It.Is<Func<IncludedCountryRelation, bool>>(a => a.GetType() == includedCountryPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<IncludedCountryRelation>> { Result = new List<IncludedCountryRelation>() { agencyIncludedCountries }, IsError = false }));

            var excludedCountryPred = new Func<ExcludedCountryRelation, bool>(a => a.IsActive && !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id);
            iAgencyExcludedCountryMock.Setup(x => x.GetListByPredicate(It.Is<Func<ExcludedCountryRelation, bool>>(a => a.GetType() == excludedCountryPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<ExcludedCountryRelation>> { Result = new List<ExcludedCountryRelation>() { agencyExcludedCountries }, IsError = false }));

            var agencySupplierPred = new Func<AgencySupplierRelation, bool>(a => a.IsActive && !a.IsDeleted && a.AgencyId == fakeAgencyResponse.MGAgency.Id);
            iAgencySuppliersMock.Setup(x => x.GetListByPredicate(It.Is<Func<AgencySupplierRelation, bool>>(a => a.GetType() == agencySupplierPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<AgencySupplierRelation>> { Result = new List<AgencySupplierRelation>() { agencySuppliers }, IsError = false }));

            var branchAgentPred = new Func<BranchAgentRelation, bool>(a => a.IsActive && !a.IsDeleted && a.BranchId == branch.Id && a.IsSuperUser == true);
            iAgencyBranchAgentMock.Setup(x => x.GetListByPredicate(It.Is<Func<BranchAgentRelation, bool>>(a => a.GetType() == branchAgentPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<BranchAgentRelation>> { Result = new List<BranchAgentRelation>() { branchAgentRelation }, IsError = false }));

            var agentPred = new Func<Agents, bool>(a => a.IsActive && !a.IsDeleted && a.Id == branchAgentRelation.AgentId);
            iAgencyAgentsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Agents, bool>>(a => a.GetType() == agentPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Agents>> { Result = new List<Agents>() { agents }, IsError = false }));

        }

        private List<Models.Response.Agency> GetFakeListOfAgencyResponseModel()
        {
            List<Models.Response.Agency> fakeAgencyResponseList = new List<Models.Response.Agency>();
            fakeAgencyResponseList = new List<Models.Response.Agency>();
            {
                fakeAgencyResponseList.Add(new Models.Response.Agency
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
                fakeAgencyResponseList.Add(new Models.Response.Agency
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

        private Models.Request.Agency GetFakeAgencyRequestModel()
        {
            Models.Request.Agency mockAgencyRequest = new Models.Request.Agency
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
                        new AgencyContacts {ContactPerson ="Jon Doe", DesignationId = 1, Email ="john@gta.com", ContactNumber ="1234567890",
                            IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa",IsActive = true,IsDeleted = false}
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
                IncludedCountryRelation = new List<IncludedCountryRelation>
                {
                    new IncludedCountryRelation
                    {
                        CountryId = 5,
                        IsDeleted = false,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    }
                },
                ExcludedCountryRelation = new List<ExcludedCountryRelation>
                {
                    new ExcludedCountryRelation
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

            };

            return mockAgencyRequest;
        }

        private Models.Response.Agency GetFakeAgencyResponseModel()
        {
            Models.Response.Agency fakeAgencyResponseModel = new Models.Response.Agency()
            {
                MGAgency = new Models.Response.AgencyViewModel
                {
                    Id= 5,
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
                    Name = "Agent1",Address1 = "Agent Add1",Address2 = "Agent Add2",EmailAddress = "agent@agent.com",AgencyBranchId = 1,AgencyId = 5,Id = 2
                }
            };

            return fakeAgencyResponseModel;
        }

    }
}
