// See https://aka.ms/new-console-template for more information
using MiddleWareMessenger;
using MiddleWareMessenger.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");
var factory = new ConnectionFactory();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("NotificationServe", true, false, false);
channel.QueueBind("NotificationServe", "CargoExchange", "Malaysia.*");
var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (sender, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var msg = System.Text.Encoding.UTF8.GetString(body);
    var sku = msg.Split(";").Last();
    Console.WriteLine($"{eventArgs.RoutingKey}: {msg}");
    var delivery = new Delivery { SKU = sku, RegionAddress = eventArgs.RoutingKey };
    RequestSender requestSender = new RequestSender();
    await requestSender.PostRequestAync(delivery);
};

channel.BasicConsume("NotificationServe", true, consumer);
Console.ReadKey();
channel.Close();
channel.Close();
