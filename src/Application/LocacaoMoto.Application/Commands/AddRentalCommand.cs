using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class AddRentalCommand: IRequest
    {
        public string DeliveryPersonId { get; set; } = String.Empty;
        public string MottoId { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int Plan { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(DeliveryPersonId)) return false;
            if (string.IsNullOrWhiteSpace(MottoId)) return false;
            if (StartDate == default) return false;
            if (ExpectedEndDate == default) return false;
            if (Plan <= 0) return false;
            if (EndDate != default && EndDate < StartDate) return false;

            return true;
        }
    }

   
}
