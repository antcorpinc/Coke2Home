namespace MG.Jarvis.Api.Extranet.ViewModel
{
    public class ContactDetailsViewModel : BaseViewModel
    {
        public int ContactId { get; set; }
        public bool IsPrimary { get; set; }
        public string ContactPerson { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public int DesignationId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
