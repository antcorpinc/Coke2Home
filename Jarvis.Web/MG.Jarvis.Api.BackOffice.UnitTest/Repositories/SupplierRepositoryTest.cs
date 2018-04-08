using Dapper;
using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models;
using MG.Jarvis.Api.BackOffice.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
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
    public class SupplierRepositoryTest
    {
        #region Private Variable
        private ISupplier supplierRepositoryMock;
        private Mock<IConfiguration> iConfigurationMock;
        private Mock<IConnection<Suppliers>> iSupplierMock;
        private Mock<IConnection<Contacts>> iSupplierContactsMock;
        private Mock<IConnection<Payment>> iSupplierPaymentMock;
        private Mock<IConnection<Bank>> iSupplierBankMock;
        private Mock<IConnection<FunctionSupplierRelation>> iSupplierFunctionMock;
        private Mock<IConnection<Functions>> iSupplierFunctionsMock;
        private Mock<IConnection<UserRelation>> iSupplierUserRelationMock;

        #endregion Private Variable

        public SupplierRepositoryTest()
        {
            iConfigurationMock = new Mock<IConfiguration>();
            iSupplierMock = new Mock<IConnection<Suppliers>>();
            iSupplierContactsMock = new Mock<IConnection<Contacts>>();
            iSupplierPaymentMock = new Mock<IConnection<Payment>>();
            iSupplierBankMock = new Mock<IConnection<Bank>>();
            iSupplierFunctionMock = new Mock<IConnection<FunctionSupplierRelation>>();
            iSupplierFunctionsMock = new Mock<IConnection<Functions>>();
            iSupplierUserRelationMock = new Mock<IConnection<UserRelation>>();

            supplierRepositoryMock = new SupplierRepository(iSupplierBankMock.Object, iSupplierContactsMock.Object,
                                                            iSupplierPaymentMock.Object, iSupplierMock.Object, iSupplierFunctionMock.Object,
                                                            iSupplierFunctionsMock.Object, iSupplierUserRelationMock.Object);
        }

        //[Test]
        //public void TestCreateSupplierReturnsSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();

        //    iSupplierMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.CreateSupplier(fakeSupplierRequest).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestCreateSupplierReturnsSupplierContactsCountIsZeroSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();
        //    fakeSupplierRequest.SupplierContacts = new List<Contacts> { };

        //    iSupplierMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.CreateSupplier(fakeSupplierRequest).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestCreateSupplierReturnsSupplierBankCountIsZeroSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();
        //    fakeSupplierRequest.Banks = new List<Bank> { };

        //    iSupplierMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.CreateSupplier(fakeSupplierRequest).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        [Test]
        public void TestGetAllSuppliersReturnsSuppliersListSuccess()
        {
            this.MockGetAllSuppliersResponseTables(true);

            var result = supplierRepositoryMock.Get().Result;
            Assert.IsTrue(result.Result.Count > 0);
            Assert.IsTrue(result.Result[0].MGSupplier != null);
            //Assert.Equals(fakeLsitAgencyResponse, result.Result);

        }

        [Test]
        public void TestGetAllSuppliersReturnsNullSupplierListFail()
        {
            this.MockGetAllSuppliersResponseTables(false);

            var result = supplierRepositoryMock.Get().Result;
            Assert.IsNull(result.Result);
            //Assert.Equals(fakeLsitAgencyResponse, result.Result);
        }

        [Test]
        public void TestGetSupplierByIdReturnsSupplierSuccess()
        {
            Models.Response.Supplier fakesupplierResponse = this.GetFakeSupplierResponseModel();

            this.MockGetAllSuppliersResponseTables(true);

            var result = supplierRepositoryMock.GetById(1).Result;
            Assert.IsNotNull(result.Result);
            Assert.IsTrue(result.Result.MGSupplier != null);
        }

        [Test]
        public void TestGetSupplierByIdReturnsNullFail()
        {
            Models.Response.Supplier fakesupplierResponse = this.GetFakeSupplierResponseModel();

            this.MockGetAllSuppliersResponseTables(false);

            var result = supplierRepositoryMock.GetById(5).Result;
            Assert.IsNull(result.Result);
        }

        //[Test]
        //public void TestUpdateSupplierReturnsSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();

        //    iSupplierMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.UpdateSupplier(fakeSupplierRequest, true, false).Result;

        //    Assert.IsTrue(result.Result);
        //}

        //[Test]
        //public void TestUpdateSupplierReturnsSupplierContactsCountIsZeroSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();
        //    fakeSupplierRequest.SupplierContacts = new List<Contacts> { };

        //    iSupplierMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.UpdateSupplier(fakeSupplierRequest, true, false).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestUpdateSupplierReturnsSupplierBanksCountIsZeroSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();
        //    fakeSupplierRequest.Banks = new List<Bank> { };

        //    iSupplierMock.Setup(x => x.ExecuteStoredProcedureInsertUpdate(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.UpdateSupplier(fakeSupplierRequest, true, false).Result;

        //    Assert.IsTrue(result.Result is true);
        //}

        //[Test]
        //public void TestDeleteSupplierReturnsSuccess()
        //{
        //    SupplierRequestModel fakeSupplierRequest = this.GetFakeSupplierRequestModel();

        //    iSupplierMock.Setup(x => x.UpdateEntityByDapper(fakeSupplierRequest.Supplier)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));

        //    var result = supplierRepositoryMock.UpdateSupplier(fakeSupplierRequest, false, true).Result;

        //    Assert.IsTrue(result.Result);
        //}

       


        private void MockGetAllSuppliersResponseTables(bool ifSuccess)
        {
            Models.Response.Supplier fakeSupplierResponse = this.GetFakeSupplierResponseModel();
            List<Models.Response.Supplier> fakeListSupplierResponse = this.GetFakeListOfSupplierResponseModel();

            var supplierList = new List<Suppliers>();

            foreach (var supplier in fakeListSupplierResponse)
            {
                supplierList.Add(supplier.MGSupplier);
            }

            var supplierContacts = new Contacts
            {
                SupplierId = 1,
                DesignationId = 1,
                ContactPerson = "Jon Doe",
                EmailAddress = "john@gta.com",
                PhoneNumber = "1234567890",
                IsActive = true,
                IsDeleted = false,
                IsPrimary = true,
                CreatedBy = "sa",
                UpdatedBy = "sa"
            };

            var supplierBank = new Bank
            {
                SupplierId = 1,
                Name = "Oriental",
                AccountTypeId = 4,
                Account = "Test Account",
                Branch = "Test Branch",
                AccountNumber = "ABC54321",
                IsPrimarySet = true,
                IsActive = true,
                IsDeleted = false,
                CreatedBy = "sa",
                UpdatedBy = "sa"
            };

            var supplierCredentials = new UserRelation
            {
                SupplierId = 1,
                EnvironmentId = 1,
                UserInfo = "String Value",
                IsDeleted = false
            };

            var functionEndpoints = new FunctionSupplierRelation
            {
                FunctionId = 1,
                SupplierId = 1,
                EnvironmentId = 1,
                EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels",
                IsDeleted = false,
                CreatedBy = "sa",
                UpdatedBy = "sa"
            };


            

            var supplierPred = new Func<Suppliers, bool>(x => x.IsActive && !x.IsDeleted);

            if (ifSuccess)
            {

                iSupplierMock.Setup(x => x.GetListByPredicate(It.Is<Func<Suppliers, bool>>(a => a.GetType() == supplierPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Suppliers>> { Result = new List<Suppliers>() { fakeSupplierResponse.MGSupplier }, IsError = false }));
            }
            else
            {
                iSupplierMock.Setup(x => x.GetListByPredicate(It.Is<Func<Suppliers, bool>>(a => a.GetType() == supplierPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Suppliers>> { Result = new List<Suppliers>(), IsError = false }));
            }

            var supplierContactsPred = new Func<Contacts, bool>(a => a.IsActive && !a.IsDeleted && a.SupplierId == fakeSupplierResponse.MGSupplier.Id);
            iSupplierContactsMock.Setup(x => x.GetListByPredicate(It.Is<Func<Contacts, bool>>(a => a.GetType() == supplierContactsPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Contacts>> { Result = new List<Contacts>() { supplierContacts }, IsError = false }));

            var supplierBankPred = new Func<Bank, bool>((a => !a.IsDeleted && a.SupplierId == fakeSupplierResponse.MGSupplier.Id));
            iSupplierBankMock.Setup(x => x.GetListByPredicate(It.Is<Func<Bank, bool>>(a => a.GetType() == supplierBankPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Bank>> { Result = new List<Bank>() { supplierBank }, IsError = false }));

            var supplierPaymentPred = new Func<Payment, bool>((a => !a.IsDeleted && a.SupplierId == fakeSupplierResponse.MGSupplier.Id));
            iSupplierPaymentMock.Setup(x => x.GetListByPredicate(It.Is<Func<Payment, bool>>(a => a.GetType() == supplierPaymentPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<Payment>> { Result = new List<Payment>() { fakeSupplierResponse.SupplierPayment }, IsError = false }));

            var supplierCredentialsPred = new Func<UserRelation, bool>(a => !a.IsDeleted && a.SupplierId == fakeSupplierResponse.MGSupplier.Id);
            iSupplierUserRelationMock.Setup(x => x.GetListByPredicate(It.Is<Func<UserRelation, bool>>(a => a.GetType() == supplierCredentialsPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<UserRelation>> { Result = new List<UserRelation>() { supplierCredentials }, IsError = false }));

            var supplierFunctionEndpointsPred = new Func<FunctionSupplierRelation, bool>(a => !a.IsDeleted && a.SupplierId == fakeSupplierResponse.MGSupplier.Id);
            iSupplierFunctionMock.Setup(x => x.GetListByPredicate(It.Is<Func<FunctionSupplierRelation, bool>>(a => a.GetType() == supplierFunctionEndpointsPred.GetType()))).Returns(Task.FromResult(new BaseResult<List<FunctionSupplierRelation>> { Result = new List<FunctionSupplierRelation>() { functionEndpoints }, IsError = false }));

        }

        private List<Models.Response.Supplier> GetFakeListOfSupplierResponseModel()
        {
            List<Models.Response.Supplier> fakeSupplierResponseList = new List<Models.Response.Supplier>();
            fakeSupplierResponseList = new List<Models.Response.Supplier>();
            {
                fakeSupplierResponseList.Add(new Models.Response.Supplier
                {

                    MGSupplier = new Suppliers
                    {
                        Name = "GTA",
                        NameItemId = 1,
                        CountryId = 5,
                        CityId = 5,
                        BranchName = "B Name",
                        AddressLine1 = "Society",
                        AddressLine2 = "LandMark",
                        ZipCode = "ZIP4321",
                        Code = "ELEIN",
                        Website = "www.GTA.com",
                        Remark = "GTA Remark Testing",
                        InternalRemark = "GTA Internal Remark Testing",
                        RefreshRate = 5,
                        MGPreferredOrder = 5,
                        ThrottleLimit = 5,
                        IsMappedWithMG = true,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    SupplierContacts = new List<Contacts>
                                {
                                    new Contacts {SupplierId = 1, DesignationId = 1, ContactPerson ="Jon Doe", EmailAddress ="john@gta.com", PhoneNumber ="1234567890", IsActive = true,
                                    IsDeleted = false,IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa"}
                                },
                    SupplierPayment = new Payment
                    {
                        SupplierId = 1,
                        PaymentTypeId = 1,
                        CurrencyId = 1,
                        CreditDays = 30,
                        WithHoldingTaxId = 3,
                        WithHoldingTaxRate = "345",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    Banks = new List<Bank>
                    {
                        new Bank{SupplierId = 1, Name = "Oriental", AccountTypeId = 4, Account = "Test Account", Branch = "Test Branch", AccountNumber = "ABC54321", IsPrimarySet = true,
                            IsActive = true, IsDeleted = false, CreatedBy = "sa",UpdatedBy = "sa"}
                    },
                    SupplierCredentials = new List<UserRelation>
                {
                    new UserRelation {SupplierId = 1, EnvironmentId = 1, UserInfo = "String Value", IsDeleted = false}
                },

                    FunctionEndpoints = new List<Models.Response.FunctionSupplierRelationModel>
                {
                    new Models.Response.FunctionSupplierRelationModel{FunctionId = 1, SupplierId = 1, EnvironmentId = 1, EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels", IsDeleted = false,
                        CreatedBy = "sa",UpdatedBy = "sa"}
                }
                });
                fakeSupplierResponseList.Add(new Models.Response.Supplier
                {

                    MGSupplier = new Suppliers
                    {
                        CountryId = 5,
                        CityId = 5,
                        Name = "GTA",
                        NameItemId = 1,
                        BranchName = "B Name",
                        IsActive = true,
                        IsDeleted = false,
                        Code = "AC10005",
                        Website = "www.GTA.com",
                        AddressLine1 = "Society",
                        AddressLine2 = "LandMark",
                        ZipCode = "1234",
                        Remark = "GTA Remark Testing",
                        InternalRemark = "GTA Internal Remark Testing",
                        RefreshRate = 5,
                        MGPreferredOrder = 4,
                        ThrottleLimit = 10,
                        IsMappedWithMG = true,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    SupplierContacts = new List<Contacts>
                                {
                                    new Contacts {SupplierId = 1, DesignationId = 1, ContactPerson ="Jon Doe", EmailAddress ="john@gta.com", PhoneNumber ="1234567890", IsActive = true,
                                    IsDeleted = false,IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa"}
                                },
                    SupplierPayment = new Payment
                    {
                        SupplierId = 1,
                        PaymentTypeId = 1,
                        CurrencyId = 1,
                        CreditDays = 30,
                        WithHoldingTaxId = 3,
                        WithHoldingTaxRate = "345",
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = "sa",
                        UpdatedBy = "sa"
                    },
                    Banks = new List<Bank>
                    {
                        new Bank{SupplierId = 1, Name = "Oriental", AccountTypeId = 4, Account = "Test Account", Branch = "Test Branch", AccountNumber = "ABC54321", IsPrimarySet = true,
                            IsActive = true, IsDeleted = false, CreatedBy = "sa",UpdatedBy = "sa"}
                    },
                    SupplierCredentials = new List<UserRelation>
                {
                    new UserRelation {SupplierId = 1, EnvironmentId = 1, UserInfo = "String Value2", IsDeleted = false}
                },

                    FunctionEndpoints = new List<Models.Response.FunctionSupplierRelationModel>
                {
                    new Models.Response.FunctionSupplierRelationModel{FunctionId = 1, SupplierId = 1, EnvironmentId = 1, EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels", IsDeleted = false,
                        CreatedBy = "sa",UpdatedBy = "sa"}
                }
                });
            }

            return fakeSupplierResponseList;
        }

        private Models.Request.Supplier GetFakeSupplierRequestModel()
        {
            Models.Request.Supplier mockSupplierRequest = new Models.Request.Supplier
            {
                MGSupplier = new Suppliers
                {
                    Name = "GTA",
                    NameItemId = 1,
                    CountryId = 5,
                    CityId = 5,
                    BranchName = "B Name",
                    AddressLine1 = "Society",
                    AddressLine2 = "LandMark",
                    ZipCode = "ZIP4321",
                    Code = "ELEIN",
                    Website = "www.GTA.com",
                    Remark = "GTA Remark Testing",
                    InternalRemark = "GTA Internal Remark Testing",
                    RefreshRate = 5,
                    MGPreferredOrder = 5,
                    ThrottleLimit = 5,
                    IsMappedWithMG = true,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "sa",
                    UpdatedBy = "sa"
                },

                SupplierContacts = new List<Contacts>
                            {
                                new Contacts {SupplierId = 1, DesignationId = 1, ContactPerson ="Jon Doe", EmailAddress ="john@gta.com", PhoneNumber ="1234567890", IsActive = true,
                                    IsDeleted = false,IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa"}
                            },
                SupplierPayment = new Payment
                {
                    SupplierId = 1,
                    PaymentTypeId = 1,
                    CurrencyId = 1,
                    CreditDays = 30,
                    WithHoldingTaxId = 3,
                    WithHoldingTaxRate = "345",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "sa",
                    UpdatedBy = "sa"
                },
                Banks = new List<Bank>
                {
                    new Bank{SupplierId = 1, Name = "Oriental", AccountTypeId = 4, Account = "Test Account", Branch = "Test Branch", AccountNumber = "ABC54321", IsPrimarySet = true,
                        IsActive = true, IsDeleted = false, CreatedBy = "sa",UpdatedBy = "sa"}
                },

            };

            return mockSupplierRequest;
        }

        private Models.Response.Supplier GetFakeSupplierResponseModel()
        {
            Models.Response.Supplier fakeSupplierResponseModel = new Models.Response.Supplier()
            {
                MGSupplier = new Suppliers
                {
                    Id = 1,
                    Name = "GTA",
                    NameItemId = 1,
                    CountryId = 5,
                    CityId = 5,
                    BranchName = "B Name",
                    AddressLine1 = "Society",
                    AddressLine2 = "LandMark",
                    ZipCode = "ZIP4321",
                    Code = "ELEIN",
                    Website = "www.GTA.com",
                    Remark = "GTA Remark Testing",
                    InternalRemark = "GTA Internal Remark Testing",
                    RefreshRate = 5,
                    MGPreferredOrder = 5,
                    ThrottleLimit = 5,
                    IsMappedWithMG = true,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "sa",
                    UpdatedBy = "sa"
                },

                SupplierContacts = new List<Contacts>
                            {
                                new Contacts {SupplierId = 1, DesignationId = 1, ContactPerson ="Jon Doe", EmailAddress ="john@gta.com", PhoneNumber ="1234567890", IsActive = true,
                                    IsDeleted = false,IsPrimary =true,CreatedBy = "sa",UpdatedBy = "sa"}
                            },

                SupplierPayment = new Payment
                {   
                    SupplierId = 1,
                    PaymentTypeId = 1,
                    CurrencyId = 1,
                    CreditDays = 30,
                    WithHoldingTaxId = 3,
                    WithHoldingTaxRate = "345",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedBy = "sa",
                    UpdatedBy = "sa"
                },

                Banks = new List<Bank>
                {
                    new Bank{SupplierId = 1, Name = "Oriental", AccountTypeId = 4, Account = "Test Account", Branch = "Test Branch", AccountNumber = "ABC54321", IsPrimarySet = true,
                        IsActive = true, IsDeleted = false, CreatedBy = "sa",UpdatedBy = "sa"}
                },

                SupplierCredentials = new List<UserRelation>
                {
                    new UserRelation {SupplierId = 1, EnvironmentId = 1, UserInfo = "String Value", IsDeleted = false}
                },

                FunctionEndpoints = new List<Models.Response.FunctionSupplierRelationModel>
                {
                    new Models.Response.FunctionSupplierRelationModel{FunctionId = 1, SupplierId = 1, EnvironmentId = 1, EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels", IsDeleted = false,
                        CreatedBy = "sa",UpdatedBy = "sa"}
                }
            };

            return fakeSupplierResponseModel;
        }

    }
}
