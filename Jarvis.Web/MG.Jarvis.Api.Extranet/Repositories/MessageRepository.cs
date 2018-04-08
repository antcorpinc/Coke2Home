using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class MessageRepository : IMessage
    {
        public IConnection<MessageType> iMessageTypeLibrary;
        public IConnection<Message> iMessageLibrary;
        public MessageRepository(IConnection<MessageType> iMessageTypeLibrary, IConnection<Message> iMessageLibrary)
        {
            this.iMessageTypeLibrary = iMessageTypeLibrary;
            this.iMessageLibrary = iMessageLibrary;
        }
        /// <summary>
        /// Returns list of MessageTypes
        /// </summary>
        /// <returns>Task<BaseResult<List<MessageType>>></returns>
        public async Task<BaseResult<List<MessageType>>> GetMessageType()
        {
            return await iMessageTypeLibrary.GetListByPredicate(x => x.IsActive == true && x.IsDeleted == false);
        }
        /// <summary>
        /// Returns list of Messages
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>Task<BaseResult<List<Message>>></returns>
        public async Task<BaseResult<List<Message>>> GetMessagesByHotelId(int hotelId)
        {

            return await iMessageLibrary.GetListByPredicate(x => x.HotelId == hotelId && x.IsDeleted == false);
        }
        /// <summary>
        /// Creates new message or edits the message
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<long>></returns>
        public async Task<BaseResult<Message>> SaveAndUpdateMessage(HotelMessageViewModel request, string userName)
        {
            BaseResult<Message> result = new BaseResult<Message>();
            result.Result = new Message();
            if (request.ObjectState == ObjectState.Added)
            {
                Message message = new Message()
                {
                    HotelId = (int)request.HotelId,
                    MessageTypeId = (int)request.MessageTypeId,
                    MessageTitle = request.MessageTitle,
                    MessageDescription = request.MessageDescription,
                    IsActive = (bool)request.IsActive,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    CreatedBy = userName,
                    UpdatedBy = userName

                };
                var insertResult = await iMessageLibrary.InsertEntity(message).ConfigureAwait(false);
                if (insertResult.IsError || insertResult.ExceptionMessage != null)
                {
                    result.IsError = true;
                    result.ExceptionMessage = insertResult.ExceptionMessage;
                    return result;
                }
                result.Result.Id = (int)insertResult.Result;
                return result;
            }
            else if (request.ObjectState == ObjectState.Modified)
            {
                var message = iMessageLibrary.GetListByPredicate(x => x.Id == request.MessageId && !x.IsDeleted);
                if (message.Result.Result.Count > 0 && message != null)
                {
                    var updatedMessage = MessageRequestMapper.AutoMapperMessage(request, message.Result.Result[0], userName);
                    var updateResult = await iMessageLibrary.UpdateEntityByDapper(updatedMessage);
                    if (updateResult.IsError || updateResult.ExceptionMessage != null)
                    {
                        result.IsError = true;
                        result.ExceptionMessage = updateResult.ExceptionMessage;
                        return result;
                    }
                    if (updateResult.Result == true)
                    {
                        result.Result.Id = updatedMessage.Id;
                    }
                    return result;
                }
                else
                {
                    result.IsError = true;
                    result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoMessageOfID;
                    result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoMessageOfID, request.MessageId);
                    return result;
                }
            }
            return result;
        }
        /// <summary>
        /// Get the details of particular message
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns> Task<BaseResult<HotelMessageViewModel>></returns>
        public async Task<BaseResult<HotelMessageViewModel>> GetMessagesByMessageId(int messageId)
        {
            BaseResult<HotelMessageViewModel> result = new BaseResult<HotelMessageViewModel>();
            var model = await iMessageLibrary.GetListByPredicate(x => x.Id == messageId && !x.IsDeleted).ConfigureAwait(false);
            if (model.IsError || model.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = model.ExceptionMessage;
                return result;
            }
            if (model == null || model.Result.Count == 0)
            {
                result.IsError = model.IsError;
                result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoMessageOfID;
                result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoMessageOfID, messageId);
                return result;
            }
            result = MessageResponseMapper.MapMessage(model.Result[0]);
            return result;
        }

        /// <summary>
        /// Delete  particular message
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="userName"></param>
        /// <returns> Task<BaseResult<bool>></returns>
        public async Task<BaseResult<bool>> DeleteMessageByMessageId(int messageId, string userName)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            var model = await iMessageLibrary.GetListByPredicate(x => x.Id == messageId && !x.IsDeleted).ConfigureAwait(false);
            if (model.IsError || model.ExceptionMessage != null)
            {
                result.IsError = model.IsError;
                result.ExceptionMessage = model.ExceptionMessage;
                return result;
            }
            if (model.Result.Any())
            {
                model.Result[0].IsDeleted = true;
                model.Result[0].UpdatedBy = userName;
                model.Result[0].UpdatedDate = Common.JakartaOffset(DateTime.Now);
                result = await iMessageLibrary.UpdateEntityByDapper(model.Result[0]).ConfigureAwait(false);
                return result;
            }
            result.IsError = true;
            result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoMessageOfID;
            result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoMessageOfID, messageId);
            return result;

        }
    }
}
