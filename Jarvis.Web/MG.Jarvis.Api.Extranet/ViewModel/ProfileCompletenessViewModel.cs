using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ProfileCompletenessViewModel
    {
        public ProfileCompletenessViewModel()
        {
            Criteria = new List<ProfileCompletenessDetailsViewModel>();
        }
        public List<ProfileCompletenessDetailsViewModel> Criteria { get;}
    }
}
