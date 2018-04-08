using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IDocument
    {

        Task<BaseResult<string>> UploadContract(UploadContractViewModel request);
        Task<BaseResult<MemoryStream>> GetDocumentByPath(string  path);
    }
}
