using MG.Jarvis.Api.Extranet.Controllers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
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
    internal class MessageControllerTest
    {
        #region Private Variables
        private MessageController mockMessageController;
        private Mock<IMessage> mockMessagesRepository;
        #endregion Private Variables

        #region Settings
        public MessageControllerTest()
        {
            mockMessagesRepository = new Moq.Mock<IMessage>();
            mockMessageController = new MessageController(mockMessagesRepository.Object);
        }
        #endregion Settings

        #region GetMessageType

        #region Negative Test Cases
        [Test]
        public async Task TestGetMessageType_Exception_InternalServerError()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MessageTypeList);
            mockMessagesRepository.Setup(a => a.GetMessageType()).Returns(Task.FromResult(new BaseResult<List<MessageType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            IActionResult actionResult = await mockMessageController.GetMessageType();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);

        }

        [Test]
        public async Task TestGetMessageType_EmptyResult_NoContentResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MessageTypeList);
            mockMessagesRepository.Setup(a => a.GetMessageType()).Returns(Task.FromResult(new BaseResult<List<MessageType>>()));
            IActionResult actionResult = await mockMessageController.GetMessageType();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);

        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetMessageType_Success_OkResponse()
        {

            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MessageTypeList);
            mockMessagesRepository.Setup(a => a.GetMessageType()).Returns(Task.FromResult(new BaseResult<List<MessageType>>() { Result = new List<MessageType> { new MessageType { Id = 1, Name = "MessageType1", IsActive = true } } }));
            IActionResult actioResult = await mockMessageController.GetMessageType();
            BaseResult<List<MessageTypeViewModel>> messageTypeList = (actioResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<MessageTypeViewModel>>;
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actioResult).StatusCode, 200);
            Assert.IsTrue(messageTypeList.Result.Count > 0);
            Assert.IsNotNull(messageTypeList);
            Assert.IsTrue(!messageTypeList.IsError);

            Assert.IsTrue(messageTypeList.Result != null);

            Assert.IsNotNull(RedisCacheHelper.Instance.Get<List<MessageTypeViewModel>>(Constants.CacheKeys.MessageTypeList));
            RedisCacheHelper.Instance.Remove(Constants.CacheKeys.MessageTypeList);

        }
        #endregion Postive Test Cases

        #endregion GetMessageType

        #region GetMessagesByHotelId

        #region Negative Test Cases
        [Test]
        public async Task TestGetMessagesByHotelId_Exception_InternalServerError()
        {
            //Arrange
            var id = 1;
            mockMessagesRepository.Setup(a => a.GetMessageType()).Returns(Task.FromResult(new BaseResult<List<MessageType>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            mockMessagesRepository.Setup(a=>a.GetMessagesByHotelId(id)).Returns(Task.FromResult(new BaseResult<List<Message>> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            //Act
            IActionResult actionResult = await mockMessageController.GetMessagesByHotelId(id);
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 500);
        }

        [Test]
        public async Task TestGetMessagesByHotelId_EmptyResult_NoContentResponse()
        {
            //Arrange
            var id = 1;
            mockMessagesRepository.Setup(a => a.GetMessageType()).Returns(Task.FromResult(new BaseResult<List<MessageType>>()));
            mockMessagesRepository.Setup(a=>a.GetMessagesByHotelId(id)).Returns(Task.FromResult(new BaseResult<List<Message>>()));
            //Act
            IActionResult actionResult = await mockMessageController.GetMessagesByHotelId(id);
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.StatusCodeResult)actionResult).StatusCode, 204);
        }

        #endregion Negative Test Casess

        #region Postive Test Cases

        [Test]
        public async Task TestGetMessagesByHotelId_Success_OkResponse()
        {
            //Arrange
            var id = 1;
            mockMessagesRepository.Setup(a => a.GetMessageType()).Returns(Task.FromResult(new BaseResult<List<MessageType>>() { Result = new List<MessageType> { new MessageType { Id = 1, Name = "MessageType1", IsActive = true } } }));
            mockMessagesRepository.Setup(a=>a.GetMessagesByHotelId(id)).Returns(Task.FromResult(new BaseResult<List<Message>>() { Result = new List<Message> { new Message { Id = 1,HotelId=id,MessageTypeId=1,MessageTitle="Title1", IsActive = true } } }));
            //Act
            IActionResult actionResult = await mockMessageController.GetMessagesByHotelId(id);
            BaseResult<List<MessagesViewModel>> messageTypeList = (actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<List<MessagesViewModel>>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode, 200);
            Assert.IsTrue(messageTypeList.Result.Count > 0);
            Assert.IsNotNull(messageTypeList);
            Assert.IsTrue(!messageTypeList.IsError);
            Assert.IsTrue(messageTypeList.Result != null);
        }
        #endregion Postive Test Cases

        #endregion GetMessagesByHotelId

        #region CreateMessage
        #region Negative test Cases
        [Test]
        public async Task TestCreateMessage_Failed_BadRequest()
        {

            //Arrange
            var id = 1;
            var hotelMessage = new HotelMessageViewModel()
            {
                MessageId=0,
                HotelId = id,
                MessageTitle = "Title1",
                MessageTypeId = id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-2),
                IsActive = true,
                ObjectState=ObjectState.Added

            };
            //Act
            var result = await mockMessageController.CreateMessage(hotelMessage);
            //Assert
            mockMessagesRepository.Verify();
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
        }

        [Test]
        public async Task TestMessage_Failed_Error()
        {
            //Arrange
            var id = 1;
            var hotelMessage = new HotelMessageViewModel()
            {
                MessageId = 0,
                HotelId = id,
                MessageTitle = "Title1",
                MessageTypeId = id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IsActive = true,
                ObjectState = ObjectState.Added
            };
            mockMessagesRepository.Setup(a => a.SaveAndUpdateMessage(It.IsAny<HotelMessageViewModel>(),It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Message>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            IActionResult result = await mockMessageController.CreateMessage(hotelMessage);
            //Assert
            mockMessagesRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);

        }
        #endregion
        #region  Positive test cases
        [Test]
        public async Task TestCreateMessage_SuccessOkResponse()
        {
            //Arrange
            var id = 1;
            var hotelMessage = new HotelMessageViewModel()
            {
                MessageId = 0,
                HotelId = id,
                MessageTitle = "Title1",
                MessageTypeId = id,
                MessageDescription = "sajdk",
                StartDate = DateTime.Now,
                EndDate=DateTime.Now,
                IsActive = true,
                ObjectState = ObjectState.Added
            };
            mockMessagesRepository.Setup(a => a.SaveAndUpdateMessage(It.IsAny<HotelMessageViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Message>() { Result=new Message  { Id = id } } ));
            //Act
            IActionResult result = await mockMessageController.CreateMessage(hotelMessage);
            BaseResult<Message> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<Message>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
            Assert.IsTrue(finalResult.Result.Id == id);
        }
        [Test]
        public async Task TestMessageEdit_SuccessOkResponse()
        {
            //Arrange

            var id = 1;
            var hotelMessage = new HotelMessageViewModel()
            {
                MessageId = 1,
                HotelId = id,
                MessageTitle = "Title1",
                MessageTypeId = id,
                MessageDescription = "sajdk",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IsActive = true,
                ObjectState = ObjectState.Modified
            };
            mockMessagesRepository.Setup(a => a.SaveAndUpdateMessage(It.IsAny<HotelMessageViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<Message>() { Result = new Message { Id = id } }));

            //Act
            IActionResult result = await mockMessageController.CreateMessage(hotelMessage);
            BaseResult<Message> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<Message>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
            Assert.IsTrue(finalResult.Result.Id == id);


        }
        #endregion  Positive test cases

        #endregion CreateMessage

        #region DeleteMessageByMessageId

        #region Positive Test Case
        [Test]
        public async Task TestDeleteMessageByMessageId_Success_OkResponse()
        {
            // Arrange
            var id = 1;
            mockMessagesRepository.Setup(a => a.DeleteMessageByMessageId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await mockMessageController.DeleteMessageByMessageId(id);
            BaseResult<bool> finalResult = (result as Microsoft.AspNetCore.Mvc.OkObjectResult).Value as BaseResult<bool>;
            //Assert
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.IsNotNull(finalResult);
            Assert.IsTrue(!finalResult.IsError);
        }
        #endregion
        #region Negative Test Case
        [Test]
        public async Task TestDeleteMessageByMessageId_Failed_BadRequest()
        {
            // Arrange
            var id = -1;
            mockMessagesRepository.Setup(a => a.DeleteMessageByMessageId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true }));
            //Act
            var result = await mockMessageController.DeleteMessageByMessageId(id);
            //Assert
            mockMessagesRepository.Verify();
            Assert.IsTrue(result is BadRequestResult);
            Assert.AreEqual(((BadRequestResult)result).StatusCode, 400);
        }
        [Test]
        public async Task TestDeleteMessageByMessageId_Failed_Error()
        {
            // Arrange
            var id = 1;
            mockMessagesRepository.Setup(a => a.DeleteMessageByMessageId(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(new BaseResult<bool>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() }));
            //Act
            var result = await mockMessageController.DeleteMessageByMessageId(id);
            //Assert
            mockMessagesRepository.Verify();
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 500);
        }
        #endregion
        #endregion

    }
}
