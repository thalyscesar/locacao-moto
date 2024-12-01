using LocacaoMoto.Domain.Enums;

namespace LocacaoMoto.Domain.Entities
{
    public class Rental
    {
        public Rental()
        {

        }

        public Rental(int id, DateTime dateCreated, DateTime startDate, DateTime? endDate, DateTime expectedEndDate, string identifierMotto, string identifierDeliveryMan, int plan)
        {
            DateCreated = dateCreated;
            StartDate = startDate;
            ExpectedEndDate = expectedEndDate;
            IdentifierMotto = identifierMotto;
            IdentifierDeliveryMan = identifierDeliveryMan;
            Plan = plan;
        }

        public int Id { get; private  set; }
        public DateTime DateCreated { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public string IdentifierMotto { get; private set; }
        public string IdentifierDeliveryMan { get; private set; }
        public int Plan { get; private set; }

        public void SetEndDate(DateTime? endDate)
        {
            this.EndDate = endDate;
        }

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
            if (EndDate < ExpectedEndDate) 
            {
                var days = (ExpectedEndDate - EndDate).Value.Days;

                if (Plan == 7)
                {
                    return (days * GetCostByPlan()) * 0.02M;
                }
                else if (Plan == 15)
                {
                    return (days * GetCostByPlan()) * 0.04M;
                }
            }
            else if (EndDate > ExpectedEndDate)
            {
                var amountPlan = GetCostByPlan() * Plan;
                var additionalValue = 50;
                var days = (ExpectedEndDate - EndDate).Value.Days;
                return amountPlan + (days * GetCostByPlan()) + (additionalValue * days);
            }

            return GetCostByPlan() * Plan;
        }
    }
}


