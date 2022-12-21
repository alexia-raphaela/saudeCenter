using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Text;

namespace SaudeCenter.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        public AgendamentoRepository()
        {

        }
        public IList<AgendamentoDto>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine("SELECT idAgendamento, idHospital, idEspecialidade, idProfissional, DataHoraAgendamento, idBeneficiario, Ativo FROM AGENDAMENTO");

                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<AgendamentoDto> agendamento = connection.Query<AgendamentoDto>(strComando.ToString()).ToList();

                return agendamento;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AgendamentoDto Consultar(int idAgendamento)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idAgendamento", idAgendamento);

                AgendamentoDto agendamento =
                    connection.Query<AgendamentoDto>(
                        "SELECT idAgendamento, idHospital, idEspecialidade, idProfissional, DataHoraAgendamento, idBeneficiario, Ativo FROM AGENDAMENTO WHERE idAgendamento = @idAgendamento", dynamicParameters).FirstOrDefault();

                if (agendamento == null || agendamento.IdAgendamento == 0)
                {
                    return null;
                }
                return agendamento;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int Inserir(AgendamentoDto agendamento)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "INSERT INTO AGENDAMENTO (idHospital, idEspecialidade, idProfissional, DataHoraAgendamento, idBeneficiario, Ativo) " +
                        "VALUES (@idHospital, @idEspecialidade, @idProfissional, @DataHoraAgendamento, @idBeneficiario, @Ativo ) ", agendamento);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Alterar(AgendamentoDto agendamento)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdAgendamento", agendamento.IdAgendamento);
                dynamicParameters.Add("@IdHospital", agendamento.IdHospital);
                dynamicParameters.Add("@IdEspecialidade", agendamento.IdEspecialidade);
                dynamicParameters.Add("@IdProfissional", agendamento.IdProfissional);
                dynamicParameters.Add("@DataHoraAgendamento", agendamento.DataHoraAgendamento);
                dynamicParameters.Add("@IdBeneficiario", agendamento.IdBeneficiario);
                dynamicParameters.Add("@Ativo", agendamento.Ativo);
                int linhasAfetadas = connection.Execute(
                        "UPDATE AGENDAMENTO SET " +
                        "IdHospital = @IdHospital, " +
                        "IdEspecialidade = @IdEspecialidade, " +
                        "IdProfissional = @IdProfissional, " +
                        "DataHoraAgendamento = @DataHoraAgendamento, " +
                        "IdBeneficiario = @IdBeneficiario, " +
                        "Ativo = @Ativo " +
                        "WHERE IdAgendamento = @IdAgendamento ", dynamicParameters);
                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Excluir(int idAgendamento)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idAgendamento", idAgendamento);

                int linhasAfetadas = connection.Execute(
                        "DELETE AGENDAMENTO WHERE idAgendamento = @idAgendamento  ", dynamicParameters);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}