using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreHelper = MG.Jarvis.Core.Model.Helper;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class PoliciesRepository : IPolicies
    {
        #region private variables
        private IConnection<ChildrenAndExtraBedPolicies> iChildrenAndExtraBedPoliciesConnectionLibrary;
        private IConnection<MaxChildAndExtraBedPerRoom> iMaxChildAndExtraBedPerRoomConnectionLibrary;
        private IConnection<CancellationPolicyType> iCancellationPolicyTypeConnectionLibrary;
        private IConnection<CancellationCharges> iCancellationChargesConnectionLibrary;
        private IConnection<CancellationPolicy> iCancellationPolicyConnectionLibrary;
        private IConnection<CancellationPolicyClauses> iCancellationPolicyClausesConnectionLibrary;
        private IConnection<Room> iRoomLibrary;
        #endregion private variables

        public PoliciesRepository(IConnection<ChildrenAndExtraBedPolicies> iChildrenAndExtraBedPoliciesConnectionLibrary,
            IConnection<MaxChildAndExtraBedPerRoom> iMaxChildAndExtraBedPerRoomConnectionLibrary,
            IConnection<CancellationCharges> iCancellationChargesLibrary,
            IConnection<CancellationPolicy> iCancellationPolicyLibrary,
            IConnection<CancellationPolicyClauses> iCancellationPolicyClausesLibrary,
            IConnection<CancellationPolicyType> iCancellationPolicyTypeLibrary, IConnection<Room> iRoomLibrary)
        {
            this.iChildrenAndExtraBedPoliciesConnectionLibrary = iChildrenAndExtraBedPoliciesConnectionLibrary;
            this.iMaxChildAndExtraBedPerRoomConnectionLibrary = iMaxChildAndExtraBedPerRoomConnectionLibrary;
            this.iCancellationChargesConnectionLibrary = iCancellationChargesLibrary;
            this.iCancellationPolicyConnectionLibrary = iCancellationPolicyLibrary;
            this.iCancellationPolicyClausesConnectionLibrary = iCancellationPolicyClausesLibrary;
            this.iCancellationPolicyTypeConnectionLibrary = iCancellationPolicyTypeLibrary;
            this.iRoomLibrary = iRoomLibrary;
        }


        /// <summary>
        /// Retruns Children And Extra Bed Policies for specific hotelId
        /// </summary>
        /// <returns>ChildrenAndExtraBedPolicies</returns>
        public async Task<BaseResult<List<ChildrenAndExtraBedPolicies>>> GetChildrenAndExtraBedPolicyListingByHotelId(int hotelId)
        {
            return await iChildrenAndExtraBedPoliciesConnectionLibrary.GetListByPredicate(id => id.HotelId == hotelId && id.IsActive && !id.IsDeleted).ConfigureAwait(false);
        }

        /// <summary>
        /// Retruns MaxChildAndExtraBedPerRoom for specific hotelId
        /// </summary>
        /// <returns>MaxChildAndExtraBedPerRoom</returns>
        public async Task<BaseResult<List<MaxChildAndExtraBedPerRoom>>> GetMaxChildAndExtraBedPerRoom(int hotelId)
        {
            BaseResult<List<MaxChildAndExtraBedPerRoom>> childrenAndExtraBedPoliciesList = new BaseResult<List<MaxChildAndExtraBedPerRoom>>();
            DynamicParameters paramCollection = new DynamicParameters();
            paramCollection.Add("@hotelid", hotelId);
            childrenAndExtraBedPoliciesList = await iMaxChildAndExtraBedPerRoomConnectionLibrary.ExecuteStoredProcedure(Constants.StoredProcedure.GetChildrenAndExtraBedPolicyByHotelId, paramCollection).ConfigureAwait(false);
            return childrenAndExtraBedPoliciesList;
        }

        /// <summary>
        /// Returns list of rooms by id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>List<Room></returns>
        public async Task<BaseResult<List<Room>>> GetRoomsById(List<MaxChildAndExtraBedPerRoomViewModel> maxChildAndExtraBedPerRoomViewModelList)
        {
            BaseResult<List<Room>> roomListResult = new BaseResult<List<Room>>();
            List<Room> roomList = new List<Room>();
            foreach (var item in maxChildAndExtraBedPerRoomViewModelList)
            {
                var room= await iRoomLibrary.GetListByPredicate(x => x.Id == item.RoomId && x.IsActive && x.IsDeleted == false).ConfigureAwait(false);
                roomList.Add(room.Result.First());
            }
            roomListResult.Result = roomList;
            return roomListResult;
        }

        /// <summary>
        /// Creates new hotel meal or edits the hotel meal
        /// </summary>
        /// <param name="hotelMealRequest"></param>
        /// <param name="objectState"></param>
        /// <param name="userName"></param>
        /// <returns>Task<BaseResult<long>></returns>
        public async Task<BaseResult<ChildrenAndExtraBedPolicies>> SaveAndUpdateChildAndExtraBedPolicy(ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesRequest, ObjectState? objectState)
        {
            BaseResult<ChildrenAndExtraBedPolicies> result = new BaseResult<ChildrenAndExtraBedPolicies>();
            result.Result = new ChildrenAndExtraBedPolicies();
            if (objectState == ObjectState.Added)
            {
                var insertResult = await iChildrenAndExtraBedPoliciesConnectionLibrary.InsertEntity(childrenAndExtraBedPoliciesRequest).ConfigureAwait(false);
                if (insertResult == null)
                {
                    return result=null;
                }
                else if (insertResult.IsError || insertResult.ExceptionMessage != null)
                {
                    result.IsError = true;
                    result.ExceptionMessage = insertResult.ExceptionMessage;
                    return result;
                }

                result.Result.Id = (int)insertResult.Result;
                return result;
            }
            else if (objectState == ObjectState.Modified)
            {
                var childrenAndExtraBedPoliciesResult =await iChildrenAndExtraBedPoliciesConnectionLibrary.GetListByPredicate(x =>x.HotelId == childrenAndExtraBedPoliciesRequest.HotelId && x.IsActive).ConfigureAwait(false);
                if (childrenAndExtraBedPoliciesResult.Result.Count > 0 && childrenAndExtraBedPoliciesResult != null)
                {
                    var updatedChildrenAndExtraBedPolicy = PoliciesRequestMapper.AutoMapperChildrenAndExtraBedPolicy(childrenAndExtraBedPoliciesRequest, childrenAndExtraBedPoliciesResult.Result.First());

                    var updateResult = await iChildrenAndExtraBedPoliciesConnectionLibrary.UpdateEntityByDapper(updatedChildrenAndExtraBedPolicy).ConfigureAwait(false);
                    if (updateResult == null)
                    {
                        return result=null;
                    }
                    else if (updateResult.IsError || updateResult.ExceptionMessage != null)
                    {
                        result.IsError = true;
                        result.ExceptionMessage = updateResult.ExceptionMessage;
                        return result;
                    }
                    else if (updateResult.Result)
                    {
                        result.Result.Id = childrenAndExtraBedPoliciesRequest.Id;
                    }
                    return result;
                }
                else
                {
                    result.IsError = true;
                    result.ErrorCode = (int)coreHelper.Constants.ErrorCodes.NoChildrenAndExtraBedPolicyOfID;
                    result.Message = string.Format(coreHelper.Constants.ErrorMessage.NoChildrenAndExtraBedPolicyOfID, childrenAndExtraBedPoliciesRequest.Id);
                    return result;
                }
            }
            return result;
        }

        public async Task<BaseResult<bool>> UpdateRoomList(List<Room> roomList)
        {
            return await iRoomLibrary.UpdateEntityList(roomList).ConfigureAwait(false);
        }
        /// <summary>
        /// Get CancellationCharges
        /// </summary>
        /// <returns>List of cancellation charges</returns>
        public async Task<BaseResult<List<CancellationCharges>>> GetCancellationCharges()
        {
            var cancellationCharges = await iCancellationChargesConnectionLibrary.GetListByPredicate(p => p.IsActive == true && p.IsDeleted == false).ConfigureAwait(false);
            return cancellationCharges;
        }

        /// <summary>
        /// Get CancellationPolicyType
        /// </summary>
        /// <returns>List of cancellation policy types</returns>
        public async Task<BaseResult<List<CancellationPolicyType>>> GetCancellationPolicyType()
        {
            var cancellationPolicyType = await iCancellationPolicyTypeConnectionLibrary.GetListByPredicate(p => p.IsDeleted == false).ConfigureAwait(false);
            return cancellationPolicyType;
        }

        /// <summary>
        /// Gets cancellation policy by policy Id
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns>List of cancellation policies</returns>
        public async Task<BaseResult<CancellationPolicy>> GetCancellationPolicyById(int? policyId)
        {
            var result = new BaseResult<CancellationPolicy>
            {
                Result = new CancellationPolicy()
            };

            var getResult =await this.iCancellationPolicyConnectionLibrary.GetListByPredicate(p=> policyId != null && p.Id == (int) policyId).ConfigureAwait(false);
            if (getResult.IsError || getResult.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = getResult.ExceptionMessage;
                return result;
            }
            if (getResult.Result == null)
            {
                result = null;
            }

            if (result != null)
                result.Result = getResult.Result[0];
            return result;
        }

        /// <summary>
        /// Gets cancellation policy clauses by Id
        /// </summary>
        /// <param name="policyId"></param>
        /// <returns>Policy list</returns>
         public async Task<BaseResult<List<CancellationPolicyClauses>>> GetCancellationPolicyClausesById(int? policyId)
        {
            BaseResult<List<CancellationPolicyClauses>> result = new BaseResult<List<CancellationPolicyClauses>>();
            result.Result = new List<CancellationPolicyClauses>();

            var getResult = await this.iCancellationPolicyClausesConnectionLibrary.GetListByPredicate(p=>p.CancellationPolicyId==(int)policyId).ConfigureAwait(false);
            if (getResult.IsError || getResult.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = getResult.ExceptionMessage;
                return result;
            }
            if (getResult == null)
            {
                result = null;
            }
            result.Result = getResult.Result;
            return result;
        }
        /// <summary>
        /// Save And Update CancellationPolicy
        /// </summary>
        /// <param name="cancellationPolicyViewModel"></param>
        /// <param name="loggedUserName"></param>
        /// <returns></returns>
        public async Task<BaseResult<CancellationPolicy>> SaveAndUpdateCancellationPolicy(CancellationPolicyViewModel cancellationPolicyViewModel, string loggedUserName)
        {
            var result = new BaseResult<CancellationPolicy>
            {
                Result = new CancellationPolicy()
            };
            int policyId = cancellationPolicyViewModel.CancellationPolicyId;
            if (cancellationPolicyViewModel != null && cancellationPolicyViewModel.ObjectState == ObjectState.Added)
            {
                result = await this.CreateCancellationPolicy(cancellationPolicyViewModel).ConfigureAwait(false);
                policyId = result.Result.Id;
                cancellationPolicyViewModel.CancellationPolicyId = result.Result.Id;
                if (cancellationPolicyViewModel.CancellationPolicyClausesViewModelList.Count > 0)
                {

                    foreach (var item in cancellationPolicyViewModel.CancellationPolicyClausesViewModelList)
                    {
                        item.CancellationPolicyId = policyId;
                        await this.CreateCancellationPolicyClauses(item).ConfigureAwait(false);
                    } 
                }
            }

            if (cancellationPolicyViewModel != null && cancellationPolicyViewModel.ObjectState == ObjectState.Modified)
            {
                var updateCancellationPolicyResult = await this.UpdateCancellationPolicy(cancellationPolicyViewModel).ConfigureAwait(false);
            }

            if (cancellationPolicyViewModel != null &&
                cancellationPolicyViewModel.CancellationPolicyClausesViewModelList.Count >= 1 &&
                cancellationPolicyViewModel.ObjectState == ObjectState.Modified)
            {
                foreach (var item in cancellationPolicyViewModel.CancellationPolicyClausesViewModelList)
                {
                    if(item.ObjectState == ObjectState.Modified || item.ObjectState==ObjectState.Added)
                    {
                        item.CancellationPolicyId = policyId;
                        var updateCancellationPolicyClauseResult = await this.UpdateCancellationClauses(item).ConfigureAwait(false);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Validates cancellation policy clauses
        /// </summary>
        /// <param name="cancellationPolicyClause"></param>
        /// <returns>returns results based on validation</returns>
        private bool ValidatePolicyClause(CancellationPolicyClauses cancellationPolicyClause)
        {
            int cancellationChrgesId = cancellationPolicyClause.CancellationChargesId;

            var list = iCancellationPolicyClausesConnectionLibrary.GetListByPredicate(p => p.CancellationPolicyId == cancellationPolicyClause.CancellationPolicyId && p.CancellationChargesId == cancellationChrgesId).Result.Result;

            int daysBeforeArrival = cancellationPolicyClause.DaysBeforeArrival;
            decimal percentage = cancellationPolicyClause.PercentageCharge;

            List<CancellationPolicyClauses> clist = list.OrderBy(p => p.DaysBeforeArrival).ToList();
            CancellationPolicyClauses c1 = null, c2 = null;
            foreach (var item in clist)
            {

                if (daysBeforeArrival > item.DaysBeforeArrival)
                {
                    c1 = item;
                    continue;
                }
                else
                {
                    c2 = item;
                    break;
                }
            }
            if (c1 != null && c2 != null)
            {
                if (c1.PercentageCharge > percentage && percentage > c2.PercentageCharge)
                {
                    return true;
                }
                else return false;
            }
            else if (c1 == null)
            {
                if (c2.PercentageCharge < percentage)
                    return true;
                else return false;
            }
            else if (c2 == null)
            {
                if (c1.PercentageCharge > percentage)
                    return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates Cancellation Policy
        /// </summary>
        /// <param name="cancellationPolicyViewModel"></param>
        /// <returns>updated cancellation policy id</returns>
        private async Task<BaseResult<CancellationPolicy>> UpdateCancellationPolicy(CancellationPolicyViewModel cancellationPolicyViewModel)
        {
            var result = new BaseResult<CancellationPolicy>();
            result.Result = new CancellationPolicy();
            if (cancellationPolicyViewModel.ObjectState == ObjectState.Modified)
            {
                var cancellationPolicyDbList = await this.iCancellationPolicyConnectionLibrary.GetListByPredicate(p => p.HotelId == cancellationPolicyViewModel.HotelId && p.IsDeleted == false).ConfigureAwait(false);
                var cancellationPolicyDb = cancellationPolicyDbList.Result.FirstOrDefault(p => p.Id == cancellationPolicyViewModel.CancellationPolicyId);
                if (cancellationPolicyDb != null)
                {
                    var cancellationPolicy =
                        DbMapperMasterdata.AutomapperCancellationPolicy(cancellationPolicyViewModel,
                            cancellationPolicyDb);
                    if (cancellationPolicy.CancellationPolicyTypeId != cancellationPolicyDb.CancellationPolicyTypeId &&
                        cancellationPolicyDb.CancellationPolicyTypeId == 2)
                    {
                        var clausesList = await iCancellationPolicyClausesConnectionLibrary
                            .GetListByPredicate(p =>
                                p.CancellationPolicyId == cancellationPolicyDb.Id && p.IsDeleted == false)
                            .ConfigureAwait(false);
                        foreach (var item in clausesList.Result)
                        {
                            item.IsDeleted = true;
                        }
                        await iCancellationPolicyClausesConnectionLibrary.UpdateEntityList(clausesList.Result)
                            .ConfigureAwait(false);

                    }
                    var updateResult = await iCancellationPolicyConnectionLibrary.UpdateEntityByDapper(cancellationPolicy).ConfigureAwait(false);
                    if (updateResult.IsError || updateResult.ExceptionMessage != null)
                    {
                        result.IsError = true;
                        result.ExceptionMessage = updateResult.ExceptionMessage;
                        return result;
                    }
                    if (updateResult == null)
                    {
                        result = null;
                    }
                    return result;
                }
                else return result;
            }
            else return result;
        }

        /// <summary>
        /// Updates CancellationClauses
        /// </summary>
        /// <param name="cancellationPolicyViewModel"></param>
        /// <returns></returns>
        private async Task<BaseResult<CancellationPolicy>> UpdateCancellationClauses(CancellationPolicyClausesViewModel clauseViewModel)
        {
            BaseResult<CancellationPolicy> result = new BaseResult<CancellationPolicy>();
            result.Result = new CancellationPolicy();
            var updateResult = new BaseResult<bool>();


            var clauseDb = this.iCancellationPolicyClausesConnectionLibrary.GetListByPredicate(p => p.Id==clauseViewModel.CancellationPolicyClausesId).Result.Result.FirstOrDefault();
           
                if (clauseViewModel.ObjectState == ObjectState.Modified)
                {
                    var updatedModel = DbMapperMasterdata.AutomapperCancellationPolicyClause(clauseViewModel, clauseDb);
                ////this.ValidatePolicyClause(updatedModel);
                    updateResult = await iCancellationPolicyClausesConnectionLibrary.UpdateEntityByDapper(updatedModel).ConfigureAwait(false);
            }
            if (clauseViewModel.ObjectState == ObjectState.Added)
                {
                 return   await CreateCancellationPolicyClauses(clauseViewModel).ConfigureAwait(false);
                }
           
            if (updateResult.IsError || updateResult.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = updateResult.ExceptionMessage;
                return result;
            }
           
            if (updateResult.Result == true)
            {
                result.Result.Id = clauseViewModel.CancellationPolicyId;
            }
            return result;
        }

        /// <summary>
        /// Create Cancellation Policy
        /// </summary>
        /// <param name="cancellationPolicyViewModel"></param>
        /// <returns>returns the Id of the newly created cancellation policy</returns>
        private async Task<BaseResult<CancellationPolicy>> CreateCancellationPolicy(CancellationPolicyViewModel cancellationPolicyViewModel)
        {
            BaseResult<CancellationPolicy> result = new BaseResult<CancellationPolicy>();
            result.Result = new CancellationPolicy();
            CancellationPolicy cancellationPolicy = new CancellationPolicy()
            {
                HotelId = cancellationPolicyViewModel.HotelId,
                CancellationPolicyTypeId = cancellationPolicyViewModel.CancellationPolicyTypeId,
                NoShowCancellationChargesId = cancellationPolicyViewModel.NoShowCancellationChargesId,
                IsNoShowCharges = cancellationPolicyViewModel.IsNoShowCharges,
                IsActive = cancellationPolicyViewModel.IsActive,
                IsDeleted = cancellationPolicyViewModel.IsDeleted,
                Name = cancellationPolicyViewModel.Name
            };
            var insertResult =  await this.iCancellationPolicyConnectionLibrary.InsertEntity(cancellationPolicy).ConfigureAwait(false);
            if (insertResult.IsError || insertResult.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = insertResult.ExceptionMessage;
                return result;
            }
            if (insertResult == null)
            {
                result = null;
            }
            result.Result.Id = (int)insertResult.Result;
            return result;
        }

        /// <summary>
        /// Create CancellationPolicyClauses
        /// </summary>
        /// <param name="clauseViewModel"></param>
        /// <returns>returns the cancellation policy clauses id</returns>
        public async Task<BaseResult<CancellationPolicy>> CreateCancellationPolicyClauses(CancellationPolicyClausesViewModel clauseViewModel)
        {
            var result = new BaseResult<CancellationPolicy> {Result = new CancellationPolicy()};
            CancellationPolicyClauses clause = new CancellationPolicyClauses()
            {
                DaysBeforeArrival = clauseViewModel.DaysBeforeArrival,
                PercentageCharge = clauseViewModel.PercentageCharge,
                CancellationChargesId = clauseViewModel.CancellationChargesId,
                CancellationPolicyId = (int) clauseViewModel.CancellationPolicyId
            };
           ////this.ValidatePolicyClause(cancellationPolicyClauses);
            var insertResult = await this.iCancellationPolicyClausesConnectionLibrary.InsertEntity(clause).ConfigureAwait(false);
            if (insertResult.IsError || insertResult.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = insertResult.ExceptionMessage;
                return result;
            }
            result.Result.Id = (int)insertResult.Result;
            return result;
        }

        /// <summary>
        /// Get Cancellation Policies by hotel id
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns>list of cancellation policy</returns>
        public BaseResult<List<CancellationPolicyViewModel>> GetCancellationPolicies(int hotelId)
        {
            BaseResult<List<CancellationPolicy>> policies = this.iCancellationPolicyConnectionLibrary.GetListByPredicate(p => p.HotelId == hotelId && p.IsDeleted == false).Result;
            var cancellationPolicyTypes = this.iCancellationPolicyTypeConnectionLibrary.GetListByPredicate(p => p.IsActive == true && p.IsDeleted == false);
            var cancellationCharges = this.iCancellationChargesConnectionLibrary.GetListByPredicate(p => p.IsActive == true && p.IsDeleted == false);
            BaseResult<List<CancellationPolicyViewModel>> modelList = new BaseResult<List<CancellationPolicyViewModel>>();
            modelList.Result = new List<CancellationPolicyViewModel>();
            Func<int?, string> GetCancellationChargesName = (id) =>
            cancellationCharges.Result.Result.Where(p => p.Id == id).FirstOrDefault().Name;
            Func<int, string> GetCancellationPolicyTypeName = (id) =>
            cancellationPolicyTypes.Result.Result.Where(p => p.Id == id).FirstOrDefault().Name;
            foreach (var item in policies.Result)
            {
                CancellationPolicyViewModel model = new CancellationPolicyViewModel()
                {
                    CancellationPolicyId = item.Id,
                    HotelId = item.HotelId,
                    CancellationPolicyTypeId = item.CancellationPolicyTypeId,
                    CancellationPolicyTypeName= GetCancellationPolicyTypeName(item.CancellationPolicyTypeId),
                    IsNoShowCharges = item.IsNoShowCharges,
                    NoShowCancellationChargesId = item.NoShowCancellationChargesId,
                    CancellationChargesName=(item.NoShowCancellationChargesId!=null)? GetCancellationChargesName(item.NoShowCancellationChargesId):String.Empty,
                    Name = item.Name,
                    IsActive = item.IsActive
                };
                BaseResult<List<CancellationPolicyClauses>> policyClauses = this.iCancellationPolicyClausesConnectionLibrary.GetListByPredicate(p => p.CancellationPolicyId == item.Id && p.IsDeleted==false).Result;
                model.CancellationPolicyClausesViewModelList = new List<CancellationPolicyClausesViewModel>();
                foreach (var clause in policyClauses.Result)
                {
                    CancellationPolicyClausesViewModel clauseModel = new CancellationPolicyClausesViewModel()
                    {
                        CancellationChargesId = clause.CancellationChargesId,
                        CancellationPolicyClausesId = clause.Id,
                        CancellationPolicyId = clause.CancellationPolicyId,
                        DaysBeforeArrival = clause.DaysBeforeArrival,
                        PercentageCharge = clause.PercentageCharge
                    };
                    model.CancellationPolicyClausesViewModelList.Add(clauseModel);
                }
                modelList.Result.Add(model);
            }
            return modelList;
        }

        public async Task<BaseResult<CancellationPolicyClauses>> DeleteCancellationPolicyClauses(int? clauseId)
        {
            BaseResult<CancellationPolicyClauses> result = new BaseResult<CancellationPolicyClauses>();
            BaseResult<bool> deleteResult = new BaseResult<bool>();
            var clausesModel = iCancellationPolicyClausesConnectionLibrary.GetListByPredicate(p =>p.Id == clauseId).Result.Result.FirstOrDefault();

            if (clausesModel != null)
            {
                clausesModel.IsDeleted = true;
                deleteResult= await iCancellationPolicyClausesConnectionLibrary.UpdateEntityByDapper(clausesModel).ConfigureAwait(false);
            }
            if (deleteResult.IsError || deleteResult.ExceptionMessage != null)
            {
                result.IsError = true;
                result.ExceptionMessage = deleteResult.ExceptionMessage;
                return result;
            }
            if (deleteResult == null)
            {
                result = null;
            }
            return result;
        }
    }
}
