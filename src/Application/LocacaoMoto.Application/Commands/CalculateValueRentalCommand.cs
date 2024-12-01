using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class CalculateMottoRentalValueCommand : IRequest<decimal>
    {
        public DateTime ReturnDate { get; set; }
    }
}
