using System;

namespace MG.Jarvis.Api.Extranet.Models.Request
{
    public class ExpiredContracts
    {
        public DateTime NotificationDate  { get; set; }
        public int ExpiryWarningDays { get; set; }
    }
}
