using Overloop.HealthScheduleApp.Application.DTOs;

namespace Overloop.HealthScheduleApp.Application.Interfaces;

public interface IMedicoApplicationService : IApplicationService
{
    Task<MedicoDto> CreateAsync(CreateMedicoDto createMedicoDto);
    Task<MedicoDto> GetByIdAsync(Guid id);
}
