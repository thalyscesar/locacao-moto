using FluentValidation;
using LocacaoMoto.Application.Commands;
using FluentValidation;

namespace LocacaoMoto.Application.Validators
{
    public class AddDeliveryManCommandValidator : AbstractValidator<AddDeliveryManCommand>
    {
        public AddDeliveryManCommandValidator()
        {

        }

//        Os tipos de cnh válidos são A, B ou ambas A+B.
//O cnpj é único e não pode se repetir.
//O número da CNH é único e não pode se repetir.
    }
}
