using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class XMLServicesRepository : IXMLServices
    {
        private HotelRepository hotelRepository;
        public XMLServicesRepository(HotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public Task<BaseResult<List<HotelView>>> GetAllHotelsInfo(string HotelCode)
        {
           return this.hotelRepository.GetAllHotelsInfo(HotelCode);
        }
    }
}
