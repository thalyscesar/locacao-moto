using Dapper;
using DapperExtensions;
using LocacaoMoto.Application.Configurations;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace LocacaoMoto.Infrastructure.Data
{
    public class DBHelper<TEntity> where TEntity : class
    {

        private IDbConnection _conectionDefault = null;
        private IDbTransaction _transaction = null;
        private readonly FactoryConnection factory;

        private DBHelper(IOptions<PostgresConfig> options)
        {
            this.factory = new DbPostgres(options.Value);
        }

        private IDbConnection GetConnectionDefault()
        {
            if (ConnectionDefaultClosed())
            {
                _conectionDefault = factory.Create();
            }
            return _conectionDefault;
        }

        private bool ConnectionDefaultClosed()
        {
            return _conectionDefault == null || _conectionDefault.State == ConnectionState.Closed;
        }

        public TEntity Get(string identifier)
        {
            var connection = this.GetConnectionDefault();

            try
            {
                var entity = connection.Get<TEntity>(identifier, _transaction);
                return entity;
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public TEntity Get(object value)
        {
            var connection = this.GetConnectionDefault();

            try
            {
                return connection.Get<TEntity>(value, _transaction);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity> GetAll()
        {
            var conexao = this.GetConnectionDefault();

            try
            {
                return conexao.Get<List<TEntity>>(_transaction);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity> GetAll(object predicate)
        {
            var conexao = this.GetConnectionDefault();

            try
            {
                return conexao.Get<List<TEntity>>(predicate, _transaction);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public int Get(string query, object value = null)
        {
            var conexao = this.GetConnectionDefault();

            try
            {
                return conexao.ExecuteScalar<int>(query, value);

            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity> GetQuery(string query)
        {
            var conexao = this.GetConnectionDefault();

            try
            {
                var x = conexao.Query<TEntity>(query);

                return x.ToList();
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public bool Inserir(TEntity entity)
        {
            var conexao = this.GetConnectionDefault();
            bool resultado = false;
            try
            {
                return conexao.Insert<TEntity>(entity, _transaction) > 0;
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
            return resultado;
        }

        //public bool Atualizar(TEntity entity)
        //{
        //    var conexao = this.GetConnectionDefault();

        //    try
        //    {
        //        return conexao.Update(entity, _transaction);
        //    }
        //    catch (NpgsqlException npgEx)//FbException fbex)
        //    {
        //        //Tratamento especial para erros do tipo: "Error reading data from the connection."
        //        if (npgEx.ErrorCode == 08000)
        //        {
        //            throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
        //        }
        //        //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
        //        if (npgEx.ErrorCode == 23503)
        //        {
        //            throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
        //        }
        //        throw;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public Task<int> UpdateAsync(string sql, TEntity parameters)
        {
            var conexao = this.GetConnectionDefault();

            try
            {
                return conexao.ExecuteAsync(sql, parameters, _transaction);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }


        public bool Excluir(TEntity entity)
        {
            var conexao = this.GetConnectionDefault();

            try
            {
                return conexao.Delete(entity, _transaction);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public void BeginTransaction()
        {
            if (this._transaction == null)
            {
                IDbConnection conexao = this.GetConnectionDefault();
                this._transaction = conexao.BeginTransaction(IsolationLevel.RepeatableRead);
            }
        }

        public void RollbackTransaction()
        {
            if (this._transaction != null)
            {
                this._transaction.Rollback();
                this._transaction.Dispose();
                this._transaction = null;
            }
        }

        public void CommitTransaction()
        {
            if (this._transaction != null)
            {
                this._transaction.Commit();
                this._transaction.Dispose();
                this._transaction = null;
            }
        }
    }
}