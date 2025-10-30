
using Job_Tracker_Api.Controllers.Repositories;
using Job_Tracker_Api.Controllers.Repositories.RepositoriesImpl;
using Job_Tracker_Api.Controllers.Services;
using Job_Tracker_Api.Controllers.Services.ServicesImpl;
using Job_Tracker_Api.Data;
using Job_Tracker_Api.Model.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddTransient<IAccountService, AccountServiceImpl>();
builder.Services.AddTransient<IApplicationService, ApplicationServiceImpl>();
builder.Services.AddTransient<IAccountRepository, AccountRepositoryImpl>();
builder.Services.AddTransient<IApplicationRepository, ApplicationRepositoryImpl>();

var app = builder.Build();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();