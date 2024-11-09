using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultaController : ControllerBase
{
    private readonly IConsultaApplicationService _consultaApplicationService;

        public ConsultaController(IConsultaApplicationService consultaApplicationService)
        {
            _consultaApplicationService = consultaApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as consultas", Description = "Este endpoint retorna uma lista completa de todas as consultas cadastradas.")]
        [Produces(typeof(IEnumerable<ConsultaEntity>))]
        public IActionResult Get()
        {
            try
            {
                var consultas = _consultaApplicationService.ObterTodasConsultas();

                if (consultas is null)
                    return NoContent();

                return Ok(consultas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("consultas/{id}")]
        [SwaggerOperation(Summary = "Obtém uma consulta específica", Description = "Este endpoint retorna os detalhes de uma consulta específica com base no ID fornecido.")]
        [SwaggerResponse(200, "Consulta encontrada com sucesso", typeof(ConsultaEntity))]
        [SwaggerResponse(204, "Consulta não encontrada")]
        [SwaggerResponse(404, "Falha para obter a consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var consulta = _consultaApplicationService.ObterConsultaPorId(id);

                if (consulta is null)
                    return NoContent();

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova consulta", Description = "Este endpoint cria uma nova consulta com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Consulta criada com sucesso")]
        [SwaggerResponse(404, "Falha para inserir a consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult Post([FromBody] ConsultaDto entity)
        {
            try
            {
                var consulta = _consultaApplicationService.SalvarDadosConsulta(entity);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("consultas/{id}")]
        [SwaggerOperation(Summary = "Atualiza uma consulta existente", Description = "Este endpoint atualiza as informações de uma consulta com base no ID fornecido.")]
        [SwaggerResponse(200, "Consulta atualizada com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar a consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult Put(int id, [FromBody] ConsultaDto entity)
        {
            try
            {
                var consulta = _consultaApplicationService.EditarDadosConsulta(id, entity);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("consultas/{id}")]
        [SwaggerOperation(Summary = "Remove uma consulta existente", Description = "Este endpoint remove as informações de uma consulta com base no ID fornecido.")]
        [SwaggerResponse(200, "Consulta removida com sucesso")]
        [SwaggerResponse(404, "Falha para excluir a consulta")]
        [Produces(typeof(ConsultaEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var consulta = _consultaApplicationService.DeletarDadosConsulta(id);

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
