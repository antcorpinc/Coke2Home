using MG.Jarvis.Api.Extranet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class XMLServicesController : Controller
    {
        private IXMLServices iXMLServices;
        public XMLServicesController(IXMLServices iXMLServices)
        {
            this.iXMLServices = iXMLServices;
        }

        [HttpPost]
        public async Task<IActionResult> GetAllHotelsInfo([FromBody] string HotelCode)
        {
            var hotelsData = await iXMLServices.GetAllHotelsInfo(HotelCode).ConfigureAwait(false);
            if (hotelsData.IsError && hotelsData.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (hotelsData.Result == null || !hotelsData.Result.Any())
            {
                return NoContent(); //204
            }

            return Ok(hotelsData);
        }
    }
}