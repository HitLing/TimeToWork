using BLL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TimeToWorkContext : IdentityDbContext<User>
    {
        public TimeToWorkContext(DbContextOptions<TimeToWorkContext> options)
            : base(options) { }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Jobrequest> Jobrequests => Set<Jobrequest>();
    }
}
