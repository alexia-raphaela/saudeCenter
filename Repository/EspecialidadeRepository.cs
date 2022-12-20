using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;

namespace SaudeCenter.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        public EspecialidadeRepository()
        {

        }

        public IList<EspecialidadeDto>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine(
                    "SELECT IdEspecialidade, " +
                    "Nome, " +
                    "Descrição, " +
                    "Ativo " +
                    "FROM Especialidade");

                
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<EspecialidadeDto> especialidades = connection.Query<EspecialidadeDto>(strComando.ToString()).ToList();

                return especialidades;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EspecialidadeDto Consultar(int idEspecialidade)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idEspecialidade", idEspecialidade);

                EspecialidadeDto especialidade =
                connection.Query<EspecialidadeDto>(
                    "SELECT IdEspecialidade," +
                    "Nome, " +
                    "Descrição, " +
                    "Ativo " +
                    "FROM Especialidade " +
                    "WHERE idEspecialidade = @idEspecialidade",
                dynamicParameters
                ).FirstOrDefault();

                if (especialidade == null || especialidade.IdEspecialidade == 0)
                {
                    return null;
                }
                return especialidade;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int Inserir(Especialidade especialidade)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "INSERT INTO ESPECIALIDADE (Nome, Descrição, Ativo) " +
                        "VALUES (@Nome, @Descrição, @Ativo) ", especialidade);
                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Alterar(EspecialidadeDto especialidade)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "UPDATE ESPECIALIDADE " +
                        "SET Nome = @Nome, " +
                        "Descrição= @Descrição, " +
                        "Ativo = @Ativo " +
                        "WHERE idEspecialidade = @idEspecialidade", especialidade);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int Excluir(int idEspecialidade)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idEspecialidade", idEspecialidade);

                int linhasAfetadas = connection.Execute(
                        "DELETE from ESPECIALIDADE WHERE idEspecialidade = @idEspecialidade", dynamicParameters);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }
     }
}