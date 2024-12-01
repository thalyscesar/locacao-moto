using LocacaoMoto.Consumer.Events;
using LocacaoMoto.Consumer.Repositories;
using Newtonsoft.Json;

namespace LocacaoMoto.Consumer.Client
{
    public class RabbitClient : RabbitBase
    {
        private readonly IMottoRepository _mottoRepository;

        public RabbitClient(string hostName, string queueName, IMottoRepository mottoRepository) : base(hostName, queueName)
        {
            _mottoRepository = mottoRepository;
        }

        public override async void ProcessMessage(string message)
        {
            var mottoCreated = JsonConvert.DeserializeObject<MottoCreatedEvent>(message);

            if (mottoCreated != null && mottoCreated.Year == 2024)
            {
                await _mottoRepository.Add(mottoCreated);
            }            
        }
    }
}
