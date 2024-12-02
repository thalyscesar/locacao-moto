using LocacaoMoto.Consumer.Events;
using System.Data;
using Dapper;

namespace LocacaoMoto.Consumer.Repositories
{
    public class MottoRepository: IMottoRepository
    {
        private readonly IDbConnection _connection;

        public MottoRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public async Task Add(MottoCreatedEvent mottoCreated)
        {
            var sql = @"INSERT INTO public.motto(identifier, model, license_plate, year) 
                        VALUES (@Identifier, @Model, @LicensePlate, @Year)";

            await _connection.ExecuteAsync(sql, mottoCreated);
        }
    }
}
