using byterisk_odontoprev_cs.Application.Dtos;
using byterisk_odontoprev_cs.Application.Interfaces;
using byterisk_odontoprev_cs.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace byterisk_odontoprev_cs.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicoController: ControllerBase
{
    private readonly IMedicoApplicationService _medicoApplicationService;

        public MedicoController(IMedicoApplicationService medicoApplicationService)
        {
            _medicoApplicationService = medicoApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os médicos", Description = "Este endpoint retorna uma lista completa de todos os médicos cadastrados.")]
        [Produces(typeof(IEnumerable<MedicoEntity>))]
        public IActionResult Get()
        {
            try
            {
                var medicos = _medicoApplicationService.ObterTodosMedicos();

                if (medicos is null)
                    return NoContent();

                return Ok(medicos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("medicos/{id}")]
        [SwaggerOperation(Summary = "Obtém um médico específico", Description = "Este endpoint retorna os detalhes de um médico específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Médico encontrado com sucesso", typeof(MedicoEntity))]
        [SwaggerResponse(204, "Médico não encontrado")]
        [SwaggerResponse(404, "Falha para obter o médico")]
        [Produces(typeof(MedicoEntity))]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var medico = _medicoApplicationService.ObterMedicoPorId(id);

                if (medico is null)
                    return NoContent();

                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo médico", Description = "Este endpoint cria um novo médico com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Médico criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o médico")]
        [Produces(typeof(MedicoEntity))]
        public IActionResult Post([FromBody] MedicoDto entity)
        {
            try
            {
                var medico = _medicoApplicationService.SalvarDadosMedico(entity);

                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("medicos/{id}")]
        [SwaggerOperation(Summary = "Atualiza um médico existente", Description = "Este endpoint atualiza as informações de um médico com base no ID fornecido.")]
        [SwaggerResponse(200, "Médico atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o médico")]
        [Produces(typeof(MedicoEntity))]
        public IActionResult Put(int id, [FromBody] MedicoDto entity)
        {
            try
            {
                var medico = _medicoApplicationService.EditarDadosMedico(id, entity);

                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("medicos/{id}")]
        [SwaggerOperation(Summary = "Remove um médico existente", Description = "Este endpoint remove as informações de um médico com base no ID fornecido.")]
        [SwaggerResponse(200, "Médico removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o médico")]
        [Produces(typeof(MedicoEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var medico = _medicoApplicationService.DeletarDadosMedico(id);

                return Ok(medico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}
