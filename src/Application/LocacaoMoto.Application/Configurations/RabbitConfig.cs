namespace LocacaoMoto.Application.Configurations
{
    public class RabbitConfig
    {
        public string HostName { get; set; } = string.Empty;
        public string QueueName { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
