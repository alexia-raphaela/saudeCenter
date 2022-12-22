using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;

namespace SaudeCenter.Repository
{
    public class AgendamentoConfiguracaoRepository : IAgendamentoConfiguracaoRepository
    {
        public AgendamentoConfiguracaoRepository()
        {

        }
        public IList<AgendamentoConfiguracaoDto>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine(
                    "SELECT IdConfiguracao, " +
                    "IdHospital, " +
                    "IdEspecialidade, " +
                    "IdProfissional, " +
                    "DataHoraInicioAtendimento, " +
                    "DataHoraFinalAtendimento " +
                    "FROM AgendamentoConfiguracao");

                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<AgendamentoConfiguracaoDto> configuracao = connection.Query<AgendamentoConfiguracaoDto>(strComando.ToString()).ToList();

                return configuracao;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AgendamentoConfiguracaoDto Consultar(int idConfiguracao)
        {
            try
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idConfiguracao", idConfiguracao);

                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                AgendamentoConfiguracaoDto configuracao =
                connection.Query<AgendamentoConfiguracaoDto>(
                    "SELECT idConfiguracao, " +
                    "IdHospital, " +
                    "IdEspecialidade, " +
                    "IdProfissional, " +
                    "DataHoraInicioAtendimento, " +
                    "DataHoraFinalAtendimento " +
                    "FROM AGENDAMENTOCONFIGURACAO WHERE idConfiguracao = @idConfiguracao",
                dynamicParameters
                ).FirstOrDefault();

                if (configuracao == null || configuracao.IdConfiguracao == 0)
                {
                    return null;
                }
                return configuracao;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int Inserir(AgendamentoConfiguracaoDto configuracao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "INSERT INTO AGENDAMENTOCONFIGURACAO (IdHospital, IdEspecialidade, IdProfissional, DataHoraInicioAtendimento, DataHoraFinalAtendimento) " +
                        "VALUES (@IdHospital, @IdEspecialidade, @IdProfissional, @DataHoraInicioAtendimento, @DataHoraFinalAtendimento) ", configuracao);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Alterar(AgendamentoConfiguracaoDto configuracao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "UPDATE AGENDAMENTOCONFIGURACAO " +
                        "SET IdHospital = @IdHospital, " +
                        "IdEspecialidade = @IdEspecialidade, " +
                        "IdProfissional = @IdProfissional, " +
                        "DataHoraInicioAtendimento = @DataHoraInicioAtendimento, " +
                        "DataHoraFinalAtendimento = @DataHoraFinalAtendimento " +
                        "WHERE idConfiguracao = @idConfiguracao", configuracao);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int Excluir(int idConfiguracao)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idConfiguracao", idConfiguracao);

                int linhasAfetadas = connection.Execute(
                        "DELETE FROM AGENDAMENTOCONFIGURACAO WHERE idConfiguracao = @idConfiguracao  ", dynamicParameters);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}