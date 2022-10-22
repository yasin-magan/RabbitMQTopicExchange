using RabbitMQ.Client;

namespace CargoShipment.Services
{
    public interface IRabbitMQMessagingService
    {
        void DeclareExchangeChannel();
        void SendMessage(string routingKeys, string message);
        IModel GetExchangeChannel();
        IModel GetConsumerChannel();
        void CloseConnection();
    }
}
