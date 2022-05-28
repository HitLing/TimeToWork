using Microsoft.AspNetCore.Identity;

namespace BLL.Entities
{
    public class User : IdentityUser
    {
        public List<Jobrequest> Payments { get; set; } = new();
    }
}
