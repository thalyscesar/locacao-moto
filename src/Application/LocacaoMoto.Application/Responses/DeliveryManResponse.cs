namespace LocacaoMoto.Application.Responses
{
    public class DeliveryManResponse
    {
        public string Identifier { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string CNPJ { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public string CNHNumber { get; set; } = String.Empty;
        public string CNHType { get; set; } = String.Empty;
    }
}
