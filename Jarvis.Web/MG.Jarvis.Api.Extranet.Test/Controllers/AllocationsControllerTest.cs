using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Controllers
{
    [TestFixture]
    public class AllocationsControllerTest
    {
        #region Private Variables
        private AllocationsController mockAllocationsController;
        private Mock<IAllocations> mockALlocationsRepository;
        #endregion
        #region Settings
        public AllocationsControllerTest()
        {
            mockALlocationsRepository = new Mock<IAllocations>();
            mockAllocationsController = new AllocationsController(mockALlocationsRepository.Object);
        }
        #endregion Settings
        #region GetDates

        #region Negative Test Cases

        [Test]

        public async Task TestGetDates_Exception_InternalServerError()
        {
            var request = new DateViewModel()
            {
                EndDate =DateTime.Now.AddDays(7),
                StartDate = DateTime.Now
            };
            mockALlocationsRepository.Setup(a => a.GetDates(It.IsAny<DateViewModel>())).Returns(Task.FromResult(new BaseResult<List<Calendar>>
            { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            var actionResult = await mockAllocationsController.GetDates(request);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetDates_EmptyResult_NoContentResponse()
        {
            var request = new DateViewModel()
            {
                EndDate = DateTime.Now.AddDays(7),
                StartDate = DateTime.Now
            };
            mockALlocationsRepository.Setup(a => a.GetDates(It.IsAny<DateViewModel>())).Returns(Task.FromResult(new BaseResult<List<Calendar>>
            ()
           ));
            var actionResult = await mockAllocationsController.GetDates(request);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.NoContentResult)actionResult).StatusCode, 204);

        }
        [Test]
        public async Task TestGetDates_InvalidInput_BadRequest()
        {
            var request = new DateViewModel()
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(7)
            };
            mockALlocationsRepository.Setup(a => a.GetDates(It.IsAny<DateViewModel>())).Returns(Task.FromResult(new BaseResult<List<Calendar>>
            ()
            {
                IsError = true,
                Message = Core.Model.Helper.Constants.ErrorMessage.EmptyModel
            }));
            var actionResult = await mockAllocationsController.GetDates(request);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 400);
        }
        [Test]
        public async Task TestGetDates_InvalidInput_BadRequest1()
        {
            DateViewModel request = null;

            mockALlocationsRepository.Setup(a => a.GetDates(It.IsAny<DateViewModel>())).Returns(Task.FromResult(new BaseResult<List<Calendar>>
            ()));
            var actionResult = await mockAllocationsController.GetDates(request);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 400);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetDates_Success_OkResponse()
        {
            var request = new DateViewModel()
            {
                EndDate = DateTime.Now.AddDays(7),
                StartDate = DateTime.Now
            };
            mockALlocationsRepository.Setup(a => a.GetDates(It.IsAny<DateViewModel>())).Returns(Task.FromResult(new BaseResult<List<Calendar>>
            ()
            { Result = new List<Calendar>() { new Calendar() { DateKey = 20180101,EnglishMonthName="January", EnglishDayNameOfWeek = "Saturday" } } }));
            var actionResult = await mockAllocationsController.GetDates(request);
            BaseResult<List<DateListViewModel>> response = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<DateListViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(response.Result.Count > 0);
            Assert.IsNotNull(response);
            Assert.IsTrue(!response.IsError);
            Assert.IsTrue(response.Result != null);
        }
        #endregion Postive Test Cases

        #endregion GetDates
    }
}
