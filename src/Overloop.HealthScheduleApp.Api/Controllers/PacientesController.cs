using Microsoft.AspNetCore.Mvc;
using Overloop.HealthScheduleApp.Application.DTOs;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Overloop.HealthScheduleApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PacientesController : ControllerBase
{
    private readonly IPacienteApplicationService _pacienteApplicationService;

    public PacientesController(IPacienteApplicationService pacienteApplicationService)
    {
        _pacienteApplicationService = pacienteApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePacienteDto createPacienteDto)
    {
        var paciente = await _pacienteApplicationService.CreateAsync(createPacienteDto);
        return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var paciente = await _pacienteApplicationService.GetByIdAsync(id);
        if (paciente == null)
        {
            return NotFound();
        }
        return Ok(paciente);
    }
}
