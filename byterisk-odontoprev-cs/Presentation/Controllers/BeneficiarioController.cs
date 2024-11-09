using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeneficiarioController : ControllerBase
{
    private readonly IBeneficiarioApplicationService _beneficiarioApplicationService;

        public BeneficiarioController(IBeneficiarioApplicationService beneficiarioApplicationService)
        {
            _beneficiarioApplicationService = beneficiarioApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os beneficiários", Description = "Este endpoint retorna uma lista completa de todos os beneficiários cadastrados.")]
        [Produces(typeof(IEnumerable<BeneficiarioEntity>))]
        public IActionResult Get()
        {
            try
            {
                var beneficiarios = _beneficiarioApplicationService.ObterTodosBeneficiarios();

                if (beneficiarios is null)
                    return NoContent();

                return Ok(beneficiarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("beneficiarios/{id}")]
        [SwaggerOperation(Summary = "Obtém um beneficiário específico", Description = "Este endpoint retorna os detalhes de um beneficiário específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Beneficiário encontrado com sucesso", typeof(BeneficiarioEntity))]
        [SwaggerResponse(204, "Beneficiário não encontrado")]
        [SwaggerResponse(404, "Falha para obter o beneficiário")]
        [Produces(typeof(BeneficiarioEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var beneficiario = _beneficiarioApplicationService.ObterBeneficiarioPorId(id);

                if (beneficiario is null)
                    return NoContent();

                return Ok(beneficiario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo beneficiário", Description = "Este endpoint cria um novo beneficiário com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Beneficiário criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o beneficiário")]
        [Produces(typeof(BeneficiarioEntity))]
        public IActionResult Post([FromBody] BeneficiarioDto entity)
        {
            try
            {
                var beneficiario = _beneficiarioApplicationService.SalvarDadosBeneficiario(entity);

                return Ok(beneficiario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("beneficiarios/{id}")]
        [SwaggerOperation(Summary = "Atualiza um beneficiário existente", Description = "Este endpoint atualiza as informações de um beneficiário com base no ID fornecido.")]
        [SwaggerResponse(200, "Beneficiário atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o beneficiário")]
        [Produces(typeof(BeneficiarioEntity))]
        public IActionResult Put(int id, [FromBody] BeneficiarioDto entity)
        {
            try
            {
                var beneficiario = _beneficiarioApplicationService.EditarDadosBeneficiario(id, entity);

                return Ok(beneficiario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um beneficiário existente", Description = "Este endpoint remove as informações de um beneficiário com base no ID fornecido.")]
        [SwaggerResponse(200, "Beneficiário removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o beneficiário")]
        [Produces(typeof(BeneficiarioEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var beneficiario = _beneficiarioApplicationService.DeletarDadosBeneficiario(id);

                return Ok(beneficiario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
