using System;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class MessagesViewModel
    {
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageTypeName { get; set; }
        public string MessageDescription { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string LastModifiedBy { get; set; }
    }
}

