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

        public bool HasRentalMotto(GetRentalByMottoIdentifierQuery query)
        {
            var sql = "select count(*) from public.rental where rental.motto_id = @Identifier";

           return _connection.ExecuteScalar<int>(sql, query) > 0;
        }

        public Task AddRental(Rental rental)
        {
            throw new NotImplementedException();
        }

        public Task<RentalResponse> GetRentalById(GetRentalByIdQuery getRentalByIdQuery)
        {
            throw new NotImplementedException();
            //string querySelect = String.Format("select id, nome from cadastro.banco where unaccent(UPPER(TRIM(nome))) like '{0}%'", this.RemoverAcentos(inicial.ToUpper()));
            //return DBHelper<Banco>.InstanciaNpgsql.GetQuery(querySelect).Select(b => new BuscarBancoQuery() { Id = b.Id, Nome = b.Nome }).ToList();
        }

        public Task<RentalResponse> UpdateReturndDate(GetRentalByIdQuery getRentalByIdQuery)
        {
            throw new NotImplementedException();
        }
    }
}
