using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Repository.Interfaces;

namespace VacinaWeb.Repository
{
    public class PostoVacinaRepository : IPostoVacinaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PostoVacinaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        public async Task<IEnumerable<PostoVacina>> GetAllPostosAsync()
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM POSTOVACINA";
                var postos = await connection.QueryAsync<PostoVacina>(sql);
                return postos;
            }
        }

        public async Task<PostoVacina> GetPostoByIdAsync(int id)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM POSTOVACINA WHERE Id = @Id";
                var posto = await connection.QueryFirstOrDefaultAsync<PostoVacina>(sql, new { Id = id });
                return posto;
            }
        }

        public async Task AddPostoVacinaAsync(PostoVacina postoVacina)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO POSTOVACINA (IdPosto, IdVacina, Quantidade) VALUES (@IdPosto, @IdVacina, @Quantidade)";
                await connection.ExecuteAsync(sql, new { postoVacina.IdPosto, postoVacina.IdVacina, postoVacina.Quantidade });
            }
        }

        public async Task UpdatePostoVacinaAsync(PostoVacina postoVacina)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE POSTOVACINA SET IdPosto = @IdPosto, IdVacina = @IdVacina, Quantidade = @Quantidade WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { postoVacina.IdPosto, postoVacina.IdVacina, postoVacina.Quantidade, postoVacina.Id });
            }
        }

        public async Task DeletePostoVacinaAsync(int id)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM POSTOVACINA WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IEnumerable<PostoVacina>> GetPostoByVacinaAsync(int idVacina)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM POSTOVACINA WHERE IdVacina = @IdVacina";
                var postos = await connection.QueryAsync<PostoVacina>(sql, new { IdVacina = idVacina });
                return postos;
            }
        }

        public async Task<IEnumerable<PostoVacina>> GetPostoVacinaByPostoAsync(int idPosto)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM POSTOVACINA WHERE IdPosto = @IdPosto";
                var postos = await connection.QueryAsync<PostoVacina>(sql, new { IdPosto = idPosto });
                return postos;
            }
        }

        public async Task<PostoVacina> GetPostoVacinaByPostoAndVacinaAsync(int idPosto, int idVacina)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM POSTOVACINA WHERE IDPOSTO = @IdPosto AND IDVACINA = @IdVacina";
                var postoVacina = await connection.QueryFirstOrDefaultAsync<PostoVacina>(sql, new { IdPosto = idPosto, IdVacina = idVacina });
                return postoVacina;
            }
        }

        public async Task<bool> HasVacinasAsync(int postoId)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT COUNT(*) FROM VACINA WHERE ID = @PostoId";
                var count = await connection.ExecuteScalarAsync<int>(sql, new { PostoId = postoId });
                return count > 0;
            }
        }

        public async Task<bool> IsDuplicatePostoNameAsync(string nome)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT COUNT(*) FROM POSTOVACINA WHERE Nome = @Nome";
                var count = await connection.ExecuteScalarAsync<int>(sql, new { Nome = nome });
                return count > 0;
            }
        }
    }
}
