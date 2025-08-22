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

    /// <summary>
    /// Creates a new consultation.
    /// </summary>
    /// <param name="createConsultaDto">The consultation data.</param>
    /// <returns>A newly created consultation.</returns>
    /// <response code="201">Returns the newly created consultation.</response>
    /// <response code="400">If the consultation data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateConsultaDto createConsultaDto)
    {
        var consulta = await _consultaApplicationService.CreateAsync(createConsultaDto);
        return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
    }

    /// <summary>
    /// Gets a consultation by its ID.
    /// </summary>
    /// <param name="id">The ID of the consultation.</param>
    /// <returns>The consultation with the specified ID.</returns>
    /// <response code="200">Returns the consultation.</response>
    /// <response code="404">If the consultation is not found.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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