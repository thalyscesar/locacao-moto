using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Domain.Interfaces.Repositories;
using MediatR;

namespace LocacaoMoto.Application.Handlers.Queries
{
    public class MottoQueryHandlers : IRequestHandler<GetAllQuery, IEnumerable<MottoResponse>>,
                                      IRequestHandler<GetMottoByIdQuery, MottoResponse>
    {
        private readonly IMottoRepository mottoRepository;

        public MottoQueryHandlers(IMottoRepository mottoRepository)
        {
            this.mottoRepository = mottoRepository;
        }

        public async Task<IEnumerable<MottoResponse>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var mottos = await mottoRepository.GetAllMottos();

            if (mottos.Count() == 0) return null;

            return mottos.Select(m => new MottoResponse()
            {
                Year = m.Year,
                Identifier = m.Identifier,
                LicensePlate = m.LicensePlate,
                Model = m.Model
            });

        }

        public async Task<MottoResponse> Handle(GetMottoByIdQuery request, CancellationToken cancellationToken)
        {
            var motto = await mottoRepository.GetMottoById(request);

            if (motto == null) return null;

            return new MottoResponse()
            {
                Year = motto.Year,
                Identifier = motto.Identifier,
                LicensePlate = motto.LicensePlate,
                Model = motto.Model
            };
        }
    }
}
