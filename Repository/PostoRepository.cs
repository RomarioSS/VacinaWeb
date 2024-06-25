using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Repository.Interfaces;

namespace VacinaWeb.Repository
{
    public class PostoRepository : IPostoRepository 
    {
        private readonly IConfiguration Configuration;
        private readonly string ConnectionString;
        public PostoRepository(IConfiguration configuration) 
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("ConnectionString");
        }
        public async Task AlterarPosto(AlterarPostoRequest posto)
        {
            await using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "UPDATE POSTO SET NOME = @NOME WHERE ID = @ID";
                await connection.ExecuteAsync(sql, new { Nome = posto.Nome, Id = posto.Id});
            }
        }

        public async Task DeletarPosto(int id)
        {
            await using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "DELETE POSTO WHERE ID = @ID";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<Posto> GetPostoById(int id)
        {
            await using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM POSTO WHERE ID = @ID";                
                var posto = await connection.QueryFirstOrDefaultAsync<Posto>(sql, new { Id = id });
                return posto;
            }
        }

        public async Task<IEnumerable<Posto>> GetPostos()
        {
            await using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT * FROM POSTO";
                var posto = await connection.QueryAsync<Posto>(sql, new { Id = 0 });
                return posto;
            }
        }

        public async Task<IEnumerable<Posto>> GetPostosByName(string nome)
        {
            await using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = $"SELECT * FROM POSTO WHERE NOME LIKE '%{nome}%' ";
                var posto = await connection.QueryAsync<Posto>(sql, null);
                return posto;
            }
        }
        public async Task IncluirPosto(IncluirPostoRequest posto)
        {
            await using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "INSERT INTO POSTO (NOME) VALUES (@NOME)";
                await connection.ExecuteAsync(sql, new { Nome = posto.Nome });
            }
        }
    }
}
