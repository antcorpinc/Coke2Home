using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.IO;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class DocumentsController : BaseController
    {
        private IDocument iDocumentLibrary;
        public DocumentsController(IDocument iDocumentLibrary)
        {
            this.iDocumentLibrary = iDocumentLibrary;
        }

        public IActionResult Index()
        {
            return Ok(new { result = "ok" });
        }
        [HttpPost]
        [ValidateModel]
        public async  Task<IActionResult> UploadContract([FromBody] UploadContractViewModel request)
        {
            if (!request.Bytes.Any())
            {
                return StatusCode(500, new BaseResult<object> { IsError = true, Message = "bytes field is required" });
            }
            var uploadContractResult=await iDocumentLibrary.UploadContract(request).ConfigureAwait(false);
            if(uploadContractResult.IsError && uploadContractResult.ExceptionMessage != null)
            {
                return StatusCode(500, uploadContractResult);
            }
            return Ok(uploadContractResult);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult> GetDocumentByPath([FromBody] GetDocumentViewModel request)
        {
            var getDocumentResult = await iDocumentLibrary.GetDocumentByPath(request.path).ConfigureAwait(false);
            if (getDocumentResult.IsError && getDocumentResult.ExceptionMessage != null)
            {
                return StatusCode(500, getDocumentResult);
            }
            using (getDocumentResult.Result)
            {
                //var response = HttpContext.Response;
                //response.StatusCode = StatusCodes.Status200OK;
                //response.Clear();
                //response.Headers.Clear();
                //var conDesp = new ContentDisposition() { DispositionType = "attachemnt", FileName = "test.pdf", Inline = true };
                //response.Headers.Append("Content-Disposition", conDesp.ToString());
                //response.Headers.Append("Content-Lenght", getDocumentResult.Result.Length.ToString());
                //response.ContentType = "application/pdf";
                //getDocumentResult.Result.Position = 0;
                //var streamReader = new StreamReader(getDocumentResult.Result);
                //await response.WriteAsync(streamReader.ReadToEnd(), Encoding.UTF8).ConfigureAwait(false);
                //return response;
                var pathSplits = request.path.Split("\\");
                var fileName = pathSplits.Last();
                return File(getDocumentResult.Result.ToArray(), "application/pdf", fileName);
            }
        }
    }
}