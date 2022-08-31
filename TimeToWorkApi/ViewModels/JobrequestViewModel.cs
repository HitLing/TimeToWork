namespace TimeToWorkApi.ViewModels
{
    public class JobrequestViewModel
    {
        public int JobrequestId { get; set; }
        public string? ClientFullName { get; set; }
        public DateTime PaymentDate { get; set; }
        public float TotalCost { get; set; }
        public int ClientId { get; set; }
        public int JobId { get; set; }
        public string? JobName { get; set; }

    }
}
