using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    internal class MessageRepositoryTest
    {
        private IMessage messageRepository;
        private Mock<IConnection<Message>> iMessageLibrary;
        private Mock<IConnection<MessageType>> iMessageTypeLibrary;
        public MessageRepositoryTest()
        {
            this.iMessageLibrary = new Mock<IConnection<Message>>();
            this.iMessageTypeLibrary = new Mock<IConnection<MessageType>>();
            this.messageRepository = new MessageRepository(iMessageTypeLibrary.Object, iMessageLibrary.Object);
        }


        [Test]
        public void TestGetMessageType_Success_ListOfMessageType()
        {
            //Arrange
            int id = 1;
            var messageType = new MessageType() { Id = id, IsActive=true,IsDeleted=false,Name="abc"};
            var baseResult = new BaseResult<List<MessageType>>() { Result = new List<MessageType>() { messageType } };
            var pred = new Func<MessageType, bool>(x => x.IsActive && !x.IsDeleted);
            iMessageTypeLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<MessageType, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult ));
            //Act
            var messageTypeList = messageRepository.GetMessageType();
            //Assert
            Assert.IsTrue(messageTypeList != null);
            Assert.IsTrue(messageTypeList.Result is BaseResult<List<MessageType>>);
            Assert.IsTrue(messageTypeList.Result.Result.Any(x => x.Id == id));
        }
        [Test]
        public void TestGetMessageType_Failed_Error()
        {
            //Arrange
            var baseResult = new BaseResult<List<MessageType>>() { IsError=true,ExceptionMessage=Helper.Common.GetMockException() };
            var pred = new Func<MessageType, bool>(x => x.IsActive && !x.IsDeleted);
            iMessageTypeLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<MessageType, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var messageTypeList = messageRepository.GetMessageType();
            //Assert
            iMessageLibrary.Verify();
            Assert.IsTrue(messageTypeList.Result.IsError);
            Assert.IsTrue(messageTypeList.Result.ExceptionMessage != null);
        }
        [Test]
        public void TestGetMessageByHotelId_Success_ListOfMessageType()
        {
            //Arrange
            int id = 1;
            var message = new Message() { Id = id, IsActive = true, IsDeleted = false, HotelId =id };
            var baseResult = new BaseResult<List<Message>>() { Result = new List<Message>() {message } };
            var pred = new Func<Message, bool>(x => x.HotelId == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var messageList = messageRepository.GetMessagesByHotelId(id);
            //Assert
            iMessageLibrary.Verify();
            Assert.IsTrue(messageList != null);
            Assert.IsTrue(messageList.Result is BaseResult<List<Message>>);
            Assert.IsTrue(messageList.Result.Result.Any(x => x.Id == id));
        }
        [Test]
        public void TestGetMessageByHotelId_Failed_Error()
        {
            //Arrange
            int id = 1;
            var baseResult = new BaseResult<List<Message>>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() };
            var pred = new Func<Message, bool>(x => x.HotelId == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var messageList = messageRepository.GetMessagesByHotelId(id);
            //Assert
            iMessageLibrary.Verify();
            Assert.IsTrue(messageList.Result.IsError);
            Assert.IsTrue(messageList.Result.ExceptionMessage != null);
        }
        [Test]
        public void TestGetMessagesByMessageId_Failed_Error()
        {
            //Arrange
            int id = 1;
            var baseResult = new BaseResult<List<Message>>() { IsError = true, ExceptionMessage = Helper.Common.GetMockException() };
            var pred = new Func<Message, bool>(x => x.Id == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var message = messageRepository.GetMessagesByMessageId(id);
            //Assert
            iMessageLibrary.Verify();
            Assert.IsTrue(message.Result.IsError);
            Assert.IsTrue(message.Result.ExceptionMessage != null);
        }
        [Test]
        public void TestGetMessagesByMessageId_Success_Message()
        {
            //Arrange
            int id = 1;
            var message = new Message() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Message>>() { Result = new List<Message>() { message } };
            var pred = new Func<Message, bool>(x => x.Id == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            //Act
            var messageList = messageRepository.GetMessagesByMessageId(id);
            //Assert
            iMessageLibrary.Verify();
            Assert.IsTrue(messageList != null);
            Assert.IsTrue(messageList.Result is BaseResult<HotelMessageViewModel>);
            Assert.IsTrue(messageList.Result.Result.MessageId==id);
        }
        [Test]
        public void TestSaveAndUpdateMessage_SaveMessage_Success()
        {
            //Arrange
            var id = 1;
            var userName = "MGIT";
            var hotelMessages = new HotelMessageViewModel()
            {
                MessageId = 0,
                HotelId = id,
                MessageTitle = "Title1",
                MessageTypeId = id,
                MessageDescription = "sajdk",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IsActive = true,
                ObjectState = Extranet.Helper.ObjectState.Added
            };
            iMessageLibrary.Setup(a => a.InsertEntity(It.IsAny<Message>())).Returns(Task.FromResult(new BaseResult<long>() { Result=id})).Verifiable();
            //Act
            var result = messageRepository.SaveAndUpdateMessage(hotelMessages,userName);
            //Assert
            iMessageLibrary.Verify();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result.Result.Id == id);
        }
        [Test]
        public void TestSaveAndUpdateMessage_Failed_Error()
        {
            //Arrange
            var id = 1;
            var userName = "MGIT";
            var hotelMessages = new HotelMessageViewModel()
            {
                MessageId = 0,
                HotelId = id,
                MessageTitle = "Title1",
                MessageTypeId = id,
                MessageDescription = "sajdk",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IsActive = true,
                ObjectState = Extranet.Helper.ObjectState.Added
            };
            iMessageLibrary.Setup(a => a.InsertEntity(It.IsAny<Message>())).Returns(Task.FromResult(new BaseResult<long>()
            {
                IsError = true,
                ExceptionMessage = Helper.Common.GetMockException()
            })).Verifiable();
            //Act
            var result = messageRepository.SaveAndUpdateMessage(hotelMessages, userName);
            //Assert
            iMessageLibrary.Verify();
            Assert.IsTrue(result.Result.IsError);
            Assert.IsTrue(result.Result.ExceptionMessage != null);          
        }
        [Test]
        public void TestDeleteMessageByMessageId_Success_True()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var message = new Message() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Message>>() { Result = new List<Message>() { message } };
            var pred = new Func<Message, bool>(x => x.HotelId == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iMessageLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Message>())).Returns(Task.FromResult(new BaseResult<bool> { Result = true })).Verifiable();
            //Act
            var result = messageRepository.DeleteMessageByMessageId(id, userName);
            //Assert 
            iMessageLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.Result == true);
        }
        [Test]
        public void TestDeleteMessageByMessageId_Failed_False()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var message = new Message() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Message>>() { Result = new List<Message>() { message } };
            var pred = new Func<Message, bool>(x => x.HotelId == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iMessageLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Message>())).Returns(Task.FromResult(new BaseResult<bool> { Result = false })).Verifiable();
            //Act
            var result = messageRepository.DeleteMessageByMessageId(id, userName);
            //Assert        
            iMessageLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.Result == false);
        }
        [Test]
        public void TestDeleteMessageByMessageId_Failed_Error()
        {
            //Arrange
            int id = 1;
            string userName = "MGIT";
            var message = new Message() { Id = id, IsActive = true, IsDeleted = false, HotelId = id };
            var baseResult = new BaseResult<List<Message>>() { Result = new List<Message>() { message } };
            var pred = new Func<Message, bool>(x => x.HotelId == id && x.IsDeleted == false);
            iMessageLibrary.Setup(a => a.GetListByPredicate(It.Is<Func<Message, bool>>(x => x.GetType() == pred.GetType()))).Returns(Task.FromResult(baseResult)).Verifiable();
            iMessageLibrary.Setup(a => a.UpdateEntityByDapper(It.IsAny<Message>())).Returns(Task.FromResult(new BaseResult<bool> { IsError = true, ExceptionMessage = Helper.Common.GetMockException() })).Verifiable();
            //Act
            var result = messageRepository.DeleteMessageByMessageId(id, userName);
            //Assert        
            iMessageLibrary.Verify();
            Assert.IsTrue(result.Result is BaseResult<bool>);
            Assert.IsTrue(result.Result.IsError == true);
            Assert.IsTrue(result.Result.ExceptionMessage != null);
        }

    }
}
