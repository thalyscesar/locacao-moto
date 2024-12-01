using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class ModifyPlateMottoPlateCommand : IRequest<string>
    {
        public string Identifier { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
    }
}
