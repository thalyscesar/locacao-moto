using LocacaoMoto.Application.Queries;
using LocacaoMoto.Domain.Entities;
using LocacaoMoto.Domain.Interfaces.Repositories;
using Dapper;
using System.Data;

namespace LocacaoMoto.Infrastructure.Repositories
{
    public class DeliveryManRepository : IDeliveryManRepository
    {
        private readonly IDbConnection _dbConnection;

        public DeliveryManRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool HasCnpjNumber(HasCNPJQuery query)
        {
            string select = "SELECT Count(*) FROM public.deliveryman where cnpj = @CNPJNumber";

            return (Int64)_dbConnection.ExecuteScalar(select, query) > 0;
        }

        public bool HasCNHNumber(HasCNHNumberQuery query)
        {
            string select = "SELECT Count(*) FROM public.deliveryman where cnh_number = @CNHNumber";

            return (Int64)_dbConnection.ExecuteScalar(select, query) > 0;
        }

        public string GetCnhTypeByIdentifier(string identifier)
        {
            string select = "SELECT cnh_type FROM public.deliveryman where identifier = @identifier";

            return _dbConnection.QuerySingle<string>(select, new { identifier });
        }

        public Task AddDeliveryMan(DeliveryMan deliveryMan)
        {
            string sql = "INSERT INTO public.deliveryman(identifier, name, cnpj, cnh_number, cnh_type, cnh_image, dateofbirth) VALUES(@Identifier, @Name, @CNPJ, @CNHNumber, @CNHType, @CNHImage, @DateOfBirth)";

            return _dbConnection.ExecuteAsync(sql, deliveryMan);

        }

        public Task UpdatePathCnhImage(DeliveryMan deliveryMan)
        {
            string sql = "UPDATE public.deliveryman SET cnh_image= @CNHImage WHERE identifier= @Identifier;";

            return _dbConnection.ExecuteAsync(sql, deliveryMan);
        }
    }
}
