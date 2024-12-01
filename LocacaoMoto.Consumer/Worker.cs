using LocacaoMoto.Consumer.Client;
using LocacaoMoto.Consumer.Repositories;

namespace LocacaoMoto.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMottoRepository _mottoRepository;


        public Worker(ILogger<Worker> logger, IMottoRepository mottoRepository)
        {
            _logger = logger;
            _mottoRepository = mottoRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                RabbitClient rabbitClient = new RabbitClient("localhost", "moto_created" , _mottoRepository);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}