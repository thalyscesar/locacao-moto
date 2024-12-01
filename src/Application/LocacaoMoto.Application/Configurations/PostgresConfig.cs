namespace LocacaoMoto.Application.Configurations
{
    public class PostgresConfig
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public int Timeout { get; set; }

    }
}