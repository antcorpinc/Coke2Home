using MG.Jarvis.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.DTOs
{
   public class FeaturePermission
    {
        //  public Feature Feature { get; set; }
        //  public FeaturePrivilege FeaturePrivilege { get; set; } 

        public int FeatureTypeId { get; set; }

        public string TypeName { get; set; }
        public string Label { get; set; }
        public int? ParentFeatureId { get; set; }
        public int? Order { get; set; }
        public string Privileges { get; set; }
    }
}
