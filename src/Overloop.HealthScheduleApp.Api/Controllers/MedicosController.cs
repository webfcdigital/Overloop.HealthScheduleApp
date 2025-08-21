using Microsoft.AspNetCore.Mvc;
using Overloop.HealthScheduleApp.Application.DTOs;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Overloop.HealthScheduleApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MedicosController : ControllerBase
{
    private readonly IMedicoApplicationService _medicoApplicationService;

    public MedicosController(IMedicoApplicationService medicoApplicationService)
    {
        _medicoApplicationService = medicoApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMedicoDto createMedicoDto)
    {
        var medico = await _medicoApplicationService.CreateAsync(createMedicoDto);
        return CreatedAtAction(nameof(GetById), new { id = medico.Id }, medico);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var medico = await _medicoApplicationService.GetByIdAsync(id);
        if (medico == null)
        {
            return NotFound();
        }
        return Ok(medico);
    }
}
