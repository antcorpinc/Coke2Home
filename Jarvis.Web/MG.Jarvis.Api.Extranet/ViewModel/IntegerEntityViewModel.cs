using System;
using System.ComponentModel.DataAnnotations;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class IntegerEntityViewModel
    {
        [Required]
        [Range(1,Int32.MaxValue)]
        public int? Id { get; set; }
    }
}
