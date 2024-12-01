using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using FluentValidation;

namespace LocacaoMoto.Application.Validators
{
    public class ModifyLicensePlateCommandValidator: ValidatorBase<ModifyPlateMottoPlateCommand>
    {
        public ModifyLicensePlateCommandValidator(INotifier notifier): base(notifier)
        {
            RuleFor(m => m.LicensePlate).NotNull().NotEmpty();
            RuleFor(m => m.Identifier).NotNull().NotEmpty();
        }
    }
}
