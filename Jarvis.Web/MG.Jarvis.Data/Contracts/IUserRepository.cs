using MG.Jarvis.Core.Contracts;
using MG.Jarvis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Data.Contracts
{
   public interface IUserRepository : IRepository<JarvisUser,Guid>
    {
        // ToDo: Add User Specific Methods

    }
}
