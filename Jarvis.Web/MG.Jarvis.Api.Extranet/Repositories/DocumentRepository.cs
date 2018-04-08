using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using System.IO;
using System.Net.Http;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class DocumentRepository:IDocument
    {
        private IConfiguration iconfiguration;
        public string DocumentStorePath { get; }
        public DocumentRepository(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
            DocumentStorePath = GetDocumentStorePathFromAppSettings();
        }
        private string GetDocumentStorePathFromAppSettings()
        {
            var appSettings = iconfiguration.GetSection(Constants.AppSettingSection);
            if (appSettings != null)
            {
                return appSettings.GetValue<string>(Constants.DocumentStorePathSection);
            }
            return string.Empty;
        }

        public async Task<BaseResult<string>> UploadContract(UploadContractViewModel request)
        {

            try
            {
                var mainDirectory = "\\MGDocuments";
                if (!Directory.Exists(DocumentStorePath + mainDirectory))
                {
                    Directory.CreateDirectory(DocumentStorePath + mainDirectory);
                }
                var hotelDirectory = mainDirectory + "\\hotelId-" + request.HotelID.Value;
                if (!Directory.Exists(DocumentStorePath + hotelDirectory))
                {
                    Directory.CreateDirectory(DocumentStorePath + hotelDirectory);
                }
                var contractDirectory = hotelDirectory + "\\contracts";
                if (!Directory.Exists(DocumentStorePath + contractDirectory))
                {
                    Directory.CreateDirectory(DocumentStorePath + contractDirectory);
                }
                var fileToUpload = contractDirectory + "\\" + request.Id.Value + ".pdf";
                //File.Delete(DocumentStorePath + fileToUpload);
                using (var fileStream = new FileStream(DocumentStorePath + fileToUpload, FileMode.OpenOrCreate))
                {
                    var bytes = request.Bytes.ToArray();
                    fileStream.Flush();
                    await fileStream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
                }
                return new BaseResult<string>() { Result=fileToUpload };
            }
            catch(Exception e)
            {
                return new BaseResult<string>() {IsError=true,ExceptionMessage=e };
            }
        }

        public async Task<BaseResult<MemoryStream>> GetDocumentByPath(string path)
        {
            byte[] input=null;
            MemoryStream memoryStream = null;
            try
            {
                input = await File.ReadAllBytesAsync(DocumentStorePath + path).ConfigureAwait(false);
                memoryStream = new MemoryStream(input);
                return new BaseResult<MemoryStream>() { Result= memoryStream };
            }
            catch(Exception e)
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
                return new BaseResult<MemoryStream>() { IsError = true, ExceptionMessage = e };
            }
        }
    }
}
