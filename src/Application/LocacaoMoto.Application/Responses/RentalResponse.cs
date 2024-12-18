﻿namespace LocacaoMoto.Application.Responses
{
    public class RentalResponse
    {
        public int Id { get; set; }
        public string DeliveryManId { get; set; } = String.Empty;
        public string MottoId { get; set; } = String.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public int Plan { get; set; }
    }
}
