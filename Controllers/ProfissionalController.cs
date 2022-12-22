using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using SaudeCenter.Repository;
using System.Text;
namespace SaudeCenter.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProfissionalController : Controller
    {
        private readonly ProfissionalRepository profissionalRepository;
        public ProfissionalController()
        {
            profissionalRepository = new ProfissionalRepository();
        }
        [HttpGet]
        [Route("/Profissional/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var profissional = profissionalRepository.ListarTodos();
                if (profissional == null)
                {
                    return NotFound("Não há nenhum registro de profissional.");
                }
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/Profissional/ConsultarPorProfissional/{idProfissional}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfissionalRepository))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorProfissional(int idProfissional)
        {
            try
            {
                var profissional = profissionalRepository.Consultar(idProfissional);
                if (profissional == null)
                {
                    return Content("Não foi encontrado o profissional.");
                }
                return Ok(profissional);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/Profissional/CadastrarProfissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarProfissional(ProfissionalDto profissional)
        {
            try
            {
                int linhasAfetadas = profissionalRepository.Inserir(profissional);
                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum Cadastro foi realizado.");
                }
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        [Route("/Profissional/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(ProfissionalDto profissional)
        {
            try
            {
                int linhasAfetadas = profissionalRepository.Alterar(profissional);
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
        [Route("/Profissional/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idProfissional)
        {
            try
            {
                int linhasAfetadas = profissionalRepository.Excluir(idProfissional);
                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum profissional foi Excluído.");
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
