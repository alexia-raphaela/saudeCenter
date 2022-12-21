using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;

namespace SaudeCenter.Repository
{
    public class DadosBancariosRepository : IDadosBancariosRepository
    {
        public DadosBancariosRepository()
        {

        }
        public IList<DadosBancariosDto>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine(
                    "SELECT IdDadosBancarios, " +
                    "NumeroBanco, " +
                    "CodigoPix, " +
                    "Agencia, " +
                    "NumeroConta, " +
                    "Poupanca , " +
                    "IdProfissional " +
                    "FROM DadosBancarios");


                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<DadosBancariosDto> dadosBancarios = connection.Query<DadosBancariosDto>(strComando.ToString()).ToList();

                return dadosBancarios;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DadosBancariosDto Consultar(int idDadosBancarios)
        {
            try
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idDadosBancarios", idDadosBancarios);

                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                DadosBancariosDto dadosBancarios =
                connection.Query<DadosBancariosDto>(
                    "SELECT IdDadosBancarios, " +
                    "NumeroBanco, " +
                    "CodigoPix, " +
                    "Agencia, " +
                    "NumeroConta, " +
                    "Poupanca, " +
                    "IdProfissional " +
                    "FROM DadosBancarios " +
                    "Where idDadosBancarios = @idDadosBancarios",
                dynamicParameters
                ).FirstOrDefault();

                if (dadosBancarios == null || dadosBancarios.IdDadosBancarios == 0)
                {
                    return null;
                }
                return dadosBancarios;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int Inserir(DadosBancariosDto dadosBancarios)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "INSERT INTO DADOSBANCARIOS (NumeroBanco, CodigoPix, Agencia, NumeroConta, Poupanca, IdProfissional) " +
                        "VALUES (@NumeroBanco, @CodigoPix, @Agencia, @NumeroConta, @Poupanca, @IdProfissional ) ", dadosBancarios);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Alterar(DadosBancariosDto dadosBancarios)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "UPDATE DADOSBANCARIOS " +
                        "SET NumeroBanco = @NumeroBanco, " +
                        "CodigoPix = @CodigoPix, " +
                        "Agencia = @Agencia, " +
                        "NumeroConta = @NumeroConta, " +
                        "Poupanca = @Poupanca, " +
                        "IdProfissional = @IdProfissional " +
                        "WHERE idDadosBancarios = @idDadosBancarios", dadosBancarios);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int Excluir(int idDadosBancarios)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idDadosBancarios", idDadosBancarios);

                int linhasAfetadas = connection.Execute(
                        "DELETE FROM DADOSBANCARIOS WHERE idDadosBancarios = @idDadosBancarios", dynamicParameters);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}