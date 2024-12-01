using LocacaoMoto.Application.Commands;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Commands
{
    public class RentalRequestHandler : IRequestHandler<AddRentalCommand>,
                                       IRequestHandler<CalculateMottoRentalValueCommand, decimal>
    {
        public RentalRequestHandler()
        {

        }

        public Task Handle(AddRentalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> Handle(CalculateMottoRentalValueCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
