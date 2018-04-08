using MG.Jarvis.Api.BackOffice.Helper;
using MG.Jarvis.Core.Model.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Request
{
    public class Supplier
    {
        public Supplier()
        {
            this.SupplierContacts = new List<MG.Jarvis.Core.Model.Supplier.Contacts>();
            this.Banks = new List<Core.Model.Supplier.Bank>();
        }
        [ChildParameter(true)]
        public MG.Jarvis.Core.Model.Supplier.Suppliers MGSupplier { get; set; }
        [ChildParameter(true)]
        public MG.Jarvis.Core.Model.Supplier.Payment SupplierPayment { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.SupplierBanks , ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_SupplierBanks)]
        public List<MG.Jarvis.Core.Model.Supplier.Bank> Banks { get; set; }

        [StoreProcedureParamterInfo(Constants.StoredProcedureParameters.SupplierContacts , ParameterDirection.In, ParameterType.TableValued, new ParameterIncludeInAction[] { ParameterIncludeInAction.All }, Constants.StoredProcedureParameters.UT_SupplierContacts)]
        public List<MG.Jarvis.Core.Model.Supplier.Contacts> SupplierContacts { get; set; }

        
    }
}
