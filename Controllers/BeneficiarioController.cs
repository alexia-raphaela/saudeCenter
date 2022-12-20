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
    public class BeneficiarioController : Controller
    {
        private readonly BeneficiarioRepository beneficiarioRepository;

        public BeneficiarioController()
        {
            beneficiarioRepository = new BeneficiarioRepository();
        }


        [HttpGet]
        [Route("/Beneficiario/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var beneficiarios = beneficiarioRepository.ListarTodos();

                if (beneficiarios == null)
                {
                    return NotFound();
                }
                return Ok(beneficiarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/Beneficiario/ConsultarPorBeneficiario/{idBeneficiario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BeneficiarioRepository))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorBeneficiario(int idBeneficiario)
        {
            try
            {
                var beneficiario = beneficiarioRepository.Consultar(idBeneficiario);

                if (beneficiario == null)
                {
                    return NotFound();
                }

                return Ok(beneficiario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/Beneficiario/CadastrarBeneficiario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarBeneficiario(Beneficiario beneficiario)
        {
            try
            {
                int linhasAfetadas = beneficiarioRepository.Inserir(beneficiario);

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
        [Route("/Beneficiario/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(BeneficiarioDto beneficiario)
        {
            try
            {
                int linhasAfetadas = beneficiarioRepository.Alterar(beneficiario);

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
        [Route("/Beneficiario/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idBeneficiario)
        {
            try
            {
                int linhasAfetadas = beneficiarioRepository.Excluir(idBeneficiario);

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
