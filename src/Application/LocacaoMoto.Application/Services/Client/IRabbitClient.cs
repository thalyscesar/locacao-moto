namespace LocacaoMoto.Application.Services.Client
{
    public interface IRabbitClient
    {
        void SendMessage<T>(T obj) where T : class;
    }
}
