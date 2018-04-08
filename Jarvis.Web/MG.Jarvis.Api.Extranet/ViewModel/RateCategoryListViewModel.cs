namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class RateCategoryListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomTypeName { get; set; }
        public string CancellationPolicyName { get; set; }
        public string MealPlanName { get; set; }
        public bool IsActive { get; set; }
        public string Markets { get; set; }
    }
}
