using CargoShipment.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Channels;

namespace CargoShipment.Services
{

    public class RabbitMQMessagingService : IRabbitMQMessagingService
    {
        private IModel? _channel;
        private IModel? _consumerChannel;
        private IConnection? _connection;
        private readonly CargoContext _context;
        public RabbitMQMessagingService(CargoContext context)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _context = context;
        }

        public void SendMessage(string routingKey, string message)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("CargoExchange", routingKey, null, bytes);
 
        }

        public void DeclareExchangeChannel( )
        {
            if (_connection == null) return;
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare("CargoExchange", ExchangeType.Topic, true);

        }
        public IModel GetExchangeChannel()
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            if (_connection == null) return;
            _connection.Close();
        }

        public IModel GetConsumerChannel()
        {
            if (_consumerChannel==null)  return null; 
            return _consumerChannel;
        }
        //public void Comsumer ()
        //{
        //    var consumer = new EventingBasicConsumer(_consumerChannel);
        //    consumer.Received += (sender, eventArgs) =>
        //    {
        //        var encoding = new System.Text.UTF8Encoding();

        //        var body = eventArgs.Body.ToArray();
        //        var message = encoding.GetString(body);
              
              
        //        Console.WriteLine($"{eventArgs.RoutingKey}: {message}");
        //    };

        //    _consumerChannel.BasicConsume("NotificationServe", true, consumer);
          
        //}
        public async Task<Delivery> AddDliver(Delivery delivery)
        {
            _context.Deliverys.Add(delivery);
            await _context.SaveChangesAsync();
            return delivery;

        }
    }

}
