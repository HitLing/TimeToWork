using BLL.Entities;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace TimeToWorkApi
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            DAL.TimeToWorkContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<DAL.TimeToWorkContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Clients.Any())
            {
                context.Clients.AddRange(
                    new Client { Name = "New", Surname = "User", Phone="88005553535", Email="mail" },
                    new Client { Name = "Bistro", Surname = "Dengi", Phone = "+79024500300", Email = "mail" }
                );
                context.SaveChanges();
            }

            if (!context.Jobs.Any())
            {
                context.Jobs.AddRange(
                    new Job { Name = "Крутой", Salary = 100000, Description = "Быть крутым", JobContent = "Ну или почти" },
                    new Job { Name = "Не крутой", Salary = 100, Description = "Быть не крутым", JobContent = "Фууууууууу" }
                );
                context.SaveChanges();
            }

            if (!context.Jobrequests.Any())
            {
                context.Jobrequests.AddRange(
                    new Jobrequest { RequestDate = new DateTime(2020, 05, 05), ClientId = 2, JobId = 1 },
                    new Jobrequest { RequestDate = new DateTime(2022, 01, 01), ClientId = 1, JobId = 2 }
                );
                context.SaveChanges();
            }
        }
    }
}