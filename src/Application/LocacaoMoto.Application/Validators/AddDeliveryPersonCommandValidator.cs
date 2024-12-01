using FluentValidation;
using LocacaoMoto.Application.Commands;
using LocacaoMoto.Application.Interfaces.Services;
using LocacaoMoto.Domain.Constants;
using LocacaoMoto.Domain.Interfaces.Repositories;

namespace LocacaoMoto.Application.Validators
{
    public class AddDeliveryManCommandValidator : ValidatorBase<AddDeliveryManCommand>
    {
        public AddDeliveryManCommandValidator(IDeliveryManRepository deliveryManRepository, INotifier notifier):base(notifier)
        {
            RuleFor(d => d.CNHType).Must(cnhType => cnhType == Constansts.CNH_TYPE_A || cnhType == Constansts.CNH_TYPE_B || cnhType == Constansts.CNH_TYPE_AB).WithMessage("CNH type invalid!");
            RuleFor(d => d.CNPJ).Must(cnpj => !deliveryManRepository.HasCnpjNumber(new Queries.HasCNPJQuery() { CNPJNumber = cnpj })).WithMessage("CNPj already exists registered");
            RuleFor(d => d.CNHNumber).Must(licenseNumber => !deliveryManRepository.HasCNHNumber(new Queries.HasCNHNumberQuery() { CNHNumber = licenseNumber })).WithMessage("License number already exists registered");
        }
    }
}
