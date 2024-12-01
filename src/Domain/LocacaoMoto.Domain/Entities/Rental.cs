using LocacaoMoto.Domain.Enums;

namespace LocacaoMoto.Domain.Entities
{
    public class Rental
    {
        public DateTime DateCreated { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public Motto Motto { get; set; }
        public DeliveryMan DeliveryMan { get; set; }
        public int Plan { get; set; }

        public decimal GetCostByPlan()
        {
            decimal custo = 0;

            switch (Plan)
            {
                case 7:
                    custo = 30M;
                    break;
                case 15:
                    custo = 28;
                    break;
                case 30:
                    custo = 22;
                    break;
                case 45:
                    custo = 20;
                    break;
                case 50:
                    custo = 18;
                    break;
                default:
                    break;
            }

            return custo;
        }

        public decimal CalculateDailyValue()
        {
            if (ExpectedEndDate < EndDate)
            {
                var days = (EndDate - ExpectedEndDate).Days;

                if (Plan == 7)
                {
                    return (days * GetCostByPlan()) * 0.02M;
                }
                else if (Plan == 15)
                {
                    return (days * GetCostByPlan()) * 0.04M;
                }
            }
            else if (ExpectedEndDate > EndDate)
            {
                var amountPlan = GetCostByPlan() * Plan;
                var additionalValue = 50;
                var days = (ExpectedEndDate - EndDate).Days;
                return amountPlan + (days * GetCostByPlan()) + (additionalValue * days);
            }

            return GetCostByPlan() * Plan;
        }
    }
}


