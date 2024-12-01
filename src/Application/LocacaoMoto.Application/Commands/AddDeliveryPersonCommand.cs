using MediatR;

namespace LocacaoMoto.Application.Commands
{
    public class AddDeliveryManCommand: IRequest
    {
        public string Identifier { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string CNPJ { get; set; } = String.Empty;
        public string DateOfBirth { get; set; } = String.Empty;
        public string LicenseNumber { get; set; } = String.Empty;
        public string LicenseType { get; set; } = String.Empty;
        public string LicenseImage { get; set; } = String.Empty;

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Identifier)) return false;
            if (string.IsNullOrWhiteSpace(Name)) return false;
            if (string.IsNullOrWhiteSpace(CNPJ)) return false;
            if (string.IsNullOrWhiteSpace(DateOfBirth)) return false;
            if (string.IsNullOrWhiteSpace(LicenseNumber)) return false;
            if (string.IsNullOrWhiteSpace(LicenseType)) return false;
            if (string.IsNullOrWhiteSpace(LicenseImage)) return false;

            return true;
        }
    }
}
