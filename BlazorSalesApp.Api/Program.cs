using System.Reflection;
using BlazorSalesApp.Api.Startup;
using BlazorSalesApp.Application;
using BlazorSalesApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContext, BlazorSalesAppContext>(options =>
    options.UseSqlServer(dbConnectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(ApplicationModule).Assembly));
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationModule).Assembly));
builder.Services.AddCustomValidation(typeof(ApplicationModule).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

namespace BlazorSalesApp.Api
{
    public partial class Program { }
}