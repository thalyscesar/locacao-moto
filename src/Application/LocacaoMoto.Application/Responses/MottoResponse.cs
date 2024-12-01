namespace LocacaoMoto.Application.Responses
{
    public class MottoResponse
    {
        public string Identifier { get; set; } = String.Empty;   
        public int Year { get; set; }
        public string Model { get; set; } = String.Empty;
        public string LicensePlate { get; set; } = String.Empty;
    }
}
