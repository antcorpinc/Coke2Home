using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class MealOptionViewModel : BaseViewModel
    {
        public MealOptionViewModel()
        {
            this.CuisineOptions = new List<CuisineTypeViewModel>();
        }
        public int? CurrencyId { get; set; }
        public double Price { get; set; }
        public List<CuisineTypeViewModel> CuisineOptions { get; }
    }
}
