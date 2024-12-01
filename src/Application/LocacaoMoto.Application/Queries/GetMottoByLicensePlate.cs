namespace LocacaoMoto.Application.Queries
{
    public class GetMottoByLicensePlateQuery
    {
        public GetMottoByLicensePlateQuery(string identifier, string licensePlate)
        {
            Identifier = identifier;
            LicensePlate = licensePlate;
        }

        public string Identifier { get; set; }
        public string LicensePlate { get; set; }
    }
}
