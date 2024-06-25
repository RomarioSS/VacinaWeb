using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacinaWeb.Models;
using VacinaWeb.Models.Requests;
using VacinaWeb.Repository.Interfaces;

namespace VacinaWeb.Repository
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public VacinaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionString");
        }

        public async Task AlterarVacina(AlterarVacinaRequest vacina)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Vacina 
                            SET Nome = @Nome, 
                                Fabricante = @Fabricante, 
                                Lote = @Lote, 
                                Quantidade = @Quantidade, 
                                DataDeValidade = @DataDeValidade 
                            WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new
                {
                    vacina.Nome,
                    vacina.Fabricante,
                    vacina.Lote,
                    vacina.Quantidade,
                    vacina.DataDeValidade,
                    vacina.Id
                });
            }
        }

        public async Task DeletarVacina(int id)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Vacina WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<Vacina> GetVacinaById(int id)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Vacina WHERE Id = @Id";
                var vacina = await connection.QueryFirstOrDefaultAsync<Vacina>(sql, new { Id = id });
                return vacina;
            }
        }

        public async Task<IEnumerable<Vacina>> GetVacinas()
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Vacina";
                var vacinas = await connection.QueryAsync<Vacina>(sql);
                return vacinas;
            }
        }

        public async Task<IEnumerable<Vacina>> GetVacinasByName(string nome)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Vacina WHERE Nome LIKE '%' + @Nome + '%'";
                var vacinas = await connection.QueryAsync<Vacina>(sql, new { Nome = nome });
                return vacinas;
            }
        }

        public async Task IncluirVacina(IncluirVacinaRequest vacina)
        {
            await using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Vacina (Nome, Fabricante, Lote, Quantidade, DataDeValidade) 
                            VALUES (@Nome, @Fabricante, @Lote, @Quantidade, @DataDeValidade)";
                await connection.ExecuteAsync(sql, new
                {
                    vacina.Nome,
                    vacina.Fabricante,
                    vacina.Lote,
                    vacina.Quantidade,
                    vacina.DataDeValidade
                });
            }
        }
    }
}
