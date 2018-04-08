using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class Department :Base.Department
    {
        public Guid Id { get; set; }
    }
}
