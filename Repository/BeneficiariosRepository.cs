using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;

namespace SaudeCenter.Repository
{
    public class BeneficiariosRepository
    {
        private readonly IConfiguration _configuration;

        public BeneficiariosRepository()
        {

        }
        public BeneficiariosRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IList<Beneficiario>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine("SELECT idBeneficiario, " +
                                "Nome, " +
                                "Cpf, " +
                                "Telefone, " +
                                "Endereco, " +
                                "NumeroCarteirinha, " +
                                "Ativo, " +
                                "email, " +
                                "senha FROM Beneficiario");

                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<Beneficiario> beneficiarios = connection.Query<Beneficiario>(strComando.ToString()).ToList();

                return beneficiarios;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Beneficiario Consultar(int idBeneficiario)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idBeneficiario", idBeneficiario);

                Beneficiario beneficiario =
                    connection.Query<Beneficiario>(
                        "SELECT idBeneficiario, " +
                                "Nome, " +
                                "Cpf, " +
                                "Telefone, " +
                                "Endereco, " +
                                "NumeroCarteirinha, " +
                                "Ativo, " +
                                "email, " +
                                "senha FROM Beneficiario where idBeneficiario = @idBeneficiario",
                        dynamicParameters
                        ).FirstOrDefault();

                if (beneficiario == null || beneficiario.IdBeneficiario == 0)
                {
                    return null;
                }
                return beneficiario;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public int Inserir(Beneficiario beneficiario)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "INSERT INTO BENEFICIARIO (Nome, Cpf, Telefone, Endereco, NumeroCarteirinha, Ativo, email, senha ) " +
                        "VALUES (@Nome, @Cpf, @Telefone, @Endereco, @NumeroCarteirinha, @Ativo, @email, @senha ) ", beneficiario);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }        

        public int Alterar(Beneficiario beneficiario)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "UPDATE BENEFICIARIO " +
                        "set Nome = @Nome, " +
                        "Cpf = @Cpf, " +
                        "Telefone = @Telefone, " +
                        "Endereco = @Endereco, " +
                        "NumeroCarteirinha = @NumeroCarteirinha, " +
                        "Ativo = @Ativo, " +
                        "email = @email, " +
                        "senha = @senha " +
                    "where idBeneficiario = @idBeneficiario", beneficiario);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int Excluir(int idBeneficiario)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idBeneficiario", idBeneficiario);

                int linhasAfetadas = connection.Execute(
                        "DELETE BENEFICIARIO WHERE idBeneficiario = @idBeneficiario  ", dynamicParameters);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}
