using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using SaudeCenter.Repository;
using System.Text;

namespace SaudeCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : Controller
    {
        private readonly HospitalRepository hospitalRepository;

        public HospitalController()
        {
            hospitalRepository = new HospitalRepository();
        }


        [HttpGet]
        [Route("/Hospital/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var hospitais = hospitalRepository.ListarTodos();

                if (hospitais == null)
                {
                    return NotFound("Não há hospitais para serem listados.");
                }
                return Ok(hospitais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Hospital/ConsultarPorHospital/{idHospital}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HospitalRepository))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorHospital(int idHospital)
        {
            try
            {
                var hospital = hospitalRepository.Consultar(idHospital);

                if (hospital == null)
                {
                    return NotFound("Cadastro não foi encontrado.");
                }

                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Hospital/CadastrarHospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarHospital(Hospital hospital)
        {
            try
            {
                int linhasAfetadas = hospitalRepository.Inserir(hospital);

                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum cadastro foi realizado.");
                }

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/Hospital/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(HospitalDto hospital)
        {
            try
            {
                int linhasAfetadas = hospitalRepository.Alterar(hospital);

                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum cadastro foi atualizado.");
                }

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/Hospital/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idHospital)
        {
            try
            {
                int linhasAfetadas = hospitalRepository.Excluir(idHospital);

                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum cadastro foi Excluído.");
                }

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
