using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.Test.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class ContractsControllerTest
    {
        #region private variable
        private ContractsController contractsController;
        private Mock<IContract> contractsRepositoryMock;
        #endregion Private Variables

        #region Settings
        public ContractsControllerTest()
        {
            contractsRepositoryMock = new Mock<IContract>();
            contractsController = new ContractsController(contractsRepositoryMock.Object);
        }
        #endregion Settings

        #region ActivateContract
        [Test]
        public void TestActivateContract_Success_OKResponse()
        {
            //Arrange
            var date = DateTime.Now;
            contractsRepositoryMock.Setup(x => x.ActivateContract(It.IsAny<DateTime>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();
            //Act
            var result = contractsController.ActivateContract(date);
            //Assert
            contractsRepositoryMock.VerifyAll();
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        }

        [Test]
        public void TestActivateContract_InvalidPastDate_BadRequest()
        {
            //Arrange
            var date = DateTime.Now.AddDays(-1);
            //Act
            var result = contractsController.ActivateContract(date);
            //Assert
            Assert.IsTrue(result.Result is BadRequestObjectResult);
        }

        [Test]
        public void TestActivateContract_InvalidFutureDate_BadRequest()
        {
            //Arrange
            var date = DateTime.Now.AddDays(1);
            //Act
            var result = contractsController.ActivateContract(date);
            //Assert
            Assert.IsTrue(result.Result is BadRequestObjectResult);
        }

        [Test]
        public void TestActivateContract_ServiceError_StatusCode500()
        {
            //Arrange
            var date = DateTime.Now;
            contractsRepositoryMock.Setup(x => x.ActivateContract(It.IsAny<DateTime>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = false, IsError = true })).Verifiable();
            //Act
            var result = contractsController.ActivateContract(date);
            //Assert
            contractsRepositoryMock.VerifyAll();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        #endregion ActivateContract

        #region DeActivateContract
        [Test]
        public void TestDeActivateContract_Success_OKResponse()
        {
            //Arrange
            var date = DateTime.Now;
            contractsRepositoryMock.Setup(x => x.DeActivateContract(It.IsAny<DateTime>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true })).Verifiable();
            //Act
            var result = contractsController.DeActivateContract(date);
            //Assert
            contractsRepositoryMock.VerifyAll();
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        }

        [Test]
        public void TestDeActivateContract_InvalidPastDate_BadRequest()
        {
            //Arrange
            var date = DateTime.Now.AddDays(-1);
            //Act
            var result = contractsController.DeActivateContract(date);
            //Assert
            Assert.IsTrue(result.Result is BadRequestObjectResult);
        }

        [Test]
        public void TestDeActivateContract_InvalidFutureDate_BadRequest()
        {
            //Arrange
            var date = DateTime.Now.AddDays(1);
            //Act
            var result = contractsController.DeActivateContract(date);
            //Assert
            Assert.IsTrue(result.Result is BadRequestObjectResult);
        }

        [Test]
        public void TestDeActivateContractt_ServiceError_StatusCode500()
        {
            //Arrange
            var date = DateTime.Now;
            contractsRepositoryMock.Setup(x => x.DeActivateContract(It.IsAny<DateTime>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = false, IsError = true })).Verifiable();
            //Act
            var result = contractsController.DeActivateContract(date);
            //Assert
            contractsRepositoryMock.VerifyAll();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        #endregion DeActivateContract

        #region Expired Contracts
        #region Positive Test Cases
        [Test]
        public async Task TestGetExpiredContract_Success_OkResponse()
        {
            ExpiredContracts request = new ExpiredContracts { ExpiryWarningDays = 15, NotificationDate = DateTime.Now };
            contractsRepositoryMock.Setup(a => a.GetExpiredContract(request)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>()
            {
                Result = new[]
                                    {
                                         new { Title="Home" },
                                         new { Title = "Categories"}
                                    }
            }));
            IActionResult actioResult = await contractsController.GetExpiredContract(request);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 200);
        }


        #endregion Positive Test Cases

        #region Negative Test Cases
        [Test]
        public async Task TestGetExpiredContract_NullRequest_BadRequestResponse()
        {
            ExpiredContracts request = null;
            var mockAction = new Moq.Mock<IContract>();
            IActionResult actioResult = await contractsController.GetExpiredContract(request);
            // Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult.Result).StatusCode, 200);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
        }

        [Test]
        public async Task TestGetExpiredContract_InvalidDateRequest_BadRequestResponse()
        {
            ExpiredContracts request = new ExpiredContracts { NotificationDate = DateTime.MinValue, ExpiryWarningDays = 10 };
            IActionResult actioResult = await contractsController.GetExpiredContract(request);
            // Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult.Result).StatusCode, 200);
            Assert.IsTrue(actioResult is BadRequestObjectResult);
        }

        [Test]
        public async Task TestGetExpiredContract_Exception_InternalServerErrorResponse()
        {
            ExpiredContracts request = new ExpiredContracts { NotificationDate = DateTime.Now, ExpiryWarningDays = 10 };

            contractsRepositoryMock.Setup(a => a.GetExpiredContract(request)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { IsError = true, ExceptionMessage = Common.GetMockException() }));
            IActionResult actioResult = await contractsController.GetExpiredContract(request);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetExpiredContract_EmptyResult_NoContentResponse()
        {
            ExpiredContracts request = new ExpiredContracts { NotificationDate = DateTime.Now, ExpiryWarningDays = 10 };

            contractsRepositoryMock.Setup(a => a.GetExpiredContract(request)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>
            {
                Result = new List<Country>()
            })).Verifiable();
            contractsRepositoryMock.Setup(a => a.GetExpiredContract(request)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>> { Result = null })).Verifiable();
            IActionResult actioResult = await contractsController.GetExpiredContract(request);
            contractsRepositoryMock.VerifyAll();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actioResult).StatusCode, 204);

        }
        #endregion Negative Test Cases
        #endregion Expired Contracts

        #region Get All Contracts
        [Test]
        public void TestGetAllContracts_Success_OKResponse()
        {
            //Arrange
            ContactDetailsViewModel contact = new ContactDetailsViewModel
            {
                ContactPerson = "John Adams",
                ContactNumber = "8541236",
                EmailAddress = "JohnAdams@email.com"
            };

            PromoContractsViewModel promo = new PromoContractsViewModel
            {
                Id = 1015,
                Name = "Main Promo1",
                StartDate = DateTime.Now,
                EndDate=DateTime.Now,
                Status = "ACTIVE"
            };

            var dataRow = new ContractListingViewModel
            {
                Id = 1007,
                Name = "Main Contract",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Status = "ACTIVE",
                HotelName = "View images T24 Residency",
                Location = "Mumbai,India",
                Designation = "Group Sales Manager",
            };
            dataRow.Contacts.Add(contact);
            dataRow.PromoContracts.Add(promo);

            contractsRepositoryMock.Setup(x => x.GetAllContracts()).Returns(Task.FromResult(new BaseResult<List<ContractListingViewModel>>()
            {
                Result = new List<ContractListingViewModel>()
                {
                    dataRow
                }

            })).Verifiable();

            //Act
            var result = contractsController.GetAllContracts();
            //Assert
            contractsRepositoryMock.Verify();
            Assert.IsTrue(result.Result is OkObjectResult);
            Assert.AreEqual(((OkObjectResult)result.Result).StatusCode, 200);
        }

        [Test]
        public void TestGetAllContracts_Failed_Error()
        {
            //Arrange
            contractsRepositoryMock.Setup(x => x.GetAllContracts()).Returns(Task.FromResult(new BaseResult<List<ContractListingViewModel>>()
            {
                IsError = true,
                Message = "error"
            })).Verifiable();

            //Act
            var result = contractsController.GetAllContracts();
            //Assert
            contractsRepositoryMock.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 500);
        }

        [Test]
        public void TestGetAllContracts_Success_NoContent()
        {
            //Arrange
            contractsRepositoryMock.Setup(x => x.GetAllContracts()).Returns(Task.FromResult(new BaseResult<List<ContractListingViewModel>>()
            {
                Result = new List<ContractListingViewModel>() { }
            })).Verifiable();

            //Act
            var result = contractsController.GetAllContracts();
            //Assert
            contractsRepositoryMock.Verify();
            Assert.IsTrue(result.Result is StatusCodeResult);
            Assert.AreEqual(((StatusCodeResult)result.Result).StatusCode, 204);
        }
        #endregion Get All Contracts
    }
}
