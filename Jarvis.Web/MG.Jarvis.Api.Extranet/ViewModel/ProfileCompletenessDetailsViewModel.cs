using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ProfileCompletenessDetailsViewModel
    {
        public int ConfigurationId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        //public bool IsActive { get; set; }
        public string RedirectUrl { get; set; }
        public string RedirectUrlText { get; set; }
        public bool IsFullfilled { get; set; }
        public string Description { get; set; }
    }
}
