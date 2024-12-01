using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class CalculateMottoRentalValueCommand : IRequest<decimal>
    {
        public DateTime EndDate { get; set; }
        public int Id { get; set; }
    }
}
