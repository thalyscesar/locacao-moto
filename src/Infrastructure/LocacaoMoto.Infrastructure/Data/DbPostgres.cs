using LocacaoMoto.Application.Configurations;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace LocacaoMoto.Infrastructure.Data
{
    public class DbPostgres : FactoryConnection
    {
        private readonly PostgresConfig _config;

        public DbPostgres(PostgresConfig postgresConfig)
        {
            _config = postgresConfig;
        }

        public IDbConnection Create()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();

            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = _config.Host;
            sb.Username = _config.UserName;
            sb.Password = _config.Password;
            sb.Database = _config.Database;
            sb.Port = _config.Port;
            sb.Timeout = _config.Timeout;

            var conexao = new NpgsqlConnection(sb.ConnectionString);
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao conectar no banco.", ex);
            }
            return conexao;
        }
    }

    public interface FactoryConnection
    {
        IDbConnection Create();
    }
}
