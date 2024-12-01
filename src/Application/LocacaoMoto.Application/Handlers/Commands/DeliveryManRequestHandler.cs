using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Application.Validators;
using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Commands
{
    public class DeliveryManRequestHandler : IRequestHandler<AddDeliveryManCommand, DeliveryManResponse>,
                                            IRequestHandler<SendImageCNHCommand>
    {
        private readonly IDeliveryManRepository _deliveryManRepository;
        private readonly INotifier _notifier;

        public DeliveryManRequestHandler(IDeliveryManRepository deliveryManRepository, INotifier notifier)
        {
            _deliveryManRepository = deliveryManRepository;
            _notifier = notifier;
        }

        public async Task<DeliveryManResponse> Handle(AddDeliveryManCommand request, CancellationToken cancellationToken)
        {
            var isValid = await new AddDeliveryManCommandValidator(_deliveryManRepository, _notifier).IsValid(request);

            if (!isValid) return null;

            var deliveryMan = new DeliveryMan(
                request.Identifier,
                request.Name,
                request.CNPJ,
                request.DateOfBirth,
                request.CNHNumber,
                request.CNHType,
                null);

            await _deliveryManRepository.AddDeliveryMan(deliveryMan);

            return new DeliveryManResponse()
            {
                CNHNumber = request.CNHNumber,
                CNHType = request.CNHType,
                CNPJ = request.CNPJ,
                DateOfBirth = request.DateOfBirth,
                Identifier = request.Identifier,
                Name = request.Name
            };
        }

        public async Task Handle(SendImageCNHCommand request, CancellationToken cancellationToken)
        {
            var isValid = await new SendImageCNHCommandValidator(_notifier).IsValid(request);

            if (!isValid) return;

            var imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "cnh");

            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            string fileName = request.Identifier + ".png";
            string filePath = Path.Combine(imageDirectory, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await request.Stream.CopyToAsync(fileStream);
            }

            var deliveryMan = new DeliveryMan();
            deliveryMan.SetIdentifier(request.Identifier);
            deliveryMan.SetCNHImage(fileName);

            await _deliveryManRepository.UpdatePathCnhImage(deliveryMan);
        }
    }
}
