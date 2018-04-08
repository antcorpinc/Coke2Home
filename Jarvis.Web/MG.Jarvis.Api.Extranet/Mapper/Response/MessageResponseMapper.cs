using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class MessageResponseMapper
    {
        /// <summary>
        /// Maps Message type to Message type View Model
        /// </summary>
        /// <param name="messageTypeList"></param>
        /// <returns>BaseResult<List<MessageTypeViewModel>></returns>
        public static BaseResult<List<MessageTypeViewModel>> MapMessageType(BaseResult<List<MessageType>> messageTypeList)
        {
            BaseResult<List<MessageTypeViewModel>> responseModelList = new BaseResult<List<MessageTypeViewModel>>();
            List<MessageTypeViewModel> modelList = new List<MessageTypeViewModel>();
            foreach (var item in messageTypeList.Result)
            {
                MessageTypeViewModel messageModel = new MessageTypeViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                };
                modelList.Add(messageModel);
            }
            responseModelList.Result = modelList;
            return responseModelList;
        }

        /// <summary>
        /// Maps messages by Hotel Id
        /// </summary>
        /// <param name="messageList"></param>
        /// <param name="messageTypeList"></param>
        /// <returns>BaseResult<List<MessagesViewModel>></returns>
        public static BaseResult<List<MessagesViewModel>> MapMessagesByHotelId(BaseResult<List<Message>> messageList, BaseResult<List<MessageType>> messageTypeList)
        {
            BaseResult<List<MessagesViewModel>> responseModelList = new BaseResult<List<MessagesViewModel>>();
            List<MessagesViewModel> modelList = new List<MessagesViewModel>();
            foreach (var item in messageList.Result)
            {
                string messageType = null;
                if (messageTypeList.Result.Where(x => x.Id == item.MessageTypeId).Any())
                {
                    messageType = messageTypeList.Result.Find(x => x.Id == item.MessageTypeId).Name;
                }
                MessagesViewModel messageModel = new MessagesViewModel
                {
                    MessageId = item.Id,
                    MessageTitle = item.MessageTitle,
                    MessageTypeName = messageType,
                    MessageDescription = item.MessageDescription,
                    LastModifiedBy = item.UpdatedBy,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    IsActive = item.IsActive
                };
                modelList.Add(messageModel);
            }
            responseModelList.Result = modelList;
            return responseModelList;
        }

        #region  MessageType
        /// <summary>
        /// Map model to view model
        /// </summary>
        /// <param name="message"></param>
        /// <returns>BaseResult<HotelMessageViewModel></returns>
        public static BaseResult<HotelMessageViewModel> MapMessage(Message message)
        {
            BaseResult<HotelMessageViewModel> result = new BaseResult<HotelMessageViewModel>();
            HotelMessageViewModel messageModel = new HotelMessageViewModel
            {
                MessageId = message.Id,
                MessageDescription = message.MessageDescription,
                IsActive = message.IsActive,
                EndDate = message.EndDate,
                StartDate = message.StartDate,
                MessageTitle = message.MessageTitle,
                HotelId = message.HotelId,
                MessageTypeId = message.MessageTypeId
            };
            result.Result = messageModel;
            return result;
        }

        #endregion
    }
}
