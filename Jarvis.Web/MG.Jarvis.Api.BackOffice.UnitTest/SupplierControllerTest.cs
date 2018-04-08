using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Response;
using MG.Jarvis.Api.BackOffice.UnitTest.Helper;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupplierRequestModel = MG.Jarvis.Api.BackOffice.Models.Request.Supplier;
using SupplierResponseModel = MG.Jarvis.Api.BackOffice.Models.Response.Supplier;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class SupplierControllerTest
    {
        #region Private Variables
        private SupplierController supplierController;
        private Mock<ISupplier> iSupplierMock;
        private Mock<ILogger> iLoggerMock;
        private Mock<IConnection<Suppliers>> iSuppliersMock;
        private Mock<IConnection<Bank>> iBankMock;
        private Mock<IConnection<Contacts>> iContactsMock;
        private Mock<IConnection<Payment>> iPaymentMock;
        private Mock<IConnection<FunctionSupplierRelation>> iSuppliersFunctionsMappingMock;
        private Mock<IConnection<Functions>> iFunctionsMock;
        private Mock<IConnection<UserRelation>> iUserRelationMock;
        private Mock<IMasterData<SupplierRequestModel, int>> _iMasterData;
        #endregion Private Variables

        public SupplierControllerTest()
        {
            iSupplierMock = new Mock<ISupplier>();
            iLoggerMock = new Mock<ILogger>();
            _iMasterData = new Mock<IMasterData<SupplierRequestModel, int>>();
            iBankMock = new Mock<IConnection<Bank>>();
            iContactsMock = new Mock<IConnection<Contacts>>();
            iPaymentMock = new Mock<IConnection<Payment>>();
            iSuppliersMock = new Mock<IConnection<Suppliers>>();
            iSuppliersFunctionsMappingMock = new Mock<IConnection<FunctionSupplierRelation>>();
            iFunctionsMock = new Mock<IConnection<Functions>>();
            iUserRelationMock = new Mock<IConnection<UserRelation>>();

            supplierController = new SupplierController(_iMasterData.Object, 
                                                        iLoggerMock.Object, 
                                                        iBankMock.Object,
                                                        iContactsMock.Object,
                                                        iPaymentMock.Object,
                                                        iSuppliersMock.Object,
                                                        iSuppliersFunctionsMappingMock.Object,
                                                        iFunctionsMock.Object,
                                                        iUserRelationMock.Object,
                                                        iSupplierMock.Object);
        }


        [Test]
        public void TestGetAllSuppliersNullObjectReturnsNoContentFail()
        {
            iSupplierMock.Setup(x => x.Get())
                .Returns(Task.FromResult(new BaseResult<List<SupplierResponseModel>>()));

            var result = supplierController.Get().Result;

            Assert.That(result is NoContentResult);
        }

        [Test]
        public void TestGetAllSuppliersReturnsAnErrorOrExceptionFail()
        {
            iSupplierMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<SupplierResponseModel>> { IsError = true, ExceptionMessage = Common.GetMockException() }));

            var result = supplierController.Get().Result;

            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllSuppliersReturnOkSuccess()
        {
            List<SupplierResponseModel> fakeSupplierResponseList = new List<SupplierResponseModel>();
            fakeSupplierResponseList = this.GetFakeListOfSupplierResponseModel();

            iSupplierMock.Setup(x => x.Get()).Returns(Task.FromResult(new BaseResult<List<SupplierResponseModel>> { Result = fakeSupplierResponseList, IsError = false }));

            var result = supplierController.Get().Result;
            BaseResult<List<SupplierResponseModel>> resultList = (result as OkObjectResult).Value as BaseResult<List<SupplierResponseModel>>;

            Assert.That(result is OkObjectResult);
        }

        [Test]
        public void TestGetAllSuppliersThrowsException()
        {
            iSupplierMock.Setup(x => x.Get()).Throws(Common.GetMockException());

            var result = supplierController.Get().Result;
            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        }

        private SupplierResponseModel GetFakeSupplierResponseModel()
        {
            SupplierResponseModel fakeSupplierResponseModel = new SupplierResponseModel()
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

                FunctionEndpoints = new List<FunctionSupplierRelationModel>
                {
                    new FunctionSupplierRelationModel{FunctionId = 1, SupplierId = 1, EnvironmentId = 1, EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels", IsDeleted = false,
                        CreatedBy = "sa",UpdatedBy = "sa"}
                }


            };

            return fakeSupplierResponseModel;
        }

        private List<SupplierResponseModel> GetFakeListOfSupplierResponseModel()
        {
            List<SupplierResponseModel> fakeSupplierResponseList = new List<SupplierResponseModel>();
            fakeSupplierResponseList = new List<SupplierResponseModel>();
            {
                fakeSupplierResponseList.Add(new SupplierResponseModel
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

                    FunctionEndpoints = new List<FunctionSupplierRelationModel>
                {
                    new FunctionSupplierRelationModel{FunctionId = 1, SupplierId = 1, EnvironmentId = 1, EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels", IsDeleted = false,
                        CreatedBy = "sa",UpdatedBy = "sa"}
                }
                });
                fakeSupplierResponseList.Add(new SupplierResponseModel
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

                    FunctionEndpoints = new List<FunctionSupplierRelationModel>
                {
                    new FunctionSupplierRelationModel{FunctionId = 1, SupplierId = 1, EnvironmentId = 1, EndpointURL = "https://api.test.hotelbeds.com/hotel-api/1.0/hotels", IsDeleted = false,
                        CreatedBy = "sa",UpdatedBy = "sa"}
                }
                });
            }
            return fakeSupplierResponseList;
        }
    }
}
