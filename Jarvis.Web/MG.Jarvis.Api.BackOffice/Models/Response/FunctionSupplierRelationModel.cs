using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Models.Response
{
    public class FunctionSupplierRelationModel : MG.Jarvis.Core.Model.Supplier.FunctionSupplierRelation
    {
        public string FunctionName { get; set; }
    }

}
