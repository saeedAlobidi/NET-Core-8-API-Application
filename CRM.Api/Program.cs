using CRM.Api.Controllers.Common.Middleware;

using CRM.Infrastructure;
using CRM.Applications;
using CRM.Api.Controllers.Common.Filters;
 using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);


//option pattern
builder.Configuration.addConfigurationFiles();
builder.Services.addOptions(builder);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//
var services = builder.Services.BuildServiceProvider();
var dbOptions = services.GetRequiredService<IOptions<databaseOption>>();
var jwtOptions = services.GetRequiredService<IOptions<jwtOption>>();

builder.Services.addApplication();
builder.Services.addInfrastructure(dbOptions,jwtOptions);
builder.Services.AddScoped<CustomLog>();

builder.Services.AddMediatR(options =>
{
  options.RegisterServicesFromAssemblyContaining(typeof(Program));
});



builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();


app.Run();


