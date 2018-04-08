using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class Mapping : BaseModel
    {
        public Mapping()
        {
            SupplierCityCodeMapping = new List<MgAndSupplierCodeMap>();
        }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.SupplierCode,
                                    ParameterDirection.In, ParameterType.Normal,
                                    new ParameterIncludeInAction[] { ParameterIncludeInAction.All })]
        public string SupplierCode { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.Mapping,
                                    ParameterDirection.In, ParameterType.TableValued,
                                    new ParameterIncludeInAction[] { ParameterIncludeInAction.All },
                                    Constants.StoredProcedureParameters.UT_EntityMapping)]
        public List<MgAndSupplierCodeMap> SupplierCityCodeMapping { get; }
    }
}
