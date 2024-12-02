using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace LocacaoMoto.Consumer.Client
{
    public abstract class RabbitBase
    {
        private static IConnection _connection;
        private static IModel _channel;
        private static readonly object _lock = new object();

        public abstract void ProcessMessage(string message);

        public RabbitBase(string hostName, string queueName)
        {

            if (_connection == null || !_connection.IsOpen)
            {
                lock (_lock)
                {
                    if (_connection == null || !_connection.IsOpen)
                    {
                        var factory = new ConnectionFactory() { HostName = hostName };
                        _connection = factory.CreateConnection();
                        _channel = _connection.CreateModel();
                        _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                        var consumer = new EventingBasicConsumer(_channel);
                        consumer.Received += OnMessageReceived;

                        _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

                    }
                    
                }
            }
            if(_connection != null || !_connection.IsOpen)
            {
               
            }
        }

        private void OnMessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            
            Console.WriteLine($"Mensagem recebida: {message}");

            ProcessMessage(message);

            _channel.BasicAck(e.DeliveryTag, false);
            
        }
    }
}
