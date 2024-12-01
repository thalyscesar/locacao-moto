using LocacaoMoto.Application.DomainEvents;
using LocacaoMoto.Application.Services.Client;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Events
{
    public class MottoCreatedEventHandler: INotificationHandler<MottoCreatedEvent>
    {
        private readonly IRabbitClient _client;

        public MottoCreatedEventHandler(IRabbitClient rabbitClient)
        {
            _client = rabbitClient;
        }

        public Task Handle(MottoCreatedEvent notification, CancellationToken cancellationToken)
        {
            _client.SendMessage(notification);
            return Task.CompletedTask;
        }
    }
}
