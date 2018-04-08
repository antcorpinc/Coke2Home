namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class MealPlanViewModel : BaseViewModel
    {
        public int MealId { get; set; }
        public bool IsSelected { get; set; }
        public MealOptionViewModel MealPlanOptions { get; set; }
    }
}
