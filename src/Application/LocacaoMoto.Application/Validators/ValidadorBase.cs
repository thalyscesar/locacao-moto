using FluentValidation;
using LocacaoMoto.Application.Interfaces.Services;

namespace LocacaoMoto.Application.Validators
{
    public class ValidatorBase<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
        private readonly INotifier _notifier;

        public ValidatorBase(INotifier notifier)
        {
            _notifier = notifier;
        }

        public async Task<bool> IsValid(TEntity entity)
        {
            var validationResult = await this.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                _notifier.AddMessage(validationResult.Errors);
            }

            return validationResult.IsValid;
        }
    }
}
