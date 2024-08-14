using CRM.Api.Controllers.Common.Middleware;

using CRM.Infrastructure;
using CRM.Applications;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.addApplication();
builder.Services.addInfrastructure();
builder.Services.AddMediatR(options =>
{
  options.RegisterServicesFromAssemblyContaining(typeof(Program));
});




var app = builder.Build();


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();


