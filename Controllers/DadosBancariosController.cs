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
    public class DadosBancariosController : Controller
    {
        private readonly DadosBancariosRepository dadosBancariosRepository;

        public DadosBancariosController()
        {
            dadosBancariosRepository = new DadosBancariosRepository();
        }


        [HttpGet]
        [Route("/DadosBancarios/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DadosBancariosDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var dadosBancarios = dadosBancariosRepository.ListarTodos();

                if (dadosBancarios == null)
                {
                    return NotFound("Não há dados para serem listados.");
                }
                return Ok(dadosBancarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/DadosBancarios/ConsultarPorDadosBancario/{idDadosBancario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DadosBancariosDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorBeneficiario(int idDadosBancario)
        {
            try
            {
                var dadosbancario = dadosBancariosRepository.Consultar(idDadosBancario);

                if (dadosbancario == null)
                {
                    return NotFound("Registro de dados bancário não foi encontrado.");
                }

                return Ok(dadosbancario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/DadosBancarios/CadastrarDadosBancario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarDadosBancario(DadosBancariosDto dadosBancario)
        {
            try
            {
                int linhasAfetadas = dadosBancariosRepository.Inserir(dadosBancario);

                if (linhasAfetadas == 0)
                {
                    return BadRequest("O cadastro foi realizado.");
                }

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/DadosBancarios/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(DadosBancariosDto dadosBancario)
        {
            try
            {
                int linhasAfetadas = dadosBancariosRepository.Alterar(dadosBancario);

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
        [Route("/DadosBancarios/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idDadosBancario)
        {
            try
            {
                int linhasAfetadas = dadosBancariosRepository.Excluir(idDadosBancario);

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
