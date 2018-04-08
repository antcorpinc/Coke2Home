using MG.Jarvis.Core.Contracts;
using MG.Jarvis.Model;
using MG.Jarvis.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Data.Contracts
{
   public interface IRoleRepository : IRepository<JarvisRole, Guid>
    {
        // object GetRelatedPrivilegesForRoleAndApp(Guid roleId, Guid appId);
        List<RolePrivilege> GetRelatedPrivilegesForRoleAndApp(Guid roleId, Guid appId);
    }
}
