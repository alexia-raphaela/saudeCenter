using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;
namespace SaudeCenter.Repository
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        public ProfissionalRepository()
        {
        }
        public IList<ProfissionalDto>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine(
                    "SELECT IdProfissional, " +
                    "Nome, " +
                    "Telefone, " +
                    "Endereço, " +
                    "Ativo " +
                    "FROM Profissional ");
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<ProfissionalDto> profissional = connection.Query<ProfissionalDto>(strComando.ToString()).ToList();
                return profissional;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ProfissionalDto Consultar(int idProfissional)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idProfissional", idProfissional);
                ProfissionalDto profissional =
                connection.Query<ProfissionalDto>(
                    "SELECT IdProfissional, Nome, Telefone, Endereço, Ativo " +
                    "FROM Profissional " +
                    "WHERE IdProfissional = @idProfissional",
                dynamicParameters
                ).FirstOrDefault();

                if (profissional == null || profissional.IdProfissional == 0)
                {
                    return null;
                }
                return profissional;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int Inserir(ProfissionalDto profissional)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Nome", profissional.Nome);
                dynamicParameters.Add("@Telefone", profissional.Telefone);
                dynamicParameters.Add("@Endereço", profissional.Endereço);
                dynamicParameters.Add("@Ativo", profissional.Ativo);
                int linhasAfetadas = connection.Execute(
                        "INSERT INTO Profissional (Nome, Telefone, Endereço, Ativo) " +
                        "VALUES (@Nome, @Telefone, @Endereço, @Ativo)", dynamicParameters);
                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Alterar(ProfissionalDto profissional)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdProfissional", profissional.IdProfissional);
                dynamicParameters.Add("@Nome", profissional.Nome);
                dynamicParameters.Add("@Telefone", profissional.Telefone);
                dynamicParameters.Add("@Endereço", profissional.Endereço);
                dynamicParameters.Add("@Ativo", profissional.Ativo);
                int linhasAfetadas = connection.Execute(
                        "UPDATE Profissional SET " +
                        "Nome = @Nome, " +
                        "Telefone = @Telefone, " +
                        "Endereço = @Endereço, " +
                        "Ativo = @Ativo " +
                        "WHERE idProfissional = @IdProfissional ", dynamicParameters);
                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Excluir(int idProfissional)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idProfissional", idProfissional);
                int linhasAfetadas = connection.Execute(
                        "DELETE from Profissional WHERE idProfissional = @idProfissional", dynamicParameters);
                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}