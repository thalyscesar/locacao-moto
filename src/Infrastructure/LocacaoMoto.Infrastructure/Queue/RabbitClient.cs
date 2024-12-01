using LocacaoMoto.Application.Configurations;
using LocacaoMoto.Application.Services.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace LocacaoMoto.Infrastructure.Queue
{
    public class RabbitClient: IRabbitClient
    {
        private static IConnection _connection;
        private static IModel _channel;
        private static readonly object _lock = new object();

        private readonly RabbitConfig rabbitConfig;

        public RabbitClient(IOptions<RabbitConfig> options)
        {
            rabbitConfig = options.Value;

            if (_connection == null || !_connection.IsOpen)
            {
                lock (_lock)
                {
                    if (_connection == null || !_connection.IsOpen)
                    {
                        var factory = new ConnectionFactory() { HostName = options.Value.HostName };
                        _connection = factory.CreateConnection();
                        _channel = _connection.CreateModel();
                        _channel.QueueDeclare(queue: options.Value.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    }
                }
            }
        }

        public void SendMessage<T>(T obj) where T : class
        {
            if (_connection == null || !_connection.IsOpen)
            {
                throw new InvalidOperationException("RabbitMQ connection is not open.");
            }

            string json = JsonConvert.SerializeObject(obj);

            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: string.Empty, routingKey: rabbitConfig.QueueName, body: body);
           
        }
    }
}
