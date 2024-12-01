using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.DomainEvents;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Application.Validators;
using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Commands
{
    public class MottoRequestHandler : IRequestHandler<AddMottoCommand, MottoResponse?>,
                                       IRequestHandler<ModifyPlateMottoPlateCommand, string>,
                                       IRequestHandler<DeleteMottoCommand>
    {
        private readonly IMottoRepository _mottoRepository;
        private readonly INotifier _notifier;
        private readonly IMediator _mediator;
        private readonly IRentalRepository _rentalRepository;

        public MottoRequestHandler(IMottoRepository mottoRepository, INotifier notifier, IMediator mediator, IRentalRepository rentalRepository)
        {
            _mottoRepository = mottoRepository;
            _notifier = notifier;
            _mediator = mediator;
            _rentalRepository = rentalRepository;
        }

        public async Task<string> Handle(ModifyPlateMottoPlateCommand request, CancellationToken cancellationToken)
        {
            var isValid = await new ModifyLicensePlateCommandValidator(_notifier).IsValid(request);

            if (!isValid) return null;

            var motto = new Motto();
            motto.SetLicensePlate(request.LicensePlate);
            motto.SetIdentifier(request.Identifier);

            await _mottoRepository.ModifyLicencePlateMotto(motto);

            return "Placa modificada com sucesso";
        }

        public async Task<MottoResponse> Handle(AddMottoCommand request, CancellationToken cancellationToken)
        {
            var isValid = await new AddMottoCommandValidator(_mottoRepository, _notifier).IsValid(request);

            if (!isValid) return null;

            var motto = new Motto(request.Identifier, request.Year, request.Model, request.LicensePlate);

            await _mottoRepository.AddMotto(motto);
            await _mediator.Publish(new MottoCreatedEvent(request.Identifier, request.Year, request.Model, request.LicensePlate));

            return new MottoResponse()
            {
                Year = request.Year,
                Model = request.Model,
                LicensePlate = request.LicensePlate,
                Identifier = request.Identifier,
            };
        }

        public async Task Handle(DeleteMottoCommand request, CancellationToken cancellationToken)
        {
            var isValid = await new DeleteMottoCommandValidator(_notifier, _rentalRepository).IsValid(request);

            if (!isValid) return;

            var motto = new Motto();
            motto.SetIdentifier(request.Identifier);

            await _mottoRepository.DeleteMottoById(motto);
        }
    }
}
