using MG.Jarvis.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Service.BackOffice.Contracts
{
   public interface IUserService
    {
        UserDetails GetUserDetails(Guid id);
        bool ActiveUsersByDate(DateTime activationDate);
        bool DeactiveUsersByDate(DateTime activationDate);
        
    }
}
