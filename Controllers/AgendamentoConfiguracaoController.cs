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
    public class AgendamentoConfiguracaoController : Controller
    {
        private readonly AgendamentoConfiguracaoRepository agendamentoConfiguracaoRepository;

        public AgendamentoConfiguracaoController()
        {
            agendamentoConfiguracaoRepository = new AgendamentoConfiguracaoRepository();
        }


        [HttpGet]
        [Route("/AgendamentoConfiguracao/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgendamentoConfiguracaoDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var configuracoes = agendamentoConfiguracaoRepository.ListarTodos();

                if (configuracoes == null)
                {
                    return NotFound("Não há dados para serem listados.");
                }
                return Ok(configuracoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/AgendamentoConfiguracao/ConsultarPorConfiguracao/{idConfiguracao}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoConfiguracaoRepository))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorConfiguracao(int idConfiguracao)
        {
            try
            {
                var configuracao = agendamentoConfiguracaoRepository.Consultar(idConfiguracao);

                if (configuracao == null)
                {
                    return NotFound("Registro não foi encontrado.");
                }

                return Ok(configuracao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/AgendamentoConfiguracao/CadastrarAgendamentoConfiguracao")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarAgendamentoConfiguracao(AgendamentoConfiguracaoDto configuracao)
        {
            try
            {
                int linhasAfetadas = agendamentoConfiguracaoRepository.Inserir(configuracao);

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
        [Route("/AgendamentoConfiguracao/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AgendamentoConfiguracaoDto configuracao)
        {
            try
            {
                int linhasAfetadas = agendamentoConfiguracaoRepository.Alterar(configuracao);

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
        [Route("/AgendamentoConfiguracao/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idConfiguracao)
        {
            try
            {
                int linhasAfetadas = agendamentoConfiguracaoRepository.Excluir(idConfiguracao);

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