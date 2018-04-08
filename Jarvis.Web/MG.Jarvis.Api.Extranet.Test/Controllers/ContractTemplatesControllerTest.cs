using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExHp = MG.Jarvis.Api.Extranet.Helper;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class ContractTemplatesControllerTest:BaseTestFixture
    {
        private Mock<IMasterData> iMasterData;
        private Mock<IContract> iContract;
        private Mock<IConfiguration> iconfiguration;
        private Mock<ITemplate> iTemplate;
        private ContractTemplatesController contractTemplatesController;
        private Mock<IAmenities> iamenities;

        public ContractTemplatesControllerTest()
        {         
            iContract = new Mock<IContract>();
            iMasterData = new Mock<IMasterData>();
            iconfiguration = new Mock<IConfiguration>();
            iamenities = new Mock<IAmenities>();
            iTemplate = new Mock<ITemplate>();
            contractTemplatesController = new ContractTemplatesController(iMasterData.Object, iContract.Object, iconfiguration.Object, iamenities.Object, iTemplate.Object);
        }
        [Test]
        public async Task TestGetContractTemplates_sucess_OKResponse()
        {
            //Arrange
            var contractTemplate = new ContractTemplate()
            {
                Id = 1,
                IsActive = true,
                Name = "T1",
                IsDeleted = false
            };
            var baseResult = new BaseResult<List<ContractTemplate>>() { Result = new List<ContractTemplate>() { contractTemplate } };
            iTemplate.Setup(x => x.GetContractTemplates()).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetContractTemplates();
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<List<ContractTemplate>>);

        }
        [Test]
        public async Task TestGetContractTemplates_failed_Error()
        {
            //Arrange
            var baseResult = new BaseResult<List<ContractTemplate>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetContractTemplates()).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetContractTemplates();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);

        }
        [Test]
        public async Task TestGetContractTemplates_failed_NoContent()
        {
            //Arrange
            var baseResult = new BaseResult<List<ContractTemplate>>() { Result = new List<ContractTemplate>() };
            iTemplate.Setup(x => x.GetContractTemplates()).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetContractTemplates();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        [Test]
        public async Task TestGetRoomFields_sucess_OKResponse()
        {
            //Arrange
            var field = new TemplateRoomField()
            {
                Name = "F1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = false,
                Code = "cd100",
                //FacilityGroupId = 1,
                //FacilityId = 1,
                //FacilityTypeId = 1,
                IconPath = "sym100",
                IsConfigurable = true
            };
            var fieldsResult = new BaseResult<List<TemplateRoomField>>() { Result = new List<TemplateRoomField>() { field } };
            iTemplate.Setup(x => x.GetTemplateRoomFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(fieldsResult));
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.RoomFieldList);
            //Act
            var result = contractTemplatesController.GetRoomFields();
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<ContractTemplateViewModel>);
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.RoomFieldList);

        }
        [Test]
        public async Task TestGetRoomFields_failed_Error()
        {
            //Arrange
            var baseResult = new BaseResult<List<TemplateRoomField>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetTemplateRoomFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(baseResult));
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.RoomFieldList);
            //Act
            var result = contractTemplatesController.GetRoomFields();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.RoomFieldList);
        }
        [Test]
        public async Task TestGetRoomFields_failed_NoContent()
        {
            //Arrange
            var baseResult = new BaseResult<List<TemplateRoomField>>() { Result = new List<TemplateRoomField>() };
            iTemplate.Setup(x => x.GetTemplateRoomFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(baseResult));
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.RoomFieldList);
            //Act
            var result = contractTemplatesController.GetRoomFields();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.RoomFieldList);

        }
        [Test]
        public async Task TestGetHotelFields_sucess_OKResponse()
        {
            //Arrange
            var hotelField = new TemplateHotelField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = false,
                Code = "cd100",
                //FacilityGroupId = 1,
                //FacilityId = 1,
                //FacilityTypeId = 1,
                IconPath = "sym100",
                IsConfigurable = true
            };
            var fieldsResult = new BaseResult<List<TemplateHotelField>>() { Result = new List<TemplateHotelField>() { hotelField } };
            iTemplate.Setup(x => x.GetTemplateHotelFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(fieldsResult));
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.HotelFieldList);
            //Act
            var result = contractTemplatesController.GetHotelFields();
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<ContractTemplateViewModel>);
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.HotelFieldList);
        }
        [Test]
        public async Task TestGetHotelFields_failed_Error()
        {
            //Arrange
            var baseResult = new BaseResult<List<TemplateHotelField>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetTemplateHotelFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(baseResult));
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.HotelFieldList);
            //Act
            var result = contractTemplatesController.GetHotelFields();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.HotelFieldList);

        }
        [Test]
        public async Task TestGetHotelFields_failed_NoContent()
        {
            //Arrange
            var baseResult = new BaseResult<List<TemplateHotelField>>() { Result = new List<TemplateHotelField>() };
            iTemplate.Setup(x => x.GetTemplateHotelFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(baseResult));
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.HotelFieldList);
            //Act
            var result = contractTemplatesController.GetHotelFields();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);
            RedisCacheHelper.Instance.Remove(ExHp.Constants.CacheKeys.HotelFieldList);

        }

        #region Test cases for Get clause library
        [Test]
        public async Task TestGetClauseLibraryFields_sucess_OKResponse()
        {
            //Arrange
            var clauseLibraryFields = new TemplateClauseLibraryViewModel()
            {
                Name = "TopUpAmount",
                ClauseLibraryId = 1,
                TemplateId = 38,
                Description = "Amount of Top-up deposit should be received by hotel",
                IsSelected = true,
                IsConfigurable = true,
                Order = 1
            };
            var baseResult = new BaseResult<List<TemplateClauseLibraryViewModel>>() { Result = new List<TemplateClauseLibraryViewModel>() { clauseLibraryFields } };
            iTemplate.Setup(x => x.GetClauseLibraryFields(38, 1)).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetClauseLibraryFields(38);
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<List<TemplateClauseLibraryViewModel>>);
        }

        [Test]
        public void TestGetClauseLibraryFields_failed_Error()
        {
            //Arrange
            var baseResult = new BaseResult<List<TemplateClauseLibraryViewModel>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetClauseLibraryFields(38, 1)).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetClauseLibraryFields(38);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetClauseLibraryFields_failed_NoContent()
        {
            //Arrange
            var baseResult = new BaseResult<List<TemplateClauseLibraryViewModel>>() { Result = new List<TemplateClauseLibraryViewModel>() };
            iTemplate.Setup(x => x.GetClauseLibraryFields(1, 1)).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetClauseLibraryFields(1);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        #endregion

        [Test]
        public async Task TestGetHotelFieldsByTemplateId_sucess_OKResponse()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var template = new ContractTemplate()
            {
                Id = id,
                Name = "tem1",
                NameItemId = 1,
                IsActive = true,
                IsDeleted = false
            };
            var hotelField1 = new TemplateHotelField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = true,
                Code = "cd100",
                IconPath = "sym100",
                IsConfigurable = true
            };
            var hotelField2 = new TemplateHotelField()
            {
                Name = "H2",
                FieldId = 2,
                IsActive = true,
                IsDeleted = false,
                Code = "cd200",
                IconPath = "sym200",
                IsConfigurable = true,
            };
            var fieldsResult = new BaseResult<List<TemplateHotelField>>() { Result = new List<TemplateHotelField>() { hotelField1, hotelField2 } };
            iTemplate.Setup(x => x.GetTemplateHotelFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(fieldsResult));
            var templateResult = new BaseResult<ContractTemplate>() { Result = template };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            //Act
            var result = contractTemplatesController.GetHotelFields(request);
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<ContractTemplateViewModel>);
        }
        [Test]
        public async Task TestGetHotelFieldsByTemplateId_failed_Error_1()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var baseResult = new BaseResult<ContractTemplate>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetHotelFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);

        }
        [Test]
        public async Task TestGetHotelFieldsByTemplateId_failed_Error_2()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var template = new ContractTemplate()
            {
                Id = id,
                Name = "tem1",
                NameItemId = 1,
                IsActive = true,
                IsDeleted = false
            };
            var hotelField1 = new TemplateHotelField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = true,
                Code = "cd100",
                IconPath = "sym100",
                IsConfigurable = true
            };
            var hotelField2 = new TemplateHotelField()
            {
                Name = "H2",
                FieldId = 2,
                IsActive = true,
                IsDeleted = false,
                Code = "cd200",
                IconPath = "sym200",
                IsConfigurable = true,
            };
            var templateResult = new BaseResult<ContractTemplate>() { Result = template };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            var baseResult = new BaseResult<List<TemplateHotelField>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetTemplateHotelFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetHotelFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);

        }
        [Test]
        public async Task TestGetHotelFieldsByTemplateId_failed_NoContent_1()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var templateResult = new BaseResult<ContractTemplate>() { Result = null };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            //Act
            var result = contractTemplatesController.GetHotelFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        [Test]
        public async Task TestGetHotelFieldsByTemplateId_failed_NoContent_2()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var template = new ContractTemplate()
            {
                Id = id,
                Name = "tem1",
                NameItemId = 1,
                IsActive = true,
                IsDeleted = false
            };
            var hotelField1 = new TemplateHotelField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = true,
                Code = "cd100",
                IconPath = "sym100",
                IsConfigurable = true
            };
            var hotelField2 = new TemplateHotelField()
            {
                Name = "H2",
                FieldId = 2,
                IsActive = true,
                IsDeleted = false,
                Code = "cd200",
                IconPath = "sym200",
                IsConfigurable = true,
            };
            var templateResult = new BaseResult<ContractTemplate>() { Result = template };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            var fieldsResult = new BaseResult<List<TemplateHotelField>>() { Result = new List<TemplateHotelField>() };
            iTemplate.Setup(x => x.GetTemplateHotelFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(fieldsResult));
            //Act
            var result = contractTemplatesController.GetHotelFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        [Test]
        public async Task TestGetRoomFieldsByTemplateId_sucess_OKResponse()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var template = new ContractTemplate()
            {
                Id = id,
                Name = "tem1",
                NameItemId = 1,
                IsActive = true,
                IsDeleted = false
            };
            var field1 = new TemplateRoomField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = true,
                Code = "cd100",
                IconPath = "sym100",
                IsConfigurable = true
            };
            var field2 = new TemplateRoomField()
            {
                Name = "H2",
                FieldId = 2,
                IsActive = true,
                IsDeleted = false,
                Code = "cd200",
                IconPath = "sym200",
                IsConfigurable = true,
            };
            var fieldsResult = new BaseResult<List<TemplateRoomField>>() { Result = new List<TemplateRoomField>() { field1, field2 } };
            iTemplate.Setup(x => x.GetTemplateRoomFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(fieldsResult));
            var templateResult = new BaseResult<ContractTemplate>() { Result = template };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            //Act
            var result = contractTemplatesController.GetRoomFields(request);
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<ContractTemplateViewModel>);
        }
        [Test]
        public async Task TestGetRoomFieldsByTemplateId_failed_Error_1()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var baseResult = new BaseResult<ContractTemplate>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetRoomFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);

        }
        [Test]
        public async Task TestGetRoomFieldsByTemplateId_failed_Error_2()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var template = new ContractTemplate()
            {
                Id = id,
                Name = "tem1",
                NameItemId = 1,
                IsActive = true,
                IsDeleted = false
            };
            var field1 = new TemplateRoomField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = true,
                Code = "cd100",
                IconPath = "sym100",
                IsConfigurable = true
            };
            var field2 = new TemplateRoomField()
            {
                Name = "H2",
                FieldId = 2,
                IsActive = true,
                IsDeleted = false,
                Code = "cd200",
                IconPath = "sym200",
                IsConfigurable = true,
            };
            var templateResult = new BaseResult<ContractTemplate>() { Result = template };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            var baseResult = new BaseResult<List<TemplateRoomField>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetTemplateRoomFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetRoomFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);

        }
        [Test]
        public async Task TestGetRoomFieldsByTemplateId_failed_NoContent_1()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var templateResult = new BaseResult<ContractTemplate>() { Result = null };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            //Act
            var result = contractTemplatesController.GetRoomFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        [Test]
        public async Task TestGetRoomFieldsByTemplateId_failed_NoContent_2()
        {
            //Arrange
            var id = 1;
            var request = new IntegerEntityViewModel() { Id = id };
            var template = new ContractTemplate()
            {
                Id = id,
                Name = "tem1",
                NameItemId = 1,
                IsActive = true,
                IsDeleted = false
            };
            var field1 = new TemplateRoomField()
            {
                Name = "H1",
                FieldId = 1,
                IsActive = true,
                IsDeleted = true,
                Code = "cd100",
                IconPath = "sym100",
                IsConfigurable = true
            };
            var field2 = new TemplateRoomField()
            {
                Name = "H2",
                FieldId = 2,
                IsActive = true,
                IsDeleted = false,
                Code = "cd200",
                IconPath = "sym200",
                IsConfigurable = true,
            };
            var templateResult = new BaseResult<ContractTemplate>() { Result = template };
            iTemplate.Setup(x => x.GetContractTemplateByID(It.IsAny<int>())).Returns(Task.FromResult(templateResult));
            var fieldsResult = new BaseResult<List<TemplateRoomField>>() { Result = new List<TemplateRoomField>() };
            iTemplate.Setup(x => x.GetTemplateRoomFields(It.IsAny<int>(), It.Is<bool>(y => !y))).Returns(Task.FromResult(fieldsResult));
            //Act
            var result = contractTemplatesController.GetRoomFields(request);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        [Test]
        public async Task TestCreateOrUpdateContractTemplate_update_unchanged()
        {
            //Arrange
            var request = new ContractTemplateViewModel()
            {
                ObjectState = ExHp.ObjectState.Unchanged
            };
            //Act
            var result = await contractTemplatesController.CreateOrUpdateContractTemplate(request).ConfigureAwait(false);
            //Assert
        }
        [Test]
        public async Task TestCreateOrUpdateContractTemplate_update_unchanged_field_Added()
        {
            //Arrange
            var request = new ContractTemplateViewModel()
            {
                ObjectState = ExHp.ObjectState.Unchanged
            };
            request.HotelFields.Add(new HotelFieldViewModel() { ObjectState = ExHp.ObjectState.Added });
            //Act
            var result = await contractTemplatesController.CreateOrUpdateContractTemplate(request).ConfigureAwait(false);
            //Assert
        }

        [Test]
        public async Task TestCreateOrUpdateContractTemplate_create_success()
        {
            //Arrange
            var id = 1;
            var request = new ContractTemplateViewModel()
            {
                ObjectState = ExHp.ObjectState.Added,
                Name = "temp1",
                Id = 0
            };
            request.HotelFields.Add(new HotelFieldViewModel()
            {
                Id = id,
                IsSelected = true,
                ObjectState = ExHp.ObjectState.Added
            });
            request.ClauseLibraryFields.Add(new TemplateClauseLibraryViewModel()
            {
                ClauseLibraryId = id,
                IsSelected = true,
                ObjectState = ExHp.ObjectState.Added
            });
            request.HotelFacilityFields.Add(new HotelFacilityGroupViewModel()
            {
                Id=id,
                IsSelected=true,
                ObjectState=ExHp.ObjectState.Added
            });
            request.RoomFields.Add(new RoomFieldViewModel()
            {
                Id = id,
                IsSelected = true,
                ObjectState = ExHp.ObjectState.Added
            });

            iTemplate.Setup(x => x.CreateContractTemplate(It.IsAny<ContractTemplateViewModel>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new BaseResult<long>() { Result = id }));
            iTemplate.Setup(x => x.InsertContractTemplateHotelProperties(It.IsAny<List<HotelFieldViewModel>>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new BaseResult<long>() { Result = id }));
            //Act
            var result = await contractTemplatesController.CreateOrUpdateContractTemplate(request).ConfigureAwait(false);
            //Assert
        }

        #region Test cases for Get Room Facility
        //[Test]
        //public async Task TestGetRoomFacilityFields_sucess_OKResponse()
        //{
        //    //Arrange
        //    var roomFacilityFields = new RoomFacilityGroupViewModel()
        //    {

        //    };
        //    var baseResult = new BaseResult<List<TemplateClauseLibraryViewModel>>() { Result = new List<TemplateClauseLibraryViewModel>() { clauseLibraryFields } };
        //    iTemplate.Setup(x => x.GetClauseLibraryFields(38, 1)).Returns(Task.FromResult(baseResult));
        //    //Act
        //    var result = contractTemplatesController.GetClauseLibraryFields(38);
        //    //Assert
        //    Assert.IsTrue(result.Result is OkObjectResult);
        //    Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        //    Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<List<TemplateClauseLibraryViewModel>>);
        //}

        [Test]
        public void TestGetRoomFacilityFields_failed_Error()
        {
            //Arrange
            IntegerEntityViewModel vm = new IntegerEntityViewModel
            {
                Id = 1
            };
            var baseResult = new BaseResult<List<TemplateRoomField>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetTemplateRoomFields(1, true)).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetRoomFacilityFields(vm);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetRoomFacilityFields_failed_NoContent()
        {
            //Arrange
            IntegerEntityViewModel vm = new IntegerEntityViewModel
            {
                Id = 1
            };
            var baseResult = new BaseResult<List<TemplateRoomField>>() { Result = new List<TemplateRoomField>() };
            iTemplate.Setup(x => x.GetTemplateRoomFields(1, true)).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetRoomFacilityFields(vm);
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);

        }
        #endregion

        #region Get Published templates
        [Test]
        public async Task TestGetPublishedTemplatesForContractCreation_sucess_OKResponse()
        {
            //Arrange
            var contractTemplate = new ContractTemplate()
            {
                Id = 1,
                IsActive = true,
                Name = "T1",
                IsDeleted = false,
                IsPublished=true
            };
            var baseResult = new BaseResult<List<ContractTemplate>>() { Result = new List<ContractTemplate>() { contractTemplate } };
            iTemplate.Setup(x => x.GetPublishedTemplatesForContract()).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetPublishedTemplatesForContractCreation();
            //Assert
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
            Assert.IsTrue(((OkObjectResult)result.Result).Value is BaseResult<List<ContractTemplate>>);
        }

        [Test]
        public async Task TestGetPublishedTemplatesForContractCreation_failed_Error()
        {
            //Arrange
            var baseResult = new BaseResult<List<ContractTemplate>>() { IsError = true, ExceptionMessage = Common.GetMockException() };
            iTemplate.Setup(x => x.GetPublishedTemplatesForContract()).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetPublishedTemplatesForContractCreation();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        [Test]
        public async Task TestGetPublishedTemplatesForContractCreation_failed_NoContent()
        {
            //Arrange
            var baseResult = new BaseResult<List<ContractTemplate>>() { Result = new List<ContractTemplate>() };
            iTemplate.Setup(x => x.GetPublishedTemplatesForContract()).Returns(Task.FromResult(baseResult));
            //Act
            var result = contractTemplatesController.GetPublishedTemplatesForContractCreation();
            //Assert
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);
        }

        #endregion

        #region GetCountOfFacilitiesAndAmenitiesForSelectedTemplate

        #region Negative Test Cases

        [Test]

        public async Task TestGetCountOfFacilitiesAndAmenitiesForSelectedTemplate_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            iTemplate.Setup(a => a.GetCountOfAmenitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            iTemplate.Setup(a => a.GetCountOfFacilitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            //Act
            IActionResult actionResult = await contractTemplatesController.GetCountOfFacilitiesAndAmenitiesForSelectedTemplate(id);
            //Assert
            iTemplate.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetCountOfFacilitiesAndAmenitiesForSelectedTemplate_Exception_BadRequest()
        {
            int id = -1;
            IActionResult actioResult = await contractTemplatesController.GetCountOfFacilitiesAndAmenitiesForSelectedTemplate(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 400);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetCountOfFacilitiesAndAmenitiesForSelectedTemplate_Success_OkResponse()
        {
            //Arrange
            int id = 1;
            iTemplate.Setup(a => a.GetCountOfFacilitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { Result = id })).Verifiable();
            iTemplate.Setup(a => a.GetCountOfAmenitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { Result = id })).Verifiable();
            //Act
            IActionResult actionResult = await contractTemplatesController.GetCountOfFacilitiesAndAmenitiesForSelectedTemplate(id);
            //Assert
            iTemplate.Verify();
            BaseResult<HotelFacilityRoomAmenity> result = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<HotelFacilityRoomAmenity>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(!result.IsError);
            Assert.IsTrue(result is BaseResult<HotelFacilityRoomAmenity>);
           
        }
        #endregion Postive Test Cases

        #endregion GetCountOfFacilitiesAndAmenitiesForSelectedTemplate

        #region GetCountOfFacilitiesForSelectedTemplate

        #region Negative Test Cases

        [Test]

        public async Task TestGetCountOfFacilitiesForSelectedTemplate_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            iTemplate.Setup(a => a.GetCountOfFacilitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            //Act
            IActionResult actionResult = await contractTemplatesController.GetCountOfFacilitiesForSelectedTemplate(id);
            //Assert
            iTemplate.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetCountOfFacilitiesForSelectedTemplate_Exception_BadRequest()
        {
            int id = -1;
            IActionResult actioResult = await contractTemplatesController.GetCountOfFacilitiesForSelectedTemplate(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 400);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetCountOfFacilitiesForSelectedTemplate_Success_OkResponse()
        {
            //Arrange
            int id = 1;
            iTemplate.Setup(a => a.GetCountOfFacilitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { Result = id })).Verifiable();
            //Act
            IActionResult actionResult = await contractTemplatesController.GetCountOfFacilitiesForSelectedTemplate(id);
            //Assert
            iTemplate.Verify();
            BaseResult<int> result = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<int>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(!result.IsError);
            Assert.IsTrue(result is BaseResult<int>);

        }
        #endregion Postive Test Cases

        #endregion GetCountOfFacilitiesForSelectedTemplate
        #region GetCountOfAmenitiesForSelectedTemplate

        #region Negative Test Cases

        [Test]

        public async Task TestGetCountOfAmenitiesForSelectedTemplate_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            iTemplate.Setup(a => a.GetCountOfAmenitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            //Act
            IActionResult actionResult = await contractTemplatesController.GetCountOfAmenitiesForSelectedTemplate(id);
            //Assert
            iTemplate.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetCountOfAmenitiesForSelectedTemplate_Exception_BadRequest()
        {
            int id = -1;
            IActionResult actioResult = await contractTemplatesController.GetCountOfAmenitiesForSelectedTemplate(id);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 400);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetCountOfAmenitiesForSelectedTemplate_Success_OkResponse()
        {
            //Arrange
            int id = 1;
            iTemplate.Setup(a => a.GetCountOfAmenitiesForSelectedTemplate(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new BaseResult<int>() { Result = id })).Verifiable();
            //Act
            IActionResult actionResult = await contractTemplatesController.GetCountOfAmenitiesForSelectedTemplate(id);
            //Assert
            iTemplate.Verify();
            BaseResult<int> result = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<int>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(!result.IsError);
            Assert.IsTrue(result is BaseResult<int>);

        }
        #endregion Postive Test Cases

        #endregion GetCountOfAmenitiesForSelectedTemplate


    }
}
