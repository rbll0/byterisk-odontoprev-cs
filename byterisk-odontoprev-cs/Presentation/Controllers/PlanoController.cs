using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlanoController : ControllerBase
{
    private readonly IPlanoApplicationService _planoApplicationService;

        public PlanoController(IPlanoApplicationService planoApplicationService)
        {
            _planoApplicationService = planoApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os planos", Description = "Este endpoint retorna uma lista completa de todos os planos cadastrados.")]
        [Produces(typeof(IEnumerable<PlanoEntity>))]
        public IActionResult Get()
        {
            try
            {
                var planos = _planoApplicationService.ObterTodosPlanos();

                if (planos is null)
                    return NoContent();

                return Ok(planos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("plano/{id}")]
        [SwaggerOperation(Summary = "Obtém um plano específico", Description = "Este endpoint retorna os detalhes de um plano específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Plano encontrado com sucesso", typeof(PlanoEntity))]
        [SwaggerResponse(204, "Plano não encontrado")]
        [SwaggerResponse(404, "Falha para obter o plano")]
        [Produces(typeof(PlanoEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var plano = _planoApplicationService.ObterPlanoPorId(id);

                if (plano is null)
                    return NoContent();

                return Ok(plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo plano", Description = "Este endpoint cria um novo plano com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Plano criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o plano")]
        [Produces(typeof(PlanoEntity))]
        public IActionResult Post([FromBody] PlanoDto entity)
        {
            try
            {
                var plano = _planoApplicationService.SalvarDadosPlano(entity);

                return Ok(plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("plano/{id}")]
        [SwaggerOperation(Summary = "Atualiza um plano existente", Description = "Este endpoint atualiza as informações de um plano com base no ID fornecido.")]
        [SwaggerResponse(200, "Plano atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o plano")]
        [Produces(typeof(PlanoEntity))]
        public IActionResult Put(int id, [FromBody] PlanoDto entity)
        {
            try
            {
                var plano = _planoApplicationService.EditarDadosPlano(id, entity);

                return Ok(plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("plano/{id}")]
        [SwaggerOperation(Summary = "Remove um plano existente", Description = "Este endpoint remove as informações de um plano com base no ID fornecido.")]
        [SwaggerResponse(200, "Plano removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o plano")]
        [Produces(typeof(PlanoEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var plano = _planoApplicationService.DeletarDadosPlano(id);

                return Ok(plano);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
