using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.DAL.Repositories;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class ContractRepository : IContract
    {
        #region private variable
        private IConnection<Contract> iContract;
        private IConfiguration iConfiguration;
        private IConnection<ContractOverview> iContractListing;
        private IConnection<HotelContractRelation> iHotelContractRelation;
        private IConnection<ContractStatus> iContractStatus;
        #endregion private variable

        public ContractRepository(
                                    IConnection<Contract> iContract,
                                    IConnection<ContractOverview> iContractListing,
                                    IConfiguration iConfiguration,
                                    IConnection<HotelContractRelation> iHotelContractRelation,
                                    IConnection<ContractStatus> iContractStatus)
        {
            this.iContract = iContract;
            this.iContractListing = iContractListing;
            this.iConfiguration = iConfiguration;
            this.iHotelContractRelation = iHotelContractRelation;
            this.iContractStatus = iContractStatus;
        }

        /// <summary>
        /// Method to activate contracts by checking StartDate
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<BaseResult<bool>> ActivateContract(DateTime dateTime)
        {
            BaseResult<bool> result = new BaseResult<bool>();
            var parameters = new DynamicParameters();
            parameters.Add(Constants.StoredProcedureParameters.StartDate, dateTime.Date);
            var contractResult = await iContract.ExecuteStoredProcedure(Constants.StoredProcedure.ActivateContracts, parameters);
            result.Result = true;
            return result;
        }


        /// <summary>
        /// Method which deactivates the contract depending on the date.
        /// </summary>
        /// <param>DateTime</param>
        /// <returns>bool</returns>
        public async Task<BaseResult<bool>> DeActivateContract(DateTime dateTime)
        {
            BaseResult<bool> baseResult = new BaseResult<bool>();
            var parameters = new DynamicParameters();
            parameters.Add(Constants.StoredProcedureParameters.EndDate, dateTime.Date);
            var contracts = await iContract.ExecuteStoredProcedure(Constants.StoredProcedure.DeActivateContracts, parameters);
            if (!contracts.IsError)
            {
                baseResult.Result = true;
            }
            return baseResult;

        }

        public async Task<BaseResult<IEnumerable<dynamic>>> GetExpiredContract(ExpiredContracts request)
        {
            BaseResult<IEnumerable<dynamic>> contractList = new BaseResult<IEnumerable<dynamic>>();
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add("@AdvancementDays", request.ExpiryWarningDays);
            paramCollection.Add("@NotificationDate", request.NotificationDate);
            contractList = await iContract.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.ExpriedContracts, paramCollection);
            return contractList;
        }
        /// <summary>
        /// Gets All contract lisiting
        /// </summary>
        /// <returns>List of contracts</returns>
        public async Task<BaseResult<List<ContractListingViewModel>>> GetAllContracts()
        {
            BaseResult<List<ContractOverview>> allContractList = new BaseResult<List<ContractOverview>>();
            DynamicParameters paramCollection = new DynamicParameters();
            allContractList = await iContractListing.ExecuteStoredProcedure(Constants.StoredProcedure.GetAllContracts, paramCollection);
            if (allContractList.IsError || allContractList.ExceptionMessage != null)
            {
                BaseResult<List<ContractListingViewModel>> baseResult = new BaseResult<List<ContractListingViewModel>>
                {
                    IsError = true,
                    ExceptionMessage = allContractList.ExceptionMessage
                };
                return baseResult;
            }
            else
            {
                BaseResult<List<ContractListingViewModel>> baseResult = ContractsResponseMapper.MapContractListingResponse(allContractList);
                if (allContractList.ExceptionMessage != null)
                {
                    baseResult.IsError = true;
                    baseResult.ExceptionMessage = allContractList.ExceptionMessage;
                    return baseResult;
                }
                else
                    return baseResult;
            }
        }
        /// <summary>
        /// create contract
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Task<BaseResult<long>> CreateContract(ContractViewModel request,string userName)
        {
            var contract = ContractsRequestMapper.MapToContractModel(request, userName);
            return iContract.InsertEntity(contract);
        }
        /// <summary>
        /// Insert hotel contract relation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Task<BaseResult<long>> InsertHotelContractRelation(ContractViewModel request, string userName)
        {
            var hotelContractRelation = ContractsRequestMapper.MapToHotelContractRelationModel(request, userName);
            return iHotelContractRelation.InsertEntity(hotelContractRelation);
        }
        /// <summary>
        /// Get contract statuses
        /// </summary>
        /// <returns></returns>
        public Task<BaseResult<List<ContractStatus>>> GetContractStatuses()
        {
            return iContractStatus.GetList();
        }
    }
}
