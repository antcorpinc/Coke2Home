using MG.Jarvis.Api.BackOffice.Controllers;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Core.Logger;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.UnitTest
{
    [TestFixture, Category("BackOffice")]
    public class SupplierConfigationControllerTest
    {
        #region private variable
        private SupplierConfigurationController supplierConfigurationControllerMock;
        private Mock<IMasterData<XMLConfiguration, int>> xmlConfigurationMasterMock;
        private Mock<ILogger> iLoggerMock;
        #endregion Private Variables

        public SupplierConfigationControllerTest()
        {
            xmlConfigurationMasterMock = new Mock<IMasterData<XMLConfiguration, int>>();
            iLoggerMock = new Mock<ILogger>();
            supplierConfigurationControllerMock = new SupplierConfigurationController(xmlConfigurationMasterMock.Object, iLoggerMock.Object);
        }

        #region OldCode
        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationSuccess()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId= 3,
        //        Thotling = 500,                
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Get().Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationNoContentIsActiveSuccess()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = false,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Get().Result;            
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationNoContentIsDeleteSuccess()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = true,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Get().Result;
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationDapperExceptionMessage()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = true,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = true, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationExceptionMessage()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = true,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Throws(new System.Exception());
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Get().Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationByIdSuccess()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.GetById(3).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationByIdNoContentNoIdMatch()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.GetById(4).Result;            
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationByIdNoContentIsActive()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = false,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.GetById(3).Result;            
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationByIdNoContentIsDelete()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = true,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.GetById(3).Result;            
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationByIdDapperExceptionMessage()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = true,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = true, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.GetById(3).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerGetSupplierConfigurationByIdExceptionMessage()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = true,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);

        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Throws(new System.Exception());
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.GetById(3).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerUpdateSupplierConfigurationSuccess()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshka",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.UpdateEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = false, ExceptionMessage = null }));
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Update(supplier).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerUpdateSupplierConfigurationNullObject()
        //{            
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.UpdateEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = false, ExceptionMessage = null }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Update(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerUpdateSupplierConfigurationDapperException()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.UpdateEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = null }));
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Update(supplier).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerUpdateSupplierConfigurationSystemException()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.UpdateEntity(It.IsAny<XMLConfiguration>())).Throws(new System.Exception());
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Update(supplier).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerUpdateSupplierConfigurationGetListError()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.UpdateEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = false, ExceptionMessage = null }));
        //    mock.Setup(x => x.GetList()).Throws(new System.Exception());
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Update(supplier).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerUpdateSupplierConfigurationIdDoesNotExists()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 1,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.UpdateEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = false, ExceptionMessage = null }));
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Update(supplier).Result;
        //    Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerCreateSupplierConfigurationSuccess()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    mock.Setup(x => x.InsertEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<long>() { IsError = false, ExceptionMessage = null }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Create(supplier).Result;
        //    Assert.IsTrue(result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerCreateSupplierConfigurationNullObject()
        //{
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.InsertEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<long>() { IsError = false, ExceptionMessage = null }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Create(null).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerCreateSupplierConfigurationAlreadyPresentConfiguration()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.InsertEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<long>() { IsError = false, ExceptionMessage = null }));
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Create(supplier).Result;
        //    Assert.IsTrue(result is BadRequestObjectResult);
        //    Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerCreateSupplierConfigurationDapperException()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier1 = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier1);

        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 1,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();
        //    mock.Setup(x => x.InsertEntity(It.IsAny<XMLConfiguration>())).Returns(Task.FromResult(new BaseResult<long>() { IsError = true, ExceptionMessage = null }));
        //    mock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<XMLConfiguration>>() { IsError = false, Result = supplierList }));
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Create(supplier).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        //[Test]
        //public void TestSupplierConfigurationControllerCreateSupplierConfigurationSystemException()
        //{
        //    List<XMLConfiguration> supplierList = new List<XMLConfiguration>();
        //    XMLConfiguration supplier = new XMLConfiguration()
        //    {
        //        Id = 3,
        //        AdvanceBookingDays = 3,
        //        CurrencyId = 2,
        //        IsActive = true,
        //        IsDeleted = false,
        //        IsScheduleOutage = true,
        //        MaxChildAge = 8,
        //        MaxInfantge = 1,
        //        MaxLength = 10,
        //        MinChildAge = 3,
        //        MinInfantAge = 3,
        //        SupplierId = 3,
        //        Thotling = 500,
        //        UpdatedBy = "jayeshkalal",
        //        CreatedBy = "jayeshka",
        //        LanguageID = null
        //    };
        //    supplierList.Add(supplier);
        //    var a = JsonConvert.SerializeObject(supplier);
        //    Mock<IMasterData<XMLConfiguration>> mock = new Mock<IMasterData<XMLConfiguration>>();            
        //    mock.Setup(x => x.GetList()).Throws(new System.Exception());
        //    var controller = new SupplierConfigurationController(mock.Object, iConfiguration.Object);
        //    var result = controller.Create(supplier).Result;
        //    Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
        //}

        #endregion OldCode

        [Test]

        public void TestSupplierConfigurationControllerUpdateModelIdLessThanZeroOrZeroReturnsBadResultObjectFail()
        {
            XMLConfiguration xmlConfiguration = new XMLConfiguration
            {
                AdvanceBookingDays = 2,
                CurrencyId = 1,
                IsCitySupported = true,
                MaxChildAge = 18,
                MaxHotelCodesInSearch = 1,
                MaxInfantge = 2,
                SupplierId = 2,
                MinChildAge = 3,
                MinInfantAge = 1,
                IsDeleted = false
            };

            xmlConfigurationMasterMock.Setup(x => x.UpdateEntity(xmlConfiguration)).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

            var result = supplierConfigurationControllerMock.Update(xmlConfiguration).Result;
            Assert.That(result is BadRequestObjectResult);
        }

    }
}
