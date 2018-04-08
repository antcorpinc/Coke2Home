using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.DTOs
{
   public class ApplicationPermission
    {
        public ApplicationPermission()
        {
            FeaturePermissions = new Dictionary<int, FeaturePermission>();
            FeaturesList = new List<FeaturePermission>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string Role { get; set; }
        public Guid RoleId { get; set; }
        public Dictionary<int, FeaturePermission> FeaturePermissions { get; set; }

        public List<FeaturePermission> FeaturesList { get; set; }

        

    }
}
