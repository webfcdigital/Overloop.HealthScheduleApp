using Microsoft.AspNetCore.Mvc;
using Overloop.HealthScheduleApp.Application.DTOs;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Overloop.HealthScheduleApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ConsultasController : ControllerBase
{
    private readonly IConsultaApplicationService _consultaApplicationService;

    public ConsultasController(IConsultaApplicationService consultaApplicationService)
    {
        _consultaApplicationService = consultaApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateConsultaDto createConsultaDto)
    {
        var consulta = await _consultaApplicationService.CreateAsync(createConsultaDto);
        return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var consulta = await _consultaApplicationService.GetByIdAsync(id);
        if (consulta == null)
        {
            return NotFound();
        }
        return Ok(consulta);
    }
}
