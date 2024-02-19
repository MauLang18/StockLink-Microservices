using MassTransit;
using StockLink.Mail.Api.Services;
using StockLink.Mail.Application.Extensions;
using StockLink.Shared.Entities;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
var Cors = "Cors";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInjectionApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

builder.Services.AddMassTransit(conf =>
{
    conf.SetKebabCaseEndpointNameFormatter();

    var asb = typeof(Program).Assembly;

    conf.AddConsumers(asb);

    conf.UsingRabbitMq((ctx,cfg) =>
    {
        cfg.Host("rabbitmq3", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("pedido_mail_record", e =>
        {
            e.ConfigureConsumer<ConsumerService>(ctx);
        });

        cfg.ConfigureEndpoints(ctx);
    });
});

var app = builder.Build();

app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
