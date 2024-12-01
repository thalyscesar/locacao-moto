using LocacaoMoto.Application.Responses;
using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class AddRentalCommand: IRequest<RentalResponse>
    {
        public string DeliveryManId { get; set; } = String.Empty;
        public string MottoId { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int Plan { get; set; }

    }

   
}
