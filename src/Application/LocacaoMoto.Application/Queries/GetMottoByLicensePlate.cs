using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Queries
{
    public class GetMottoByLicensePlateQuery: IRequest<MottoResponse>
    {
        public GetMottoByLicensePlateQuery(string licensePlate)
        {
            LicensePlate = licensePlate;
        }

        public string LicensePlate { get; set; }
    }
}
