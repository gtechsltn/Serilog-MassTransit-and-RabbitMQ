using MassTransit;
using CentralLoggerSystem.Consumers;
using CentralLoggerSystem.Models;
using CentralLoggerSystem.Services;
using Serilog;
using CentralLoggerSystem.Repositorys;
using CentralLoggerSystem.Data;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console() // Log to console
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();

// Add MassTransit and configure RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<LogConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("example-queue", e =>
        {
            e.ConfigureConsumer<LogConsumer>(context);
        });
    });
});

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ILoggerService, LoggerService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseSerilog();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware to log incoming requests

app.MapControllers();



app.Run();
