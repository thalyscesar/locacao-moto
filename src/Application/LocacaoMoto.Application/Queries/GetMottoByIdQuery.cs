using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Queries
{
    public class GetMottoByIdQuery: IRequest<MottoResponse>
    {
        public string Identifier { get; set; }

        public GetMottoByIdQuery(string identifier)
        {
            Identifier = identifier;
        }
    }
}
