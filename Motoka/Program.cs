using Microsoft.EntityFrameworkCore;
using Motoka.BackgroundTask;
using Motoka.BackgroundTask.Interface;
using Motoka.Domain;
using Motoka.Domain.IRepository;
using Motoka.Postgres;
using Motoka.RabbitMq;
using Motoka.RabbitMq.Interfaces;
using Motoka.RabbitMq.ObjectValues;
using Motoka.Service;
using Motoka.Service.Interface;
using RabbitMQ.Client;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PostgresContext>();

var connectionFactory = new ConnectionFactory
{
    HostName = "127.0.0.1",
    UserName = "motoka",
    Password = "motoka",
    Port = 5672

};
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.AddSingleton<IRabbitConnection>(sp => { return new RabbitConnection(connectionFactory); });

builder.Services.AddSingleton<IRabbitConsumer, RabbitConsumer>();
builder.Services.AddSingleton<IRabbitPublisher, RabbitPublisher>();
// Add background services to consume messages in rabbit queue.
builder.Services.AddHostedService<RabbitConsumerTask>();

builder.Services.AddScoped<IVehiclesRepository, GestaoRepository>();
builder.Services.AddScoped<IVehiclesService, VehiclesService>();
builder.Services.AddScoped<IDeliveryDriverRepository, DeliveryDriverRepository>();
builder.Services.AddScoped<IDeliveryDriverService, DeliveryDriverService>();
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRentService, RentService>();
builder.Services.AddScoped<IOrderNotificationRepository, OrderNotificationRepository>();
builder.Services.AddScoped<IRentService, RentService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderNotificationService, OrderNotificationService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options => {

    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies(); 
    });

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

app.Run();
