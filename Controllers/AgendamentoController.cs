using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudeCenter.Dto;
using SaudeCenter.Entidades;
using SaudeCenter.Repository;
using SaudeCenter.Validation;

namespace SaudeCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly AgendamentoRepository agendamentoRepository;
        private readonly AgendamentoValidation agendamentoValidation;
        int linhasAfetadas;

        public AgendamentoController()
        {
            agendamentoRepository = new AgendamentoRepository();
            agendamentoValidation = new AgendamentoValidation();
        }


        [HttpGet]
        [Route("/Agendamento/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AgendamentoDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var agendamento = agendamentoRepository.ListarTodos();

                if (agendamento == null)
                {
                    return NotFound("Não há agendamentos");
                }
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Agendamento/ConsultarPorAgendamento/{idAgendamento}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AgendamentoRepository))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorAgendamentoo(int idAgendamento)
        {
            try
            {
                var agendamento = agendamentoRepository.Consultar(idAgendamento);

                if (agendamento == null)
                {
                    return NotFound("Não há agendamentos");
                }

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Agendamento/CadastrarAgendamento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarBeneficiario(AgendamentoDto agendamento)
        {
            try
            {
                var validacao = agendamentoValidation.validacao(agendamento);
                if (string.IsNullOrEmpty(validacao))
                {
                    linhasAfetadas = agendamentoRepository.Inserir(agendamento);

                    if (linhasAfetadas == 0)
                    {
                        return BadRequest("Nenhum Cadastro foi realizado.");
                    }
                }
                else
                {
                    return BadRequest(validacao);
                }
                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("/Agendamento/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(AgendamentoDto agendamento)
        {
            try
            {
                int linhasAfetadas = agendamentoRepository.Alterar(agendamento);
                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum Agendamento foi atualizado.");
                }

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/Agendamento/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idAgendamento)
        {
            try
            {
                int linhasAfetadas = agendamentoRepository.Excluir(idAgendamento);

                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum Agendamento foi excluído.");
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