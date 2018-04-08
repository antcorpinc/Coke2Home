using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Helper
{
    public static class Enums
    {
        public enum EntityState
        {
            New=0,
            Inserted
        }
        public enum ContractType
        {
            MgStatic=0,
            MgDynamic,
            NonMg
        }
        public enum NumberOfGuest
        {
            One=1,Two,Three,Four,Five,Six,Seven,Eight
        }
    }
}
