using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class HotelAssociateMealPlanViewModel
    {
        public HotelAssociateMealPlanViewModel()
        {
            this.CuisineTypeIds = new List<int>();
        }
        public int HotelId { get; set; }
        public int MealId { get; set; }
        public int CurrencyId { get; set; }
        public double Price { get; set; }
        public List<int> CuisineTypeIds { get; }
    }
}
