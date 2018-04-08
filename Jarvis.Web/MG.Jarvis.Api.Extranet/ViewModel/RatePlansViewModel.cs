using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RatePlansViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int RateCategoryId { get; set; }
        public int RoomId { get; set; }
        public bool IsSelected { get; set; }
    }
}
