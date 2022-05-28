namespace TimeToWorkApi.ViewModels
{
    public class UserViewModel
    {
        public string? Email { get; set; }
        public int Year { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public bool RememberMe { get; set; }
        public string? RoleName { get; set; }
    }
}
