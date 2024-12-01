using LocacaoMoto.Application.Responses;
using LocacaoMoto.Domain.Enums;
using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class AddDeliveryManCommand: IRequest<DeliveryManResponse>
    {
        public string Identifier { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string CNPJ { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; } 
        public string CNHNumber { get; set; } = String.Empty;
        public string CNHType { get; set; } = String.Empty;

    }
}
