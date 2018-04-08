using MG.Jarvis.Core.Model.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class Supplier
    {
        public Supplier()
        {
            this.SupplierContacts = new List<MG.Jarvis.Core.Model.Supplier.Contacts>();
            this.Banks = new List<Core.Model.Supplier.Bank>();
            this.FunctionEndpoints = new List<FunctionSupplierRelationModel>();
            this.SupplierCredentials = new List<UserRelation>();
        }


        public Suppliers MGSupplier { get; set; }
        public Payment SupplierPayment { get; set; }
        public List<Contacts> SupplierContacts { get; set; }
        public List<Bank> Banks { get; set; }
        public List<FunctionSupplierRelationModel> FunctionEndpoints { get; set; }
        public List<UserRelation> SupplierCredentials { get; set; }
    }
}
