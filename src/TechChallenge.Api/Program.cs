using Npgsql;
using Prometheus;
using System.Data;
using TechChallenge.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDependencyInjection();
builder.Services.AddScoped<IDbConnection>((sp) =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("TechChallengeDb")));


builder.Services.UseHttpClientMetrics();


builder.Services.AddHealthChecks()
    .ForwardToPrometheus();



var app = builder.Build();

var counter = Metrics.CreateCounter("webapimetric", "Contador de requests",
    new CounterConfiguration
    {
        LabelNames = new[] { "method", "endpoint" }
    });

app.Use((context, next) =>
{
    counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
    return next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpMetrics();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapMetrics(settings => settings.EnableOpenMetrics = false);

app.Run();

public partial class Program { }