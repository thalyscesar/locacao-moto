using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Domain.Interfaces.Repositories;
using FluentValidation;

namespace LocacaoMoto.Application.Validators
{
    public class DeleteMottoCommandValidator : ValidatorBase<DeleteMottoCommand>
    {
        public DeleteMottoCommandValidator(INotifier notifier, IRentalRepository rentalRepository) : base(notifier)
        {
            RuleFor(d => d.Identifier).NotEmpty().NotNull();
            RuleFor(d => d).Must(c => !rentalRepository.HasRentalMotto(c.Identifier)).WithMessage("Motorcycle rental is already available");
        }
    }
}
