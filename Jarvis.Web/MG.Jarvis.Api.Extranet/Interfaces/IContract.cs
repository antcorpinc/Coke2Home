using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.MasterData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IContract
    {
        Task<BaseResult<bool>> ActivateContract(DateTime dateTime );
        Task<BaseResult<bool>> DeActivateContract(DateTime dateTime);
        Task<BaseResult<IEnumerable<dynamic>>> GetExpiredContract(ExpiredContracts request);
        Task<BaseResult<List<ContractListingViewModel>>> GetAllContracts();
        Task<BaseResult<long>> CreateContract(ContractViewModel request, string userName);
        Task<BaseResult<long>> InsertHotelContractRelation(ContractViewModel request, string userName);
        Task<BaseResult<List<ContractStatus>>> GetContractStatuses();

    }
}
