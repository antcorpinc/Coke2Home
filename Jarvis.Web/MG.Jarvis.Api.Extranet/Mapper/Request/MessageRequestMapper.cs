using AutoMapper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Hotel;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class MessageRequestMapper
    {
        /// <summary>
        /// Maps view model of message to message model
        /// </summary>
        /// <param name="hotelMessageViewModel"></param>
        /// <param name="messageDatabase"></param>
        /// <param name="userName"></param>
        /// <returns>Message</returns>
        public static Message AutoMapperMessage(HotelMessageViewModel hotelMessageViewModel, Message messageDatabase, string userName)
        {
            var messageMapped = AutoMapper.Mapper.Map<Message>(hotelMessageViewModel);
            ResolveRemainingParamters(messageMapped, messageDatabase, userName);
            return messageMapped;
        }
        /// <summary>
        /// Resolve remaining parameters
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        public static void ResolveRemainingParamters(Message destination, Message source, string userName)
        {

            destination.CreatedBy = source.CreatedBy;
            destination.UpdatedBy = userName;
            destination.IsDeleted = source.IsDeleted;
        }
    }

    public class MessageIdResolver : IValueResolver<HotelMessageViewModel, Message, int>
    {
        public int Resolve(HotelMessageViewModel source, Message destination, int destMember, ResolutionContext context)
        {
            return source.MessageId;
        }
    }
}

