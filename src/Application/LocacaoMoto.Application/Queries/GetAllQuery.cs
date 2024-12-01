using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Queries
{
    public class GetAllQuery: IRequest<IEnumerable<MottoResponse>>
    {
    }
}
