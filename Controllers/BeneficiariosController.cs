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
    public class BeneficiariosController : Controller
    {
        private readonly BeneficiariosRepository beneficiariosRepository;

        public BeneficiariosController()
        {
            beneficiariosRepository = new BeneficiariosRepository();
        }


        [HttpGet]
        [Route("/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                var beneficiarios = beneficiariosRepository.ListarTodos();

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
        [Route("/ConsultarPorBeneficiario/{idBeneficiario}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BeneficiarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConsultarPorBeneficiario(int idBeneficiario)
        {
            try
            {
                var beneficiarios = beneficiariosRepository.Consultar(idBeneficiario);

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

        [HttpPost]
        [Route("/CadastrarBeneficiario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarBeneficiario(Beneficiario beneficiario)
        {
            try
            {
                int linhasAfetadas = beneficiariosRepository.Inserir(beneficiario);

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

        [HttpDelete]
        [Route("/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int idBeneficiario)
        {
            try
            {
                int linhasAfetadas = beneficiariosRepository.Excluir(idBeneficiario);

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

        [HttpPatch]
        [Route("/Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizar(Beneficiario beneficiario)
        {
            try
            {
                int linhasAfetadas = beneficiariosRepository.Alterar(beneficiario);

                if (linhasAfetadas == 0)
                {
                    return BadRequest("Nenhum Cadastro foi Atualizado.");
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
