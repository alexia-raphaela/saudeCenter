using Dapper;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using System.Data;
using System.Text;

namespace SaudeCenter.Repository
{
    public class HospitalRepository : IHospitalRepository
    {
        public HospitalRepository()
        {

        }

        public IList<HospitalDto>? ListarTodos()
        {
            try
            {
                StringBuilder strComando = new StringBuilder();
                strComando.AppendLine(
                    "SELECT idHospital, Nome, CNPJ, Endereco, Telefone, CNES, Ativo FROM HOSPITAL");

                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));
                List<HospitalDto> hospitais = connection.Query<HospitalDto>(strComando.ToString()).ToList();

                return hospitais;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HospitalDto Consultar(int idHospital)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idHospital", idHospital);

                HospitalDto hospital =
                connection.Query<HospitalDto>(
                    "SELECT idHospital, Nome, CNPJ, Endereço, Telefone, CNES, Ativo FROM HOSPITAL WHERE idHospital = @idHospital", dynamicParameters).FirstOrDefault();

                if (hospital == null || hospital.IdHospital == 0)
                {
                    return null;
                }
                return hospital;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public int Inserir(Hospital hospital)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "INSERT INTO Hospital (Nome, Cnpj, Endereco, Telefone, Cnes, Ativo) " +
                        "VALUES (@Nome, @Cnpj, @Endereco, @Telefone, @Cnes, @Ativo) ", hospital);
                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Alterar(HospitalDto hospital)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                int linhasAfetadas = connection.Execute(
                        "UPDATE HOSPITAL SET " +
                        "Nome = @Nome, " +
                        "Cnpj = @Cnpj, " +
                        "Endereco = @Endereco, " +
                        "Telefone = @Telefone, " +
                        "Cnes = @Cnes, " +
                        "Ativo = @Ativo " +
                        "WHERE idHospital = @idHospital", hospital);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int Excluir(int idHospital)
        {
            try
            {
                SqlConnection connection = new SqlConnection(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetConnectionString("Sql"));

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@idHospital", idHospital);

                int linhasAfetadas = connection.Execute(
                        "DELETE FROM HOSPITAL WHERE idHospital = @idHospital", dynamicParameters);

                return linhasAfetadas;
            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}