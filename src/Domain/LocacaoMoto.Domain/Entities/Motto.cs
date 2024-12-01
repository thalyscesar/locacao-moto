namespace LocacaoMoto.Domain.Entities
{
    public class Motto
    {
        public string Identifier { get; private set; }
        public int Year { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }

        public Motto() { }

        public Motto(string identifier, int year, string model, string licensePlate)
        {
            Identifier = identifier;
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }

        public void SetLicensePlate(string licensePlate)
        {
            this.LicensePlate = licensePlate;
        }

        public void SetIdentifier(string identifier)
        {
            this.Identifier = identifier;
        }
    }
}
