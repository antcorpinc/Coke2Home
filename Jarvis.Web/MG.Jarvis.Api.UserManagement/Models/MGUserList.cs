using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class MGUserList : Base.UserList
    {
        public MGUserList()
        {
            this.Departments = new List<UserDepartments>();
        }

        public int EmployeeId { get; set; }
        public ICollection<UserDepartments> Departments { get; set; }
    }
}
