using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;

namespace SaudeCenter.Repository
{
    public class AgendamentoConfiguracaoRepository 
    {
        public AgendamentoConfiguracaoRepository()
        {

        }
        //public IList<BeneficiarioDto>? ListarTodos()
        //{
        //    try
        //    {
        //        StringBuilder strComando = new StringBuilder();
        //        strComando.AppendLine(
        //            "SELECT idBeneficiario, " +
        //            "Nome, " +
        //            "Cpf, " +
        //            "Telefone, " +
        //            "Endereco, " +
        //            "NumeroCarteirinha, " +
        //            "Ativo, " +
        //            "email, " +
        //            "senha FROM Beneficiario");

        //        SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
        //        List<BeneficiarioDto> beneficiarios = connection.Query<BeneficiarioDto>(strComando.ToString()).ToList();

        //        return beneficiarios;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public AgendamentoConfiguracao Consultar(int idAgendamentoConfiguracao)
        //{
        //    try
        //    {
        //        var dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@idAgendamentoConfiguracao", idAgendamentoConfiguracao);

        //        SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
        //        AgendamentoConfiguracao configuracao =
        //        connection.Query<AgendamentoConfiguracao>(
        //            "SELECT idConfiguracao, " +
        //            "IdHospital, " +
        //            "IdEspecialidade, " +
        //            "IdProfissional, " +
        //            "DataHoraInicioAtendimento, " +
        //            "DataHoraFinalAtendimento " +
        //            "FROM AGENDAMENTOCONFIGURACAO WHERE idConfiguracao = @idConfiguracao",
        //        dynamicParameters
        //        ).FirstOrDefault();

        //        if (beneficiario == null || beneficiario.IdBeneficiario == 0)
        //        {
        //            return null;
        //        }
        //        return beneficiario;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //}

        //public int Inserir(Beneficiario beneficiario)
        //{
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

        //        int linhasAfetadas = connection.Execute(
        //                "INSERT INTO BENEFICIARIO (Nome, Cpf, Telefone, Endereco, NumeroCarteirinha, Ativo, email, senha ) " +
        //                "VALUES (@Nome, @Cpf, @Telefone, @Endereco, @NumeroCarteirinha, @Ativo, @email, @senha ) ", beneficiario);

        //        return linhasAfetadas;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}

        //public int Alterar(BeneficiarioDto beneficiario)
        //{
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

        //        int linhasAfetadas = connection.Execute(
        //                "UPDATE BENEFICIARIO " +
        //                "SET Nome = @Nome, " +
        //                "Cpf = @Cpf, " +
        //                "Telefone = @Telefone, " +
        //                "Endereco = @Endereco, " +
        //                "NumeroCarteirinha = @NumeroCarteirinha, " +
        //                "Ativo = @Ativo, " +
        //                "email = @email, " +
        //                "senha = @senha " +
        //                "WHERE idBeneficiario = @idBeneficiario", beneficiario);

        //        return linhasAfetadas;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }

        //}

        //public int Excluir(int idBeneficiario)
        //{
        //    try
        //    {
        //        SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

        //        var dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@idBeneficiario", idBeneficiario);

        //        int linhasAfetadas = connection.Execute(
        //                "DELETE FROM BENEFICIARIO WHERE idBeneficiario = @idBeneficiario  ", dynamicParameters);

        //        return linhasAfetadas;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }

        //}
    }
}