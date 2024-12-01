using FluentValidation;
using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Domain.Constants;
using LocacaoMoto.Domain.Interfaces.Repositories;

namespace LocacaoMoto.Application.Validators
{
    public class AddRentalCommandValidator : ValidatorBase<AddRentalCommand>
    {
        public AddRentalCommandValidator(INotifier notifier, IDeliveryManRepository deliveryManRepository) : base(notifier)
        {
            RuleFor(r => r.DeliveryManId).NotNull().NotEmpty();
            RuleFor(r => r.MottoId).NotNull().NotEmpty();
            RuleFor(r => r.StartDate).NotNull().NotEmpty();
            RuleFor(r => r.ExpectedEndDate).NotNull();
            RuleFor(r => r.Plan).Must(plan => plan == 7 || plan == 15 || plan == 30 || plan == 45 || plan == 50).WithMessage("Plan invalid!");
            RuleFor(r => r.DeliveryManId).Must(deliveryManId => deliveryManRepository.GetCnhTypeByIdentifier(deliveryManId) == Constansts.CNH_TYPE_A).WithMessage("Only delivery drivers qualified in category A can make a rental.");
        }
    }
}
