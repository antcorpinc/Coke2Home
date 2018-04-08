using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class MessageController : BaseController
    {

        IMessage iMessage;
        public MessageController(IMessage iMessage)
        {
            this.iMessage = iMessage;
        }
        /// <summary>
        /// Get the list of Message Type
        /// </summary>
        /// <returns> Task<IActionResult></returns>
        public async Task<IActionResult> GetMessageType()
        {
            BaseResult<List<MessageTypeViewModel>> messageTypeViewModelResult = new BaseResult<List<MessageTypeViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<MessageTypeViewModel>>(Constants.CacheKeys.MessageTypeList)
            };

            if (messageTypeViewModelResult.Result == null || messageTypeViewModelResult.Result.Count == 0)
            {
                var messageTypeResult = await iMessage.GetMessageType().ConfigureAwait(false);

                if (messageTypeResult.IsError && messageTypeResult.ExceptionMessage != null)
                {
                    return StatusCode(500, messageTypeResult);
                }
                else if (messageTypeResult.Result == null || messageTypeResult.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var result = MessageResponseMapper.MapMessageType(messageTypeResult);//maps to MessageTypeViewModel
                    RedisCacheHelper.Instance.Set<List<MessageTypeViewModel>>(Constants.CacheKeys.MessageTypeList, result.Result);
                    return Ok(result);
                }
            }
            return Ok(messageTypeViewModelResult); //200
        }
        /// <summary>
        /// Get the list of messages of  particular hotel
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetMessagesByHotelId([FromBody]int hotelId)
        {
            if (hotelId <= default(int))
            {
                return new BadRequestResult();
            }
            BaseResult<List<Message>> messagesResult = new BaseResult<List<Message>>();
            var messageTypeResult = await iMessage.GetMessageType().ConfigureAwait(false);
            messagesResult = await iMessage.GetMessagesByHotelId(hotelId).ConfigureAwait(false);
            if (messagesResult.IsError && messagesResult.ExceptionMessage != null || messageTypeResult.IsError && messageTypeResult.ExceptionMessage != null)
            {
                return StatusCode(500, messagesResult);
            }
            else if (messagesResult.Result == null || messagesResult.Result.Count == 0 || messagesResult.Result == null || messagesResult.Result.Count == 0)
            {
                return NoContent(); //204
            }
            var result = MessageResponseMapper.MapMessagesByHotelId(messagesResult, messageTypeResult); //maps to GetMessagesViewModel
            return Ok(result);
        }
        /// <summary>
        /// Creates new message or edits the message
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Task<IActionResult></returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateMessage([FromBody]HotelMessageViewModel request)
        {
            BaseResult<Message> createMessageResponse = new BaseResult<Message>();
            BaseResult<bool> validateResponse = new BaseResult<bool>();
            validateResponse = ValidateMessageRequest(request);
            if (validateResponse == null || !validateResponse.Result && validateResponse.IsError && validateResponse.Message != null)
            {
                return BadRequest(validateResponse);
            }
            if (!validateResponse.Result)
            {
                createMessageResponse = await iMessage.SaveAndUpdateMessage(request, base.LoggedInUserName);
            }
            if (createMessageResponse.IsError || createMessageResponse.ExceptionMessage != null || createMessageResponse.Result.Id == 0)
            {
                return StatusCode(500, createMessageResponse);
            }
            else if (createMessageResponse.Message != null)
            {
                return BadRequest(createMessageResponse);
            }
            return Ok(createMessageResponse); //200
        }
        /// <summary>
        ///Get the details of particular message
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns> Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> GetMessagesByMessageId([FromBody]int messageId)
        {
            if (messageId <= default(int))
            {
                return new BadRequestResult();
            }
            BaseResult<HotelMessageViewModel> messageResult = new BaseResult<HotelMessageViewModel>();
            messageResult = await iMessage.GetMessagesByMessageId(messageId).ConfigureAwait(false);

            if (messageResult.IsError && messageResult.ExceptionMessage != null)
            {
                return StatusCode(500, messageResult);
            }
            else if (messageResult.Message != null)
            {
                return BadRequest(messageResult);
            }
            return Ok(messageResult);
        }
        /// <summary>
        ///Get the details of particular message
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns> Task<IActionResult></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteMessageByMessageId([FromBody]int messageId)
        {
            if (messageId <= default(int))
            {
                return new BadRequestResult();
            }
            string userName = base.LoggedInUserName;
            BaseResult<bool> messageResult = new BaseResult<bool>();
            messageResult = await iMessage.DeleteMessageByMessageId(messageId, userName).ConfigureAwait(false);
            if (messageResult.Message != null)
            {
                return BadRequest(messageResult);
            }
            if (messageResult.IsError || messageResult.ExceptionMessage != null || messageResult.Result == default(bool))
            {
                return StatusCode(500, messageResult);
            }
            return Ok(messageResult);
        }

        /// <summary>
        /// Validates the request for creating messgae
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private BaseResult<bool> ValidateMessageRequest(HotelMessageViewModel request)
        {
            BaseResult<bool> validateMessageRequest = new BaseResult<bool>() { IsError = false };
            if ((request.EndDate.Date < request.StartDate.Date || request.StartDate.Date < DateTime.Now.Date || request.EndDate.Date < DateTime.Now.Date) && request.ObjectState == ObjectState.Added)
            {
                validateMessageRequest.IsError = true;
                validateMessageRequest.ErrorCode = (int)coreHelper.Constants.ErrorCodes.StartDateEndDateViolation;
                validateMessageRequest.Message = string.Format(coreHelper.Constants.ErrorMessage.StartDateEndDateViolation);
                return validateMessageRequest;
            }

            return validateMessageRequest;
        }

    }
}