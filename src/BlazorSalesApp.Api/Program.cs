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

const string corsPolicyName = "DefaultCorsPolicy";
var allowedOrigins = builder.Configuration
    .GetSection("AllowedOrigins")
    .GetChildren()
    .Select(conf => conf.Value!)
    .ToArray();
builder.Services.AddCors(options =>
    options.AddPolicy(name: corsPolicyName,
        policy =>
            policy
                .WithOrigins(allowedOrigins)
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(corsPolicyName);

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

namespace BlazorSalesApp.Api
{
    public partial class Program { }
}