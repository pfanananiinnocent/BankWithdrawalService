using BankWithdrawalService.Data;
using BankWithdrawalService.Repositories;
using BankWithdrawalService.Services;
using Microsoft.EntityFrameworkCore;
using Amazon.SimpleNotificationService;
using Amazon.Extensions.NETCore.Setup; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSimpleNotificationService>(); 

// Database Configuration
builder.Services.AddDbContext<BankDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=BankDb;User Id=sa;Password=yourpassword;"));

// Dependency Injection
builder.Services.AddScoped<BankAccountRepository>();
builder.Services.AddScoped<BankAccountService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
