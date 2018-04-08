using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IXMLServices
    {
        Task<BaseResult<List<HotelView>>> GetAllHotelsInfo(string HotelCode);
    }
}
