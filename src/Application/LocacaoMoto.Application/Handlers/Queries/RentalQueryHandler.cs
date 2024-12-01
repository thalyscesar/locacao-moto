using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Domain.Interfaces.Repositories;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Queries
{
    public class RentalQueryHandler : IRequestHandler<GetRentalByIdQuery, RentalResponse>
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalQueryHandler(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<RentalResponse> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetRentalById(request.Id);

            return new RentalResponse()
            {
                Id = rental.Id,
                DeliveryManId = rental.IdentifierDeliveryMan,
                EndDate = rental.EndDate,
                ExpectedEndDate = rental.ExpectedEndDate,
                MottoId = rental.IdentifierMotto,
                Plan = rental.Plan,
                StartDate = rental.StartDate
            };
        }
    }
}
