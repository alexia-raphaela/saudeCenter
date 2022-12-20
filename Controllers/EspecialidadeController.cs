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
    public class EspecialidadeController : Controller
    {
        private readonly EspecialidadeRepository especialidadeRepository;

        public EspecialidadeController()
        {
            especialidadeRepository = new EspecialidadeRepository();
        }


        [HttpGet]
        [Route("/Especialidade/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var especialidades = especialidadeRepository.ListarTodos();

                if (especialidades == null)
                {
                    return NotFound("Não há nenhum registro de especialidade.");
                }
                return Ok(especialidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Especialidade/ConsultarPorEspecialidade/{idEspecialidade}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EspecialidadeRepository))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorEspecialidade(int idEspecialidade)
        {
            try
            {
                var especialidade = especialidadeRepository.Consultar(idEspecialidade);

                if (especialidade == null)
                {
                    return Content("Não foi encontrada a especialidade.");
                }
                return Ok(especialidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Especialidade/CadastrarEspecialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarEspecialidade(Especialidade especialidade)
        {
            try
            {
                int linhasAfetadas = especialidadeRepository.Inserir(especialidade);

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
        [Route("/Especialidade/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(EspecialidadeDto especialidade)
        {
            try
            {
                int linhasAfetadas = especialidadeRepository.Alterar(especialidade);

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
        [Route("/Especialidade/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idEspecialidade)
        {
            try
            {
                int linhasAfetadas = especialidadeRepository.Excluir(idEspecialidade);

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
