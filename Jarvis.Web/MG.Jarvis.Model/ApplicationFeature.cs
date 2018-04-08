using MG.Jarvis.Core.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// All the Features in the application Ex. Extranet will have set of features ,similarly for BO
/// </summary>
namespace MG.Jarvis.Model
{
    [Table("ApplicationFeature",Schema = "AccessPermission")]
    public class ApplicationFeature : IIdentifiableModel<Guid>
    {        
        [Key]
        public Guid Id {get;set;}
        
        public int FeatureTypeId {get;set;}

        public Guid ApplicationId {get;set;}
        public bool IsDeleted { get; set; }

        //Relationship

        [ForeignKey("FeatureTypeId")]
        public FeatureType FeatureType { get; set; }

        [ForeignKey("ApplicationId")]
         public Application Application { get; set; }
     
    }
}