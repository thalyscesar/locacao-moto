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
            EndDate = endDate;
        }

        public int Id { get; private  set; }
        public DateTime DateCreated { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public DateTime ExpectedEndDate { get; private set; }
        public string IdentifierMotto { get; private set; }
        public string IdentifierDeliveryMan { get; private set; }
        public int Plan { get; private set; }

        public void SetExpectedEndDate(DateTime ExpectedEndDate)
        {
            this.ExpectedEndDate = ExpectedEndDate;
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
            if (ExpectedEndDate < EndDate) 
            {
                var days =(EndDate - ExpectedEndDate).Value.Days;
                var dailyEffective = (ExpectedEndDate - StartDate).Days;

                if (Plan == 7)
                {
                    var fine = (days * GetCostByPlan()) * 0.2M;
                    return (dailyEffective * GetCostByPlan()) + fine;
                }
                else if (Plan == 15)
                {
                    var fine = (days * GetCostByPlan()) * 0.4M;
                    return (dailyEffective * GetCostByPlan()) + fine;
                }
            }
            else if (ExpectedEndDate > EndDate)
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


