using Overloop.HealthScheduleApp.Application.DTOs;

namespace Overloop.HealthScheduleApp.Application.Interfaces;

public interface IPacienteApplicationService : IApplicationService
{
    Task<PacienteDto> CreateAsync(CreatePacienteDto createPacienteDto);
    Task<PacienteDto> GetByIdAsync(Guid id);
}
