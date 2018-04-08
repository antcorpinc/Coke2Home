using System;
using System.Collections.Generic;
using System.Text;

namespace MG.Jarvis.Model.DTOs
{
    public class Feature
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int? ParentFeatureId { get; set; }
        public int? Order { get; set; }

    }
}
