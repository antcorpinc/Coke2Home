using MG.Jarvis.Core.Contracts;
using MG.Jarvis.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Data.Contracts
{
   public interface IApplicationRepository : IRepository<Application, Guid>
    {
    }
}
