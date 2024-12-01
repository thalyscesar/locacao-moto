using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Queries
{
    public class RentalQueryHandler : IRequestHandler<GetRentalByIdQuery, RentalResponse>
    {
        public RentalQueryHandler()
        {

        }

        public Task<RentalResponse> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
