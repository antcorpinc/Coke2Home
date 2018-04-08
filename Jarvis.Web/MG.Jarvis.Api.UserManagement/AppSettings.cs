using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement
{
    public class AppSettings
    {
        public int MGUserType { get; set; }
        public int HotelUserType { get; set; }
        public int AgentUserType { get; set; }
        public string MGDefaultPassword { get; set; }
        public string HotelDefaultPassword { get; set; }
        public string AgentDefaultPassword { get; set; }

        public string BookingEngineAppName { get; set; }
        public string ExtranetAppName { get; set; }
    }
}
