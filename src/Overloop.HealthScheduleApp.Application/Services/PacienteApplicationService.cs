using Overloop.HealthScheduleApp.Application.DTOs;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Overloop.HealthScheduleApp.Domain.Entities;
using Overloop.HealthScheduleApp.Domain.Interfaces;

namespace Overloop.HealthScheduleApp.Application.Services;

public class PacienteApplicationService : IPacienteApplicationService
{
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteApplicationService(IPacienteRepository pacienteRepository)
    {
        _pacienteRepository = pacienteRepository;
    }

    public async Task<PacienteDto> CreateAsync(CreatePacienteDto createPacienteDto)
    {
        var paciente = new Paciente
        {
            Id = Guid.NewGuid(),
            Nome = createPacienteDto.Nome,
            Email = createPacienteDto.Email
        };

        await _pacienteRepository.AddAsync(paciente);

        return new PacienteDto
        {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Email = paciente.Email
        };
    }

    public async Task<PacienteDto> GetByIdAsync(Guid id)
    {
        var paciente = await _pacienteRepository.GetByIdAsync(id);
        if (paciente == null)
        {
            return null;
        }

        return new PacienteDto
        {
            Id = paciente.Id,
            Nome = paciente.Nome,
            Email = paciente.Email
        };
    }
}
