using LocacaoMoto.Application.Commands;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Commands
{
    public class DeliveryManRequestHandler : IRequestHandler<AddDeliveryManCommand>,
                                            IRequestHandler<PostPictureCNHCommand>
    {
        public DeliveryManRequestHandler()
        {

        }

        public Task Handle(AddDeliveryManCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(PostPictureCNHCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
