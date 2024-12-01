using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Queries
{
    public class GetRentalByIdQuery: IRequest<RentalResponse>
    {
        public string Identifier { get; set; } = string.Empty;
    }
}
