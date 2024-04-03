using Buying.Infrastructure.Common.Extensions;
using Buying.Application.Common.Extensions;
using Buying.Api.Common.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.Configure<RouteOptions>(option => option.LowercaseUrls = true);

builder.Services.AddControllers(option =>
{
    option.Filters.Add(typeof(ExceptionFilter));
    option.Filters.Add(typeof(ValidationFilter));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();