using MG.Jarvis.Api.BackOffice.Interfaces;
//using DapperParameters;
using MG.Jarvis.Api.BackOffice.Models.Response;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Supplier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class SupplierRepository : ISupplier
    {
        private Core.DAL.Interfaces.IConnection<Bank> iBank;
        private Core.DAL.Interfaces.IConnection<Contacts> iContacts;
        private Core.DAL.Interfaces.IConnection<Payment> iPayment;
        private Core.DAL.Interfaces.IConnection<Suppliers> iSuppliers;
        private Core.DAL.Interfaces.IConnection<FunctionSupplierRelation> iSuppliersFunctionsMapping;
        private Core.DAL.Interfaces.IConnection<Functions> iFunctions;
        private Core.DAL.Interfaces.IConnection<UserRelation> iUserRelation;


        private readonly string ClassName = "";
        public SupplierRepository(Core.DAL.Interfaces.IConnection<Bank> iBank, Core.DAL.Interfaces.IConnection<Contacts> iContacts,
            Core.DAL.Interfaces.IConnection<Payment> iPayment, Core.DAL.Interfaces.IConnection<Suppliers> iSuppliers, Core.DAL.Interfaces.IConnection<FunctionSupplierRelation> iSuppliersFunctionsMapping,
            Core.DAL.Interfaces.IConnection<Functions> iFunctions, Core.DAL.Interfaces.IConnection<UserRelation> iUserRelation)
        {
            this.iBank = iBank;
            this.iContacts = iContacts;
            this.iPayment = iPayment;
            this.iSuppliers = iSuppliers;
            this.iSuppliersFunctionsMapping = iSuppliersFunctionsMapping;
            this.iFunctions = iFunctions;
            this.iUserRelation = iUserRelation;

            this.ClassName = "SupplierRepository";
            this.iPayment.SetConnectionStringKey("DapperConnection");
        }
               
        public virtual async Task<BaseResult<List<Supplier>>> Get()
        {
            BaseResult<List<Supplier>> supplierList = new BaseResult<List<Supplier>>();
            var list = await iSuppliers.GetListByPredicate(s => s.IsActive && !s.IsDeleted);

            if (list != null && list.Result != null && list.Result.Count > 0)
            {
                supplierList.Result = new List<Supplier>();
                foreach (var supplier in list.Result)
                {
                    var bankDetails = await iBank.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.SupplierId == supplier.Id);
                    var contactDetails = await iContacts.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.SupplierId == supplier.Id);
                    var paymentDetails = await iPayment.GetListByPredicate(b => b.IsActive && !b.IsDeleted && b.SupplierId == supplier.Id);
                    var userRelationList = await iUserRelation.GetListByPredicate(b => !b.IsDeleted && b.SupplierId == supplier.Id);

                    supplierList.Result.Add(new Supplier
                    {
                        MGSupplier = supplier,
                        Banks = (bankDetails.IsError == false && bankDetails.Result != null && bankDetails.Result.Count > 0) ? bankDetails.Result : null,
                        SupplierContacts = (contactDetails.IsError == false && contactDetails.Result != null && contactDetails.Result.Count > 0) ? contactDetails.Result : null,
                        SupplierPayment = (paymentDetails.IsError == false && paymentDetails.Result != null && paymentDetails.Result.Count > 0) ? paymentDetails.Result[0] : null,
                        SupplierCredentials = (userRelationList.IsError == false && userRelationList.Result != null && userRelationList.Result.Count > 0) ? userRelationList.Result : null,
                        FunctionEndpoints = await GetSupplierFunctionEndpoints(supplier.Id),
                    });
                }
            }
            else
            {
                supplierList.IsError = list.IsError;
                supplierList.ErrorCode = list.ErrorCode;
                supplierList.ExceptionMessage = list.ExceptionMessage;
                supplierList.Message = list.Message;
            }

            return supplierList;
        }
        
        public virtual async Task<BaseResult<Supplier>> GetById(int Id)
        {
            var supplierList = await Get();
            BaseResult<Supplier> result = new BaseResult<Supplier>();


            if (supplierList != null && !supplierList.IsError && supplierList.Result != null && supplierList.Result.Count > 0)
            {
                result.Result = supplierList.Result.Find(s => s.MGSupplier.Id == Id);
            }
            else
            {
                result.ErrorCode = supplierList.ErrorCode;
                result.ExceptionMessage = supplierList.ExceptionMessage;
                result.IsError = supplierList.IsError;
                result.Message = supplierList.Message;
            }

            return result;

        }

        private async Task<List<FunctionSupplierRelationModel>> GetSupplierFunctionEndpoints(int supplierId)
        {
            var functionList = await iFunctions.GetListByPredicate(f => !f.IsDeleted);
            var supplierFunctionMapping = await iSuppliersFunctionsMapping.GetListByPredicate(f => !f.IsDeleted && f.SupplierId == supplierId);

            if (supplierFunctionMapping == null ||
                functionList == null ||
                supplierFunctionMapping.Result == null ||
                functionList.Result == null ||
                supplierFunctionMapping.Result.Count == 0 ||
                functionList.Result.Count == 0)
                return null;

            List<FunctionSupplierRelationModel> result = new List<FunctionSupplierRelationModel>();

            foreach (var item in supplierFunctionMapping.Result)
            {
                result.Add(new FunctionSupplierRelationModel
                {
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    EndpointURL = item.EndpointURL,
                    EnvironmentId = item.EnvironmentId,
                    FunctionId = item.FunctionId,
                    FunctionName = functionList.Result.Find(f => f.Id == item.FunctionId).Name,
                    IsDeleted = item.IsDeleted,
                    LanguageID = item.LanguageID,
                    SupplierId = item.SupplierId,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate
                });
            }

            return result;
        }
    }
}
