using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models.Base
{
    public class Feature : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Order { get; set; }
        public int? ParentFeatureId { get; set; }
       
    }
}
