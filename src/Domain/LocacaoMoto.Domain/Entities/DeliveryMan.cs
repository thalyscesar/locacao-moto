namespace LocacaoMoto.Domain.Entities
{
    public class DeliveryMan
    {
        private string deliveryManId;

        public string Identifier { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CNHNumber { get; set; }
        public string CNHType { get; set; }
        public string? CNHImage { get; set; }
        
        public DeliveryMan() { }

        public DeliveryMan(string identifier, string name, string cnpj, DateTime dateOfBirth, string cnhNumber, string cnhType, string? cnhImage): this(identifier)
        {
            Name = name;
            CNPJ = cnpj;
            DateOfBirth = dateOfBirth;
            CNHNumber = cnhNumber;
            CNHType = cnhType;
            CNHImage = cnhImage;
        }

        public DeliveryMan(string deliveryManId)
        {
            this.deliveryManId = deliveryManId;
        }

        public void SetIdentifier(string identifier)
        {
            this.Identifier = identifier;
        }

        public void SetCNHImage(string cnhImage)
        {
            this.CNHImage = cnhImage;
        }
    }
}