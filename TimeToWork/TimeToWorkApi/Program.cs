using BLL.Entities;
using BLL.IRepositories;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeToWorkApi;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionStrings:Connection"];
builder.Services.AddDbContext<DAL.TimeToWorkContext>(opts => {
    opts.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DAL.TimeToWorkContext>();
builder.Services.AddScoped<IGenericRepository<Job>, GenericRepository<Job>>();
builder.Services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
builder.Services.AddScoped<IGenericRepository<Jobrequest>, GenericRepository<Jobrequest>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ReactPolicy");

app.UseAuthorization();

app.MapControllers();

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();
