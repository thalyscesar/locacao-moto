using FluentValidation;
using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Domain.Constants;

namespace LocacaoMoto.Application.Validators
{
    public class SendImageCNHCommandValidator : ValidatorBase<SendImageCNHCommand>
    {
        public SendImageCNHCommandValidator(INotifier notifier) : base(notifier)
        {
            RuleFor(s => s.ContentyType).Must(c => c == Constansts.EXTENSION_BPM || c == Constansts.EXTENSION_PNG).WithMessage("The file format must be png or bmp.");
        }
    }
}
