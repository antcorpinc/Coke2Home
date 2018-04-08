using Dapper;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.Hotel;
using System;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class ContractsRequestMapper
    {
        /// <summary>
        /// Create Parameters for Template Clause Library Fields
        /// </summary>
        /// <param name="templateId">template Id</param>
        /// <param name="languageId">language Id</param>
        /// <returns>Parameters for Template Clause Library Fields</returns>
        public static DynamicParameters CreateTemplateClauseLibraryFieldsRequest(int templateId, int languageId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.TemplateId, templateId);
            param.Add(Constants.StoredProcedureParameters.LanguageId, languageId);
            return param;
        }

        /// <summary>
        /// Update Template Clause Library Fields Request
        /// </summary>
        /// <param name="item">Clause Library Fields</param>
        /// <param name="userName">userName</param>
        /// <param name="templateId">templateId</param>
        /// <returns>Update Template Clause Library Fields Request</returns>
        public static DynamicParameters UpdateTemplateClauseLibraryFieldsRequest(TemplateClauseLibraryViewModel item, string userName, int templateId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(Constants.StoredProcedureParameters.TemplateId, templateId);
            param.Add(Constants.StoredProcedureParameters.ClauseLibraryId, item.ClauseLibraryId);
            param.Add(Constants.StoredProcedureParameters.IsSelected, item.IsSelected);
            param.Add(Constants.StoredProcedureParameters.UpdatedBy, userName);
            param.Add(Constants.StoredProcedureParameters.UpdatedDate, DateTime.Now.JakartaOffset());
            return param;
        }
        public static Contract MapToContractModel(ContractViewModel source,string userName)
        {
            var dest=AutoMapper.Mapper.Map<Contract>(source);
            dest.UpdatedBy = dest.CreatedBy = userName;
            dest.UpdatedDate = dest.CreatedDate = DateTime.Now.JakartaOffset();
            return dest;
        }
        public static HotelContractRelation MapToHotelContractRelationModel(ContractViewModel source, string userName)
        {
            var dest = AutoMapper.Mapper.Map<HotelContractRelation>(source);
            dest.UpdatedBy = dest.CreatedBy = userName;
            dest.UpdatedDate = dest.CreatedDate = DateTime.Now.JakartaOffset();
            return dest;
        }
    }
}
