using Dapper;
using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using System.Data;

namespace LocacaoMoto.Infrastructure.Repositories
{
    public class MottoRepository : IMottoRepository
    {
        private readonly IDbConnection _connection;

        public MottoRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public async Task AddMotto(Motto motto)
        {
            var sql = @"INSERT INTO public.motto(identifier, model, license_plate, year) 
                        VALUES (@Identifier, @Model, @LicensePlate, @Year)";

            await _connection.ExecuteAsync(sql, motto);
            return;
        }

        public bool AnyLicencePlateAsync(string licensePlate)
        {
            string sql = "SELECT Count(*) FROM public.motto where license_plate = @LicensePlate";

            return _connection.ExecuteScalar<int>(sql, new { LicensePlate = licensePlate }) > 0;
        }

        public async Task DeleteMottoById(Motto motto)
        {
            string sql = "DELETE FROM public.motto WHERE identifier = @Identifier";

            await _connection.ExecuteAsync(sql, motto);

            return;
        }

        public async Task<IEnumerable<Motto>> GetAllMottos()
        {
           string sql = "SELECT identifier as Identifier, model as Model, license_plate as LicensePlate, year as Year FROM public.motto";

            return await _connection.QueryAsync<Motto>(sql);
        }

        public async Task<Motto> GetMottoById(string identifier)
        {
            string sql = "SELECT identifier as Identifier, model as Model, license_plate as LicensePlate, year as Year FROM public.motto WHERE identifier = @Identifier";

            return _connection.QueryFirstOrDefault<Motto>(sql, new { Identifier = identifier });
        }

        public Task<Motto> GetMottoByLicensePlate(string licensePlate)
        {
            string sql = "SELECT identifier as Identifier, model as Model, license_plate as LicensePlate, year as Year FROM public.motto WHERE license_plate = @LicensePlate";

            return _connection.QueryFirstOrDefaultAsync<Motto>(sql, new { LicensePlate = licensePlate });
        }

        public Task ModifyLicencePlateMotto(Motto motto)
        {
            string sql = "UPDATE public.motto SET license_plate = @LicensePlate WHERE identifier = @Identifier";
            _connection.ExecuteAsync(sql, motto);

            return Task.CompletedTask;
        }
    }
}
