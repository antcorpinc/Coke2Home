using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IMessage
    {
        Task<BaseResult<List<MessageType>>> GetMessageType();
        Task<BaseResult<List<Message>>> GetMessagesByHotelId(int hotelId);
        Task<BaseResult<Message>> SaveAndUpdateMessage(HotelMessageViewModel request, string userName);
        Task<BaseResult<HotelMessageViewModel>> GetMessagesByMessageId(int messageId);
        Task<BaseResult<bool>> DeleteMessageByMessageId(int messageId,string userName);
    }
}
