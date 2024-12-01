using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class AddMottoCommand: IRequest<MottoResponse>
    {
        public string Identifier { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }

        public AddMottoCommand(string identifier, int year, string model, string licensePlate)
        {
            Identifier = identifier;
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }
    }
}
