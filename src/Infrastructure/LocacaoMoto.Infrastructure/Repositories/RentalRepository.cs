using LocacaoMoto.Application.Queries;
using LocacaoMoto.Application.Responses;
using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using Dapper;
using System.Data;

namespace LocacaoMoto.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private IDbConnection _connection;
        public RentalRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public bool HasRentalMotto(string identifier)
        {
            var sql = "select count(*) from public.rental where rental.motto_id = @Identifier";

            return _connection.ExecuteScalar<int>(sql, sql) > 0;
        }

        public async Task<int> AddRental(Rental rental)
        {
            string insert = @"INSERT INTO public.rental(date_created, start_date, end_date, expected_end_date, motto_id, deliveryman_id, plan) 
                              VALUES (@DateCreated, @StartDate, @EndDate, @ExpectedEndDate, @IdentifierMotto, @IdentifierDeliveryMan, @Plan)
                                RETURNING id";

            var id = await _connection.ExecuteScalarAsync<int>(insert, rental);

            return id;
        }

        public async Task<Rental> GetRentalById(int id)
        {
            string select = @"SELECT id as Id, date_created as DateCreated , start_date as StartDate, end_date as EndDate, expected_end_date as ExpectedEndDate, motto_id as IdentifierMotto, deliveryman_id as IdentifierDeliveryMan, plan as Plan
                              FROM public.rental where id = @Id";

            return await _connection.QueryFirstOrDefaultAsync<Rental>(select, new { Id = id });
        }

        public async Task UpdateReturndDate(Rental rental)
        {
            string update = "UPDATE public.rental SET end_date= @EndDate WHERE id= @Id";

            await _connection.ExecuteAsync(update, rental);
            return;
        }
    }
}
