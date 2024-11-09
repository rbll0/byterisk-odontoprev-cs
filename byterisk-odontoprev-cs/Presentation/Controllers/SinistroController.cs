using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SinistroController : ControllerBase
{
    private readonly ISinistroApplicationService _sinistroApplicationService;

        public SinistroController(ISinistroApplicationService sinistroApplicationService)
        {
            _sinistroApplicationService = sinistroApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os sinistros", Description = "Este endpoint retorna uma lista completa de todos os sinistros cadastrados.")]
        [Produces(typeof(IEnumerable<SinistroEntity>))]
        public IActionResult Get()
        {
            try
            {
                var sinistros = _sinistroApplicationService.ObterTodosSinistros();

                if (sinistros is null)
                    return NoContent();

                return Ok(sinistros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sinistro/{id}")]
        [SwaggerOperation(Summary = "Obtém um sinistro específico", Description = "Este endpoint retorna os detalhes de um sinistro específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Sinistro encontrado com sucesso", typeof(SinistroEntity))]
        [SwaggerResponse(204, "Sinistro não encontrado")]
        [SwaggerResponse(404, "Falha para obter o sinistro")]
        [Produces(typeof(SinistroEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var sinistro = _sinistroApplicationService.ObterSinistroPorId(id);

                if (sinistro is null)
                    return NoContent();

                return Ok(sinistro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo sinistro", Description = "Este endpoint cria um novo sinistro com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Sinistro criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o sinistro")]
        [Produces(typeof(SinistroEntity))]
        public IActionResult Post([FromBody] SinistroDto entity)
        {
            try
            {
                var sinistro = _sinistroApplicationService.SalvarDadosSinistro(entity);

                return Ok(sinistro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("sinistro/{id}")]
        [SwaggerOperation(Summary = "Atualiza um sinistro existente", Description = "Este endpoint atualiza as informações de um sinistro com base no ID fornecido.")]
        [SwaggerResponse(200, "Sinistro atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o sinistro")]
        [Produces(typeof(SinistroEntity))]
        public IActionResult Put(int id, [FromBody] SinistroDto entity)
        {
            try
            {
                var sinistro = _sinistroApplicationService.EditarDadosSinistro(id, entity);

                return Ok(sinistro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("sinistro/{id}")]
        [SwaggerOperation(Summary = "Remove um sinistro existente", Description = "Este endpoint remove as informações de um sinistro com base no ID fornecido.")]
        [SwaggerResponse(200, "Sinistro removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o sinistro")]
        [Produces(typeof(SinistroEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var sinistro = _sinistroApplicationService.DeletarDadosSinistro(id);

                return Ok(sinistro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
