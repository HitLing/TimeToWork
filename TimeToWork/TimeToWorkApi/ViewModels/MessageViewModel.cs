namespace TimeToWorkApi.ViewModels
{
    public class MessageViewModel
    {
        public string? Message { get; set; }
        public IList<string> RoleName { get; set; } = new List<string>();
        public string? User { get; set; }
    }
}
