using MG.Jarvis.Api.Extranet.Attributes;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Models.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MG.Jarvis.Core.Model.Contracts;

namespace MG.Jarvis.Api.Extranet.Controllers
{
    using System.Diagnostics.Contracts;

    using Contract = MG.Jarvis.Core.Model.Contracts.Contract;

    public class ContractsController : BaseController
    {
        #region Private Variable
        private readonly IContract contracts;
        private readonly IContractStatic _icontractsStatic;
        #endregion Private Variables

        public ContractsController(IContract contracts, IContractStatic contractStatic)
        {
            this.contracts = contracts;
            this._icontractsStatic = contractStatic;
        }

        /// <summary>
        /// Method to activate contract
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost]
        // [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ActivateContract([FromBody] DateTime date)
        {

            BaseResult<bool> activationResult;
            if (date.Date != DateTime.Now.Date)
            {
                activationResult = new BaseResult<bool>() { IsError = true };
                return new BadRequestObjectResult(activationResult);
            }
            activationResult = await this.contracts.ActivateContract(date);
            if (activationResult.IsError)
            {
                return new StatusCodeResult(500);
            }
            return Ok(activationResult);
        }
        /// <summary>
        /// Method which deactivates the contract depending on the date.
        /// </summary>
        /// <param>DateTime</param>
        /// <returns></returns>
        [HttpPost]
        // [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeActivateContract([FromBody] DateTime date)
        {
            BaseResult<bool> deActivationResult;
            if (date.Date != DateTime.Now.Date)
            {
                deActivationResult = new BaseResult<bool>() { IsError = true, Result = false };
                return new BadRequestObjectResult(deActivationResult);
            }
            deActivationResult = await this.contracts.DeActivateContract(date);
            if (deActivationResult.IsError)
            {
                return new StatusCodeResult(500);
            }
            return Ok(deActivationResult);
        }

        /// <summary>
        /// Returns the List Of Expired Contracts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetExpiredContract([FromBody]  ExpiredContracts request)
        {
            BaseResult<IEnumerable<dynamic>> expiryingContracts;
            #region Input Request Validation
            if (request == null || request.NotificationDate == DateTime.MinValue) //Need to check jakarta offset // || request.ExpiryWarningDays < 1 : Might Need old expired contract
            {
                expiryingContracts = new BaseResult<IEnumerable<dynamic>>
                {
                    IsError = true,
                    Message = Constants.BadRequestErrorMessage.InvalidRequest
                };
                return new BadRequestObjectResult(expiryingContracts);
            }

            #endregion Input Request Validation

            expiryingContracts = await this.contracts.GetExpiredContract(request).ConfigureAwait(false);

            if (expiryingContracts.IsError && expiryingContracts.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (expiryingContracts.Result == null || !expiryingContracts.Result.Any())
            {
                return NoContent(); //204
            }
            return Ok(expiryingContracts); ;
        }

        /// <summary>
        /// Gets List of contracts
        /// </summary>
        /// <returns>List of contracts</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllContracts()
        {
            BaseResult<List<ContractListingViewModel>> contractData;

            contractData = await this.contracts.GetAllContracts().ConfigureAwait(false);
            if (contractData.IsError && contractData.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (contractData.Result == null || !contractData.Result.Any())
            {
                return NoContent(); //204
            }
            return Ok(contractData);
        }
        /// <summary>
        /// api for create non mg contract
        /// </summary>
        /// <param name="contractRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateNonMGContract([FromBody] ContractViewModel contractRequest)
        {
            if (contractRequest.ContractType != Enums.ContractType.NonMg)
            {
                return BadRequest();
            }
            return await CreateContract(contractRequest).ConfigureAwait(false);
        }
        /// <summary>
        /// api for create mg dynamic contract
        /// </summary>
        /// <param name="contractRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateMGDynamicContract([FromBody] ContractViewModel contractRequest)
        {
            if (contractRequest.ContractType != Enums.ContractType.MgDynamic)
            {
                return BadRequest();
            }
            return await CreateContract(contractRequest).ConfigureAwait(false);
        }
        /// <summary>
        /// PAi for  get contract statuses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetContractStatuses")]
        public async Task<IActionResult> GetContractStatusesAPI()
        {
            var contractStatusResult = await GetContractStatuses().ConfigureAwait(false);
            if (contractStatusResult.IsError && contractStatusResult.ExceptionMessage != null)
            {
                return StatusCode(500, contractStatusResult);
            }
            return Ok(contractStatusResult);
        }
        /// <summary>
        /// private common method for create contract
        /// </summary>
        /// <param name="contractRequest"></param>
        /// <returns></returns>
        private async Task<IActionResult> CreateContract(ContractViewModel contractRequest)
        {
            BaseResult<long> contractResult = null;
            if ((contractRequest.Id?? default(int)) == default(int))
            {
                var contractStatusResult =await  GetContractStatuses().ConfigureAwait(false);
                if(contractStatusResult.IsError && contractStatusResult.ExceptionMessage != null)
                {
                    return StatusCode(500, contractStatusResult);
                }
                //get status id for draft must present in DB
                contractRequest.StatusID = contractStatusResult.Result.First(x => x.Name.Equals(Constants.ContractStatuses.Draft, StringComparison.OrdinalIgnoreCase)).Id;
                contractResult = await this.contracts.CreateContract(contractRequest, LoggedInUserName).ConfigureAwait(false);
                if (contractResult.IsError && contractResult.ExceptionMessage != null)
                {
                    return StatusCode(500, contractResult);
                }
                contractRequest.Id = (int)contractResult.Result;
            }
            //else for update
            var hotelContractRelationResult = await this.contracts.InsertHotelContractRelation(contractRequest, LoggedInUserName).ConfigureAwait(false);
            if (hotelContractRelationResult.IsError && hotelContractRelationResult.ExceptionMessage != null)
            {
                return StatusCode(500, hotelContractRelationResult);
            }
            return Ok(contractResult);
        }

        private async  Task<BaseResult<List<ContractStatus>>> GetContractStatuses()
        {
            var contractStatusResult = new BaseResult<List<ContractStatus>>();
            var contractStatusListCache =
                RedisCacheHelper.Instance.Get<List<ContractStatus>>(Constants.CacheKeys.ContractStatusList);
            if (contractStatusListCache != null && contractStatusListCache.Any())
            {
                contractStatusResult.Result = contractStatusListCache;
            }
            else
            {
                var contractStatusData = await this.contracts.GetContractStatuses().ConfigureAwait(false);
                if (contractStatusData.IsError && contractStatusData.ExceptionMessage != null)
                {
                    contractStatusResult.IsError = contractStatusData.IsError;
                    contractStatusData.ExceptionMessage = contractStatusData.ExceptionMessage;
                    return contractStatusResult;
                }
                contractStatusResult = contractStatusData;
                RedisCacheHelper.Instance.Set(Constants.CacheKeys.ContractStatusList, contractStatusData.Result);
            }
            return contractStatusResult;
        }

        /// <summary>
        /// The create contract.
        /// </summary>
        /// <param name="contractStaticViewModel">
        /// The contract Static View Model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateStaticContract([FromBody]ContractStaticViewModel contractStaticViewModel)
        {
            var insertResult = await this._icontractsStatic.CreateContract(contractStaticViewModel, this.LoggedInUserName).ConfigureAwait(false);
            if (insertResult.IsError && insertResult.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (insertResult.Result == null)
            {
                return this.NoContent(); // 204
            }

            return this.Ok(insertResult);
        }

        /// <summary>
        /// The get contract by id.
        /// </summary>
        /// <param name="contractId">
        /// The contract id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<BaseResult<Contract>> GetContractById(int contractId)
        {
            var result = await this._icontractsStatic.GetContractById(contractId).ConfigureAwait(false);
            var contractHotelProperties = new List<ContractHotelProperties>();
            var contractRoomProperties = new List<ContractRoomProperties>();

            return result;
        }
    }
}
