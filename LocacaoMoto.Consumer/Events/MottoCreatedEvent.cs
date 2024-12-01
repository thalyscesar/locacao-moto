namespace LocacaoMoto.Consumer.Events
{
    public class MottoCreatedEvent
    {
        public MottoCreatedEvent(string identifier, int year, string model, string licensePlate)
        {
            Identifier = identifier;
            Year = year;
            Model = model;
            LicensePlate = licensePlate;
        }

        public string Identifier { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
    }
}
