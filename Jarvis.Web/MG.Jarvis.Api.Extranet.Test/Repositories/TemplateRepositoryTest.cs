using System;
using System.Collections.Generic;
using System.Text;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Core.Model.Common;
using Dapper;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class TemplateRepositoryTest
    {
        private Mock<IConnection<HotelField>> iHotelFieldLibrary;
        private Mock<IConnection<RoomField>> iRoomFieldLibrary;
        private Mock<IConnection<ContractTemplate>> iContractTemplateLibrary;
        private Mock<IConnection<TemplateHotelField>> iTemplateHotelFieldLibrary;
        private Mock<IConnection<TemplateRoomField>> iTemplateRoomFieldLibrary;
        private Mock<IConnection<TemplateClauseLibrary>> iTemplateCaluseLibrary;
        private Mock<IConnection<TemplateClauseLibraryRelation>> iTemplateClauseLibraryRelation;
        private Mock<IConnection<Field>> iTemplate;
        private Mock<IConfiguration> iconfiguration;
        private ITemplate templateRepository;

        public TemplateRepositoryTest()
        {
            iHotelFieldLibrary = new Mock<IConnection<HotelField>>();
            iRoomFieldLibrary = new Mock<IConnection<RoomField>>();
            iContractTemplateLibrary = new Mock<IConnection<ContractTemplate>>();
            iTemplateHotelFieldLibrary = new Mock<IConnection<TemplateHotelField>>();
            iTemplateRoomFieldLibrary = new Mock<IConnection<TemplateRoomField>>();
            iTemplateCaluseLibrary = new Mock<IConnection<TemplateClauseLibrary>>();
            iTemplateClauseLibraryRelation = new Mock<IConnection<TemplateClauseLibraryRelation>>();
            iTemplate = new Mock<IConnection<Field>>();
            iconfiguration = new Mock<IConfiguration>();
            templateRepository = new TemplateRepository(
                                                        iTemplateCaluseLibrary.Object, iTemplateClauseLibraryRelation.Object,
                                                        iTemplate.Object,iContractTemplateLibrary.Object,
                                                        iHotelFieldLibrary.Object, iRoomFieldLibrary.Object,
                                                        iTemplateHotelFieldLibrary.Object,
                                                        iTemplateRoomFieldLibrary.Object,
                                                        iconfiguration.Object
                                                        );

        }
        [Test]
        public async Task Test_GetContractTemplates_sucess()
        {
            //Arrange
            var template = new ContractTemplate()
            {
                Id = 1,
                IsActive = true,
                Name = "T1",
                IsDeleted = false
            };
            var baseResult = new BaseResult<List<ContractTemplate>>() { Result = new List<ContractTemplate>() { template } };
            var pred = new Func<ContractTemplate, bool>(x => x.IsActive && !x.IsDeleted);
            iContractTemplateLibrary.Setup
                (
                    x => x.GetListByPredicate(It.Is<Func<ContractTemplate, bool>>(y => y.GetType() == pred.GetType()))
                )
                .Returns(Task.FromResult(baseResult));
            //Act
            var result = templateRepository.GetContractTemplates();
            //Assert
            Assert.IsTrue(result.Result is BaseResult<List<ContractTemplate>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == template.Id));
        }
        [Test]
        public async Task Test_GetRoomFields_sucess()
        {
            //Arrange
            var roomField = new RoomField()
            {
                Name = "F1",
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                Code = "cd100",
                FacilityGroupId = 1,
                FacilityId = 1,
                FacilityTypeId = 1,
                IconPath = "sym100",
            };
            var baseResult = new BaseResult<List<RoomField>>() { Result = new List<RoomField>() { roomField } };
            var pred = new Func<RoomField, bool>(x => x.IsActive && !x.IsDeleted);
            iRoomFieldLibrary.Setup
                (
                    x => x.GetListByPredicate(It.Is<Func<RoomField, bool>>(y => y.GetType() == pred.GetType()))
                )
                .Returns(Task.FromResult(baseResult));
            //Act
            var result = templateRepository.GetRoomFields();
            //Assert
            Assert.IsTrue(result.Result is BaseResult<List<RoomField>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == roomField.Id));
        }
        [Test]
        public async Task Test_GetHotelFields_sucess()
        {
            //Arrange
            var hotelField = new HotelField()
            {
                Name = "F1",
                Id = 1,
                IsActive = true,
                IsDeleted = false,
                Code = "cd100",
                FacilityGroupId = 1,
                FacilityId = 1,
                FacilityTypeId = 1,
                IconPath = "sym100",
            };
            var baseResult = new BaseResult<List<HotelField>>() { Result = new List<HotelField>() { hotelField } };
            var pred = new Func<HotelField, bool>(x => x.IsActive && !x.IsDeleted);
            iHotelFieldLibrary.Setup
                (
                    x => x.GetListByPredicate(It.Is<Func<HotelField, bool>>(y => y.GetType() == pred.GetType()))
                )
                .Returns(Task.FromResult(baseResult));
            //Act
            var result = templateRepository.GetHotelFields();
            //Assert
            Assert.IsTrue(result.Result is BaseResult<List<HotelField>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == hotelField.Id));
        }

        [Test]
        public async Task Test_GetPublishedTemplatesForContractCreation_sucess()
        {
            //Arrange
            var template = new ContractTemplate()
            {
                Id = 1,
                IsActive = true,
                Name = "T1",
                IsDeleted = false,
                IsPublished = true
            };
            var baseResult = new BaseResult<List<ContractTemplate>>() { Result = new List<ContractTemplate>() { template } };
            var pred = new Func<ContractTemplate, bool>(x => x.IsActive && !x.IsDeleted && x.IsPublished);
            iContractTemplateLibrary.Setup
                (
                    x => x.GetListByPredicate(It.Is<Func<ContractTemplate, bool>>(y => y.GetType() == pred.GetType()))
                )
                .Returns(Task.FromResult(baseResult));
            //Act
            var result = templateRepository.GetPublishedTemplatesForContract();
            //Assert
            Assert.IsTrue(result.Result is BaseResult<List<ContractTemplate>>);
            Assert.IsTrue(result.Result.Result.Any(x => x.Id == template.Id));
        }

        #region GetCountOfFacilitiesForSelectedTemplate

        [Test]

        public async Task TestGetCountOfFacilitiesForSelectedTemplate_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            iTemplateHotelFieldLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<List<TemplateHotelField>>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            //Act
            var result = await templateRepository.GetCountOfFacilitiesForSelectedTemplate(id, 1);
            //Assert
            iTemplateHotelFieldLibrary.Verify();
            Assert.IsTrue(result.IsError);
            Assert.IsTrue(result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestGetCountOfFacilitiesForSelectedTemplate_Success_ReturnsCount()
        {
            //Arrange
            int id = 1;
            iTemplateHotelFieldLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<List<TemplateHotelField>>() { Result = new List<TemplateHotelField>() { new TemplateHotelField() { FacilityGroupId = 2, IsSelected = true, TemplateId = 1 } } }));
            //Act
            var result = await templateRepository.GetCountOfFacilitiesForSelectedTemplate(id, 1);
            //Assert
            iTemplateHotelFieldLibrary.Verify();
            Assert.IsTrue(result.Result == 1);

        }
        #endregion
        #region GetCountOfAmenitiesForSelectedTemplate
        [Test]
        public async Task TestGetCountOfAmenitiesForSelectedTemplate_Exception_InternalServerError()
        {
            //Arrange
            int id = 1;
            iTemplateRoomFieldLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<List<TemplateRoomField>>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            //Act
            var result = await templateRepository.GetCountOfAmenitiesForSelectedTemplate(id, 1);
            //Assert
            iTemplateHotelFieldLibrary.Verify();
            Assert.IsTrue(result.IsError);
            Assert.IsTrue(result.ExceptionMessage != null);
        }

        [Test]
        public async Task TestGetCountOfAmenitiesForSelectedTemplate_Success_ReturnsCount()
        {
            //Arrange
            int id = 1;
            iTemplateRoomFieldLibrary.Setup(a => a.ExecuteStoredProcedure(It.IsAny<string>(), It.IsAny<DynamicParameters>())).Returns(Task.FromResult(new BaseResult<List<TemplateRoomField>>() { Result = new List<TemplateRoomField>() { new TemplateRoomField() { FacilityGroupId = 2, IsSelected = true, TemplateId = 1 } } }));
            //Act
            var result = await templateRepository.GetCountOfAmenitiesForSelectedTemplate(id, 1);
            //Assert
            iTemplateHotelFieldLibrary.Verify();
            Assert.IsTrue(result.Result == 1);

        }
        #endregion

    }
}
