//using MG.Jarvis.Api.Extranet.Interfaces;
//using MG.Jarvis.Core.DAL.Interfaces;
//using MG.Jarvis.Core.Model;
//using MG.Jarvis.Core.Model.Contracts;
//using System;
//using Dapper;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using MG.Jarvis.Api.Extranet.Models.Request;
//using MG.Jarvis.Api.Extranet.Helper;

//namespace MG.Jarvis.Api.Extranet.Fakes
//{
//    public class ContractRepository: IContract
//    {
//        #region private variable
//        IConnection<Contract> iContract;
//        #endregion private variable

//        public ContractRepository(IConnection<Contract> iContract)
//        {
//            this.iContract = iContract;
//        }

//        /// <summary>
//        /// Method to activate contracts by checking StartDate
//        /// </summary>
//        /// <param name="dateTime"></param>
//        /// <returns></returns>
//        public async Task<BaseResult<bool>> ActivateContract(DateTime dateTime)
//        {
//            BaseResult<bool> result = new BaseResult<bool>
//            {
//                Result = true
//            };
//            var parameters = new DynamicParameters();
//            parameters.Add(Constants.StoredProcedureParameters.StartDate, dateTime.Date);
//            var contractResult = await iContract.ExecuteStoredProcedure(Constants.StoredProcedure.ActivateContracts, parameters);
//            return result;
//        }

//        /// <summary>
//        /// Method which deactivates the contract depending on the date.
//        /// </summary>
//        /// <param >DateTime</param>
//        /// <returns>bool</returns>
//        public async Task<BaseResult<bool>> DeActivateContract(DateTime dateTime)
//        {
//            BaseResult<bool> result = new BaseResult<bool>
//            {
//                Result = false
//            };
//            var parameters = new DynamicParameters();
//            parameters.Add(Constants.StoredProcedureParameters.EndDate, dateTime.Date);
//            var contracts = await iContract.ExecuteStoredProcedure(Constants.StoredProcedure.DeActivateContracts, parameters);

//            return result;

//        }
//        public async Task<BaseResult<IEnumerable<dynamic>>> GetExpiredContract(ExpiredContracts request)
//        {
//            BaseResult<List<Contract>> result = new BaseResult<List<Contract>>();
//            BaseResult<IEnumerable<dynamic>> contractList = new BaseResult<IEnumerable<dynamic>>();
//            DynamicParameters paramCollection = new DynamicParameters();
//            paramCollection.Add("@AdvancementDays", request.ExpiryWarningDays);
//            paramCollection.Add("@NotificationDate", request.NotificationDate);
//            contractList = await iContract.ExecuteStoredProcedureDynamicModel(Constants.StoredProcedure.ExpriedContracts, paramCollection);
//            return contractList;
//        }

//    }
//}
