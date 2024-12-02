using LocacaoMoto.Domain.Entities;

namespace LocacaoMoto.Tests
{
    public class RentalTest
    {
        [Fact]
        public void CDailyRatesBeforeScheduledDateWith7DayPlan()
        {
            //Arrange
            var createdDate = DateTime.Now;
            var startDate = new DateTime(2024, 10, 2);
            var endDate = new DateTime(2024, 10, 9);
            var expectdDate = new DateTime(2024, 10, 6);
            var idMotto = "biz";
            var IdDeliveryMan = "entregador1";
            var plan = 7;

            var rental = new Rental(
                1,
                createdDate,
                startDate,
                endDate,
                expectdDate,
                idMotto,
                IdDeliveryMan,
                plan);

            //Action
            var dailyRates = rental.CalculateDailyValue();

            //Assert
            Assert.Equal(138M, dailyRates);
        }

        [Fact]
        public void DailyRatesBeforeScheduledDateWith15DayPlan()
        {
            //Arrange
            var createdDate = DateTime.Now.AddDays(-1);
            var startDate = createdDate.AddDays(1);
            var endDate = startDate.AddDays(7);
            var expectdDate = startDate.AddDays(2);
            var idMotto = "biz";
            var IdDeliveryMan = "entregador1";
            var plan = 7;

            var rental = new Rental(
                1,
                createdDate,
                startDate,
                endDate,
                expectdDate,
                idMotto,
                IdDeliveryMan,
                plan);

            //Action
            var dailyRates = rental.CalculateDailyValue();

            //Assert
            Assert.Equal(90M, dailyRates);
        }

        [Fact]
        public void CalculateDailyValueExceedsExpectedDate()
        {
            //Arrange
            var createdDate = DateTime.Now;
            var startDate = new DateTime(2024, 10, 1);
            var endDate = new DateTime(2024, 10, 8);
            var expectdDate = new DateTime(2024, 10, 15);
            var idMotto = "biz";
            var IdDeliveryMan = "entregador1";
            var plan = 7;

            var rental = new Rental(
                1,
                createdDate,
                startDate,
                endDate,
                expectdDate,
                idMotto,
                IdDeliveryMan,
                plan);

            //Action
            var dailyRates = rental.CalculateDailyValue();

            //Assert
            Assert.Equal(770M, dailyRates);
        }
    }
}