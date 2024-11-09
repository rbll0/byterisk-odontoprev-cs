using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExameController : ControllerBase
{
    private readonly IExameApplicationService _exameApplicationService;

        public ExameController(IExameApplicationService exameApplicationService)
        {
            _exameApplicationService = exameApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os exames", Description = "Este endpoint retorna uma lista completa de todos os exames cadastrados.")]
        [Produces(typeof(IEnumerable<ExameEntity>))]
        public IActionResult Get()
        {
            try
            {
                var exames = _exameApplicationService.ObterTodosExames();

                if (exames is null)
                    return NoContent();

                return Ok(exames);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exames/{id}")]
        [SwaggerOperation(Summary = "Obtém um exame específico", Description = "Este endpoint retorna os detalhes de um exame específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Exame encontrado com sucesso", typeof(ExameEntity))]
        [SwaggerResponse(204, "Exame não encontrado")]
        [SwaggerResponse(404, "Falha para obter o exame")]
        [Produces(typeof(ExameEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var exame = _exameApplicationService.ObterExamePorId(id);

                if (exame is null)
                    return NoContent();

                return Ok(exame);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo exame", Description = "Este endpoint cria um novo exame com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Exame criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o exame")]
        [Produces(typeof(ExameEntity))]
        public IActionResult Post([FromBody] ExameDto entity)
        {
            try
            {
                var exame = _exameApplicationService.SalvarDadosExame(entity);

                return Ok(exame);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("exames/{id}")]
        [SwaggerOperation(Summary = "Atualiza um exame existente", Description = "Este endpoint atualiza as informações de um exame com base no ID fornecido.")]
        [SwaggerResponse(200, "Exame atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o exame")]
        [Produces(typeof(ExameEntity))]
        public IActionResult Put(int id, [FromBody] ExameDto entity)
        {
            try
            {
                var exame = _exameApplicationService.EditarDadosExame(id, entity);

                return Ok(exame);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("exames/{id}")]
        [SwaggerOperation(Summary = "Remove um exame existente", Description = "Este endpoint remove as informações de um exame com base no ID fornecido.")]
        [SwaggerResponse(200, "Exame removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o exame")]
        [Produces(typeof(ExameEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var exame = _exameApplicationService.DeletarDadosExame(id);

                return Ok(exame);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
