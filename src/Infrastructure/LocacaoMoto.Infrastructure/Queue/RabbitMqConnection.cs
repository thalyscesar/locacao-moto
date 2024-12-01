using RabbitMQ.Client;

namespace LocacaoMoto.Infrastructure.Queue
{
    public class RabbitMqConnection 
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public IModel Channel => _channel;

        public RabbitMqConnection(string hostName = "localhost", string userName = "guest", string password = "guest", string queueName = "default_queue")
        {
            var factory = new ConnectionFactory() { HostName = hostName, UserName = userName, Password = password };
            using var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}