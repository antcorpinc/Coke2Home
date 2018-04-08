using MG.Jarvis.Api.Extranet.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using static MG.Jarvis.Api.Extranet.Helper.Enums;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class TemplateClauseLibraryViewModel
    {
        public int TemplateId { get; set; }
        public int ClauseLibraryId { get; set; }
        public Boolean IsSelected { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsConfigurable { get; set; }
        public int Order { get; set; }
        public EntityState Status { get; set; }
        [Required]
        public ObjectState? ObjectState { get; set; }
    }
}
