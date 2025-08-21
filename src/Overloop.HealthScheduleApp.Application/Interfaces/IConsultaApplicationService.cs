using Overloop.HealthScheduleApp.Application.DTOs;

namespace Overloop.HealthScheduleApp.Application.Interfaces;

public interface IConsultaApplicationService : IApplicationService
{
    Task<ConsultaDto> CreateAsync(CreateConsultaDto createConsultaDto);
    Task<ConsultaDto> GetByIdAsync(Guid id);
}