using CargoShipment.Models;
using CargoShipment.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var messengder =builder.Services.AddTransient<IRabbitMQMessagingService, RabbitMQMessagingService>();
//builder.Services.AddTransient<IDeliveryRegionService, DeliveryRegionService>();

builder.Services.AddDbContext<CargoContext>(options =>
{
    options.UseInMemoryDatabase("Cargo");
});

var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var serviceInitialzer = scope.ServiceProvider.GetRequiredService<IRabbitMQMessagingService>();
    // use dbInitializer
    serviceInitialzer.DeclareExchangeChannel();
}
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
