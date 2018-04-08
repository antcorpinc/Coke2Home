using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Interfaces
{
    public interface IIdentifiableModel<T>
    {
        T Id { get; set; }
    }
}
