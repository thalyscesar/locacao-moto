using FluentValidation;
using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Application.Queries;
using LocacaoMoto.Domain.Interfaces.Repositories;

namespace LocacaoMoto.Application.Validators
{
    public class AddMottoCommandValidator: ValidatorBase<AddMottoCommand>
    {
        public AddMottoCommandValidator(IMottoRepository mottoRepository, INotifier notifier ):base(notifier)
        {
            RuleFor(m => m.Identifier).NotEmpty().NotNull();
            RuleFor(m => m.Year).GreaterThan(0);
            RuleFor(m => m.Model).NotEmpty().NotNull();
            RuleFor(m => m.LicensePlate).NotEmpty().NotNull();
            RuleFor(m => m).Must(m => !mottoRepository.AnyLicencePlateAsync(m.LicensePlate)).WithMessage("motorcycle plate must be unique");
        }
    }
}
