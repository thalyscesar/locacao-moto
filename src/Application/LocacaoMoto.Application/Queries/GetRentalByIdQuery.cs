using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Queries
{
    public class GetRentalByIdQuery : IRequest<RentalResponse>
    {
        public int Id { get; set; }
    }
}
