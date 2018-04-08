using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models.Base
{
    public class Department : BaseModel
    {
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
