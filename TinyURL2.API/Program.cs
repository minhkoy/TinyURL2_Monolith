using Microsoft.EntityFrameworkCore;
using TinyURL2.API.Middlewares;
using TinyURL2.Business;
using TinyURL2.Infrastructure;
using TinyURL2.Infrastructure.DbContexts;
using TinyURL2_Monolith.ServiceDefaults;

//if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GOOGLE_API_KEY")))
//{
//    Environment.SetEnvironmentVariable("GOOGLE_API_KEY", "AIzaSyA_9Ts_Onnh1bRubRJ7XX0DwIKPeNTeeFc");
//}
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
var services = builder.Services;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
services.AddDbContext<UrlDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["TinyDb:ConnectionString"]);
});
services.AddBusinessServices();
services.AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseErrorHandlingMiddleware();

await app.RunAsync();
