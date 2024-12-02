using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Application.Validators;
using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Commands
{
    public class RentalRequestHandler : IRequestHandler<AddRentalCommand, RentalResponse>,
                                       IRequestHandler<CalculateMottoRentalValueCommand, decimal>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly INotifier _notifier;
        private readonly IDeliveryManRepository _deliveryManRepository;

        public RentalRequestHandler(IRentalRepository rentalRepository, INotifier notifier, IDeliveryManRepository deliveryManRepository)
        {
            _rentalRepository = rentalRepository;
            _notifier = notifier;
            _deliveryManRepository = deliveryManRepository;
        }

        public async Task<RentalResponse> Handle(AddRentalCommand request, CancellationToken cancellationToken)
        {
            var isValid = await new AddRentalCommandValidator(_notifier, _deliveryManRepository).IsValid(request);

            if (!isValid) return null;

            var rental = new Rental(
                0,
                DateTime.Now.Date.ToUniversalTime(),
                DateTime.Now.Date.AddDays(1).ToUniversalTime(),
                request.EndDate.ToUniversalTime(),
                request.ExpectedEndDate.Date.ToUniversalTime(),
                request.MottoId,
                request.DeliveryManId,
                request.Plan);

            var id = await _rentalRepository.AddRental(rental);

            return new RentalResponse()
            {
                Id = id,
                DeliveryManId = request.DeliveryManId,
                EndDate = request.EndDate,
                ExpectedEndDate = request.ExpectedEndDate,
                MottoId = request.MottoId,
                Plan = request.Plan,
                StartDate = request.StartDate
            };
        }

        public async Task<decimal> Handle(CalculateMottoRentalValueCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetRentalById(request.Id);
            rental.SetExpectedEndDate(request.ReturnDate);

           var dailyRates = rental.CalculateDailyValue();

            await _rentalRepository.UpdateReturndDate(rental);

            return dailyRates;
        }
    }
}
