using PermissionManagement.API.Extensions;
using PermissionManagement.API.Middleware;
using PermissionManagement.Application;
using PermissionManagement.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfraestructure(builder.Configuration);

builder.Services.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCustomException();

app.UseRegistryInfoRequest();

app.MapControllers();

app.Run();
