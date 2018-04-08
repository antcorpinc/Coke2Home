using MG.Jarvis.Core.Contracts;
using MG.Jarvis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Data.Contracts
{
    public interface IFeatureTypeRepository : IRepository<FeatureType, int>
    {
        object GetApplicationRoleFeaturePrivileges(Guid applicationId,
            Guid roleId, Guid userId);
    }
}
