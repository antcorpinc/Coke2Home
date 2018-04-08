using MG.Jarvis.Api.UserManagement.Models.Base;
using System;
using System.Collections.Generic;

namespace MG.Jarvis.Api.UserManagement.Models
{
    public class MGUser : Base.User
    {
        public MGUser()
        {
            this.Departments = new List<Base.UserDepartments>();
            this.UserApplicationRole = new List<Base.UserApplicationRole>();
        }

        
        public int? EmployeeId { get; set; }
        ///// <summary>
        ///// User application and its roles for which he has access.
        ///// </summary>
        public ICollection<Base.UserApplicationRole> UserApplicationRole { get; set; }
        public ICollection<Base.UserDepartments> Departments { get; set; }
    }
}
